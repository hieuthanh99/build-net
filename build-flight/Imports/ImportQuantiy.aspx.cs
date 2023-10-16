
using APPLibs;
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


public partial class Imports_ImportQuantiy : BasePage
{
    KTQTDataEntities entities = new KTQTDataEntities();
    const string KEY = "fb39f17d-5770-4924-b6d7-03075464e604";
    string fileStorage = ConfigurationManager.AppSettings["FileStorage"];
    string domain = ConfigurationManager.AppSettings["Domain"];
    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            LoadUser();
            LoadVersion();
            LoadCompany();
            if (!IsPostBack)
                Session[KEY] = null;

            if (this.cboFileType.Value != null)
            {
                var fileType = this.cboFileType.Value.ToString();
                LoadHistories(fileType);
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

            if (this.VersionGrid.IsCallback)
                this.LoadVersions();

        }
        catch (Exception ex)
        {
            throw ex;
        }
    }

    #region LoadData
    private void LoadUser()
    {
        GridViewDataComboBoxColumn aCombo = (GridViewDataComboBoxColumn)ImportErrorGrid.Columns["CreateBy"];
        GridViewDataComboBoxColumn aCombo1 = (GridViewDataComboBoxColumn)TransferDataHistoryGrid.Columns["UserID"];
        GridViewDataComboBoxColumn aCombo2 = (GridViewDataComboBoxColumn)TransferDataHistoryGrid.Columns["CreateBy"];

        using (APPData.QLKHAppEntities context = new APPData.QLKHAppEntities())
        {
            var list = context.Users.Where(x => x.IsDeleted == false).ToList();
            aCombo.PropertiesComboBox.DataSource = list;
            aCombo.PropertiesComboBox.ValueField = "UserID";
            aCombo.PropertiesComboBox.TextField = "DisplayName";

            aCombo1.PropertiesComboBox.DataSource = list;
            aCombo1.PropertiesComboBox.ValueField = "UserID";
            aCombo1.PropertiesComboBox.TextField = "DisplayName";

            aCombo2.PropertiesComboBox.DataSource = list;
            aCombo2.PropertiesComboBox.ValueField = "UserID";
            aCombo2.PropertiesComboBox.TextField = "DisplayName";

        }
    }

    private void LoadVersion()
    {
        GridViewDataComboBoxColumn aCombo = (GridViewDataComboBoxColumn)ImportErrorGrid.Columns["VersionID"];
        GridViewDataComboBoxColumn aCombo1 = (GridViewDataComboBoxColumn)TransferDataHistoryGrid.Columns["VersionID"];


        var list = entities.Versions.ToList();
        aCombo.PropertiesComboBox.DataSource = list;
        aCombo.PropertiesComboBox.ValueField = "VersionID";
        aCombo.PropertiesComboBox.TextField = "VersionName";

        aCombo1.PropertiesComboBox.DataSource = list;
        aCombo1.PropertiesComboBox.ValueField = "VersionID";
        aCombo1.PropertiesComboBox.TextField = "VersionName";


    }

    private void LoadCompany()
    {
        GridViewDataComboBoxColumn aCombo1 = (GridViewDataComboBoxColumn)TransferDataHistoryGrid.Columns["CompanyID"];

        var list = entities.DecCompanies.ToList();

        aCombo1.PropertiesComboBox.DataSource = list;
        aCombo1.PropertiesComboBox.ValueField = "CompanyID";
        aCombo1.PropertiesComboBox.TextField = "NameV";


    }
    private void LoadHistories(string fileType)
    {
        if (!(SessionUser.IsInRole(PermissionConstant.ADMINISTRATOR)))
        {
            var userId = SessionUser.UserID;
            var list = entities.ETHistories.Where(x => x.ETCode == fileType && x.CreatedBy == userId).OrderByDescending(x => x.HistoryID).ToList();
            this.FileHistoryGrid.DataSource = list;
            this.FileHistoryGrid.DataBind();
        }
        else
        {
            var list = entities.ETHistories.Where(x => x.ETCode == fileType).OrderByDescending(x => x.HistoryID).ToList();
            this.FileHistoryGrid.DataSource = list;
            this.FileHistoryGrid.DataBind();
        }
    }
    private void LoadDataHistories(decimal historyID)
    {
        var list = entities.ETDataHistories.Where(x => x.HistoryID == historyID).OrderBy(x => x.Seq).ToList();
        this.DataHistoryGrid.DataSource = list;
        this.DataHistoryGrid.DataBind();
    }

    private void LoadVersions()
    {
        var list = entities.Versions.Where(x => x.Status != "APPROVED" && x.Active == true).OrderByDescending(x => x.VersionYear).ThenBy(x => x.Sorting).ToList();
        this.VersionGrid.DataSource = list;
        this.VersionGrid.DataBind();
    }
    #endregion
    protected void cboFileType_Init(object sender, EventArgs e)
    {
        var list = entities.ETParameters.Where(x => x.ETCode != "ULCOST" && x.ETCode != "GL").OrderBy(x => x.CreateDate).ToList();
        this.cboFileType.DataSource = list;
        this.cboFileType.ValueField = "ETCode";
        this.cboFileType.TextField = "Name";
        this.cboFileType.DataBind();
        if (this.cboFileType.Items.Count > 0)
        {
            var type = Request.QueryString["Code"];
            if (!string.IsNullOrEmpty(type))
                this.cboFileType.Value = type;
            else
                this.cboFileType.SelectedItem = this.cboFileType.Items[0];

            GenerateCols(DataHistoryGrid, this.cboFileType.Value.ToString());
        }
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
        entities.SaveChangesWithAuditLogs();

        return entity;
    }
    protected void FileHistoryGrid_CustomCallback(object sender, ASPxGridViewCustomCallbackEventArgs e)
    {
        ASPxGridView s = sender as ASPxGridView;
        string[] args = e.Parameters.Split('|');

        s.JSProperties["cpCommand"] = args[0];

        if (args[0] == "LoadHistory")
        {
            try
            {
                string fileType = args[1];
                GenerateCols(DataHistoryGrid, fileType);
                LoadHistories(fileType);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        if (args[0] == "ProcessFile")
        {
            try
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
                            pi.SetValue(entity, value != null ? value.ToString() : string.Empty, null); ; ;
                        }

                        entity.HistoryID = history.HistoryID;
                        entity.Seq = rowCount;
                        entities.ETDataHistories.Add(entity);
                    }
                }


                history.SumRC = rowCount;
                history.SumInsert = rowCount;
                history.SumCol = cols;
                entities.SaveChangesWithAuditLogs();

                // entities.TransferUploadData(history.HistoryID, SessionUser.UserID);

                LoadHistories(fileType);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        if (args[0] == "Apply")
        {
            decimal historyKey = decimal.Zero;
            decimal versionKey = decimal.Zero;
            int companyKey;

            try
            {
                if (!decimal.TryParse(args[1], out historyKey))
                    return;

                if (!decimal.TryParse(args[2], out versionKey))
                    return;

                if (!int.TryParse(args[3], out companyKey))
                    return;

                var entity = entities.ETHistories.SingleOrDefault(x => x.HistoryID == historyKey);

                if (entity != null)
                {
                    entities.TransferUploadData(historyKey, versionKey, companyKey, SessionUser.UserID);

                    LoadHistories(entity.ETCode);

                    var count = entities.ImportLogs
                        .Where(x => x.VersionID == versionKey && x.HistoryID == historyKey)
                        .Count();
                    if (count > 0)
                    {
                        Notify.Warn("Có lỗi xảy ra khi Apply dữ liệu vào Version. Vui lòng xem chi tiết trong Import Logs");
                    }
                }
            }
            catch (Exception ex)
            {
                entities.WriteImportLog(historyKey, versionKey, GetErrorMessage(ex), SessionUser.UserID);
                throw new UserFriendlyException("Có lỗi, xem chi tiết trong Import Logs (" + GetErrorMessage(ex) + ")", SessionUser.UserName);
            }
        }
    }

    private string GetErrorMessage(Exception ex)
    {
        if (ex.InnerException != null)
            return ex.InnerException.Message;

        return ex.Message;
    }

    protected void DataHistoryGrid_CustomCallback(object sender, ASPxGridViewCustomCallbackEventArgs e)
    {
        try
        {
            ASPxGridView s = sender as ASPxGridView;
            string[] args = e.Parameters.Split('|');
            if (args[0] == "GenerateCols")
            {

                GenerateCols(s, args[1]);
                this.DataHistoryGrid.DataSource = null;
                this.DataHistoryGrid.DataBind();
                // LoadDataHistories(0);

            }
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
        catch (Exception ex)
        {
            throw ex;
        }
    }

    private void GenerateCols(ASPxGridView s, decimal key)
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

            var history = entities.ETHistories.SingleOrDefault(x => x.HistoryID == key);

            if (history != null)
            {
                var columns = entities.ETColumns.Where(x => x.ETCode == history.ETCode).OrderBy(x => x.Seq).ToList();
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
                    col.Width = columns[i].ColumnWidth.HasValue ? columns[i].ColumnWidth.Value : 120; // columns[i].DataLength.HasValue ? columns[i].DataLength.Value : 120;
                    s.Columns.Add(col);
                    //s.DataColumns["ATT" + i].Visible = true;
                    //s.DataColumns["ATT" + i].VisibleIndex = (i + 1);
                    //s.DataColumns["ATT" + i].Caption = StringUtils.isEmpty(columns[i].Description) ? columns[i].ColumnName : columns[i].Description;
                }
            }
            //int j = 0;
            //foreach (var col in columns)
            //{
            //    s.DataColumns["ATT" + j].Caption = StringUtils.isEmpty(col.Description) ? col.ColumnName : col.Description;
            //    j += 1;
            //}

            //for (int i = 0; i < s.Columns.Count - 2; i++)
            //{
            //    s.DataColumns["ATT" + i].Visible = false;
            //}

            //var history = entities.ETHistories.SingleOrDefault(x => x.HistoryID == key);

            //if (history != null)
            //{
            //    var columns = entities.ETColumns.Where(x => x.ETCode == history.ETCode).OrderBy(x => x.Seq).ToList();
            //    for (int i = 0; i < columns.Count - 1; i++)
            //    {
            //        s.DataColumns["ATT" + i].Visible = true;
            //        s.DataColumns["ATT" + i].VisibleIndex = (i + 1);
            //    }

            //    int j = 0;
            //    foreach (var col in columns)
            //    {
            //        s.DataColumns["ATT" + j].Caption = StringUtils.isEmpty(col.Description) ? col.ColumnName : col.Description;
            //        j += 1;
            //    }

            //}
        }
        catch (Exception ex)
        {
            throw ex;
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
                col.Width = columns[i].ColumnWidth.HasValue ? columns[i].ColumnWidth.Value : 120;// columns[i].DataLength.HasValue ? columns[i].DataLength.Value : 120;
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
        ASPxGridView s = sender as ASPxGridView;
        var args = e.Parameters.Split('|');

        s.JSProperties["cpCommand"] = args[0];

        if (args[0] == "ApplyToVersion")
        {
            try
            {
                int companyID;
                if (!int.TryParse(args[1], out companyID))
                    return;

                decimal[] verKeys = null;
                if (!TryParseKeyValues(args.Skip(2), out verKeys))
                    return;


                s.JSProperties["cpResult"] = "Success";
            }
            catch (Exception ex)
            {
                s.JSProperties["cpResult"] = ex.Message;
            }
        }
    }

    protected bool TryParseKeyValues(IEnumerable<string> stringKeys, out decimal[] resultKeys)
    {
        resultKeys = null;
        var list = new List<decimal>();
        foreach (var sKey in stringKeys)
        {
            decimal key;
            if (!decimal.TryParse(sKey, out key))
                return false;
            list.Add(key);
        }
        resultKeys = list.ToArray();
        return true;
    }

    protected void cboCompany_Init(object sender, EventArgs e)
    {
        ASPxComboBox s = sender as ASPxComboBox;

        List<int> companies = new List<int>();
        using (APPData.QLKHAppEntities app = new APPData.QLKHAppEntities())
        {
            companies = app.UserCompanies.Where(x => x.UserID == SessionUser.UserID).Select(x => x.CompanyID).ToList();
        }
        //&& x.AreaCode == areaCode
        var list = entities.DecCompanies
            .Where(x => x.CompanyType == "D" && companies.Contains(x.CompanyID))
             .Select(x => new { x.CompanyID, x.NameV, x.Seq })
            .OrderBy(x => x.Seq).ToList();

        ListEditItem le;
        foreach (var item in list)
        {
            le = new ListEditItem();
            le.Text = item.NameV;
            le.Value = item.CompanyID;
            s.Items.Add(le);
        }

    }

    protected void Callback_Callback(object source, CallbackEventArgs e)
    {
        string[] args = e.Parameter.Split('|');
        if (args[0] == "HasUseVersion")
        {
            var etCode = args[1];
            var etParas = entities.ETParameters.Where(x => x.ETCode == etCode).FirstOrDefault();
            if (etParas != null)
                e.Result = etParas.UseVersion ? "TRUE" : "FALSE";
            else
                e.Result = "FALSE";
        }
    }

    protected void ImportErrorGrid_CustomCallback(object sender, ASPxGridViewCustomCallbackEventArgs e)
    {
        string[] args = e.Parameters.Split('|');
        if (args[0] == "LoadErrors")
        {
            decimal key;
            if (!decimal.TryParse(args[1], out key))
                return;

            var list = entities.ImportLogs.Where(x => x.HistoryID == key).OrderBy(x => x.Id).ToList();
            this.ImportErrorGrid.DataSource = list;
            this.ImportErrorGrid.DataBind();

        }
    }

    protected void TransferDataHistoryGrid_CustomCallback(object sender, ASPxGridViewCustomCallbackEventArgs e)
    {
        string[] args = e.Parameters.Split('|');
        if (args[0] == "Load")
        {
            decimal key;
            if (!decimal.TryParse(args[1], out key))
                return;

            var list = entities.TransferDataHistories.Where(x => x.HistoryID == key).OrderBy(x => x.Id).ToList();
            this.TransferDataHistoryGrid.DataSource = list;
            this.TransferDataHistoryGrid.DataBind();

        }
    }
}