using APPData;
using Microsoft.Owin.Security.Cookies;
using Microsoft.Owin.Security.OpenIdConnect;
using System;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.Security;

public partial class Account_SignOut : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            using (QLKHAppEntities entities = new QLKHAppEntities())
            {
                decimal LogID = (decimal)Session[SessionConstant.LOGID];

                var Log = entities.UserLoginAttempts.SingleOrDefault(x => x.Id == LogID);
                if (Log != null)
                {
                    Log.LogoutAt = DateTime.Now;

                    entities.SaveChanges();
                }
            }
        }
        catch{}
        finally
        {
            try
            {
                FormsAuthentication.SignOut();
                Session.Abandon();
            }
            catch { }

            Response.Redirect(HelpDeskConstant.LoginPageUrl);
        }
    }
}