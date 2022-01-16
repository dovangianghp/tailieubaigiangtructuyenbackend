function check1() {
    var email = document.getElementById("txtMail");
    var regMail = /^([a-zA-Z0-9](\.|_)?)+([a-zA-Z0-9])+\@([a-zA-Z0-9])+(\.?[a-zA-Z0-9]){2}\.[a-z]{2,3}$/;
    if (!regMail.test(email.value)) {
        soloi1++;
        loi1 += "\n" + String(soloi1) + ".Bạn phải nhập đúng dạng email (tên đăng nhập)";
        email.style.border = "1px solid red";
    } else {
        email.style.border = "";
    }
    var txtPass = document.getElementById("txtPass");
    var loi1 = "", soloi1 = 0;
    
    var dem = 0; 
    if (txtPass.value.length < 8) {
        soloi1++; dem++;
        loi1 += "\n" + String(soloi1) + ".Bạn phải nhập password độ dài lớn hơn = 8!";
        txtPass.style.border = "1px solid red";
    }

    
    
    
var txtRe_Pass = document.getElementById("txtRe_Pass");
if (txtRe_Pass.value!= txtPass.value) {
    soloi1++;
    loi1 += "\n" + String(soloi1) + ".Bạn phải nhập lại password trùng với password ở trên";
    txtRe_Pass.style.border = "1px solid red";
} else {
    txtRe_Pass.style.border = "";
    }
    var ten = document.getElementById("txtFullName");
    if (txtFullName.value =="") {
        soloi1++;
        loi1 += "\n" + String(soloi1) + ".Bạn phải nhập họ và tên";
        ten.style.border = "1px solid red";
    } else {
        ten.style.border = "";
    }
    var txtdoituong1 = document.getElementsByName("txtDoituong")[0];
var txtdoituong2 = document.getElementsByName("txtDoituong")[1];
if (txtdoituong1.checked == false && txtdoituong2.checked == false) {
    soloi1++;
    loi1 += "\n" + String(soloi1) + ".Bạn phải chọn đối tượng";
}
    if (soloi1 != 0) {
        alert(loi1);
        return false;
    }
    return true;
}