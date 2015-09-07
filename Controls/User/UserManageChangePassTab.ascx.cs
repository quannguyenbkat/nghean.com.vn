using System;
using BIC.Utils;
using BIC.WebControls;
using System.Web.Security;

public partial class Controls_User_UserManageChangePassTab : BaseUIControl
{
    protected void btnChangePass_Click(object sender, EventArgs e)
    {
        if (txtNewPassword.Text.Length > 3)
        {
            if ((txtNewPassword.Text == txtConfirmNewPassword.Text))
            {
                var username = BicSession.ToString("UsernameWasLoggedIn");
                if (username != null)
                {
                    var user = Membership.GetUser(username);
                    BicAjax.Alert(user.ChangePassword(txtCurrentPassword.Text, txtNewPassword.Text)
                                      ? "Thay đổi mật khẩu thành công !"
                                      : "Mật khẩu cũ không chính xác !");
                }
                else
                    BicAjax.Alert("Bạn chưa đăng nhập !");
            }
            else
                BicAjax.Alert("Mật khẩu xác nhận không phù hợp !");
        }
        else
            BicAjax.Alert("mật khẩu quá ngắn!");
    }
}