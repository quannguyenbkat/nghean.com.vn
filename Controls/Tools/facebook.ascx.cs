using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BIC.Utils;
using BIC.WebControls;

public partial class Controls_Comment_facebook : BaseUIControl
{
    public string Url
    {
        get
        {
            var obj = ViewState["url"];
            return obj != null ? (string)obj : Request.Url.ToString();
        }
        set { ViewState["url"] = value; }
    }
    public int PostCount
    {
        get
        {
            var obj = ViewState["postcount"];
            return (obj != null || (int)obj > 0) ? (int)obj : 10;
        }
        set { ViewState["postcount"] = value; }
    }
    public int Width
    {
        get
        {
            var obj = ViewState["width"];
            return (obj != null || (int) obj > 250) ? (int) obj : 250;
        }
        set { ViewState["width"] = value; }
    }
    public string AppId
    {
        get { return string.Format("&appId={0}", "171200359755268"); }
        //BicWebConfig.GetAppSettingValue("FaceBookAppId")
    }
    protected void Page_Load(object sender, EventArgs e)
    {

    }
}