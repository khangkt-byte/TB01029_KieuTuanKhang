using DAL_QLBanHang;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace BUS_QLBanHang
{
    public class BUS_Log
    {
        DAL_Log dalLog = new DAL_Log();
        public DataTable GetLogSanPham()
        {
            return dalLog.GetLogSanPham();
        }
    }
}
