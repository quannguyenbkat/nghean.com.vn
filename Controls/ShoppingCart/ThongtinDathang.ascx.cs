using System;
using System.Linq;
using System.Web.Security;
using System.Web.UI.WebControls;
using BIC.Biz;
using BIC.Data;
using BIC.Utils;
using BIC.WebControls;

public partial class Controls_Article_ThongtinDathang : BaseUIControl
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (IsPostBack) return;
        LoadUserInfo();
        LoadData();
        var ttNguoiDat = (string[])Session["ThongTinNguoiDat"];
        if (ttNguoiDat != null)
        {
            ddlCity.SelectedValue = ttNguoiDat[3];
            BindDropDownDistrict();
            ddlDistrict.SelectedValue = ttNguoiDat[17];
            ddlShippingMethod.SelectedValue = ttNguoiDat[9];
            tblShippingType.SelectedValue = ttNguoiDat[16];
            IsUsePoint.Checked = (ttNguoiDat[12] != "0");
            BindMaxPoint();
        }
        var ttNguoiNhan = (string[])Session["ThongTinNguoiNhan"];
        if (ttNguoiNhan != null)
        {
            ddlCity2.SelectedValue = ttNguoiNhan[3];
            BindDropDownDistrict2();
            ddlDistrict2.SelectedValue = ttNguoiNhan[8];
        }
    }

    protected void LoadUserInfo()
    {
        var currentUser = BicMemberShip.CurrentUserName;
        var user = Membership.GetUser(currentUser);
        if (user != null)
        {
            var profile = Profile.GetProfile(currentUser);
            if (profile != null)
            {
                txtFullname.Text = profile.FullName;
                //txtCity.Text = profile.City;
                txtCompany.Text = profile.Company;
                txtAddressNguoiGui.Text = profile.Address;
                txtEmail.Text = user.Email;
                txtTel.Text = !string.IsNullOrEmpty(profile.Phone) ? profile.Phone : profile.Mobile;
                //UsePoint.Text = profile.CurrentPoint;
                //txtNip.Text = profile.Nip;
            }
        }
    }

    protected void BindDropDownCity2()
    {
        // Bind Dropdown city
        ddlCity2.Items.Clear();
        var lstCity = CityBiz.GetAllCitys();
        if (!lstCity.Any()) return;
        ddlCity2.DataSource = lstCity;
        ddlCity2.DataTextField = "CityName";
        ddlCity2.DataValueField = "CityID";
        ddlCity2.DataBind();
        ddlCity2.Items.Insert(0, new ListItem("-- Chọn Tỉnh/Thành phố --", "0"));
        //ddlCity.SelectedIndex = 24;
    }

    protected void BindDropDownDistrict2()
    {
        // Bind Dropdown district
        ddlDistrict2.Items.Clear();
        if (ddlCity2.SelectedValue == "0")
            ddlDistrict2.Items.Insert(0, new ListItem("-- Chọn Quận/Huyện --", "0"));
        else
        {
            var lstDist = DistrictBiz.GetDistrictByCityID(BicConvert.ToInt32(ddlCity2.SelectedValue));
            if (lstDist.Any())
            {
                ddlDistrict2.DataSource = lstDist;
                ddlDistrict2.DataTextField = "DistrictName";
                ddlDistrict2.DataValueField = "DistrictID";
                ddlDistrict2.DataBind();
                ddlDistrict2.Items.Insert(0, new ListItem("-- Chọn Quận/Huyện --", "0"));
            }
            else
            {
                ddlDistrict2.Items.Clear();
                ddlDistrict2.Items.Insert(0, new ListItem("-- Chọn Quận/Huyện --", "0"));
            }
        }
    }

    protected void BindDropDownCity()
    {
        // Bind Dropdown city
        ddlCity.Items.Clear();
        var lstCity = CityBiz.GetAllCitys();
        if (!lstCity.Any()) return;
        ddlCity.DataSource = lstCity;
        ddlCity.DataTextField = "CityName";
        ddlCity.DataValueField = "CityID";
        ddlCity.DataBind();
        ddlCity.Items.Insert(0, new ListItem("-- Chọn Tỉnh/Thành phố --", "0"));
        //ddlCity.SelectedIndex = 24;
    }

    protected void BindDropDownDistrict()
    {
        // Bind Dropdown district
        ddlDistrict.Items.Clear();
        if (ddlCity.SelectedValue == "0")
            ddlDistrict.Items.Insert(0, new ListItem("-- Chọn Quận/Huyện --", "0"));
        else
        {
            var lstDist = DistrictBiz.GetDistrictByCityID(BicConvert.ToInt32(ddlCity.SelectedValue));
            if (lstDist.Any())
            {
                ddlDistrict.DataSource = lstDist;
                ddlDistrict.DataTextField = "DistrictName";
                ddlDistrict.DataValueField = "DistrictID";
                ddlDistrict.DataBind();
                ddlDistrict.Items.Insert(0, new ListItem("-- Chọn Quận/Huyện --", "0"));
            }
            else
            {
                ddlDistrict.Items.Clear();
                ddlDistrict.Items.Insert(0, new ListItem("-- Chọn Quận/Huyện --", "0"));
            }
        }
    }

    protected void BindMaxPoint()
    {
        // Bind max usepoint
        if (IsUsePoint.Checked)
        {
            divPoint.Visible = true;
            var profile = Profile.GetProfile(BicMemberShip.CurrentUserName);
            if (!string.IsNullOrEmpty(profile.City))
                ddlCity.Items.FindByText(profile.City).Selected = true;
            if (!string.IsNullOrEmpty(profile.District))
            {
                BindDropDownDistrict();
                ddlDistrict.Items.FindByText(profile.District).Selected = true;
            }
            var total = BicConvert.ToDouble(Session["TotalCart"].ToString()) + BicConvert.ToDouble(lbPhiVanChuyen.Text.Trim());
            var curPoint = BicConvert.ToDouble(profile.CurrentPoint);
            CurPoint.Text = string.Format("{0:N0}", curPoint);
            if (total > curPoint)
            {
                // Set max value của UserPoint
                string temp;
                if (curPoint.ToString().Length > 3)
                    temp = curPoint.ToString().Substring(curPoint.ToString().Length - 3, 3);
                else
                    temp = curPoint.ToString();
                if (BicConvert.ToInt32(temp) == 0)
                {
                    UsePoint.MaxValue = curPoint;
                    MaxUsePoint.Value = curPoint.ToString();

                    UsePoint.Text = curPoint.ToString();
                    lbUsePoint.Text = string.Format("{0:N0}", BicConvert.ToDouble(curPoint));
                }
                else
                {
                    curPoint = curPoint - BicConvert.ToInt32(temp);
                    UsePoint.MaxValue = curPoint;
                    MaxUsePoint.Value = curPoint.ToString();

                    UsePoint.Text = curPoint.ToString();
                    lbUsePoint.Text = string.Format("{0:N0}", BicConvert.ToDouble(curPoint));
                }
            }
            else
            {
                // Set max value của UserPoint
                UsePoint.MaxValue = total;
                MaxUsePoint.Value = total.ToString();

                UsePoint.Text = total.ToString();
                lbUsePoint.Text = string.Format("{0:N0}", BicConvert.ToDouble(total));
            }
            lblTotalPay.Text = string.Format("{0:N0}",
            BicConvert.ToDouble(Session["TotalCart"]) + BicConvert.ToDouble(lbPhiVanChuyen.Text) - BicConvert.ToDouble(lbUsePoint.Text));
        }
        else
        {
            divPoint.Visible = false;
            UsePoint.Text = "0";
            lbUsePoint.Text = "0";
            lblTotalPay.Text = string.Format("{0:N0}",
            BicConvert.ToDouble(Session["TotalCart"]) + BicConvert.ToDouble(lbPhiVanChuyen.Text));
        }
        // end bind max point
    }

    protected void LoadData()
    {
        if (BicSession.ToString("NganLuong") == "1")
            ddlPayMethod.SelectedValue = "Thanh toán qua Ngân Lượng";
        //Tính tiền
        //UsePoint.Text = "0";
        lbUsePoint.Text = "0";
        var shippingfee = "0";
        var shippingType = tblShippingType.SelectedValue;
        if (ddlCity2.SelectedIndex > 0)
        {
            var free = CityBiz.GetCityByID(BicConvert.ToInt32(ddlCity2.SelectedValue));
            if (free != null)
            {
                if (shippingType == "0")
                {
                    if (BicConvert.ToDouble(Total.Value.Trim()) <= BicConvert.ToDouble(free.MienPhiNhanh))
                        shippingfee = free.ChuyenNhanh;
                }
                else
                {
                    if (BicConvert.ToDouble(Total.Value.Trim()) <= BicConvert.ToDouble(free.MienPhiCham))
                        shippingfee = free.ChuyenCham;
                }
            }
        }
        if (ddlDistrict2.SelectedIndex > 0)
        {
            var free = DistrictBiz.GetDistrictByID(BicConvert.ToInt32(ddlDistrict2.SelectedValue));
            if (free != null)
            {
                if (shippingType == "0")
                {
                    if (BicConvert.ToDouble(Total.Value.Trim()) <= BicConvert.ToDouble(free.MienPhiNhanh))
                        shippingfee = free.ChuyenNhanh;
                }
                else
                {
                    if (BicConvert.ToDouble(Total.Value.Trim()) <= BicConvert.ToDouble(free.MienPhiCham))
                        shippingfee = free.ChuyenCham;
                }
            }
        }

        if (ddlShippingMethod.SelectedValue.Equals("Nhận hàng tại LovelyBeauty"))
        {
            shippingfee = "0";
        }

        lbPhiVanChuyen.Text = string.Format("{0:N0}", BicConvert.ToDouble(shippingfee));
        lblTotalPay.Text = string.Format("{0:N0}",
            BicConvert.ToDouble(Session["TotalCart"]) + BicConvert.ToDouble(lbPhiVanChuyen.Text) -
            BicConvert.ToDouble(lbUsePoint.Text));

        //End tính tiền
        BindDropDownCity();
        //BindDropDownDistrict();
        BindDropDownCity2();
        BindDropDownDistrict2();

        SavePoint.Value = Session["TotalPoint"].ToString();
        Total.Value = Session["TotalCart"].ToString();

        // Bind max usepoint
        BindMaxPoint();
        // end bind max point

        var bicData = new BicGetData("Category");
        bicData.Selecting.Add(
         "Name, Value, TypeOfCategory,IsActive,Priority");
        var con = new ConditioningItem
        {
            TypeOfCondition = TypeOfCondition.QUERY,
            Query = string.Format("TypeOfCategory=1 and IsActive=1")
        };
        var con1 = new ConditioningItem
        {
            TypeOfCondition = TypeOfCondition.QUERY,
            Query = string.Format("TypeOfCategory=2 and IsActive=1")
        };
        bicData.Conditioning.Add(con);
        bicData.Sorting.Add(new SortingItem("Priority", false));
        var data = bicData.GetAllData();
        ddlShippingMethod.DataSource = data;
        ddlShippingMethod.DataValueField = "Name";
        ddlShippingMethod.DataTextField = "Name";
        ddlShippingMethod.DataBind();
        ddlShippingMethod.Items.Insert(0, new ListItem("-- Chọn cách vận chuyển --", "0"));
        bicData.Conditioning.Remove(con);
        bicData.Conditioning.Add(con1);
        var data1 = bicData.GetAllData();
        ddlPayMethod.DataSource = data1;
        ddlPayMethod.DataValueField = "Name";
        ddlPayMethod.DataTextField = "Name";
        ddlPayMethod.DataBind();
        ddlPayMethod.Items.Insert(0, new ListItem("-- Chọn cách thanh toán --", "0"));

        if (Session["ThongTinNguoiDat"] != null)
        {
            var ttNguoiDat = (string[])Session["ThongTinNguoiDat"];
            txtFullname.Text = ttNguoiDat[0];
            txtTel.Text = ttNguoiDat[1];
            txtAddressNguoiGui.Text = ttNguoiDat[5];
            //txtCity.Text = ttNguoiDat[3];
            txtEmail.Text = ttNguoiDat[4];
            txtCompany.Text = ttNguoiDat[2];
            txtNotes.Text = ttNguoiDat[6];
            ddlPayMethod.SelectedValue = ttNguoiDat[8];
            txtNip.Text = ttNguoiDat[10];
            txtAddOrderReceived.Text = ttNguoiDat[7];
        }
        if (ddlShippingMethod.SelectedValue != "Nhận hàng tại LovelyBeauty")
        {
            divShipingType.Visible = true;
        }
        else
        {
            divShipingType.Visible = false;
        }
        if (Session["ThongTinNguoiNhan"] == null) return;
        var ttNguoiNhan = (string[])Session["ThongTinNguoiNhan"];
        txtFullname2.Text = ttNguoiNhan[0];
        txtTel2.Text = ttNguoiNhan[1];
        txtAdresShipping.Text = ttNguoiNhan[5];
        //txtCity2.Text = ttNguoiNhan[3];
        txtEmail2.Text = ttNguoiNhan[4];
        txtCompany2.Text = ttNguoiNhan[2];
        txtNotes2.Text = ttNguoiNhan[6];
        txtNip2.Text = ttNguoiNhan[7];
    }
    protected void chkTT_Change(object sender, EventArgs e)
    {
        if (chkTT.Checked)
        {
            txtFullname2.Text = txtFullname.Text;
            txtTel2.Text = txtTel.Text;
            //txtCompany2.Text = txtCompany.Text;
            txtAdresShipping.Text = txtAddressNguoiGui.Text;
            //txtCity2.Text = txtCity.Text;
            txtEmail2.Text = txtEmail.Text;
            //txtNgheNghiep2.Text = txtNgheNghiep.Text;
            //txtNotes2.Text = txtNotes.Text;
            //txtNip2.Text = txtNip.Text;
            ddlCity2.SelectedIndex = ddlCity.SelectedIndex;
            BindDropDownDistrict2();
            ddlDistrict2.SelectedIndex = ddlDistrict.SelectedIndex;
            var shippingfee = "0";
            var shippingType = tblShippingType.SelectedValue;
            if (ddlCity2.SelectedIndex > 0)
            {
                var free = CityBiz.GetCityByID(BicConvert.ToInt32(ddlCity2.SelectedValue));
                if (free != null)
                {
                    if (shippingType == "0")
                    {
                        if (BicConvert.ToDouble(Total.Value.Trim()) <= BicConvert.ToDouble(free.MienPhiNhanh))
                            shippingfee = free.ChuyenNhanh;
                    }
                    else
                    {
                        if (BicConvert.ToDouble(Total.Value.Trim()) <= BicConvert.ToDouble(free.MienPhiCham))
                            shippingfee = free.ChuyenCham;
                    }
                }
            }
            if (ddlDistrict2.SelectedIndex > 0)
            {
                var free = DistrictBiz.GetDistrictByID(BicConvert.ToInt32(ddlDistrict2.SelectedValue));
                if (free != null)
                {
                    if (shippingType == "0")
                    {
                        if (BicConvert.ToDouble(Total.Value.Trim()) <= BicConvert.ToDouble(free.MienPhiNhanh))
                            shippingfee = free.ChuyenNhanh;
                    }
                    else
                    {
                        if (BicConvert.ToDouble(Total.Value.Trim()) <= BicConvert.ToDouble(free.MienPhiCham))
                            shippingfee = free.ChuyenCham;
                    }
                }
            }

            if (ddlShippingMethod.SelectedValue.Equals("Nhận hàng tại LovelyBeauty"))
            {
                shippingfee = "0";
            }

            lbPhiVanChuyen.Text = string.Format("{0:N0}", BicConvert.ToDouble(shippingfee));
            BindMaxPoint();
            lblTotalPay.Text = string.Format("{0:N0}",
                BicConvert.ToDouble(Session["TotalCart"]) + BicConvert.ToDouble(lbPhiVanChuyen.Text) -
                BicConvert.ToDouble(lbUsePoint.Text));
        }
        else
        {
            ClearForm();
            ddlCity2.SelectedIndex = 0;
            ddlDistrict2.SelectedIndex = 0;
            lbPhiVanChuyen.Text = "0";
            BindMaxPoint();
        }
    }
    private void ClearForm()
    {
        txtCompany2.Text = string.Empty;
        txtNotes2.Text = string.Empty;
        txtEmail2.Text = string.Empty;
        txtAdresShipping.Text = string.Empty;
        txtFullname2.Text = string.Empty;
        txtTel2.Text = string.Empty;
        txtNip2.Text = string.Empty;
        //txtCity2.Text = string.Empty;
    }
    protected void lbtNext_OnClick(object sender, EventArgs e)
    {
        var isfreecondi = "0";
        var shippingfee = "0";
        var shippingType = tblShippingType.SelectedValue;
        var freecondion = "0";
        if (ddlCity2.SelectedIndex > 0)
        {
            var free = CityBiz.GetCityByID(BicConvert.ToInt32(ddlCity2.SelectedValue));
            if (free != null)
            {
                if (shippingType == "0")
                {
                    freecondion = free.MienPhiNhanh;
                    if (BicConvert.ToDouble(Total.Value.Trim()) <= BicConvert.ToDouble(free.MienPhiNhanh))
                        shippingfee = free.ChuyenNhanh;
                }
                else
                {
                    freecondion = free.MienPhiCham;
                    if (BicConvert.ToDouble(Total.Value.Trim()) <= BicConvert.ToDouble(free.MienPhiCham))
                        shippingfee = free.ChuyenCham;
                }
            }
        }
        if (ddlDistrict2.SelectedIndex > 0)
        {
            var free = DistrictBiz.GetDistrictByID(BicConvert.ToInt32(ddlDistrict2.SelectedValue));
            if (free != null)
            {
                if (shippingType == "0")
                {
                    freecondion = free.MienPhiNhanh;
                    if (BicConvert.ToDouble(Total.Value.Trim()) <= BicConvert.ToDouble(free.MienPhiNhanh))
                        shippingfee = free.ChuyenNhanh;
                }
                else
                {
                    freecondion = free.MienPhiCham;
                    if (BicConvert.ToDouble(Total.Value.Trim()) <= BicConvert.ToDouble(free.MienPhiCham))
                        shippingfee = free.ChuyenCham;
                }
            }
        }

        if (ddlShippingMethod.SelectedValue.Equals("Nhận hàng tại LovelyBeauty"))
        {
            shippingfee = "0";
            isfreecondi = "1";
            shippingType = "";
        }

        var usePoint = "0";
        if (IsUsePoint.Checked)
            usePoint = string.Format("{0}", BicConvert.ToInt32(UsePoint.Text));

        var ttNguoiDat = new[]
            {
                txtFullname.Text, 
                txtTel.Text, 
                txtCompany.Text, 
                ddlCity.SelectedValue, 
                txtEmail.Text, 
                txtAddressNguoiGui.Text,
                txtNotes.Text,
                txtAddOrderReceived.Text, 
                ddlPayMethod.SelectedValue,
                ddlShippingMethod.SelectedValue,
                txtNip.Text,
                SavePoint.Value.Trim(),
                usePoint,
                shippingfee,
                freecondion,
                isfreecondi,
                shippingType,
                ddlDistrict.SelectedValue
            };
        Session["ThongTinNguoiDat"] = ttNguoiDat;

        var ttNguoiNhan = new[]
            {
                txtFullname2.Text, 
                txtTel2.Text, 
                txtCompany2.Text, 
                ddlCity2.SelectedValue,
                txtEmail2.Text, 
                txtAdresShipping.Text,
                txtNotes2.Text,
                txtNip2.Text,
                ddlDistrict2.SelectedValue
            };
        Session["ThongTinNguoiNhan"] = ttNguoiNhan;
        Response.Redirect(string.Format("{0}{1}/shopping-cart.sc{2}.html", BicApplication.URLRoot, BicLanguage.CurrentLanguage, "3"));
        //Response.Redirect(Request.Url.ToString().Replace("sc2.html", "sc3.html"));
    }
    protected void lbtBack_OnClick(object sender, EventArgs e)
    {
        Response.Redirect(string.Format("{0}{1}/shopping-cart.sc{2}.html", BicApplication.URLRoot, BicLanguage.CurrentLanguage, "1"));
    }

    protected void ddlPayMethod_OnSelectedIndexChanged(object sender, EventArgs e)
    {
        BicSession.SetValue("NganLuong", ddlPayMethod.SelectedValue == "Thanh toán qua Ngân Lượng" ? "1" : "0");
        bankinfo.Visible = ddlPayMethod.SelectedValue == "Ngân hàng trực tuyến";
    }

    protected void ddlCity_OnSelectedIndexChanged(object sender, EventArgs e)
    {
        BindDropDownDistrict();
    }
    protected void ddlCity2_OnSelectedIndexChanged(object sender, EventArgs e)
    {
        BindDropDownDistrict2();
        if (ddlCity2.SelectedValue != "0")
        {
            var city = CityBiz.GetCityByID(BicConvert.ToInt32(ddlCity2.SelectedValue));
            if (city != null)
            {
                var shipType = tblShippingType.SelectedValue;
                if (shipType == "0")
                {
                    if (BicConvert.ToDouble(Session["TotalCart"]) > BicConvert.ToDouble(city.MienPhiNhanh))
                    {
                        lbPhiVanChuyen.Text = "0";
                        BindMaxPoint();
                        lblTotalPay.Text = string.Format("{0:N0}", BicConvert.ToDouble(Session["TotalCart"]) + BicConvert.ToDouble(lbPhiVanChuyen.Text) - BicConvert.ToDouble(lbUsePoint.Text));
                    }
                    else
                    {
                        lbPhiVanChuyen.Text = string.Format("{0:N0}", BicConvert.ToDouble(city.ChuyenNhanh));
                        BindMaxPoint();
                        lblTotalPay.Text = string.Format("{0:N0}", BicConvert.ToDouble(Session["TotalCart"]) + BicConvert.ToDouble(lbPhiVanChuyen.Text) - BicConvert.ToDouble(lbUsePoint.Text));
                    }
                }
                else
                {
                    if (BicConvert.ToDouble(Session["TotalCart"]) > BicConvert.ToDouble(city.MienPhiCham))
                    {
                        lbPhiVanChuyen.Text = "0";
                        BindMaxPoint();
                        lblTotalPay.Text = string.Format("{0:N0}", BicConvert.ToDouble(Session["TotalCart"]) + BicConvert.ToDouble(lbPhiVanChuyen.Text) - BicConvert.ToDouble(lbUsePoint.Text));
                    }
                    else
                    {
                        lbPhiVanChuyen.Text = string.Format("{0:N0}", BicConvert.ToDouble(city.ChuyenCham));
                        BindMaxPoint();
                        lblTotalPay.Text = string.Format("{0:N0}", BicConvert.ToDouble(Session["TotalCart"]) + BicConvert.ToDouble(lbPhiVanChuyen.Text) - BicConvert.ToDouble(lbUsePoint.Text));
                    }
                }
            }
        }
    }

    protected void ddlShippingMethod_OnSelectedIndexChanged(object sender, EventArgs e)
    {
        if (ddlShippingMethod.SelectedValue != "Nhận hàng tại LovelyBeauty")
        {
            divShipingType.Visible = true;
            //var isfreecondi = "0";
            var shippingfee = "0";
            var shippingType = tblShippingType.SelectedValue;
            //var freecondion = "0";
            if (ddlCity2.SelectedIndex > 0)
            {
                var free = CityBiz.GetCityByID(BicConvert.ToInt32(ddlCity2.SelectedValue));
                if (free != null)
                {
                    if (shippingType == "0")
                    {
                        //freecondion = free.MienPhiNhanh;
                        if (BicConvert.ToDouble(Total.Value.Trim()) <= BicConvert.ToDouble(free.MienPhiNhanh))
                            shippingfee = free.ChuyenNhanh;
                    }
                    else
                    {
                        //freecondion = free.MienPhiCham;
                        if (BicConvert.ToDouble(Total.Value.Trim()) <= BicConvert.ToDouble(free.MienPhiCham))
                            shippingfee = free.ChuyenCham;
                    }
                }
            }
            if (ddlDistrict2.SelectedIndex > 0)
            {
                var free = DistrictBiz.GetDistrictByID(BicConvert.ToInt32(ddlDistrict2.SelectedValue));
                if (free != null)
                {
                    if (shippingType == "0")
                    {
                        //freecondion = free.MienPhiNhanh;
                        if (BicConvert.ToDouble(Total.Value.Trim()) <= BicConvert.ToDouble(free.MienPhiNhanh))
                            shippingfee = free.ChuyenNhanh;
                    }
                    else
                    {
                        //freecondion = free.MienPhiCham;
                        if (BicConvert.ToDouble(Total.Value.Trim()) <= BicConvert.ToDouble(free.MienPhiCham))
                            shippingfee = free.ChuyenCham;
                    }
                }
            }

            if (ddlShippingMethod.SelectedValue.Equals("Nhận hàng tại LovelyBeauty"))
            {
                shippingfee = "0";
            }

            lbPhiVanChuyen.Text = string.Format("{0:N0}", BicConvert.ToDouble(shippingfee));
            BindMaxPoint();
            lblTotalPay.Text = string.Format("{0:N0}",
                BicConvert.ToDouble(Session["TotalCart"]) + BicConvert.ToDouble(shippingfee) -
                BicConvert.ToDouble(UsePoint.Value));
        }
        else
        {
            divShipingType.Visible = false;
            lbPhiVanChuyen.Text = "0";
            BindMaxPoint();
            lblTotalPay.Text = string.Format("{0:N0}",
                BicConvert.ToDouble(Session["TotalCart"]) - BicConvert.ToDouble(lbUsePoint.Text));
        }

    }

    protected void tblShippingType_OnSelectedIndexChanged(object sender, EventArgs e)
    {
        //var isfreecondi = "0";
        var shippingfee = "0";
        var shippingType = tblShippingType.SelectedValue;
        //var freecondion = "0";
        if (ddlCity2.SelectedIndex > 0)
        {
            var free = CityBiz.GetCityByID(BicConvert.ToInt32(ddlCity2.SelectedValue));
            if (free != null)
            {
                if (shippingType == "0")
                {
                    //freecondion = free.MienPhiNhanh;
                    if (BicConvert.ToDouble(Total.Value.Trim()) <= BicConvert.ToDouble(free.MienPhiNhanh))
                        shippingfee = free.ChuyenNhanh;
                }
                else
                {
                    //freecondion = free.MienPhiCham;
                    if (BicConvert.ToDouble(Total.Value.Trim()) <= BicConvert.ToDouble(free.MienPhiCham))
                        shippingfee = free.ChuyenCham;
                }
            }
        }
        else
        {
            BicAjax.Alert("Bạn chưa chọn Tỉnh/Thành Phố của người nhận hàng !");
        }
        if (ddlDistrict2.SelectedIndex > 0)
        {
            var free = DistrictBiz.GetDistrictByID(BicConvert.ToInt32(ddlDistrict2.SelectedValue));
            if (free != null)
            {
                if (shippingType == "0")
                {
                    //freecondion = free.MienPhiNhanh;
                    if (BicConvert.ToDouble(Total.Value.Trim()) <= BicConvert.ToDouble(free.MienPhiNhanh))
                        shippingfee = free.ChuyenNhanh;
                }
                else
                {
                    //freecondion = free.MienPhiCham;
                    if (BicConvert.ToDouble(Total.Value.Trim()) <= BicConvert.ToDouble(free.MienPhiCham))
                        shippingfee = free.ChuyenCham;
                }
            }
        }

        if (ddlShippingMethod.SelectedValue.Equals("Nhận hàng tại LovelyBeauty"))
        {
            shippingfee = "0";
        }

        lbPhiVanChuyen.Text = string.Format("{0:N0}", BicConvert.ToDouble(shippingfee));
        BindMaxPoint();
        lblTotalPay.Text = string.Format("{0:N0}",
            BicConvert.ToDouble(Session["TotalCart"]) + BicConvert.ToDouble(lbPhiVanChuyen.Text) -
            BicConvert.ToDouble(lbUsePoint.Text));
    }

    protected void UsePoint_OnTextChanged(object sender, EventArgs e)
    {
        // Set max value của UserPoint
        var curPoint = UsePoint.Text;
        string temp;
        if (curPoint.ToString().Length > 3)
            temp = curPoint.ToString().Substring(curPoint.ToString().Length - 3, 3);
        else
            temp = curPoint.ToString();
        curPoint = (BicConvert.ToInt32(curPoint) - BicConvert.ToInt32(temp)).ToString();
        UsePoint.MaxValue = BicConvert.ToDouble(curPoint);
        MaxUsePoint.Value = curPoint.ToString();

        UsePoint.Text = curPoint.ToString();
        lbUsePoint.Text = string.Format("{0:N0}", BicConvert.ToDouble(curPoint));

        lbUsePoint.Text = string.Format("{0:N0}", BicConvert.ToDouble(UsePoint.Text));
        lblTotalPay.Text = string.Format("{0:N0}",
            BicConvert.ToDouble(Session["TotalCart"]) + BicConvert.ToDouble(lbPhiVanChuyen.Text) -
            BicConvert.ToDouble(lbUsePoint.Text));
        UsePoint.Focus();
    }

    protected void IsUsePoint_OnCheckedChanged(object sender, EventArgs e)
    {
        BindMaxPoint();
    }

    protected void ddlDistrict2_OnSelectedIndexChanged(object sender, EventArgs e)
    {
        if (ddlDistrict2.SelectedValue != "0")
        {
            var district = DistrictBiz.GetDistrictByID(BicConvert.ToInt32(ddlDistrict2.SelectedValue));
            if (district != null)
            {
                var shipType = tblShippingType.SelectedValue;
                if (shipType == "0")
                {
                    if (!string.IsNullOrEmpty(district.ChuyenNhanh))
                    {
                        if (BicConvert.ToDouble(Session["TotalCart"]) > BicConvert.ToDouble(district.MienPhiNhanh))
                        {
                            lbPhiVanChuyen.Text = "0";
                            BindMaxPoint();
                            lblTotalPay.Text = string.Format("{0:N0}", BicConvert.ToDouble(Session["TotalCart"]) + BicConvert.ToDouble(lbPhiVanChuyen.Text) - BicConvert.ToDouble(lbUsePoint.Text));
                        }
                        else
                        {
                            lbPhiVanChuyen.Text = string.Format("{0:N0}", BicConvert.ToDouble(district.ChuyenNhanh));
                            BindMaxPoint();
                            lblTotalPay.Text = string.Format("{0:N0}", BicConvert.ToDouble(Session["TotalCart"]) + BicConvert.ToDouble(lbPhiVanChuyen.Text) - BicConvert.ToDouble(lbUsePoint.Text));
                        }
                    }
                    else
                    {
                        var temp = CityBiz.GetCityByID(BicConvert.ToInt32(ddlCity2.SelectedValue));
                        if (temp != null)
                        {
                            if (!string.IsNullOrEmpty(temp.ChuyenNhanh))
                            {
                                if (BicConvert.ToDouble(Session["TotalCart"]) > BicConvert.ToDouble(temp.MienPhiNhanh))
                                {
                                    lbPhiVanChuyen.Text = "0";
                                    BindMaxPoint();
                                    lblTotalPay.Text = string.Format("{0:N0}", BicConvert.ToDouble(Session["TotalCart"]) + BicConvert.ToDouble(lbPhiVanChuyen.Text) - BicConvert.ToDouble(lbUsePoint.Text));
                                }
                                else
                                {
                                    lbPhiVanChuyen.Text = string.Format("{0:N0}", BicConvert.ToDouble(temp.ChuyenNhanh));
                                    BindMaxPoint();
                                    lblTotalPay.Text = string.Format("{0:N0}", BicConvert.ToDouble(Session["TotalCart"]) + BicConvert.ToDouble(lbPhiVanChuyen.Text) - BicConvert.ToDouble(lbUsePoint.Text));
                                }
                            }
                        }
                    }
                }
                else
                {
                    if (!string.IsNullOrEmpty(district.ChuyenCham))
                    {
                        if (BicConvert.ToDouble(Session["TotalCart"]) > BicConvert.ToDouble(district.MienPhiCham))
                        {
                            lbPhiVanChuyen.Text = "0";
                            BindMaxPoint();
                            lblTotalPay.Text = string.Format("{0:N0}", BicConvert.ToDouble(Session["TotalCart"]) + BicConvert.ToDouble(lbPhiVanChuyen.Text) - BicConvert.ToDouble(lbUsePoint.Text));
                        }
                        else
                        {
                            lbPhiVanChuyen.Text = string.Format("{0:N0}", BicConvert.ToDouble(district.ChuyenCham));
                            BindMaxPoint();
                            lblTotalPay.Text = string.Format("{0:N0}", BicConvert.ToDouble(Session["TotalCart"]) + BicConvert.ToDouble(lbPhiVanChuyen.Text) - BicConvert.ToDouble(lbUsePoint.Text));
                        }
                    }
                    else
                    {
                        var temp = CityBiz.GetCityByID(BicConvert.ToInt32(ddlCity2.SelectedValue));
                        if (temp != null)
                        {
                            if (!string.IsNullOrEmpty(temp.ChuyenCham))
                            {
                                if (BicConvert.ToDouble(Session["TotalCart"]) > BicConvert.ToDouble(temp.MienPhiCham))
                                {
                                    lbPhiVanChuyen.Text = "0";
                                    BindMaxPoint();
                                    lblTotalPay.Text = string.Format("{0:N0}", BicConvert.ToDouble(Session["TotalCart"]) + BicConvert.ToDouble(lbPhiVanChuyen.Text) - BicConvert.ToDouble(lbUsePoint.Text));
                                }
                                else
                                {
                                    lbPhiVanChuyen.Text = string.Format("{0:N0}", BicConvert.ToDouble(temp.ChuyenCham));
                                    BindMaxPoint();
                                    lblTotalPay.Text = string.Format("{0:N0}", BicConvert.ToDouble(Session["TotalCart"]) + BicConvert.ToDouble(lbPhiVanChuyen.Text) - BicConvert.ToDouble(lbUsePoint.Text));
                                }
                            }
                        }
                    }
                }
            }
        }
    }
}