using DAL_PolyCafe;
using DTO_Xuong;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL_Xuong
{
    public class DALTacGia
    {
        public List<TacGia> LayDSTacGia()
        {
            List<TacGia> ds = new List<TacGia>();
            string sql = "SELECT * FROM TacGia";
            SqlDataReader reader = DBUtil.Query(sql, new List<object>(), CommandType.Text);

            while (reader.Read())
            {
                TacGia entity = new TacGia();
                entity.MaTacGia = reader.GetString("MaTacGia");
                entity.TenTacGia = reader.GetString("TenTacGia");
                entity.QuocTich = reader.GetString("QuocTich");
                entity.TrangThai = reader.GetBoolean("TrangThai");
                entity.NgayTao = reader.GetDateTime("NgayTao");
                ds.Add(entity);
            }

            reader.Close();
            return ds;
        }




        public void ThemTacGia(TacGia s)
        {
            string sql = @"INSERT INTO TacGia 
        (MaTacGia, TenTacGia, QuocTich, TrangThai, NgayTao)
        VALUES (@0, @1, @2, @3, @4)";
            List<object> args = new List<object>
    {
        s.MaTacGia,
        s.TenTacGia,
        s.QuocTich,
        s.TrangThai,
        s.NgayTao
    };
            DBUtil.Update(sql, args);
        }

        public void CapNhatTacGia(TacGia s)
        {
            string sql = @"UPDATE TacGia SET TenTacGia=@1, QuocTich=@2, TrangThai=@3 WHERE MaTacGia=@0";
            List<object> args = new List<object>
            {
                s.MaTacGia, s.TenTacGia, s.QuocTich, s.TrangThai
            };
            DBUtil.Update(sql, args);
        }

        public void XoaTacGia(string maTacGia)
        {
            string sql = "UPDATE TacGia SET TrangThai = 0 WHERE MaTacGia=@0";
            DBUtil.Update(sql, new List<object> { maTacGia });
        }

        public string generateMaTacGia()
        {
            string prefix = "TG";
            string sql = "SELECT MAX(MaTacGia) FROM TacGia";
            List<object> thamSo = new List<object>();
            object result = DBUtil.ScalarQuery(sql, thamSo);
            if (result != null && result.ToString().StartsWith(prefix))
            {
                string maxCode = result.ToString().Substring(2);
                int newNumber = int.Parse(maxCode) + 1;
                return $"{prefix}{newNumber:D3}";
            }

            return $"{prefix}001";
        }

        public List<TacGia> LayTacGiaDangHoatDong()
        {
            List<TacGia> ds = new List<TacGia>();
            string sql = "SELECT * FROM TacGia WHERE TrangThai = 1";
            SqlDataReader reader = DBUtil.Query(sql, new List<object>(), CommandType.Text);

            while (reader.Read())
            {
                TacGia entity = new TacGia();
                entity.MaTacGia = reader.GetString("MaTacGia");
                entity.TenTacGia = reader.GetString("TenTacGia");
                entity.QuocTich = reader.GetString("QuocTich");
                entity.TrangThai = reader.GetBoolean("TrangThai");
                entity.NgayTao = reader.GetDateTime("NgayTao");
                ds.Add(entity);
            }

            reader.Close();
            return ds;
        }

    }
}