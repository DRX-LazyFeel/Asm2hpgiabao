using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using DAL_Xuong;
using DTO_Xuong;

namespace BUS_Xuong
{
    public class BUSQuenMatKhau
    {
        public static bool GuiMa(string email, out string ma)
        {
            ma = null;
            if (!DALNhanVien.KiemTraEmail(email)) return false;

            ma = new Random().Next(100000, 999999).ToString();
            DALMaXacNhan.Luu(email, ma);

            // 🧨 Bỏ GuiEmail
            return true;

        }

        private static void GuiEmail(string toEmail, string ma)
        {
            var fromEmail = "your_email@gmail.com";
            var password = "your_app_password";

            var mail = new MailMessage(fromEmail, toEmail);
            mail.Subject = "Mã xác nhận đặt lại mật khẩu";
            mail.Body = $"Mã xác nhận của bạn là: {ma}";

            using (var smtp = new SmtpClient("smtp.gmail.com", 587))
            {
                smtp.Credentials = new NetworkCredential(fromEmail, password);
                smtp.EnableSsl = true;
                smtp.Send(mail);
            }
        }

        public static bool XacNhan(string email, string ma, string matKhauMoi)
        {
            var dto = DALMaXacNhan.Lay(email);
            if (dto == null) return false;

            bool hopLe = ma == dto.MaXacNhan && (DateTime.Now - dto.ThoiGianTao).TotalMinutes <= 10;
            if (hopLe)
            {
                DALNhanVien.DoiMatKhau(email, matKhauMoi);
                DALMaXacNhan.Xoa(email);
            }

            return hopLe;
        }
    }

}
