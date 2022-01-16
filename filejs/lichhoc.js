function checkchoose() {
    var c1 = document.getElementsByName["choose"][0];
    var c2 = document.getElementsByName["choose"][1];
    if (c1.checked == false && c2.checked == false) {
        return false;
    }
    else return true;
}
/*
    var loiname = document.getElementsByClassName("loi")[0];
    var loipass = document.getElementsByClassName("loi")[1];
    var a=/[0-9]/,b=/[a-z]/,c=/[A-Z]/;
    if ((!a.test(txtPass_log.value)) || (!b.test(txtPass_log.value)) || (!c.test(txtPass_log.value))) {
        soloi++; dem++;
        loi += "\n" + String(soloi) +"Bạn phải nhập password có đủ số, chữ cái hoa, thường, không chứa các kí tự đặc biệt!";
    }
    if (dem != 0) {
        txtPass_log.style.border = "1px solid red";
    } else {
        txtPass_log.style.border = "";
    }
 */
/*var a1 = /[0-9]/, b1 = /[a-z]/, c1 = /[A-Z]/;
    if ((!a1.test(txtPass.value)) || (!b1.test(txtPass.value)) || (!c1.test(txtPass.value))) {
        soloi1++; dem++;
        loi1 += "\n" + String(soloi1) + ".Bạn phải nhập password có đủ số, chữ cái hoa, thường, không chứa các kí tự đặc biệt!";
    }
    if (dem != 0) {
        txtPass.style.border = "1px solid red";
    }
    else {
        txtPass.style.border = "";
    }*/