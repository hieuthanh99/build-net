<%@ WebHandler Language="C#" Class="GetStoreNote" %>

using System;
using System.Web;
using System.Linq;

public class GetStoreNote : IHttpHandler, System.Web.SessionState.IReadOnlySessionState
{
    public void ProcessRequest(HttpContext context)
    {

        if (context.Session.IsNewSession || SessionUser.GetLoginUser() == null)
        {
            context.Response.Write(Newtonsoft.Json.JsonConvert.SerializeObject("Session expired!"));
            context.Response.End();
            return;
        }

        decimal storeID;
        if (!decimal.TryParse(context.Request.QueryString["key"], out storeID))
            return;
        
        string note = string.Empty;
        using (KTQTData.KTQTDataEntities entities = new KTQTData.KTQTDataEntities())
        {
            var store = entities.Stores.SingleOrDefault(x => x.StoreID == storeID);
            if (store != null)
            {
                note = store.Note;
            }
        }
        context.Response.ContentType = "text/plain";
        context.Response.Write(Newtonsoft.Json.JsonConvert.SerializeObject(note));
    }

    public bool IsReusable
    {
        get
        {
            return false;
        }
    }

}