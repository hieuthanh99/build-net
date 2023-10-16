using KTQTData;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Configs_PopupControl_StationeryLOV : System.Web.UI.UserControl
{
    public int UnitPriceID { get; set; }
    protected void Page_Load(object sender, EventArgs e)
    {
        this.UnitPriceID = this.GetCallbackKeyValue("UnitPriceID");
        LoadStationery();

    }

    private void LoadStationery()
    {
        using (KTQTDataEntities entities = new KTQTDataEntities())
        {
            var list = entities.DecStationeries
                .Where(x => !entities.DM_StationeryUnitPriceDetails.Where(t => t.UnitPriceID == this.UnitPriceID)
                    .Select(t => t.StationeryID).Contains(x.StationeryID))
                    .OrderBy(t => t.StationeryType)
                    .ThenBy(x => x.StationeryID).ToList();
            this.LOVStationeryGrid.DataSource = list;
            this.LOVStationeryGrid.DataBind();
        }
    }

    private int GetCallbackKeyValue(string keyStr)
    {
        string result = null;
        if (Utils.TryGetClientStateValue<string>(this.Page, keyStr, out result))
            return Convert.ToInt32(result);
        return 0;
    }
}