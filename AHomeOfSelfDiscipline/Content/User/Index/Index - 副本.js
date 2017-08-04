function ShowSubPage(name, sex, birth, address, company, trade, job, phone, weChat, qq, hobby, description) {
    document.getElementById("user_name").innerHTML = name;
    document.getElementById("user_sex").innerHTML = sex;
    document.getElementById("user_birth").innerHTML = birth;
    document.getElementById("user_address").innerHTML = address;
    document.getElementById("user_company").innerHTML = company;
    document.getElementById("user_trade").innerHTML = trade;
    document.getElementById("user_job").innerHTML = job;
    document.getElementById("user_phone").innerHTML = phone;
    document.getElementById("user_weChat").innerHTML = weChat;
    document.getElementById("user_qq").innerHTML = qq;
    document.getElementById("user_hobby").innerHTML = hobby;
    document.getElementById("user_description").innerHTML = description;
    
    $("#mymodal").modal("toggle");
}