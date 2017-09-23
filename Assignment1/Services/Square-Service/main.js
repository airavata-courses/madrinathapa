var amqp = require('amqplib/callback_api');

amqp.connect('amqp://test:test@129.114.104.76', function(err, conn) {
  conn.createChannel(function(err, ch) {
    var ex = 'amq.direct';
    var queue ='square';
    
    ch.assertExchange(ex, 'direct', {durable: true});

    ch.assertQueue(queue, {durable: true}, function(err, q) {
      console.log(' [*] Waiting for logs. To exit press CTRL+C');

    ch.bindQueue(queue, ex, "square");
    
    ch.consume(queue, function(msg) {
        var side = msg.content.toString();
        var area= side*side;      
        var response = JSON.stringify({"Side": side,"Area":area});
        ch.publish(ex, "squareresponse", new Buffer(response));
        console.log(" [x] Sent %s: '%s'", "squareresponse", response);
      }, {noAck: true});
    });
  });
});