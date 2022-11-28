var player;
const players = [];

export function initialize() {
    players.length = 0;
    player = null;
    var tag = document.createElement('script');

    tag.src = "https://www.youtube.com/player_api";
    var firstScriptTag = document.getElementsByTagName('script')[0];
    firstScriptTag.parentNode.insertBefore(tag, firstScriptTag);

}

export function ready(newplayerid) {
    player = new YT.Player(newplayerid, {
        height: '100',
        width: '100',
        videoId: newplayerid,
        playerVars: { 'rel': 0, 'controls': 1, 'start': 10 },
        events: {
            'onReady': onPlayerReady,
            'onStateChange': onPlayerStateChange
        }
    });

    players.push(player);
}

export function onPlayerStateChange(event) {
    console.log("wykrzyknik");
    if (event.data == YT.PlayerState.PLAYING) {
        window.dotNetHelper.invokeMethodAsync('StartTimer');
        console.log("znak zapytania?");
        console.log(event.target.getVideoUrl());
    }
}

export function SetDotNetHelper(dotNetHelper) {
    window.dotNetHelper = dotNetHelper;
}

export function onPlayerReady(event) {
    console.log(event.target.getVideoUrl());
    window.dotNetHelper.invokeMethodAsync('SongReady', event.target.getVideoUrl());
}

export function playVideo(index) {
    players[index].playVideo();
}

export function pauseVideo(index) {
    players[index].seekTo(10);
    players[index].pauseVideo();
}

export function getState(index) {
    console.log(players[index].getPlayerState());
    return players[index].getPlayerState();
}