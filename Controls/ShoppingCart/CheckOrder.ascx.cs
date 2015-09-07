using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Xml.Linq;
using BIC.Biz;
using BIC.Entity;
using BIC.Utils;
using BIC.Data;
using BIC.WebControls;

public partial class Controls_ShoppingCart_CheckOrder : BaseUIControl
{
    public int totalpoint;
    public double totalSavePoint;
    protected void Page_Load(object sender, EventArgs e)
    {
        GetDateTime();
        LoadData();
    }
    protected void GetDateTime()
    {
        string l = BicLanguage.CurrentLanguage;
        switch (l)
        {
            //case "ru":
            //    ltrTime.Text = "дата " + DateTime.Now.ToString("dd/MM/yyyy");
            //    break;
            //case "vi":
            //    ltrTime.Text = "Ngày " + DateTime.Now.ToString("dd/MM/yyyy");
            //    break;
            //default:
            //    ltrTime.Text = "Date " + DateTime.Now.ToString("MM/dd/yyyy");
            //    break;
        }
    }
    protected void LoadData()
    {
        if (Session["ThongTinNguoiDat"] == null)
            Response.Redirect(string.Format("{0}{1}/shopping-cart.sc{2}.html", BicApplication.URLRoot, BicLanguage.CurrentLanguage, "1"));
        else
        {
            string[] ttNguoiDat = (string[])Session["ThongTinNguoiDat"];
            ltrTen.Text = ttNguoiDat[0];
            ltrPhone.Text = ttNguoiDat[1];
            ltrAddress.Text = ttNguoiDat[5] + (ttNguoiDat[17] == "0" ? string.Empty : ", " + DistrictBiz.GetDistrictByID(BicConvert.ToInt32(ttNguoiDat[17])).DistrictName) + (ttNguoiDat[3] == "0" ? string.Empty : ", " + CityBiz.GetCityByID(BicConvert.ToInt32(ttNguoiDat[3])).CityName);
            //ltrCity.Text = ttNguoiDat[3];
            ltrEmail.Text = ttNguoiDat[4];
            ltrNgheNghiep.Text = ttNguoiDat[2];
            ltrNotes.Text = ttNguoiDat[6];
            lblAddressRecervedOrder.Text = ttNguoiDat[7];
            ltPayMethod.Text = ttNguoiDat[8];
            ltShippingMethod.Text = ttNguoiDat[9];
            ltrNip.Text = ttNguoiDat[10];
        }

        if (Session["ThongTinNguoiNhan"] == null)
            Response.Redirect(string.Format("{0}{1}/shopping-cart.sc{2}.html", BicApplication.URLRoot, BicLanguage.CurrentLanguage, "2"));
        else
        {
            string[] ttNguoiNhan = (string[])Session["ThongTinNguoiNhan"];
            ltrTen2.Text = ttNguoiNhan[0];
            ltrPhone2.Text = ttNguoiNhan[1];
            ltrAddress2.Text = ttNguoiNhan[5] + ", " + DistrictBiz.GetDistrictByID(BicConvert.ToInt32(ttNguoiNhan[8])).DistrictName + ", " + CityBiz.GetCityByID(BicConvert.ToInt32(ttNguoiNhan[3])).CityName;
            //ltrCity2.Text = ttNguoiNhan[3];
            ltrEmail2.Text = ttNguoiNhan[4];
            ltrNgheNghiep2.Text = ttNguoiNhan[2];
            ltrNotes2.Text = ttNguoiNhan[6];
            ltrNip2.Text = ttNguoiNhan[7];
        }

    }

    protected void lbtBack_OnClick(object sender, EventArgs e)
    {
        Response.Redirect(string.Format("{0}{1}/shopping-cart.sc{2}.html", BicApplication.URLRoot, BicLanguage.CurrentLanguage, "2"));
    }

