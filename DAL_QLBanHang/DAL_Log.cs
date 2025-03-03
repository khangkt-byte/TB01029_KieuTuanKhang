using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL_QLBanHang
{
    public class DAL_Log : DBConnect
    {
        public DataTable GetLogSanPham()
        {
			try
			{
				_conn.Open();
				SqlCommand cmd = new SqlCommand();
				cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "LayLogSanPham";
                cmd.Connection = _conn;
				DataTable dtLog = new DataTable();
				dtLog.Load(cmd.ExecuteReader());
                return dtLog;
            }
			finally
			{
				_conn.Close();
            }
        }
    }
}
