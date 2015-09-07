using System;
using BIC.Biz;
using BIC.Utils;
using BIC.WebControls;

public partial class Controls_Article_Base_AboutUs : BaseUIControl
{
    public int MenuUserId { get; set; }

    protected void Page_Load(object sender, EventArgs e)
    {
        if (IsPostBack) return;
        MenuUserId = Language.Equals("vi") ? 2 : 2;
        BindingArticle();
    }

    //Nap du lieu cho so luong bai so luong 1
    private void BindingArticle()
    {
        var articleEntity = ArticleBiz.ArticlesGetEntityByMenuUserId(MenuUserId);
        if (articleEntity == null) return;
        ltrTitleAboutUs.Text = BicString.TrimText(articleEntity.Title,40);
        imgAboutUs.ImageName = articleEntity.ImageName;
        imgAboutUs.Target = articleEntity.Target;
        imgAboutUs.Alt = articleEntity.Title;
        imgAboutUs.Title = articleEntity.Title;
        ltlBriefDescription.Text = BicString.TrimText(articleEntity.BriefDescription,250);
        aAboutUs1.Title = articleEntity.Title;
        imgAboutUs.Link = aAboutUs1.HRef = aAboutUs2.HRef = articleEntity.Link != string.Empty ? articleEntity.Link : string.Format("{0}{1}", BicApplication.URLRoot, articleEntity.Url);
        ltlDetail.Text = BicResource.GetValue("Detail");
    }
}