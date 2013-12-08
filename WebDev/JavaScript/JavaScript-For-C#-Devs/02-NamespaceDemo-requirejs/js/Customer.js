// customer.js
define( [],      // Required scripts (None)
    function(){  // Gets any required modules here like in main, order (None)
        function Customer(name){
            this.name = name;
        }
        return Customer; // return the object that requires 
                         // constructor to allow you to call it
    }
);