using System;
using BIC.Utils;
using BIC.WebControls;

public partial class Controls_Article_ArticleReference : BaseUIControl
{
    public int ArticleId { get; set; }
    public string MenuUserId { get; set; }
    protected void Page_Load(object sender, EventArgs e)
    {
        if (IsPostBack) return;

        lvReference.MenuUserId = MenuUserId;
        // End Code
        lvReference.IgnoreArticleId = ArticleId.ToString();
        lvReference.ArticleId = ArticleId;
        lvReference.Prefix = "'+ (case TypeOfControl when '2' then 'gd' when '3' then 'vd' else 'nd' end) +'";
        lvReference.PageSize = 5;
        lvReference.LoadData();
        Visible = lvReference.Items.Count > 0;
    }
}