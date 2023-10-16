using Hangfire.Annotations;
using Hangfire.Dashboard;
using Microsoft.Owin;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for HangfireAuthorizationFilter
/// </summary>
public class HangfireAuthorizationFilter: IDashboardAuthorizationFilter
{
    public HangfireAuthorizationFilter()
    {
        //
        // TODO: Add constructor logic here
        //
    }

    public bool Authorize([NotNull] DashboardContext context)
    {
        var owinContext = new OwinContext(context.GetOwinEnvironment());

        return owinContext.Authentication.User.Identity.IsAuthenticated;
    }
}