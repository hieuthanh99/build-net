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
using System.Web.UI.WebControls;

public partial class Pages_RoeVN : BasePage
{
    KTQTDataEntities entities = new KTQTDataEntities();
    string fileStorage = ConfigurationManager.AppSettings["FileStorage"];

    protected void Page_Load(object sender, EventArgs e)
    {
        this.mMain.Items.FindByName("New").Visible = IsGranted("Pages.KHTC.Configs.RoeVN.Create");
        this.mMain.Items.FindByName("Edit").Visible = IsGranted("Pages.KHTC.Configs.RoeVN.Edit");
        this.mMain.Items.FindByName("Delete").Visible = IsGranted("Pages.KHTC.Configs.RoeVN.Delete");
        this.mMain.Items.FindByName("SyncData").Visible = IsGranted("Pages.KHTC.Configs.RoeVN.SyncData");

        if (!IsPostBack)
        {
            this.FilterYearEditor.Value = DateTime.Now.Year;
            LoadVersion();
        }
        if (!IsPostBack || DataGrid.IsCallback)
        {
            if (cboSelectedVerID.Value != null)
                LoadDataToGrid(Convert.ToDecimal(cboSelectedVerID.Value));
        }
    }

    #region Load data
    private void LoadVersion()
    {
        var versionYear = Convert.ToInt32(FilterYearEditor.Number);
        var list = entities.Versions.Where(x => x.VersionYear == versionYear && x.Active == true).ToList();
        cboSelectedVerID.DataSource = list;
        cboSelectedVerID.ValueField = "VersionID";
        cboSelectedVerID.TextField = "Description";
        cboSelectedVerID.DataBind();
        if (cboSelectedVerID.Items.Count > 0)
            cboSelectedVerID.Value = cboSelectedVerID.Items[0].Value;
    }

