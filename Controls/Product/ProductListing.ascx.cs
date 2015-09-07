using System;
using System.Data;
using System.Text;
using System.Web.UI.WebControls;
using BIC.Biz;
using BIC.Data;
using BIC.Entity;
using BIC.Utils;
using BIC.WebControls;

public partial class Controls_Product_ProductListing : BaseUIControl
{
    private int _menuUserId;
    private string _name;
    public int count;
    private int ParentID;
    protected int Point;
    public string chuoi = "";
    protected StringBuilder Sb = new StringBuilder();
    protected void Page_Load(object sender, EventArgs e)
    {
        
        if (!IsPostBack)
        {
            _name = BicRouting.GetRequestString("menu_name", string.Empty);
            if (string.IsNullOrEmpty(_name)) return;
            var menuEtt = MenuUserBiz.GetMenuUserByUrlName(_name);
            if (menuEtt != null)
            {
                _menuUserId = menuEtt.MenuUserId;
                ParentID = menuEtt.ParentID;
            }
            BindingArticleListView();
        }
        
    }
    protected void BindingArticleListView()
    {
        ProductList.MenuUserId = _menuUserId.ToString(); 
        ProductList.PageSize = 12;
        ProductList.PageIndex = pager.PageIndex = 0;
        ProductList.LoadData();
        pager.PageSize = ProductList.PageSize;
        pager.PageIndex = ProductList.PageIndex;
        count = ProductList.TotalItem;
        pager.TotalItems = ProductList.TotalItem;
    }
    protected void BindingArticleListView2(object sender, EventArgs e)
    {
        BindingArticleListView();
    }
    
    protected void pager_PageIndexChanged(object sender, PagerUIEventArgs e)
    {
        ProductList.PageIndex = pager.PageIndex = e.NewPageIndex;
        count = pager.TotalItems;
        ProductList.PageSize = 12;
        ProductList.LoadData();
        pager.PageSize = ProductList.PageSize;
        pager.PageIndex = ProductList.PageIndex;
        count = ProductList.TotalItem;
        pager.TotalItems = ProductList.TotalItem;
    }
    
    
}