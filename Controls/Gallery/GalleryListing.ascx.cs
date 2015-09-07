using System;
using BIC.Biz;
using BIC.Data;
using BIC.Entity;
using BIC.Utils;
using BIC.WebControls;

public partial class Controls_Gallery_GalleryListing : BaseUIControl
{
    private string _menuUserId = string.Empty;
    private string _name;
    protected void Page_Load(object sender, EventArgs e)
    {
        _name = BicRouting.GetRequestString("menu_name", "0");
        MenuUserEntity menuEtt = MenuUserBiz.GetMenuUserByUrlName(_name);
        if (menuEtt != null)
        {
            _menuUserId = menuEtt.MenuUserId.ToString();
        }
        //mncap.MenuUserId = BicConvert.ToInt32(_menuUserId);
        articleGallery.PageSize = pager.PageSize = 15;
        if (!IsPostBack)
        {
            articleGallery.MenuUserId = _menuUserId;
            articleGallery.OrderBy = "Priority";
            articleGallery.LoadData();
        }
        pager.TotalItems = articleGallery.TotalItem;


    }

    protected void pager_PageIndexChanged(object sender, PagerUIEventArgs e)
    {
        articleGallery.PageIndex = pager.PageIndex = e.NewPageIndex;
        articleGallery.LoadData();
    }

}