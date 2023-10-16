using KTQTData;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Configs_PopupControl_CompanyLOV : System.Web.UI.UserControl
{
    protected void Page_Load(object sender, EventArgs e)
    {
        LoadCompanies();
    }

    private void LoadCompanies()
    {
        using (KTQTDataEntities entities = new KTQTDataEntities())
        {
            var list = entities.DecCompanies.Where(x => x.CompanyType == "D").OrderByDescending(x => x.AreaCode).ThenBy(x => x.Seq).ToList();
            this.LOVCompanyGrid.DataSource = list;
            this.LOVCompanyGrid.DataBind();
        }
    }
}