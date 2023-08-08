using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class DBHelper
    {
        
        public static SqlConnection GetConnection()
        {
            SqlConnection connection = new SqlConnection("Data Source=DESKTOP-VOR0UB8\\SQLEXPRESS;Initial Catalog=Salon;Integrated Security=True");
            return connection;
        }
        
    }
}
