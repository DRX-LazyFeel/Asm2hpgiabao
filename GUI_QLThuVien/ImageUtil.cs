using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GUI_QLThuVien
{
    public static class imageutil
    {
        public static void LoadHinhAnh(PictureBox pic, string relativePath)
        {
            if (pic == null) return;

            if (string.IsNullOrEmpty(relativePath))
            {
                pic.Image = null;
                return;
            }

            // Nếu là đường dẫn tuyệt đối thì dùng luôn, nếu là tương đối thì ghép với Application.StartupPath
            string fullPath = relativePath;
            if (!Path.IsPathRooted(fullPath))
            {
                fullPath = Path.Combine(Application.StartupPath, "images", relativePath.Replace("/", "\\"));
            }

            if (File.Exists(fullPath))
            {
                try
                {
                    // Giải phóng file sau khi load để tránh bị khóa file
                    using (var img = Image.FromFile(fullPath))
                    {
                        pic.Image = new Bitmap(img);
                    }
                }
                catch
                {
                    pic.Image = null;
                    MessageBox.Show("Không thể mở ảnh: " + fullPath);
                }
            }
            else
            {
                pic.Image = null;
                // Có thể bỏ dòng dưới nếu không muốn hiện thông báo khi không có ảnh
                // MessageBox.Show("Không tìm thấy ảnh: " + fullPath);
            }


        }

        public static string SaveImage(Image img, string folderName)
        {
            if (img == null) return null;

            string saveFolder = Path.Combine(Application.StartupPath, folderName);
            if (!Directory.Exists(saveFolder))
            {
                Directory.CreateDirectory(saveFolder);
            }

            string fileName = Guid.NewGuid().ToString() + ".jpg";
            string fullPath = Path.Combine(saveFolder, fileName);

            img.Save(fullPath, System.Drawing.Imaging.ImageFormat.Jpeg);

            // Trả về đường dẫn tương đối để lưu DB
            return Path.Combine(folderName, fileName);
        }
    }
}
    

