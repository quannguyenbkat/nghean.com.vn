using System;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Text.RegularExpressions;

public class Include
{
    public static StringBuilder Sb;
    public static string RootCssStyle = "~/Styles/{0}";
    public static string RootCssControl = "~/Controls/{0}";
    public static string RootJs = "~/Scripts/{0}";
    public static string RootBicSkin = "~/BICSkins/Menu/{0}";
    public static string RootBicSkin2 = "~/BICSkins/PanelBar/{0}";

    #region Include Default

    public static string DefaultCss()
    {
        Sb = new StringBuilder();
        Sb.Append(CssAdd(string.Format(RootCssStyle, "reset.css")));
        Sb.Append(CssAdd(string.Format(RootCssStyle, "layout.css")));
        //Sb.Append(CssAdd(string.Format(RootJs, "jquery-ui/css/ui-lightness/jquery-ui-1.8.7.custom.css")));
        //Sb.Append(CssAdd(string.Format(RootCssStyle, "bootstrap.min.css")));
        return Sb.ToString();
    }

    #endregion Include Default

    #region Jquery

    public static string JqueryUI()
    {
        Sb = new StringBuilder();
        Sb.Append(JsAdd(string.Format(RootJs, "jquery-1.7.1.min.js")));
        //Sb.Append(JsAdd(string.Format(RootJs, "jquery-ui/jquery-ui-1.8.7.custom.min.js")));
        Sb.Append(JsAdd(string.Format(RootJs, "lib.js")));
        //Sb.Append(JsAdd(string.Format(RootJs, "bootstrap.min.js")));
        //Sb.Append(JsAdd(string.Format(RootJs, "ddaccordion.js")));
        return Sb.ToString();
    }
    public static string Lofslidernews()
    {
        Sb = new StringBuilder();
        Sb.Append(JsAdd(string.Format(RootJs, "lofslidernews/js/jquery.easing.js")));
        Sb.Append(JsAdd(string.Format(RootJs, "lofslidernews/js/script.js")));
        Sb.Append(CssAdd(string.Format(RootJs, "lofslidernews/css/style2.css")));
        return Sb.ToString();
    }
    public static string Scroll()
    {
        Sb = new StringBuilder();
        Sb.Append(JsAdd(string.Format(RootJs, "scroll/js/jquery.tinyscrollbar.min.js")));
        Sb.Append(CssAdd(string.Format(RootJs, "scroll/css/website.css")));
        return Sb.ToString();
    }

    public static string Jszoom()
    {
        Sb = new StringBuilder();
        Sb.Append(JsAdd(string.Format(RootJs, "jszoom/jquery.jqzoom-core-pack.js")));
        Sb.Append(CssAdd(string.Format(RootJs, "jszoom/jquery.jqzoom.css")));
        return Sb.ToString();
    }
    public static string Scrollbar()
    {
        Sb = new StringBuilder();
        Sb.Append(JsAdd(string.Format(RootJs, "jquery-ui/js/jquery.mCustomScrollbar.js")));
        return Sb.ToString();
    }

    public static string HighSlide()
    {
        Sb = new StringBuilder();
        Sb.Append(JsAdd(string.Format(RootJs, "highslide/highslide-full.packed.js")));
        Sb.Append(CssAdd(string.Format(RootJs, "highslide/highslide-ie6.css")));
        Sb.Append(CssAdd(string.Format(RootJs, "highslide/highslide.css")));
        return Sb.ToString();
    }

    public static string ColorBox()
    {
        Sb = new StringBuilder();
        Sb.Append(JsAdd(string.Format(RootJs, "colorbox/jquery.colorbox.js")));
        Sb.Append(CssAdd(string.Format(RootJs, "colorbox/colorbox.css")));
        return Sb.ToString();
    }

    public static string Autocomplete()
    {
        Sb = new StringBuilder();
        Sb.Append(JsAdd(string.Format(RootJs, "jquery.autocomplete/jquery.autocomplete.min.js")));
        Sb.Append(CssAdd(string.Format(RootJs, "jquery.autocomplete/jquery.autocomplete.css")));
        return Sb.ToString();
    }

    public static string Simplemodal()
    {
        Sb = new StringBuilder();
        Sb.Append(JsAdd(string.Format(RootJs, "jquery.simplemodal.js")));
        return Sb.ToString();
    }

    

    #endregion Jquery

    #region Menu

    public static string Menu(string path)
    {
        Sb = new StringBuilder();
        Sb.Append(CssAdd(string.Format(RootBicSkin, path)));
        return Sb.ToString();
    }

