using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL_PolyCafe;
using DTO_Xuong;
using Microsoft.Data.SqlClient;

namespace DAL_Xuong
{
    public class DALTrangThaiThanhToan
    {

        public List<TrangThaiThanhToan> GetAllTrangThai()
        {
            string sql = "SELECT * FROM TrangThaiThanhToan";
            List<TrangThaiThanhToan> ds = new List<TrangThaiThanhToan>();
            SqlDataReader r = DBUtil.Query(sql, new List<object>(), CommandType.Text);

            while (r.Read())
            {
                var tt = new TrangThaiThanhToan
                {
                    MaTrangThai = r["MaTrangThai"].ToString(),
                    TenTrangThai = r["TenTrangThai"].ToString(),
                    NgayTao = Convert.ToDateTime(r["NgayTao"]),
                    TrangThai = Convert.ToBoolean(r["TrangThai"]) // 👉 thêm dòng này
                };
                ds.Add(tt);
            }

            r.Close();
            return ds;
        }

        public bool Insert(TrangThaiThanhToan t)
        {
            string sql = "INSERT INTO TrangThaiThanhToan (MaTrangThai, TenTrangThai, NgayTao, TrangThai) VALUES (@0, @1, @2, @3)";
            List<object> args = new List<object> { t.MaTrangThai, t.TenTrangThai, t.NgayTao, t.TrangThai }; // 👉 thêm t.TrangThai

            try
            {
                DBUtil.Update(sql, args, CommandType.Text);
                return true;
            }
            catch
            {
                return false;
            }
        }

        public bool Update(TrangThaiThanhToan t)
        {
            string sql = "UPDATE TrangThaiThanhToan SET TenTrangThai = @0, TrangThai = @1 WHERE MaTrangThai = @2";
            List<object> args = new List<object> { t.TenTrangThai, t.TrangThai, t.MaTrangThai }; // 👉 cập nhật thêm t.TrangThai

            try
            {
                DBUtil.Update(sql, args, CommandType.Text);
                return true;
            }
            catch
            {
                return false;
            }
        }

        public bool Delete(string ma)
        {
            string sql = "UPDATE TrangThaiThanhToan SET TrangThai = 0 WHERE MaTrangThai = @0"; 
            List<object> args = new List<object> { ma };

            try
            {
                DBUtil.Update(sql, args, CommandType.Text);
                return true;
            }
            catch
            {
                return false;
            }
        }

        public string GenerateNextMaSach()
        {
            string sql = "SELECT TOP 1 MaTrangThai FROM TrangThaiThanhToan ORDER BY MaTrangThai DESC";
            SqlDataReader reader = DBUtil.Query(sql, new List<object>(), CommandType.Text);

            string lastMa = "TT000";

            if (reader.Read())
                lastMa = reader["MaTrangThai"].ToString();

            reader.Close();

            int so = int.Parse(lastMa.Substring(2)) + 1; // Cắt bỏ "TT" -> giữ lại số
            return "TT" + so.ToString("D3"); // Tạo mã mới dạng TT001, TT002,...
        }
      
    }

    }
