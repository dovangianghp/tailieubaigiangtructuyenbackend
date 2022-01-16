
function check() {
    var txtName_log = document.getElementById("txtName_log");
    var txtPass_log = document.getElementById("txtPass_log");
    
    var loi = "", soloi = 0;
    
    var regMail = /^([a-zA-Z0-9](\.|_)?)+([a-zA-Z0-9])+\@([a-zA-Z0-9])+(\.?[a-zA-Z0-9]){2}\.[a-z]{2,3}$/;
    if (!regMail.test(txtName_log.value)) {
        soloi++;
        loi += "\n" + String(soloi1) + ".Bạn phải nhập đúng dạng email (tên đăng nhập)";
        txtName_log.style.border = "1px solid red";
        
    } else {
        txtName_log.style.border = "";
    }
    var dem = 0;
    if (txtPass_log.value.length < 8) {
        soloi++; dem++;
        loi += "\n" + String(soloi) + "Bạn phải nhập password độ dài lớn hơn = 8!";
    }
    
    if (soloi != 0) {
        alert(loi);
        return false;
    }
    return true;
}
