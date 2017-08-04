var isLock = false;
var email, name, code;

$(document).ready(function () {
    InitValiCode();
});

//初始化验证码
function InitValiCode() {
    $("#valiCode").bind("click", function () {
        this.src = "/GetValidateCode?codeClass=0&time=" + (new Date()).getTime();
    });
}

//刷新验证码
function RefreshValiCode() {
    document.getElementById("valiCode").src = "/GetValidateCode?codeClass=0&time=" + (new Date()).getTime();
}

//检查表单是否合法
function Checkform() {
    if (isLock)
    {
        return false;
    }
     email = document.getElementById("email").value;
     name = document.getElementById("name").value;
     code = document.getElementById("code").value;

    if (!CheckEmail(email)) {
        swal("错误提示", "邮箱不合法!");
        RefreshValiCode();
        return false;
    }
    if (Trim(name) == "" || Trim(name).length > 10) {
        swal("错误提示", "姓名不能为空或超出指定长度!");
        RefreshValiCode();
        return false;
    }
    if (!CheckCode(code)) {
        swal("错误提示", "验证码错误!");
        RefreshValiCode();
        return false;
    }
    return true;
   
}

//ajax上传数据
function AjaxPostData()
{
    isLock = true;
    $("#requst").removeClass("hidden");
    $.ajax({
        url: '/ForgotPassword',
        type: 'post',
        async: true,
        success: function (data) {
            $("#requst").addClass("hidden");
            if (data.title == "提交成功")
            {
                swal({ title: data.title, text: data.message }, function () { location.href = "/Login" });
            }
            else
            {
                swal(data.title, data.message);
                RefreshValiCode();
                document.getElementById("code").value = "";
                isLock = false;
            }
        },
        data: { email: email, name: name, code: code },
        error: function () {
            $("#requst").addClass("hidden");
            swal("Sorry", "请求失败!请重新提交!");
            isLock = false;
        }
    });
}

//检查邮箱是否合法
function CheckEmail(email) {
    var filter = /^([\w-\.]+)@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.)|(([\w-]+\.)+))([a-zA-Z]{2,4})$/;
    if (filter.test(email))
        return true;
    else
        return false;
}

//检查验证码是否合法
function CheckCode(code) {
    var filter = /^[0-9a-zA-Z]{5}$/;
    if (filter.test(code))
        return true;
    else
        return false;
}