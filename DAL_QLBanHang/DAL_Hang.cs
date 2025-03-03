using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO_QLBanHang;
namespace DAL_QLBanHang
{
    public class DAL_Hang : DBConnect
    {
        public DataTable getHang()
        {
            //Store Procedure
            try
            {
                _conn.Open();
                SqlCommand cmd = new SqlCommand();
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "DanhSachHang";
                cmd.Connection = _conn;
                DataTable dtHang = new DataTable();
                dtHang.Load(cmd.ExecuteReader());
                return dtHang;
            }
            finally
            {
                // Dong ket noi
                _conn.Close();
            }

        }
        public bool insertHang(DTO_Hang hang)
        {
            //using store procedure
            try
            {
                // Ket noi
                _conn.Open();

                SqlCommand cmd = new SqlCommand();
                cmd.Connection = _conn;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "InsertDataIntoTblHang";
                cmd.Parameters.AddWithValue("TenHang", hang.TenHang);
                cmd.Parameters.AddWithValue("SoLuong", hang.SoLuong);
                cmd.Parameters.AddWithValue("DonGiaNhap", hang.DonGiaNhap);
                cmd.Parameters.AddWithValue("DonGiaBan", hang.DonGiaBan);
                cmd.Parameters.AddWithValue("HinhAnh", hang.HinhAnh);
                cmd.Parameters.AddWithValue("GhiChu", hang.GhiChu);
                cmd.Parameters.AddWithValue("Email", hang.EmailNV);
                // Query và kiểm tra
                if (cmd.ExecuteNonQuery() > 0)
                    return true;
            }
            catch (Exception e)
            {

            }
            finally
            {
                // Dong ket noi
                _conn.Close();
            }
            return false;
        }

        public bool UpdateHang(DTO_Hang hang)
        {
            //using store procedure
            try
            {
                // Ket noi
                _conn.Open();
                // Command (mặc định command type = text nên chúng ta khỏi fải làm gì nhiều).
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = _conn;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "UpdateDataIntoTblHang";
                cmd.Parameters.AddWithValue("MaHang", hang.MaHang);
                cmd.Parameters.AddWithValue("TenHang", hang.TenHang);
                cmd.Parameters.AddWithValue("SoLuong", hang.SoLuong);
                cmd.Parameters.AddWithValue("DonGiaNhap", hang.DonGiaNhap);
                cmd.Parameters.AddWithValue("DonGiaBan", hang.DonGiaBan);
                cmd.Parameters.AddWithValue("HinhAnh", hang.HinhAnh);
                cmd.Parameters.AddWithValue("GhiChu", hang.GhiChu);
                cmd.Parameters.AddWithValue("email", hang.EmailNV);
                // Query và kiểm tra
                if (cmd.ExecuteNonQuery() > 0)
                    return true;
            }
            catch (Exception e)
            {

            }
            finally
            {
                // Dong ket noi
                _conn.Close();
            }
            return false;
        }

        public bool DeleteHang(int maHang, string email)
        {
            // using store procedure
            try
            {
                // Ket noi
                _conn.Open();
                SqlCommand cmd = new SqlCommand();
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "DeleteDataFromtblHang";
                cmd.Parameters.AddWithValue("MaHang", maHang);
                cmd.Parameters.AddWithValue("email", email);
                cmd.Connection = _conn;
                // Query và kiểm tra
                if (cmd.ExecuteNonQuery() > 0)
                    return true;
            }
            catch (Exception e)
            {

            }
            finally
            {
                // Dong ket noi
                _conn.Close();
            }
            return false;
        }

        public DataTable SearchHang(string tenHang)
        {
            //Store Procedure
            try
            {
                // Ket noi
                _conn.Open();
                SqlCommand cmd = new SqlCommand();
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "[SearchHang]";
                cmd.Parameters.AddWithValue("TenHang", tenHang);
                cmd.Connection = _conn;
                DataTable dtHang = new DataTable();
                dtHang.Load(cmd.ExecuteReader());
                return dtHang;
            }
            finally
            {
                // Dong ket noi
                _conn.Close();
            }
        }

        public DataTable ThongKeHang()
        {
            try
            {
                _conn.Open();
                SqlCommand cmd = new SqlCommand();
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "ThongKeSP";
                cmd.Connection = _conn;
                DataTable dtHang = new DataTable();
                dtHang.Load(cmd.ExecuteReader());
                return dtHang;
            }
            finally
            {
                // Dong ket noi
                _conn.Close();
            }
        }

        public DataTable ThongKeTonKho()
        {
            try
            {
                _conn.Open();
                SqlCommand cmd = new SqlCommand();
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "ThongKeTonKho";
                cmd.Connection = _conn;
                DataTable dtHang = new DataTable();
                dtHang.Load(cmd.ExecuteReader());
                return dtHang;
            }
            finally
            {
                // Dong ket noi
                _conn.Close();
            }
        }
    }
}