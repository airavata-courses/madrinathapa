
var SenecaWeb = require('seneca-web')
var Express = require('express')
var Router = Express.Router
var context = new Router()

var senecaWebConfig = {
      context: context,
      adapter: require('seneca-web-adapter-express'),
      options: { parseBody: false }
}


var app = Express()
	  .use(function(req, res, next) {
		  res.header("Access-Control-Allow-Origin", "*");
		  res.header("Access-Control-Allow-Headers", "Origin, X-Requested-With, Content-Type, Accept");
		  next();
	  })
      .use( require('body-parser').json() )
      .use( context )
      .listen(3000)

var seneca = require( 'seneca' )()
      .use( SenecaWeb, senecaWebConfig )
      .use( 'api' )
      .client( { type:'tcp', pin:'role:greet' } )
