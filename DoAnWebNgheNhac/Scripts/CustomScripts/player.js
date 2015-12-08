
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
}, false);

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
        if (btntype.indexOf(" looponebtn") >= 0) {
            setCurrentTime(0);
            movePlayedLine(0);
        }
        else if (btntype.indexOf(" loopbtn") >= 0) {
            // Nếu có playlist và trạng thái nút là loop 
            //      Kiểm tra xem có phải bài hát cuối không nếu phải thì nhảy lên đầu
            //      Nếu không phải thì nhảy đến bài hát kế tiếp.
        }
        if (shufflebtn.className.indexOf(" disable") >= 0) {
            // Nhảy đến bài hát ngẫu nhiên.
        }
        else {
            // Nhảy đến bài hảt kế tiếp.
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