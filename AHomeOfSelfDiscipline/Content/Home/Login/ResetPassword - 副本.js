/* 检查提交表单是否合格 */
function Checkform() {

    var account = document.getElementById("account");
    var code = document.getElementById("code");
    var pwd = document.getElementById("newPassword");
    if (account.value == "") {
        swal("错误提示", "用户名不能为空！");
        return false;
    }
    if (code.value == "")
    {
        swal("错误提示", "确认码不能为空!");
        return false;
    }
    if (pwd.value == "") {
        swal("错误提示", "密码不能为空!");
        return false;
    }
    if (!CheckAccount(account.value) || !CheckCode(code.value) || !CheckPassword(pwd.value)) {
        swal("错误提示", "提交信息不合法!");
        pwd.value = "";
        return false;
    }
    return true;
}

//检查账号是否合法
function CheckAccount(account) {
    var filter = /^([\w-\.]+)@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.)|(([\w-]+\.)+))([a-zA-Z]{2,4})$/;
    if (filter.test(account))
        return true;
    else
        return false;
}

//检查确认码是否合法
function CheckCode(code) {
    var filter = /^[0-9a-zA-Z]{32}$/;
    if (filter.test(code))
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
