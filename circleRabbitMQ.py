import pika
import sys
import json

print("[x] starts here")

credentials = pika.PlainCredentials('test', 'test')
parameters = pika.ConnectionParameters('129.114.104.76',credentials=credentials)

connection = pika.BlockingConnection(parameters)
channel = connection.channel()
channel.queue_declare(queue='circle', durable=True)

def getArea(radius):
    area = 3.14*float(radius)*float(radius)
    result = {'radius':float(radius),'area': float(area)}
    return json.dumps(result)

def publish(msg):
    channel.basic_publish(exchange='amq.direct', routing_key="circleresponse", body=msg)
    print(" [x] Sent %r:%r" % ("circle response", msg))

def callback(ch, method, properties, body):
    print("Body: %r" % (body))
    result = getArea(body)
    print("Final result: %r" % (result))
    publish(result)
    print(" [x] %r:%r" % (method.routing_key, body))

channel.basic_consume(callback, queue='circle', no_ack=True)
channel.start_consuming()
