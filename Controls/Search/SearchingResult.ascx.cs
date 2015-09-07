using System;
using System.Data;
using System.Web.UI.WebControls;
using BIC.Biz;
using BIC.Entity;
using BIC.Utils;
using BIC.WebControls;

public partial class Controls_Search_SearchingResult : BaseUIControl
{
    public string _keyword;
    public int result;

    protected void Page_Load(object sender, EventArgs e)
    {
        _keyword = BicRouting.GetRequestString("k", string.Empty);
        searching.PageSize = pager.PageSize = 10;
        if (!IsPostBack)
        {
            searching.ViewName = "Searching";
            searching.QueryCondition = string.Format("(LanguageKey = '{0}' AND Title Like N'%{1}%' OR  BriefDescription Like N'%{1}%') AND TypeOfControl != '3' ", BicLanguage.CurrentLanguage, _keyword);
            searching.Prefix = "'+ (case TypeOfControl when '2' then 'gd' when '3' then 'vd' when '4' then 'pd' else 'nd' end) +'";
            searching.LoadData();
            result = searching.TotalItem;
            pager.Visible = searching.TotalItem >= pager.PageSize;
        }
        pager.TotalItems = searching.TotalItem;
        
    }

    protected void pager_PageIndexChanged(object sender, PagerUIEventArgs e)
    {
        searching.PageIndex = pager.PageIndex = e.NewPageIndex;
        searching.LoadData();
        result = searching.TotalItem;
    }

    protected void searchingArticle_ItemDataBound(object sender, ListViewItemEventArgs e)
    {
        if (e.Item.ItemType == ListViewItemType.DataItem)
        {
            var dr = (DataRowView)e.Item.DataItem;
            if (dr != null)
            {
                var menuCaption = (HyperLink)e.Item.FindControl("mnuSearch");
                var menuUserEntity =
                    MenuUserBiz.GetByIdShort(BicConvert.ToInt32(BicConvert.ToInt32(dr["MainMenuUserID"])));
                if (menuUserEntity == null) return;
                menuCaption.NavigateUrl = menuUserEntity.URL;
                menuCaption.Text = BicString.HighlightKeyWords(menuUserEntity.Name, _keyword, "highlight", string.Empty);
                menuCaption.Target = menuUserEntity.Target;
            }

        }
    }
}