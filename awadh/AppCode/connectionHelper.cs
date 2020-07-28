using System.Data;
using System.Data.SqlClient;
using System.Configuration;

namespace Mahadev
{
    public class connectionHelper
    {
        public static IDbConnection GetConnection()
        {
            var connection = new SqlConnection(ConfigurationManager.ConnectionStrings["DBConnection"].ConnectionString);
            connection.Open();
            return connection;
        }
    }
}