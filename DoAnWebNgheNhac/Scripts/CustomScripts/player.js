
// BIẾN THAM CHIẾU
var duration;
var timlineLeft;
var volumebarLeft;

// Tham chiếu đến audio tag, bài hát đang chơi.
var music = document.getElementById('playingsong');

// Thanh giời gian.
var timeline = document.getElementById('timeline');

// Thanh thời gian hiện tại của bài nhạc.
var currentTimeSlider = document.getElementById('currentTimeSlider');

// Tham chiếu đến toàn bộ khung media player (860 * 240).
var musicplayer = document.getElementById('musicPlayer');

// Tham chiếu đến cục hình vuông trên timeline.
var timenode = document.getElementById('timenode');

// Nút play/pause.
var playpausebtn = document.getElementById('playpausebtn');

// Tham chiếu đến đoạn text hiển thị thời gian.
var timecurrrent = document.getElementById('timecurrrent');

// Thanh volume lớn
var volumebar = document.getElementById('volumebar');

// Thanh volume hiện tại.
var volumeavaiable = document.getElementById('volumeavaiable');

// Nút chỉnh volume.
var volumenode = document.getElementById('volumenode');

// Tham chiếu đến biểu tượng volume.
var volumeicon = document.getElementById('volumeicon');

// Tham chiếu đến nút loop
var loopbtn = document.getElementById('loopbtn');

// Tham chiếu đến nút shuffle
var shufflebtn = document.getElementById('shufflebtn');

// Tham chiếu đến nút next
var nextbtn = document.getElementById('nextbtn');

/// SỰ KIỆN

// Update thông tin dựa theo thời gian play nhạc
music.addEventListener("timeupdate", timeUpdate, false);

// Sự kiện bài hát kết thúc.
music.addEventListener("ended", musicended);

// Update UI khi đưa chuột vào khu vực player.
musicplayer.addEventListener("mouseover", playerBigSlider);

// Update UI khi đưa chuột ra khỏi khu vực player.
musicplayer.addEventListener("mouseout", playerSmallSlider);

// Sư kiện click vào thanh thời gian để fast forward hoặc fast backward.
timeline.addEventListener("click", timelineClick);
currentTimeSlider.addEventListener("click", timelineClick);

// Sự kiện click vào thanh volume để chỉnh âm lượng nhạc.
volumebar.addEventListener("click", volumeClick);
volumeavaiable.addEventListener("click", volumeClick);

// Sự kiện kéo nút để fast forward hoặc fast backward.
var flagMouseDown = false;
timenode.addEventListener("mousedown", timenodeMouseDown);
timenode.addEventListener("mouseup", timenodeMouseUp);

// Sự kiện kéo nút volumenode để chỉnh âm lượng.
var flagvolume = false;
volumenode.addEventListener("mousedown",volumenodeMouseDown);
volumenode.addEventListener("mouseup", volumenodeMouseUp);

// Sự kiện nhấn vào nút pause/play để tạm dừng hoặc chơi nhạc.
playpausebtn.addEventListener("click", playpauseClick);

// Thêm sự kiện click vào nút volume
volumeicon.addEventListener("click", volumeiconClick);

// Sự kiện click vào nút loop
loopbtn.addEventListener("click", loopbtnClick);

//
timelineLeft = getPos(timeline)[0];
volumebarLeft = getPos(volumebar)[0];

$('[id^="playpausebtn_li_"]').bind("click", playpausebtn_li_Click);

window.addEventListener("load", function (args) {
    if ((document.getElementById('playlist')) ? true : false) {
        // Có playlist
        shufflebtn.className = "controlbtn alignright shufflebtn";
        nextbtn.className = "controlbtn nextbtn";
    }
    else {
        // Không có playlist
        shufflebtn.className = "controlbtn alignright shufflebtn disable";
        nextbtn.className = "controlbtn nextbtn disable";
    }
    var vol = getCookie("volume");
    if (vol == "") {
        setVolume(1);
    }
    else {
        setVolume(vol);
    }
})

