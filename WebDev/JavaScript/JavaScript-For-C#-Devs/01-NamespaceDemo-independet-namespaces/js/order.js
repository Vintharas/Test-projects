// order.js
// Using Anonymous self executing function to create
// our namespace declarations and passing the Vintharas
// namespace so the Order class becomes part of it.
(function (ns) { // Get Required objects in order

// define the new object and add it to the namespace
ns.Order = function (id, customerName)
{
    this.id = id,
    this.customer = new ns.Customer(customerName);
};

}(window.Vintharas = window.Vintharas || {}));

// Even though the code inside the main function is being called
// immediately as the script is parsed so we are adding the class
// definition to the namespace, the code inside the function itself
// is not executed until an order is actually created, which is much
// later when all script files have been executed correctly.