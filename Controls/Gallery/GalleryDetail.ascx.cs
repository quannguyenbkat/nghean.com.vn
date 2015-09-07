using System;
using System.Collections.Generic;
using BIC.Biz;
using BIC.Entity;
using BIC.Utils;
using BIC.WebControls;

public partial class Controls_GalleryDetail : BaseUIControl
{
    private int _id;
    protected string MenuUserId = string.Empty;
    protected string _name = string.Empty;
    protected string _title = string.Empty;
    public class AttackImage
    {
        public string Url { set; get; }
    }
    protected void Page_Load(object sender, EventArgs e)
    {
        _name = BicRouting.GetRequestString("menu_name", "0");//Lấy về ID của bài viết chi tiết
        _title = BicRouting.GetRequestString("name", "0");//Lấy về ID của bài viết chi tiết
        MenuUserEntity menuEtt = MenuUserBiz.GetMenuUserByUrlName(_name);
        if (menuEtt != null)
        { MenuUserId = menuEtt.MenuUserId.ToString(); }
        ArticleEntity articleEtt = ArticleBiz.GetArticleByUrlName(_title);
        if (articleEtt != null)
        {
            _id = articleEtt.ArticleID;
            lbtitle.Text = articleEtt.Title;
            

            if (!IsPostBack)
            {
                ArticleEntity articleEntity = ArticleBiz.GetArticleByID(_id);
                lbtitle.Text = articleEntity.Title;
                LoadImageArray(articleEntity.ImageArray); // Load ảnh mô tả
                OtherGalleryType.ArticleId = _id;
                OtherGalleryType.MenuUserId = MenuUserId;
            }
        }

    }

    public void LoadImageArray(string imageArray)
    {
        if (!string.IsNullOrEmpty(imageArray))
        {
            string[] images = imageArray.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries);
            IList<AttackImage> attackImages = new List<AttackImage>();
            foreach (string image in images)
            {
                AttackImage attackImage = new AttackImage();
                attackImage.Url = BicImage.GetPathImage(BicConvert.ToInt32(image));
                attackImages.Add(attackImage);
            }
            rptImageArr.DataSource = attackImages;
            rptImageArr.DataBind();
            rptImgBig.DataSource = attackImages;
            rptImgBig.DataBind();
        }
    }
}