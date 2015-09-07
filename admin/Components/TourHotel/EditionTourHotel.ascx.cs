using System;
using System.Web.UI.WebControls;
using BIC.Biz;
using BIC.Data;
using BIC.Entity;
using BIC.Utils;
using BIC.WebControls;

public partial class Admin_Components_TourHotel_EditionTourHotel : BaseUserControl
{
	protected int Id;

	protected void Page_Load(object sender, EventArgs e)
	{
		Id = BicHtml.GetRequestString("id", 0);
		if (!IsPostBack)
		{
			tvMenuUser.WebServiceSettings.Method = "GetNodesTours";
			tvMenuUser.WebServiceSettings.Path = BicApplication.URLRoot + "Webservice/MenuService.asmx";
			chkIsActive.Enabled = Approved;
            PositionWithPriorityAdd(ddlPosition);
			LoadDataFromEntity();
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
	private void LoadDataFromEntity()
	{
		TourHotelEntity tourhotelEntity = TourHotelBiz.GetTourHotelByID(Id);
		if (tourhotelEntity != null)
		{
		    BindingCity();
			ddlLanguage.SelectedValue = tourhotelEntity.LanguageKey;
			txtTenKhachSan.Text = BicConvert.ToString(tourhotelEntity.TenKhachSan);
            MenuUserUtils.BindingRadTreeView(tvMenuUser, ddlLanguage.SelectedValue, "des");
			MenuUserBiz.SetCheckedNodes(tvMenuUser, tourhotelEntity.ThanhPho);
			radRating.Value = BicConvert.ToInt32(tourhotelEntity.Hang);
			ddlKieu.SelectedValue = tourhotelEntity.Kieu;
			ddlKieu.Text = tourhotelEntity.Kieu;
			reMoTaChiTiet.Content = BicConvert.ToString(tourhotelEntity.MoTaChiTiet);
			ddlPosition.SelectedValue = tourhotelEntity.Priority.ToString();
			chkIsActive.Checked = BicConvert.ToBoolean(tourhotelEntity.IsActive);
			isImageId.ImageID = BicConvert.ToString(tourhotelEntity.ImageId);
			ismAnhKhachSan.ImageIDArray = BicConvert.ToString(tourhotelEntity.AnhKhachSan);
			txtLuotXem.Text = BicConvert.ToString(tourhotelEntity.LuotXem);
			txtDiachi.Text = BicConvert.ToString(tourhotelEntity.Diachi);
			txtSoDienThoai.Text = BicConvert.ToString(tourhotelEntity.SoDienThoai);
			txtWebsite.Text = BicConvert.ToString(tourhotelEntity.Website);
			txtEmail.Text = BicConvert.ToString(tourhotelEntity.Email);
			ddlTinh.SelectedValue = BicConvert.ToString(tourhotelEntity.Price);
            BindingDistrict(BicConvert.ToInt32(ddlTinh.SelectedValue));
			reGiaChiTiet.Content = BicConvert.ToString(tourhotelEntity.GiaChiTiet);
			ddlQuan.SelectedValue = BicConvert.ToString(tourhotelEntity.GiaTu);
            //reRoom.Content = BicConvert.ToString(tourhotelEntity.Room);
			reThietBiPhong.Content = BicConvert.ToString(tourhotelEntity.ThietBiPhong);                         
            txtSeoTitle.Text = tourhotelEntity.SEOTitle;
            txtTag.Text = BicConvert.ToString(tourhotelEntity.Tag);
            string coordinate = tourhotelEntity.Room;
            if (coordinate != string.Empty && coordinate != null)
            {
                var coordinateArr = coordinate.Split(',');
                if (coordinateArr.Length == 2)
                {
                    Maps2.PosX = coordinateArr[0].ToString().Trim();
                    Maps2.PosY = coordinateArr[1].ToString().Trim();
                    Maps2.Address = string.IsNullOrEmpty(tourhotelEntity.Diachi) ? tourhotelEntity.TenKhachSan : tourhotelEntity.Diachi;
                }
            }
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
	private TourHotelEntity LoadDataToEntity()
	{
		TourHotelEntity tourhotelEntity = new TourHotelEntity();
		tourhotelEntity.TourHotelID = Id;

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
		tourhotelEntity.Website = BicConvert.ToString(txtWebsite.Text);
		tourhotelEntity.Email = BicConvert.ToString(txtEmail.Text);
		tourhotelEntity.Price = BicConvert.ToString(ddlTinh.SelectedValue);
		tourhotelEntity.GiaChiTiet = BicConvert.ToString(reGiaChiTiet.Content);
		tourhotelEntity.GiaTu = BicConvert.ToDouble(ddlQuan.SelectedValue);
        tourhotelEntity.Room = BicConvert.ToString(txtVitribando.Text).Replace("(", "").Replace(")", "");
		tourhotelEntity.ThietBiPhong = BicConvert.ToString(reThietBiPhong.Content);
        tourhotelEntity.Tag = BicConvert.ToString(txtTag.Text);
        tourhotelEntity.SEOTitle = BicConvert.ToString(txtSeoTitle.Text);
		return tourhotelEntity;
	}

	protected void Save(object sender, CommandEventArgs e)
	{
		try
		{
			if (e.CommandName == "Update")
			{
				if (tvMenuUser.CheckedNodes.Count == 0)
				{
					BicAjax.Alert("Bạn phải chọn ít nhất một danh mục.");
				}
				else
				{
					TourHotelBiz.UpdateTourHotel(LoadDataToEntity());
					BicAdmin.NavigateToList();
				}
			}
		}
		catch (Exception ex)
		{
			BicAjax.Alert(ex.Message);
		}
	}
}