window.addEventListener("beforeunload", function (args) {
    setCookie("volume", music.volume, 2);
})

shufflebtn.addEventListener("click", function sufflebtnClick() {

    if ((document.getElementById('playlist')) ? true : false) {
        if ($(this).hasClass("disable") == true)
            $(this).removeClass("disable");
        else
            $(this).addClass("disable");
    }
})



// Tính độ dài bài hát khi bài hát hoàn thành load
music.addEventListener("canplaythrough", function () {
    // Lưu lại độ dài bài hát.
    duration = music.duration;

    // set độ dài bài hát hiển trị trên player
    document.getElementById('timeduration').textContent = fromSecondToTime(duration);

    // Ban đầu nút ở nút play, 
    // sau khi bài hát load thành công và bắt đầu play thì chuyển nút sang nút pause.
    playpausebtn.className = "controlbtn pausebtn";
    movePlayedLine(music.currentTime / duration);

    high_current(); // highlight
    update_infospan();
    update_lyric()

    updateplaypauseBtn()

}, false);

music.addEventListener("pause",
    function musicPause() {
        var current = document.getElementById("musicPlayer").dataset.currenttrack;
        $('#playpausebtn_li_' + current).removeClass('pausebtn');
        $('#playpausebtn_li_' + current).addClass('playbtn');
    }
    , false);

music.addEventListener("playing",
    function musicPause() {
        var current = document.getElementById("musicPlayer").dataset.currenttrack;
        $('#playpausebtn_li_' + current).removeClass('playbtn');
        $('#playpausebtn_li_' + current).addClass('pausebtn');
    }
    , false);

function updateplaypauseBtn() {
    // Tất cả các nút btn trở về trạng thái play
    $('[id^="playpausebtn_li_"]').removeClass('pausebtn');
    $('[id^="playpausebtn_li_"]').addClass('playbtn');
    // Nút được nhấn ở trạng thái pause

    var current = document.getElementById("musicPlayer").dataset.currenttrack;
    $('#playpausebtn_li_' + current).removeClass('playbtn');
    $('#playpausebtn_li_' + current).addClass('pausebtn');
}

function high_current() {
    $('#playlist_ul li').css("background-color", "initial");
    var current = document.getElementById("musicPlayer").dataset.currenttrack;
    $('#playlist_ul li:eq(' + current + ')').css("background-color", "#dedede");
}
function update_infospan() {
    $('[id^="info_span_li_"]').hide();
    var current = document.getElementById("musicPlayer").dataset.currenttrack;
    $('#info_span_li_' + current).show();
}
function update_lyric() {
    $('[id^="lyricbox_li_"]').hide();
    var current = document.getElementById("musicPlayer").dataset.currenttrack;
    $('#lyricbox_li_' + current).show();
}
nextbtn.addEventListener("click", function nextbtnClick() {
    nextmusic();
})

// Helper
function setCookie(cname, cvalue, exdays) {
    if (exdays) {
        var d = new Date();
        d.setTime(d.getTime() + (exdays * 24 * 60 * 60 * 1000));
        var expires = "expires=" + d.toUTCString();
    }
    else var expires = "2";
    document.cookie = cname + "=" + cvalue + "; " + expires;
}

// Helper
function getCookie(cname) {
    var name = cname + "=";
    var ca = document.cookie.split(';');
    for (var i = 0; i < ca.length; i++) {
        var c = ca[i];
        while (c.charAt(0) == ' ') c = c.substring(1);
        if (c.indexOf(name) == 0) return c.substring(name.length, c.length);
    }
    return "";
}

// Helper
function fromSecondToTime(i) {
    // Chuyển giá trị từ seconds sang text dạng m:ss
    i = parseInt(i);
    var minutes = parseInt(i / 60);
    var seconds = i - 60 * minutes;
    if (seconds < 10)
        return (minutes + ":0" + seconds);
    else
        return (minutes + ":" + seconds);
}

