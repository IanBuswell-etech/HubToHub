using RabbitMQ.Client;
using System;

namespace MiniHub.MessagePusher
{
    public class MqPusher : IMessagePusher
    {
        public MqPusher()
        {
            string host = "192.168.99.100"; // 192.168.99.100:32769
            var factory = new ConnectionFactory() { HostName = host, Port = 32768 };

            using (var connection = factory.CreateConnection())
            {
                using (var channel = connection.CreateModel())
                {
                    channel.QueueDeclare(
                        queue: "hello",
                        durable: false,
                        exclusive: false,
                        autoDelete: false,
                        arguments: null);
                }
            }
        }

        public void Initialise()
        {
            throw new NotImplementedException();
        }

        public void PushMessage(object o)
        {
            throw new NotImplementedException();
        }
    }
}
