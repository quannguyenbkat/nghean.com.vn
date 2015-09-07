using System;
using System.Data;
using System.Data.SqlClient;
using System.Web;
using BIC.Biz;
using BIC.Data;
using BIC.Entity;
using BIC.Utils;

/// <summary>
/// Summary description for Seo
/// </summary>
public class Seo : DataAccess
{
   

    public SeoEntity GetSeoInfo(string defaultImageLink)
    {
        string menuUserName;
        string itemName;
        string ogType = "product";
        var currentUrl = HttpContext.Current.Request.Url.AbsoluteUri;
        var typeOfItem = string.Empty;

        menuUserName = BicRouting.GetRequestString("menu_name","");
        itemName = BicRouting.GetRequestString("name", "");
        if (!currentUrl.Contains("html"))
            currentUrl = BicXML.ToString("FacebookSiteName", "SearchEngine");//currentUrl.Replace("/default.aspx", "");

        if (currentUrl.Contains(".pl") || currentUrl.Contains(".nl") || currentUrl.Contains(".h.") || currentUrl.Contains(".c.") || currentUrl.Contains(".gl") || currentUrl.Contains(".vl"))
        {
            typeOfItem = "menu";
            
        }
        else
        {
            if (currentUrl.Contains(".nd") || currentUrl.Contains(".vd") || currentUrl.Contains(".gd"))
            {
                typeOfItem = "article";
                ogType = "article";
            }
            else
            {
                if (currentUrl.Contains(".pd"))
                {
                    typeOfItem = "product";
                    ogType = "product";
                }
            }
        }
        var seoEntity = new SeoEntity();
        using (var cn = new SqlConnection(BicWebConfig.ConnectionString))
        {
            var cmd = new SqlCommand("GetSeoInfo", cn) { CommandType = CommandType.StoredProcedure };
            cmd.Parameters.Add("@TypeOfItem", SqlDbType.NVarChar).Value = typeOfItem;
            cmd.Parameters.Add("@MenuUserName", SqlDbType.NVarChar).Value = menuUserName;
            cmd.Parameters.Add("@ItemName", SqlDbType.NVarChar).Value = itemName;
            cmd.Parameters.Add("@DefaultImageLink", SqlDbType.NVarChar).Value = defaultImageLink;
            cn.Open();
            IDataReader reader = ExecuteReader(cmd, CommandBehavior.SingleRow);
            if (reader.Read())
            {
                seoEntity = GetSeoFromReader(reader);
            }
            cn.Close();
        }

        if (seoEntity.MetaTitle == string.Empty)
        {
            seoEntity.MetaTitle = BicXML.ToString("Title", "SearchEngine");
        }

        if (seoEntity.MetaDescription == string.Empty)
        {
            seoEntity.MetaDescription = BicPage.Page.Server.HtmlDecode(BicXML.ToString("Description", "SearchEngine"));
        }

        if (seoEntity.MetaKeyword == string.Empty)
        {
            seoEntity.MetaKeyword = BicPage.Page.Server.HtmlDecode(BicXML.ToString("Keywords", "SearchEngine"));
        }
        seoEntity.Url = currentUrl;
        seoEntity.Type = ogType;

        return seoEntity;
    }


    private SeoEntity GetSeoFromReader(IDataReader reader)
    {
        return new SeoEntity(reader["MetaDescription"].ToString().Trim(), reader["MetaKeyword"].ToString().Trim(), reader["MetaTitle"].ToString().Trim(), reader["ImageLink"].ToString().Trim());
    }

}

public class SeoEntity
{
    #region Contructors

    public SeoEntity()
    {
    }

    public SeoEntity(string metaDescription, string metaKeyword, string metaTitle, string imageLink)
    {
        MetaDescription = metaDescription;
        MetaKeyword = metaKeyword;
        MetaTitle = metaTitle;
        ImageLink = imageLink;
    }

    #endregion


    #region MetaDescription

    private string _metaDescription = String.Empty;

    /// <summary>
    /// Gets or sets MetaDescription
    /// </summary>
    public string MetaDescription
    {
        get { return _metaDescription; }
        set { _metaDescription = value; }
    }

    #endregion

    #region MetaKeyword

    private string _metaKeyword = String.Empty;

    /// <summary>
    /// Gets or sets MetaKeyword
    /// </summary>
    public string MetaKeyword
    {
        get { return _metaKeyword; }
        set { _metaKeyword = value; }
    }

    #endregion

    #region MetaTitle

    private string _metaTitle = String.Empty;

    /// <summary>
    /// Gets or sets MetaTitle
    /// </summary>
    public string MetaTitle
    {
        get { return _metaTitle; }
        set { _metaTitle = value; }
    }

    #endregion

    #region ImageLink

    private string _imageLink = String.Empty;

    /// <summary>
    /// Gets or sets ImageLink
    /// </summary>
    public string ImageLink
    {
        get { return _imageLink; }
        set { _imageLink = value; }
    }

    #endregion

    #region Url

    private string _url = String.Empty;

    /// <summary>
    /// Gets or sets ImageLink
    /// </summary>
    public string Url
    {
        get { return _url; }
        set { _url = value; }
    }

    #endregion

    #region Type

    private string _type = String.Empty;

    /// <summary>
    /// Gets or sets ImageLink
    /// </summary>
    public string Type
    {
        get { return _type; }
        set { _type = value; }
    }

    #endregion
}