    #endregion Menu

    #region Slide

    public static string CarouFredSel()
    {
        Sb = new StringBuilder();
        Sb.Append(JsAdd(string.Format(RootJs, "carouFredSel/jquery.carouFredSel-6.2.1-packed.js")));
        return Sb.ToString();
    }

    public static string Cycle()
    {
        Sb = new StringBuilder();
        Sb.Append(JsAdd(string.Format(RootJs, "jquery-slide/jquery.cycle.all.min.js")));
        return Sb.ToString();
    }

    public static string NivoSlider()
    {
        Sb = new StringBuilder();
        Sb.Append(JsAdd(string.Format(RootJs, "nivo-slider/jquery.nivo.slider.pack.js")));
        Sb.Append(CssAdd(string.Format(RootJs, "nivo-slider/nivo-slider.css")));
        return Sb.ToString();
    }

    public static string Diary()
    {
        Sb = new StringBuilder();
        Sb.Append(CssAdd(string.Format(RootJs, "diary/core.css")));
        Sb.Append(CssAdd(string.Format(RootJs, "diary/forms.css")));
        Sb.Append(CssAdd(string.Format(RootJs, "diary/Diary.css")));
        Sb.Append(CssAdd(string.Format(RootJs, "diary/jquery-ui.css")));
        Sb.Append(JsAdd(string.Format(RootJs, "diary/jquery-ui.js")));
        Sb.Append(JsAdd(string.Format(RootJs, "diary/dropdownchecklist_themeroller.css")));
        Sb.Append(JsAdd(string.Format(RootJs, "diary/ui.dropdownchecklist.js")));
        Sb.Append(CssAdd(string.Format(RootJs, "diary/wz_tooltip.js")));
        return Sb.ToString();
    }

    public static string Slides()
    {
        Sb = new StringBuilder();
        Sb.Append(JsAdd(string.Format(RootJs, "slides/slides.min.jquery.js")));
        Sb.Append(CssAdd(string.Format(RootJs, "slides/slides.css")));
        return Sb.ToString();
    }

    public static string Jwplayer()
    {
        Sb = new StringBuilder();
        Sb.Append(JsAdd(string.Format(RootJs, "jwplayer/jwplayer.js")));
        Sb.Append(JsAdd(string.Format(RootJs, "Video.js")));
        return Sb.ToString();
    }

    public static string Tooltipsy()
    {
        ScriptToBottom("tooltipsy.min.js");
        return string.Empty;
    }

    public static string Infieldlabel()
    {
        Sb = new StringBuilder();
        Sb.Append(JsAdd(string.Format(RootJs, "jquery.infieldlabel.min.js")));
        return Sb.ToString();
    }

    //public static string Simplemodal()
    //{
    //    Sb = new StringBuilder();
    //    Sb.Append(JsAdd(string.Format(RootJs, "jquery.simplemodal.js")));
    //    return Sb.ToString();
    //}

    public static string Charcounter()
    {
        Sb = new StringBuilder();
        Sb.Append(JsAdd(string.Format(RootJs, "jquery.charcounter.js")));
        return Sb.ToString();
    }

    #endregion Slide
    public static string Tooltip()
    {
        Sb = new StringBuilder();
        Sb.Append(CssAdd(string.Format(RootJs, "tooltip/stickytooltip.css")));
        Sb.Append(JsAdd(string.Format(RootJs, "tooltip/stickytooltip.js")));
        return Sb.ToString();
    }
    public static string FAQOld()
    {
        Sb = new StringBuilder();
        Sb.Append(CssAdd(string.Format(RootCssControl, "FAQ/FAQOld.css")));
        Sb.Append(JsAdd(string.Format(RootCssControl, "FAQ/FAQ.js")));
        return Sb.ToString();
    }

    #region Style Control

    public static string Adv()
    {
        Sb = new StringBuilder();
        Sb.Append(CssAdd(string.Format(RootCssControl, "Adv/Adv.css")));
        return Sb.ToString();
    }

    public static string Footer()
    {
        Sb = new StringBuilder();
        Sb.Append(CssAdd(string.Format(RootCssControl, "Footer/Footer.css")));
        return Sb.ToString();
    }

    public static string Voting()
    {
        Sb = new StringBuilder();
        Sb.Append(CssAdd(string.Format(RootCssControl, "Voting/Voting.css")));
        return Sb.ToString();
    }

