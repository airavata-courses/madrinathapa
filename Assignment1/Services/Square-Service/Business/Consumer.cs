using System;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using System.Text;

namespace Square_Service.Business
{
    public class Consumer
    {
        public void ConsumeMessage()
        {
            try
            {
                var factory = new ConnectionFactory() { HostName = "129.114.104.76", UserName="test", Password="test" };
                using (var connection = factory.CreateConnection())
                using (var channel = connection.CreateModel())
                {
					channel.ExchangeDeclare(exchange: "amq.direct", type: "direct", durable: true);
				//	channel.QueueDeclare(queue: "square", durable: false, exclusive: false, autoDelete: false);

					Console.WriteLine(" [*] Waiting for messages.");
					 Publisher objPub = new Publisher();
					 SquareController objSq = new SquareController();

					 var consumer = new EventingBasicConsumer(channel);

						 consumer.Received += (model, ea) =>
						 {
							 var body = ea.Body;
							 var message = Encoding.UTF8.GetString(body);
							 var routingKey = ea.RoutingKey;
							 string result = objSq.GetSquareArea(message);
							 objPub.PublishResponse(result);
							 Console.WriteLine(" [x] Received '{0}':'{1}'", routingKey, message);
						 };
						 channel.BasicConsume(queue: "square", autoAck: true, consumer: consumer);
						 Console.ReadLine();
                }
            }
            catch (Exception ex)
            {
                Console.Write(ex.Message);
            }
        }
    }
}
