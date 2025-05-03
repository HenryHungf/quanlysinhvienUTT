using quanlysinhvien.quanly_usercontrol;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using quanlysinhvien.quanly_usercontrol;
namespace quanlysinhvien
{
    public partial class TrangChu : Form
    {
        public TrangChu()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void btnDangXuat_Click(object sender, EventArgs e)
        {
            DialogResult check = MessageBox.Show("Bạn có muốn đăng xuất không?", "Xác nhận đăng xuất", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question);

            if (check == DialogResult.Yes)
            {
                // Ẩn form hiện tại
                this.Hide();

                // Mở lại form đăng nhập (nếu có)
                LoginForm login = new LoginForm();
                login.Show();

                // Hoặc thoát chương trình hoàn toàn nếu không có màn hình đăng nhập
                // Application.Exit();
            }
        }

        private void TrangChu_Load(object sender, EventArgs e)
        {

        }

        private void panel3_Paint(object sender, PaintEventArgs e)
        {

        }

        private void btnSinhvien_Click(object sender, EventArgs e)
        {
            ShowControl(new ucQuanLySinhVien());
        }
        private void ShowControl(UserControl control)
        {
            panelQuanly.Controls.Clear();  // Xóa control cũ
            control.Dock = DockStyle.Fill;  // Điều chỉnh kích thước vừa khít panel
            panelQuanly.Controls.Add(control); // Thêm control mới vào panel
        }

        private void btnLop_Click(object sender, EventArgs e)
        {
            ShowControl(new ucQuanLyLop());
        }

        private void btnNganh_Click(object sender, EventArgs e)
        {
            ShowControl(new ucQuanLyNganh());
        }

        private void btnMonhoc_Click(object sender, EventArgs e)
        {
            ShowControl(new ucQuanLyMonHoc());
        }

        private void btnDKlop_Click(object sender, EventArgs e)
        {
            ShowControl(new ucQuanLyDangKylop());
        }

        private void btnBaoLUU_Click(object sender, EventArgs e)
        {
            ShowControl(new ucQuanLyBaoLuu());
        }

        private void btnThiLai_Click(object sender, EventArgs e)
        {
            ShowControl(new ucQuanLyThiLai());
        }

        private void btnHocLai_Click(object sender, EventArgs e)
        {
            ShowControl(new ucQuanLyHocLai());
        }

        private void btnKhenThuong_Click(object sender, EventArgs e)
        {
            ShowControl(new ucQuanLySinhVienKhenThuong());
        }

        private void btnDiem_Click(object sender, EventArgs e)
        {
            ShowControl(new ucQuanLyDiem());
        }

        private void btnKhoanamhoc_Click(object sender, EventArgs e)
        {
            ShowControl(new ucQuanLyKhoaNamHoc());
        }

        private void btnKhoa_Click(object sender, EventArgs e)
        {
            ShowControl(new ucQuanLyKhoa());
        }

        private void btnHocbong_Click(object sender, EventArgs e)
        {
            ShowControl(new ucQuanLyHocBong());
        }

        private void btnKyluat_Click(object sender, EventArgs e)
        {
            ShowControl(new ucQuanLyKyLuat());
        }

        private void btnthongke_Click(object sender, EventArgs e)
        {
            ShowControl(new ucThongKe());
        }

        //private void panel2_Paint(object sender, PaintEventArgs e)
        //{
        //    panel2.Dock = DockStyle.Left;
        //    panel2.Width = 200;
        //    panel2.AutoScroll = true;
        //    panel2.AutoScrollMinSize = new Size(0, 0);  // mặc định

        //}

        private void panel2_Paint_1(object sender, PaintEventArgs e)
        {
            this.panel2.AutoScroll = true;
            this.panel2.Dock = DockStyle.Left;  // để nó bám sát bên trái
            this.panel2.Width = 200; // hoặc kích thước bạn mong muốn
 
        }
    }
}
