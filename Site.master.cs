using System;
using System.Collections;
using System.Web;
using BIC.Biz;
using BIC.Utils;
using BIC.WebControls;

public partial class Site : BaseMasterPage
{
    public Hashtable Hashtable
    {
        set { HttpContext.Current.Session.Add("cart", value); }
        get
        {
            var hashtable = (Hashtable)HttpContext.Current.Session["cart"] ?? new Hashtable();
            return hashtable;
        }
    }
    protected SeoEntity SeoInfo = new SeoEntity();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (IsPostBack) return;
        var seo = new Seo();
        SeoInfo = seo.GetSeoInfo("ShareLogo.jpg");
    }
  

}