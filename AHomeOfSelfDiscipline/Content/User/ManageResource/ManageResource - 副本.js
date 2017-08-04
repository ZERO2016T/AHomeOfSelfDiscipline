//修改视频名称（videoId:视频名称Id;btnId:按钮Id）
function ModifyVideo(videoId, btnId) {
    document.getElementById(btnId).innerText = "完成";
    document.getElementById(btnId).href = "javascript:CheckValue('" + videoId + "')";
    document.getElementById(videoId).removeAttribute("disabled");
    document.getElementById(videoId).innerText = document.getElementById(videoId).title;
    document.getElementById(videoId).style.backgroundColor = "white";
    document.getElementById(videoId).style.border = "1px solid #DDDDDD";
}

//检查视频名称是否合法
function CheckValue(videoId)
{
    var name = Trim(document.getElementById(videoId).value);
    var ids = videoId.split('_');
    var id = ids[ids.length - 1];
    if(name == "" ||  name.length > 15)
    {
        swal("错误提示", "资源名称不能为空或超出15个字!");
        return false;
    }
    else
    {
        //ajax异步提交申请
        AjaxModifyVideoName(id, name);
        return true;
    }
}

//ajax异步修改视频名称
function AjaxModifyVideoName(id, value)
{
    $.ajax({
        url: '/User/ModResource',
        type: 'post',
        async: true,
        success: function (data) {
            ResetModity(id);
            swal(data.title, data.message);
        },
        data: { Id: id ,name: value },
        error: function () {
            swal("Sorry", "请求失败!请重新提交!");
        }
    });
}

//重置为修改前的状态
function ResetModity(id)
{
    var videoId = "VideoName_" + id;
    var btnId = "ModityBtn_" + id;
    document.getElementById(btnId).innerHTML = "<i class='fa fa-pencil'></i>";
    document.getElementById(btnId).href = "javascript:ModifyVideo('" + videoId + "', '" + btnId + "')";
    document.getElementById(videoId).disabled = "disabled";
    document.getElementById(videoId).style.backgroundColor = "#F9F9F9";
    document.getElementById(videoId).style.border = "0 solid #F9F9F9";
}



