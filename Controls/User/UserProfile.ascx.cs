using System;
using System.Web.Security;
using System.Web.UI;
using BIC.Biz;
using BIC.Entity;
using BIC.Utils;
using BIC.WebControls;

public partial class Controls_User_UserProfile : BaseUIControl
{
    public string ChangePassUrl { get; set; }

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            Include.CssToTop("contact.css,Register.css");
            Include.ScriptToBottom("Register.js");
            GetProfile();
            ChangePassUrl = string.Format("{0}{1}/change-pass.html", BicApplication.URLRoot, Language);
            //url of change password page
        }
    }

    private void GetProfile()
    {
        MembershipUser user = Membership.GetUser(BicMemberShip.CurrentUserName);
        if (user == null) return;
        txtUsername.Text = user.UserName;
        txtUsername.Enabled = false;
        var profile = Profile.GetProfile(BicMemberShip.CurrentUserName);
        if (profile != null)
        {
            txtFullName.Text = profile.FullName;
            txtWorkPlace.Text = profile.Address;
            txtCity.Text = profile.City;
            txtPhone.Text = profile.Phone;
            chkSex.Checked = profile.GioiTinh == "1";
        }
    }

    public void SaveProfile()
    {
        var user = Membership.GetUser(BicMemberShip.CurrentUserName);
        if (!Membership.ValidateUser(BicMemberShip.CurrentUserName,txtPass.Text))
        {
            BicAjax.Alert("Mật khẩu không chính xác");
            return;
        }
        var profile = Profile.GetProfile(BicMemberShip.CurrentUserName);
        if (user != null && profile != null)
        {

            try
            {
                profile.FullName = txtFullName.Text;
                profile.Address = txtWorkPlace.Text;
                profile.City = txtCity.Text;
                profile.Phone = txtPhone.Text;
                profile.GioiTinh = chkSex.Checked ? "1" : "0";
                profile.Save();
                UserInfoBiz.InsertUserInfo(new UserInfoEntity()
                {
                    Username = user.UserName,
                    Fullname = profile.FullName,
                    LastLogin = DateTime.Now,
                    IsOnline = false,
                    IsActive = true,
                    Phone = profile.Phone,
                    RegisterDay = DateTime.Now.ToString("yyyy-MM-dd"),
                    UserGender = chkSex.Checked,
                    ViewCount = 0,
                    ViewTime = 0,
                    Priority = 1,
                    UserCode = UserInfoBiz.LastId().ToString("X6")
                });
                BicAjax.Alert(BicResource.GetValue("Message", "USER_UPDATE_SUCC"));
            }
            catch (Exception ex)
            {
                BicAjax.Alert(BicResource.GetValue("Message", "USER_UPDATE_FAIL") + "\n" + ex.Message);
            }
        }
        else
        {
            BicAjax.Alert(BicResource.GetValue("Message", "USER_REQUIRE_LOGIN"));
        }
    }

    protected void ImageButton1_Click(object sender, ImageClickEventArgs e)
    {
        SaveProfile();
    }
}