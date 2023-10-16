<%@ WebHandler Language="C#" Class="DownloadTemplate" %>

using System;
using System.Web;

public class DownloadTemplate : IHttpHandler, System.Web.SessionState.IReadOnlySessionState
{

    public void ProcessRequest(HttpContext context)
    {
        try
        {
            if (context.Session.IsNewSession || SessionUser.GetLoginUser() == null)
            {
                context.Response.Write(Newtonsoft.Json.JsonConvert.SerializeObject("Session expired!"));
                context.Response.End();
                return;
            }

            string aID = context.Request.QueryString["id"];

            string fileName = string.Empty;

            if (aID.Equals("RoeVN"))
            {
                fileName = HttpContext.Current.Server.MapPath("~") + @"Templates\RoeVn.xlsx";
            }

            if (!StringUtils.isEmpty(fileName) && Common.isExistsFile(fileName))
            {
                System.IO.FileInfo file = new System.IO.FileInfo(fileName);
                context.Response.Clear();
                context.Response.AddHeader("Content-Disposition", "attachment; filename=" + file.Name.Replace(',', '_') + "");
                context.Response.AddHeader("Content-Length", file.Length.ToString());
                context.Response.ContentType = getContentType(fileName);
                context.Response.WriteFile(fileName);
                context.Response.Flush();
                context.Response.SuppressContent = true;  // Gets or sets a value indicating whether to send HTTP content to the client.
                context.ApplicationInstance.CompleteRequest();
            }
            else
            {
                context.Response.Write(Newtonsoft.Json.JsonConvert.SerializeObject("File not found!"));
                context.Response.SuppressContent = true;  // Gets or sets a value indicating whether to send HTTP content to the client.
                context.ApplicationInstance.CompleteRequest();
            }
        }
        catch (Exception ex)
        {
            context.Response.Write(Newtonsoft.Json.JsonConvert.SerializeObject(ex.Message));
            context.Response.SuppressContent = true;  // Gets or sets a value indicating whether to send HTTP content to the client.
            context.ApplicationInstance.CompleteRequest();
        }
    }

    string getContentType(String path)
    {
        switch (System.IO.Path.GetExtension(path))
        {
            case ".bmp": return "Image/bmp";
            case ".gif": return "Image/gif";
            case ".jpg": return "Image/jpeg";
            case ".png": return "Image/png";
            default: break;
        }
        return "application/octet-stream";
    }


    System.Drawing.Imaging.ImageFormat getImageFormat(String path)
    {
        switch (System.IO.Path.GetExtension(path))
        {
            case ".bmp": return System.Drawing.Imaging.ImageFormat.Bmp;
            case ".gif": return System.Drawing.Imaging.ImageFormat.Gif;
            case ".jpg": return System.Drawing.Imaging.ImageFormat.Jpeg;
            case ".png": return System.Drawing.Imaging.ImageFormat.Png;
            default: break;
        }
        return System.Drawing.Imaging.ImageFormat.Jpeg;
    }

    public bool IsReusable
    {
        get
        {
            return false;
        }
    }

}