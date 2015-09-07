using System;
using BIC.Utils;

public partial class Controls_GoogleMap_GoogleMaps : System.Web.UI.UserControl
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (IsPostBack) return;
        hdTitle.Value = BicXML.ToString("1","title", "GoogleMaps");
        hdDescription.Value = BicXML.ToString("1", "description", "GoogleMaps");
        hdLat.Value = BicXML.ToString("1", "Lat", "GoogleMaps");
        hdLog.Value = BicXML.ToString("1", "Log", "GoogleMaps");
        hdZoom.Value = BicXML.ToString("1", "zoom", "GoogleMaps");
    }
}