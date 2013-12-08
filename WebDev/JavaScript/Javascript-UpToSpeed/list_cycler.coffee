class ListCycler
  constructor: (@parentContainer) ->

  cycle: ->
    listContainer = $(@parentContainer)
    firstPost = $(@parentContainer + " li:first")
    firstPost.fadeOut ->
    	firstPost.remove()
    	listContainer.append(firstPost)
    	firstPost.fadeIn()


  $ -> // this is jquery document.ready function
    $("#cycler").click ->
    	cycler = new ListCycler "#posts"
    	cycler.cycle()



 // coffee -c list_cycler.coffee