﻿using System;
using System.Data;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using BIC.Biz;
using BIC.Data;
using BIC.Entity;
using BIC.Utils;
using BIC.WebControls;
using Telerik.Web.UI;

public partial class Admin_Components_TourHotel_ListingTourHotel : BaseUserControl
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            MenuUserUtils.BindingRadTreeView(tvMenuUser, ddlLanguage.SelectedValue, "des");
            radMenuContext.LoadContentFile("~/admin/XMLData/Grid/Edit_View_Delete_Move.xml");
            radMenuContext.Items[2].Attributes.Add("onclick",
                                                    string.Format("var as;as=confirm('{0}');document.getElementById('confirmdelete').value = as;", BicMessage.Delete));
        }
    }

    private void GetDataSource()
    {
        var bicData = new BicGetData
        {
            TableName = "TourHotel"
        };

        bicData.Sorting.Add(new SortingItem("Priority", false));
        bicData.Selecting.Add(TourHotelEntity.FIELD_TOURHOTELID);
        bicData.Selecting.Add(TourHotelEntity.FIELD_TENKHACHSAN);
        bicData.Selecting.Add(TourHotelEntity.FIELD_PRIORITY);
        bicData.Selecting.Add(TourHotelEntity.FIELD_ISACTIVE);
        bicData.Selecting.Add(TourHotelEntity.FIELD_LUOTXEM);
        bicData.Selecting.Add(string.Format("dbo.MenuUserIdToNames({0}) as Nhom", TourHotelEntity.FIELD_THANHPHO));
        bicData.Conditioning.Add(new ConditioningItem("LanguageKey", ddlLanguage.SelectedValue, Operator.EQUAL, CompareType.STRING));
        if (txtSearch.Text != String.Empty)
            bicData.Conditioning.Add(new ConditioningItem(TourHotelEntity.FIELD_TENKHACHSAN, "%" + BicConvert.ToString(txtSearch.Text) + "%", Operator.LIKE, CompareType.STRING));
        if (tvMenuUser.CheckedNodes.Count > 0)
        {
            var ciMenuUser = new ConditioningItem
            {
                TypeOfCondition = TypeOfCondition.QUERY,
                Query = string.Format("convert(int,(select * from dbo.ListIsExist(ThanhPho,'{0}'))) > 0",
                                     MenuUserBiz.GetCheckedNodes(tvMenuUser))
            };

            bicData.Conditioning.Add(ciMenuUser);
        }
        if (ddlIsActive.SelectedValue != "2")
            bicData.Conditioning.Add(new ConditioningItem("IsActive", ddlIsActive.SelectedValue, Operator.EQUAL, CompareType.NUMERIC));
        DataTable data = bicData.GetAllData();
        rgManager.VirtualItemCount = bicData.TotalItems;
        rgManager.DataSource = data;
    }

    protected void txtSearch_TextChanged(object sender, EventArgs e)
    {
        GetDataSource();
        rgManager.DataBind();
    }

    protected void btnSearch_Click(object sender, EventArgs e)
    {
        GetDataSource();
        rgManager.DataBind();
    }

    protected void rgManager_DeleteCommand(object source, GridCommandEventArgs e)
    {
        var id = BicConvert.ToInt32(e.Item.OwnerTableView.DataKeyValues[e.Item.ItemIndex]["TourHotelID"]);
        TourHotelBiz.DeleteTourHotel(id);
        GetDataSource();
        rgManager.DataBind();
    }

    protected void rgManager_NeedDataSource(object source, GridNeedDataSourceEventArgs e)
    {
        GetDataSource();
    }

    protected void rgManager_ItemDataBound(object sender, GridItemEventArgs e)
    {
        var ddlCurrentPosition = (DropDownList)e.Item.FindControl("ddlCurrentPosition");
        var drv = (DataRowView)e.Item.DataItem; if (drv == null) return;
        //if (ddlCurrentPosition != null) { TourHotelBiz.PositionWithPriorityEdit(ddlCurrentPosition); ddlCurrentPosition.SelectedValue = BicConvert.ToString(drv["Priority"]); }
        var ibtnIsActive = (ImageButton)e.Item.FindControl("ibtnIsActive");
        if (ibtnIsActive != null) ibtnIsActive.Enabled = Approved;
    }

    protected void radMenuContext_ItemClick(object sender, RadMenuEventArgs e)
    {
        var index = Convert.ToInt32(Request.Form["radGridClickedRowIndex"]);
        var id = Convert.ToInt32(rgManager.Items[index].GetDataKeyValue("TourHotelID"));
        var tourhotelEntity = TourHotelBiz.GetTourHotelByID(id);
        switch (e.Item.Value)
        {
            case "Add":
                BicAdmin.NavigateToAdd();
                break;
            case "View":
                BicAdmin.NavigateToView(id.ToString());
                break;
            case "Delete":
                if (Deleted && tourhotelEntity.IsActive && Approved == false)
                    BicAjax.Alert("Bạn không có quyền xóa bản ghi đã duyệt.");
                else
                    if (Deleted)
                    {
                        var confirm = Convert.ToBoolean(Request.Form["confirmdelete"]);
                        if (confirm)
                        {
                            TourHotelBiz.DeleteTourHotel(id);
                            GetDataSource();
                            rgManager.DataBind();
                        }
                    }
                    else
                        if (Deleted == false)
                            BicAjax.Alert(BicMessage.DenyDelete);
                break;
            case "Edit":
                if (Edited && tourhotelEntity.IsActive && Approved == false)
                    BicAjax.Alert("Bạn không có quyền sửa bản ghi đã duyệt");
                else
                    if (Edited)
                    {
                        BicAdmin.NavigateToEdit(id.ToString());
                    }
                    else
                        if (Edited == false)
                            BicAjax.Alert(BicMessage.DenyEdit);
                break;
        }
    }

    protected void ddlLanguage_SelectedIndexChanged(object o, EventArgs e)
    {
        MenuUserUtils.BindingRadTreeView(tvMenuUser, ddlLanguage.SelectedValue, "hotels");
        GetDataSource();
        rgManager.DataBind();
    }

    protected void rgManager_ItemCommand(object source, GridCommandEventArgs e)
    {
        switch (e.CommandName)
        {
            case "Change":
                var dhChange = new DataHelper();
                dhChange.ChangePosition(
                    BicConvert.ToInt32(e.Item.OwnerTableView.DataKeyValues[e.Item.ItemIndex]["TourHotelID"]), "TourHotelID",
                    BicConvert.ToInt32(((DropDownList)e.Item.FindControl("ddlCurrentPosition")).SelectedItem.Text),
                    "TourHotel");
                GetDataSource();
                rgManager.DataBind();
                break;
            case "IsActive":
                if (BicRadGrid.ExecuteBooleanCommand(e, e.CommandName, "TourHotelId", e.Item.OwnerTableView.DataKeyValues[e.Item.ItemIndex]["TourHotelID"].ToString(), "TourHotel"))
                    GetDataSource();
                else
                    e.Canceled = true;
                rgManager.DataBind();
                break;
        }
    }

    public string GetCheckId()
    {
        try
        {
            CheckBox checkBox = null;
            string output = string.Empty;
            foreach (GridDataItem item in rgManager.Items)
            {
                TableCell cell = item["column"];
                checkBox = (CheckBox)cell.FindControl("column");
                if (checkBox.Checked)
                {
                    output += item.GetDataKeyValue("TourHotelID") + ",";
                }
            }
            return output.Substring(0, output.Length - 1);
        }
        catch (Exception)
        {
            return string.Empty;
        }
    }

    protected void tvMenuUser_NodeExpand(object sender, Telerik.Web.UI.RadTreeNodeEventArgs e)
    {
        DataTable dt = MenuUserBiz.GetMenuUserByTypeOfControl(BicConvert.ToInt32(e.Node.Value), "hotels");
        foreach (DataRow entity in dt.Rows)
        {
            var node = new RadTreeNode();
            node.Value = entity["MenuUserId"].ToString();
            node.Text = entity["Name"].ToString();
            node.Enabled = BicConvert.ToBoolean(entity["EnableCheck"]);
            if (BicConvert.ToInt32(entity["ChildrenCount"]) > 0)
            {
                node.ExpandMode = TreeNodeExpandMode.ServerSideCallBack;
            }
            e.Node.Nodes.Add(node);
        }
    }

    protected void tvMenuUser_NodeCheck(object sender, RadTreeNodeEventArgs e)
    {
        GetDataSource();
        rgManager.DataBind();
    }
}