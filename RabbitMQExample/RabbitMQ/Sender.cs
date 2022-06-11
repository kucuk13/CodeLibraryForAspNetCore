using System.Text;
using Newtonsoft.Json;
using RabbitMQ.Client;

namespace RabbitMQExample
{
    public class Sender
    {
        public static void Produce(string queueName, string message)
        {
            var channel = Channel.GetChannel(queueName);
            var body = Encoding.UTF8.GetBytes(JsonConvert.SerializeObject(message));
            channel.BasicPublish("", "demo-queue", null, body);
        }
    }
}
