<%@ Page Language="C#" AutoEventWireup="true" CodeFile="GalleryForVideo.aspx.cs" Inherits="admin_Components_ImageGallery_GalleryForVideo" %>

<%@ Register Src="ImageManagerForVideo.ascx" TagName="ImageManagerForVideo" TagPrefix="uc1" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
    <head runat="server">
        <style type="text/css">body {margin:0px;}</style>
    </head>
    <body>
        <form id="form1" runat="server">
            <div>
                <uc1:ImageManagerForVideo ID="ImageManagerForVideo1" runat="server" />
            </div>
        </form>
    </body>
</html>