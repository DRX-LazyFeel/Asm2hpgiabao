using DAL_PolyCafe;
using DTO_Xuong;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using static DTO_Xuong.ThongKe;

namespace DAL_Xuong
{
    public class DALThongKe
    {
        public List<ThongKeDTO> ThongKeMuonTheoNhanVien()
        {
            List<ThongKeDTO> list = new List<ThongKeDTO>();

            string query = @"
                SELECT 
                    NV.MaNhanVien,
                    NV.Ten,
                    COUNT(DISTINCT MT.MaMuonTra) AS SoLuongPhieuMuon,
                    ISNULL(SUM(CT.SoLuong), 0) AS TongSachMuon
                FROM 
                    NhanVien NV
                LEFT JOIN 
                    MuonTraSach MT ON NV.MaNhanVien = MT.MaNhanVien
                LEFT JOIN 
                    ChiTietMuonSach CT ON MT.MaMuonTra = CT.MaMuonTra
                GROUP BY 
                    NV.MaNhanVien, NV.Ten
                ORDER BY 
                    SoLuongPhieuMuon DESC";

            using (SqlConnection con = new SqlConnection(DBUtil.connString))
            {
                SqlCommand cmd = new SqlCommand(query, con);
                con.Open();

                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    ThongKeDTO item = new ThongKeDTO
                    {
                        MaNhanVien = reader["MaNhanVien"].ToString(),
                        TenNhanVien = reader["Ten"].ToString(),
                        SoLuongPhieuMuon = Convert.ToInt32(reader["SoLuongPhieuMuon"]),
                        TongSachMuon = Convert.ToInt32(reader["TongSachMuon"])
                    };
                    list.Add(item);
                }
                reader.Close();
            }

            return list;
        }

        // ✅ Thống kê theo mã nhân viên
        public ThongKeDTO ThongKeTheoMaNhanVien(string maNV)
        {
            ThongKeDTO result = null;

            string query = @"
                SELECT 
                    NV.MaNhanVien,
                    NV.Ten,
                    COUNT(DISTINCT MT.MaMuonTra) AS SoLuongPhieuMuon,
                    ISNULL(SUM(CT.SoLuong), 0) AS TongSachMuon
                FROM 
                    NhanVien NV
                LEFT JOIN 
                    MuonTraSach MT ON NV.MaNhanVien = MT.MaNhanVien
                LEFT JOIN 
                    ChiTietMuonSach CT ON MT.MaMuonTra = CT.MaMuonTra
                WHERE 
                    NV.MaNhanVien = @MaNhanVien
                GROUP BY 
                    NV.MaNhanVien, NV.Ten";

            using (SqlConnection con = new SqlConnection(DBUtil.connString))
            {
                SqlCommand cmd = new SqlCommand(query, con);
                cmd.Parameters.AddWithValue("@MaNhanVien", maNV);
                con.Open();

                SqlDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    result = new ThongKeDTO
                    {
                        MaNhanVien = reader["MaNhanVien"].ToString(),
                        TenNhanVien = reader["Ten"].ToString(),
                        SoLuongPhieuMuon = Convert.ToInt32(reader["SoLuongPhieuMuon"]),
                        TongSachMuon = Convert.ToInt32(reader["TongSachMuon"])
                    };
                }
                reader.Close();
            }

            return result;
        }
        public List<ThongKeDTO> LayThongKeTheoNhanVien(DateTime tuNgay, DateTime denNgay)
        {
            List<ThongKeDTO> danhSach = new List<ThongKeDTO>();

            string query = @"
                SELECT 
                    nv.MaNhanVien,
                    nv.Ten AS TenNhanVien,
                    COUNT(DISTINCT mts.MaMuonTra) AS SoLuongPhieuMuon,
                    SUM(ct.SoLuong) AS TongSachMuon
                FROM MuonTraSach mts
                JOIN ChiTietMuonSach ct ON mts.MaMuonTra = ct.MaMuonTra
                JOIN NhanVien nv ON mts.MaNhanVien = nv.MaNhanVien
                WHERE mts.NgayMuon BETWEEN @TuNgay AND @DenNgay
                GROUP BY nv.MaNhanVien, nv.Ten
                ORDER BY TongSachMuon DESC;
            ";

            using (SqlConnection conn = DBUtil.GetConnection())
            {
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@TuNgay", tuNgay);
                    cmd.Parameters.AddWithValue("@DenNgay", denNgay);

                    conn.Open();
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            ThongKeDTO thongKe = new ThongKeDTO
                            {
                                MaNhanVien = reader["MaNhanVien"].ToString(),
                                TenNhanVien = reader["TenNhanVien"].ToString(),
                                SoLuongPhieuMuon = Convert.ToInt32(reader["SoLuongPhieuMuon"]),
                                TongSachMuon = Convert.ToInt32(reader["TongSachMuon"])
                            };
                            danhSach.Add(thongKe);
                        }
                    }
                }
            }

            return danhSach;
        }
    }
}

