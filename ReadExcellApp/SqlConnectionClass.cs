namespace ReadExcellApp
{
    public static class SqlConnectionClass
    {
        private static string _connectionString = "Server=.;Database=DacpolDB;User ID=admin;Integrated Security=true;";
        public static string ConnectionString()
        {
            return _connectionString;
        }
    }
}
