var p = new Printer();
p.Print("starting up");

string default_msg_provider_host_name = "localhost";
string default_db_host_name = "localhost";
string default_queue_name = "random_numbers_queue";

var db_conn = new MyDbConnection(GetEnvVarOrDefault("HOSTDB", default_db_host_name),
                    GetEnvVarOrDefault("DB", "my_db"),   
                    GetEnvVarOrDefault("DBUSER", "my_user"),
                    GetEnvVarOrDefault("DBPASS", "my_password"),
                    GetEnvVarOrDefault("DBCOLLECTION", "my_collection"));

// Establish rabbit connection
var message_reader = new MessageReader(
            GetEnvVarOrDefault("HOSTMSG",default_msg_provider_host_name), 
                            (string s) => {
                                var cmd = new UpdateDbCommand(s, db_conn);
                                cmd.Run();
                            });

message_reader.Listen(GetEnvVarOrDefault("QUEUE", default_queue_name));

while(true)
{
    Thread.Sleep(1000);
}  


string GetEnvVarOrDefault(in string envvar, in string default_val)
{
    var s = Environment.GetEnvironmentVariable(envvar);

    if(s == null)
    {
        s = default_val;
    }
    return s;
}