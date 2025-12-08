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
    public class DALKhachHang
    {
        
        public List<KhachHang> SelectBySql(string sql, List<object> args, CommandType cmdType = CommandType.Text)
        {
            List<KhachHang> list = new List<KhachHang>();
            try
            {
                SqlDataReader reader = DBUtil.Query(sql, args);
                while (reader.Read())
                {
                    KhachHang entity = new KhachHang();
                    entity.MaKhachHang = reader.GetString("MaKhachHang");
                    entity.TenKhachHang = reader.GetString("TenKhachHang");
                    entity.Email = reader.GetString("Email");
                    entity.SoDienThoai = reader.GetString("SoDienThoai");
                    entity.CCCD = reader.GetString("CCCD");
                    entity.TrangThai = reader.GetBoolean("TrangThai");
                    entity.NgayTao = reader.GetDateTime("NgayTao");
                    list.Add(entity);
                  
                }
            }
            catch (Exception)
            {
                throw;
            }
            return list;
        }

        public List<KhachHang> selectAll()
        {
            string sql = "SELECT * FROM KhachHang";
            return SelectBySql(sql, new List<object>());
        }

        public List<KhachHang> SearchKhachHang(string keyword)
        {
            string sql = "SELECT * FROM KhachHang WHERE MaKhachHang LIKE " + $"N'%{keyword}%' COLLATE Latin1_General_CI_AI" + " OR TenKhachHang LIKE " + $"N'%{keyword}%' COLLATE Latin1_General_CI_AI";
            // + " OR Email LIKE "+ $"N'%{keyword}%' COLLATE Latin1_General_CI_AI";
            List<object> thamSo = new List<object>();
            return SelectBySql(sql, thamSo);
        }


        public KhachHang selectById(string id)
        {
            String sql = "SELECT * FROM KhachHang WHERE MaKhachHang=@0";
            List<object> thamSo = new List<object>();
            thamSo.Add(id);
            List<KhachHang> list = SelectBySql(sql, thamSo);
            return list.Count > 0 ? list[0] : null;
        }

        public void insertKhachHang(KhachHang nv)
        {
            try
            {
                string sql = @"INSERT INTO KhachHang (MaKhachHang, TenKhachHang, Email, SoDienThoai, CCCD, TrangThai) 
                   VALUES (@0, @1, @2, @3, @4, @5)";
                List<object> thamSo = new List<object>();
                thamSo.Add(nv.MaKhachHang);
                thamSo.Add(nv.TenKhachHang);
                thamSo.Add(nv.Email);
                thamSo.Add(nv.SoDienThoai);
                thamSo.Add(nv.CCCD);
                thamSo.Add(nv.TrangThai);
                DBUtil.Update(sql, thamSo);
            }
            catch (Exception e)
            {
                throw;
            }

        }

        public void updateKhachHang(KhachHang nv)
        {
            try
            {
                string sql = @"UPDATE KhachHang 
                   SET TenKhachHang = @1, Email = @2, SoDienThoai = @3, CCCD = @4, TrangThai = @5 
                   WHERE MaKhachHang = @0";
                List<object> thamSo = new List<object>();
                thamSo.Add(nv.MaKhachHang);
                thamSo.Add(nv.TenKhachHang);
                thamSo.Add(nv.Email);
                thamSo.Add(nv.SoDienThoai);
                thamSo.Add(nv.CCCD);
                thamSo.Add(nv.TrangThai);
                DBUtil.Update(sql, thamSo);
            }
            catch (Exception e)
            {
                throw;
            }

        }

        public void deleteKhachHang(string maKH)
        {
            try
            {
                string sql = "UPDATE KhachHang SET TrangThai = 0 WHERE MaKhachHang = @0";
                List<object> thamSo = new List<object>();
                thamSo.Add(maKH);
                DBUtil.Update(sql, thamSo);
            }
            catch (Exception e)
            {
                throw;
            }

        }

        public bool checkEmailExists(string email)
        {
            string sql = "SELECT COUNT(*) FROM KhachHang WHERE Email = @0";
            List<object> thamSo = new List<object>();
            thamSo.Add(email);
            object result = DBUtil.ScalarQuery(sql, thamSo);
            return Convert.ToInt32(result) > 0;
        }

        public string generateMaKhachHang()
        {
            string prefix = "KH";
            string sql = "SELECT MAX(MaKhachHang) FROM KhachHang";
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
