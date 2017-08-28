module.exports = function api( options ) {

  var valid_ops = { hello:'hello', goodbye:'goodbye' }

  this.add( 'role:api,path:first', function( msg, respond ) {
    var operation = msg.args.params.operation
    var name = msg.args.query.name
    this.act( 'role:greet', {
      cmd:   valid_ops[operation],
      name:  name,
    }, respond )
  })


  this.add( 'init:api', function( msg, respond ) {
    this.act('role:web',{routes:{
      prefix: '/api',
      pin:    'role:api,path:*',
      map: {
        first: { GET:true, suffix:'/:operation' }
      }
    }}, respond )
  })

}