    private void LoadDataToGrid(decimal verId)
    {
        var list = entities.RoeVNs.Where(x => x.Ver_ID == verId).OrderBy(x => x.Curr).ToList();
        this.DataGrid.DataSource = list;
        this.DataGrid.DataBind();
    }
    #endregion
    protected void DataGrid_CustomCallback(object sender, ASPxGridViewCustomCallbackEventArgs e)
    {
        ASPxGridView s = sender as ASPxGridView;
        string[] args = e.Parameters.Split('|');
        if (args[0].Equals(Action.REFRESH))
        {
            s.JSProperties["cpResult"] = Action.REFRESH;
            decimal verId;
            if (!decimal.TryParse(args[1], out verId))
                LoadDataToGrid(0);
            else
                LoadDataToGrid(verId);
        }
        else if (args[0].Equals(Action.DELETE))
        {
            s.JSProperties["cpResult"] = Action.DELETE;
            decimal key;
            if (!decimal.TryParse(args[1], out key))
                return;

            var entity = (from x in entities.RoeVNs where x.RoeID == key select x).FirstOrDefault();
            if (entity != null)
            {
                entities.RoeVNs.Remove(entity);
                entities.SaveChanges();
                if (cboSelectedVerID.Value != null)
                    LoadDataToGrid(Convert.ToDecimal(cboSelectedVerID.Value));
            }
        }
        else if (args[0].Equals(Action.SYNC_DATA))
        {
            if (cboSelectedVerID.Value != null)
            {
                var versionId = Convert.ToDecimal(cboSelectedVerID.Value);
                entities.Sync_1VersionRoeVN(Convert.ToDouble(versionId));

                LoadDataToGrid(versionId);
            }
        }
        else if (args[0].Equals("SaveForm"))
        {
            if (args.Length > 1)
            {
                try
                {
                    var command = args[1];
                    var aVerID = cboSelectedVerID.Value;
                    var aCurr = CurrEditor.Text;
                    var aM01 = M01Editor.Number;
                    var aM02 = M02Editor.Number;
                    var aM03 = M03Editor.Number;
                    var aM04 = M04Editor.Number;
                    var aM05 = M05Editor.Number;
                    var aM06 = M06Editor.Number;
                    var aM07 = M07Editor.Number;
                    var aM08 = M08Editor.Number;
                    var aM09 = M09Editor.Number;
                    var aM10 = M10Editor.Number;
                    var aM11 = M11Editor.Number;
                    var aM12 = M12Editor.Number;
                    var aNote = NoteEditor.Text;

                    if (command.ToUpper() == "EDIT")
                    {
                        decimal key;
                        if (!decimal.TryParse(args[2], out key))
                            return;

                        var entity = entities.RoeVNs.Where(x => x.RoeID == key).SingleOrDefault();
                        if (entity != null)
                        {
                            entity.Curr = aCurr;
                            entity.M01 = aM01;
                            entity.M02 = aM02;
                            entity.M03 = aM03;
                            entity.M04 = aM04;
                            entity.M05 = aM05;
                            entity.M06 = aM06;
                            entity.M07 = aM07;
                            entity.M08 = aM08;
                            entity.M09 = aM09;
                            entity.M10 = aM10;
                            entity.M11 = aM11;
                            entity.M12 = aM12;
                            entity.Note = aNote;

                            entity.LastUpdateDate = DateTime.Now;
                            entity.LastUpdatedBy = (int)SessionUser.UserID;
                            entities.SaveChangesWithAuditLogs();
                        }
                    }
                    else if (command.ToUpper() == "NEW")
                    {
                        var entity = new RoeVN();
                        entity.Ver_ID = Convert.ToDecimal(aVerID);
                        entity.Curr = aCurr;
                        entity.M01 = aM01;
                        entity.M02 = aM02;
                        entity.M03 = aM03;
                        entity.M04 = aM04;
                        entity.M05 = aM05;
                        entity.M06 = aM06;
                        entity.M07 = aM07;
                        entity.M08 = aM08;
                        entity.M09 = aM09;
                        entity.M10 = aM10;
                        entity.M11 = aM11;
                        entity.M12 = aM12;
                        entity.Note = aNote;

                        entity.CreateDate = DateTime.Now;
                        entity.CreatedBy = (int)SessionUser.UserID;

                        entities.RoeVNs.Add(entity);
                        entities.SaveChangesWithAuditLogs();
                    }
                    if (cboSelectedVerID.Value != null)
                        LoadDataToGrid(Convert.ToDecimal(cboSelectedVerID.Value));

                    s.JSProperties["cpResult"] = "Success";
                }
                catch (Exception ex)
                {
                    s.JSProperties["cpResult"] = ex.Message;
                }
            }
        }
    }
    protected void DataGrid_CustomDataCallback(object sender, ASPxGridViewCustomDataCallbackEventArgs e)
    {
        string[] args = e.Parameters.Split('|');
        if (args[0] == "EditForm" && args.Length == 3)
        {
            decimal key;
            if (!decimal.TryParse(args[2], out key))
                return;

            var roe = entities.RoeVNs.SingleOrDefault(x => x.RoeID == key);
            if (roe == null)
                return;

            var result = new Dictionary<string, string>();
            result["Ver_ID"] = (roe.Ver_ID ?? decimal.Zero).ToString();
            result["Curr"] = roe.Curr;
            result["M01"] = (roe.M01 ?? decimal.Zero).ToString();
            result["M02"] = (roe.M02 ?? decimal.Zero).ToString();
            result["M03"] = (roe.M03 ?? decimal.Zero).ToString();
            result["M04"] = (roe.M04 ?? decimal.Zero).ToString();
            result["M05"] = (roe.M05 ?? decimal.Zero).ToString();
            result["M06"] = (roe.M06 ?? decimal.Zero).ToString();
            result["M07"] = (roe.M07 ?? decimal.Zero).ToString();
            result["M08"] = (roe.M08 ?? decimal.Zero).ToString();
            result["M09"] = (roe.M09 ?? decimal.Zero).ToString();
            result["M10"] = (roe.M10 ?? decimal.Zero).ToString();
            result["M11"] = (roe.M11 ?? decimal.Zero).ToString();
            result["M12"] = (roe.M12 ?? decimal.Zero).ToString();
            result["Note"] = roe.Note;

            e.Result = result;
        }
    }

