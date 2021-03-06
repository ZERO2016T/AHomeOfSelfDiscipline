﻿$(document).ready(function () {
    Window.UEDITOR_HOME_URL = "/Scripts/UEditor/";
    var editor = new baidu.editor.ui.Editor({
        autoHeightEnabled: false,
        initialFrameHeight: 300,
        autoFloatEnabled: false,
        toolbars: [['source', 'fullscreen', '|', 'undo', 'redo', '|', 'bold', 'italic', 'underline', 'strikethrough', '|', 'superscript', 'subscript', '|', 'forecolor', 'backcolor', '|',
                   'insertorderedlist', 'insertunorderedlist', '|', 'insertcode', 'paragraph', '|', 'fontfamily', 'fontsize',
                   '|', 'justifyleft', 'justifycenter', 'justifyright', 'justifyjustify', '|',
                   'link', 'unlink', '|', 'imagenone', 'imageleft', 'imageright', 'imagecenter', '|', 'horizontal', 'spechars', 'emotion', '|', 'simpleupload', 'insertvideo', 'map', '|',
                   'inserttable', 'deletetable', 'insertparagraphbeforetable', 'insertrow', 'deleterow', 'insertcol', 'deletecol', 'mergecells', 'mergeright', 'mergedown', 'splittocells', 'splittorows', 'splittocols', 'charts', '|',
                   'preview']],
    });
    editor.render("Description");
});

/* 检查提交表单是否合格 */
function Checkform() {
    var name = document.getElementById("Name").value;
    var des = $("textarea[name='Description']").val();
    if (Trim(name).length == 0 || Trim(name).length > 40) {
        swal("错误提示", "标题不能为空或超过40个字!");
        return false;
    }
    if (Trim(des) == "") {
        swal("错误提示", "公告内容不能为空!");
        return false;
    }
    return true;
}
