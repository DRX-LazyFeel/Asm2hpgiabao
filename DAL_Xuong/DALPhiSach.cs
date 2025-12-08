
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
    public class DALPhiSach
    {
        public List<PhiSach> LayDSPhiSach()
        {
            string sql = "SELECT MaPhiSach, MaSach, PhiMuon, PhiPhat, TrangThai, NgayTao FROM PhiSach";
            return SelectBySql(sql, new List<object>(), CommandType.Text);
        }

        public bool KiemTraMaSachTonTai(string maSach)
        {
            string sql = "SELECT COUNT(*) FROM Sach WHERE MaSach = @0";
            var args = new List<object> { maSach };
            object result = DBUtil.ScalarQuery(sql, args);

            int count = 0;
            if (result != null && int.TryParse(result.ToString(), out var parsed))
                count = parsed;

            return count > 0;
        }

        public List<PhiSach> SelectBySql(string sql, List<object> args, CommandType cmdType = CommandType.Text)
        {
            var ds = new List<PhiSach>();

            // Dùng đúng args và cmdType truyền vào
            using var reader = DBUtil.Query(sql, args, cmdType);
            while (reader.Read())
            {
                // Lấy ordinal để truy cập cột an toàn
                int iMaPhiSach = reader.GetOrdinal("MaPhiSach");
                int iMaSach = reader.GetOrdinal("MaSach");
                int iPhiMuon = reader.GetOrdinal("PhiMuon");
                int iPhiPhat = reader.GetOrdinal("PhiPhat");
                int iTrangThai = reader.GetOrdinal("TrangThai");
                int iNgayTao = reader.GetOrdinal("NgayTao");

                var entity = new PhiSach
                {
                    MaPhiSach = reader.IsDBNull(iMaPhiSach) ? null : reader.GetString(iMaPhiSach),
                    MaSach = reader.IsDBNull(iMaSach) ? null : reader.GetString(iMaSach),
                    PhiMuon = reader.IsDBNull(iPhiMuon) ? 0m : reader.GetDecimal(iPhiMuon),
                    PhiPhat = reader.IsDBNull(iPhiPhat) ? 0m : reader.GetDecimal(iPhiPhat),
                    TrangThai = !reader.IsDBNull(iTrangThai) && reader.GetBoolean(iTrangThai),
                    NgayTao = reader.IsDBNull(iNgayTao) ? DateTime.MinValue : reader.GetDateTime(iNgayTao)
                };

                ds.Add(entity);
            }

            reader.Close();
            return ds;
        }

        public void ThemPhiSach(PhiSach s)
        {
            string sql = "INSERT INTO PhiSach (MaPhiSach, MaSach, PhiMuon, PhiPhat, TrangThai, NgayTao) VALUES (@0, @1, @2, @3, @4, @5)";
            var args = new List<object>
            {
                s.MaPhiSach,
                s.MaSach,
                s.PhiMuon,
                s.PhiPhat,
                s.TrangThai,
                s.NgayTao
            };
            DBUtil.Update(sql, args);
        }

        public void CapNhatPhiSach(PhiSach s)
        {
            string sql = @"UPDATE PhiSach
                           SET MaSach = @1, PhiMuon = @2, PhiPhat = @3, TrangThai = @4
                           WHERE MaPhiSach = @0";
            var args = new List<object>
            {
                s.MaPhiSach,
                s.MaSach,
                s.PhiMuon,
                s.PhiPhat,
                s.TrangThai
            };
            DBUtil.Update(sql, args);
        }

        public void XoaPhiSach(string maPhiSach)
        {
            if (string.IsNullOrWhiteSpace(maPhiSach))
                throw new Exception("Vui lòng chọn phí sách cần xóa");

            // Nếu chính sách là "ngừng áp dụng" thay vì xóa cứng:
            string sql = "UPDATE PhiSach SET TrangThai = 0 WHERE MaPhiSach = @0";
            DBUtil.Update(sql, new List<object> { maPhiSach });
        }

        public string generateMaPhiSach()
        {
            const string prefix = "PS";
            string sql = "SELECT MAX(MaPhiSach) FROM PhiSach";
            var args = new List<object>();
            object result = DBUtil.ScalarQuery(sql, args);

            // Xử lý null hoặc giá trị không hợp lệ
            string max = result?.ToString();
            if (!string.IsNullOrEmpty(max) && max.StartsWith(prefix, StringComparison.OrdinalIgnoreCase))
            {
                string numberPart = max.Substring(prefix.Length);
                if (int.TryParse(numberPart, out int current))
                {
                    int next = current + 1;
                    return $"{prefix}{next:D3}";
                }
            }

            return $"{prefix}001";
        }

        // Hàm này nên ở DAL Sách, không phải DAL Phi Sách. Nếu cần, hãy di chuyển sang DALSach.
        // Giữ lại nếu project hiện tại đang dùng, nhưng khuyến nghị tách đúng tầng.
        public string generateMaSach()
        {
            const string prefix = "S";
            string sql = "SELECT MAX(MaSach) FROM Sach";
            var args = new List<object>();
            object result = DBUtil.ScalarQuery(sql, args);

            string max = result?.ToString();
            if (!string.IsNullOrEmpty(max) && max.StartsWith(prefix, StringComparison.OrdinalIgnoreCase))
            {
                string numberPart = max.Substring(prefix.Length);
                if (int.TryParse(numberPart, out int current))
                {
                    int next = current + 1;
                    return $"{prefix}{next:D3}";
                }
            }

            return $"{prefix}001";
        }
    }

}