    protected void cboVerID_Init(object sender, EventArgs e)
    {
        ASPxComboBox s = sender as ASPxComboBox;
        var list = entities.Versions.Where(x => x.Active == true).OrderByDescending(x => x.Sorting).ToList();
        s.DataSource = list;
        s.ValueField = "VersionID";
        s.TextField = "Description";
        s.DataBind();
        if (s.Items.Count > 0)
            s.SelectedIndex = 0;
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
            foreach (Cell cell in rows.ElementAt(0))
            {
                dataTable.Columns.Add(GetCellValue(spreadSheetDocument, cell));
            }
            foreach (Row row in rows)
            {
                if (row.RowIndex.HasValue && row.RowIndex.Value == 1)
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
                string fileName = Path.Combine(fileStorage, SessionUser.UserName, file.FileName);
                SaveFile(fileName, file);

                try
                {
                    System.Data.DataTable dataTable = ReadAsDataTable(fileName).Rows
                            .Cast<System.Data.DataRow>()
                            .Where(row => !row.ItemArray.All(field => field is DBNull
                             || string.IsNullOrWhiteSpace(field as string)))
                             .CopyToDataTable();

                    decimal verId = Convert.ToDecimal(cboSelectedVerID.Value);
                    entities.RoeVNs.RemoveRange(entities.RoeVNs.Where(x => x.Ver_ID == verId).AsEnumerable());
                    foreach (System.Data.DataRow row in dataTable.Rows)
                    {
                        var entity = new RoeVN();
                        entity.Ver_ID = verId;
                        entity.Curr = row[1] != DBNull.Value ? row[1].ToString() : string.Empty;
                        entity.M01 = row[2] != DBNull.Value ? Convert.ToDecimal(!StringUtils.isEmpty(row[2].ToString()) ? row[2] : "0") : decimal.Zero;
                        entity.M02 = row[3] != DBNull.Value ? Convert.ToDecimal(!StringUtils.isEmpty(row[3].ToString()) ? row[3] : "0") : decimal.Zero;
                        entity.M03 = row[4] != DBNull.Value ? Convert.ToDecimal(!StringUtils.isEmpty(row[4].ToString()) ? row[4] : "0") : decimal.Zero;
                        entity.M04 = row[5] != DBNull.Value ? Convert.ToDecimal(!StringUtils.isEmpty(row[5].ToString()) ? row[5] : "0") : decimal.Zero;
                        entity.M05 = row[6] != DBNull.Value ? Convert.ToDecimal(!StringUtils.isEmpty(row[6].ToString()) ? row[6] : "0") : decimal.Zero;
                        entity.M06 = row[7] != DBNull.Value ? Convert.ToDecimal(!StringUtils.isEmpty(row[7].ToString()) ? row[7] : "0") : decimal.Zero;
                        entity.M07 = row[8] != DBNull.Value ? Convert.ToDecimal(!StringUtils.isEmpty(row[8].ToString()) ? row[8] : "0") : decimal.Zero;
                        entity.M08 = row[9] != DBNull.Value ? Convert.ToDecimal(!StringUtils.isEmpty(row[9].ToString()) ? row[9] : "0") : decimal.Zero;
                        entity.M09 = row[10] != DBNull.Value ? Convert.ToDecimal(!StringUtils.isEmpty(row[10].ToString()) ? row[10] : "0") : decimal.Zero;
                        entity.M10 = row[11] != DBNull.Value ? Convert.ToDecimal(!StringUtils.isEmpty(row[11].ToString()) ? row[11] : "0") : decimal.Zero;
                        entity.M11 = row[12] != DBNull.Value ? Convert.ToDecimal(!StringUtils.isEmpty(row[12].ToString()) ? row[12] : "0") : decimal.Zero;
                        entity.M12 = row[13] != DBNull.Value ? Convert.ToDecimal(!StringUtils.isEmpty(row[13].ToString()) ? row[13] : "0") : decimal.Zero;

                        entity.CreateDate = DateTime.Now;
                        entity.CreatedBy = (int)SessionUser.UserID;

                        entities.RoeVNs.Add(entity);
                    }
                    entities.SaveChanges();
                    e.CallbackData = "success";
                }
                catch (Exception ex)
                {
                    e.CallbackData = "error";
                    e.ErrorText = ex.Message;
                }
                //using (SpreadsheetDocument spreadsheetDocument = SpreadsheetDocument.Open(fileName, false))
                //{
                //    WorkbookPart workbookPart = spreadsheetDocument.WorkbookPart;
                //    WorksheetPart worksheetPart = workbookPart.WorksheetParts.First();
                //    //SheetData sheetData = worksheetPart.Worksheet.Elements<SheetData>().First();
                //    OpenXmlReader reader = OpenXmlReader.Create(worksheetPart);
                //    string text;
                //    //foreach (Row r in sheetData.Elements<Row>())
                //    while(reader.Read())
                //    {
                //        if (reader.ElementType == typeof(CellValue))
                //        {
                //            text = reader.GetText();                        
                //        }
                //        //foreach (Cell c in r.Elements<Cell>())
                //        //{
                //            //if (c.CellValue != null)
                //            //{
                //            //    text = c.CellValue.Text;
                //            //   Log.Info(text + " ");
                //            //}
                //        //}                       
                //    }

                //}

            }
        }
    }

    protected void cboSelectedVerID_Callback(object sender, CallbackEventArgsBase e)
    {
        LoadVersion();
    }
}