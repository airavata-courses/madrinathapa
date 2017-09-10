using System;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using System.Text;
using System.Threading;

namespace SgaApi.Business
{
    public class Consumer
	{
		public string ConsumeMessage(string queue)
		{
            string result = string.Empty;
			try
			{
				var factory = new ConnectionFactory() { HostName = "localhost" };
				using (var connection = factory.CreateConnection())
				using (var channel = connection.CreateModel())
				{
					channel.ExchangeDeclare(exchange: "amq.direct", type: "direct", durable: true);
					var queueName = channel.QueueDeclare().QueueName;

					Console.WriteLine(" [*] Waiting for messages.");

					var consumer = new EventingBasicConsumer(channel);

					consumer.Received += (model, ea) =>
					{
						var body = ea.Body;
						var message = Encoding.UTF8.GetString(body);
						var routingKey = ea.RoutingKey;
                        result = message;
						//channel.BasicAck(deliveryTag: ea.DeliveryTag, multiple: false);
						//Console.WriteLine(" [x] Received '{0}':'{1}'", routingKey, message);
					};
                    if(!string.IsNullOrEmpty(result)){
                        return result;
                    }
					channel.BasicConsume(queue: queue, autoAck: true, consumer: consumer);
					//Console.ReadLine();
				}
			}
			catch (Exception ex)
			{
				Console.Write(ex.Message);
                return ex.Message;
			}
            return result;
		}
	}
}
