using RabbitMQ.Client;

namespace RabbitMQExample
{
    public class Channel
    {
        public static IModel GetChannel(string queueName)
        {
            var factory = new ConnectionFactory
            {
                Uri = new Uri("amqp://guest:guest@localhost:5672")
            };

            using var connection = factory.CreateConnection();
            using var channel = connection.CreateModel();
            channel.QueueDeclare(queueName, true, false, false, null);

            return channel;
        }
    }
}