function timeUpdate() {
    var playpercent = music.currentTime / duration * 100;
    var width = playpercent + "%";
    currentTimeSlider.style.width = width;
    
    // Update thanh thời gian
    if (music.currentTime === duration) {
        playpausebtn.className = "controlbtn playbtn";
    }

    // Update text hiển thị thời gian đang play.
    timecurrrent.textContent = fromSecondToTime( music.currentTime);

}

function musicended() {
    var btntype = loopbtn.className.toString();
    if ((document.getElementById('playlist')) ? true : false) {
        // Có playlist

        if ($('#shufflebtn').hasClass('disable') == false) {
            next_random_music();

            // Nhảy đến bài hát ngẫu nhiên.
        }
        else {
            if (btntype.indexOf(" looponebtn") >= 0) {
                setCurrentTime(0);
                movePlayedLine(0);
            }
            else if (btntype.indexOf(" loopbtn") >= 0) {
                // Nếu có playlist và trạng thái nút là loop 
                //      Kiểm tra xem có phải bài hát cuối không nếu phải thì nhảy lên đầu
                //      Nếu không phải thì nhảy đến bài hát kế tiếp.
                nextmusic();
            }
        }
    }
    else {
        // Không có playlist
        if (btntype.indexOf(" loopbtn") >= 0) {
            setCurrentTime(0);
            movePlayedLine(0);
        }
    }

}
function next_random_music() {
    var current = document.getElementById("musicPlayer").dataset.currenttrack;
    var count = document.getElementById("playlist_ul").dataset.trackcount;
    var next = Math.floor((Math.random() * count) + 1) -1;
    var playlist_li = document.getElementById("playlist_li_" + next);

    document.getElementById("musicPlayer").dataset.currenttrack = next;
    music.src = "../../Audio/" + playlist_li.dataset.url;
    setCurrentTime(0);
    movePlayedLine(0);
    //$('#playlist_ul li').css("background-color", "initial");
    //$('#playlist_ul li:eq(' + next + ')').css("background-color", "#2FEBEB");
}
function nextmusic() {
    var current = document.getElementById("musicPlayer").dataset.currenttrack;
    var count = document.getElementById("playlist_ul").dataset.trackcount;
    var next = (parseInt(current) + 1) % count;
    var playlist_li = document.getElementById("playlist_li_" + next);

    document.getElementById("musicPlayer").dataset.currenttrack = next;
    music.src = "../../Audio/" + playlist_li.dataset.url;
    setCurrentTime(0);
    movePlayedLine(0);
    //$('#playlist_ul li').css("background-color", "initial");
    //$('#playlist_ul li:eq(' + next + ')').css("background-color", "#2FEBEB");
}

// Chỉnh kích thước thanh timeslider
function playerBigSlider() {
    timeline.className = "timeslideloadedExtend";
    currentTimeSlider.className = "timeslidecurrentExtend";
    document.getElementById('timelinecontrol').className = "timeslideExtend";
    showTimeNode();
}

function playerSmallSlider() {
    timeline.className = "timeslideloaded";
    currentTimeSlider.className = "timeslidecurrent";
    document.getElementById('timelinecontrol').className = "timeslide";
    hideTimeNode();
}

function hideTimeNode() {
    timenode.style.display = "none";
}

function showTimeNode() {
    timenode.style.display = "block";
}

function moveObjectToPosition(obj, position) {
    if (position >= 0 && position <= 1) {
        obj.style.width = position * 100 + "%";
    }
    else if (position < 0) {
        obj.style.width = "0%";
    }
    else if (position > 1) {
        obj.style.width = "100%";
    }
}

function movePlayedLine(newposition) {
    moveObjectToPosition(currentTimeSlider, newposition);
}

function moveVolumeAvaiable(newposition) {
    moveObjectToPosition(volumeavaiable, newposition);
}

// Helper
function getPos(obj) {
    // get position relative with whole document.
    var curLeft = curTop = 0;
    if (obj.offsetParent) {
        do{
            curLeft += obj.offsetLeft;
            curTop += obj.offsetTop;
        }
        while(obj = obj.offsetParent);
    }
    return [curLeft, curTop];
}

