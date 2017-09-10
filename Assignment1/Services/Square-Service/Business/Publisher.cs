using System;
using RabbitMQ.Client;
using System.Text;

namespace Square_Service.Business
{
    public class Publisher
    {
        public void PublishResponse(string response)
        {
            try
            {
                var factory = new ConnectionFactory() { HostName = "localhost" };
                using (var connection = factory.CreateConnection())
                using (var channel = connection.CreateModel())
                {
                    channel.ExchangeDeclare(exchange: "amq.direct", type: "direct", durable: true);
                    var body = Encoding.UTF8.GetBytes(response);
                    channel.BasicPublish(exchange: "amq.direct", routingKey: "squareresponse", basicProperties: null, body: body);
                    Console.WriteLine(" [x] Sent '{0}':'{1}'", "squareresponse", response);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}
