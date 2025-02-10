using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;

namespace DAL_QLBanHang
{
    public class DBConnect
    {
        static string strConnection = ConfigurationManager.ConnectionStrings["connectionString"].ConnectionString;
        protected SqlConnection _conn = new SqlConnection(strConnection);
    }
}
