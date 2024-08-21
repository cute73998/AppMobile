using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using OpenCvSharp;
using OpenCvSharp.Extensions;

namespace animation
{
    public partial class form1 : Form
    {
        private VideoCapture capture; //Đối tượng để kết nối với nguồn video (webcam).
        private Mat frame; // Lưu trữ khung hình video từ webcam dưới dạng ma trận hình ảnh.
        private Bitmap image; //Đối tượng hình ảnh có thể hiển thị trên form, được chuyển đổi từ Mat.
        public form1()
        {
            InitializeComponent();
            capture = new VideoCapture(0); // Kết nối với webcam, 0 là ID mặc định của webcam
            frame = new Mat();  // Khởi tạo một Mat để lưu trữ khung hình từ webcam
            Application.Idle += ProcessFrame; // Xử lý khung hình khi ứng dụng rảnh
            Console.WriteLine();
        }
        private void ProcessFrame(object sender, EventArgs e)
        {
            capture.Read(frame);  // Đọc một khung hình từ webcam
            if (!frame.Empty())  // Kiểm tra xem khung hình có trống không
            {
                image = BitmapConverter.ToBitmap(frame);  // Chuyển đổi Mat thành Bitmap
                pictureBox1.Image = image;  // Hiển thị hình ảnh trong PictureBox
            }
        }

        protected override void OnClosed(EventArgs e)
        {
            base.OnClosed(e);
            capture.Release();  // Giải phóng tài nguyên khi đóng ứng dụng
        }
    }

}
