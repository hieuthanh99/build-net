using HtmlAgilityPack;
using Microsoft.Owin.Security;
using Microsoft.Owin.Security.Cookies;
using Microsoft.Owin.Security.OpenIdConnect;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Threading;
using System.Web;

/// <summary>
/// Summary description for BasePage
/// </summary>
public class BasePageNotCheckURL : System.Web.UI.Page
{
    const string AccessDeniedPage = "~/AccessDenied.aspx";
    protected override void OnInit(EventArgs e)
    {
        base.OnInit(e);

        ValidateSession();
    }


    public void ValidateSession()
    {

        if (!Request.IsAuthenticated || (Session.IsNewSession || !User.Identity.IsAuthenticated || SessionUser.GetLoginUser() == null))
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


    public void SignOut()
    {
        Context.GetOwinContext().Authentication.SignOut(
                OpenIdConnectAuthenticationDefaults.AuthenticationType,
                CookieAuthenticationDefaults.AuthenticationType);
    }


    protected override void OnPreInit(EventArgs e)
    {
        base.OnPreInit(e);
        Utils.ApplyTheme(this);
    }

    public string GetMessage(string messageId)
    {
        object obj = GetGlobalResourceObject("Message", messageId);
        return obj != null ? (string)obj : messageId;
    }


    public bool IsGranted(string actionRight)
    {
        if (SessionUser.GetLoginUser() != null)
        {
            var actionRights = SessionUser.GetLoginUser().ActionRights;
            if (actionRights != null && actionRights.Count() > 0)
                return actionRights.Contains(actionRight);
        }

        return false;
    }




}