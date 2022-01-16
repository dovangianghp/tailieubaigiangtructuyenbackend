function checktk() {
    var tk = document.getElementById("tk");
    if (tk.value == "") {
        alert("Bạn chưa nhập gì!");
        return false;
    }
    else return true;
}