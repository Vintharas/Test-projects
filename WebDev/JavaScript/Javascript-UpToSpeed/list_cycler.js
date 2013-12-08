var ListCycler = function(parentContainer){
	var listContainer = $(parentContainer);
	var firstPost =  $(parentContainer + " li:first");
	cycle = function(){
		firstPost.fadeOut(appendToEnd);
	};
	appendToEnd = function(post){
		firstPost.remove();
		$("#posts").append(firstPost);
		firstPost.fadeIn();
	};

	return{
		cycle: cycle
	}

};


$(function(){
	$("#cycler").click(function(){
		var cycler = new ListCycler("#posts"); // convention that emulates a class
		cycler.cycle();
	})
});