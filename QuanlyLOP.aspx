<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="QuanlyLOP.aspx.cs" Inherits="BTL_nhom10.WebForm3" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Quản lý lớp</title>
    <link href="filecss/QuanLy.css" type="text/css" rel="stylesheet" />
    <link href="filecss/menu.css" type="text/css" rel="stylesheet" />
    <link href=".data/fontawesome-free-5.15.4-web/css/all.min.css" rel="stylesheet" />
    <script type="text/javascript" src="filejs/QuanLylichlop.js"></script>
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
    <div class="grid containbody">
    <section class="s1 s_lop">
    <form class="form_QL" onsubmit="return checkloplich()" runat="server">
        <h1 class="tk">THÊM GIÁO TRÌNH</h1>
        <br />
                <label for="DropDownList1">Nhập ID lop:</label>
                <asp:DropDownList ID="DropDownList1" AutoPostBack="False" runat="server"></asp:DropDownList>
                <br />
                <label for="txtdate">Nhập ngày đăng bài:</label>
                <input type="date" id="txtdate" name="txtdate" value="" required="required"/>
                <label for="txtdate">Chọn file bài:</label>
                <asp:FileUpload ID="FileUpload1" required="required" runat="server" />
                <label for="txttitile">Nhập tên bài:</label>
                <input type="text" id="txttitile" name="txttitile" value="" required="required"/>
                <label for="txtinfor">Nhập thông tin bài:</label><br />
                <textarea name="txtinfor" id="txtinfor"></textarea>
            <div id="subbutton">
                <button  type="submit" class="btn" name="btnRegistlop" value="true">Thêm</button>
            </div>
    </form>
    </section>
    <section class="s2">
        <h1>Danh sách lớp - lịch học</h1>
        <table id="table4" runat="server" visible="false">
            <thead>
               <tr>
                <td><b>STT</b></td>
                <td><b>ID lớp</b></td>
                <td><b>Lịch học</b></td>
                <td><b>Link bài</b></td>
                <td><b>Chức năng</b></td>
               </tr>
            </thead>
        </table>
    </section>
    </div>
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
