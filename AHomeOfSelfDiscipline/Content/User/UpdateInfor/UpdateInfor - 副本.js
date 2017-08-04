/* 检查提交表单是否合格 */
function Checkform() {

    var password = document.getElementById("Password");
    var name = document.getElementById("Name");
    var birth = document.getElementById("Birthday");
    var job = document.getElementById("Job");
    var company = document.getElementById("Company");
    var address = document.getElementById("Address");
    var phone = document.getElementById("Phone");
    var qq = document.getElementById("QQ");
    var weChat = document.getElementById("WeChat");
    var hobby = document.getElementById("Hobby");
    var description = document.getElementById("Description");

    if (password.value != "") {
        if (!CheckPassword(password.value)) {
            swal("错误提示", "新密码不合法!");
            return false;
        }
    }

    if (Trim(name.value) == "" || Trim(name.value).length > 10) {
        swal("错误提示", "姓名不能为空或不在指定范围长度!");
        return false;
    }

    if (birth.value != "") {
        if (!CheckDate(birth.value)) {
            swal("错误提示", "出生日期不合法!");
            return false;
        }
    }

    if (Trim(job.value).length > 20) {
        swal("错误提示", "职业超出指定范围长度!");
        return false;
    }

    if (Trim(company.value).length > 20) {
        swal("错误提示", "工作单位超出指定范围长度!");
        return false;
    }

    if (Trim(address.value) != "") {
        if (!CheckAddress(address.value)) {
            swal("错误提示", "家庭住址不完整或不合法!");
            return false;
        }
    }

    if (Trim(phone.value) != "") {
        if (!CheckPhone(phone.value)) {
            swal("错误提示", "电话号码不合法!");
            return false;
        }
    }

    if (Trim(qq.value) != "") {
        if (!CheckQQ(qq.value)) {
            swal("错误提示", "QQ号码不合法!");
            return false;
        }
    }

    if (Trim(weChat.value) != "") {
        if (!CheckWeChat(weChat.value)) {
            swal("错误提示", "微信账号不合法!");
            return false;
        }
    }
   
    if (Trim(hobby.value).length > 50) {
        swal("错误提示", "爱好超出指定范围长度!");
        return false;
    }

    if (Trim(description.value).length > 100) {
        swal("错误提示", "其它描述超出指定范围长度!");
        return false;
    }
    return true;
}

//检查密码是否合法
function CheckPassword(pwd) {
    var filter = /^[0-9a-zA-Z]{6,16}$/;
    if (filter.test(pwd))
        return true;
    else
        return false;
}

//验证是否合法日期   
function CheckDate(strDate) {
    if (strDate.length > 0) {
        var filter = /^(\d{4})-(\d{1,2})-(\d{1,2})$/;
        if (filter.test(strDate)) {
            return true;
        }
        else {
            return false;
        }
    }
    else {
        return false;
    }
}

//检查家庭住址是否合法
function CheckAddress(address)
{
    var filter = /^[\u4e00-\u9fa5]{2,4}-[\u4e00-\u9fa5]{2,8}-[\u4e00-\u9fa5]{2,10}$/;
    if (filter.test(address))
        return true;
    else
        return false;
}

//检查电话号码是否合法
function CheckPhone(phone) {
    var filter = /^[0-9]{6,11}$/;
    if (filter.test(phone))
        return true;
    else
        return false;
}

//检查QQ号码是否合法
function CheckQQ(qq) {
    var filter = /^[0-9]{5,11}$/;
    if (filter.test(qq))
        return true;
    else
        return false;
}


//检查微信账号是否合法
function CheckWeChat(weChat) {
    var filter = /^[a-zA-Z]([0-9a-zA-Z]|_|-){5,19}$/;
    if (filter.test(weChat))
        return true;
    else
        return false;
}

//初始化日期
function InitDate() {
    jeDate({
        dateCell: "#Birthday",
        format: "YYYY-MM-DD",
        isinitVal: true,
        isTime: true, //isClear:false,
        minDate: "1900-01-01"
    });
}

var majors = ["计算机科学与技术", "计算机科学与技术(教育)", "物联网工程", "信息管理与信息系统", "电子商务", "计算机应用与维修", "农业电气化自动化(计算机应用)", "其它"];
var grades = ["2000-2015", "2013-2015", "2013-2015", "2013-2015", "2001-2009", "1994-1997", "1995-1996"];
var classes = ["1-9", "1-5", "1-5", "1-5", "1-5", "1-1", "1-1"];
var trades = ["", "信息传输、计算机服务和软件业", "电信和其他信息传输服务业", "计算机服务业", "软件业", "电气机械及器材制造业", "通信设备、计算机及其他电子设备制造业", "其它"];