    protected void lbtSend_OnClick(object sender, EventArgs e)
    {
        try
        {
            var cart = new Cart();
            if (Session["cart"] == null || ((Hashtable)Session["cart"]).Count <= 0) return;
            if (Session["ThongTinNguoiDat"] == null || Session["ThongTinNguoiNhan"] == null) return;

            var item = new OrderMenuEntity();
            string month = DateTime.Now.Month.ToString();
            string day = DateTime.Now.Day.ToString();
            var ordercode = string.Empty;

            var dh = new DataHelper();
            var dt = dh.ExecuteSQL("select max(OrderMenuID) from OrderMenu");
            int orderMenuIDNew = 0;
            if (dt.Rows.Count > 0)
                orderMenuIDNew = BicConvert.ToInt32(dt.Rows[0][0]) + 1;
            //item.OrderCode = month + "." + day + "-" + orderMenuIDNew; //Common.GetRandomTextCode(6);
            item.OrderCode = ordercode = DateTime.Now.ToString("yyyyMMdd") + string.Format("{0:D4}", orderMenuIDNew);
            item.OrderStatus = "Mới tiếp nhận";
            var user = Membership.GetUser(BicMemberShip.CurrentUserName);
            if (user != null)
            {
                if (user.ProviderUserKey != null) item.Customer = user.ProviderUserKey.ToString();
            }
            item.OrderTax = 23;
            if (Session["SubTotalAndDiscount"] != null)
            {
                var arr = (string[])Session["SubTotalAndDiscount"];
                item.OrderDiscount = Convert.ToDouble(arr[1]);

            }
            var ttNguoiDat = (string[])Session["ThongTinNguoiDat"];
            if (Session["TotalCart"] != null)
            {
                string tt = Session["TotalCart"].ToString();
                item.OrderSubTotal = Convert.ToDouble(tt) + BicConvert.ToDouble(ttNguoiDat[13]) - BicConvert.ToDouble(ttNguoiDat[12]);
            }
            item.CustomerIp = BicMemberShip.CurrentUserIP;
            item.PaymentMethod = ttNguoiDat[8];
            item.PaymentStatus = "Chưa thanh toán";
            item.ShippingMethod = ttNguoiDat[9];
            item.ShippingStatus = "Chưa giao hàng";
            item.BillingFullName = ttNguoiDat[0];
            item.BillingPhone = ttNguoiDat[1];
            item.BillingShippingAddress = ttNguoiDat[5];
            item.BillingCity = ttNguoiDat[3];
            item.BillingEmail = ttNguoiDat[4];
            item.BillingCompany = ttNguoiDat[2];
            item.InvoiceAddress = ttNguoiDat[7];
            item.OrderNote = ttNguoiDat[6];
            item.InvoiceTaxCode = ttNguoiDat[10];
            item.SavePoint = ProductBasket.SumPoints();
            item.UsePoint = BicConvert.ToDouble(ttNguoiDat[12]);
            item.OrderShippingFee = BicConvert.ToDouble(ttNguoiDat[13]);
            // Kiểu chuyển phát
            item.Column3 = ttNguoiDat[16];
            // Quận huyện
            item.BillingState = ttNguoiDat[17];

            var ttNguoiNhan = (string[])Session["ThongTinNguoiNhan"];
            item.ShippingFullName = ttNguoiNhan[0];
            item.ShippingEmail = ttNguoiNhan[4];
            item.ShippingPhone = ttNguoiNhan[1];
            item.ShippingAddress = ttNguoiNhan[5];
            item.ShippingCity = ttNguoiNhan[3];
            item.ShippingCompany = ttNguoiNhan[2];
            item.ShippingDate = DateTime.Now;
            item.Column1 = ttNguoiNhan[6];
            item.Column2 = ttNguoiNhan[7];
            item.ShippingDeliveredDate = DateTime.Now;
            //Quận Huyện
            item.ShippingState = ttNguoiNhan[8];
            OrderMenuBiz.InsertOrderMenu(item);

            if (Session["ProductList"] != null)
            {
                var lstProduct = Session["ProductList"] as List<ProductCart>;
                if (lstProduct != null && lstProduct.Count > 0)
                {
                    totalpoint = 0;
                    foreach (var productCart in lstProduct)
                    {
                        var orDetail = new OrderDetailEntity
                                           {
                                               OrderMenuID = item.OrderMenuID,
                                               Tax = 23,
                                               ProductCode = productCart.Code,
                                               ProductName = productCart.proName,
                                               ProductID = productCart.proID,
                                               SubTotal = Convert.ToDouble(productCart.Quantity) * Convert.ToDouble(productCart.Price),
                                               ProductPrice = Convert.ToDouble(productCart.Price),
                                               Total = productCart.Quantity
                                           };
                        totalpoint += Convert.ToInt32(productCart.ProductVat);
                        OrderDetailBiz.InsertOrderDetail(orDetail);
                    }
                }
            }

            //if (BicMemberShip.CurrentUserName != "")
            //{
            //    ProfileCommon profile = Profile.GetProfile(BicMemberShip.CurrentUserName);
            //    profile.Point = string.IsNullOrEmpty(profile.Point) ? totalpoint.ToString() : (BicConvert.ToInt32(profile.Point) + totalpoint).ToString();
            //    profile.Save();
            //}
            //cart.Clear();
            //Session["ThongTinNguoiDat"] = null;
            //Session["ThongTinNguoiNhan"] = null;
            //Response.Redirect(string.Format("{0}{1}/shopping-cart.sc{2}.html", BicApplication.URLRoot, BicLanguage.CurrentLanguage, "4"));

            string content = BicHtml.GetContents("~/Controls/ShoppingCart/ProductContact_" + BicLanguage.CurrentLanguage + ".htm");
            content = content.Replace("[DateTime]", DateTime.Now.ToString("dd/MM/yyyy"));
            content = content.Replace("[Domain]", BicXML.ToString("Domain", "MailConfig"));
            content = content.Replace("[Sender]", ltrTen.Text.Trim());
            content = content.Replace("[Email]", ltrEmail.Text);
            content = content.Replace("[Tel]", ltrPhone.Text);
            //content = content.Replace("[Subject]", "Đặt mua sản phẩm ");
            content = content.Replace("[Content]", ltrNotes.Text);
            content = content.Replace("[Address]", ltrAddress.Text);
            //content = content.Replace("[City]", ltrCity.Text);
            //content = content.Replace("[NgheNghiep]", ltrNgheNghiep.Text);
            //content = content.Replace("[Nip]", ltrNip.Text);

            //thông tin người nhận hàng
            content = content.Replace("[Sender2]", ltrTen2.Text.Trim());
            content = content.Replace("[Email2]", ltrEmail2.Text);
            content = content.Replace("[Tel2]", ltrPhone2.Text);
            content = content.Replace("[Content2]", ltrNotes2.Text);
            content = content.Replace("[Address2]", ltrAddress2.Text);
            //content = content.Replace("[City2]", ltrCity2.Text);
            //content = content.Replace("[NgheNghiep2]", ltrNgheNghiep2.Text);
            //content = content.Replace("[Nip2]", ltrNip2.Text);

            //if (Session["TongTienSauChietKhau"] != null)
            //    content = content.Replace("[Total]", Session["TongTienSauChietKhau"].ToString());
            //else
            //{
            //    if (Session["TotalCart"] != null)
            //        content = content.Replace("[Total]", Session["TotalCart"].ToString());//Session["TotalCart"] 
            //}

            content = content.Replace("[SaleMail]", BicXML.ToString("WebMasterEmail", "MailConfig"));

            content = content.Replace("[PaymentMethod]", ltPayMethod.Text);
            content = content.Replace("[ShippingMethod]", ltShippingMethod.Text);
            content = content.Replace("[ShippingFee]", BicConvert.ToDouble(ttNguoiDat[13]).ToString("##,###"));
            content = content.Replace("[UsePoint]", BicConvert.ToDouble(ttNguoiDat[12]).ToString("##,###"));

            string sRow = string.Empty;
            IEnumerator ie = ((Hashtable)Session["cart"]).Values.GetEnumerator();
            double totalVat = 0;
            double totalFullVat = 0;
            double total = 0;
            int itemcount = 0;
            while (ie.MoveNext())
            {

                var b = (ProductCart)ie.Current;
                itemcount += b.Quantity;
                var imageEntity = ImageBiz.GetImageByID(b.ImageId);
                string imagName = Request.Url.AbsoluteUri.Replace(Request.Url.AbsolutePath, "") + Request.ApplicationPath + "/FileUpload/Images/thumb/" +
                                  imageEntity.Name;
                var proEntity = ProductBiz.GetProductByID(b.proID);
                string linkUrl = "javascript:void(0)";
                if (proEntity != null)
                    linkUrl = string.Format("{0}{1}{2}{3}{4}", Request.Url.AbsoluteUri.Replace(Request.Url.AbsolutePath, "") + Request.ApplicationPath, Language + "/",
                                                      proEntity.MenuUserName + ".pd" + "/",
                                                      string.IsNullOrEmpty(proEntity.Url) ? BicEncoding.ConvertUnicodeToNoSignAndTag(proEntity.Title, "") : proEntity.Url, ".html");
                totalVat += Convert.ToDouble(Convert.ToDouble(b.ProductVat));
                totalFullVat += Convert.ToDouble(Convert.ToDouble(b.ProductVat)) +
                                Convert.ToDouble(Convert.ToDouble(b.Total));
                total += Convert.ToDouble(Convert.ToDouble(b.Quantity * Convert.ToDouble(b.Price)));
                sRow += string.Format(
                    "<tr>" +
                    "<td style=\"border: 1px solid #E2E2E2; line-height: 20px; padding: 8px;\">{0}</td>" +
                    "<td style=\"border: 1px solid #E2E2E2; line-height: 20px; padding: 8px;\">{5}</td>" +
                    "<td style=\"border: 1px solid #E2E2E2; line-height: 0px; padding: 1px; text-align: center;\">  " +
                    "<a href=" + linkUrl + "><img alt='avatar' src='{4}' width='38'/></a></td> " +
                    "<td style=\"text-align: center; color: #f15a22; border: 1px solid #E2E2E2; line-height: 20px; padding: 8px;\">{1}</td>" +
                    "<td style=\"border: 1px solid #E2E2E2; text-align: center; color: #f15a22;\">{2}</td>" +
                    "<td style=\"text-align: center; color: #f15a22;  border: 1px solid #E2E2E2; line-height: 20px; padding: 8px;\">{3}</td>" +
                    "</tr>",
                   "<a href=" + linkUrl + " style='text-decoration:none;'>" + b.proName + "</a>",
                    BicString.ToStringNO(b.Price),
                    b.Quantity,
                    BicString.ToStringNO(Convert.ToDouble(b.Quantity * Convert.ToDouble(b.Price)).ToString()), //#,##0
                      imagName,
                    b.Code
                    );
            }
            content = content.Replace("[Cart]", sRow);
            //content = content.Replace("[Total]", BicConvert.ToInt32(Session["TotalCart"].ToString()));//ToString("#,##0"));
            content = content.Replace("[Total]", string.Format("{0:N0}", total + BicConvert.ToDouble(ttNguoiDat[13]) - BicConvert.ToDouble(ttNguoiDat[12])));
            string phantram = LoadDataToPhanTram(totalFullVat, itemcount);
            content = content.Replace("[TongTien]", totalFullVat.ToString());

            if (BicEmail.SendToWebMaster(BicResource.GetValue("ShoppingCart", "SubjectMaster") + String.Format("{0: hh:mm tt - dd/MM/yyyy}", DateTime.Now), content, ltrEmail.Text, ltrTen.Text))
                if (BicEmail.SendToCustomer(ltrEmail.Text, BicResource.GetValue("ShoppingCart", "Subject") + BicXML.ToString("Domain", "MailConfig") + " - " + String.Format("{0: hh:mm tt - dd/MM/yyyy}", DateTime.Now), content))
                {
                    // Update diem thuong da su dung
                    if (!string.IsNullOrEmpty(BicMemberShip.CurrentUserName))
                    {
                        var profile = new ProfileCommon().GetProfile(BicMemberShip.CurrentUserName);
                        profile.CurrentPoint = string.Format("{0}", BicConvert.ToDouble(profile.CurrentPoint) + totalpoint);
                        profile.CurrentPoint = string.Format("{0}", BicConvert.ToDouble(profile.CurrentPoint) - BicConvert.ToDouble(ttNguoiDat[12]));
                        profile.UsedPoint = string.Format("{0}", BicConvert.ToDouble(profile.UsedPoint) + BicConvert.ToDouble(ttNguoiDat[12]));
                        profile.Save();
                    }
                    //System.Threading.Thread.Sleep(99999);
                    cart.Clear();
                    Session["ThongTinNguoiDat"] = null;
                    Session["ThongTinNguoiNhan"] = null;

                    if (BicSession.ToString("NganLuong") == "1")
                    {
                        if ((total + BicConvert.ToDouble(ttNguoiDat[13]) - BicConvert.ToDouble(ttNguoiDat[12])) <= 0)
                            Response.Redirect(string.Format("{0}{1}/shopping-cart.sc{2}.html", BicApplication.URLRoot, BicLanguage.CurrentLanguage, "4"));
                        else
                            Response.Redirect(string.Format("{0}{1}&product_name={2}&price={3}&return_url={4}&comments={5}", @"https://www.nganluong.vn/button_payment.php?receiver=", "lovelybeautyvn@gmail.com", ordercode, total + BicConvert.ToDouble(ttNguoiDat[13]) - BicConvert.ToDouble(ttNguoiDat[12]), string.Format("{0}/{1}/shopping-cart.sc{2}.html", Common.GetSiteUrl(), BicLanguage.CurrentLanguage, "4"), string.Empty));
                    }
                    else
                    {
                        Response.Redirect(string.Format("{0}{1}/shopping-cart.sc{2}.html", BicApplication.URLRoot, BicLanguage.CurrentLanguage, "4"));
                    }
                }
        }
        catch (Exception ex)
        {
            //rapContact.Alert(BicResource.GetValue("Message", "INVALID_EMAIL"));
            BIC.Handler.LogEvent.LogToEvent(ex.ToString());
        }
    }

