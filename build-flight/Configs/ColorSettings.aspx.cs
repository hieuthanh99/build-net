using DevExpress.Web;
using DocumentFormat.OpenXml.Packaging;
using DocumentFormat.OpenXml.Spreadsheet;
using KTQTData;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Web.UI.WebControls;

public partial class Pages_ColorSettings : BasePage
{
    KTQTDataEntities entities = new KTQTDataEntities();

    protected void Page_Load(object sender, EventArgs e)
    {
        this.mMain.Items.FindByName("New").Visible = IsGranted("Pages.KHTC.Configs.ColorSettings.Create");
        this.mMain.Items.FindByName("Edit").Visible = IsGranted("Pages.KHTC.Configs.ColorSettings.Edit");
        this.mMain.Items.FindByName("Delete").Visible = IsGranted("Pages.KHTC.Configs.ColorSettings.Delete");

        if (!IsPostBack)
        {
            FilterYearEditor.Value = DateTime.Now.Year;
        }
        if (!IsPostBack || DataGrid.IsCallback)
        {
            if (FilterYearEditor.Value != null)
                LoadDataToGrid(Convert.ToInt32(FilterYearEditor.Value));
        }
    }

    #region Load data

    private void LoadDataToGrid(int year)
    {
        var list = entities.VersionBaseSettings
            .Where(x => x.ForYear == year)
            .OrderBy(x => x.ForYear).ThenBy(x => x.MinPecent)
            .ToList();
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
            LoadDataToGrid(Convert.ToInt32(FilterYearEditor.Value));
        }
        else if (args[0].Equals(Action.DELETE))
        {
            s.JSProperties["cpResult"] = Action.DELETE;
            decimal key;
            if (!decimal.TryParse(args[1], out key))
                return;

            var entity = (from x in entities.VersionBaseSettings where x.Id == key select x).FirstOrDefault();
            if (entity != null)
            {
                entities.VersionBaseSettings.Remove(entity);
                entities.SaveChanges();

                LoadDataToGrid(Convert.ToInt32(FilterYearEditor.Value));
            }
        }

        else if (args[0].Equals("SaveForm"))
        {
            if (args.Length > 1)
            {
                try
                {
                    var command = args[1];
                    decimal? nullDecimal = null;
                    var aMinPercent = MinPercentEditor.Number;
                    var aMaxPercent = MaxPercentEditor.Value!=null? MaxPercentEditor.Number: nullDecimal;
                    var aColor = ColorEditor.Text;


                    if (command.ToUpper() == "EDIT")
                    {
                        decimal key;
                        if (!decimal.TryParse(args[2], out key))
                            return;

                        var entity = entities.VersionBaseSettings.Where(x => x.Id == key).SingleOrDefault();
                        if (entity != null)
                        {

                            entity.MinPecent = aMinPercent;
                            entity.MaxPecent = aMaxPercent;
                            entity.Color = aColor;

                            entity.ModifyDate = DateTime.Now;
                            entity.ModifiedBy = (int)SessionUser.UserID;
                            entities.SaveChangesWithAuditLogs();
                        }
                    }
                    else if (command.ToUpper() == "NEW")
                    {
                        var entity = new VersionBaseSetting();
                        entity.ForYear = Convert.ToInt32(FilterYearEditor.Value);
                        entity.MinPecent = aMinPercent;
                        entity.MaxPecent = aMaxPercent;
                        entity.Color = aColor;


                        entity.CreateDate = DateTime.Now;
                        entity.CreatedBy = (int)SessionUser.UserID;

                        entities.VersionBaseSettings.Add(entity);
                        entities.SaveChangesWithAuditLogs();
                    }

                    LoadDataToGrid(Convert.ToInt32(FilterYearEditor.Value));

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

            var entity = entities.VersionBaseSettings.SingleOrDefault(x => x.Id == key);
            if (entity == null)
                return;

            var result = new Dictionary<string, string>();

            result["MinPecent"] = (entity.MinPecent ?? decimal.Zero).ToString();
            result["MaxPecent"] = (entity.MaxPecent ?? decimal.Zero).ToString();
            result["Color"] = entity.Color;


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


}