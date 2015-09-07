<%@ Application Language="C#" %>
<%@ Import Namespace="System.Web.Routing" %>
<script RunAt="server">

    public void ClearCache()
    {
        var keyList = new List<string>();
        var cacheEnum = HttpContext.Current.Cache.GetEnumerator();
        while (cacheEnum.MoveNext())
        {
            keyList.Add(cacheEnum.Key.ToString());
        }
        foreach (var key in keyList)
        {
            HttpContext.Current.Cache.Remove(key);
        }
    }

    private void RegisterRoutes(RouteCollection routes)
    {
        routes.Ignore("{resource}.axd/{*pathInfo}");

        //System
        routes.MapPageRoute("home", "{l}/{menu_name}.h{lv}.html", "~/Default.aspx");
        routes.MapPageRoute("home-back", "{l}/home.html", "~/Default.aspx");
        routes.MapPageRoute("home-2", "{l}/{menu_name}.h.html", "~/Default.aspx");
        routes.MapPageRoute("contact", "{l}/{menu_name}.c{lv}.html", "~/Contact.aspx");
        routes.MapPageRoute("contact-2", "{l}/{menu_name}.c.html", "~/Contact.aspx");
        routes.MapPageRoute("search", "{l}/{k}/search.html", "~/Searching.aspx");
        routes.MapPageRoute("court-register", "{l}/dang-ky-tuyen-sinh.html", "~/CourtRegister.aspx");
        routes.MapPageRoute("about-listing", "{l}/{menu_name}.al.html", "~/AboutListing.aspx");
        routes.MapPageRoute("about-detail", "{l}/{menu_name}.ad/{name}.html", "~/AboutDetails.aspx");

        //Booking
        routes.MapPageRoute("booking", "{l}/{menu_name}.bk.html", "~/BookRoom.aspx");

        //Điểm đến
        routes.MapPageRoute("Destination-Listing", "{l}/{menu_name}.de.html", "~/DestinationListing.aspx");
        routes.MapPageRoute("Destination-Detail", "{l}/{menu_name}.dd/{name}.i{id}.html", "~/DestinationDetail.aspx");
        
        //room
        routes.MapPageRoute("room-listing", "{l}/{menu_name}.rl.html", "~/RoomListing.aspx");
        routes.MapPageRoute("room-detail", "{l}/{menu_name}.rd/{name}.html", "~/RoomDetail.aspx");
        routes.MapPageRoute("Reservation", "{l}/BookRoom.html", "~/BookRoom.aspx");
        routes.MapPageRoute("ConfirmRoom", "{l}/ConfirmRoom.html", "~/ConfirmRoom.aspx");
        routes.MapPageRoute("SuccessRoom", "{l}/SuccessRoom.html", "~/SuccessRoom.aspx");
        
        //Tin tuc
        routes.MapPageRoute("article-detail", "{l}/{menu_name}.nd{lv}/{name}.i{id}.html", "~/ArticleDetail.aspx");
        routes.MapPageRoute("article-detail-2", "{l}/{menu_name}.nd/{name}.html", "~/ArticleDetail.aspx");
        routes.MapPageRoute("article-listing", "{l}/{menu_name}.nl{lv}.html", "~/ArticleListing.aspx");
        routes.MapPageRoute("article-listing-2", "{l}/{menu_name}.nl.html", "~/ArticleListing.aspx");
        routes.MapPageRoute("article-group", "{l}/{menu_name}.ng{lv}.html", "~/ArticleGroupListing.aspx");
        routes.MapPageRoute("article-group-2", "{l}/{menu_name}.ng.html", "~/ArticleGroupListing.aspx");
        routes.MapPageRoute("print-article", "{id}/print-article.html", "~/PrintArticle.aspx");

        //nghien cuu khoa hoc
        routes.MapPageRoute("scientific-listing", "{l}/{menu_name}.kh{lv}.html", "~/ScientificResearch.aspx");

        //chuyen gia tu van
        routes.MapPageRoute("consultantst-listing", "{l}/{menu_name}.tv{lv}.html", "~/Consultantst.aspx");
        routes.MapPageRoute("consultantst-listing-2", "{l}/{menu_name}.tv.html", "~/Consultantst.aspx");

        //chia sẻ kinh nghiệm
        routes.MapPageRoute("shareexp-listing", "{l}/{menu_name}.sl{lv}.html", "~/Sharingexperiences.aspx");
        routes.MapPageRoute("shareexp-listing-2", "{l}/{menu_name}.sl.html", "~/Sharingexperiences.aspx");
        routes.MapPageRoute("shareexp-detail", "{l}/{menu_name}.sd{lv}/{name}.i{id}.html", "~/SharingexperiencesDetail.aspx");
        routes.MapPageRoute("shareexp-detail-2", "{l}/{menu_name}.sd/{name}.html", "~/SharingexperiencesDetail.aspx");
        
        
        //Video
        routes.MapPageRoute("article-detail-video", "{l}/{menu_name}.vd{lv}/{name}.i{id}.html", "~/ArticleVideoDetail.aspx");
        routes.MapPageRoute("article-detail-video-2", "{l}/{menu_name}.vd/{name}.html", "~/ArticleVideoDetail.aspx");
        routes.MapPageRoute("article-listing-video", "{l}/{menu_name}.vl{lv}.html", "~/ArticleVideoListing.aspx");
        routes.MapPageRoute("article-listing-video-2", "{l}/{menu_name}.vl.html", "~/ArticleVideoListing.aspx");
        //Galery
        routes.MapPageRoute("gallery-listing", "{l}/{menu_name}.gl{lv}.html", "~/GalleryListing.aspx");
        routes.MapPageRoute("gallery-listing-2", "{l}/{menu_name}.gl.html", "~/GalleryListing.aspx");
        routes.MapPageRoute("gallery-detail", "{l}/{menu_name}.gd{lv}/{name}.i{id}.html", "~/GalleryDetail.aspx");
        routes.MapPageRoute("gallery-detail-2", "{l}/{menu_name}.gd/{name}.html", "~/GalleryDetail.aspx");

        //to Print article page, by HoangAn 7.7.2011
        routes.MapPageRoute("print-product", "{id}/print-product.html", "~/PrintProduct.aspx");
        //to Print product page, by HoangAn 7.7.2011

        routes.MapPageRoute("shareByEmail", "{l}/ShareByEmail.html", "~/ShareByEmail.aspx");
        //for Email button in TopToolbar, use for sharing ArticleDetail by Email, by HoangAn 30.06.2011

        //Sản phẩm
        routes.MapPageRoute("product-detail", "{l}/{menu_name}.pd{lv}/{name}.i{id}.html", "~/ProductDetail.aspx");
        routes.MapPageRoute("product-detail-2", "{l}/{menu_name}.pd/{name}.html", "~/ProductDetail.aspx");
        routes.MapPageRoute("product-group", "{l}/{menu_name}.pg{lv}.html", "~/ProductGroupListing.aspx");
        routes.MapPageRoute("product-group-2", "{l}/{menu_name}.pg.html", "~/ProductGroupListing.aspx");
        routes.MapPageRoute("product-listing", "{l}/{menu_name}.pl{lv}.html", "~/ProductListing.aspx");
        routes.MapPageRoute("product-listing-2", "{l}/{menu_name}.pl.html", "~/ProductListing.aspx");
        routes.MapPageRoute("product-listing-group-3", "{l}/{menu_name}.lgp.html", "~/ProductGroupListing2.aspx");

        // Tin ảnh
        routes.MapPageRoute("artileimage-listing", "{l}/{menu_name}.np{lv}.html", "~/ArticleAsImage.aspx");
        routes.MapPageRoute("artileimage-listing-2", "{l}/{menu_name}.np.html", "~/ArticleAsImage.aspx");
        
        routes.MapPageRoute("project-detail", "{l}/{menu_name}.pjd{lv}/{name}.i{id}.html", "~/ProjectDetail.aspx");
        routes.MapPageRoute("project-listing", "{l}/{menu_name}.pjl{lv}.html", "~/ProjectListing.aspx");

        //routes.MapPageRoute("thong-tin-dat-hang", "{l}/product-contact.html", "~/ThongtinDathang.aspx");
        routes.MapPageRoute("shoppingcartviewtoprint", "{l}/ShoppingCartToPrint.i{id}.html", "~/ShoppingCartViewToPrint.aspx");
		routes.MapPageRoute("shoppingcartviewtoprint1", "{l}/ShoppingCartToPrint1.i{id}.html", "~/ShoppingCartViewToPrint1.aspx");
        routes.MapPageRoute("shopping-cart", "{l}/{shopping-cart}.sc{id}.html", "~/ShoppingCart.aspx");
        //routes.MapPageRoute("shopping-cart", "{l}/shopping-cart.html", "~/ShoppingCart.aspx");

        routes.MapPageRoute("file-listing", "LF/{l}.{lv}/{menu_name}.html", "~/File.aspx");

        //Login and manage user
        routes.MapPageRoute("login", "{l}/login.html", "~/Login.aspx");
        routes.MapPageRoute("active", "{l}.{username}/{code}/active.html", "~/Login.aspx");
        routes.MapPageRoute("register", "{l}/register.html", "~/Register.aspx");
        routes.MapPageRoute("manage-account", "{l}/edit-profile.html", "~/EditProfile.aspx");
        routes.MapPageRoute("manage-account1", "{l}/edit-profile.i{id}.html", "~/EditProfile.aspx");
        routes.MapPageRoute("pass-recovery", "{l}/pass-recovery.html", "~/PasswordRecovery.aspx");
        routes.MapPageRoute("change-pass", "{l}/change-pass.html", "~/ChangePassword.aspx");

        //File download
        routes.MapPageRoute("document-listing", "{l}/{menu_name}.dl{lv}.html", "~/Download.aspx");
        routes.MapPageRoute("document-listing-2", "{l}/{menu_name}.dl.html", "~/Download.aspx");

        //FAQ
        routes.MapPageRoute("faq-listing", "{l}/{menu_name}.fl{lv}.html", "~/FAQ.aspx");
        routes.MapPageRoute("faq-listing1", "{l}/{menu_name}.fl.html", "~/FAQListing.aspx");

        //Comment
        routes.MapPageRoute("comment-listing", "{l}/{menu_name}.bll{lv}.html", "~/CommentListing.aspx");
        routes.MapPageRoute("comment-detail", "vi/binh-luan-chi-tiet.bld{lv}.i{id}.html", "~/CommentDetail.aspx");

        // He Thong Phan phoi
        routes.MapPageRoute("franchise-news", "{l}/{menu_name}.ll{lv}.html", "~/FranchiseNews.aspx");
        routes.MapPageRoute("franchise-news-2", "{l}/{menu_name}.ll.html", "~/FranchiseNews.aspx");

        // PhotoReview
        routes.MapPageRoute("PhotoReview", "{l}/{menu_name}.pr.html", "~/PhotoReviewListing.aspx");
        routes.MapPageRoute("PhotoReview-Detail", "{l}/{name}.i{id}.dpr.html", "~/PhotoReviewDetail.aspx");
        routes.MapPageRoute("PhotoReview-Write", "{l}/{name}.wpr.html", "~/ReviewProduct.aspx");
        routes.MapPageRoute("PhotoReviewEdit", "{l}/{name}.i{id}.epr.html", "~/PhotoReviewEdit.aspx");
        // Confirm payment
        routes.MapPageRoute("Confirm-Payment-List", "{l}/{menu_name}.pml.html", "~/ConfirmPaymentListing.aspx");
        routes.MapPageRoute("Confirm-Payment-Detail", "{l}/{menu_name}.pmd/{name}.html", "~/ConfirmPaymentDetail.aspx");
    }

    private void Application_Start(object sender, EventArgs e)
    {
        // Code that runs on application startup
        RegisterRoutes(RouteTable.Routes);
    }

    private void Application_End(object sender, EventArgs e)
    {
        //  Code that runs on application shutdown
    }
    private void Application_PreRequestHandlerExecute(object sender, EventArgs e)
    {
       
        var i = Request.Url.ToString().IndexOf("www.", StringComparison.Ordinal);
        if (i >= 8 || i == -1) return;
        Response.Clear();
        Response.Status = "301 Moved Permanently";
        Response.AddHeader("Location", Request.Url.ToString().Remove(i, 4));
        Response.End();
    }
    private void Application_Error(object sender, EventArgs e)
    {
        
    }

    private void Session_Start(object sender, EventArgs e)
    {
        var popup = new HttpCookie("popupadv");
        popup.Value = "1";
        popup.Expires = DateTime.Now.AddDays(1);
        //Session["popupadv"] = 1;
    }

    private void Session_End(object sender, EventArgs e)
    {
        
    }

</script>
