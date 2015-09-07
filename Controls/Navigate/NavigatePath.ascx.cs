using System;
using System.Collections.Generic;
using BIC.Biz;
using BIC.Entity;
using BIC.Utils;
using BIC.WebControls;

public partial class Controls_Navigate_NavigatePath : BaseUIControl
{
    public string CSS { get; set; }
    public string UrlName { get; set; }

    public bool VisibleHomePage { get; set; }

    protected void Page_Load(object sender, EventArgs e)
    {
        UrlName = BicRouting.GetRequestString("menu_name");
        //if (MenuUserId == 0)
        //    MenuUserId = BicRouting.GetRequestString("lv", 0);
        if (!IsPostBack)
            LoadData();
    }

    protected void LoadData()
    {
        VisibleHomePage = true;
        string result = string.Empty;
        List<MenuUserEntity> items = MenuUserBiz.GetNavigatePathById(MenuUserBiz.MenuUserGetIDByURLName(UrlName));
        if (items == null) return;
        int i = 1;
       if(VisibleHomePage)
           result = string.Format("<a class='home' href='{0}{1}/home.html'>{2}</a> ", BicApplication.URLRoot, Language, BicResource.GetValue("HomePage"));
       if (Request.Url.ToString().Contains("search.html"))
           result += string.Format("<a href='{0}' target='{2}' class='arr firt' id='menu{3}'>{1}</a>", "#", BicLanguage.CurrentLanguage == "vi"?"Tìm kiếm":"Search", "", "", "");
        foreach (MenuUserEntity item in items)
        {
            //if (i == 1)
            //    result += string.Format("<a href='{0}' target='{2}' class='arr'>{1}</a>", item.URL, item.Name, item.Target);
            //else
            //    result += string.Format("<a href='{0}' target='{2}'>{1}</a>", item.URL, item.Name, item.Target);
            //i++;
            if (i == 1)
            {
                if (i == items.Count)
                {
                    result += string.Format("<h2><a href='{0}' target='{2}' class='arr firt' id='menu{3}'>{1}</a></h2>", item.URL, item.Name.Replace("</br>",""), item.Target, item.MenuUserId);
                }
                else
                    result += string.Format("<a href='{0}' target='{2}' class='arr firt' id='menu{3}'>{1}</a>", item.URL, item.Name.Replace("</br>", ""), item.Target, item.Target, item.MenuUserId);
            }
            else
            {
                if (i == items.Count)
                {
                    result += string.Format("<h2><a href='{0}' class='arr' target='{2}'>{1}</a></h2>", item.URL, item.Name.Replace("</br>", ""), item.Target);
                }
                else
                    result += string.Format("<a href='{0}' class='arr' target='{2}'>{1}</a>", item.URL, item.Name.Replace("</br>", ""), item.Target);
            }
            i++;
        }
        lblNavigatePath.Text = result;
    }
}