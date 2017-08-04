//弹出子窗口
function ShowSubPage(imgUrl, userName, userGrade, userMajor, userClass, userWish) {
    if (imgUrl != "") {
        document.getElementById("user_photo").src = "/AlumniPlatform/HeadPortrait/" + imgUrl;
    }
    if (userMajor == "其它") {
        userGrade = "XX";
        userMajor = "XX";
        userClass = "XX";
    }
    document.getElementById("user_name").innerHTML = userName;
    document.getElementById("user_grade").innerHTML = userGrade;
    document.getElementById("user_major").innerHTML = userMajor;
    document.getElementById("user_class").innerHTML = userClass;
    document.getElementById("user_wish").innerHTML = userWish;
    $("#mymodal").modal("toggle");
}