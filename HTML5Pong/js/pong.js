// User input allowed (WS for the left paddle and
// up and down arrows for the right paddle)
var KEY = {
	UP: 38,
	DOWN: 40,
	W: 87,
	S: 83
}

var pingpong = {
	scoreA: 0,
	scoreB: 0
}
pingpong.pressedKeys = [];
pingpong.ball = {
	speed: 5,
	x: 150,
	y: 100,
	directionX: 1,
	directionY: 1
}

$(function(){
	// set interval to call gameloop every 30 milliseconds
	pingpong.timer = setInterval(gameloop, 30);
	// mark down what key is down and up into an array called
	// "pressedKeys".
	$(document).keydown(function(e){
		pingpong.pressedKeys[e.which] = true;
		});
	$(document).keyup(function(e){
		pingpong.pressedKeys[e.which] = false;
		});
});

function gameloop(){
	moveBall();
	movePaddles();
	if (isGameFinished()){
		clearInterval(pingpong.timer);
		var winner = pingpong.scoreA > pingpong.scoreB ? "A" : "B";
		$("#playground").html("Player " + winner + " won the match!");
	}
}

function movePaddles(){
	// use custom timer to continuously check if a key is pressed
	if (pingpong.pressedKeys[KEY.UP]){
		var top = parseInt($("#paddleB").css("top"));
		$("#paddleB").css("top", top-5);
	}
	if (pingpong.pressedKeys[KEY.DOWN]){
		var top = parseInt($("#paddleB").css("top"));
		$("#paddleB").css("top", top+5);		
	}
	if (pingpong.pressedKeys[KEY.W]){
		var top = parseInt($("#paddleA").css("top"));
		$("#paddleA").css("top", top-5);
	}
	if (pingpong.pressedKeys[KEY.S]){
		var top = parseInt($("#paddleA").css("top"));
		$("#paddleA").css("top", top+5);
	}
}

function moveBall(){
	var playgroundHeight = parseInt($("#playground").height());
	var playgroundWidth = parseInt($("#playground").width());
	var ball = pingpong.ball;
	var ballWidth = parseInt($("#ball").width());
	// check playground boundary
	// check bottom edge
	if (ball.y + ball.speed*ball.directionY > playgroundHeight - ballWidth){
		ball.directionY = -1;
	}
	// check top edge
	if (ball.y + ball.speed*ball.directionY < 0){
		ball.directionY = 1;
	}
	// check right edge
	if (ball.x + ball.speed*ball.directionX > playgroundWidth - ballWidth){
		playerBLost();
		resetBall(ball);
		ball.directionX = -1;
	}
	// check left edge
	if (ball.x + ball.speed*ball.directionX < 0){
		playerALost();
		resetBall(ball);
		ball.directionX = 1;
	}
	// update position
	ball.x += ball.speed * ball.directionX;
	ball.y += ball.speed * ball.directionY;
	// check moving paddle here later
	if (ballCollidesWithLeftPaddle(ball)){
		ball.directionX = 1;
	}
	if (ballCollidesWithRightPaddle(ball)){
		ball.directionX = -1;
	}
	// draw graphics
	$("#ball").css({
		"left" : ball.x,
		"top" : ball.y
	});
}

function ballCollidesWithLeftPaddle(ball){
	var paddleAX = parseInt($("#paddleA").css("left")) + parseInt($("#paddleA").css("width"));
	var paddleAYBottom = parseInt($("#paddleA").css("top")) + parseInt($("#paddleA").css("height"));
	var paddleAYTop = parseInt($("#paddleA").css("top"));
	return ball.x + ball.speed*ball.directionX < paddleAX &&
		   ball.y + ball.speed*ball.directionY >= paddleAYTop &&
		   ball.y + ball.speed*ball.directionY >= paddleAYTop;
}

function ballCollidesWithRightPaddle(ball){
	var paddleBX = parseInt($("#paddleB").css("left"));
	var paddleBYBottom = parseInt($("#paddleB").css("top")) + parseInt($("#paddleB").css("height"));
	var paddleBYTop = parseInt($("#paddleB").css("top"));
	var ballWidth = parseInt($("#ball").width());
	return ball.x + ball.speed*ball.directionX >= paddleBX - ballWidth &&
		   ball.y + ball.speed*ball.directionY >= paddleBYTop &&
		   ball.y + ball.speed*ball.directionY >= paddleBYTop;
}

function playerBLost()
{
	pingpong.scoreA++;
	$("#scoreA").html(pingpong.scoreA);
}

function playerALost()
{
	pingpong.scoreB++;
	$("#scoreB").html(pingpong.scoreB);
}

function resetBall(ball)
{
	ball.x = 200;
	ball.y = 100;
	$("#ball").css({
		"left": ball.x,
		"top": ball.y,
	});
}

function isGameFinished()
{
	return pingpong.scoreA >= 10 || pingpong.scoreB >= 10;
}
