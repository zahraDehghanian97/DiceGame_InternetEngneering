
var dice = {
    sides: 6,
    roll: function () {
        var randomNumber = Math.floor(Math.random() * this.sides) + 1;
        return randomNumber;
    },
    defaultRoll: function () {
        var placeholder = document.getElementById('dice1');
        placeholder.classList.remove("display");
        placeholder.classList.add("nodisplay");

    }
}



//Prints dice roll to the page
function win(number) {
    alert('Player ' + number + ' wins !!!!');
    alert('The Game wil be reset');
    current = 0;
    turn = 0;
    score0 = 0;
    before = 0;
    score1 = 0;
    firstTime = true;
    document.getElementById('roundScore0').innerHTML = 0;
    document.getElementById('roundScore1').innerHTML = 0;
    document.getElementById('currentScore0').innerHTML = 0;
    document.getElementById('currentScore1').innerHTML = 0;
    CURRENT = document.getElementById('currentScore0');
    SCORE = document.getElementById('roundScore0');
    var dot = document.getElementById("dot1");
    dot.classList.remove("display");
    dot.classList.add("nodisplay");
    var dot = document.getElementById("dot0");
    dot.classList.remove("nodisplay");
    dot.classList.add("display");
    result = dice.defaultRoll();
    BOARD.style.backgroundImage = 'url(../images/' + turn + '.png")';
};
function rolldice1(number) {
    var placeholder = document.getElementById('dice1');
    placeholder.classList.remove("nodisplay");
    placeholder.classList.add("display");
    placeholder.innerHTML = '<img src="../images/dice-' + number + '.png" class="placeholder"></a>';
};

var before = 0;
var current = 0;
var turn = 0;
var score0 = 0;
var score1 = 0;
var topScore = 99;
var firstTime = true;
var BOARD = document.getElementById('board');
//var MAXSCORE = document.getElementById('maxScore');
//MAXSCORE.innerHTML = 'score';
var ROLLDICE = document.getElementById('ROLLDICE');
var HOLD = document.getElementById('hold');
var CURRENT = document.getElementById('currentScore' + turn);
var SCORE = document.getElementById('roundScore' + turn);
HOLD.onclick = function () {
    // if(MAXSCORE.innerHTML!="score")
    //     topScore = MAXSCORE.innerHTML.parseInt()-1;
    if (turn == 0) {
        score0 = current + score0;
        SCORE.innerHTML = score0;
        if (score0 > topScore)
            win(0);
    }
    else {
        score1 = current + score1;
        SCORE.innerHTML = score1;
        if (score1 > topScore)
            win(1);
    }
    before = 0;
    current = 0;
    CURRENT.innerHTML = current;
    var dot = document.getElementById("dot" + turn);
    dot.classList.remove("display");
    dot.classList.add("nodisplay");
    turn = (turn + 1) % 2;
    var dot = document.getElementById("dot" + turn);
    dot.classList.remove("nodisplay");
    dot.classList.add("display");
    SCORE = document.getElementById('roundScore' + turn);
    CURRENT = document.getElementById('currentScore' + turn);
    BOARD.style.backgroundImage = 'url("../images/' + turn + '.png")';

}


ROLLDICE.onclick = function () {
    var result1 = dice.roll();
    if (firstTime) {
        result1 = 1;
        firstTime = false;
    }
    if (result1 == 6 && before == 6) {
        if (turn == 0) {
            score0 = 0;
        }
        else {
            score1 = 0;
        }
        SCORE.innerHTML = 0;
    }
    if (result1 == 1 || (result1 == 6 && before == 6)) {
        rolldice1(result1);
        var dot = document.getElementById("dot" + turn);
        dot.classList.remove("display");
        dot.classList.add("nodisplay");
        turn = (turn + 1) % 2;
        var dot = document.getElementById("dot" + turn);
        dot.classList.remove("nodisplay");
        dot.classList.add("display");
        current = 0;
        before = 1;
        CURRENT.innerHTML = "0";
        SCORE = document.getElementById('roundScore' + turn);
        CURRENT = document.getElementById('currentScore' + turn);
        BOARD.style.backgroundImage = 'url("../images/' + turn + '.png")';

    }
    else {
        rolldice1(result1);
        before = result1;
        current = current + result1;
        CURRENT.innerHTML = current;


    }
    


};

var NEWGAME = document.getElementById('NEWGAME');
NEWGAME.onclick = function () {
    current = 0;
    turn = 0;
    score0 = 0;
    score1 = 0;
    before = 0;
    firstTime = true;
    document.getElementById('roundScore0').innerHTML = 0;
    document.getElementById('roundScore1').innerHTML = 0;
    document.getElementById('currentScore0').innerHTML = 0;
    document.getElementById('currentScore1').innerHTML = 0;
    CURRENT = document.getElementById('currentScore0');
    SCORE = document.getElementById('roundScore0');
    result = dice.defaultRoll();
    var dot = document.getElementById("dot1");
    dot.classList.remove("display");
    dot.classList.add("nodisplay");
    var dot = document.getElementById("dot0");
    dot.classList.remove("nodisplay");
    dot.classList.add("display");
    // var back = document.getElementsByClassName("gameBoard");
    // back.style.backgroundImage='url("../images/back.png")';
    BOARD.style.backgroundImage = 'url("../images/' + turn + '.png")';
    // window.alert("before game");
    window.alert(getGame());
    var json = { t: turn, c1: current, c2: current, s1: score0, s2: score1 };
    $.ajax({
        url: "SaveGame",
        type: "POST",
        dataType: "json",
        data: JSON.stringify(json),
        contentType: "application/json; charset=utf-8"
        
    });
    //window.alert("after ajax");
    //rolldice(result);
};

function getGame() {
    var json = {}
    json.Turn = turn.toString();
    var current1;
    var current2;
    if (turn == 0) {
        current1 = current;
        current2 = 0;
    }
    else {
        current2 = current;
        current1 = 0;
    }
    json.Current1 = current1.toString();
    json.Current2 = current2.toString();
    json.Score1 = score0.toString();
    json.Score2 = score1.toString();
    return JSON.stringify(json);
}



/*
$(function () {
    $("#NEWGAME").click(function () {
        var game = getgame();

        
        if (game == null) {
            alert("can not send json");
            return;
        }

        var json = $.toJSON(game);

        $.ajax({
            url: '/Game/SaveGame',
            type: 'POST',
            dataType: 'json',
            data: json,
            contentType: 'application/json; charset=utf-8',
           // success: function (data) {
           //     // get the result and do some magic with it
           //     var message = data.Message;
           //     $("#resultMessage").html(message);
           // }
        });
    });
});
*/