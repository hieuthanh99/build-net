using DevExpress.Web;
using DocumentFormat.OpenXml.Packaging;
using DocumentFormat.OpenXml.Spreadsheet;
using KTQTData;
using OfficeOpenXml;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.IO;
using System.Linq;
using System.Reflection;


public partial class Imports_UploadCost : BasePage
{
    KTQTDataEntities entities = new KTQTDataEntities();
    const string KEY = "fb39f17d-5770-4924-b6d7-03075464e604";
    string fileStorage = ConfigurationManager.AppSettings["FileStorage"];
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            Session[KEY] = null;
            if (this.cboFileType.Value != null)
            {
                var fileType = this.cboFileType.Value.ToString();
                LoadHistories(fileType);
            }
        }

        if (this.DataHistoryGrid.IsCallback && Session[KEY] != null)
        {
            decimal key;
            if (decimal.TryParse(Session[KEY].ToString(), out key))
            {
                GenerateCols(this.DataHistoryGrid, key);
                LoadDataHistories(key);
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

    private void LoadPlanVersion()
    {
        var list = entities.Versions.Where(x => x.Status != "APPROVED").OrderByDescending(x => x.VersionYear).OrderBy(x => x.Sorting).ToList();
        this.VersionGrid.DataSource = list;
        this.VersionGrid.DataBind();
    }

    #endregion
    protected void cboFileType_Init(object sender, EventArgs e)
    {
        var list = entities.ETParameters.Where(x => x.ETCode == "ULCOST").OrderBy(x => x.ETCode).ToList();
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
        dataTable.Rows.RemoveAt(0);
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
        else if (cell.DataType != null && cell.DataType.Value == CellValues.Number)
        {
            return DateTime.FromOADate(Convert.ToDouble(stringTablePart.SharedStringTable.ChildElements[Int32.Parse(value)].InnerText)).ToShortDateString();
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

                    e.CallbackData = file.FileName;
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
            string fileName = Path.Combine(fileStorage + @"QuantityFiles\", SessionUser.UserName, args[1]);
            string fileType = args[2];
            string sheetName = args[3];

            if (!File.Exists(fileName))
                return;

            var etParams = entities.ETParameters.SingleOrDefault(x => x.ETCode == fileType);
            if (etParams == null)
                return;

            var history = InsertHistory(fileName, fileType);

            var cols = entities.ETColumns.Where(x => x.ETCode == fileType).Count();

            int rowCount = 0;

            using (ExcelPackage package = new ExcelPackage(new FileInfo(fileName)))
            {
                ExcelWorksheet workSheet = package.Workbook.Worksheets[sheetName];

                for (var rowNumber = 9; rowNumber <= workSheet.Dimension.End.Row; rowNumber++)
                {
                    rowCount += 1;
                    var entity = new ETDataHistory();

                    Type type = entity.GetType();
                    for (int i = 0; i < cols; i++)
                    {
                        PropertyInfo pi = type.GetProperty("ATT" + i);
                        object value = workSheet.GetValue(rowNumber, i + 1);
                        //if (value != null && !StringUtils.isEmpty(value.ToString()))
                        //    pi.SetValue(entity, value.ToString());
                    }

                    entity.HistoryID = history.HistoryID;
                    entity.Seq = rowCount;
                    entities.ETDataHistories.Add(entity);
                }
            }

            //System.Data.DataTable dataTable = ReadAsDataTable(fileName).Rows
            //        .Cast<System.Data.DataRow>()
            //        .Where(row => !row.ItemArray.All(field => field is DBNull
            //         || string.IsNullOrWhiteSpace(field as string)))
            //         .CopyToDataTable();

            //int cols = dataTable.Columns.Count;
            // int rowCount = 0;
            //foreach (System.Data.DataRow row in dataTable.Rows)
            //{
            //    rowCount += 1;
            //    var entity = new ETDataHistory();
            //    Type type = entity.GetType();
            //    for (int i = 0; i < cols; i++)
            //    {
            //        PropertyInfo pi = type.GetProperty("ATT" + i);
            //        var value = row[i] != DBNull.Value ? row[i].ToString() : string.Empty;
            //        pi.SetValue(entity, value);
            //    }
            //    entity.HistoryID = history.HistoryID;
            //    entity.Seq = rowCount;
            //    entities.ETDataHistories.Add(entity);
            //}

            history.SumRC = rowCount;
            history.SumInsert = rowCount;
            history.SumCol = cols;
            entities.SaveChanges();

            LoadHistories(fileType);
        }

        if (args[0] == "ApplyToVersion")
        {
            decimal versionID;
            decimal hisID;
            if (!decimal.TryParse(args[1], out versionID))
                return;

            if (!decimal.TryParse(args[2], out hisID))
                return;

            var entity = entities.ETHistories.SingleOrDefault(x => x.HistoryID == hisID);

            entities.TransferUploadCostRevData(versionID, hisID, SessionUser.UserID);

            LoadHistories(entity.ETCode);
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

            GenerateCols(s, key);

            Session[KEY] = key;
            LoadDataHistories(key);
        }
    }

    private void GenerateCols(ASPxGridView s, decimal key)
    {
        for (int i = 0; i < s.Columns.Count - 1; i++)
        {
            s.DataColumns["ATT" + i].Visible = false;
        }

        var history = entities.ETHistories.SingleOrDefault(x => x.HistoryID == key);

        if (history != null)
        {
            var columns = entities.ETColumns.Where(x => x.ETCode == history.ETCode).OrderBy(x => x.Seq).ToList();
            for (int i = 0; i < columns.Count; i++)
            {
                s.DataColumns["ATT" + i].Visible = true;
                s.DataColumns["ATT" + i].VisibleIndex = (i + 1);
            }

            int j = 0;
            foreach (var col in columns)
            {
                s.DataColumns["ATT" + j].Caption = StringUtils.isEmpty(col.Description) ? col.ColumnName : col.Description;
                j += 1;
            }

        }
    }
    protected void SheetListBox_Callback(object sender, CallbackEventArgsBase e)
    {
        ASPxListBox lb = sender as ASPxListBox;
        string[] args = e.Parameter.Split('|');
        if (args[0] == "GetAllSheets")
        {
            string fileName = Path.Combine(fileStorage + @"QuantityFiles\", SessionUser.UserName, args[1]);

            if (!File.Exists(fileName))
                return;

            using (ExcelPackage package = new ExcelPackage(new FileInfo(fileName)))
            {
                foreach (var worksheet in package.Workbook.Worksheets)
                {
                    var item = new ListEditItem();
                    item.Value = worksheet.Name;
                    item.Text = worksheet.Name;
                    lb.Items.Add(item);
                }
            }

        }
    }
    protected void VersionGrid_CustomCallback(object sender, ASPxGridViewCustomCallbackEventArgs e)
    {
        var args = e.Parameters.Split('|');
        if (args[0] == "LoadVersion")
        {
            LoadPlanVersion();
        }
    }
    protected void cboArea1_Init(object sender, EventArgs e)
    {
        ASPxComboBox s = sender as ASPxComboBox;

        var list = entities.Airports.ToList();

        s.DataSource = list;

        s.ValueField = "Code";
        s.TextField = "NameE";
        s.DataBind();
        if (s.Items.Count > 0)
            s.Value = SessionUser.AreaCode;
    }
}