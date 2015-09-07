
//if (typeof BIC == 'undefined') BIC = {};
//BIC.Gallery = {
//    Id: '',
//    lastIndex: 0,
//    Interval: '',
//    Init: function (id) {
//        this.Id = id;
//        this.FirstImage();
//        this.CarouFredSel(id);
//        this.ThumbClick();
//        $(document).ready(function () {
//            // Ẩn button của slide khi không có ảnh
//            if ($('#galerydt item').length = 0) $('.galerydt-prev,.galerydt-next').hide();
//        });
//        this.Interval = setInterval("BIC.Gallery.Round('" + this.Id + "')", 8000);
//    },
//    CarouFredSel: function (id) {

//        $(id).carouFredSel({
//            //auto: true,
//            items: 7,
//            auto: { play: true, items: 1, duration: 2500, pauseDuration: 3000, pauseOnHover: true },
//            //pagination: "#product-pag"
//            width: 558,
//            height:71,
//            left:0,
//            prev: "#galerydt-prev",
//            next: "#galerydt-next"
//        });

//    },
//    FirstImage: function () {
//        try {
//            $('#large-image a').html('<img src="' + $('#galerydt a.colorbox img').attr('src').replace('/thumb', "") + '" />');
//            $("#large-image img").fadeTo("slow", 0.7);
//            $("#large-image img").fadeTo("fast", 1);
//            $('.image0').addClass('thumbActive');
//        } catch (Error) {
//        }
//    },

//    Round: function (id) {
//        try {
//            var that = this;
//            var totalItem = $(id + ' .item .image').length;
           
//            if (totalItem > 0)
//                for (var i = 0; i < totalItem; i++) {
//                    var image = id + ' .item .image';
//                    if ($(image + i).hasClass('thumbActive')) {
                      
                     
//                        //alert($(".thumbActive").position().left);
//                        if ($(".thumbActive").position().left > 420 && $(".thumbActive").position().left < 520)
//                            {
                      
//                            $(id).trigger("next", {
//                                fx: "fade",
//                                duration: 300
//                            });
//                        }

//                        $(image + i).removeClass('thumbActive');

//                        if (i == (totalItem - 1)) {
                           
//                            i = -1;
//                            $(that.Id).trigger("slideTo", 0, {
//                                fx: "fade",
//                                duration: 500
//                            });
//                        }
//                        $(image + (i + 1)).addClass('thumbActive');
//                        var src = $(image + (i + 1) + " img").attr('src').replace('/thumb', "");
//                        $('#large-image a').html('<img src="' + src + '" />');
//                        $("#large-image img").fadeTo("slow", 0.7);
//                        $("#large-image img").fadeTo("fast", 1);
//                        break;
//                    }
//                }
//        } catch (error) {
//            alert(error);
//        }
//    },
//    ThumbClick: function () {
//        $('#galerydt a.colorbox').each(function () {
//            $(this).attr('href', '#1');
//        });
//        $('#galerydt a.colorbox img').click(function () {
//            $(BIC.Gallery.Id + ' .item .image').removeClass('thumbActive');
//            $(this).parent().parent().addClass('thumbActive');
//            var src = $(this).attr('src').replace('/thumb', "");
//            $('#large-image a').html('<img src="' + src + '" />');
//            $("#large-image img").fadeTo("slow", 0.7);
//            $("#large-image img").fadeTo("fast", 1);
//        });
//    }
//};

//BIC.Gallery.Init(".gallerylisting #galerydt");

