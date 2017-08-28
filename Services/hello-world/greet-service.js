require( 'seneca' )()
  .use( 'greet' )
  .listen( { type:'tcp', pin:'role:greet' } )
