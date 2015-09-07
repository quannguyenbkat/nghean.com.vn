using System;
using System.Web.UI.WebControls;
using BIC.Utils;
using BIC.WebControls;

public partial class Controls_Language : BaseUIControl
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if(IsPostBack) return;
        switch (BicLanguage.CurrentLanguage)
        {
            case "vi":
                btnVI.Visible = false;
                btnEN.Visible = true;
                break;
            case "en":
                btnVI.Visible = true;
                btnEN.Visible = false;
                break;
        }
    }

    protected void LanguageCommand(object sender, CommandEventArgs e)
    {
        switch(e.CommandName)
        {
            case "vi":
                Response.Redirect(string.Format("{0}vi/home.html", BicApplication.URLRoot));
                btnVI.Visible = false;
                btnEN.Visible = true;
                break;
            case "en":
                Response.Redirect(string.Format("{0}en/home.html", BicApplication.URLRoot));
                btnVI.Visible = true;
                btnEN.Visible = false;
                break;
        }
    }
}