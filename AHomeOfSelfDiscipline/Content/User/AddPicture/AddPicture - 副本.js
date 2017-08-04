$(document).ready(function () {
    InitUpload();
});

//初始化删除图片
function InitUpload() {
    $("#upload-file").fileinput({
        uploadUrl: '/User/AddPicture', // you must set a valid URL here else you will get an error
        overwriteInitial: true,
        maxFileSize: 10240,//kb
        minFileCount: 1,
        maxFileCount: 1,
        allowedFileExtensions: ['jpg', 'png', 'gif'],
        uploadExtraData: function () {
            var des = document.getElementById("description").value;
            if (Trim(des).length <= 20) {
                if (des == "") {
                    des = "暂无";
                }
                return { description: des };
            }
            else {
                swal("错误提示", "图片简介长度不合要求!");
                NoFunctionForStop();
            }
        },
        ajaxSettings: {
            success: function (data) {
                swal(data.title, data.message);
                $("#description").val("");
                $(".file-footer-buttons .kv-file-remove").click();
            }
        }
    });
}