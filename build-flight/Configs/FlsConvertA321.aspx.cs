using DevExpress.Web;
using KTQTData;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Configs_FlsConvertA321 : BasePage
{
    KTQTDataEntities entities = new KTQTDataEntities();
    protected void Page_Load(object sender, EventArgs e)
    {

        LoadDataGrid();

    }

    #region Load data
    private void LoadDataGrid()
    {
        var list = entities.FlsConvertA321.OrderBy(x => x.Carrier).OrderBy(x => x.Aircraft).OrderBy(x => x.Network).ToList();
        this.DataGrid.DataSource = list;
        this.DataGrid.DataBind();
    }
    #endregion
    protected void DataGrid_CustomCallback(object sender, DevExpress.Web.ASPxGridViewCustomCallbackEventArgs e)
    {

        ASPxGridView s = sender as ASPxGridView;
        string[] args = e.Parameters.Split('|');
        if (args[0].Equals(Action.REFRESH))
        {
            s.JSProperties["cpResult"] = Action.REFRESH;
            LoadDataGrid();
        }
        else if (args[0].Equals(Action.DELETE))
        {
            s.JSProperties["cpResult"] = Action.DELETE;
            int key;
            if (!int.TryParse(args[1], out key)) return;

            var area = (from x in entities.FlsConvertA321 where x.FlsConvertID == key select x).FirstOrDefault();
            if (area != null)
            {
                entities.FlsConvertA321.Remove(area);
                entities.SaveChanges();
                LoadDataGrid();
            }
        }

        else if (args[0].Equals("SaveForm"))
        {
            if (args.Length > 1)
            {
                try
                {
                    var command = args[1];
                    var aAreaCode = AreaCodeEditor.Value;
                    var aFiscalYear = FiscalYearEditor.Number;
                    var aCarrier = CarrierEditor.Value;
                    var aNetwork = NetworkEditor.Value;
                    var aAircraft = AircraftEditor.Value;
                    var aFls321 = Fls321Editor.Number;
                    var aDescription = DescriptionEditor.Text;

                    if (command.ToUpper() == "EDIT")
                    {
                        int key;
                        if (!int.TryParse(args[2], out key)) return;
                        var entity = entities.FlsConvertA321.Where(x => x.FlsConvertID == key).SingleOrDefault();
                        if (entity != null)
                        {
                            entity.FiscalYear = Convert.ToInt32(aFiscalYear);
                            entity.Carrier = aCarrier.ToString();
                            entity.Network = aNetwork.ToString();
                            entity.Aircraft = aAircraft.ToString();
                            entity.AreaCode = aAreaCode.ToString();
                            entity.Fls321 = aFls321;
                            entity.Description = aDescription;

                            entity.LastUpdateDate = DateTime.Now;
                            entity.LastUpdatedBy = (int)SessionUser.UserID;
                            entities.SaveChanges();
                        }
                    }
                    else if (command.ToUpper() == "NEW")
                    {
                        var entity = new FlsConvertA321();
                        entity.FiscalYear = Convert.ToInt32(aFiscalYear);
                        entity.Carrier = aCarrier.ToString();
                        entity.Network = aNetwork.ToString();
                        entity.Aircraft = aAircraft.ToString();
                        entity.AreaCode = aAreaCode.ToString();
                        entity.Fls321 = aFls321;
                        entity.Description = aDescription;

                        entity.CreateDate = DateTime.Now;
                        entity.CreatedBy = (int)SessionUser.UserID;

                        entities.FlsConvertA321.Add(entity);
                        entities.SaveChanges();
                    }
                    LoadDataGrid();

                    s.JSProperties["cpResult"] = "Success";
                }
                catch (Exception ex)
                {
                    s.JSProperties["cpResult"] = ex.Message;
                }
            }
        }
    }
    protected void DataGrid_CustomDataCallback(object sender, DevExpress.Web.ASPxGridViewCustomDataCallbackEventArgs e)
    {
        string[] args = e.Parameters.Split('|');
        if (args[0] == "EditForm" && args.Length == 3)
        {
            int key;
            if (!int.TryParse(args[2], out key)) return;

            var area = entities.FlsConvertA321.SingleOrDefault(x => x.FlsConvertID == key);
            if (area == null)
                return;

            var result = new Dictionary<string, string>();
            result["AreaCode"] = area.AreaCode;
            result["FiscalYear"] = area.FiscalYear.HasValue ? area.FiscalYear.Value.ToString() : "0";
            result["Carrier"] = area.Carrier;
            result["Network"] = area.Network;
            result["Aircraft"] = area.Aircraft;
            result["Fls321"] = area.Fls321.HasValue ? area.Fls321.ToString() : "0";
            result["Description"] = area.Description;

            e.Result = result;
        }
    }
    protected void CarrierEditor_Init(object sender, EventArgs e)
    {
        ASPxComboBox s = sender as ASPxComboBox;
        var list = entities.Code_Airlines.Select(x => new { AirlinesCode = x.AirlinesCode }).ToList();
        s.DataSource = list;
        s.ValueField = "AirlinesCode";
        s.TextField = "AirlinesCode";
        s.DataBind();
        ListEditItem item = new ListEditItem("XX", "XX");
        s.Items.Insert(0, item);
    }
    protected void AircraftEditor_Init(object sender, EventArgs e)
    {
        ASPxComboBox s = sender as ASPxComboBox;
        var list = entities.DecAircrafts.Select(x => new { Aircraft = x.Aircraft }).Distinct().ToList();
        s.DataSource = list;
        s.ValueField = "Aircraft";
        s.TextField = "Aircraft";
        s.DataBind();
    }
    protected void mMain_ItemClick(object source, MenuItemEventArgs e)
    {
        switch (e.Item.Name.ToUpper())
        {
            case "PDF":
                GridViewExporter.Landscape = true;
                GridViewExporter.WritePdfToResponse();
                break;
            case "XLS":
                GridViewExporter.WriteXlsToResponse();
                break;
            case "XLSX":
                DevExpress.XtraPrinting.XlsxExportOptionsEx options = new DevExpress.XtraPrinting.XlsxExportOptionsEx() { ExportType = DevExpress.Export.ExportType.WYSIWYG };
                options.SheetName = "ConvertA321";
                GridViewExporter.WriteXlsxToResponse(options);
                break;
            case "RTF":
                GridViewExporter.Landscape = true;
                GridViewExporter.WriteRtfToResponse();
                break;
        }
    }
}