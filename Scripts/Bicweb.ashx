<%@ WebHandler Language="C#" Class="Bicweb" %>

using System;
using System.Web;

public class Bicweb : IHttpHandler
{

    public void ProcessRequest(HttpContext context)
    {
        var querystring = context.Request.QueryString["files"];
        var dir = context.Request.QueryString["dir"];
        dir = string.IsNullOrEmpty(dir) ? "~/Scripts/" : dir + "/";
        dir = (dir.StartsWith("~/") ? "" : "~/") + dir;
        dir = dir.Replace("//", "/");
        if (!string.IsNullOrEmpty(querystring))
        {
            var files = querystring.Split(new char[] { ',', ';' }, StringSplitOptions.RemoveEmptyEntries);
            context.Response.ContentType = "text/javascript";
            context.Response.Write(Compress.CombineScripts(dir, files));
        }
    }

    public bool IsReusable
    {
        get
        {
            return false;
        }
    }

}