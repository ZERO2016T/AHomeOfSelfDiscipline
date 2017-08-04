var isLock = false;

$(document).ready(function () {
    InitValiCode();
    InitInfor('2000', '计算机科学与技术', '1');
});

//初始化验证码
function InitValiCode() {
    $("#valiCode").bind("click", function () {
        this.src = "/GetValidateCode?codeClass=1&time=" + (new Date()).getTime();
    });
}

//刷新验证码
function RefreshValiCode() {
    document.getElementById("valiCode").src = "/GetValidateCode?codeClass=1&time=" + (new Date()).getTime();
}

/* 检查提交表单是否合格 */
function Checkform() {

    if (isLock)
    {
        return false;
    }
    var account = document.getElementById("Account").value;
    var name = document.getElementById("Name").value;
    var password = document.getElementById("Password").value;
    var repassword = document.getElementById("Re-password").value;
    var code = document.getElementById("code").value;

    if (!CheckAccount(account)) {
            swal("错误提示", "邮箱[用户名]不合法!");
            return false;
    }

    if (Trim(name) == "" || Trim(name).length > 10) {
        swal("错误提示", "姓名不能为空或不在指定范围长度!");
        return false;
    }

    if (!CheckPassword(password)) {
        swal("错误提示", "密码不合法!");
        return false;
    }

    if (password != repassword)
    {
        swal("错误提示", "两次输入密码不相等!");
        return false;
    }

    if (!CheckCode(code)) {
        swal("错误提示", "验证码错误!");
        RefreshValiCode();
        return false;
    }
    return true;
}

function AjaxPostData()
{
    isLock = true;
    $("#requst").removeClass("hidden");
    var account = $("#Account").val();
    var name = $("#Name").val();
    var password = $("#Password").val();
    var code = $("#code").val();
    var userGrade = $("#Grade").val();
    var userMajor = $("#Major").val();
    var userClass = $("#Class").val();
    var sex = $("#Sex").val();

    $.ajax({
        url: '/RepeatedRegister',
        type: 'post',
        async: true,
        success:function(data)
        {
            if(data.Repeated)
            {
                swal({ title: "温馨提示", text: "提交的用户信息与已注册账号:" + data.Account + "的一样，疑似重复注册，是否继续？", type: "warning", showCancelButton: true, confirmButtonColor: "#DD6B55", confirmButtonText: "继续", cancelButtonText: '取消', closeOnConfirm: false }, function (isConfirm) {
                    if (isConfirm)
                    {
                        setTimeout("Register()",0);
                    }
                    else
                    {
                        isLock = false;
                        $("#requst").addClass("hidden");
                    }
                });
            }
            else
            {
                Register();
            }
        },
        data: { __RequestVerificationToken: $("input[name='__RequestVerificationToken']").val(), Name: name, Grade: userGrade, Major: userMajor, Class: userClass, Sex: sex },
        error: function () {
            $("#requst").addClass("hidden");
            swal("Sorry", "请求失败!请重新提交!");
            isLock = false;
        }
    });
}

function Register()
{
    var account = $("#Account").val();
    var name = $("#Name").val();
    var password = $("#Password").val();
    var code = $("#code").val();
    var userGrade = $("#Grade").val();
    var userMajor = $("#Major").val();
    var userClass = $("#Class").val();
    var sex = $("#Sex").val();
    $.ajax({
        url: '/Register',
        type: 'post',
        async: true,
        success: function (data) {
            $("#requst").addClass("hidden");
            if (data.title == "提交成功") {
                swal({ title: data.title, text: data.message }, function () { location.href = "/Login" });
            }
            else {
                swal(data.title, data.message);
                RefreshValiCode();
                document.getElementById("code").value = "";
                isLock = false;
            }
        },
        data: { Account: account, Name: name, Password: password, Grade: userGrade, Major: userMajor, Class: userClass, Sex: sex, code: code },
        error: function () {
            $("#requst").addClass("hidden");
            swal("Sorry", "请求失败!请重新提交!");
            isLock = false;
        }
    });
}

//检查账号是否合法
function CheckAccount(account) {
    var filter1 = /^[a-zA-Z0-9]{6,16}$/;
    var filter2 = /^([\w-\.]+)@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.)|(([\w-]+\.)+))([a-zA-Z]{2,4})$/;
    if (filter1.test(account) || filter2.test(account))
        return true;
    else
        return false;
}

