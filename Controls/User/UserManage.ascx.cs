using System;
using BIC.Utils;

public partial class Controls_User_UserManage : BIC.WebControls.BaseUIControl
{
    public string CurrentSelectedTab = string.Empty;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (IsPostBack) return;
        Include.CssAdd("~/Controls/User/CSS/UserManage.css");


        var status = BicSession.ToString("status");
        BicSession.SetValue("status", string.Empty);

        if (status != string.Empty && status != "1")
        {
            rtsUserManage.SelectedIndex = BicConvert.ToInt32(status) - 1;
            radMultiPage.SelectedIndex = BicConvert.ToInt32(status) - 1;
        }
        else
        {
            rtsUserManage.SelectedIndex = 0;
            radMultiPage.SelectedIndex = 0;
        }
        if (Session["backlist"] != null)
        {
            rtsUserManage.SelectedIndex = 2;
            radMultiPage.SelectedIndex = 2;
        }
        if (!string.IsNullOrEmpty(BicSession.ToString("SelectTabOrder")))
        {
            rtsUserManage.SelectedIndex = 2;
            radMultiPage.SelectedIndex = 2;
            BicSession.SetValue("SelectTabOrder", string.Empty);
        }
    }
}