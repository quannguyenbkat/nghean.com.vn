using System;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web.Security;
using System.Web.UI.WebControls;
using BIC.Biz;
using BIC.Utils;
using BIC.WebControls;

public partial class Controls_User_UserProfile : BaseUIControl
{


    protected void Page_Load(object sender, EventArgs e)
    {
        Include.CssAdd("~/Controls/User/CSS/UserManage.css");
        if (BicMemberShip.CurrentUserName == "")
            BicAjax.Navigate(BicApplication.URLRoot);

        if (!IsPostBack)
        {
            GetProfile();
        }
    }

    private void GetProfile()
    {
        var user = Membership.GetUser(BicMemberShip.CurrentUserName);
        if (user == null) return;

        BicSession.SetValue("CurrentEmail", user.Email);

        var profile = Profile.GetProfile(BicMemberShip.CurrentUserName);
        if (profile == null) return;
        txtFullName.Text = profile.FullName;
        txtUsername.Text = profile.UserName;
        txtDOB.Text = profile.Birth;
        txtAddress.Text = profile.Address;
        txtEmail.Text = user.Email;
        txtPhone.Text = profile.Phone;
        txtPoint.Text = BicConvert.ToDouble(profile.Point).ToString("##,###");
        txtCurPoint.Text = BicConvert.ToDouble(profile.CurrentPoint).ToString("##,###");
        txtUsedPoint.Text = BicConvert.ToDouble(profile.UsedPoint).ToString("##,###");
        txtGiftPoint.Text = BicConvert.ToDouble(profile.GiftPoint).ToString("##,###");
        var note = BicString.SplitSemicolon(profile.PointHistory).Aggregate(string.Empty, (current, s) => current + (s + "\n"));
        txtPointNote.Text = note;
        txtDateOfBirth.Text = profile.Birth;
        txtCompany.Text = profile.Company;
        BindDropDownCity();
        if (!string.IsNullOrEmpty(profile.City))
            ddlCity.Items.FindByText(profile.City).Selected = true;
        if (!string.IsNullOrEmpty(profile.District))
        {
            BindDropDownDistrict();
            ddlDistrict.Items.FindByText(profile.District).Selected = true;
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

    public void SaveProfile()
    {
        var user = Membership.GetUser(BicMemberShip.CurrentUserName);
        if (user != null)
        {
            user.Email = txtEmail.Text.Trim();
            Membership.UpdateUser(user);
        }

        var profile = Profile.GetProfile(BicMemberShip.CurrentUserName);
        profile.FullName = txtFullName.Text;
        profile.Company = txtCompany.Text;
        profile.Address = txtAddress.Text;
        profile.Phone = txtPhone.Text;
        if (ddlCity.SelectedIndex != 0)
            profile.City = ddlCity.SelectedItem.Text;
        if (ddlDistrict.SelectedIndex != 0)
            profile.District = ddlDistrict.SelectedItem.Text;
        //profile.Birth = txtDOB.Text;
        profile.Birth = txtDateOfBirth.Text;
        try
        {
            profile.Save();
            BicAjax.Alert(BicResource.GetValue("Message", "USER_UPDATE_SUCC"));
        }

        catch (Exception ex)
        {
            BicAjax.Alert(BicResource.GetValue("Message", "USER_UPDATE_FAIL") + "\n" + ex.Message);
        }
    }

    public bool IsValidEmail(string email)
    {
        //regular expression pattern for valid email addresses, allows for the following domains: com,edu,info,gov,int,mil,net,org,biz,name,museum,coop,aero,pro,tv
        var pattern = @"^[-a-zA-Z0-9][-.a-zA-Z0-9]*@[-.a-zA-Z0-9]+(\.[-.a-zA-Z0-9]+)*\.(com|edu|info|gov|int|mil|net|org|biz|name|museum|coop|aero|pro|tv|[a-zA-Z]{2})$";

        //Regular expression object
        var check = new Regex(pattern, RegexOptions.IgnorePatternWhitespace);

        //boolean variable to return to calling method
        bool valid;

        //make sure an email address was provided
        valid = !string.IsNullOrEmpty(email) && check.IsMatch(email);

        //return the value to the calling method
        return valid;
    }

    protected void btnChange_OnClick(object sender, EventArgs e)
    {
        SaveProfile();
    }

    protected void ddlCity_OnSelectedIndexChanged(object sender, EventArgs e)
    {
        BindDropDownDistrict();
    }
}