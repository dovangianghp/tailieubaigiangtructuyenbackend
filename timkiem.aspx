<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="timkiem.aspx.cs" Inherits="BTL_nhom10.timkiem" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Tìm kiếm</title>
    <link href="filecss/DSlop.css" type="text/css" rel="stylesheet" />
    <link href="filecss/menu.css" type="text/css" rel="stylesheet" />
    <link href="filecss/timkiem.css" type="text/css" rel="stylesheet" />
    <script src="filejs/timkiem.js" type="text/javascript"></script>
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
        <form id="formTK1" onsubmit="return checktk()" method="post" runat="server">
            <label id="lbtk">Tìm kiếm</label><br />
            <input type="text" id="tk" name="tk1" value="" placeholder="Nhập loại lớp, giáo viên, id lớp cần tìm!"/>
            <button name="btntk" id="btntk1" value="true" runat="server">Tìm kiếm</button>
        </form>
        <section class="flex_box" id="sectiontk" runat="server">
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
</body>
</html>
