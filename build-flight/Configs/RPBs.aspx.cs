using DevExpress.Web;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.UI.WebControls;
using KTQTData;

public partial class Pages_RPBs : BasePage
{
    KTQTDataEntities entities = new KTQTDataEntities();
    protected void Page_Load(object sender, EventArgs e)
    {

        if (!IsPostBack || DataGrid.IsCallback)
        {
            LoadRPBs();
        }
    }

    #region Load data
    private void LoadRPBs()
    {
        var list = entities.RPBs.OrderBy(x => x.PSS).ToList();
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
            LoadRPBs();
        }
        else if (args[0].Equals(Action.DELETE))
        {
            s.JSProperties["cpResult"] = Action.DELETE;
            int key;
            if (!int.TryParse(args[1], out key))
                return;

            var entity = (from x in entities.RPBs where x.Id == key select x).FirstOrDefault();
            if (entity != null)
            {
                entities.RPBs.Remove(entity);
                entities.SaveChangesWithAuditLogs();
                LoadRPBs();
            }
        }

        else if (args[0].Equals("SaveForm"))
        {
            if (args.Length > 1)
            {
                try
                {
                    var command = args[1];
                    var vPSS = PSSEditor.Text;
                    var vGroupPax = GroupPaxEditor.Text;
                    var vMinRPBs = MinRPBsEditor.Number;
                    var vMaxRPBs = MaxRPBsEditor.Number;
                    var vPriceRPB = PriceRPBEditor.Number;
                    var vEffectiveFrom = EffectiveFromEditor.Date;
                    var vEffectiveTo = EffectiveToEditor.Date;

                    if (command.ToUpper() == "EDIT")
                    {
                        int key;
                        if (!int.TryParse(args[2], out key))
                            return;

                        var entity = entities.RPBs.Where(x => x.Id == key).SingleOrDefault();
                        if (entity != null)
                        {
                            entity.PSS = vPSS;
                            entity.GroupPax = vGroupPax;
                            entity.MinRPBs = (long?)vMinRPBs;
                            entity.MaxRPBs = (long?)vMaxRPBs;
                            entity.PriceRPB = (decimal?)vPriceRPB;
                            entity.CurrencyCode = CurrencyCodeEditor.Text;
                            entity.EffectiveFrom = vEffectiveFrom;
                            entity.EffectiveTo = vEffectiveTo;

                            entity.ModifyDate = DateTime.Now;
                            entity.ModifiedBy = (int)SessionUser.UserID;
                            entities.SaveChangesWithAuditLogs();
                        }
                    }
                    else if (command.ToUpper() == "NEW")
                    {
                        var entity = new RPB();
                        entity.PSS = vPSS;
                        entity.GroupPax = vGroupPax;
                        entity.MinRPBs = (long?)vMinRPBs;
                        entity.MaxRPBs = (long?)vMaxRPBs;
                        entity.PriceRPB = (decimal?)vPriceRPB;
                        entity.CurrencyCode = CurrencyCodeEditor.Text;
                        entity.EffectiveFrom = vEffectiveFrom;
                        entity.EffectiveTo = vEffectiveTo;

                        entity.CreateDate = DateTime.Now;
                        entity.CreatedBy = (int)SessionUser.UserID;

                        entities.RPBs.Add(entity);
                        entities.SaveChangesWithAuditLogs();
                    }
                    LoadRPBs();

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
            if (!int.TryParse(args[2], out key))
                return;

            var area = entities.RPBs.SingleOrDefault(x => x.Id == key);
            if (area == null)
                return;

            var result = new Dictionary<string, string>();
            result["PSS"] = area.PSS;
            result["GroupPax"] = area.GroupPax;
            result["MinRPBs"] = area.MinRPBs.HasValue ? area.MinRPBs.Value.ToString() : "0";
            result["MaxRPBs"] = area.MaxRPBs.HasValue ? area.MaxRPBs.Value.ToString() : "0";
            result["PriceRPB"] = area.PriceRPB.HasValue ? area.PriceRPB.Value.ToString() : "0";
            result["CurrencyCode"] = area.CurrencyCode;
            result["EffectiveFrom"] = area.EffectiveFrom.HasValue ? area.EffectiveFrom.Value.ToString("yyyy-MM-dd") : string.Empty;
            result["EffectiveTo"] = area.EffectiveTo.HasValue ? area.EffectiveTo.Value.ToString("yyyy-MM-dd") : string.Empty;

            e.Result = result;
        }
    }
  
}