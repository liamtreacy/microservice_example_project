using System.ComponentModel;

var p = new Printer();
p.Print("starting up");

string default_host_name = "localhost";

var host_name = Environment.GetEnvironmentVariable("HOST");

if(host_name == null)
{
    host_name = default_host_name;
}

var queue_name = "random_numbers_queue";//Environment.GetEnvironmentVariable("QUEUE");

// Establish rabbit connection

var message_reader = new MessageReader(host_name);

message_reader.Listen(queue_name);

p.Print("NEAR END");

Console.ReadLine();

