/* 检查提交表单是否合格 */
function Checkform() {

    var pwd = document.getElementById("Password");
    var account = document.getElementById("Account");
    if (account.value == "") {
        swal("错误提示", "用户名不能为空！");
        return false;
    }
    if (pwd.value == "") {
        swal("错误提示", "密码不能为空!");
        return false;
    }

    if (!CheckAccount(account.value) || !CheckPassword(pwd.value)) {
        swal("错误提示", "用户名或密码错误!");
        pwd.value = "";
        return false;
    }
    return true;
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
