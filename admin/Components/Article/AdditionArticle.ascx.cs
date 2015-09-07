﻿using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using System.Web;
using System.Web.UI.WebControls;
using BIC.Biz;
using BIC.Data;
using BIC.Entity;
using BIC.Handler;
using BIC.Utils;
using BIC.WebControls;

public partial class Admin_Components_Article_AdditionArticle : BaseUserControl
{
    private int _id;

    public void PositionWithPriorityAdd()
    {
        try
        {
            var dh = new DataHelper();
            var maxPosition = BicConvert.ToInt32(dh.CountItem("ArticleId", "Article"));
            if (maxPosition < 1)
                maxPosition = 1;
            ntxPosition.MaxValue = maxPosition;
        }
        catch (Exception ex)
        {
            LogEvent.LogToFile(ex.ToString());
        }
    }

    private void BindTextH1()
    {
        reBody.Content =
            "<h1 style='background:url(/Controls/Article/img/at_intro_title.png) repeat-y center top;margin:0;padding:10px 0;color:#443112;font:700 27px Times New Roman;min-height:55px;text-align:center'></h1>";
    }
    public void RemoveCache()
    {
        var keyList = new List<string>();
        var cacheEnum = HttpContext.Current.Cache.GetEnumerator();
        while (cacheEnum.MoveNext())
        {
            keyList.Add(cacheEnum.Key.ToString());
        }
        foreach (var key in keyList)
        {
            HttpContext.Current.Cache.Remove(key);
        }
    }

    protected void Page_Load(object sender, EventArgs e)
    {
        _id = BicHtml.GetRequestString("id", 0);
        if (IsPostBack) return;

        chkIsShowToolbar.Checked = true;
        chkIsShowTitle.Checked = true;
        if (!Added)
        {
            BicAdmin.NavigateToDenyPage();
        }
        if (BicSession.ToString("ArticleLanguage") != string.Empty)
            ddlLanguage.SelectedValue = BicSession.ToString("ArticleLanguage");

        MenuUserUtils.BindingRadTreeView(tvMenuUser, ddlLanguage.SelectedValue, "news", "cot1");
        MenuUserUtils.BindingRadTreeView(RadTreeView1, ddlLanguage.SelectedValue, "news", "cot2");
        MenuUserUtils.BindingRadTreeView(RadTreeView2, ddlLanguage.SelectedValue, "news", "cot3");
        tvMenuUser.ExpandAllNodes();
        RadTreeView1.ExpandAllNodes();
        RadTreeView2.ExpandAllNodes();

        PositionWithPriorityAdd();
        ddlTypeNews.Items.Clear();
        BicXML.BindDropDownListFromXML(ddlTintieudiem, "~/admin/XMLData/Tintieudiem.xml");
        BicXML.BindDropDownListFromXML(ddlTypeNews, "~/admin/XMLData/ModelNews.xml");
        //ArticleBiz.PositionWithPriorityEdit(ddlPosition);
        if (_id != 0)
        {
            LoadDataFromEntity();
        }
        RelatedArticle1.Lang = ddlLanguage.SelectedValue;
    }

