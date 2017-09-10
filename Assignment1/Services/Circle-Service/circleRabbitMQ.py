import pika
import sys
import json

connection = pika.BlockingConnection(pika.ConnectionParameters(
        host='localhost'))
channel = connection.channel()

channel.exchange_declare(exchange='amq.direct',
                         exchange_type='direct', durable=True)

result = channel.queue_declare(exclusive=True)
queue_name = result.method.queue


channel.queue_bind(exchange='amq.direct',
                       queue="circle",
                       routing_key="circle")

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

channel.basic_consume(callback,
                      queue="circle",
                      no_ack=True)

channel.start_consuming()
