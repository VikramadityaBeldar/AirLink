using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace ISP_Project
{
    class DBConnection
    {
        public static SqlConnection GetConnection()
        {
            SqlConnection conn = new SqlConnection("Data Source = DESKTOP-JMIGVPE\\SQLEXPRESS; Initial Catalog = ISP_DB; User ID = sa; Password = vikram@211;");
            return conn;
        }
    }
}
