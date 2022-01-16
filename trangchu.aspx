<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="trangchu.aspx.cs" Inherits="BTL_nhom10.trangchu" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Trang chủ</title>
    <link href="filecss/menu.css" type="text/css" rel="stylesheet" />
    <link href="filecss/DSlop.css" type="text/css" rel="stylesheet" />
    <link href="filecss/slide.css" type="text/css" rel="stylesheet" />
    <link href="./data/fontawesome-free-5.15.4-web/css/all.min.css" rel="stylesheet" />
</head>
<body>
    
    <header>
        <nav>
            <div class="first">
                <div class="hidden">
                    <img class="icon1" src="anh/list.png"/>
                </div>
                <ul class="nav" id="nav" runat="server">
                    <li><a href="trangchu.aspx"><i class="iconF fas fa-home"></i>Trang chủ</a></li>
                    <li><a href="DSlop.aspx"><i class="iconF fas fa-list-alt"></i>Danh sách lớp học</a></li>
                    <li><a href="timkiem.aspx"><i class="iconF fas fa-search"></i>Tìm kiếm</a></li>
                </ul>
             </div>
             <div class="last">
                <span id="ten" runat="server"><i class="iconF fas fa-user"></i>Tài khoản</span>
                <ul class="account" id="account" runat="server">
                </ul>
            </div>
        </nav>
    </header>
    <section class="containbody">
        <div class="container">
			<div class="slide change display"><img class="classimg" src="anh/slider1.jpg"/></div>
			<div class="slide change"><img class="classimg" src="anh/slider2.jpg"/></div>
			<div class="slide change"><img class="classimg" src="anh/slider3.jpg"/></div>
			<div>
                <a class="prev" onclick="plus(-1)">&#10094;</a>
                <a class="next" onclick="plus(1)">&#10095;</a>
            </div>
            <div class="classdot" style="text-align:center">
                <span class="dot" onclick="current(1)"></span> 
                <span class="dot" onclick="current(2)"></span> 
                <span class="dot" onclick="current(3)"></span> 
            </div>
		</div>
        <section class="fars">
        <h1>Các lớp đăng bài mới nhất</h1>
        <div id="sec1" class="flex_box" runat="server"></div>
        </section>
        <section class="fars">
        <h1>Các lớp sắp đăng bài</h1>
        <div id="sec2" class="flex_box" runat="server"></div>
        </section>
    </section>
    
    <footer>
        <aside class="aside">
            <h2><b>Trang web bài giảng học trực tuyến G-H</b></h2>
            <p class="footer">Trang web được thiết kế bởi 2 sinh viên chăm chỉ lớp 1810A05 - ĐH Mở HN</p>
        </aside>
        <section class="GH">
            <h3><b>Liên hệ</b></h3>
            <p class="footer"><img class="icon" src="anh/local.png"/>Địa chỉ:96 Định Công, Hoàng Mai, HN</p>
            <p class="footer"><img class="icon" src="anh/mail.png"/>Mail:tructuyen@gmail.com</p>
        </section>
        <section class="GH">
            <h3>Thành viên</h3>
            <p class="footer"><a href="https://www.facebook.com/profile.php?id=100005761937708" title="Facebook Giang"><img class="icon" src="anh/FB.png"/>Đỗ Văn Giang</a></p>
            <p class="footer"><a href="https://www.facebook.com/lehoang.nguyen.501/" title="Facebook Hoàng"><img class="icon" src="anh/FB.png"/>Nguyễn Lê Hoàng</a></p>
        </section>
    </footer>
    <script>
        var slideIndex = 1;
        showSlides(slideIndex);
        var do_alert = function () {
            showSlides(slideIndex += 1);
        };
        var cl=setInterval(do_alert, 5000);
        function plus(n) {
            showSlides(slideIndex += n);
            //clearInterval(cl);
        }
        function current(n) {
            showSlides(slideIndex = n);
            //clearInterval(cl);
        }
        function showSlides(n) {
            var i;
            var slides = document.getElementsByClassName("slide");
            var dots = document.getElementsByClassName("dot");
            if (n > slides.length) { slideIndex = 1 }
            if (n < 1) { slideIndex = slides.length }
            for (i = 0; i < slides.length; i++) {
                slides[i].style.display = "none";
            }
            for (i = 0; i < dots.length; i++) {
                dots[i].className = dots[i].className.replace(" active", "");
            }
            if (slideIndex != 1) {
                slides[0].style.display = "none";
            }
            slides[slideIndex - 1].style.display = "block";
            dots[slideIndex - 1].className += " active";
        }
    </script>
</body>
</html>