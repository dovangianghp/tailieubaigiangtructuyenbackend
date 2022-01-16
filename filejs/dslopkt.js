function ktchacchan() {
    var kt = document.getElementById("btnhuy").value;
    var x = kt.split(',');
    if (x[0] == "true") {
        var n = confirm("Bạn có chắc chắn ko!");
        if (n == true) {
            return true;
        } else { return false; }
    }
}