    public static string FAQ()
    {
        Sb = new StringBuilder();
        Sb.Append(CssAdd(string.Format(RootCssControl, "FAQ/FAQ.css")));
        Sb.Append(JsAdd(string.Format(RootCssControl, "FAQ/FAQ.js")));
        return Sb.ToString();
    }

    public static string Gallery()
    {
        Sb = new StringBuilder();
        Sb.Append(CssAdd(string.Format(RootCssControl, "Gallery/Gallery.css")));
        Sb.Append(JsAdd(string.Format(RootCssControl, "Gallery/Gallery.js")));
        return Sb.ToString();
    }

    public static string Article()
    {
        Sb = new StringBuilder();
        Sb.Append(CssAdd(string.Format(RootCssControl, "Article/Article.css")));
        ////Sb.Append(JsAdd(string.Format(RootCssControl, "Article/Article.js")));
        return Sb.ToString();
        //CssToTop("Article.css");
        //return string.Empty;
    }

    public static string ArticleToolbar()
    {
        Sb = new StringBuilder();
        Sb.Append(CssAdd(string.Format(RootCssControl, "Article/Tools/Toolbar.css")));
        return Sb.ToString();
    }

    public static string Contact()
    {
        Sb = new StringBuilder();
        Sb.Append(CssAdd(string.Format(RootCssControl, "Contact/Contact.css")));
        return Sb.ToString();
    }

    public static string Comment()
    {
        Sb = new StringBuilder();
        Sb.Append(CssAdd(string.Format(RootCssControl, "Comment/Comment.css")));
        return Sb.ToString();
    }

    public static string Download()
    {
        Sb = new StringBuilder();
        Sb.Append(CssAdd(string.Format(RootCssControl, "Download/Download.css")));
        Sb.Append(JsAdd(string.Format(RootCssControl, "Download/Download.js")));
        return Sb.ToString();
    }

    public static string Language()
    {
        Sb = new StringBuilder();
        Sb.Append(CssAdd(string.Format(RootCssControl, "Language/Language.css")));
        return Sb.ToString();
    }

    public static string LiveSupport()
    {
        Sb = new StringBuilder();
        Sb.Append(CssAdd(string.Format(RootCssControl, "LiveSupport/LiveSupport.css")));
        return Sb.ToString();
    }

    public static string Navigate()
    {
        Sb = new StringBuilder();
        Sb.Append(CssAdd(string.Format(RootCssControl, "Navigate/Navigate.css")));
        return Sb.ToString();
    }

    public static string Product()
    {
        Sb = new StringBuilder();
        Sb.Append(CssAdd(string.Format(RootCssControl, "Product/Product.css")));
        Sb.Append(JsAdd(string.Format(RootCssControl, "Product/Product.js")));
        return Sb.ToString();
    }
    public static string DistributionSystem()
    {
        Sb = new StringBuilder();
        Sb.Append(CssAdd(string.Format(RootCssControl, "DistributionSystem/DistributionSystem.css")));
        return Sb.ToString();
    }

    public static string ProductToolbar()
    {
        Sb = new StringBuilder();
        Sb.Append(CssAdd(string.Format(RootCssControl, "Product/Tools/Toolbar.css")));
        return Sb.ToString();
    }

    public static string Search()
    {
        Sb = new StringBuilder();
        Sb.Append(CssAdd(string.Format(RootCssControl, "Search/Search.css")));
        //Sb.Append(JsAdd(string.Format(RootCssControl, "Search/Search.js")));
        return Sb.ToString();
    }

    public static string Login()
    {
        Sb = new StringBuilder();
        Sb.Append(CssAdd(string.Format(RootCssControl, "User/Login.css")));
        Sb.Append(JsAdd(string.Format(RootCssControl, "User/Login.js")));
        return Sb.ToString();
    }

    public static string LoginStatus()
    {
        Sb = new StringBuilder();
        Sb.Append(CssAdd(string.Format(RootCssControl, "User/LoginStatus.css")));
        Sb.Append(JsAdd(string.Format(RootCssControl, "User/LoginStatus.js")));
        return Sb.ToString();
    }

    //public static string Register()
    //{
    //    Sb = new StringBuilder();
    //    Sb.Append(CssAdd(string.Format(RootCssControl, "User/Register.css")));
    //    Sb.Append(JsAdd(string.Format(RootCssControl, "User/Register.js")));
    //    return Sb.ToString();
    //}

