using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.Routing;
using System.Web.Security;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using BIC.Biz;
using BIC.Entity;
using BIC.Utils;

public class PermissionHelper
{
    public static bool ByMenuUser(int menuid)
    {
        bool result = false;
        string currentUser = BicMemberShip.CurrentUserName;
        if (menuid == 0) return true;
        MenuUserEntity menuEntity = MenuUserBiz.GetMenuUserByID(menuid);
        if (string.IsNullOrEmpty(menuEntity.UserName)) return true;
        string[] arrUserdoc = BicString.SplitComma(menuEntity.UserName);
        if (Roles.GetRolesForUser(currentUser).Length > 0)
        {
            IEnumerable<string> searchGroup = from s in arrUserdoc
                                              where
                                                  s.ToLower().Equals("g:" +
                                                                     Roles.GetRolesForUser(currentUser)[0].ToLower())
                                              select s;
            IEnumerable<string> searchUser = from s in arrUserdoc
                                             where s.ToLower().Equals(currentUser.ToLower())
                                             select s;
            if (searchUser.Count() > 0 || searchGroup.Count() > 0) return true;
        }
        else
        {
            IEnumerable<string> searchUser = from s in arrUserdoc
                                             where s.ToLower().Equals(currentUser.ToLower())
                                             select s;
            if (searchUser.Count() > 0) return true;
        }
        return result;
    }

    public static bool ByMenuUsers(string menus)
    {
        bool result = false;
        string[] arrMenuId = BicString.SplitComma(menus);
        foreach (string s in arrMenuId)
        {
            if (ByMenuUser(BicConvert.ToInt32(s))) result = true;
        }
        return result;
    }
}

public class FomatOfString
{
    public static string FDate()
    {
        string result = string.Empty;
        string lang = BicLanguage.CurrentLanguage;
        switch (lang.ToLower())
        {
            case "vi":
                result = "{0:(dd/MM/yyyy)}";
                break;
            case "en":
                result = "{0:(MM/dd/yyyy)}";
                break;
            default:
                result = "{0:(MM/dd/yyyy)}";
                break;
        }
        return result;
    }
}

public class HtmlHelper
{
    public static void WriteMetaTag(HtmlHead pHead, string pName, string pContent)
    {
        for (int i = pHead.Controls.Count - 1; i >= 0; i--)
        {
            if (pHead.Controls[i] is HtmlMeta)
            {
                var thisMetaTag = (HtmlMeta)pHead.Controls[i];
                if (thisMetaTag.Name == pName)
                {
                    pHead.Controls.RemoveAt(i);
                }
            }
        }
        var metaTag = new HtmlMeta { Name = pName, Content = pContent };
        pHead.Controls.Add(metaTag);
    }
}

public static class RouteCollectionExtensions
{
    public static Route MapRouteWithName(this RouteCollection routes,
                                         string name, string routeUrl, string directUrl)
    {
        Route route = routes.MapPageRoute(name, routeUrl, directUrl);
        route.DataTokens = new RouteValueDictionary { { "RouteName", name } };
        return route;
    }
}

namespace BIC.Utils
{
    public class Common
    {
        public static string convertToUnSign3(string s)
        {
            var regex = new Regex("\\p{IsCombiningDiacriticalMarks}+");
            string temp = s.Normalize(NormalizationForm.FormD);
            return
                regex.Replace(temp, String.Empty)
                     .Replace('\u0111', 'd')
                     .Replace('\u0110', 'D')
                     .Replace(" ", "-")
                     .Replace(",", string.Empty)
                     .Replace(":", string.Empty)
                     .Replace("\"", string.Empty)
                     .Replace("/", string.Empty)
                     .Replace("?", string.Empty)
                     .Replace("%", string.Empty)
                     .Replace(">", string.Empty)
                     .Replace("<", string.Empty)
                     .Replace("'", string.Empty)
                     .Replace("&", string.Empty)
                     .Replace("+", string.Empty)
                     .Replace("#", string.Empty)
                     .Replace("(", string.Empty)
                     .Replace(")", string.Empty)
                     .Replace("*", string.Empty)
                     .Replace("^", string.Empty)
                     .Replace("$", string.Empty)
                     .Replace("@", string.Empty)
                     .Replace("!", string.Empty)
                     .Replace("{", string.Empty)
                     .Replace("}", string.Empty)
                     .Replace("|", string.Empty)
                     .Replace(";", string.Empty)
                     .Replace("`", string.Empty)
                     .Replace("~", string.Empty).ToLower();
        }
        public static string GetSiteUrl()
        {
            return HttpContext.Current.Request.Url.Scheme + Uri.SchemeDelimiter + HttpContext.Current.Request.Url.Host + (HttpContext.Current.Request.Url.IsDefaultPort ? "" : ":" + HttpContext.Current.Request.Url.Port);
        }

        public static string BuildLinkPageList(string languageKey, string menuName, string prefix)
        {
            return string.Format("{0}/{1}/{2}.{3}.html", GetSiteUrl(), languageKey, menuName, prefix);
        }

