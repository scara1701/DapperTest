using System.Configuration;

namespace DapperTest.SQLDataAccessDemo
{
    public static class Helper
    {
        public static string ConVal(string name)
        {
            return ConfigurationManager.ConnectionStrings[name].ConnectionString;
        }
    }
}
