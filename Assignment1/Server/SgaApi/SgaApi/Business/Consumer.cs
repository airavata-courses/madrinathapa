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
			    ManualResetEvent manualResetEvent = new ManualResetEvent(false);
				var factory = new ConnectionFactory() { HostName ="129.114.104.76", UserName = "test", Password = "test" };
				using (var connection = factory.CreateConnection())
				using (var channel = connection.CreateModel())
				{
					//channel.ExchangeDeclare(exchange: "amq.direct", type: "direct", durable: true);
					//var queueName = channel.QueueDeclare().QueueName;

					Console.WriteLine(" [*] Waiting for messages.");

					var consumer = new EventingBasicConsumer(channel);

					consumer.Received += (model, ea) =>
					{
						var body = ea.Body;
						var message = Encoding.UTF8.GetString(body);
						var routingKey = ea.RoutingKey;
                        result = message;
                        manualResetEvent.Set();
					};
                    if(!string.IsNullOrEmpty(result)){
                        return result;
                    }
					channel.BasicConsume(queue: queue, autoAck: true, consumer: consumer);
					manualResetEvent.WaitOne(TimeSpan.FromSeconds(10));
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
