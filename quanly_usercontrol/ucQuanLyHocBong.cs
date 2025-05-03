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
using System.Net;
using Excel = Microsoft.Office.Interop.Excel;

namespace quanlysinhvien.quanly_usercontrol
{
    public partial class ucQuanLyHocBong: UserControl
    {
        private ConnectDB db = new ConnectDB();
        public ucQuanLyHocBong()
        {
            InitializeComponent();
            LoadData();
            LoadCbbMaSv();
            LoadCbbtkMaSv();
        }

        private void LoadData()
        {
            dgrhocbong.Rows.Clear();

            string query = "SELECT * FROM HocBong";
            using (SqlConnection conn = db.Connect())
            {
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            dgrhocbong.Rows.Add(reader["MaSV"], reader["TenHocBong"], reader["GiaTri"]);
                        }
                    }
                }
            }
        }

        private void ResetText()
        {
            txttenhb.Clear();
            txtgiatri.Clear();
            cbbmasv.SelectedIndex = -1;
        }
        private void LoadCbbMaSv()
        {
            try
            {
                using (SqlConnection conn = db.Connect())
                {
                    string query = "SELECT MaSV FROM SinhVien";
                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        using (SqlDataAdapter da = new SqlDataAdapter(cmd))
                        {
                            DataTable dt = new DataTable();
                            da.Fill(dt);

                            // Gán dữ liệu vào ComboBox
                            cbbmasv.Text = "Chọn mã sinh viên";
                            cbbmasv.DataSource = dt;
                            cbbmasv.DisplayMember = "MaSV"; 
                            cbbmasv.ValueMember = "MaSV";
                            cbbmasv.SelectedIndex = -1; 
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi tải danh sách sinh viên: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void LoadCbbtkMaSv()
        {
            try
            {
                using (SqlConnection conn = db.Connect())
                {
                    string query = "SELECT MaSV FROM SinhVien";
                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        using (SqlDataAdapter da = new SqlDataAdapter(cmd))
                        {
                            DataTable dt = new DataTable();
                            da.Fill(dt);

                            // Gán dữ liệu vào ComboBox
                            cbbutkmasv.Text = "Chọn mã sinh viên";
                            cbbutkmasv.DataSource = dt;
                            cbbutkmasv.DisplayMember = "MaSV";
                            cbbutkmasv.ValueMember = "MaSV";
                            cbbutkmasv.SelectedIndex = -1; 
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi tải danh sách sinh viên: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnthem_Click(object sender, EventArgs e)
        {
            using (SqlConnection conn = db.Connect())
            {
                try
                {
                    // Kiểm tra dữ liệu trước khi lưu
                    if (string.IsNullOrWhiteSpace(txttenhb.Text) ||
                        string.IsNullOrWhiteSpace(txtgiatri.Text))
                    {
                        MessageBox.Show("Vui lòng nhập đầy đủ thông tin!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }

                    if (cbbmasv.SelectedItem == null || string.IsNullOrEmpty(cbbmasv.Text))
                    {
                        MessageBox.Show("Vui lòng chọn mã sinh viên!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }

                    if (!int.TryParse(txtgiatri.Text.Trim(), out int namBD) )
                    {
                        MessageBox.Show("Gía trị phải là số!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }

                    string query = "INSERT INTO HocBong (MaSV, TenHocBong, GiaTri) " +
                                   "VALUES (@MaSV, @TenHocBong, @GiaTri)";

                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@TenHocBong", txttenhb.Text.Trim());
                        cmd.Parameters.AddWithValue("@GiaTri", txtgiatri.Text.Trim());
                        cmd.Parameters.AddWithValue("@MaSV", cbbmasv.SelectedValue?.ToString() ?? "Không xác định");

                        int result = cmd.ExecuteNonQuery();

                        if (result > 0)
                        {
                            MessageBox.Show("Lưu dữ liệu thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            LoadData();
                            ResetText();
                        }
                        else
                        {
                            MessageBox.Show("Lưu dữ liệu thất bại!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void dgrhocbong_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dgrhocbong.Rows[e.RowIndex];

                cbbmasv.SelectedValue = row.Cells["MaSV"].Value.ToString();
                txttenhb.Text = row.Cells["TenHocBong"].Value.ToString();
                txtgiatri.Text = row.Cells["GiaTri"].Value.ToString();
                
            }
        }

        private void btnsua_Click(object sender, EventArgs e)
        {
            if (cbbmasv.SelectedItem == null || string.IsNullOrEmpty(cbbmasv.Text))
            {
                MessageBox.Show("Vui lòng chọn mã sinh viên cần sửa!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                using (SqlConnection conn = db.Connect())
                {
                    string query = "UPDATE HocBong SET TenHocBong=@TenHocBong, GiaTri=@GiaTri WHERE MaSV=@MaSV";

                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@TenHocBong", txttenhb.Text);
                        cmd.Parameters.AddWithValue("@GiaTri", txtgiatri.Text);
                        cmd.Parameters.AddWithValue("@MaSV", cbbmasv.SelectedValue.ToString());
                        cmd.ExecuteNonQuery();
                    }
                }

                MessageBox.Show("Cập nhật thông tin thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                LoadData();
                ResetText();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi cập nhật dữ liệu: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnxoa_Click(object sender, EventArgs e)
        {
            if (cbbmasv.SelectedItem == null || string.IsNullOrEmpty(cbbmasv.Text))
            {
                MessageBox.Show("Vui lòng chọn mã sinh viên cần sửa!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Xác nhận trước khi xóa
            DialogResult result = MessageBox.Show("Bạn có chắc chắn muốn xóa sinh viên này?", "Xác nhận xóa", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.No)
            {
                return;
            }

            try
            {
                using (SqlConnection conn = db.Connect())
                {
                    // Câu lệnh DELETE
                    string query = "DELETE FROM HocBong WHERE MaSV = @MaSV";
                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@MaSV", cbbmasv.SelectedValue.ToString());
                        int rowsAffected = cmd.ExecuteNonQuery();

                        if (rowsAffected > 0)
                        {
                            MessageBox.Show("Xóa sinh viên thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            LoadData();
                        }
                        else
                        {
                            MessageBox.Show("Không tìm thấy sinh viên để xóa!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi xóa sinh viên: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btntk_Click(object sender, EventArgs e)
        {
            dgrhocbong.Rows.Clear();
            if (cbbmasv.SelectedItem == null || string.IsNullOrEmpty(cbbmasv.Text))
            {
                MessageBox.Show("Vui lòng chọn mã sinh viên cần tìm kiếm!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            using (SqlConnection conn = db.Connect())
            {
                try
                {
                    string TenHocBong = txttktenhb.Text.Trim();
                    string MaSV = cbbutkmasv.SelectedValue?.ToString() ?? "Không xác định";

                    string query = "SELECT * FROM HocBong WHERE 1=1";

                    if (!string.IsNullOrEmpty(TenHocBong))
                        query += " AND TenHocBong LIKE @TenHocBong";

                    if (!string.IsNullOrEmpty(MaSV) && MaSV != "Chọn sinh viên")
                        query += " AND MaSV = @MaSV";

                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        if (!string.IsNullOrEmpty(TenHocBong))
                            cmd.Parameters.AddWithValue("@TenHocBong", "%" + TenHocBong + "%");

                        if (!string.IsNullOrEmpty(MaSV) && MaSV != "Chọn sinh viên")
                            cmd.Parameters.AddWithValue("@MaSV", MaSV);

                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                dgrhocbong.Rows.Add(reader["MaSV"], reader["TenHocBong"], reader["GiaTri"]);
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi: " + ex.Message, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void ExportExcel(string path)
        {

            try
            {
                Excel.Application application = new Excel.Application();
                application.Application.Workbooks.Add(Type.Missing);

                // Xuất tiêu đề cột
                for (int i = 0; i < dgrhocbong.ColumnCount; i++)
                {
                    application.Cells[1, i + 1] = dgrhocbong.Columns[i].HeaderText;
                }

                // Xuất dữ liệu hàng
                for (int i = 0; i < dgrhocbong.Rows.Count; i++)
                {
                    for (int j = 0; j < dgrhocbong.Columns.Count; j++)
                    {
                        application.Cells[i + 2, j + 1] = dgrhocbong.Rows[i].Cells[j].Value?.ToString();
                    }
                }

                // Căn chỉnh độ rộng cột
                application.Columns.AutoFit();

                // Lưu file
                application.ActiveWorkbook.SaveCopyAs(path);
                application.ActiveWorkbook.Saved = true;

                // Đóng Excel
                application.Quit();
                System.Runtime.InteropServices.Marshal.ReleaseComObject(application);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void Export_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Title = "Export Excel";
            saveFileDialog.Filter = "Excel Files|*.xlsx|All Files|*.*";
            saveFileDialog.FileName = "DanhSach.xlsx";

            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                ExportExcel(saveFileDialog.FileName);
                MessageBox.Show("Xuất Excel thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void ucQuanLyHocBong_Load(object sender, EventArgs e)
        {

        }
    }
}
