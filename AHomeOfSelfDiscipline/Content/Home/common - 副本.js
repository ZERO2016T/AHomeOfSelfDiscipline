//有关返回顶部的按钮
var myShowtoTop = setInterval(ShowtoTop, 50);//控制显示
var myBackTop;//控制返回顶部
var flag = true;
var scrollTop;//滚动条距离顶部的距离

//显示或隐藏返回顶部按钮
function ShowtoTop() {
    //兼容各大浏览器
    scrollTop = document.documentElement.scrollTop || window.pageYOffset || document.body.scrollTop;
    if (scrollTop <= 10) {
        document.getElementById("toTop").style.display = "none";
    }
    else {
        document.getElementById("toTop").style.display = "block";
    }
}

//设置平滑滚动到顶部的触发器
function myInterval() {
    if (flag) {
        flag = false;
        myBackTop = setInterval(BackTop, 50);
    }
}

//平滑滚动到顶部
function BackTop() {
    scrollTop = document.documentElement.scrollTop || window.pageYOffset || document.body.scrollTop;
    if (scrollTop <= 20) {
        clearInterval(myBackTop);
        if (document.body.scrollTop != 0)
        {
            document.body.scrollTop = 0;
        }
        else if (document.documentElement.scrollTop != 0)
        {
            document.documentElement.scrollTop = 0;
        }
        else
        {
            window.pageYOffset = 0;
        }
        flag = true;
    }
    else {
        if (document.body.scrollTop != 0) {
            document.body.scrollTop = document.body.scrollTop - 100;
        }
        else if (document.documentElement.scrollTop != 0) {
            document.documentElement.scrollTop = document.documentElement.scrollTop - 100;
        }
        else {
            window.pageYOffset = window.pageYOffset - 100;
        }
        
    }
}