$(document).ready(function () {
    InitUpload();
});

function InitUpload() {
    $("#upload-file").fileinput({
        uploadUrl: '/User/UploadResource', // you must set a valid URL here else you will get an error
        overwriteInitial: false,
        maxFileSize: 204800,//kb
        minFileCount: 1,
        maxFileCount: 4,
        allowedFileExtensions: ['mp4', 'flv'],
        ajaxSettings: {
            success: function (data) {
                swal(data.title, data.message);
                $(".file-footer-buttons .kv-file-remove").each(
                    function () {
                        this.click();
                    });
            }
        }
        //allowedFileTypes: ['image', 'video', 'flash'],
    });
}