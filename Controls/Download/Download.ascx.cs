using System;
using System.Data;
using System.IO;
using System.Web.Security;
using System.Web.UI.WebControls;
using BIC.Biz;
using BIC.Data;
using BIC.Entity;
using BIC.Handler;
using BIC.Utils;
using BIC.WebControls;

public partial class Controls_Download_Download : BaseUIControl
{
    private string _groupOfUser;
    private string _menuUserID;
    private int _modeMenu;
    public int PageSize;

    protected void Page_Load(object sender, EventArgs e)
    {
        txtDownloadSearch.Attributes.Add("onkeypress", "return clickButton(event,'" + btnSearch.ClientID + "')");
        _modeMenu = 1;
        if (!IsPostBack)
        {
            //binding menu user (type of document)
            _menuUserID = BicRouting.GetRequestString("lv", "0");
            //MenuUserUtils.BuildMenuUserTree(ddlMenuUser, BicLanguage.CurrentLanguage, "55","");
            loadDropdowlist();
            //"1" value appropriated with Top Menu, view XMLData/ModelMenu.xml for more detail
            //if (_menuUserID != "0")
            //ddlDocumentTypeID.Language = "vi";
            //ddlDocumentTypeID.LoadData();
            //ddlMenuUser.SelectedValue = _menuUserID;
            //binding document list
            BindingDownloadList();

            //get current group of user
            _groupOfUser = "";
        }
    }
    private void loadDropdowlist()
    {
        var bicdata = new BicGetData { TableName = "MenuUser", PageSize = 100 };
        bicdata.Selecting.Add(MenuUserEntity.FIELD_MENUUSERID);
        bicdata.Selecting.Add(MenuUserEntity.FIELD_NAME);
        bicdata.Selecting.Add(MenuUserEntity.FIELD_PARENTID);
        bicdata.Selecting.Add(MenuUserEntity.FIELD_TYPEID);
        bicdata.Conditioning.Add(new ConditioningItem("LanguageKey", BicLanguage.CurrentLanguage, Operator.EQUAL, CompareType.STRING));
        bicdata.Conditioning.Add(new ConditioningItem("TypeID", "55", Operator.EQUAL, CompareType.STRING));
        DataTable dtTable = bicdata.GetAllData();
        BuildMenuUserDropDownList(dtTable, ddlMenuUser);
        ddlMenuUser.Items.Insert(0, new ListItem(BicLanguage.CurrentLanguage == "vi" ? "-- Nhóm tài liệu --" : "-- Categories --", "0"));
    }

   

    private void BindingDownloadList()
    {
        _menuUserID = BicRouting.GetRequestString("lv", "0");
        var bicData = new BicGetData
                          {
                              TableName = "Document",
                              PageSize = pager.PageSize = 10,
                              PageIndex = pager.PageIndex
                          };
        bicData.PageIndex = pager.PageIndex;
        if (pager.PageIndex > 0)
            PageSize = pager.PageSize * pager.PageIndex;
        bicData.Sorting.Add(new SortingItem("Priority", false));
        bicData.Selecting.Add(DocumentEntity.FIELD_DOCUMENTID);
        bicData.Selecting.Add(DocumentEntity.FIELD_DOCUMENTNO);
        bicData.Selecting.Add(DocumentEntity.FIELD_DISPLAYNAME);
        bicData.Selecting.Add(DocumentEntity.FIELD_NAME);
        bicData.Selecting.Add(DocumentEntity.FIELD_VIEWNO);
        bicData.Selecting.Add(DocumentEntity.FIELD_BRIEFDESCRIPTION);
        bicData.Selecting.Add(DocumentEntity.FIELD_USERNAMEVIEW);
        bicData.Selecting.Add(DocumentEntity.FIELD_ISNEW);

        bicData.Conditioning.Add(new ConditioningItem("UserNameView", BicLanguage.CurrentLanguage, Operator.EQUAL,
                                                          CompareType.STRING)); 
        if (txtDownloadSearch.Text != String.Empty)
        {
            string whereMenu =
                string.Format(
                    " (Name LIKE N'%{0}%') or (BriefDescription LIKE N'%{0}%') or (DisplayName LIKE N'%{0}%') or(DocumentID Like N'%{0}%') ",
                    txtDownloadSearch.Text.Trim());
            bicData.Conditioning.Add(new ConditioningItem
                                         {
                                             TypeOfCondition = TypeOfCondition.QUERY,
                                             Query = whereMenu,
                                             CombineCondition = CombineCondition.AND
                                         });
        }

        bicData.Conditioning.Add(new ConditioningItem("IsActive", "1", Operator.EQUAL, CompareType.NUMERIC));
        //bicData.Conditioning.Add(new ConditioningItem("DocumentTypeID", _menuUserID, Operator.EQUAL, CompareType.STRING));
        if (ddlMenuUser.SelectedValue != "0")
        {
            string listDocumentTypeID = ddlMenuUser.SelectedValue;
            bicData.Conditioning.Add(new ConditioningItem("DocumentTypeID", listDocumentTypeID, Operator.IN,
                                                          CompareType.STRING));
        }
        DataTable data = bicData.GetPagingData();

        pager.TotalItems = bicData.TotalItems;
        if (bicData.TotalItems <= pager.PageSize)
            divPage.Visible = false;
        if (txtDownloadSearch.Text != String.Empty)
        {
            lblSearch.Text = bicData.TotalItems > 0
                                 ? string.Format("Tìm thấy {0} kết quả với từ khóa <b>'{1}'</b>", bicData.TotalItems,
                                                 txtDownloadSearch.Text)
                                 : @"Không tìm thấy tài liệu nào.";
        }

        dlDownload.DataSource = data;
        dlDownload.DataBind();
    }

