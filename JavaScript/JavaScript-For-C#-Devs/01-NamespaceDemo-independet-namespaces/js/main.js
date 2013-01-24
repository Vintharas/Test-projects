// main.js
// using jquery readdy function to say,
// once all scripts have been loading, go ahead and execute this code
$(function(){
	var o = new Vintharas.Order(1, "A Customer");
	alert(o.id);
	alert(o.customer.name);
});