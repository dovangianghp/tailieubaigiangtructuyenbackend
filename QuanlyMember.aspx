<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="QuanlyMember.aspx.cs" Inherits="BTL_nhom10.QuanlyMember" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Quản lý tài khoản</title>
    <link href="filecss/QuanLy.css" type="text/css" rel="stylesheet" />
    <link href="filecss/menu.css" type="text/css" rel="stylesheet" />
    <link href=".data/fontawesome-free-5.15.4-web/css/all.min.css" rel="stylesheet" />
    <script type="text/javascript" src="filejs/regist.js"></script>
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
    <section class="s1 s_QLDS">
        
    <form class="form_QL" onsubmit="return check1()" runat="server">
        <h1 class="tk">THÊM TÀI KHOẢN</h1>
        <label for="txtMaila">Nhập tên người dùng (email):</label>
                <input type="email" id="txtMail" name="txtMaila" value="" />
                <label for="txtPassa">Nhập mật khẩu:</label>
                <input type="password" id="txtPass" name="txtPassa" value="" />
                <label for="txtRe_Passa">Nhập lại mật khẩu:</label>
                <input type="password" id="txtRe_Pass" name="txtRe_Passa" value="" />
                <label for="txtFullNamea">Nhập họ và tên:</label>
                <input type="text" id="txtFullName" name="txtFullNamea" value="" />
                <label>Đối tượng</label>
            <div id="checkboxa">
                <div><input type="radio" class="checkbox_sona" name="txtDoituong" value="Giáo viên" /><span>Giáo viên</span></div>
                <div><input type="radio" class="checkbox_sona" name="txtDoituong" value="Sinh viên" /><span>Sinh viên</span></div>
            </div>
            <div id="subbutton">
                <button  type="submit"  class="btn" name="btnRegista" value="true">Thêm</button>
            </div>
    </form>
    </section>
    <section class="s2">
        <h1>Danh sách tài khoản</h1>
        <table id="table1" runat="server" visible="false">
            
            <thead>
               <tr>
                <td><b>ID</b></td>
                <td><b>Email</b></td>
                <td><b>Mật khẩu</b></td>
                <td><b>Tên</b></td>
                <td><b>Đối tượng</b></td>
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
