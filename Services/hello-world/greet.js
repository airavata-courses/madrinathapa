module.exports = function greet( options ) {

  this.add( 'role:greet,cmd:hello', function sum( msg, respond ) {
    respond( null, { result: "Welcome "+ msg.name +"!" } )
  })

  this.add( 'role:greet,cmd:goodbye', function product( msg, respond ) {
    respond( null, { result: "Goodbye "+ msg.name +"!"  } )
  })

  this.wrap( 'role:greet', function( msg, respond ) {
    msg.name  = (msg.name).valueOf()
    this.prior( msg, respond )
  })

}
