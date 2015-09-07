using System;
using BIC.Utils;
using BIC.WebControls;

public partial class Controls_GalleryType : BaseUIControl
{
    public int ArticleId { get; set; }
    public string MenuUserId { get; set; }
    protected void Page_Load(object sender, EventArgs e)
    {
        galleryRef.PageSize = pager.PageSize = 15;
        pager.PageIndex = galleryRef.PageIndex;
        if (!IsPostBack)
        {
            galleryRef.MenuUserId = MenuUserId;
            galleryRef.QueryCondition = "ArticleID != " + ArticleId;
            //galleryRef.ArticleId = ArticleId;
            galleryRef.TypeOfControl = 2;
            galleryRef.Prefix = "gd";
            galleryRef.LoadData();
        }
        pager.TotalItems = galleryRef.TotalItem;
    }
    protected void pager_PageIndexChanged(object sender, PagerUIEventArgs e)
    {
        galleryRef.PageIndex = pager.PageIndex = e.NewPageIndex;
        galleryRef.LoadData();
    }
}