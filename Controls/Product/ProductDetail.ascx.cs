using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using BIC.Biz;
using BIC.Data;
using BIC.Entity;
using BIC.Utils;
using BIC.WebControls;

public partial class Controls_Product_ProductDetail : BaseUIControl
{
    protected int ProductId;
    public string MenuUserId = string.Empty;
    public string ViewCount;
    public string Name;
    public DateTime CreatedDate;
    protected int MenuUserIdPointSale;
    protected int MenuUserIdComment;
    protected string Lang;
    public int countImg;
    protected string _name = string.Empty;
    public class AttackImage
    {
        public string Url { set; get; }
    }
    public string SendMailUrl { get; set; }
    protected void Page_Load(object sender, EventArgs e)
    {
        _name = BicRouting.GetRequestString("menu_name", "0");
        ProductId = BicRouting.GetRequestString("id", 0);
        MenuUserEntity menuEtt = MenuUserBiz.GetMenuUserByUrlName(_name);
        if (menuEtt != null)
        { MenuUserId = menuEtt.MenuUserId.ToString(); }
        Name = BicRouting.GetRequestString("name", "0");
        Lang = BicRouting.GetRequestString("l");
        if (IsPostBack) return;
        BindingProductDetail();
        SendMailUrl = string.Format("{0}{1}/ShareByEmail.html?target={2}", BicApplication.URLRoot, Language, Request.Url);
    }
    /// <summary>
    /// Nạp dữ liệu lên các điều khiển của trang chi tiết
    /// </summary>
    
    protected void BindingProductDetail()
    {

        ProductEntity productEntity = ProductBiz.GetProductByUrlName(Name);
        if (productEntity != null)
        {
            ProductBiz.UpdateProductViewCount(productEntity.ProductID);
            Page.Title = string.IsNullOrEmpty(Convert.ToString(productEntity.PageTitle)) ? string.Format("{0} - {1}", productEntity.Title, MenuUserBiz.GetNameById(BicConvert.ToInt32(MenuUserId))) : productEntity.PageTitle;
            Page.MetaKeywords = productEntity.MetaKeyWord == "" ? Server.HtmlDecode(BicXML.ToString("Keywords", "SearchEngine")) : productEntity.MetaKeyWord;
            Page.MetaDescription = productEntity.MetaDescription == "" ? productEntity.BriefDescription : productEntity.MetaDescription;
            lblNamePro.Text = productEntity.Title;
            ltrBody.Text = productEntity.Body;
            ProductRef.MenuUserId = MenuUserId;
            ProductRef.ProductId = productEntity.ProductID;
        }
        else
            Visible = false;
    }
    
}
