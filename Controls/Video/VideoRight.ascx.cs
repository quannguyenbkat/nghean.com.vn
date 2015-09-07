using System;
using BIC.Utils;
using BIC.WebControls;

public partial class Controls_Video_HiLiArticleVideo : BaseUIControl
{
    public string MenuUserId { get; set; }
    protected void Page_Load(object sender, EventArgs e)
    {

        if (!IsPostBack)
        {
            MenuUserId = "21";
            mncap.MenuUserId = 21;
            lvArticleVideo.SelectFields =
                "ImageName,CreatedDate,(SELECT TOP 1 (case URL when '' then [Path] + [Name] else URL end) from Video v WHERE v.VideoId = Article.VideoId) VideoUrl,(SELECT TOP 1 FileType from Video v WHERE v.VideoId = Article.VideoId) FileType,(SELECT i.[Path] + i.[Name] from [Image] i where i.ImageID = (SELECT TOP 1 ImageId from Video v WHERE v.VideoId = Article.VideoId)) ImageThumb";
            lvArticleVideo.MenuUserId = MenuUserId;
            lvArticleVideo.TypeOfControl = 3;
            lvArticleVideo.PageSize = 3;
            lvArticleVideo.LoadData();
            Visible = lvArticleVideo.Items.Count > 0;
        }
    }
}