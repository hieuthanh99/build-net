using DevExpress.Web;
using DocumentFormat.OpenXml.Packaging;
using DocumentFormat.OpenXml.Spreadsheet;
using KTQTData;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Web.UI.WebControls;

public partial class Imports_ImportUnit : BasePage
{
    KTQTDataEntities entities = new KTQTDataEntities();

    string fileStorage = ConfigurationManager.AppSettings["FileStorage"];
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            if (this.cboFileType.Value != null)
            {
                var fileType = this.cboFileType.Value.ToString();

                GenerateCols(this.DataHistoryGrid, fileType);
                LoadHistories(fileType);
            }
        }

    }

    #region LoadData
    private void LoadHistories(string fileType)
    {
        var list = entities.ETHistories.Where(x => x.ETCode == fileType).OrderByDescending(x => x.HistoryID).ToList();
        this.FileHistoryGrid.DataSource = list;
        this.FileHistoryGrid.DataBind();
    }
    private void LoadDataHistories(decimal historyID)
    {
        var list = entities.ETDataHistories.Where(x => x.HistoryID == historyID).OrderBy(x => x.Seq).ToList();
        this.DataHistoryGrid.DataSource = list;
        this.DataHistoryGrid.DataBind();
    }
    #endregion
    protected void cboFileType_Init(object sender, EventArgs e)
    {
        var list = entities.ETParameters.Where(x => x.ETCode == "UNIT").OrderBy(x => x.ETCode).ToList();
        this.cboFileType.DataSource = list;
        this.cboFileType.ValueField = "ETCode";
        this.cboFileType.TextField = "Name";
        this.cboFileType.DataBind();
        if (this.cboFileType.Items.Count > 0)
            this.cboFileType.SelectedItem = this.cboFileType.Items[0];
    }

    private void SaveFile(string filePath, UploadedFile file)
    {
        string aDirectoryPath = Path.GetDirectoryName(filePath);
        if (!Directory.Exists(aDirectoryPath))
        {
            Directory.CreateDirectory(aDirectoryPath);
        }
        file.SaveAs(filePath);
    }

    public static System.Data.DataTable ReadAsDataTable(string fileName)
    {
        System.Data.DataTable dataTable = new System.Data.DataTable();
        using (SpreadsheetDocument spreadSheetDocument = SpreadsheetDocument.Open(fileName, false))
        {
            WorkbookPart workbookPart = spreadSheetDocument.WorkbookPart;
            IEnumerable<Sheet> sheets = spreadSheetDocument.WorkbookPart.Workbook.GetFirstChild<Sheets>().Elements<Sheet>();
            string relationshipId = sheets.First().Id.Value;
            WorksheetPart worksheetPart = (WorksheetPart)spreadSheetDocument.WorkbookPart.GetPartById(relationshipId);
            Worksheet workSheet = worksheetPart.Worksheet;
            SheetData sheetData = workSheet.GetFirstChild<SheetData>();
            IEnumerable<Row> rows = sheetData.Descendants<Row>();
            foreach (Cell cell in rows.ElementAt(5))
            {
                string col = GetCellValue(spreadSheetDocument, cell);
                if (!dataTable.Columns.Contains(col))
                    dataTable.Columns.Add(col);
                else
                {
                    col += dataTable.Columns.Count;
                    dataTable.Columns.Add(col);
                }
            }
            foreach (Row row in rows)
            {
                if (row.RowIndex.HasValue && row.RowIndex.Value <= 7)
                    continue;
                System.Data.DataRow dataRow = dataTable.NewRow();
                for (int i = 0; i < row.Descendants<Cell>().Count(); i++)
                {
                    dataRow[i] = GetCellValue(spreadSheetDocument, row.Descendants<Cell>().ElementAt(i));
                }
                dataTable.Rows.Add(dataRow);
            }
        }
        //dataTable.Rows.RemoveAt(0);        
        return dataTable;
    }
    private static string GetCellValue(SpreadsheetDocument document, Cell cell)
    {
        SharedStringTablePart stringTablePart = document.WorkbookPart.SharedStringTablePart;
        string value = cell.CellValue != null ? cell.CellValue.InnerXml : string.Empty;
        if (cell.DataType != null && cell.DataType.Value == CellValues.SharedString)
        {
            return stringTablePart.SharedStringTable.ChildElements[Int32.Parse(value)].InnerText;
        }
        else
        {
            return value;
        }
    }
    protected void UploadControl_FilesUploadComplete(object sender, FilesUploadCompleteEventArgs e)
    {
        for (int i = 0; i < UploadControl.UploadedFiles.Length; i++)
        {
            UploadedFile file = UploadControl.UploadedFiles[i];

            if (file.FileName != "" && file.IsValid)
            {
                try
                {
                    string fileName = Path.Combine(fileStorage + @"QuantityFiles\", SessionUser.UserName, file.FileName);
                    SaveFile(fileName, file);
                    e.CallbackData = fileName;
                }
                catch (Exception ex)
                {
                    e.CallbackData = "error";
                    e.ErrorText = ex.Message;
                }
            }
        }
    }
    private ETHistory InsertHistory(string fileName, string fileType)
    {
        FileInfo fi = new FileInfo(fileName);

        var entity = new ETHistory();
        entity.StatusDL = true;
        entity.StatusTR = false;
        entity.ETCode = fileType;
        entity.FileName = fi.Name;
        entity.FilePath = fileName;
        entity.IssueDate = DateTime.Now;
        entity.SizeOfFile = fi.Length;
        entity.Remark = "SUCCESS";
        entity.CreateDate = DateTime.Now;
        entity.CreatedBy = (int)SessionUser.UserID;

        entities.ETHistories.Add(entity);
        entities.SaveChanges();

        return entity;
    }
    protected void FileHistoryGrid_CustomCallback(object sender, ASPxGridViewCustomCallbackEventArgs e)
    {
        ASPxGridView s = sender as ASPxGridView;
        string[] args = e.Parameters.Split('|');

        s.JSProperties["cpCommand"] = args[0];

        if (args[0] == "LoadHistory")
        {
            string fileType = args[1];
            LoadHistories(fileType);
        }

        if (args[0] == "ProcessFile")
        {
            string fileName = args[1];
            string fileType = args[2];

            if (!File.Exists(fileName))
                return;

            var history = InsertHistory(fileName, fileType);

            System.Data.DataTable dataTable = ReadAsDataTable(fileName).Rows
                    .Cast<System.Data.DataRow>()
                    .Where(row => !row.ItemArray.All(field => field is DBNull
                     || string.IsNullOrWhiteSpace(field as string)))
                     .CopyToDataTable();

            var exist = entities.ETColumns.Where(x => x.ETCode == fileType).Any();
            if (!exist)
            {
                int colCount = 0;
                foreach (System.Data.DataColumn col in dataTable.Columns)
                {
                    colCount += 1;
                    var entity = new ETColumn();
                    entity.ETCode = fileType;
                    entity.Seq = colCount;
                    entity.ColumnName = col.ColumnName;
                    entity.MapingColumn = "ATT" + (colCount - 1);

                    entity.CreateDate = DateTime.Now;
                    entity.CreatedBy = SessionUser.UserID;

                    entities.ETColumns.Add(entity);
                }
                entities.SaveChanges();
            }

            int cols = dataTable.Columns.Count;
            int rowCount = 0;
            foreach (System.Data.DataRow row in dataTable.Rows)
            {
                rowCount += 1;
                var entity = new ETDataHistory();
                Type type = entity.GetType();
                for (int i = 0; i < cols; i++)
                {
                    PropertyInfo pi = type.GetProperty("ATT" + i);
                    var value = row[i] != DBNull.Value ? row[i].ToString() : string.Empty;
                    pi.SetValue(entity, value);
                }
                entity.HistoryID = history.HistoryID;
                entity.Seq = rowCount;
                entities.ETDataHistories.Add(entity);
            }
            history.SumRC = dataTable.Rows.Count;
            history.SumInsert = rowCount;
            history.SumCol = cols;
            entities.SaveChanges();

            LoadHistories(fileType);
        }
    }
    protected void DataHistoryGrid_CustomCallback(object sender, ASPxGridViewCustomCallbackEventArgs e)
    {
        ASPxGridView s = sender as ASPxGridView;
        string[] args = e.Parameters.Split('|');
        if (args[0] == "LoadDataHistory")
        {
            decimal key;
            if (!decimal.TryParse(args[1], out key))
                return;

            GenerateCols(s, "UNIT");
            LoadDataHistories(key);
        }
    }

    private void GenerateCols(ASPxGridView s, string etCode)
    {
        try
        {
            s.Columns.Clear();
            //for (int i = 0; i < s.Columns.Count - 2; i++)
            //{
            //    s.DataColumns["ATT" + i].Visible = false;
            //}
            var col = new GridViewDataColumn();
            col.FieldName = "Seq";
            col.Visible = true;
            col.VisibleIndex = 0;
            col.Caption = "Seq";
            col.HeaderStyle.HorizontalAlign = System.Web.UI.WebControls.HorizontalAlign.Center;
            col.HeaderStyle.Wrap = DevExpress.Utils.DefaultBoolean.True;
            col.Settings.AutoFilterCondition = AutoFilterCondition.Contains;
            col.Width = 50;
            s.Columns.Add(col);

            var columns = entities.ETColumns.Where(x => x.ETCode == etCode).OrderBy(x => x.Seq).ToList();
            for (int i = 0; i <= columns.Count - 1; i++)
            {
                col = new GridViewDataColumn();
                col.FieldName = columns[i].MapingColumn;
                col.Visible = true;
                col.VisibleIndex = i + 1;
                col.Caption = StringUtils.isEmpty(columns[i].Description) ? columns[i].ColumnName.Replace("_", " ") : columns[i].Description.Replace("_", " ");
                col.HeaderStyle.HorizontalAlign = System.Web.UI.WebControls.HorizontalAlign.Center;
                col.HeaderStyle.Wrap = DevExpress.Utils.DefaultBoolean.True;
                col.Settings.AutoFilterCondition = AutoFilterCondition.Contains;
                col.Width = 120;// columns[i].DataLength.HasValue ? columns[i].DataLength.Value : 120;
                s.Columns.Add(col);
                //s.DataColumns["ATT" + i].Visible = true;
                //s.DataColumns["ATT" + i].VisibleIndex = (i + 1);
                //s.DataColumns["ATT" + i].Caption = StringUtils.isEmpty(columns[i].Description) ? columns[i].ColumnName : columns[i].Description;
            }

            //int j = 0;
            //foreach (var col in columns)
            //{
            //    s.DataColumns["ATT" + j].Caption = StringUtils.isEmpty(col.Description) ? col.ColumnName : col.Description;
            //    j += 1;
            //}
        }
        catch (Exception ex)
        {
            //throw ex;
        }

    }
}