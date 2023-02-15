var player;

function initialize() {
    player = null;
    var tag = document.createElement('script');

    tag.src = "https://www.youtube.com/iframe_api";
    var firstScriptTag = document.getElementsByTagName('script')[0];
    firstScriptTag.parentNode.insertBefore(tag, firstScriptTag);

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
    if (event.data == YT.PlayerState.PLAYING) {
        window.dotNetHelper.invokeMethodAsync('StartTimer');
        window.dotNetHelper.invokeMethodAsync('ShowAnswers');
    }
}

function onPlayerReady(event) {
    window.dotNetHelper.invokeMethodAsync('SongReady', event.target.getVideoUrl());
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
    return player.getPlayerState();
}