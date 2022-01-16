function checklop() {
    var txtTen = document.getElementById("txtTena");
    var txtlop = document.getElementById("txtlopa");
    //var txtaddress = document.getElementById("txtaddressa");
    var loi = "", soloi = 0;

    if (txtTen.value == "") {
        soloi++; 
        loi += "\n" + String(soloi) + ".Bạn phải nhập họ và tên đầy đủ của GV";
        txtTen.style.border = "1px solid red";
    }
    else {
        txtTen.style.border = "";
    }

    if (txtlop.value == "") {
        soloi++;
        loi += "\n" + String(soloi) + ".Bạn phải nhập tên lớp";
        txtlop.style.border = "1px solid red";
    }
    else {
        txtlop.style.border = "";
    }

    /*if (txtaddress.value == "") {
        soloi++; 
        loi += "\n" + String(soloi) + ".Bạn phải nhập link";
        txtaddress.style.border = "1px solid red";
    }
    else {
        txtaddress.style.border = "";
    }
    var link = /^.+\.aspx$/;
    if (!link.test(txtaddress.value)) {
        soloi++;
        loi += "\n" + String(soloi) + ".Bạn chưa nhập đúng dạng link";
        txtaddress.style.border = "1px solid red";
    }
    else {
        txtaddress.style.border = "";
    }*/
    
    if (soloi != 0) {
        alert(loi);
        return false;
    }
    return true;
}