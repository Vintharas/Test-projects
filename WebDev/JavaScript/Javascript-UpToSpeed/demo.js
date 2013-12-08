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
		privateMethod = function(){
			alert("Oh no! I'm private!");  // This is going to call the alert() method of the notifier
		}

		return {
			info: info,
			alert: alert,
			init: init,
			privateMethod: privateMethod
		}
	}();


	$(function(){

		// init
		notifierTwo.init();
		// cannot call notifierTwo.privateMethod();
		// you could expose it if you wanted (by adding it to the return)

		$("#messageSetter").click(function(){
			notifierTwo.alert("You clicked me!");
		})
	})