        public static string BuildLinkPageDetail(string languageKey, string menuName, string prefix, string name)
        {
            return string.Format("{0}/{1}/{2}.{3}/{4}.html", GetSiteUrl(), languageKey, menuName, prefix, name);
        }

        //Danh sach cac quoc gia tren the gioi
        private static readonly string[] Countries = new[]
                                                          {
                                                              "Afghanistan", "Albania", "Algeria", "American Samoa",
                                                              "Andorra",
                                                              "Angola", "Anguilla", "Antarctica", "Antigua And Barbuda",
                                                              "Argentina",
                                                              "Armenia", "Aruba", "Australia", "Austria", "Azerbaijan",
                                                              "Bahamas", "Bahrain", "Bangladesh", "Barbados", "Belarus",
                                                              "Belgium", "Belize", "Benin", "Bermuda", "Bhutan",
                                                              "Bolivia", "Bosnia Hercegovina", "Botswana",
                                                              "Bouvet Island", "Brazil",
                                                              "Brunei Darussalam", "Bulgaria", "Burkina Faso", "Burundi"
                                                              , "Byelorussian SSR",
                                                              "Cambodia", "Cameroon", "Canada", "Cape Verde",
                                                              "Cayman Islands",
                                                              "Central African Republic", "Chad", "Chile", "China",
                                                              "Christmas Island",
                                                              "Cocos (Keeling) Islands", "Colombia", "Comoros", "Congo",
                                                              "Cook Islands",
                                                              "Costa Rica", "Cote D'Ivoire", "Croatia", "Cuba", "Cyprus"
                                                              ,
                                                              "Czech Republic", "Czechoslovakia", "Denmark", "Djibouti",
                                                              "Dominica",
                                                              "Dominican Republic", "East Timor", "Ecuador", "Egypt",
                                                              "El Salvador",
                                                              "England", "Equatorial Guinea", "Eritrea", "Estonia",
                                                              "Ethiopia",
                                                              "Falkland Islands", "Faroe Islands", "Fiji", "Finland",
                                                              "France",
                                                              "Gabon", "Gambia", "Georgia", "Germany", "Ghana",
                                                              "Gibraltar", "Great Britain", "Greece", "Greenland",
                                                              "Grenada",
                                                              "Guadeloupe", "Guam", "Guatemela", "Guernsey", "Guiana",
                                                              "Guinea", "Guinea-Bissau", "Guyana", "Haiti",
                                                              "Heard Islands",
                                                              "Honduras", "Hong Kong", "Hungary", "Iceland", "India",
                                                              "Indonesia", "Iran", "Iraq", "Ireland", "Isle Of Man",
                                                              "Israel", "Italy", "Jamaica", "Japan", "Jersey",
                                                              "Jordan", "Kazakhstan", "Kenya", "Kiribati",
                                                              "Korea, South",
                                                              "Korea, North", "Kuwait", "Kyrgyzstan",
                                                              "Lao People's Dem. Rep.", "Latvia",
                                                              "Lebanon", "Lesotho", "Liberia", "Libya", "Liechtenstein",
                                                              "Lithuania", "Luxembourg", "Macau", "Macedonia",
                                                              "Madagascar",
                                                              "Malawi", "Malaysia", "Maldives", "Mali", "Malta",
                                                              "Mariana Islands", "Marshall Islands", "Martinique",
                                                              "Mauritania", "Mauritius",
                                                              "Mayotte", "Mexico", "Micronesia", "Moldova", "Monaco",
                                                              "Mongolia", "Montserrat", "Morocco", "Mozambique",
                                                              "Myanmar",
                                                              "Namibia", "Nauru", "Nepal", "Netherlands",
                                                              "Netherlands Antilles",
                                                              "Neutral Zone", "New Caledonia", "New Zealand",
                                                              "Nicaragua", "Niger",
                                                              "Nigeria", "Niue", "Norfolk Island", "Northern Ireland",
                                                              "Norway",
                                                              "Oman", "Pakistan", "Palau", "Panama", "Papua New Guinea",
                                                              "Paraguay", "Peru", "Philippines", "Pitcairn", "Poland",
                                                              "Polynesia", "Portugal", "Puerto Rico", "Qatar", "Reunion"
                                                              ,
                                                              "Romania", "Russian Federation", "Rwanda", "Saint Helena",
                                                              "Saint Kitts",
                                                              "Saint Lucia", "Saint Pierre", "Saint Vincent", "Samoa",
                                                              "San Marino",
                                                              "Sao Tome and Principe", "Saudi Arabia", "Scotland",
                                                              "Senegal", "Seychelles",
                                                              "Sierra Leone", "Singapore", "Slovakia", "Slovenia",
                                                              "Solomon Islands",
                                                              "Somalia", "South Africa", "South Georgia", "Spain",
                                                              "Sri Lanka",
                                                              "Sudan", "Suriname", "Svalbard", "Swaziland", "Sweden",
                                                              "Switzerland", "Syrian Arab Republic", "Taiwan",
                                                              "Tajikista", "Tanzania",
                                                              "Thailand", "Togo", "Tokelau", "Tonga",
                                                              "Trinidad and Tobago",
                                                              "Tunisia", "Turkey", "Turkmenistan",
                                                              "Turks and Caicos Islands", "Tuvalu",
                                                              "Uganda", "Ukraine", "United Arab Emirates",
                                                              "United Kingdom", "United States",
                                                              "Uruguay", "Uzbekistan", "Vanuatu", "Vatican City State",
                                                              "Venezuela",
                                                              "Vietnam", "Virgin Islands", "Wales", "Western Sahara",
                                                              "Yemen",
                                                              "Yugoslavia", "Zaire", "Zambia", "Zimbabwe"
                                                          };

