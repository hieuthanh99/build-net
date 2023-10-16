using Microsoft.Owin.Security;
using Microsoft.Owin.Security.OpenIdConnect;
using Microsoft.Owin.Security.Cookies;
using System;
using System.Web;

public partial class _Default : BasePage
{
    //KTQTDataEntities entities = new KTQTDataEntities();

    protected void Page_Load(object sender, EventArgs e)
    {

    }

    //protected override void InitializeCulture()
    //{

    //    string lang = "vi-VN";

    //    Thread.CurrentThread.CurrentCulture = new System.Globalization.CultureInfo(lang);
    //    Thread.CurrentThread.CurrentUICulture = new System.Globalization.CultureInfo(lang);

    //    base.InitializeCulture();
    //}
    protected void ASPxDashboard1_CustomParameters(object sender, DevExpress.DashboardWeb.CustomParametersWebEventArgs e)
    {
        //ASPxDashboard dashboard = sender as ASPxDashboard;
        //try
        //{
        //    var version = entities.Versions.Where(x => x.VersionType == "A" && x.UsedStatus == "USED").OrderByDescending(x => x.VersionYear).FirstOrDefault();

        //    if (e.DashboardId == "dashboard2")
        //    {
        //        foreach (var param in e.Parameters)
        //        {
        //            if (param.Name == "VersionID" && version != null)
        //                param.Value = version.VersionID;

        //            //if (param.Name == "AreaCode" && SessionUser.AreaCode != "CTY")
        //            //    param.Value = SessionUser.AreaCode;

        //            //if (param.Name == "FromDate")
        //            //    param.Value = DateTimeUtils.getFirstDayOfYear(DateTime.Now);

        //            //if (param.Name == "ToDate")
        //            //    param.Value = DateTimeUtils.getLastDayOfPreviousMonth(DateTime.Now);
        //        }
        //    }
        //}
        //catch (Exception ex) { }

    }
}