    protected void btnSearch_Click(object sender, EventArgs e)
    {
        BindingDownloadList();
        dlDownload.DataBind();
    }

    protected void pager_PageIndexChanged(object sender, PagerUIEventArgs e)
    {
        pager.PageIndex = e.NewPageIndex;
        BindingDownloadList();
        dlDownload.DataBind();
    }

    protected void ddlMenuUser_SelectedIndexChanged(object o, EventArgs e)
    {
        BindingDownloadList();
        dlDownload.DataBind();
    }

    protected void dlDownload_ItemCommand(object sender, ListViewCommandEventArgs e)
    {
        try
        {
            var btnDownload = e.Item.FindControl("btnDownload") as ImageButton;
            if (e.CommandName.Equals("Download"))
            {
                int documentID = Convert.ToInt32(e.CommandArgument);
                DocumentEntity docEntity = DocumentBiz.GetDocumentByID(documentID);

                string[] allowedViewingGroupList =
                    BicString.SplitComma(docEntity.UserNameView + ',' + docEntity.UserNameEdit);

                bool per = false;

                if (docEntity.UserNameView == String.Empty)
                {
                    string downloadURL = string.Format("~/FileUpload/Documents/{0}", docEntity.Name);

                    if (File.Exists(Server.MapPath(downloadURL)))
                    {
                        //update date number of downloaded
                        docEntity.ViewNo += 1;
                        DocumentBiz.UpdateDocument(docEntity);
                        Response.Redirect(downloadURL);
                    }
                    else
                        BicAjax.Alert(BicResource.GetValue("Message", "DOWNLOAD_FILE_REMOVED"));
                }
                else
                {
                    foreach (string t in allowedViewingGroupList)
                    {
                        if (Roles.RoleExists(t)
                                ? Roles.IsUserInRole(BicMemberShip.CurrentUserName, t)
                                : BicMemberShip.CurrentUserName.Equals(t))
                        {
                            per = true;
                        }
                    }
                    //if (BicMemberShip.CurrentUserName.Equals("administrator"))
                    //    per = true;
                    //if (per)
                    //{
                        string downloadURL = "~/FileUpload/Documents/" + docEntity.Name;

                        if (File.Exists(Server.MapPath(downloadURL)))
                        {
                            //update date number of downloaded
                            docEntity.ViewNo += 1;
                            DocumentBiz.UpdateDocument(docEntity);
                            Response.Redirect(downloadURL);
                        }
                        else
                            BicAjax.Alert(BicResource.GetValue("Message", "DOWNLOAD_FILE_REMOVED"));
                    //}
                    //else
                    //{
                    //    string path = String.Format("{0}{1}/login.html", BicApplication.URLRoot, Language);
                    //    Page.RegisterStartupScript("click",
                    //                               string.Format(
                    //                                   "<script type='text/javascript' language='javascript'>alert('Bạn không dủ quyền download tài liệu này. Mời bạn đang nhập.');window.location={0}</script>",
                    //                                   path));
                    //}
                }
            }
        }
        catch (Exception ex)
        {
            LogEvent.LogToFile(ex.ToString());
        }
    }
    public static void BuildMenuUserDropDownList(DataTable dt, DropDownList ddlMenuUser)
    {
        ddlMenuUser.Items.Clear();
        DataRow[] arrProductRow = dt.Select();
        foreach (DataRow dr in arrProductRow)
        {
            int iParentId = BicConvert.ToInt32(dr[MenuUserEntity.FIELD_PARENTID]);
            int iMenuUserId = BicConvert.ToInt32(dr[MenuUserEntity.FIELD_MENUUSERID]);

            //Khoi tao list Item
            var lt = new ListItem
            {
                Value = iMenuUserId.ToString(),
                Text = BicConvert.ToString(dr[MenuUserEntity.FIELD_NAME])
            };
            //Kiem tra xem item hien tai co phai la danh muc goc khong
            if (iParentId == 0)
            {
                lt.Text = BicConvert.ToString(dr[MenuUserEntity.FIELD_NAME]);
                ddlMenuUser.Items.Add(lt);
            }
            else
            {
                ListItem subLt =
                    ddlMenuUser.Items.FindByValue(BicConvert.ToString(dr[MenuUserEntity.FIELD_PARENTID]));
                if (subLt != null)
                {
                    ddlMenuUser.Items.Insert(ddlMenuUser.Items.IndexOf(subLt) + 1, lt);
                }
                else
                {
                    ddlMenuUser.Items.Add(lt);
                }
            }
        }

    }
}