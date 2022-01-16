<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="regist.aspx.cs" Inherits="BTL_nhom10.WebForm2" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Đăng ký</title>
    <link href="filecss/regist.css" type="text/css" rel="stylesheet" />
</head>
<body>
    <header>
        HỆ THỐNG HỌC TRỰC TUYẾN G-H
    </header>
    <div id="center">
    <div id="grid">
        <aside id="img_left"></aside>
        <section>
        <form id="form_regist"  onsubmit="return check1()" runat="server" >

                <h1>ĐĂNG KÝ</h1>
                <label for="txtName">Nhập tên đăng ký(email):</label>
                <input type="email" id="txtMail" name="txtMail" value="" />
                <label for="txtPass">Nhập mật khẩu:</label>
                <input type="password" id="txtPass" name="txtPass" value="" />
                <label for="txtRe_Pass">Nhập lại mật khẩu:</label>
                <input type="password" id="txtRe_Pass" name="txtRe_Pass" value="" />
                <label for="txtFullName">Nhập họ và tên:</label>
                <input type="text" id="txtFullName" name="txtFullName" value="" />
                <label>Đối tượng</label>
            <div id="checkbox">
                <input type="radio" class="checkbox_son" name="txtDoituong" value="Giáo viên" /><span>Giáo viên</span>
                
                <input type="radio" class="checkbox_son" name="txtDoituong" value="Sinh viên" /><span>Sinh viên</span>
            </div>
                <button  type="submit" name="btnRegist" value="true">Đăng kí</button>
                <p>Đã có tài khoản?-<a href="login.aspx">Đăng nhập</a></p>
            </form>
        </section>
    </div>
    </div>
    <footer>
        Đỗ Văn Giang - Nguyễn Lê Hoàng
    </footer>
    <script type="text/javascript" src="regist.js"></script>
</body>
</html>
