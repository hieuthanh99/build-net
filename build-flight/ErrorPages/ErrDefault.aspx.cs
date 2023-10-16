using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class ErrorPages_ErrDefault : System.Web.UI.Page
{
    protected override void OnPreInit(EventArgs e)
    {
        base.OnPreInit(e);
        Utils.ApplyTheme(this);
    }
    protected void Page_Load(object sender, EventArgs e)
    {

    }
  
}