        public static void GetCountries(DropDownList ddl)
        {
            var countries = new StringCollection { BicResource.GetValue("SELECT_CAPTION") };
            countries.AddRange(Countries);
            ddl.DataSource = countries;
            ddl.DataBind();
        }

        public static void GetCountries(HtmlSelect ddl)
        {
            var countries = new StringCollection { BicResource.GetValue("SELECT_CAPTION") };
            countries.AddRange(Countries);
            ddl.DataSource = countries;
            ddl.DataBind();
        }

        //Phương thức nạp ảnh theo giá trị logic
        public static void ImageButtonIconCheck(ImageButton ibtnImage, bool bIsChecked, string sImageNameOn,
                                                string sImageNameOff)
        {
            if (bIsChecked)
            {
                ibtnImage.ImageUrl = BicApplication.URLPath("Admin/Images/Icons/" + sImageNameOn);
                ibtnImage.ToolTip = @"Trực tuyến";
            }
            else
            {
                ibtnImage.ImageUrl = BicApplication.URLPath("Admin/Images/Icons/" + sImageNameOff);
                ibtnImage.ToolTip = @"Ngoại tuyến";
            }
        }

        public static void ImageButtonIconCheck(Image imgImage, bool bIsChecked, string sImageNameOn,
                                                string sImageNameOff)
        {
            if (bIsChecked)
            {
                imgImage.ImageUrl = BicApplication.URLPath("Admin/Images/Icons/" + sImageNameOn);
                imgImage.ToolTip = @"Trực tuyến";
            }
            else
            {
                imgImage.ImageUrl = BicApplication.URLPath("Admin/Images/Icons/" + sImageNameOff);
                imgImage.ToolTip = @"Ngoại tuyến";
            }
        }

        //Kiểm tra trạng thái của ảnh hiện thị
        public static bool ImageButtonIconChecked(ImageButton ibtnImage, string sImageNameOn, string sImageNameOff)
        {
            if (ibtnImage.ImageUrl == BicApplication.URLPath("Admin/Images/Icons/" + sImageNameOff))
            {
                ibtnImage.ImageUrl = BicApplication.URLPath("Admin/Images/Icons/" + sImageNameOn);
                ibtnImage.ToolTip = @"Trực tuyến";
                return true;
            }
            else
            {
                ibtnImage.ImageUrl = BicApplication.URLPath("Admin/Images/Icons/" + sImageNameOff);
                ibtnImage.ToolTip = @"Ngoại tuyến";
                return false;
            }
        }

        //Checkbox cho DataView
        public static string CheckBoxImage(TableCell cell, string sImageNameOn, string sImageNameOff)
        {
            string sImage = string.Empty;
            string src = string.Empty;
            string sText = cell.Text.Substring(6, (cell.Text.Length - 13));
            string sAlt = string.Empty;
            if (sText.Equals("True"))
            {
                src = BicApplication.URLPath("Admin/Images/Icons/" + sImageNameOn);
                sAlt = "Trực tuyến";
            }
            else
            {
                src = BicApplication.URLPath("Admin/Images/Icons/" + sImageNameOff);
                sAlt = "Ngoại tuyến";
            }
            sImage = string.Format("<img runat='server' id='{0}' src='{1}' alt='{2}'/>", sText, src, sAlt);
            return sImage;
        }

        public static string CheckBoxImageGroup(TableCell cell, string sImageNameOn, string sImageNameOff)
        {
            var sImage = string.Empty;
            var src = string.Empty;
            var sText = cell.Text;
            var sAlt = string.Empty;
            if (sText.Equals("True"))
            {
                src = BicApplication.URLPath("Admin/Images/Icons/" + sImageNameOn);
                sAlt = "Trực tuyến";
            }
            else
            {
                src = BicApplication.URLPath("Admin/Images/Icons/" + sImageNameOff);
                sAlt = "Ngoại tuyến";
            }
            sImage = string.Format("<img runat='server' id='{0}' src='{1}' alt='{2}'/>", sText, src, sAlt);
            return sImage;
        }
        public static string SplitContent(object content, int maxlen)
        {
            if (content == null) return "";
            var result = content.ToString();
            if (content.ToString().Length <= maxlen) return result;
            result = content.ToString().Substring(0, maxlen);
            result = result.Substring(0, result.LastIndexOf(" ")) + " ...";
            return result;
        }
    }
}