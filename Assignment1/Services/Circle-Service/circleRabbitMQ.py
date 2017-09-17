import pika
import sys
import json

connection = pika.BlockingConnection(pika.ConnectionParameters(
        host='rmq-container'))
channel = connection.channel()

channel.exchange_declare(exchange='amq.direct',
                         exchange_type='direct', durable=True)

result = channel.queue_declare(exclusive=True)
queue_name = result.method.queue

print("queue name %r" % (queue_name))

binding_key = "circle"
channel.queue_bind(exchange="amq.direct",
                  queue=queue_name,
                  routing_key=binding_key)


print(' [*] Waiting for logs. To exit press CTRL+C')

class Circle:
    def __init__(self):
        self.cache = {}
    def __call__(self, radius):
        area = 3.14*float(radius)*float(radius)
        result = {'radius':float(radius),'area': float(area)}
        return json.dumps(result)

cir = Circle()

class Publish:
    def __init__(self):
        self.cache={}
    def __call__(self, msg):
        channel.basic_publish(exchange='amq.direct',
                              routing_key="circleresponse",
                              body=msg)
        print(" [x] Sent %r:%r" % ("circle response", msg))

pub = Publish()

def callback(ch, method, properties, body):
    result = cir(body)
    print("Final result: %r" % (result))
    pub(result)
    print(" [x] %r:%r" % (method.routing_key, body))

result = channel.queue_declare(exclusive=True)
queue_name = result.method.queue

channel.basic_consume(callback,
                      queue=queue_name,
                      no_ack=True)

channel.start_consuming()
