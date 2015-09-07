using System;
using System.Data;
using BIC.Biz;
using BIC.Data;
using BIC.Entity;
using BIC.Utils;
using BIC.WebControls;

public partial class Controls_Product_ProductRef : BaseUIControl
{
    public int ProductId { get; set; }
    public string MenuUserId { get; set; }
    public string chuoi = "";
    public int Point { get; set; } 

    protected void Page_Load(object sender, EventArgs e)
    {
        if (IsPostBack) return;

        lvProdRef.MenuUserId = MenuUserId;
        lvProdRef.IgnoreProductId = ProductId.ToString();
        lvProdRef.ProductId = ProductId;
        lvProdRef.PageSize = 10;
        lvProdRef.LoadData();
        Visible = lvProdRef.Items.Count > 0;
    }
}