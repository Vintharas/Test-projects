// #. variables and functions

person = "Jaime"

greet = (name = 'Stranger') ->
  alert 'Hello #{name}'

sum = (a, b) ->
  a + b

// #. jQuery and CoffeeScript

# $('#newCoffee a').click(function() {
#   var coffee, name;
#   name = prompt('Name of coffee:');
#   coffee = $("<li>" + name + "</li>");
#   $('ul.drink').append(coffee);
# });

$('#newCoffee a').click ->
  name = prompt 'Name of coffee:'
  coffee = $ "<li>#{name}</li>"
  $('ul.drink').append coffee

# $('.drink li a').click(function(e) {
#   e.preventDefault();
#   alert($(this).text());
# });

$('.drink li a').click (e) ->
  e.preventDefault()
  alert $(@).text()

# $('.drink li').mouseenter(function() {
#   $(this).find('span').show();
# });
# $('.drink li').mouseleave(function() {
#   $(this).find('span').hide();
# });

$('.drink li').mouseenter ->
  $(@).find('span').show()

$('.drink li').mouseleave ->
  $(@).find('span').hide()

# $('.drink li').hover(function() {
#   $(this).find('span').show();
# }, function() {
#   $(this).find('span').hide();
# });

$('.drink li').hover ->
  $(@).find('span').show()
, ->
  $(@).find('span').hide()

// #. Conditionals and Operators

// if else

if age < 18
  alert 'under age'

alert 'under age' if age < 18

if age < 18 then aler 'under age'

if age < 18
  alert ' under age'
else
  alert 'of age'

if age < 18 then alert 'under age' else alert 'of age'

// operators
// CoffeeScript ----- JavaScript
// == is              ===
// != isnt            !==
// not                !
// and                &&
// or                 ||
// true yes on        true
// false no off       false

if paid() and coffe() is on then pour()

addCaffeine() if not Decaf()

addCaffeine() unless Decaf()

if 2 < newLevel < 5
  alert "in rage"

// switch
message = switch CupsOfCoffee
  when 0 then "Asleep"
  when 1 then "Awake"
  else "Dangerous"

// check for exists (not undefined nor null)
if cupsOfCoffee?
  alert "it Exists!"

alert "it exists!" if cupsOfCoffee?

// set unexistent variable (undefined or null)
cupsOfCoffee ?= 0

// call method only if it exists
coffePot?.brew()
vehicle.start_engine?().shift_gear?() 

// #.Arrays, Objects, Iterations

range = [1..5] // 1, 2, 3, 4, 5
range = [1...5] // 1, 2, 3, 4
range[1..2] // 1, 2
range[1...range.length] // 1, 2, 3, 4, 5
range[1..-1] // same as above

storeLocations = [
  'Orlando'
  'Winter Park'
  'Sanford'
]

storeLocation.forEach (location, index) ->
  alert 'woho! #{location}"

for location in storeLocations
  alert 'woho! #{location}"


alert 'woho! #{location}" for location in storeLocations






