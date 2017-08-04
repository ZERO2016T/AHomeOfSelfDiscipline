
/* 检查提交表单是否合格 */
function Checkform() {

    var name = document.getElementById("name");
    var description = document.getElementById("description");

    if (Trim(name.value) == "" || Trim(name.value).length > 15) {
        swal("错误提示", "名称不能为空或不在指定范围长度!");
        return false;
    }

    if (Trim(description.value).length > 20) {
        swal("错误提示", "其它描述超出指定范围长度!");
        return false;
    }
    return true;
}