// customer.js
// Using Anonymous self executing function to create
// our namespace declarations and passing the Vintharas
// namespace so the Order class becomes part of it.
(function (ns) { // Get Required objects in order

// define the new object and add it to the namespace
ns.Customer = function (name)
{
    this.name = name
};

}(window.Vintharas = window.Vintharas || {}));