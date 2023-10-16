<%@ Application Language="C#" %>
<%@ Import Namespace="System" %>
<%@ Import Namespace="System.Web.Routing" %>

<script RunAt="server">
    void Application_PreRequestHandlerExecute(object sender, EventArgs e)
    {
        DevExpress.Web.ASPxWebControl.GlobalTheme = Utils.CurrentTheme;
    }
    void Application_Start(Object sender, EventArgs e)
    {
        //DevExpress.Web.Internal.DemoUtils.RegisterDemo("WebMail");
        DevExpress.DataAccess.Sql.SqlDataSource.AllowCustomSqlQueries = true;
        DevExpress.DataAccess.Sql.SqlDataSource.DisableCustomQueryValidation = true;
        DevExpress.Xpo.DB.ConnectionProviderSql.GlobalDefaultCommandTimeout = 3600;

        DevExpress.Web.ASPxWebControl.CallbackError += Callback_Error;

        //System.Web.Routing.RouteTable.Routes.MapHubs();

        //NotificationScheduler.Start();

    }
    protected void Callback_Error(object sender, EventArgs e)
    {
        Exception exception = HttpContext.Current.Server.GetLastError();

        DevExpress.Web.ASPxWebControl.SetCallbackErrorMessage(exception.Message);

        if (exception is HttpUnhandledException)
            exception = exception.InnerException;
        try
        {
            Common.writeLog("Application_Error", exception.StackTrace, true);

            //AddToLog(exception.Message, exception.StackTrace);
        }
        catch { }



    }
</script>
