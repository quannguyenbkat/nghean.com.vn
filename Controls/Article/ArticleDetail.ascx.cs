using System;
using System.Collections.Generic;
using BIC.Biz;
using BIC.Entity;
using BIC.Utils;
using BIC.WebControls;

public partial class Controls_Article_ArticleDetail : BaseUIControl
{
    protected int Id;
    protected string MenuUserId;
    protected string _name;
    protected string _title;
    public string SendMailUrl;
    public class AttackImage
    {
        public string Url { set; get; }
    }
    protected void Page_Load(object sender, EventArgs e)
    {
        _name = BicRouting.GetRequestString("menu_name");//Lấy về ID của bài viết chi tiết
        _title = BicRouting.GetRequestString("name");//Lấy về ID của bài viết chi tiết

        var urlpath = Request.Url.AbsolutePath;
        string[] arr = urlpath.Split(new char[] { '/' }, StringSplitOptions.RemoveEmptyEntries);

        if (string.IsNullOrEmpty(_name))
        {
            if (arr.Length > 2)
            {
                if (arr[1].IndexOf('.') > 0)
                {
                    _name = arr[1].Substring(0, arr[1].IndexOf('.'));
                }
            }
        }
        if (string.IsNullOrEmpty(_title))
        {
            if (arr.Length > 2)
            {
                if (arr[2].IndexOf('.') > 0)
                {
                    _title = arr[2].Substring(0, arr[2].IndexOf('.'));
                }
            }
        }

        MenuUserEntity menuEtt = MenuUserBiz.GetMenuUserByUrlName(_name);
        if (menuEtt != null)
        { MenuUserId = menuEtt.MenuUserId.ToString(); }
        ArticleEntity articleEtt = ArticleBiz.GetArticleByUrlName(_title);
        if (articleEtt != null)
        {
            Id = articleEtt.ArticleID;
        }//Lấy về ID của bài viết chi tiết
        if (IsPostBack) return;//Nếu là Refresh trang sẽ không chạy đoạn code bên dưới
        articleReference.MenuUserId = MenuUserId;//Thiết lập MenuUserId cho Control tin liên quan và tiêu đề
        articleReference.ArticleId = Id; //Thiết lập ArticleId cho Control tin liên quan, để hệ thống đọc các bài viết cũ hơn bài viết có Id này.
        BindingArticleDetail();
    }

    /// <summary>
    /// Nạp dữ liệu lên các điều khiển của trang chi tiết
    /// </summary>
    protected void BindingArticleDetail()
    {
        //ArticleBiz.UpdateArticleViewCount(Id);//Tăng lượt xem lên 1 giá trị
        ArticleEntity articleEntity = ArticleBiz.GetArticleByID(Id);
        if (articleEntity != null)
        {
            
            Page.MetaDescription = articleEntity.MetaDescription == "" ? articleEntity.BriefDescription : articleEntity.MetaDescription;
            if (articleEntity.TinTieuDiem == 1)
            {
                ltlTitle.Text = articleEntity.Title;
                if (articleEntity.IsNew)
                    ltlTitle.Text += BicLanguage.CurrentLanguage == "vi" ? " <img src='/Styles/icon/new_vi.gif' style='float:none;display:inline-block' />" : " <img src='/Styles/icon/new_en.gif' style='float:none;display:inline-block' />";
            }
            ltlDescription.Text = articleEntity.Body;
            
            SendMailUrl = string.Format("{0}{1}/ShareByEmail.html?target={2}", BicApplication.URLRoot, Language, Request.Url);

            BottomToolbar.ViewCount = articleEntity.ViewCount;
            BottomToolbar.ModifiedDate = articleEntity.CreatedDate;
            TopToolbar.ArticleID = articleEntity.ArticleID;
            if (!articleEntity.IsFull)
            {
                BottomToolbar.Visible = TopToolbar.Visible = false;
                h1title.Attributes.CssStyle.Add("margin-bottom", "20px");
            }
            if (articleEntity.TinTieuDiem == 0)
            {
                h1title.Visible = false;
                if (articleEntity.IsFull)
                {
                    fixtoolbar.Attributes.CssStyle.Add("margin-top", "-10px");
                    fixtoolbar2.Attributes.CssStyle.Add("margin-top", "-10px");
                }
            }
        }
        else
            Visible = false;
    }

    
}