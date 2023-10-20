public class DbConnection
{
    private string db;
    private string user;
    private string pass;
    private string collection_name;
    private string host_name;
    public DbConnection(string _host_name, string _db, string _user, string _pass, string _collection_name)
    {
        db = _db;
        user = _user;
        pass = _pass;
        collection_name = _collection_name;
        host_name = _host_name;
    }
}
