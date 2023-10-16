using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class AccessDenied : System.Web.UI.Page
{
    protected override void OnPreInit(EventArgs e)
    {
        base.OnPreInit(e);
        Utils.ApplyTheme(this);
    }

    protected override void OnInit(EventArgs e)
    {
        base.OnInit(e);

        if (Session.IsNewSession || !User.Identity.IsAuthenticated || SessionUser.GetLoginUser() == null)
        {
            string ReturnUrl = Request.Url.ToString();
            if (IsCallback)
            {
                if (!string.IsNullOrEmpty(ReturnUrl))
                    DevExpress.Web.ASPxWebControl.RedirectOnCallback(HelpDeskConstant.LoginPageUrl + "?ReturnUrl=" + HttpUtility.UrlEncode(ReturnUrl));
                else
                    DevExpress.Web.ASPxWebControl.RedirectOnCallback(HelpDeskConstant.LoginPageUrl);
            }
            else
            {
                if (!string.IsNullOrEmpty(ReturnUrl))
                    Response.Redirect(HelpDeskConstant.LoginPageUrl + "?ReturnUrl=" + HttpUtility.UrlEncode(ReturnUrl));
                else
                    Response.Redirect(HelpDeskConstant.LoginPageUrl);
            }
        }
    }
    protected void Page_Load(object sender, EventArgs e)
    {

    }
}