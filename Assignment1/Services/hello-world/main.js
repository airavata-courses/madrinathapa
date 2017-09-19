var amqp = require('amqplib/callback_api');

amqp.connect('amqp://test:test@129.114.104.76', function(err, conn) {
  conn.createChannel(function(err, ch) {
    var ex = 'amq.direct';
    var queue ='greet';
    
    ch.assertExchange(ex, 'direct', {durable: true});

    ch.assertQueue(queue, {durable: true}, function(err, q) {
      console.log(' [*] Waiting for logs. To exit press CTRL+C');

    ch.bindQueue(queue, ex, "greet");
    
    ch.consume(queue, function(msg) {
        var response = JSON.stringify({ result: "Welcome "+ msg.content.toString() +"!" });
        ch.publish(ex, "greetresponse", new Buffer(response));
        console.log(" [x] Sent %s: '%s'", "greetresponse", response);
      }, {noAck: true});
    });
  });
});