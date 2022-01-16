<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="login.aspx.cs" Inherits="BTL_nhom10.WebForm1" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Đăng nhập</title>
    <link href="filecss/login.css" rel="stylesheet" type="text/css" />
</head>
<body>
    <header>
        HỆ THỐNG HỌC TRỰC TUYẾN G-H
    </header>
    <div id="center">
    <div id="grid">
        <aside id="img_left"></aside>
        <section>
            <form id="form_login"  onsubmit="return check()" runat="server">
                <h1>ĐĂNG NHẬP</h1>
                <br />
                <label for="txtName_log">Nhập tên đăng nhập:</label>
                
                <input type="email" id="txtName_log" name="txtName_log" value="" />
                
                <label for="txtPass_log">Nhập mật khẩu:</label>
                
                <input type="password" id="txtPass_log" name="txtPass_log" placeholder="Nhập mật khẩu ít nhất 8 kí tự" value="" />
                
                <button type="submit" name="btnLogin" value="true">Đăng nhập</button>
                
                <p>Đã có tài khoản?-<a href="regist.aspx">Đăng ký</a></p>
            </form>
        </section>

    </div>
    </div>
    <footer>
        Đỗ Văn Giang - Nguyễn Lê Hoàng
    </footer>
    <script type="text/javascript" src="filejs/login.js"></script>
</body>
</html>
