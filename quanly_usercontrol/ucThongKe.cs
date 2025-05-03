using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace quanlysinhvien.quanly_usercontrol
{
    public partial class ucThongKe: UserControl
    {
        private ConnectDB db = new ConnectDB();
        public ucThongKe()
        {
            InitializeComponent();
            LoadThongKeSinhVien();
        }

        private void LoadThongKeSinhVien()
        {
            using (SqlConnection conn = db.Connect())
            {
                try
                {
                    string query = @"
                SELECT 
                    k.TenKhoa,
                    n.TenNganh,
                    l.TenLop,
                    COUNT(sv.MaSV) AS SoLuongSinhVien,
                    SUM(CASE WHEN bl.MaSV IS NOT NULL THEN 1 ELSE 0 END) AS SoLuongBaoLuu,
                    SUM(CASE WHEN sv.MaLop IS NULL THEN 1 ELSE 0 END) AS SoLuongThoiHoc,
                    SUM(CASE WHEN bl.MaSV IS NULL THEN 1 ELSE 0 END) AS SoLuongDangHoc
                FROM SinhVien sv
                INNER JOIN Lop l ON sv.MaLop = l.MaLop
                INNER JOIN Nganh n ON l.MaNganh = n.MaNganh
                INNER JOIN Khoa k ON n.MaNganh = k.MaKhoa  -- nếu bạn có mối liên kết Nganh - Khoa như thế này
                LEFT JOIN BaoLuu bl ON sv.MaSV = bl.MaSV
                GROUP BY k.TenKhoa, n.TenNganh, l.TenLop
                ORDER BY l.TenLop";

                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    using (SqlDataAdapter da = new SqlDataAdapter(cmd))
                    {
                        DataTable dt = new DataTable();
                        da.Fill(dt);
                        dgrtk.DataSource = dt;
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi thống kê: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void ucThongKe_Load(object sender, EventArgs e)
        {

        }
    }
}