//检查密码是否合法
function CheckPassword(pwd) {
    var filter = /^[0-9a-zA-Z]{6,16}$/;
    if (filter.test(pwd))
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

var majors = ["计算机科学与技术", "计算机科学与技术(教育)", "物联网工程", "信息管理与信息系统", "电子商务", "计算机应用与维修", "农业电气化自动化(计算机应用)", "其它"];
var grades = ["2000-2015", "2013-2015", "2013-2015", "2013-2015", "2001-2009", "1994-1997", "1995-1996"];
var classes = ["1-9", "1-5", "1-5", "1-5", "1-5", "1-1", "1-1"];

//初始化用户信息（grade_:年级，mojor_:专业，class_:班级）
function InitInfor(userGrade, userMajor, userClass) {
    var gradeElem = document.getElementById("Grade");
    var majorElem = document.getElementById("Major");
    var classElem = document.getElementById("Class");
    var i = 0;
    var str = "";
    for (i = 0; i < majors.length; i++) {
        if (majors[i] == userMajor) {
            str += "<option value='" + majors[i] + "' selected='selected'>" + majors[i] + "</option>";
            if (userMajor == "其它") {
                gradeElem.innerHTML = "<option value='0' selected='selected'>默认</option>";
                classElem.innerHTML = "<option value='0' selected='selected'>默认</option>";
            }
            else {
                gradeElem.innerHTML = SelectGrade(i, userGrade);
                classElem.innerHTML = SelectClass(i, userClass);
            }
        }
        else {
            str += "<option value='" + majors[i] + "'>" + majors[i] + "</option>";
        }
    }
    majorElem.innerHTML = str;
    $("#Major").change(function () {
        if (this.value == "其它") {
            InitGrade(-1);
            InitClass(-1);
        }
        else {
            var i = 0;
            for (i = 0; i < majors.length; i++) {
                if (majors[i] == this.value) {
                    InitGrade(i);
                    InitClass(i);
                    return true;
                }
            }
        }
    });
}

function InitGrade(index) {
    if (index == -1) {
        document.getElementById("Grade").innerHTML = "<option value='0' selected='selected'>默认</option>";
        return true;
    }
    var str = "";
    var strs = grades[index].split('-');
    var start = parseInt(strs[0]);
    var end = parseInt(strs[1]);
    var i = 0;
    str += "<option value='" + start + "' selected='selected'>" + start + "级</option>";
    for (i = start + 1; i <= end; i++) {
        str += "<option value='" + i + "'>" + i + "级</option>";
    }
    document.getElementById("Grade").innerHTML = str;
}

function InitClass(index) {
    if (index == -1) {
        document.getElementById("Class").innerHTML = "<option value='0' selected='selected'>默认</option>";
        return true;
    }
    var str = "";
    var strs = classes[index].split('-');
    var start = parseInt(strs[0]);
    var end = parseInt(strs[1]);
    var i = 0;
    str += "<option value='" + start + "' selected='selected'>" + start + "班</option>";
    for (i = start + 1; i <= end; i++) {
        str += "<option value='" + i + "'>" + i + "班</option>";
    }
    document.getElementById("Class").innerHTML = str;
}

function SelectGrade(index, userGrade) {

    var str = "";
    var strs = grades[index].split('-');
    var start = parseInt(strs[0]);
    var end = parseInt(strs[1]);
    var i = 0;
    for (i = start; i <= end; i++) {
        if (i == userGrade) {
            str += "<option value='" + i + "' selected='selected'>" + i + "级</option>";
        }
        else {
            str += "<option value='" + i + "'>" + i + "级</option>";
        }

    }
    return str;
}


function SelectClass(index, userClass) {

    var str = "";
    var strs = classes[index].split('-');
    var start = parseInt(strs[0]);
    var end = parseInt(strs[1]);
    var i = 0;
    for (i = start; i <= end; i++) {
        if (i == userClass) {
            str += "<option value='" + i + "' selected='selected'>" + i + "班</option>";
        }
        else {
            str += "<option value='" + i + "'>" + i + "班</option>";
        }
    }
    return str;
}