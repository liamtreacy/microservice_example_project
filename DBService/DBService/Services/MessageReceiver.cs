using System.Text;
using System.ComponentModel;
using System.Diagnostics;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;

public class MessageReceiver : IMessageReceiver
{
    private int latestNumber = -1;
    private readonly ILogger<MessageReceiver> _logger;
    private readonly IDbConnector _dbConnector;

    public MessageReceiver(ILogger<MessageReceiver> logger, IDbConnector dbConnector)
    {
        _logger = logger;
        _dbConnector = dbConnector;
        var worker = new BackgroundWorker();
                worker.DoWork += (s,e) => 
                {
       // Thread.Sleep(15000);
logger.LogInformation("AWAKE NOW", DateTime.UtcNow.ToLongTimeString());
        var factory = new ConnectionFactory { HostName = "rabbitmq",
            DispatchConsumersAsync = true,
            UseBackgroundThreadsForIO = true  };
        //logger.LogInformation(" 1");  
        using var connection = factory.CreateConnection();
  //logger.LogInformation(" 2");  
        using var channel = connection.CreateModel();
//logger.LogInformation(" 3");  
        var queue = "random_numbers_queue";
//logger.LogInformation(" 4");  
        channel.QueueDeclare(queue: queue,
                            durable: false,
                            exclusive: false,
                            autoDelete: false,
                            arguments: null);

        logger.LogInformation(" [*] Waiting for messages.");

        var consumer = new AsyncEventingBasicConsumer(channel);
        consumer.Received += async (model, ea) =>
        {
            var body = ea.Body.ToArray();
            var message = Encoding.UTF8.GetString(body);
            latestNumber = Int32.Parse(message);

            // TODO why is this not working?
            dbConnector.UpdateDb(latestNumber).GetAwaiter().GetResult();
            logger.LogInformation($"RECEIVED MESSAGE {message}", DateTime.UtcNow.ToLongTimeString());
            Console.WriteLine($" [x] Received {message}");
        };
        channel.BasicConsume(queue: queue,
                            autoAck: true,
                            consumer: consumer);
                            
         while(true)
         {
            Thread.Sleep(1000);
         }      };
        worker.RunWorkerAsync();


    }
    
    public int GetLatestReceivedNumber()
    {
        return latestNumber;
    }
}