var isClickBtn = false;

//检查表单是否合法
function Checkform()
{
    var description = Trim(document.getElementById("description").value);
    if(description == "" || description.length > 100)
    {
        swal("错误提示", "寄语内容不能为空或超出指定范围长度!");
        return false;
    }
    return true;
}

//修改寄语
function ModifyWish() {
    if (isClickBtn) {
        document.getElementById("btnSubmit").click();
    }
    else {
        document.getElementById("UpdateWish").innerHTML = "完成";
        document.getElementById("description").removeAttribute("disabled");
        document.getElementById("description").style.backgroundColor = "white";
        document.getElementById("description").style.color = "#3B3E40";
        isClickBtn = true;
    }
}

//弹出子窗口
function ShowSubPage(imgUrl, userName, userGrade, userMajor, userClass, userWish) {
    if (userMajor == "其它")
    {
        userGrade = "XX";
        userMajor = "XX";
        userClass = "XX";
    }
    document.getElementById("user_photo").src = "/AlumniPlatform/HeadPortrait/" + imgUrl;
    document.getElementById("user_name").innerHTML = userName;
    document.getElementById("user_grade").innerHTML = userGrade;
    document.getElementById("user_major").innerHTML = userMajor;
    document.getElementById("user_class").innerHTML = userClass;
    document.getElementById("user_wish").innerHTML = userWish;
    
    $("#mymodal").modal("toggle");
}