    public static string UserProfile()
    {
        Sb = new StringBuilder();
        Sb.Append(CssAdd(string.Format(RootCssControl, "User/UserProfile.css")));
        return Sb.ToString();
    }

    public static string Video()
    {
        Sb = new StringBuilder();
        Sb.Append(CssAdd(string.Format(RootCssControl, "Video/VideoRight.css")));
        Sb.Append(CssAdd(string.Format(RootCssControl, "Video/Video.css")));
        return Sb.ToString();
    }

    public static string ShareByEmail()
    {
        Sb = new StringBuilder();
        Sb.Append(CssAdd(string.Format(RootCssControl, "Tools/ShareByEmail.css")));
        return Sb.ToString();
    }

    public static string PrintArticle()
    {
        Sb = new StringBuilder();
        Sb.Append(CssAdd(string.Format(RootCssControl, "Tools/PrintArticle.css")));
        return Sb.ToString();
    }

    public static string PrintProduct()
    {
        Sb = new StringBuilder();
        Sb.Append(CssAdd(string.Format(RootCssControl, "Tools/PrintProduct.css")));
        return Sb.ToString();
    }

    #endregion Style Control

    #region CssMedthod

    public static string CssAdd(string path)
    {
        string result = string.Empty;
        var page = HttpContext.Current.Handler as Page;
        const string mark = "<link type='text/css'  rel='stylesheet' href='{0}' />";
        if (page != null) result = string.Format(mark, page.ResolveUrl(path));
        return result;
    }
    public static bool CssToTop(string filename)
    {
        try
        {
            var page = (Page)HttpContext.Current.Handler;
            var header = page.Header;
            var link = (HtmlGenericControl)header.FindControl("lnkCss");
            filename += filename.EndsWith(".css") ? "" : ".css";
            filename = filename.Replace("..", ".").Replace(",", ".css,").Replace(".css.css", ".css");

            if (link != null)
            {
                var linkhref = link.Attributes["href"].ToString();
                var s = string.Empty;
                foreach (var item in filename.Split(',').Where(item => !string.IsNullOrEmpty(item) && !linkhref.Contains(item) && !s.Contains(item)))
                {
                    s += (s != string.Empty ? "," : string.Empty) + item;
                }
                linkhref += (linkhref.Contains("?files=") ? "," : "?files=") + s;
                link.Attributes["href"] = page.ResolveUrl(linkhref);
            }
            return true;
        }
        catch (Exception)
        {
            return false;
        }
    }

    public static bool CssToTop(string[] filename)
    {
        var file = string.Empty;
        foreach (string s in filename)
        {
            file += s + (s.EndsWith(".css") ? "," : ".css,");
            file = file.Replace("..", ".");
        }
        file.Remove(file.Length);
        return CssToTop(file);
    }

    #endregion CssMedthod

    #region JsMedthod

    public static string JsAdd(string path)
    {
        var result = string.Empty;
        var page = HttpContext.Current.Handler as Page;
        const string mark = "<script type='text/javascript' src='{0}'></script>";
        if (page != null)
        {
            result = string.Format(mark, page.ResolveUrl(path));
            page.RegisterClientScriptBlock("bic", result);
        }
        return result;
    }

    public static bool ScriptToBottom(string filename)
    {
        try
        {
            var page = (Page)HttpContext.Current.Handler;
            var ltScript = (Literal)(page.Form.FindControl("ltScript"));
            var script = "<script type='text/javascript' src='{0}'></script>";
            var regex = "src\\=\\'.+?\\'";
            if (ltScript == null || ltScript.Text.Contains(filename)) return false;
            if (string.IsNullOrEmpty(ltScript.Text))
            {
                ltScript.Text = string.Format(script, page.ResolveUrl("~/Scripts/Bicweb.ashx?files=" + filename));
            }
            else
            {
                var m = Regex.Match(ltScript.Text, regex).ToString().Replace("src='", string.Empty).Replace("'", "," + filename);
                ltScript.Text = string.Format(script, m);
            }
            return true;
        }
        catch (Exception)
        {
            return false;
        }
    }

    public static string JsUserAdd(params string[] a)
    {
        return JsAdd("~/Scripts/" + a);
    }

    #endregion JsMedthod


}

public static class ExtStringForInclude
{
    #region AddToHead

    // Using on Page Load
    public static void ToHeader(this string a)
    {
        var page = HttpContext.Current.Handler as Page;
        if (page != null) page.Header.Controls.Add(new LiteralControl(a));
    }

    #endregion AddToHead
}