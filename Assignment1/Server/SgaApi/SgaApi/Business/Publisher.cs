using RabbitMQ.Client;
using System;
using System.Text;

namespace SgaApi.Business
{
    public class Publisher
    {
        public void SendMessage(string routeKey, string message)
		{
			try
			{
                var factory = new ConnectionFactory() { HostName = "129.114.104.76", UserName = "test", Password = "test" };
				using (var connection = factory.CreateConnection())
                using (var channel = connection.CreateModel())
                {
                    channel.ExchangeDeclare(exchange: "amq.direct", type: "direct", durable:true);
                    var body = Encoding.UTF8.GetBytes(message);
                    channel.BasicPublish(exchange: "amq.direct", routingKey: routeKey, basicProperties: null, body: body);
                    Console.WriteLine(" [x] Sent '{0}':'{1}'", routeKey, message);
                }
			} catch (Exception ex) {
                Console.WriteLine(ex.Message);
			}
		}
    }
}
