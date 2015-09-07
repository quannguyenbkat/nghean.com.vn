using System;
using System.Data;
using System.Web.UI.WebControls;
using BIC.Biz;
using BIC.Data;
using BIC.Entity;
using BIC.Utils;
using BIC.WebControls;

public partial class Controls_Product_ProductGroup : BaseUIControl
{
    protected string Css;
    private string UrlName;
    private int _MenuUserID;
    protected string Lang;
    protected int count;
    protected void Page_Load(object sender, EventArgs e)
    {
        UrlName = BicRouting.GetRequestString("menu_name", string.Empty);
        if (!string.IsNullOrEmpty(UrlName))
        {
            var menu = MenuUserBiz.GetMenuUserByUrlName(UrlName);
            if (menu != null)
            {
                mncap.MenuUserId = _MenuUserID = menu.MenuUserId;

            }
        }
        if (!IsPostBack)
        {
            
           BindingList();
        }

    }
    protected void BindingList()
    {
        var data = new BicGetData { TableName = "MenuUser", PageSize = 20};
        data.Selecting.Add(MenuUserEntity.FIELD_MENUUSERID);
        data.Selecting.Add(MenuUserEntity.FIELD_NAME);
        data.Selecting.Add(MenuUserEntity.FIELD_URLNAME);
        data.Selecting.Add(MenuUserEntity.FIELD_URL);
        data.Selecting.Add(MenuUserEntity.FIELD_IMAGEID);
        data.Selecting.Add(MenuUserEntity.FIELD_IMAGENAME);
        data.Selecting.Add(MenuUserEntity.FIELD_DESCRIPTION);
        data.Selecting.Add(MenuUserEntity.FIELD_TARGET);
        data.Selecting.Add(MenuUserEntity.FIELD_ISNEW);
        data.Sorting.Add(new SortingItem("Priority", false));
        data.Conditioning.Add(new ConditioningItem(MenuUserEntity.FIELD_PARENTID, _MenuUserID.ToString(), Operator.EQUAL, CompareType.STRING));
        data.Conditioning.Add(new ConditioningItem(MenuUserEntity.FIELD_ISACTIVE, "1", Operator.EQUAL, CompareType.STRING));

        DataTable dt = data.GetPagingData();
        if (dt != null && dt.Rows.Count > 0)
        {
            ProductListgroup2.DataSource = dt;
            ProductListgroup2.DataBind();
            pager.PageSize = data.PageSize;
            pager.PageIndex = data.PageIndex;
            pager.TotalItems = data.GetAllData().Rows.Count;
        }

    }
  
    protected void pager_PageIndexChanged(object sender, PagerUIEventArgs e)
    {
        if (e.NewPageIndex >= 0)
        {
            pager.PageIndex = e.NewPageIndex;
            pager.PageSize = 20;
            var data = new BicGetData { TableName = "MenuUser", PageSize = 20, PageIndex = e.NewPageIndex };
            data.Selecting.Add(MenuUserEntity.FIELD_MENUUSERID);
            data.Selecting.Add(MenuUserEntity.FIELD_NAME);
            data.Selecting.Add(MenuUserEntity.FIELD_URLNAME);
            data.Selecting.Add(MenuUserEntity.FIELD_URL);
            data.Selecting.Add(MenuUserEntity.FIELD_IMAGEID);
            data.Selecting.Add(MenuUserEntity.FIELD_IMAGENAME);
            data.Selecting.Add(MenuUserEntity.FIELD_DESCRIPTION);
            data.Selecting.Add(MenuUserEntity.FIELD_TARGET);
            data.Selecting.Add(MenuUserEntity.FIELD_ISNEW);
            data.Sorting.Add(new SortingItem("Priority", false));
            data.Conditioning.Add(new ConditioningItem(MenuUserEntity.FIELD_PARENTID, _MenuUserID.ToString(), Operator.EQUAL, CompareType.STRING));
            data.Conditioning.Add(new ConditioningItem(MenuUserEntity.FIELD_ISACTIVE, "1", Operator.EQUAL, CompareType.STRING));

            DataTable dt = data.GetPagingData();
            if (dt != null && dt.Rows.Count > 0)
            {
                ProductListgroup2.DataSource = dt;
                ProductListgroup2.DataBind();
                
                pager.TotalItems = data.GetAllData().Rows.Count;
            }
            //else
            //{
            //    ProductListgroup2.DataSource = null;
            //    ProductListgroup2.DataBind();
            //}

        }
    }
    protected void MenuParentItemDataBound(object sender, ListViewItemEventArgs e)
    {
        var menuChild = (MenuListView)e.Item.FindControl("menuChild");
        if (menuChild == null) return;
        var dr = (DataRowView)e.Item.DataItem;
        menuChild.ParentId = BicConvert.ToInt32(dr["MenuUserId"]);
        menuChild.PageSize = 1000;
        menuChild.Language = BicLanguage.CurrentLanguage;
        menuChild.LoadData();
    }

    public string _Getlink(string url,string name)
    {
        string link= "{0}{1}{2}" + url ;
        link = string.Format(link,"","","", name, BicLanguage.CurrentLanguage); 
        return link;
    }

}