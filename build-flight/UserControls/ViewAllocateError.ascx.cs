using KTQTData;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class UserControls_ViewAllocateError : System.Web.UI.UserControl
{
    KTQTDataEntities entities = new KTQTDataEntities();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack || this.StoreAllocateErrorGrid.IsCallback)
        {
            string result = null;
            if (Utils.TryGetClientStateValue<string>(this.Page, "VerCompanyID", out result))
            {
                var key = Convert.ToDecimal(result);
                LoadStoreAllocateLog(key);
            }
        }
    }
    private void LoadStoreAllocateLog(decimal key)
    {
        var list = entities.StoreAllocateLogs.Where(x => x.VerCompanyID == key).OrderBy(x => x.LogID).ToList();
        this.StoreAllocateErrorGrid.DataSource = list;
        this.StoreAllocateErrorGrid.DataBind();
    }

}