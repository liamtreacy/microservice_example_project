public class UpdateDbCommand
{
    private string message;
    private IMyDbConn db_conn;

    public UpdateDbCommand(string _message, IMyDbConn _db_conn)
    {
        message = _message;
        db_conn = _db_conn;
    }

    public void Run()
    {
        var p = new Printer();
        //p.Print($"LAMBDA: {message}");
        db_conn.InsertNumber(int.Parse(message));
    }
}
