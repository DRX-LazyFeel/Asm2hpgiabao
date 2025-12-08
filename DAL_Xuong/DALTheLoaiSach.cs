
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
    public class DALTheLoaiSach
    {
        public List<TheLoaiSach> LayDSTheLoaiSach()
        {
            List<object> args = new List<object>();
            string sql = "SELECT * FROM TheLoaiSach";

            return SelectBySql(sql, args);
        }

        public List<TheLoaiSach> SelectBySql(string sql, List<object> args, CommandType cmdType = CommandType.Text)
        {
            List<TheLoaiSach> ds = new List<TheLoaiSach>();
            SqlDataReader reader = DBUtil.Query(sql, new List<object>(), CommandType.Text);

            while (reader.Read())
            {
                TheLoaiSach entity = new TheLoaiSach();
                entity.MaTheLoai = reader.GetString("MaTheLoai");
                entity.TenTheLoai = reader.GetString("TenTheLoai");
                entity.TrangThai = reader.GetBoolean("TrangThai");
                entity.NgayTao = reader.GetDateTime("NgayTao");
                ds.Add(entity);
            }

            reader.Close();
            return ds;
        }

        public void ThemTheLoaiSach(TheLoaiSach s)
        {
            string sql = "INSERT INTO TheLoaiSach VALUES (@0, @1, @2, @3 )";
            List<object> args = new List<object>
            {
                s.MaTheLoai, s.TenTheLoai, s.TrangThai, s.NgayTao
            };
            DBUtil.Update(sql, args);
        }

        public List<TheLoaiSach> LayTheLoaiDangHoatDong()
        {
            string sql = "SELECT * FROM TheLoaiSach WHERE TrangThai = 1";
            return SelectBySql(sql, new List<object>());
        }

        public void CapNhatTheLoaiSach(TheLoaiSach s)
        {
            string sql = @"UPDATE TheLoaiSach SET TenTheLoai=@1, TrangThai=@2 WHERE MaTheLoai=@0";
            List<object> args = new List<object>
            {
                s.MaTheLoai, s.TenTheLoai, s.TrangThai
            };
            DBUtil.Update(sql, args);
        }

        public void XoaTheLoaiSach(string maTheLoaiSach)
        {
            string sql = "UPDATE TheLoaiSach SET TrangThai = 0 WHERE MaTheLoai=@0";
            DBUtil.Update(sql, new List<object> { maTheLoaiSach });
        }

        public string generateMaTheLoaiSach()
        {
            string prefix = "TL";
            string sql = "SELECT MAX(MaTheLoai) FROM TheLoaiSach";
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

    }
}
