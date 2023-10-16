using KTQTData;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Configs_PopupControl_PositionLOV : System.Web.UI.UserControl
{
    protected void Page_Load(object sender, EventArgs e)
    {
        LoadPositions();
    }

    private void LoadPositions()
    {
        using (KTQTDataEntities entities = new KTQTDataEntities())
        {
            var list = entities.DecPositions.Where(x => x.Inactive == false).OrderBy(x => x.PostionName).ToList();
            this.LOVPositionGrid.DataSource = list;
            this.LOVPositionGrid.DataBind();
        }
    }
}