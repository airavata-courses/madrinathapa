var express = require('express');
var cors = require('cors');
var amqp = require('amqplib/callback_api');

var app = express();

app.use(cors())

app.get('/',function(req,res){
	res.send("Connected to the NODE API Gateway!");
});

app.get('/greeting',function(req,res){
	amqp.connect('amqp://test:test@129.114.104.76', function(err, conn) {
		conn.createChannel(function(err, ch) {
		var exchange = 'amq.direct';
	    var routingKey = 'greet';
	    var msg = req.query.name;

	    ch.assertExchange(exchange, 'direct', {durable: true});
	    ch.publish(exchange, routingKey, Buffer.from(msg));
	    console.log(" [x] Sent %s:'%s'", routingKey, msg);
	    console.log(' [*] Waiting for logs. To exit press CTRL+C');
	    ch.consume('greetresponse', function(msg) {
	        res.send(msg.content.toString());
	      }, {noAck: true});
		setTimeout(function() { ch.close(); conn.close(); }, 2000);
	    });
	});
});

app.get('/circle',function(req,res){
	amqp.connect('amqp://test:test@129.114.104.76', function(err, conn) {
		conn.createChannel(function(err, ch) {
		var exchange = 'amq.direct';
	    var routingKey = 'circle';
	    var msg = req.query.radius;

	    ch.assertExchange(exchange, 'direct', {durable: true});
	    ch.publish(exchange, routingKey, Buffer.from(msg));
	    console.log(" [x] Sent %s:'%s'", routingKey, msg);
	    console.log(' [*] Waiting for logs. To exit press CTRL+C');

	    ch.consume('circleresponse', function(msg) {
	        res.send(msg.content.toString());
	      }, {noAck: true});
	    
	    setTimeout(function() { ch.close(); conn.close(); }, 2000);
	    });
	});
});

app.get('/square',function(req,res){
	amqp.connect('amqp://test:test@129.114.104.76', function(err, conn) {
		conn.createChannel(function(err, ch) {
		var exchange = 'amq.direct';
	    var routingKey = 'square';
	    var msg = req.query.name;

	    ch.assertExchange(exchange, 'direct', {durable: true});
	    ch.publish(exchange, routingKey, Buffer.from(msg));
	    console.log(" [x] Sent %s:'%s'", routingKey, msg);

	    console.log(' [*] Waiting for logs. To exit press CTRL+C');

	    ch.consume('squareresponse', function(msg) {
	        res.send(msg.content.toString());
	      }, {noAck: true});
	    setTimeout(function() { ch.close(); conn.close(); }, 2000);
	    });
	});
});
app.listen(58912,function(){
	console.log("listening on port 58912");
});