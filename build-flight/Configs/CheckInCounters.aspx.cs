using KTQTData;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DevExpress.Web;

public partial class Configs_CheckInCounters : BasePage
{
    KTQTDataEntities entities = new KTQTDataEntities();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack || DataGrid.IsCallback)
        {
            LoadCheckInCounters();
        }
    }

    #region Load data
    private void LoadCheckInCounters()
    {
        var list = entities.CheckInCounters
                    .OrderBy(x => x.Carrier)
                    .ThenBy(x => x.Network)
                    .ThenBy(x => x.AC_ID)
                    .ToList();
        this.DataGrid.DataSource = list;
        this.DataGrid.DataBind();
    }
    #endregion
    protected void AircraftEditor_Init(object sender, EventArgs e)
    {
        ASPxComboBox cbo = sender as ASPxComboBox;
        var list = entities.AircraftGroups.ToList();

        cbo.DataSource = list;
        cbo.ValueField = "ACGroup";
        cbo.TextField = "ACGroup";
        cbo.DataBind();
    }
    protected void FltTypeEditor_Init(object sender, EventArgs e)
    {
        ASPxComboBox cbo = sender as ASPxComboBox;
        var list = entities.DecTableValues
                            .Where(x => x.Tables == "FLT_OPS" && x.Field == "FLT_TYPE")
                            .Select(x => new
                            {
                                DefValue = x.DefValue,
                                Description = x.Description
                            })
                            .ToList();

        cbo.DataSource = list;
        cbo.ValueField = "DefValue";
        cbo.TextField = "Description";
        cbo.DataBind();
    }
    protected void DataGrid_CustomCallback(object sender, DevExpress.Web.ASPxGridViewCustomCallbackEventArgs e)
    {
        ASPxGridView s = sender as ASPxGridView;
        string[] args = e.Parameters.Split('|');
        if (args[0].Equals(Action.REFRESH))
        {
            s.JSProperties["cpResult"] = Action.REFRESH;
            LoadCheckInCounters();
        }
        else if (args[0].Equals(Action.DELETE))
        {
            s.JSProperties["cpResult"] = Action.DELETE;
            decimal key;
            if (!decimal.TryParse(args[1], out key))
                return;

            var item = (from x in entities.CheckInCounters where x.ID == key select x).FirstOrDefault();
            if (item != null)
            {
                entities.CheckInCounters.Remove(item);
                entities.SaveChangesWithAuditLogs();

                LoadCheckInCounters();
            }
        }

        else if (args[0].Equals("SaveForm"))
        {
            if (args.Length > 1)
            {
                try
                {
                    var command = args[1];
                    if (command.ToUpper() == "EDIT")
                    {
                        decimal key;
                        if (!decimal.TryParse(args[2], out key))
                            return;

                        var entity = entities.CheckInCounters.Where(x => x.ID == key).SingleOrDefault();
                        if (entity != null)
                        {
                            entity.Carrier = CarrierEditor.Value != null ? CarrierEditor.Value.ToString() : string.Empty;
                            entity.Network = NetworkEditor.Value != null ? NetworkEditor.Value.ToString() : string.Empty;
                            entity.AC_ID = AircraftEditor.Value != null ? AircraftEditor.Value.ToString() : string.Empty;

                            entity.FltType = FltTypeEditor.Value != null ? FltTypeEditor.Value.ToString() : string.Empty;
                            entity.Quantity = QuantityEditor.Value != null ? Convert.ToInt32(QuantityEditor.Number) : 0;
                            entity.CKIN = CheckInEditor.Value != null ? CheckInEditor.Number : decimal.Zero;
                            entity.CKVIP = CheckInVipEditor.Value != null ? CheckInVipEditor.Number : decimal.Zero;
                            entity.Total = TotalEditor.Value != null ? TotalEditor.Number : decimal.Zero;

                            entity.LastUpdateDate = DateTime.Now;
                            entity.LastUpdatedBy = (int)SessionUser.UserID;
                            entities.SaveChangesWithAuditLogs();
                        }
                    }
                    else if (command.ToUpper() == "NEW")
                    {
                        var entity = new CheckInCounter();
                        entity.Carrier = CarrierEditor.Value != null ? CarrierEditor.Value.ToString() : string.Empty;
                        entity.Network = NetworkEditor.Value != null ? NetworkEditor.Value.ToString() : string.Empty;
                        entity.AC_ID = AircraftEditor.Value != null ? AircraftEditor.Value.ToString() : string.Empty;

                        entity.FltType = FltTypeEditor.Value != null ? FltTypeEditor.Value.ToString() : string.Empty;
                        entity.Quantity = QuantityEditor.Value != null ? Convert.ToInt32(QuantityEditor.Number) : 0;
                        entity.CKIN = CheckInEditor.Value != null ? CheckInEditor.Number : decimal.Zero;
                        entity.CKVIP = CheckInVipEditor.Value != null ? CheckInVipEditor.Number : decimal.Zero;
                        entity.Total = TotalEditor.Value != null ? TotalEditor.Number : decimal.Zero;


                        entity.CreateDate = DateTime.Now;
                        entity.CreatedBy = (int)SessionUser.UserID;

                        entities.CheckInCounters.Add(entity);
                        entities.SaveChangesWithAuditLogs();
                    }

                    LoadCheckInCounters();

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
            decimal key;
            if (!decimal.TryParse(args[2], out key))
                return;

            var item = entities.CheckInCounters.SingleOrDefault(x => x.ID == key);
            if (item == null)
                return;

            var result = new Dictionary<string, string>();
            result["Carrier"] = item.Carrier.Trim();
            result["Network"] = item.Network;
            result["AC_ID"] = item.AC_ID;
            result["FltType"] = item.FltType;

            result["Quantity"] = (item.Quantity ?? 0).ToString();
            result["CKIN"] = (item.CKIN ?? decimal.Zero).ToString();
            result["CKVIP"] = (item.CKVIP ?? decimal.Zero).ToString();
            result["Total"] = (item.Total ?? decimal.Zero).ToString();

            e.Result = result;
        }
    }
    protected void DataGrid_CustomUnboundColumnData(object sender, DevExpress.Web.ASPxGridViewColumnDataEventArgs e)
    {

    }
    protected void DataGrid_CustomColumnDisplayText(object sender, DevExpress.Web.ASPxGridViewColumnDisplayTextEventArgs e)
    {

    }
    protected void CarrierEditor_Init(object sender, EventArgs e)
    {
        ASPxComboBox cbo = sender as ASPxComboBox;
        var list = entities.Code_Airlines.ToList();

        cbo.DataSource = list;
        cbo.ValueField = "AirlinesCode";
        cbo.TextField = "AirlinesCode";
        cbo.DataBind();
    }
}