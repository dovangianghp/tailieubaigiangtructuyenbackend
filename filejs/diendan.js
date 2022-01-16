function kiemtra() {
   
    var k = document.getElementById("textdiendan").value;
    if (k == "") {
        alert("Bạn phải nhập nội dung!");
        return false;
    }
    else {
        return true;
    }
}