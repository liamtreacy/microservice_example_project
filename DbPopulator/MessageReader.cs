using System.Text;
using System.ComponentModel;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;

public class MessageReader
{
    private ConnectionFactory factory;
    private IConnection connection;
    private Printer p;

    public MessageReader(string host_name)
    {
        factory = new ConnectionFactory
        {
            HostName = host_name,
            DispatchConsumersAsync = true,
            AutomaticRecoveryEnabled = true,
            NetworkRecoveryInterval = TimeSpan.FromSeconds(20)
        };
        connection = factory.CreateConnection();

        p = new Printer();
    }

    public void Listen(string queue_name)
    {
       var worker = new BackgroundWorker();
       worker.DoWork += (s,e) => 
        {
            using var channel = connection.CreateModel();
            channel.QueueDeclare(queue: queue_name,
                                durable: false,
                                exclusive: false,
                                autoDelete: false,
                                arguments: null);

            var consumer = new AsyncEventingBasicConsumer(channel);

            consumer.Received += async (model, ea) =>
            {
                var body = ea.Body.ToArray();
                var message = Encoding.UTF8.GetString(body);

                p.Print($"RECV: {message}");
            };

            channel.BasicConsume(queue: queue_name,
                            autoAck: true,
                            consumer: consumer);

            while(true)
            {
                Thread.Sleep(1000);
            }  
        };
       worker.RunWorkerAsync();
    }
}
