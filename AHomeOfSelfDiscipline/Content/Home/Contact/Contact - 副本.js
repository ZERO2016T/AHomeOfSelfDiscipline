var isLock = false;
var name, email, phone, code, subject, message;

$(document).ready(function () {
    InitValiCode();
});

//初始化验证码
function InitValiCode() {
    $("#valiCode").bind("click", function () {
        this.src = "/GetValidateCode?codeClass=2&time=" + (new Date()).getTime();
    });
}

//刷新验证码
function RefreshValiCode() {
    document.getElementById("valiCode").src = "/GetValidateCode?codeClass=2&time=" + (new Date()).getTime();
}

/* 检查提交表单是否合格 */
function Checkform() {
    if (isLock) {
        return false;
    }
    name = document.getElementById("name").value;
    email = document.getElementById("email").value;
    phone = document.getElementById("phone").value;
    code = document.getElementById("code").value;
    subject = document.getElementById("subject").value;
    message = document.getElementById("message").value;

    if (Trim(name) == "" || Trim(name).length > 10) {
        swal("错误提示", "姓名不能为空或超出指定长度！");
        return false;
    }
    if (!CheckEmail(email)) {
        swal("错误提示", "邮箱不合法!");
        return false;
    }
    if (Trim(phone) != "")
    {
        if (!CheckPhone(phone)) {
            swal("错误提示", "电话号码不合法!");
            return false;
        }
    }
    if (!CheckCode(code))
    {
        swal("错误提示", "验证码错误!");
        return false;
    }

    if (Trim(subject) == "" || Trim(subject).length > 50) {
        swal("错误提示", "主题不能为空或超出指定长度！");
        return false;
    }
    if (Trim(message) == "" || Trim(message).length > 1000) {
        swal("错误提示", "主题不能为空或超出指定长度！");
        return false;
    }
    return true;
}

//ajax上传数据
function AjaxPostData() {
    isLock = true;
    $("#requst").removeClass("hidden");
    $.ajax({
        url: '/SendEmail',
        type: 'post',
        async: true,
        success: function (data) {
            $("#requst").addClass("hidden");
            if (data.title == "发送成功") {
                swal({ title: data.title, text: data.message }, function () { location.href = "/Contact" });
            }
            else {
                swal(data.title, data.message);
                RefreshValiCode();
                document.getElementById("code").value = "";
                isLock = false;
            }
        },
        data: { name: name, email: email, phone: phone, code: code, subject: subject, message: message },
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

//检查电话是否合法
function CheckPhone(phone) {
    var filter = /^[0-9]{6,11}$/;
    if (filter.test(phone))
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