    private string LoadDataToPhanTram(double tongTien, int soluong)
    {
        string phantram = "0";
        try
        {
            if (!string.IsNullOrEmpty(tongTien.ToString()))
            {
                string mappath = HttpContext.Current.Server.MapPath(string.Format("~/admin/XMLData/{0}{1}", "Promotion_", Language + ".xml"));
                XDocument xmldoc = XDocument.Load(mappath);
                IEnumerable<XElement> q =
                    from xe in xmldoc.Descendants("key") select xe;
                var dt = new DataTable();
                dt.Columns.Add("key");
                dt.Columns.Add("name");
                dt.Columns.Add("value");
                dt.Columns.Add("description");

                foreach (XElement xe in q)
                {
                    DataRow row = dt.NewRow();
                    row[0] = xe.Attribute("key").Value;
                    row[1] = xe.Attribute("name").Value;
                    row[2] = xe.Attribute("value").Value;
                    row[3] = xe.Attribute("description").Value;
                    dt.Rows.Add(row); // Thêm dòng mới vào dtb
                }
                foreach (DataRow row in dt.Rows)
                {
                    string[] s = row[1].ToString().Split('-');
                    if (s.Length > 0)
                    {
                        if (BicConvert.ToDecimal(s[1]) <= 100)
                        {
                            phantram = soluong > 9 ? row[2].ToString() : "0";
                            return phantram;
                        }
                        if (tongTien >= Convert.ToDouble(s[0]) && tongTien <= Convert.ToDouble(s[1]))
                        {
                            phantram = row[2].ToString();
                            return phantram;
                        }
                    }
                }
            }
        }
        catch (Exception)
        {
        }
        return phantram;
    }
}