function SetDotNetHelper() {
    alert("dfg");
}

var player;

function initialize() {
    //players.length = 0;
    //player = null;
    player = null;
    var tag = document.createElement('script');

    tag.src = "https://www.youtube.com/iframe_api";
    var firstScriptTag = document.getElementsByTagName('script')[0];
    firstScriptTag.parentNode.insertBefore(tag, firstScriptTag);

}

function onYouTubeIframeAPIReady() {
    console.log("juz");
}


function ready(newId) {
    player = null;
    player = new YT.Player('player', {
        height: '360',
        width: '640',
        videoId: newId,
        playerVars: { 'rel': 0, 'controls': 1 },
        events: {
            'onReady': onPlayerReady,
            'onStateChange': onPlayerStateChange
        }
    });
}

function onPlayerStateChange(event) {
    console.log("eeeee");
    if (event.data == YT.PlayerState.PLAYING) {
        console.log("????");
        window.dotNetHelper.invokeMethodAsync('StartTimer');
        window.dotNetHelper.invokeMethodAsync('ShowAnswers');
        console.log(event.target.getVideoUrl());
    }
}

function onPlayerReady(event) {
    console.log("readyyyy");
    window.dotNetHelper.invokeMethodAsync('SongReady', event.target.getVideoUrl());
}

function onPlayerReadyMulti(event) {
    console.log("readyyyyMultiii");
    //window.dotNetHelper.invokeMethodAsync('SongReady', event.target.getVideoUrl());
}

function loadNew(songId) {
player.loadVideoById({
        videoId: songId
    });
}

function SetDotNetHelper(dotNetHelper) {
    window.dotNetHelper = null;
    window.dotNetHelper = dotNetHelper;
}

function playVideo() {
    player.playVideo();
}

function pauseVideo() {
    player.seekTo(0);
    player.pauseVideo();
}

function getState(index) {
    console.log(player.getPlayerState());
    return player.getPlayerState();
}