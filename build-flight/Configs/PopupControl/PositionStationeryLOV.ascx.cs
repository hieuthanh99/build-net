using KTQTData;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Configs_PopupControl_PositionStationeryLOV : System.Web.UI.UserControl
{
    protected void Page_Load(object sender, EventArgs e)
    {
        LoadStationery();
    }

    private void LoadStationery()
    {
        using (KTQTDataEntities entities = new KTQTDataEntities())
        {
            var list = entities.DecStationeries.Where(x => x.StationeryType == "CD").OrderBy(x => x.StationeryID).ToList();
            this.LOVPositionStationeryGrid.DataSource = list;
            this.LOVPositionStationeryGrid.DataBind();
        }
    }
}