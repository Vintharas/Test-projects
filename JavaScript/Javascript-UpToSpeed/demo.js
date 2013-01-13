	// it's better to use a function literal than an object literal
	var notifier = {
		info: function(message){
			$("#message").html(message).effect("highlight");
		}
		alert: function(message){
			$("#message").attr("class", "alert");
			$("#message").html(message).effect("highlight");
		}
	}

	// using a function literal instead
	var notifierTwo = function(){
		var initialMessage = "Welcome";
		init = function(){
			$("#message").html(initialMessage).effect("highlight");
		}
		info = function(message){
			$("#message").html(message).effect("highlight");
		};
		alert = function(message){
			$("#message").attr("class", "alert");
			$("#message").html(message).effect("highlight");
		};
		return {
			info: info,
			alert: alert,
			init: init
		}
	}();


	$(function(){

		// init
		notifier.info("Welcome!");

		$("#messageSetter").click(function(){
			notifier.alert("You clicked me!");
		})
	})