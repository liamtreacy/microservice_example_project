﻿var p = new Printer();
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

string db;
string user;
string pass;

GetEnvVarOrDefault("DBUSER", "", out db);
GetEnvVarOrDefault("DBPASS", "", out user);
GetEnvVarOrDefault("DB", "", out pass);

var db_conn = new DbConnection(db, user, pass);


// Establish rabbit connection
var message_reader = new MessageReader(msg_provider_host_name, 
                            (string s) => {
                                var cmd = new UpdateDbCommand(s);
                                cmd.Run();
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