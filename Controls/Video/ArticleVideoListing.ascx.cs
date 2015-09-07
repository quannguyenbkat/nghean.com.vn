using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BIC.Utils;
using BIC.WebControls;

public partial class Controls_Video_ArticleVideoListing : System.Web.UI.UserControl
{
    private int _menuUserId;

    protected void Page_Load(object sender, EventArgs e)
    {
        _menuUserId = BicRouting.GetRequestString("lv", 0);
        if (!IsPostBack)
        {
            BindArticleListView();
        }
        pager.PageSize = ArticleList.PageSize;
        pager.PageIndex = ArticleList.PageIndex;
        pager.TotalItems = ArticleList.TotalItem;
    }

    protected void BindArticleListView()
    {
        ArticleList.MenuUserId = _menuUserId.ToString();
        ArticleList.SelectFields = "CreatedDate,BriefDescription,ImageName";
      
        ArticleList.Prefix = "'+ (case TypeOfControl when '3' then 'vd' when '2' then 'gd' else 'nd' end) +'";
        ArticleList.MenuUserIdGetPageSize = _menuUserId;
        //ArticleList.PageSize = 6;
        ArticleList.LoadData();

        pager.PageSize = ArticleList.PageSize;
        pager.PageIndex = ArticleList.PageIndex;
        pager.TotalItems = ArticleList.TotalItem;
    }

    protected void pager_PageIndexChanged(object sender, PagerUIEventArgs e)
    {
        ArticleList.PageIndex = pager.PageIndex = e.NewPageIndex;
        ArticleList.LoadData();
    }

    //protected void ibtSearch_Click(object sender, EventArgs e)
    //{
    //    BindArticleListView(true);
    //}
}