using System;
using System.Collections;
using System.Collections.Generic;
using System.Web;
using System.Web.UI.WebControls;
using BIC.Biz;
using BIC.Data;
using BIC.Entity;
using BIC.Handler;
using BIC.Utils;
using BIC.WebControls;
using Telerik.Web.UI;

public partial class Admin_Components_Product_AdditionProduct : BaseUserControl
{
    private int _id;

    public void PositionWithPriorityAdd()
    {
        try
        {
            var dh = new DataHelper();
            int maxPosition = BicConvert.ToInt32(dh.CountItem("ProductId", "Product"));
            if (maxPosition < 1)
                maxPosition = 1;
            ntxPosition.MaxValue = maxPosition;
        }
        catch (Exception ex)
        {
            LogEvent.LogToFile(ex.ToString());
        }
    }

    public void RemoveCache()
    {
        var keyList = new List<string>();
        IDictionaryEnumerator cacheEnum = HttpContext.Current.Cache.GetEnumerator();
        while (cacheEnum.MoveNext())
        {
            keyList.Add(cacheEnum.Key.ToString());
        }
        foreach (string key in keyList)
        {
            HttpContext.Current.Cache.Remove(key);
        }

    }

    protected void Page_Load(object sender, EventArgs e)
    {
        _id = BicHtml.GetRequestString("id", 0);
        chkIsActive.Enabled = Approved;
        if (BicSession.ToString("ProductLanguage") != string.Empty)
            ddlLanguage.SelectedValue = BicSession.ToString("ProductLanguage");
        MenuUserUtils.BindingRadTreeView(tvMenuUser, ddlLanguage.SelectedValue, "products", "cot1");
        MenuUserUtils.BindingRadTreeView(RadTreeView1, ddlLanguage.SelectedValue, "products", "cot2");
        MenuUserUtils.BindingRadTreeView(RadTreeView2, ddlLanguage.SelectedValue, "products", "cot3");
        tvMenuUser.ExpandAllNodes();
        RadTreeView1.ExpandAllNodes();
        RadTreeView2.ExpandAllNodes();
        PositionWithPriorityAdd();
        ddlTypeproducts.Items.Clear();
        if (!IsPostBack)
        {
            chkIsActive.Enabled = Approved;
            BicXML.BindDropDownListFromXML(ddlTintieudiem, "~/admin/XMLData/Tintieudiem.xml");
            BicXML.BindDropDownListFromXML(ddlTypeproducts, "~/admin/XMLData/Modelproducts.xml");
            //ProductBiz.PositionWithPriorityEdit(ddlPosition);
            if (_id != 0)
            {
                LoadDataFromEntity();
            }
        }
        RelatedProduct1.Lang = RelatedArticle.Lang = ddlLanguage.SelectedValue;
    }

