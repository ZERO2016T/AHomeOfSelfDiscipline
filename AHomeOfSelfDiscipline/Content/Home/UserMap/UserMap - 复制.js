document.write('<script type="text/javascript" src="http://api.map.baidu.com/api?v=2.0&ak=A739765f9a84bee561d30fa0b537ccb9"></script>');
document.write('<script charset=utf-8 type="text/javascript" src="http://api.map.baidu.com/library/SearchInfoWindow/1.5/src/SearchInfoWindow_min.js"></script>');
document.write('<link charset=utf-8 rel="stylesheet" href="http://api.map.baidu.com/library/SearchInfoWindow/1.5/src/SearchInfoWindow_min.css" />');

var baiduMap;//百度地图
var addrPoints = [];//用户地址坐标
setTimeout("InitMap('baiduMap',4)", 1000);

//初始化Map(mapId:地图元素Id；zoom:地图的放大级别（范围为3-18级）)
function InitMap(mapId, zoom) {

    baiduMap = new BMap.Map(mapId);//创建地图
    baiduMap.enableScrollWheelZoom();//支持放缩
    baiduMap.enableKeyboard();//启用键盘操作
    baiduMap.enablePinchToZoom();//启用双指操作缩放
    baiduMap.enableAutoResize();//启用自动适应容器尺寸变化
    baiduMap.centerAndZoom(new BMap.Point(100, 40), zoom);//设初始化地图。
    
    //向地图中添加缩略图控件
    var ctrlOve = new BMap.OverviewMapControl({
        anchor: BMAP_ANCHOR_BOTTOM_RIGHT,
        isOpen: 1
    });
    baiduMap.addControl(ctrlOve);

    //显示完整的平移缩放控件
    var opts = { type: BMAP_NAVIGATION_CONTROL_LARGE };
    baiduMap.addControl(new BMap.NavigationControl(opts));

    ////创建一个获取本地城市位置的实例
    //var myCity = new BMap.LocalCity();
    ////获取城市
    //myCity.get(
	//function (result) {
	//    baiduMap.setCenter(result.name);
	//});
   
    AjaxGetData();//异步加载数据
}

//使用ajax获取数据
function AjaxGetData() {
    $.ajax({
        url: '/AjaxGetUserInfos',
        type: 'post',
        async: true,
        data:{ __RequestVerificationToken: $("input[name='__RequestVerificationToken']").val()},
        success: function (data) {
            var userDatas = eval('(' + data + ')');
            var n = userDatas.length;
            document.getElementById("signCount").innerHTML = n;
            var i = 0, j = 0, k = 0;
            for(i = 0; i < n; i++)
            {
                AddMarker(userDatas[i].AddrLocation, k, j);
                j++;
                if(j == 4)
                {
                    j = 0;
                    k++;
                    if (k == 4) {
                        k = 0;
                    }
                }
            }
        },
        error: function () {
            swal("Sorry", "数据加载失败,请刷新页面重试!");
        }
    });
}

//添加标注
function AddMarker(addrLocation, lngr, latr)
{
    var point = addrLocation.split('-');
    var lng = parseFloat(point[0]) + 0.0001 * lngr;//避免坐标重复
    var lat = parseFloat(point[1]) + 0.0001 * latr;
    var marker = new BMap.Marker(new BMap.Point(lng, lat));
    baiduMap.addOverlay(marker); // 将标注添加到地图中
	marker.addEventListener("mouseover", function () {
            this.setAnimation(BMAP_ANIMATION_BOUNCE); //跳动的动画
        });
    marker.addEventListener("mouseout", function () {
            this.setAnimation(null); //清除动画
        });
    
    
}

