using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL_PolyCafe;
using DTO_Xuong;
using Microsoft.Data.SqlClient;

namespace DAL_Xuong
{
    public class DALMaXacNhan
    {
        public static void Luu(string email, string ma)
        {
            using (var conn = DBUtil.GetConnection())
            {
                conn.Open();
                string query = @"
                    IF EXISTS (SELECT 1 FROM MaXacNhan WHERE Email = @Email)
                        UPDATE MaXacNhan SET MaXacNhan = @Ma, ThoiGianTao = GETDATE() WHERE Email = @Email
                    ELSE
                        INSERT INTO MaXacNhan (Email, MaXacNhan) VALUES (@Email, @Ma)";
                using (var cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@Email", email);
                    cmd.Parameters.AddWithValue("@Ma", ma);
                    cmd.ExecuteNonQuery();
                }
            }
        }

        public static DTOMaXacNhan Lay(string email)
        {
            using (var conn = DBUtil.GetConnection())
            {
                conn.Open();
                string query = "SELECT MaXacNhan, ThoiGianTao FROM MaXacNhan WHERE Email = @Email";
                using (var cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@Email", email);
                    using (var reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            return new DTOMaXacNhan
                            {
                                Email = email,
                                MaXacNhan = reader.GetString(0),
                                ThoiGianTao = reader.GetDateTime(1)
                            };
                        }
                    }
                }
            }
            return null;
        }

        public static void Xoa(string email)
        {
            using (var conn = DBUtil.GetConnection())
            {
                conn.Open();
                string query = "DELETE FROM MaXacNhan WHERE Email = @Email";
                using (var cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@Email", email);
                    cmd.ExecuteNonQuery();
                }
            }
        }
    }

}
