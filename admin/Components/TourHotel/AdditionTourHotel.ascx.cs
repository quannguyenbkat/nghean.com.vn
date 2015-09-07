using System;
using System.Data;
using System.Web.UI.WebControls;
using BIC.Biz;
using BIC.Data;
using BIC.Entity;
using BIC.Utils;
using BIC.WebControls;
using Telerik.Web.UI;

public partial class Admin_Components_TourHotel_AdditionTourHotel : BaseUserControl
{
	protected void Page_Load(object sender, EventArgs e)
	{
		if (!IsPostBack)
		{
			//tvMenuUser.WebServiceSettings.Method = "GetNodesTourHotel";
			//tvMenuUser.WebServiceSettings.Path = BicApplication.URLRoot + "Webservice/MenuService.asmx";
            PositionWithPriorityAdd(ddlPosition);

            BindingCity();
			if (string.IsNullOrEmpty(BicSession.ToString("HotelsLanguage")))
				ddlLanguage.SelectedValue = BicSession.ToString("HotelsLanguage");
			MenuUserUtils.BindingRadTreeView(tvMenuUser, ddlLanguage.SelectedValue, "des");
		}
	}
    protected void PositionWithPriorityAdd(DropDownList ddlPosition)
    {
        var dh = new DataHelper();
        var count = dh.ExecuteSQL("select Count(TourHotelId) as count from TourHotel");
        for (int i = 1; i <= BicConvert.ToInt32(count.Rows[0]["count"]) + 1; i++)
        {
            ddlPosition.Items.Add(new ListItem(i.ToString()));
        }
    }
    private void BindingCity()
    {
        var bicData = new BicGetData
        {
            TableName = "City"
        };
        bicData.Sorting.Add(new SortingItem("Priority", false));
        
        ddlTinh.DataSource = bicData.GetAllData();
        ddlTinh.DataTextField = "CityName";
        ddlTinh.DataValueField = "CityID";
        ddlTinh.DataBind();
        ddlTinh.Items.Insert(0, new ListItem("[ Chọn tỉnh thành ]", "0"));
    }
    protected void ddlThanhPho_SelectedIndexChanged(object o, EventArgs e)
    {
        txtDiachi.Text = "";
        ddlQuan.Items.Clear();
        BindingDistrict(BicConvert.ToInt32(ddlTinh.SelectedValue));
    }
    protected void ddlQuanHuyen_SelectedIndexChanged(object sender, EventArgs e)
    {
        txtDiachi.Text = ddlQuan.SelectedItem.Text + " - " + ddlTinh.SelectedItem.Text;
    }
    private void BindingDistrict(int cityID)
    {
        ddlQuan.DataSource = DistrictBiz.GetDistrictByCityID(cityID);
        ddlQuan.DataTextField = "DistrictName";
        ddlQuan.DataValueField = "DistrictID";
        ddlQuan.DataBind();
        ddlQuan.Items.Insert(0, new ListItem("[ Chọn quận huyện]", "0"));
    }
	private TourHotelEntity LoadDataToEntity()
	{
		var tourhotelEntity = new TourHotelEntity();
		tourhotelEntity.LanguageKey = ddlLanguage.SelectedValue;
		tourhotelEntity.TenKhachSan = BicConvert.ToString(txtTenKhachSan.Text);
		tourhotelEntity.ThanhPho = MenuUserBiz.GetCheckedNodes(tvMenuUser);
		tourhotelEntity.Hang = BicConvert.ToInt32(radRating.Value);
		tourhotelEntity.Kieu = BicConvert.ToString(ddlKieu.SelectedValue);
		tourhotelEntity.MoTaChiTiet = BicConvert.ToString(reMoTaChiTiet.Content);
		tourhotelEntity.Priority = BicConvert.ToInt32(ddlPosition.SelectedValue);
		tourhotelEntity.IsActive = chkIsActive.Checked;
		tourhotelEntity.ImageId = BicConvert.ToInt32(isImageId.ImageID);
		tourhotelEntity.AnhKhachSan = BicConvert.ToString(ismAnhKhachSan.ImageIDArray);
		tourhotelEntity.LuotXem = BicConvert.ToInt32(txtLuotXem.Text);
		tourhotelEntity.Diachi = BicConvert.ToString(txtDiachi.Text);
		tourhotelEntity.SoDienThoai = BicConvert.ToString(txtSoDienThoai.Text);
        tourhotelEntity.Room = BicConvert.ToString(txtVitribando.Text).Replace("(", "").Replace(")", "");
		tourhotelEntity.ThietBiPhong = BicConvert.ToString(reThietBiPhong.Content);
		tourhotelEntity.Website = BicConvert.ToString(txtWebsite.Text);
		tourhotelEntity.Email = BicConvert.ToString(txtEmail.Text);
        tourhotelEntity.Price = BicConvert.ToString(ddlTinh.SelectedValue);
		tourhotelEntity.GiaChiTiet = BicConvert.ToString(reGiaChiTiet.Content);
        tourhotelEntity.GiaTu = BicConvert.ToDouble(ddlQuan.SelectedValue);
        tourhotelEntity.Tag = BicConvert.ToString(txtTag.Text);
        tourhotelEntity.SEOTitle = BicConvert.ToString(txtSeoTitle.Text);
        
		return tourhotelEntity;
	}
    
	protected void Save(object sender, CommandEventArgs e)
	{
		try
		{
			switch (e.CommandName)
			{
				case "AddNew":
					if (tvMenuUser.CheckedNodes.Count == 0)
					{
						BicAjax.Alert("Bạn phải chọn ít nhất một danh mục.");
					}
					else
					{
						TourHotelBiz.InsertTourHotel(LoadDataToEntity());
						BicAdmin.NavigateToList();
					}
					break;
			}
		}
		catch (Exception ex)
		{
			BicAjax.Alert(ex.Message);
		}
	}

	protected void tvMenuUser_NodeExpand(object sender, Telerik.Web.UI.RadTreeNodeEventArgs e)
	{
		DataTable dt = MenuUserBiz.GetMenuUserByTypeOfControl(BicConvert.ToInt32(e.Node.Value), "des");
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
}