    private void LoadDataFromEntity()
    {
        BizObject.PurgeCacheItems("IDProduct_Product_" + _id); //clear cache bài viết trước khi lấy dữ liệu ra
        ProductEntity productEntity = ProductBiz.GetProductByID(_id);
        if (productEntity == null) return;
        txtTitle.Text = BicConvert.ToString(productEntity.Title);
        reBriefDescription.Content = BicConvert.ToString(productEntity.BriefDescription);
        reBody.Content = BicConvert.ToString(productEntity.Body);
        isImageId.ImageID = BicConvert.ToString(productEntity.ImageID);
        isVideoID.VideoID = BicConvert.ToString(productEntity.VideoID);
        //txtSource.Text = BicConvert.ToString(productEntity.Source);
        txtViewCount.Text = BicConvert.ToString(productEntity.ViewCount);
        txtLink.Text = BicConvert.ToString(productEntity.Link);
        txtApsuat.Text = BicConvert.ToString(productEntity.AllowUsers);
        chkCommentEnable.Checked = BicConvert.ToBoolean(productEntity.CommentsEnabled);
        //chkHome.Checked = BicConvert.ToBoolean(productEntity.IsHome);
        //RelatedProduct1.MenuUserId = 0 + MenuUserBiz.GetCheckedNodes(tvMenuUser);
        txtCongSuat.Text = productEntity.TinLienQuan;
        txtHieuDienThe.Text = productEntity.SanPhamLienQuan;
        ismImageId.ImageIDArray = productEntity.ImageArray;
        ddlTypeproducts.SelectedValue = productEntity.TypeOfControl.ToString();
        chkNew.Checked = BicConvert.ToBoolean(productEntity.IsNew);
        chkIsActive.Checked = BicConvert.ToBoolean(productEntity.IsActive);
        ddlLanguage.SelectedValue = productEntity.LanguageKey;
        cbTarget.SelectedValue = productEntity.Target;
        txtVote.Text = productEntity.VoteCount.ToString();
        txtPageTitle.Text = productEntity.PageTitle;
        txtSeoTitle.Text = productEntity.SeoTitle;
        chkIsFull.Checked = productEntity.IsFull;
        txtTag.Text = productEntity.Tag;
        txtTieuChuan.Text = productEntity.SaleOff;
        ddlTintieudiem.SelectedValue = productEntity.TinTieuDiem.ToString();
        txtMetaDescription.Text = productEntity.MetaDescription;
        txtMetaKeyword.Text = productEntity.MetaKeyWord;
        txtDongDienDinhMuc.Text = productEntity.ImageArray2;
        //Thuộc tính sản phẩm
        txtCode.Text = productEntity.Code;
        txtPrice1.Text = productEntity.Price;
        txtPriceOnline.Text = productEntity.OldPrice;
        chkOutOfStock.Checked = BicConvert.ToBoolean(productEntity.OutOfStock);
        txtManufactory.Text = productEntity.Manufactory;
        txtDuongVienCoAo.Text = productEntity.Source;
        txtDongNganMach.Text = productEntity.VideoArray;
        reThongso.Content = BicConvert.ToString(productEntity.NewColumn1);
        txtThanhPhan.Text = productEntity.NewColumn2;
        txtThuongHieu.Text = productEntity.NewColumn3;
        txtTheLoai.Text = productEntity.NewColumn4;
        reBanve.Content = BicConvert.ToString(productEntity.NewColumn5);
        rePhamvi.Content = BicConvert.ToString(productEntity.NewColumn6);


        MenuUserUtils.BindingRadTreeView(tvMenuUser, ddlLanguage.SelectedValue, "products", "cot1");
        MenuUserUtils.BindingRadTreeView(RadTreeView1, ddlLanguage.SelectedValue, "products", "cot2");
        MenuUserUtils.BindingRadTreeView(RadTreeView2, ddlLanguage.SelectedValue, "products", "cot3");
        tvMenuUser.ExpandAllNodes();
        RadTreeView1.ExpandAllNodes();
        RadTreeView2.ExpandAllNodes();
        

        reBody.CssFiles.Add(productEntity.IsFull
                                ? new EditorCssFile("~/BICSkins/BICCMS/Editor/EditorContentAreaStylesFull.css")
                                : new EditorCssFile("~/BICSkins/BICCMS/Editor/EditorContentAreaStyles.css"));
    }

