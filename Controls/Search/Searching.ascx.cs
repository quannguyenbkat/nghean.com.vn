using System;
using BIC.Utils;
using BIC.WebControls;

public partial class Controls_Search_Searching : BaseUIControl
{
    protected void Page_Load(object sender, EventArgs e)
    {
        txtSearch.Attributes.Add("onkeypress", "return clickButton1(event,'" + ibtSearch.ClientID + "')");
        string sKey = BicRouting.GetRequestString("k", string.Empty);
        if(!IsPostBack)
        {
      
            txtSearch.Value = !string.IsNullOrEmpty(sKey) ? sKey : BicResource.GetValue("Keyword");
            hdKeyword.Value = BicResource.GetValue("Keyword");
        }
    }
    
    protected void ibtSearch_Click(object sender, EventArgs e)
    {
        if (txtSearch.Value == BicResource.GetValue("Keyword") || txtSearch.Value == string.Empty)
        BicAjax.Alert("Chưa có từ khóa nào");
        if (txtSearch.Value != BicResource.GetValue("Keyword") && txtSearch.Value != string.Empty)
            Response.Redirect(string.Format("{0}{1}/{2}/search.html", BicApplication.URLRoot, Language, BicConvert.ToString(txtSearch.Value)));
    }
}