using System;
using System.Data;
using BIC.Data;
using BIC.Entity;
using BIC.WebControls;

public partial class Controls_Adv_Adv : BaseUIControl
{
    public int TypeOfAdv { get; set; }
    public int Name { get; set; }
    protected void Page_Load(object sender, EventArgs e)
    {
        if (IsPostBack) return;
        //mncaplogo.Text = "Hãng sản xuất khác";
        BindingAdv();
        if (Name == 1)
        {
            ltrName.Text = "Khách hàng";
        }
        else
        {
            ltrName.Text = "Đối tác";
        }

    }
    protected void BindingAdv()
    {
        var bicData = new BicGetData { TableName = "Adv" };
        bicData.Sorting.Add(new SortingItem("Priority", true));
        bicData.Selecting.Add(AdvEntity.FIELD_URL);
        bicData.Selecting.Add(AdvEntity.FIELD_IMAGEID);
        bicData.Selecting.Add(AdvEntity.FIELD_TARGET);
        bicData.Selecting.Add(AdvEntity.FIELD_DESCRIPTION);
        bicData.Conditioning.Add(new ConditioningItem("LanguageKey", Language, Operator.EQUAL, CompareType.STRING));
        bicData.Conditioning.Add(new ConditioningItem(AdvEntity.FIELD_TYPEOFADVID, TypeOfAdv.ToString(), Operator.EQUAL, CompareType.STRING));
        bicData.Conditioning.Add(new ConditioningItem(AdvEntity.FIELD_ISACTIVE, "1", Operator.EQUAL, CompareType.NUMERIC));
        DataTable data = bicData.GetAllData();
        dlSliderList.DataSource = data;
        dlSliderList.DataBind();

    }
}