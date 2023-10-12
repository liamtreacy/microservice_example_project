using System.Text;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;

Thread.Sleep(15000);

var factory = new ConnectionFactory { HostName = "rabbitmq",
    DispatchConsumersAsync = true  };
using var connection = factory.CreateConnection();
using var channel = connection.CreateModel();

var queue = "random_numbers_queue";

channel.QueueDeclare(queue: queue,
                     durable: false,
                     exclusive: false,
                     autoDelete: false,
                     arguments: null);

Console.WriteLine(" [*] Waiting for messages.");

var consumer = new AsyncEventingBasicConsumer(channel);
consumer.Received += async (model, ea) =>
{
    var body = ea.Body.ToArray();
    var message = Encoding.UTF8.GetString(body);
    Console.WriteLine($" [x] Received {message}");
};
channel.BasicConsume(queue: queue,
                     autoAck: true,
                     consumer: consumer);

// TODO fix this
while (channel.IsOpen) {
    Thread.Sleep(1);
}