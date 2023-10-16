using System;
using System.Web;

public partial class Root : System.Web.UI.MasterPage
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            Page.Header.EnableViewState = false;
            Page.Header.DataBind();
        }

    }
}
