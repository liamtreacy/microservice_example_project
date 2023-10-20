public class UpdateDbCommand
{
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
