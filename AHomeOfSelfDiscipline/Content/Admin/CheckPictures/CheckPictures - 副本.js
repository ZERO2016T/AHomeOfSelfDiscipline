//弹出子窗口
function ShowSubPage(imgUrl, imgDescription) {
    document.getElementById("user_picture").src = "/AlumniPlatform/Picture/" + imgUrl;
    document.getElementById("picture_des").innerHTML = imgDescription;
    $("#mymodal").modal("toggle");
}