//初始化用户信息（grade_:年级，mojor_:专业，class_:班级）
function InitInfor(userGrade, userMajor, userClass, userTrade)
{
    var gradeElem = document.getElementById("Grade");
    var majorElem = document.getElementById("Major");
    var classElem = document.getElementById("Class");
    var tradeElem = document.getElementById("Trade");
    var i = 0;
    var str = "";
    for (i = 0; i < majors.length; i++)
    {
        if (majors[i] == userMajor)
        {
            str += "<option value='" + majors[i] + "' selected='selected'>" + majors[i] + "</option>";
            if (userMajor == "其它")
            {
                gradeElem.innerHTML = "<option value='0' selected='selected'>默认</option>";
                classElem.innerHTML = "<option value='0' selected='selected'>默认</option>";
            }
            else
            {
                gradeElem.innerHTML = SelectGrade(i, userGrade);
                classElem.innerHTML = SelectClass(i, userClass);
            }
        }
        else
        {
            str += "<option value='" + majors[i] + "'>" + majors[i] + "</option>";
        }
    }
    majorElem.innerHTML = str;
    str = "";
    if (userTrade == "")
    {
        str += "<option value='' selected='selected'>(选填)</option>";
    }
    else
    {
        str += "<option value=''>(选填)</option>";
    }
    for (i = 1; i < trades.length; i++)
    {
        if(trades[i] == userTrade)
        {
            str += "<option value='" + trades[i] + "' selected='selected'>" + trades[i] + "</option>";
        }
        else
        {
            str += "<option value='" + trades[i] + "'>" + trades[i] + "</option>";
        }
    }
    tradeElem.innerHTML = str;
    $("#Major").change(function () {
        if(this.value == "其它")
        {
            InitGrade(-1);
            InitClass(-1);
        }
        else
        {
            var i = 0;
            for(i = 0; i < majors.length; i++)
            {
                if(majors[i] == this.value)
                {
                    InitGrade(i);
                    InitClass(i);
                    return true;
                }
            }
        }
    });
}

function InitGrade(index)
{
    if (index == -1) {
        document.getElementById("Grade").innerHTML = "<option value='0' selected='selected'>默认</option>";
        return true;
    }
    var str = "";
    var strs = grades[index].split('-');
    var start = parseInt(strs[0]);
    var end = parseInt(strs[1]);
    var i = 0;
    str += "<option value='" + start + "' selected='selected'>" + start + "级</option>";
    for (i = start + 1; i <= end; i++) {
        str += "<option value='" + i + "'>" + i + "级</option>";
    }
    document.getElementById("Grade").innerHTML = str;
}

function InitClass(index)
{
    if (index == -1)
    {
        document.getElementById("Class").innerHTML = "<option value='0' selected='selected'>默认</option>";
        return true;
    }
    var str = "";
    var strs = classes[index].split('-');
    var start = parseInt(strs[0]);
    var end = parseInt(strs[1]);
    var i = 0;
    str += "<option value='" + start + "' selected='selected'>" + start + "班</option>";
    for (i = start + 1; i <= end; i++) {
        str += "<option value='" + i + "'>" + i + "班</option>";
    }
    document.getElementById("Class").innerHTML = str;
}

function SelectGrade(index, userGrade)
{
   
    var str = "";
    var strs = grades[index].split('-');
    var start = parseInt(strs[0]);
    var end = parseInt(strs[1]);
    var i = 0;
    for(i = start; i <= end; i++)
    {
        if (i == userGrade)
        {
            str += "<option value='" + i + "' selected='selected'>" + i + "级</option>";
        }
        else
        {
            str += "<option value='" + i + "'>" + i + "级</option>";
        }
        
    }
    return str;
}


function SelectClass(index, userClass) {
   
    var str = "";
    var strs = classes[index].split('-');
    var start = parseInt(strs[0]);
    var end = parseInt(strs[1]);
    var i = 0;
    for (i = start; i <= end; i++) {
        if (i == userClass) {
            str += "<option value='" + i + "' selected='selected'>" + i + "班</option>";
        }
        else {
            str += "<option value='" + i + "'>" + i + "班</option>";
        }
    }
    return str;
}