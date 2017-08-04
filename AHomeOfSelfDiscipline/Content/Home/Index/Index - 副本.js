$(document).ready(function () {
    $('#main-slider .carousel').carousel({
        interval: 5000,//轮播时间间隔
    });
    InitPictrue();
    UpdateCarousel();
});

//更新轮播图
function UpdateCarousel()
{
    $.ajax({
        url: '/UpdateCarousel',
        type: 'post',
        async: true,
        
    });
}

//初始化图片
function InitPictrue() {
    $("a[rel^='prettyPhoto']").prettyPhoto({
        social_tools: false,
        allow_expand: false
    });
}