// main.js
require(["Order"], // Requires the Customer Module
    function(Order){ // Call with required model
        // Your initialization code
        var o = new Order(1, "A Customer");
        alert(o.id);
        alert(o.customer.name);
    }
);