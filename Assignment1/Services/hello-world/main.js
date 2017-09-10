var amqp = require('amqplib/callback_api');

amqp.connect('amqp://localhost', function(err, conn) {
  conn.createChannel(function(err, ch) {
    var ex = 'amq.direct';

    ch.assertExchange(ex, 'direct', {durable: true});

    ch.assertQueue('', {exclusive: true}, function(err, q) {
      console.log(' [*] Waiting for logs. To exit press CTRL+C');

    ch.bindQueue(q.queue, ex, "greet");
    ch.consume(q.queue, function(msg) {
        var response = JSON.stringify({ result: "Welcome "+ msg.content.toString() +"!" });
        ch.publish(ex, "greetresponse", new Buffer(response));
        console.log(" [x] Sent %s: '%s'", "greetresponse", response);
        //console.log("[x] %s: '%s'", msg.fields.routingKey, msg.content.toString());
      }, {noAck: false});
    });
  });
});