    private void LoadDataFromEntity()
    {
        var articleEntity = ArticleBiz.GetArticleByID(_id);
        if (articleEntity == null) return;
        txtTitle.Text = BicConvert.ToString(articleEntity.Title);
        reBriefDescription.Content = BicConvert.ToString(articleEntity.BriefDescription);
        reBody.Content = BicConvert.ToString(articleEntity.Body);
        isImageId.ImageID = BicConvert.ToString(articleEntity.ImageID);
        isVideoID.VideoID = BicConvert.ToString(articleEntity.VideoID);
        
        //txtSource.Text = BicConvert.ToString(articleEntity.Source);
        if (!string.IsNullOrEmpty(articleEntity.Source))
        {
            pnLeader.Visible = true;
            chkIsLeader.Checked = true;
            txtVocative.Text = articleEntity.Source;
            //ddlVocative.SelectedValue = articleEntity.Source;
        }
        

        txtViewCount.Text = BicConvert.ToString(articleEntity.ViewCount);
        txtLink.Text = BicConvert.ToString(articleEntity.Link);
        txtAllowUser.Text = BicConvert.ToString(articleEntity.AllowUsers);
        chkCommentEnable.Checked = BicConvert.ToBoolean(articleEntity.CommentsEnabled);
        //chkHome.Checked = BicConvert.ToBoolean(articleEntity.IsHome);
        //RelatedArticle1.MenuUserId = 0 + MenuUserBiz.GetCheckedNodes(tvMenuUser);
        RelatedArticle1.RelatedArticleId = articleEntity.TinLienQuan;
        
        //ismImageId.ImageIDArray = articleEntity.ImageArray;
        ismImageId.ImageIDArray = articleEntity.TinLienQuan;

        txtPosition.Text = articleEntity.ImageArray;
        txtFullName.Text = articleEntity.VideoArray;

        ddlTypeNews.SelectedValue = "1";
        chkNew.Checked = BicConvert.ToBoolean(articleEntity.IsNew);
        chkIsActive.Checked = BicConvert.ToBoolean(articleEntity.IsActive);
        ddlLanguage.SelectedValue = articleEntity.LanguageKey;
        cbTarget.SelectedValue = articleEntity.Target;
        txtVote.Text = articleEntity.VoteCount.ToString();
        txtPageTitle.Text = articleEntity.PageTitle;
        txtSeoTitle.Text = articleEntity.SeoTitle;
        
        //chkIsFull.Checked = articleEntity.IsFull;
        chkIsShowToolbar.Checked = BicConvert.ToBoolean(articleEntity.IsFull);
        

        txtTag.Text = articleEntity.Tag;
        
        ddlTintieudiem.SelectedValue = articleEntity.TinTieuDiem.ToString();
        chkIsShowTitle.Checked = articleEntity.TinTieuDiem == 1;


        txtMetaDescription.Text = articleEntity.MetaDescription;
        txtMetaKeyword.Text = articleEntity.MetaKeyWord;
       
    }

    private ArticleEntity LoadDataToEntity()
    {
        var articleEntity = new ArticleEntity
                                {
                                    Title = txtTitle.Text,
                                    VoteCount = BicConvert.ToInt32(txtVote.Text),
                                    LanguageKey = ddlLanguage.SelectedValue,
                                    BriefDescription = Server.HtmlDecode(reBriefDescription.Content),
                                    Body = Server.HtmlDecode(reBody.Content),
                                    CreatedDate = DateTime.Now,
                                    MenuUserID = "," + BicString.Trim(hdTreeMenu.Value.Replace(",,", ",")) + ",",
                                    CommentsEnabled = chkCommentEnable.Checked,
                                    IsHome = chkIsHome.Checked,
                                    IsActive = chkIsActive.Checked,
                                    IsNew = chkNew.Checked,
                                    ImageID = BicConvert.ToInt32(isImageId.ImageID),
                                    Priority = BicConvert.ToInt32(ntxPosition.Text),
                                    Target = cbTarget.SelectedValue,

                                    //Source = txtSource.Text,
                                    Source = pnLeader.Visible?txtVocative.Text:"",

                                    Link = txtLink.Text,
                                    CreatedBy = HttpContext.Current.User.Identity.Name,
                                    ModifiedBy = HttpContext.Current.User.Identity.Name,
                                    AllowUsers = txtAllowUser.Text,
                                    ViewCount = BicConvert.ToInt32(txtViewCount.Text),
                                    PageTitle = txtPageTitle.Text,
                                    SeoTitle = txtSeoTitle.Text,
                                    Tag = txtTag.Text,
                                    //TinTieuDiem = BicConvert.ToInt32(ddlTintieudiem.SelectedValue),
                                    TinTieuDiem = chkIsShowTitle.Checked?1:0,

                                    //TinLienQuan = RelatedArticle1.RelatedArticleId,
                                    TinLienQuan = ismImageId.ImageIDArray,

                                    //ImageArray = ismImageId.ImageIDArray,
                                    ImageArray = txtPosition.Text,

                                    TypeOfControl = 1,
                                    VideoID = BicConvert.ToInt32(isVideoID.VideoID),

                                    //VideoArray = string.Empty,
                                    VideoArray = txtFullName.Text,

                                    MetaDescription = txtMetaDescription.Text,
                                    MetaKeyWord = txtMetaKeyword.Text,
                                    //IsFull = chkIsFull.Checked,
                                    IsFull = chkIsShowToolbar.Checked
                                };
        return articleEntity;
    }

