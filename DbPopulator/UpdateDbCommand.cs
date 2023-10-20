public class UpdateDbCommand
{
    public static string Db;
    public static string User;
    public static string Password;

    private string message;

    public UpdateDbCommand(string _message)
    {
        message = _message;
    }

    public void Run()
    {
        var p = new Printer();
        p.Print($"LAMBDA: {message}");
    }
}
