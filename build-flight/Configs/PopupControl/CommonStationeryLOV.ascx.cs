using KTQTData;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Configs_PopupControl_CommonStationeryLOV : System.Web.UI.UserControl
{
    protected void Page_Load(object sender, EventArgs e)
    {
        LoadStationery();
    }

    private void LoadStationery()
    {
        using (KTQTDataEntities entities = new KTQTDataEntities())
        {
            var list = entities.DecStationeries.Where(x => x.StationeryType == "DC").OrderBy(x => x.StationeryID).ToList();
            this.LOVCommonStationeryGrid.DataSource = list;
            this.LOVCommonStationeryGrid.DataBind();
        }
    }
}