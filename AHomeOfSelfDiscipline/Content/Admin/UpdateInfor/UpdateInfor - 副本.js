/* 检查提交表单是否合格 */
function Checkform() {

    var username = document.getElementById("Name");
    var account = document.getElementById("Account");
    var pwd = document.getElementById("Password");
    var repwd = document.getElementById("Re-password");
    if (Trim(username.value) == "" || Trim(username.value).length > 10) {

        swal("错误提示", "姓名不能为空或不在指定范围长度!");
        return false;
    }
    if (account.value == "" || account.value.length > 16 || account.value.length < 6) {

        swal("错误提示", "用户名不在指定范围长度!");
        return false;
    }
    if (pwd.value == "" || pwd.value.length > 16 || pwd.value.length < 6) {

        swal("错误提示", "密码不在指定范围长度!");
        return false;
    }
    if (!CheckAccount(account.value)) {
        swal("错误提示", "用户名不合规范!");
        account.value = "";
        return false;
    }
    if (!CheckPassword(pwd.value)) {
        swal("错误提示", "密码不合规范!");
        pwd.value = "";
        repwd.value = "";
        return false;
    }

    if (pwd.value != repwd.value) {
        swal("错误提示", "两次输入的密码不相等!");
        repwd.value = "";
        return false;
    }

    return true;
}

//检查账号是否合法
function CheckAccount(account) {
    var filter = /^[0-9a-zA-Z]{6,16}$/;
    if (filter.test(account))
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


//去除字符串的前后空白
function Trim(str) {
    return str.replace(/(^\s*)|(\s*$)/g, "");
}