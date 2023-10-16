<%@ WebHandler Language="C#" Class="SaveStoreNote" %>

using System;
using System.Web;
using System.Linq;

public class SaveStoreNote : IHttpHandler, System.Web.SessionState.IReadOnlySessionState
{
    
    public void ProcessRequest (HttpContext context) {
        try
        {
            if (context.Session.IsNewSession || SessionUser.GetLoginUser() == null)
            {
                context.Response.Write(Newtonsoft.Json.JsonConvert.SerializeObject("Session expired!"));
                context.Response.End();
                return;
            }

            string note = context.Request.QueryString["note"];
            decimal storeID;
            if (!decimal.TryParse(context.Request.QueryString["key"], out storeID))
                return;

            using (KTQTData.KTQTDataEntities entities = new KTQTData.KTQTDataEntities())
            {
                var store= entities.Stores.SingleOrDefault(x => x.StoreID == storeID);
                if (store != null)
                {
                    store.Note = note;

                    entities.SaveChanges();
                }
                
            }
            context.Response.ContentType = "text/plain";
            context.Response.Write(Newtonsoft.Json.JsonConvert.SerializeObject("success"));
        }
        catch (Exception ex)
        {     
            context.Response.ContentType = "text/plain";
            context.Response.Write(Newtonsoft.Json.JsonConvert.SerializeObject(ex.Message));
        }
    }
 
    public bool IsReusable {
        get {
            return false;
        }
    }

}