using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Dashboards_DashboardViewer : BasePageNotCheckURL
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }
    protected void ASPxDashboard1_CustomParameters(object sender, DevExpress.DashboardWeb.CustomParametersWebEventArgs e)
    {

        if (e.DashboardId == "dashboard1")
        {
            var pYear = e.Parameters.FirstOrDefault(p => p.Name == "Year");
            if (pYear != null)
            {
                pYear.Value = DateTime.Now.Year;
            }
        }

    }
}