function timelineClick(event) {
    // Khi sự kiện click vào thanh timeline
    var position = (event.pageX - timelineLeft ) / timeline.offsetWidth;
    
    // Di chuyển thanh nhạc đã play.
    movePlayedLine(position);

    // Set vị trí phát nhạc hiện tại.
    setCurrentTime(position * duration);
}

function volumeClick(event) {
    var position = (event.pageX - volumebarLeft) / volumebar.clientWidth;
    // Set volume hiện tại của bài hát.

    setVolume(position);

}

function setCurrentTime(seconds) {
    // Set vị trí hiện tại của bài hát.
    music.currentTime = seconds;
}

function setVolume(value) {
    value = Math.min(value, 1);
    value = Math.max(value, 0);
    music.volume = value;

    // Di chuyển thanh volumen giá trị hiện tại.
    moveVolumeAvaiable(value);

    // Thay đổi trạng thái icon volume
    if (value >= 0.66) {
        volumeicon.className = "controlbtn alignright volume3";
    }
    else if (value >= 0.33) {
        volumeicon.className = "controlbtn alignright volume2";
    }
    else if (value > 0) {
        volumeicon.className = "controlbtn alignright volume1";
    }
    else {
        volumeicon.className = "controlbtn alignright volume0";
    }
}

function playpauseClick() {
    if (music.currentTime > 0 && (music.paused == false)) {
        // Đang play
        music.pause();
        playpausebtn.className = "controlbtn playbtn";
    }
    else {
        if (music.currentTime === music.duration) {
            // Đã play xong. Set lại bắt đầu từ đầu.
            music.currentTime = 0;
        }
        music.play();
        playpausebtn.className = "controlbtn pausebtn";
    }
}

function MouseMove(args) {
    var position = (args.pageX - timelineLeft) / timeline.offsetWidth;

    // Di chuyển thanh nhạc đã play.
    movePlayedLine(position);
}

function MouseMoveVolume(args) {
    var position = (args.pageX - volumebarLeft) / volumebar.clientWidth;

    // Di chuyển thanh nhạc đã play.
    moveVolumeAvaiable(position);
}

function timenodeMouseDown(args) {
    flagMouseDown = true;
    window.addEventListener("mousemove", MouseMove,true);
    window.addEventListener("mouseup", timenodeMouseUp, true);
    music.removeEventListener("timeupdate", timeUpdate, false);
}

function timenodeMouseUp(args) {
    if (flagMouseDown == true ) {
        //var position = (args.pageX - timelineLeft) / timeline.offsetWidth;

        //// Di chuyển thanh nhạc đã play.
        //movePlayedLine(position);

        //// Set vị trí phát nhạc hiện tại.
        //setCurrentTime(position * duration);
        timelineClick(args);

        window.removeEventListener("mousemove", MouseMove, true);
        window.removeEventListener("mouseup", timenodeMouseUp, true);
        music.addEventListener("timeupdate", timeUpdate, false);
    }
    flagMouseDown = false;
}

function volumenodeMouseDown(args) {
    flagvolume = true;
    window.addEventListener("mousemove", MouseMoveVolume, true);
    window.addEventListener("mouseup", volumenodeMouseUp, true);
}

function volumenodeMouseUp(args) {
    if (flagvolume == true) {
        //var position = (args.pageX - timelineLeft) / timeline.offsetWidth;

        //// Di chuyển thanh nhạc đã play.
        //moveVolumeAvaiable(position);

        //// Set vị trí phát nhạc hiện tại.
        //setCurrentTime(position * duration);
        volumeClick(args);

        window.removeEventListener("mousemove", MouseMoveVolume, true);
        window.removeEventListener("mouseup", volumenodeMouseUp, true);
    }
    flagvolume = false;
}

function volumeiconClick() {
    var currentvolume = music.volume;
    if (currentvolume > 0) {
        setCookie("volume", currentvolume);
        setVolume(0);
    }
    else {
        var vol = getCookie("volume");
        setVolume(vol);
    }
}

