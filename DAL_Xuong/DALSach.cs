
using DAL_PolyCafe;
using DTO_Xuong;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace DAL_Xuong
{
    public class DALSach
    {
        public List<Sach> GetSachDangHoatDong()
        {
            string sql = "SELECT * FROM Sach WHERE TrangThai = 1";
            return SelectBySql(sql, new List<object>()); // nếu bạn có hàm SelectBySql
        }

        public List<Sach> SelectBySql(string sql, List<object> args, CommandType cmdType = CommandType.Text)
        {
            List<Sach> list = new List<Sach>();
            try
            {
                SqlDataReader reader = DBUtil.Query(sql, args);
                while (reader.Read())
                {
                    Sach entity = new Sach();
                    entity.MaSach = reader.GetString("MaSach");
                    entity.TieuDe = reader.GetString("TieuDe");
                    entity.MaTheLoai = reader.GetString("MaTheLoai");
                    entity.MaTacGia = reader.GetString("MaTacGia");
                    entity.NhaXuatBan = reader.GetString("NhaXuatBan");
                    entity.SoLuongTon = reader.GetInt32("SoLuongTon");
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

        public string LayDuongDanHinhAnhTheoMaSach(string maSach)
        {
            string sql = "SELECT HinhAnh FROM Sach WHERE MaSach = @0";
            List<object> args = new List<object> { maSach };
            object result = DBUtil.ScalarQuery(sql, args);
            return result != DBNull.Value ? result?.ToString() : null;
        }
        public List<Sach> LayDSSach()
        {
            List<object> args = new List<object>();
            string sql = "SELECT * FROM Sach";
           
            return SelectBySql(sql, args);
        }

        public void ThemSach(Sach s)
        {
            string sql = "INSERT INTO Sach (MaSach, TieuDe, MaTheLoai, MaTacGia, NhaXuatBan, SoLuongTon, TrangThai, NgayTao, HinhAnh) VALUES (@0, @1, @2, @3, @4, @5, @6, @7, @8)";
            List<object> args = new List<object>
    {
        s.MaSach, s.TieuDe, s.MaTheLoai, s.MaTacGia,
        s.NhaXuatBan, s.SoLuongTon, s.TrangThai, s.NgayTao, s.HinhAnh
    };
            DBUtil.Update(sql, args);
        }

        public void CapNhatSach(Sach s)
        {
            string sql = @"UPDATE Sach 
                   SET TieuDe=@1, MaTheLoai=@2, MaTacGia=@3,
                       NhaXuatBan=@4, SoLuongTon=@5, TrangThai=@6, HinhAnh=@7 
                   WHERE MaSach=@0";

            List<object> args = new List<object>
    {
        s.MaSach, s.TieuDe, s.MaTheLoai, s.MaTacGia,
        s.NhaXuatBan, s.SoLuongTon, s.TrangThai, s.HinhAnh
    };

            DBUtil.Update(sql, args);
        }

        public void XoaSach(string maSach)
        {

            // Cập nhật trạng thái của sách thành 0 (Ngừng phát hành) thay vì xóa hoàn toàn
            string sql = "UPDATE Sach SET TrangThai = 0 WHERE MaSach=@0";
            DBUtil.Update(sql, new List<object> { maSach });
        }       
            
        public List<Sach> SearchSach(string keyword)
        {
            string sql = "SELECT * FROM Sach WHERE MaSach LIKE " + $"N'%{keyword}%' COLLATE Latin1_General_CI_AI" + " OR TenSach LIKE " + $"N'%{keyword}%' COLLATE Latin1_General_CI_AI";
            // + " OR Email LIKE "+ $"N'%{keyword}%' COLLATE Latin1_General_CI_AI";
            List<object> thamSo = new List<object>();
            return SelectBySql(sql, thamSo);
        }

        public string generateMaSach()
        {
            string prefix = "S";
            string sql = "SELECT MAX(MaSach) FROM Sach";
            List<object> thamSo = new List<object>();
            object result = DBUtil.ScalarQuery(sql, thamSo);
            if (result != null && result.ToString().StartsWith(prefix))
            {
                string maxCode = result.ToString().Substring(1);
                int newNumber = int.Parse(maxCode) + 1;
                return $"{prefix}{newNumber:D3}";
            }

            return $"{prefix}001";
        }
    }
}