    private ProductEntity LoadDataToEntity()
    {
        var productEntity = new ProductEntity();
        productEntity.Title = txtTitle.Text;
        productEntity.VoteCount = BicConvert.ToInt32(txtVote.Text);
        productEntity.LanguageKey = ddlLanguage.SelectedValue;
        productEntity.BriefDescription = Server.HtmlDecode(reBriefDescription.Content);
        productEntity.Body = Server.HtmlDecode(reBody.Content);
        productEntity.CreatedDate = DateTime.Now;
        productEntity.MenuUserID = "," + BicString.Trim(hdTreeMenu.Value.Replace(",,", ",")) + ",";
        productEntity.CommentsEnabled = chkCommentEnable.Checked;
        productEntity.IsHome = chkIsHome.Checked;
        productEntity.IsActive = chkIsActive.Checked;
        productEntity.IsNew = chkNew.Checked;
        productEntity.ImageID = BicConvert.ToInt32(isImageId.ImageID);
        productEntity.Priority = BicConvert.ToInt32(ntxPosition.Text);
        productEntity.Target = cbTarget.SelectedValue;
        productEntity.Link = txtLink.Text;
        productEntity.CreatedBy = HttpContext.Current.User.Identity.Name;
        productEntity.ModifiedBy = HttpContext.Current.User.Identity.Name;
        productEntity.AllowUsers = txtApsuat.Text;
        productEntity.ViewCount = BicConvert.ToInt32(txtViewCount.Text);
        productEntity.PageTitle = txtPageTitle.Text;
        productEntity.SeoTitle = txtSeoTitle.Text;
        productEntity.Tag = txtTag.Text;
        productEntity.TinTieuDiem = BicConvert.ToInt32(ddlTintieudiem.SelectedValue);
        productEntity.TinLienQuan = txtCongSuat.Text;
        productEntity.SanPhamLienQuan = txtHieuDienThe.Text;
        productEntity.ImageArray = ismImageId.ImageIDArray;
        productEntity.TypeOfControl = BicConvert.ToInt32(ddlTypeproducts.SelectedValue);
        productEntity.VideoID = BicConvert.ToInt32(isVideoID.VideoID);
        productEntity.VideoArray = txtDongNganMach.Text;
        productEntity.MetaDescription = txtMetaDescription.Text;
        productEntity.MetaKeyWord = txtMetaKeyword.Text;
        productEntity.IsFull = chkIsFull.Checked;
        productEntity.ImageArray2 = txtDongDienDinhMuc.Text;
        //Thuộc tính
        productEntity.Code = txtCode.Text;
        productEntity.Price = txtPrice1.Text;
        productEntity.OldPrice = txtPriceOnline.Text;
        productEntity.OutOfStock = chkOutOfStock.Checked;
        productEntity.SaleOff = txtTieuChuan.Text;
        productEntity.Manufactory = txtManufactory.Text;
        productEntity.Source = txtDuongVienCoAo.Text;
        //thuộc tính mới
        productEntity.NewColumn1 = Server.HtmlDecode(reThongso.Content);
        productEntity.NewColumn2 = txtThanhPhan.Text;
        productEntity.NewColumn3 = txtThuongHieu.Text;
        productEntity.NewColumn4 = txtTheLoai.Text;
        productEntity.NewColumn5 = Server.HtmlDecode(reBanve.Content);
        productEntity.NewColumn6 = Server.HtmlDecode(rePhamvi.Content);

       
        return productEntity;
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
                        BicAjax.Alert(string.Format(BicResource.GetValue("Admin", "Admin_Product_Message1")));
                    }
                    else
                    {
                        ProductEntity product = LoadDataToEntity();
                        ProductBiz.InsertProduct(product);

                        SaveTags(product.Tag, product.ProductID);
                        RemoveCache();

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
        BicSession.SetValue("ProductLanguage", ddlLanguage.SelectedValue);
        MenuUserUtils.BindingRadTreeView(tvMenuUser, ddlLanguage.SelectedValue, "products", "cot1");
        MenuUserUtils.BindingRadTreeView(RadTreeView1, ddlLanguage.SelectedValue, "products", "cot2");
        MenuUserUtils.BindingRadTreeView(RadTreeView2, ddlLanguage.SelectedValue, "products", "cot3");
        RelatedProduct1.Lang = RelatedArticle.Lang = ddlLanguage.SelectedValue;
    }

    protected void tvMenuUser_OnNodeCheck(object sender, RadTreeNodeEventArgs e)
    {
        RelatedProduct1.MenuUserId = 0 + MenuUserBiz.GetCheckedNodes(tvMenuUser);
        RelatedProduct1.GetValue();
    }

    private void SaveTags(string tags, int ID)
    {
        string[] arrTag = tags.Split(new[] { ',', ';' }, StringSplitOptions.RemoveEmptyEntries);
        foreach (string item in arrTag)
        {
            TagEntity tag = TagBiz.GetTagByKey(item.Trim().ToLower(), 1);
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
}