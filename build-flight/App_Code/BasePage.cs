
using APPData;
using HtmlAgilityPack;
using Microsoft.Owin.Security;
using Microsoft.Owin.Security.Cookies;
using Microsoft.Owin.Security.OpenIdConnect;
using System;
using System.Configuration;
using System.IdentityModel.Claims;
using System.Linq;
using System.Web;
/// <summary>
/// Summary description for BasePage
/// </summary>
public class BasePage : System.Web.UI.Page
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
        else
        {
            if (!IsPostBack)
                this.CheckPermitionURL();
        }
    }

    /// <summary>
    /// Send an OpenID Connect sign-out request.
    /// </summary>
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


    private void CheckPermitionURL()
    {
        string url = Request.RawUrl.Split('?')[0];
        if (StringUtils.isEmpty(url) || url.Equals("/"))
        {
            if (IsCallback)
                DevExpress.Web.ASPxWebControl.RedirectOnCallback(AccessDeniedPage);
            else
                Response.Redirect(AccessDeniedPage);

            return;
        }

        QLKHAppEntities entity = new QLKHAppEntities();

        var check = (from a in entity.GroupUserMenus
                     join b in entity.GroupUsers on a.GroupID equals b.GroupID
                     join c in entity.Menus on a.MenuID equals c.MenuID
                     join d in entity.UserGroupUsers on b.GroupID equals d.GroupID
                     where d.UserID == SessionUser.UserID && c.AppCode == SessionUser.Application && c.FileName.Contains(url) && d.Used == true && (a.Used ?? false) == true
                     select a).Any();

        if (!check)
        {
            if (IsCallback)
                DevExpress.Web.ASPxWebControl.RedirectOnCallback(AccessDeniedPage);
            else
                Response.Redirect(AccessDeniedPage);
        }

    }

    public string GetImageName(string imgSource)
    {
        try
        {
            string retStr = imgSource.Replace("cid:", "");
            if (retStr.IndexOf('@') > 0)
                return retStr.Substring(0, retStr.IndexOf('@'));
            else
                return retStr;
        }
        catch (Exception) { }
        return string.Empty;
    }

    public string EmbedImageProcess(string htmlInput, decimal id, bool preview = false)
    {
        try
        {
            HtmlDocument doc = new HtmlDocument();
            doc.LoadHtml(htmlInput);

            var nodes = doc.DocumentNode.SelectNodes("//img");

            foreach (var node in nodes)
            {
                try
                {
                    string src = node.Attributes["src"].Value;
                    if (!src.Contains("cid")) continue;
                    string imgName = GetImageName(src);
                    if (string.IsNullOrEmpty(imgName)) continue;
                    //string fileName = MapPath(string.Format("~/Portals/0/YeuCau/{0}/{1}", id, imgName));
                    //if (Common.isExistsFile(fileName))
                    //    node.Attributes["src"].Value = string.Format("/Portals/0/YeuCau/{0}/{1}", id, imgName);
                    if (preview)
                        node.Attributes["src"].Value = string.Format("../GenericHandler/attachment.ashx?type=1&id={0}&attach={1}", id, HttpUtility.UrlEncode(imgName));
                    else
                        node.Attributes["src"].Value = string.Format("../GenericHandler/attachment.ashx?type=1&id={0}&attach={1}", id, HttpUtility.UrlEncode(imgName));

                }
                catch (Exception) { }
            }
            string htmlOutput = doc.DocumentNode.OuterHtml;
            return htmlOutput;
        }
        catch (Exception) { }
        return htmlInput;
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