<%@ Control Language="C#" AutoEventWireup="true" CodeFile="GalleryDetail.ascx.cs"
    Inherits="Controls_GalleryDetail" %>
<%= Include.Gallery()%>
<%= Include.CarouFredSel()%>
<%@ Register Src="~/Controls/Gallery/OtherGalleryType.ascx" TagPrefix="uc2" TagName="OtherGalleryType" %>

<div class="gallerylisting">
    <div class="title"><h1> <asp:Label runat="server" ID="lbtitle"></asp:Label></h1></div>
    <div class="clear"></div>
    <div id="jslidernews1" class="lof-slidecontent" style="width:770px; height:490px;">
        <div class="border">
            <div class="main-slider-content" id="large-image" style="width:675px; height:340px;">
                <ul class="sliders-wrap-inner"> 
                    <asp:Repeater runat="server" ID="rptImgBig">
                        <ItemTemplate>
                            <li><img class="img_gallerydetail" src='<%# Eval("Url")%>' alt="" /></li> 
                        </ItemTemplate>
                    </asp:Repeater> 
                </ul>  	
                <div class="button-next"><span class="text">Next</span> </div>
                <div  class="button-previous"><span class="text">Previous</span></div>
            </div>
            </div>
        <div class="navigator-content">
           	    
            <div class="navigator-wrapper">
                <ul class="navigator-wrap-inner">
                    <asp:Repeater runat="server" ID="rptImageArr">
                        <ItemTemplate>
                            <li><img class="img_gallerydetail" src='<%# Eval("Url")%>' alt="" /></li> 
                        </ItemTemplate>
                    </asp:Repeater>         		
                </ul>
            </div>
                  
        </div> 
    </div>
</div>

<uc2:OtherGalleryType runat="server" ID="OtherGalleryType" />
<link href="<%= Page.ResolveUrl("~/Controls/Gallery/style1.css") %>" rel="stylesheet" />
<script type="text/javascript" src='<%= Page.ResolveUrl("~/Controls/Gallery/Gallery.js") %>'></script>
<script type="text/javascript" src='<%= Page.ResolveUrl("~/Controls/Gallery/jquery.easing.js") %>'></script>
<script type="text/javascript" src='<%= Page.ResolveUrl("~/Controls/Gallery/script.js") %>'></script>


<script type="text/javascript">
    $(document).ready(function () {
        // buttons for next and previous item						 
        var buttons = {
            previous: $('#jslidernews1 .button-previous'),
            next: $('#jslidernews1 .button-next')
        };
        $('#jslidernews1').lofJSidernews({
            interval: 4000,
            direction: 'opacitys',
            easing: 'easeInOutExpo',
            duration: 1200,
            auto: true,
            maxItemDisplay: 3,
            navPosition: 'horizontal', // horizontal
            navigatorHeight: 32,
            navigatorWidth: 157,
            mainWidth: 748,
            buttons: buttons
        });
    });
</script>