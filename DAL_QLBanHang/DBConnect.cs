﻿using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL_QLBanHang
{
    public class DBConnect
    {

        //protected SqlConnection _conn = new SqlConnection(@"Data Source=.;Initial Catalog=QLBanHang;Integrated Security=True;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");
        //static string strConnection = System.Configuration.ConfigurationManager.ConnectionStrings["abc"].ConnectionString;
        protected SqlConnection _conn = new SqlConnection(@"Data Source=khang\sqlexpress;database=SOF2051_QLBanHang1;Integrated Security=True");
        //protected SqlConnection _conn = new SqlConnection(strConnection);

    }
}
