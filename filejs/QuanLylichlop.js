function checkloplich() {

    var txtdate = document.getElementById("txtdate");
    var loi = "", soloi = 0;
    var date = new Date(txtdate.value);

    if ((date.getTime() - Date.now())<0) {
        soloi++;
        loi += "\n" + soloi.toString() + ".Bạn phải chọn ngày đăng bài lớn hơn hoặc bằng ngày hôm nay";
    } 
    
    if (soloi != 0) {
        alert(loi);
        return false;
    }
    return true;
}