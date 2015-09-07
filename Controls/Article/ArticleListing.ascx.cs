using System;
using System.Data;
using BIC.Biz;
using BIC.Data;
using BIC.Entity;
using BIC.Utils;
using BIC.WebControls;

public partial class Controls_Article_ArticleListing : BaseUIControl
{
    private int _menuUserId;
    private string _name;
    protected void Page_Load(object sender, EventArgs e)
    {
        _name = BicRouting.GetRequestString("menu_name", "0");
        var menuEtt = MenuUserBiz.GetMenuUserByUrlName(_name);
        if (menuEtt != null)
        {
            _menuUserId = menuEtt.MenuUserId;
            if (!IsPostBack)
            {
                BindingArticleListView();
            }
        }
        pager.PageSize = ArticleList.PageSize;
        pager.PageIndex = ArticleList.PageIndex;
        pager.TotalItems = ArticleList.TotalItem;
    }
    // Hàm đọc danh sách tin tức theo MenuUserID    
    protected void BindingArticleListView()
    {
        ArticleList.MenuUserId = _menuUserId.ToString();
        ArticleList.Prefix = "'+ (case TypeOfControl when '2' then 'gd' when '3' then 'vd' else 'nd' end) +'";
        ArticleList.PageSize = 6; 
        ArticleList.LoadData();
    }

    protected void pager_PageIndexChanged(object sender, PagerUIEventArgs e)
    {
        ArticleList.PageIndex = pager.PageIndex = e.NewPageIndex;
        ArticleList.LoadData();
    }
}