using System.ComponentModel;

var p = new Printer();
p.Print("starting up");

string default_msg_provider_host_name = "localhost";
string default_db_host_name = "localhost";
string default_queue_name = "random_numbers_queue";

string msg_provider_host_name;
string queue_name;
string db_host_name;

GetEnvVarOrDefault("HOSTMSG",default_msg_provider_host_name, out msg_provider_host_name);
GetEnvVarOrDefault("QUEUE", default_queue_name, out queue_name);
GetEnvVarOrDefault("HOSTDB", default_db_host_name, out db_host_name);

UpdateDbCommand.User = "";

// Establish rabbit connection
var message_reader = new MessageReader(msg_provider_host_name, 
                            (string s) => {
                                p.Print($"LAMBDA: {s}");
                            });

message_reader.Listen(queue_name);

Console.ReadLine();


void GetEnvVarOrDefault(in string envvar, in string default_val, out string s)
{
    s = Environment.GetEnvironmentVariable(envvar);

    if(s == null)
    {
        s = default_val;
    }
}