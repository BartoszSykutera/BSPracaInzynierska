export function initialize() {
    var tag = document.createElement('script');

    tag.src = "https://www.youtube.com/iframe_api";
    var firstScriptTag = document.getElementsByTagName('script')[0];
    firstScriptTag.parentNode.insertBefore(tag, firstScriptTag);

}

var player;
const players = [];

export function ready(newplayerid) {
    player = new YT.Player(newplayerid, {
        height: '500',
        width: '500',
        videoId: newplayerid,
        playerVars: {'rel': 0, 'controls': 1},
        events: {
            'onReady': onPlayerReady,
            'onStateChange': onPlayerStateChange
        }
    });

    players.push(player);
}

export function onPlayerStateChange(event) {
    console.log("funkcja sie wywolala");
    if (event.data == YT.PlayerState.PLAYING) {
        console.log("state cos tam");
        window.dotNetHelper.invokeMethodAsync('StartTimer');

    }

}

export function SetDotNetHelper(dotNetHelper) {
    console.log("seal vi do kurwy");
    window.dotNetHelper = dotNetHelper;
}

export function onPlayerReady(event) {
    //event.target.playVideo();
}

export function playVideo(index) {
    players[index].playVideo();
}

export function pauseVideo(index) {
    players[index].pauseVideo();
}

export function getState(index) {
    return player[index].getPlayerState();
}



