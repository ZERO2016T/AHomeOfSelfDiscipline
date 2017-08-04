$(document).ready(function () {
    HTMLPlay();
});

function FlashPlay(website) {
    
    var file = document.getElementById("resourcepath").value;
    var flashvars = {
        f: file,
        c: 0,
        b: 1
    };
    var params = { bgcolor: '#FFF', allowFullScreen: true, allowScriptAccess: 'always', wmode: 'transparent' };
    CKobject.embedSWF(website + '/ckplayer/ckplayer.swf', 'video', 'ckplayer_a1', -1, 400, flashvars, params);
    document.getElementById("video").style.width = "50%";
    $("#flash").toggleClass('active');
    $("#html5").removeClass('active');
}

function HTMLPlay() {
   
    var file = document.getElementById("resourcepath").value;
    var flashvars = {
        p: 1,
        e: 1,
        hl: file,
        ht: '20',
        hr: 'http://www.ckplayer.com'
    };
    var video = [file + '->video/mp4', file + '->video/webm', file + '->video/ogg'];
    var support = ['all'];
    CKobject.embedHTML5('video', 'ckplayer_a1', -1, 400, video, flashvars, support);
    document.getElementById("video").style.width = "50%";
    $("#html5").toggleClass('active');
    $("#flash").removeClass('active');
}