    protected void Save(object sender, CommandEventArgs e)
    {
        try
        {
            switch (e.CommandName)
            {
                case "AddNew":
                    if (tvMenuUser.CheckedNodes.Count == 0 && RadTreeView1.CheckedNodes.Count == 0 &&
                        RadTreeView2.CheckedNodes.Count == 0)
                    {
                        BicAjax.Alert(string.Format(BicResource.GetValue("Admin", "Admin_Article_Message4")));
                    }
                    else
                    {
                        var article = LoadDataToEntity();
                        ArticleBiz.InsertArticle(article);
                        SaveTags(article.Tag, article.ArticleID);
                        BicAdmin.NavigateToList();
                    }
                    break;
            }
        }
        catch (Exception ex)
        {
            LogEvent.LogToFile(ex.Message);
        }
    }

    protected void ddlLanguage_SelectedIndexChanged(object o, EventArgs e)
    {
        BicSession.SetValue("ArticleLanguage", ddlLanguage.SelectedValue);
        MenuUserUtils.BindingRadTreeView(tvMenuUser, ddlLanguage.SelectedValue, "news", "cot1");
        MenuUserUtils.BindingRadTreeView(RadTreeView1, ddlLanguage.SelectedValue, "news", "cot2");
        MenuUserUtils.BindingRadTreeView(RadTreeView2, ddlLanguage.SelectedValue, "news", "cot3");
        RelatedArticle1.Lang = ddlLanguage.SelectedValue;
    }


    private static void SaveTags(string tags, int ID)
    {
        var arrTag = tags.Split(new[] { ',', ';' }, StringSplitOptions.RemoveEmptyEntries);
        foreach (var item in arrTag)
        {
            var tag = TagBiz.GetTagByKey(item.Trim().ToLower(), 1);
            if (tag != null)
            {
                tag.Id += ID + ",";
                TagBiz.UpdateTag(tag);
            }
            else
            {
                tag = new TagEntity
                          {
                              Id = "," + ID + ",",
                              Keyword = item.Trim().ToLower(),
                              IsActive = true,
                              Priority = 1,
                              TypeID = 1,
                          };
                TagBiz.InsertTag(tag);
            }
        }
    }
    private string AddContent()
    {
        var sb = new StringBuilder();
        sb.Append("<div style='width: 795px;background: url(/Styles/img/sd_history.png) no-repeat left top;margin-top:-10px;height: 75px;padding-top: 23px'>"
                  + "<div style='width: 150px;float: left;margin-right: 55px;height: 100%;color:#3caed6;font-size:22px'>"
                  + "</div>"
                  + "<div style='width: 588px;float: left;height: 100%'>"
                  + "</div>"
                  + "</div>");
        return sb.ToString();
    }
    protected void ChkHistoryCheckedChanged(object sender, EventArgs e)
    {
        if (chkHistory.Checked)
        {
            btnAddRow.Visible = true;
            reBody.Content += AddContent();
        }
        else
        {
            btnAddRow.Visible = false;
            reBody.Content = string.Empty;
        }

    }
    protected void BtnAddRowClick(object sender, EventArgs e)
    {
        reBody.Content += AddContent();
    }
    protected void ChkIsLeaderCheckedChanged(object sender, EventArgs e)
    {
        if (chkIsLeader.Checked)
        {
            pnLeader.Visible = true;
        }
        else
        {
            pnLeader.Visible = false;
        }

    }
    
  
}