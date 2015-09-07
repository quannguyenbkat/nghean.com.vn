using System;
using BIC.Utils;
using BIC.WebControls;

public partial class ShoppingCart : BasePage
{
    public int id;
    protected void Page_Load(object sender, EventArgs e)
    {
        Page.Header.DataBind();
        LoadControl();
    }
    protected void LoadControl()
    {
        id = BicRouting.GetRequestString("id", 0);
        switch (id)
        {
            case 1:
                phCart.Controls.Add(Page.LoadControl(Page.ResolveUrl("~") + "Controls/ShoppingCart/ProductBasket.ascx"));
                lbtTitle.Text = BicResource.GetValue("ShoppingCart", "GioHangDetail");
                break;
            case 2:
                phCart.Controls.Add(Page.LoadControl(Page.ResolveUrl("~") + "Controls/ShoppingCart/ThongtinDathang.ascx"));
                lbtTitle.Text = BicResource.GetValue("ShoppingCart", "TTDatHang");
                break;
            case 3:
                phCart.Controls.Add(Page.LoadControl(Page.ResolveUrl("~") + "Controls/ShoppingCart/CheckOrder.ascx"));
                lbtTitle.Text = BicResource.GetValue("ShoppingCart", "XacNhanDonHang");
                break;
            case 4:
                phCart.Controls.Add(Page.LoadControl(Page.ResolveUrl("~") + "Controls/ShoppingCart/MessageSuccess.ascx"));
                lbtTitle.Text = BicResource.GetValue("ShoppingCart", "TitleSuccess");
                //Response.AppendHeader("Refresh", "5; URL=" + ResolveUrl("/vi/edit-profile.html"));
                break;
            default:
                 phCart.Controls.Add(Page.LoadControl(Page.ResolveUrl("~") + "Controls/ShoppingCart/ProductBasket.ascx"));
                 lbtTitle.Text = BicResource.GetValue("ShoppingCart", "GioHang");
                break;
        }
    }
}