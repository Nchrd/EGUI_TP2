namespace lab2.Config
{
    public class StoreConnection
    {
        public static string GetConnection()
        {
            return System.Configuration.ConfigurationManager.ConnectionStrings["cs"].ConnectionString;
        }
    }
}
