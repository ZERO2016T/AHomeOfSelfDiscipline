var img = new Image();
var imgWidth = 0;
var imgHeight = 0;

$(document).ready(function () {
    window.onresize = function () {
        ResizePhoto();
    }
    InitPicture();
});

//检查更新照片
function Checkform() {

    var path = document.getElementById("pictureFile").value;
    var x1 = parseInt(document.getElementById("x1").value);
    var y1 = parseInt(document.getElementById("y1").value);
    var x2 = parseInt(document.getElementById("x2").value);
    var y2 = parseInt(document.getElementById("y2").value);
    if (path == "") {
        swal("操作提示", "请选择图片!");
        return false;
    }
    var strs = path.split(".");
    var fileExt = strs[strs.length - 1].toLowerCase();
    if (fileExt != "jpg" && fileExt != "png") {
        swal("错误提示", "上传文件格式不正确!");
        return false;
    }
    if (img.width == img.height && x1 == 0 && x2 == 0 && y1 == 0 && y2 == 0) {
        return true;
    }
    if (x1 < 0 || x2 < 0 || y1 < 0 || y2 < 0 || x1 > 368 || y1 > 368 || x2 > 368 || y2 > 368) {
        swal("错误提示", "截取图像不正确!");
        return false;
    }
    var length = x2 - x1;
    if (length == (y2 - y1) && length >= 50 && length <= 368 && x1 + length <= imgWidth && y1 + length <= imgHeight) {
        return true;
    }
    else {
        swal("错误提示", "图像长宽比不正确,请换图或用鼠标截取合适部分!");
        //swal("错误提示", "上传的图片信息不合法!x1=" + x1 + ",x2=" + x2 + ",y1=" + y1 + ",y2 = " + y2 + ",width=" + imgWidth + ",height=" + imgHeight);
        return false;
    }
}

//选择和设置图片
function SelectPicture() {
    var pic = document.getElementById("pictureFile");
    if (pic.value == "") {
        document.getElementById("preview_img").src = "/image/User/UpdatePicture/default.png";
        return false;
    }
    var strs = pic.value.split(".");
    var fileExt = strs[strs.length - 1].toLowerCase();
    if (fileExt != "jpg" && fileExt != "png") {
        swal("错误提示", "选择的文件格式不正确!");
        return false;
    }
    var url = getFileUrl("pictureFile");
    document.getElementById("preview_img").src = url;
    img.src = url;
    img.onload = function () {
        if (this.width > this.height) {
            imgWidth = $(".picture-show-box").width() - 20;
            imgHeight = parseInt(imgWidth * (this.height / this.width));
            document.getElementById("preview_img").style.width = imgWidth + "px";
            document.getElementById("preview_img").style.height = imgHeight + "px";
        }
        else {
            imgHeight = $(".picture-show-box").height() - 20;
            imgWidth = parseInt(imgHeight * (this.width / this.height));
            document.getElementById("preview_img").style.height = imgHeight + "px";
            document.getElementById("preview_img").style.width = imgWidth + "px";
        }
        InitPicture();
    };
}

//重置图片大小
function ResizePhoto()
{
    if (img.width > img.height)
    {
            imgWidth = $(".picture-show-box").width() - 20;
            imgHeight = parseInt(imgWidth * (img.height / img.width));
    }
    else
    {
            imgHeight = $(".picture-show-box").height() - 20;
            imgWidth = parseInt(imgHeight * (img.width / img.height));
    }
    $("#preview_img").width(imgWidth);
    $("#preview_img").height(imgHeight);
    InitPicture();
}

//初始化图片
function InitPicture() {
    $('#preview_img').imgAreaSelect({
        minWidth: 50,
        minHeight: 50,
        aspectRatio: "1:1",
        handles: true,
        //onSelectChange: preview,
        onSelectEnd: function (img, selection) {
            $("input[name='x1']").val(selection.x1);
            $("input[name='y1']").val(selection.y1);
            $("input[name='x2']").val(selection.x2);
            $("input[name='y2']").val(selection.y2);
        },
    });
}

//获取本地图片的url
function getFileUrl(sourceId) {
    var url = window.URL.createObjectURL(document.getElementById(sourceId).files.item(0));
    if (navigator.userAgent.indexOf("MSIE") >= 1) { // IE 
        url = document.getElementById(sourceId).value;
    } else if (navigator.userAgent.indexOf("Firefox") > 0) { // Firefox 
        url = window.URL.createObjectURL(document.getElementById(sourceId).files.item(0));
    } else if (navigator.userAgent.indexOf("Chrome") > 0) { // Chrome 
        url = window.URL.createObjectURL(document.getElementById(sourceId).files.item(0));
    }
    return url;
}