function loopbtnClick() {
    var btntype = loopbtn.className.toString();
    if (btntype.indexOf(" loopbtn") >= 0) {
        loopbtn.className = "controlbtn alignright noloopbtn";
    }
    else if (btntype.indexOf(" noloopbtn") >= 0) {
        loopbtn.className = "controlbtn alignright looponebtn";
        if ((document.getElementById('playlist')) ? true : false) {
            // Có playlist
            loopbtn.className = "controlbtn alignright looponebtn";
        }
        else {
            // Không có playlist
            loopbtn.className = "controlbtn alignright loopbtn";
        }
    }
    else if (btntype.indexOf(" looponebtn") >= 0) {
        loopbtn.className = "controlbtn alignright loopbtn";
    }
}



//------------------------------------------------------------------------------
// FUNCTION BAR

// Tham chiếu đến nút share fabebook
var fbshare = document.getElementById('fbshare');

// Tham chiếu đến nút share trên g+
var ggpluslogo = document.getElementById('ggpluslogo');

var embedbox = document.getElementById('embedbox');
var embedbtn = document.getElementById('embedbtn');

// Tham chiếu đến nút report.
var reportbtn = document.getElementById('reportbtn');

// Tham chiếu đến khung form report.
var reportpane = document.getElementById('reportpane');

// Tham chiếu đến radio "Lỗi khác"
var radio_other = document.getElementById('report7');

// Tham chiếu đến box textarea lỗi khác
var contentreport = document.getElementById('contentreport');


// Sự kiện nhấn nút share facebook.
fbshare.addEventListener("click", fbshareClick);

// Sự kiện nhất nút share google.
ggpluslogo.addEventListener("click", ggplusClick);

// Sự kiện nhất nút lấy mã nhúng.
embedbtn.addEventListener("click", embedbtnClick);

// Sự kiện nhất nút báo cáo sự cố.
reportbtn.addEventListener("click", reportbtnClick);

function show(obj) {
    obj.className = obj.className.replace("hide", "show");
}
function hide(obj) {
    obj.className = obj.className.replace("show", "hide");
}
function isStringContains(str1, str2) {
    if (str1.indexOf(str2) >= 0)
        return true;
    return false;
}
function fbshareClick() {
    
    var url = "http://www.facebook.com/sharer/sharer.php?u=";
    url += "http://mp3.zing.vn/bai-hat/Nguoi-Dien-Yeu-Minh-Hang/ZWZ9Z699.html";
    //url += document.URL;
    window.open(url, "_blank", "fullscreen=no, width=500, height=350px, top=100, left=150,");
    
}

function ggplusClick() {
    var url = "https://plusone.google.com/_/+1/confirm?hl=ru&url=_URL_&title=_TITLE_";
    url = url.replace("_URL_", "http://mp3.zing.vn/bai-hat/Nguoi-Dien-Yeu-Minh-Hang/ZWZ9Z699.html");
    url = url.replace("_TITLE_", "Tên bài hát");
    //url += document.URL;
    var sharewindow = window.open(url, "_blank", "fullscreen=no, width=500, height=350px, top=100, left=150,");
    
}

function embedbtnClick() {
    if (embedbox.style.display == "none") {
        embedbox.style.display = "block";
    }
    else if (embedbox.style.display == "block") {
        embedbox.style.display = "none";
    }
}

function reportbtnClick() {
    if (isStringContains(reportpane.className, "hide") == true) {
        show(reportpane);
    }
    else if (isStringContains(reportpane.className, "show") == true) {
        hide(reportpane);
    }
}

$('input:radio[name="report"]').change(function () {
    if (radio_other.checked == true) {
        show(contentreport);
    }
    else {
        hide(contentreport);
    }
});


function playpausebtn_li_Click() {
    var btn = $(this);
    var listitem = btn.parent().parent();

    // Lấy số id của item trong list
    var tracknumber = listitem.attr('data-tracknumber');

    // Gán current cho player.
    document.getElementById("musicPlayer").dataset.currenttrack = tracknumber;

    // gán source âm thanh cho trình phát nhạc
    music.src = "../../Audio/" + listitem.attr('data-url');

    setCurrentTime(0);
    movePlayedLine(0);
}

