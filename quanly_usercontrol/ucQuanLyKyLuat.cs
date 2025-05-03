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
    public partial class ucQuanLyKyLuat: UserControl
    {
        private ConnectDB db = new ConnectDB();
        public ucQuanLyKyLuat()
        {
            InitializeComponent();
            LoadData();
            LoadCbbMaSv();
            LoadCbbtkMaSv();
        }

        private void LoadData()
        {
            dgrkl.Rows.Clear();

            string query = "SELECT * FROM KyLuat";
            using (SqlConnection conn = db.Connect())
            {
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            dgrkl.Rows.Add(reader["MaSV"], reader["LyDo"], reader["HinhThuc"], reader["NgayKyLuat"]);
                        }
                    }
                }
            }
        }

        private void ResetText()
        {
            txttenld.Clear();
            txtht.Clear();
            cbbmasv.SelectedIndex = -1;
            dtngay.Value = DateTime.Now;
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
                    if (string.IsNullOrWhiteSpace(txttenld.Text) ||
                        string.IsNullOrWhiteSpace(txtht.Text))
                    {
                        MessageBox.Show("Vui lòng nhập đầy đủ thông tin!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }

                    if (cbbmasv.SelectedItem == null || string.IsNullOrEmpty(cbbmasv.Text))
                    {
                        MessageBox.Show("Vui lòng chọn mã sinh viên!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }

                    if (dtngay.Value == null || dtngay.Value > DateTime.Now)
                    {
                        MessageBox.Show("Vui lòng chọn ngày kỷ luật hợp lệ!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }

                    string query = "INSERT INTO KyLuat (MaSV, LyDo, HinhThuc, NgayKyLuat) " +
                                   "VALUES (@MaSV, @LyDo, @HinhThuc, @NgayKyLuat)";

                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@LyDo", txttenld.Text.Trim());
                        cmd.Parameters.AddWithValue("@HinhThuc", txtht.Text.Trim());
                        cmd.Parameters.AddWithValue("@MaSV", cbbmasv.SelectedValue?.ToString() ?? "Không xác định");
                        cmd.Parameters.AddWithValue("@NgayKyLuat", dtngay.Value.Date);

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

        private void dgrkl_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dgrkl.Rows[e.RowIndex];

                cbbmasv.SelectedValue = row.Cells["MaSV"].Value.ToString();
                txttenld.Text = row.Cells["LyDo"].Value.ToString();
                txtht.Text = row.Cells["HinhThuc"].Value.ToString();
                dtngay.Value = Convert.ToDateTime(row.Cells["NgayKyLuat"].Value);
            }
        }

        private void btnsua_Click(object sender, EventArgs e)
        {
            if (cbbmasv.SelectedItem == null || string.IsNullOrEmpty(cbbmasv.Text))
            {
                MessageBox.Show("Vui lòng chọn mã sinh viên!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                using (SqlConnection conn = db.Connect())
                {
                    string query = "UPDATE KyLuat SET LyDo=@LyDo, HinhThuc=@HinhThuc, NgayKyLuat=@NgayKyLuat WHERE MaSV=@MaSV";

                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@LyDo", txttenld.Text.Trim());
                        cmd.Parameters.AddWithValue("@HinhThuc", txtht.Text.Trim());
                        cmd.Parameters.AddWithValue("@MaSV", cbbmasv.SelectedValue?.ToString() ?? "Không xác định");
                        cmd.Parameters.AddWithValue("@NgayKyLuat", dtngay.Value.Date);
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
                    string query = "DELETE FROM KyLuat WHERE MaSV = @MaSV";
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
            dgrkl.Rows.Clear();

            if (cbbmasv.SelectedItem == null || string.IsNullOrEmpty(cbbmasv.Text))
            {
                MessageBox.Show("Vui lòng chọn mã sinh viên cần tìm kiếm!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            using (SqlConnection conn = db.Connect())
            {
                try
                {
                    string LyDo = txttenld.Text.Trim();
                    string MaSV = cbbutkmasv.SelectedValue?.ToString() ?? "Không xác định";

                    string query = "SELECT * FROM KyLuat WHERE 1=1";

                    if (!string.IsNullOrEmpty(LyDo))
                        query += " AND LyDo LIKE @LyDo";

                    if (!string.IsNullOrEmpty(MaSV) && MaSV != "Chọn sinh viên")
                        query += " AND MaSV = @MaSV";

                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        if (!string.IsNullOrEmpty(LyDo))
                            cmd.Parameters.AddWithValue("@LyDo", "%" + LyDo + "%");

                        if (!string.IsNullOrEmpty(MaSV) && MaSV != "Chọn sinh viên")
                            cmd.Parameters.AddWithValue("@MaSV", MaSV);

                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                dgrkl.Rows.Add(reader["MaSV"], reader["LyDo"], reader["HinhThuc"], reader["NgayKyLuat"]);
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
                for (int i = 0; i < dgrkl.ColumnCount; i++)
                {
                    application.Cells[1, i + 1] = dgrkl.Columns[i].HeaderText;
                }

                // Xuất dữ liệu hàng
                for (int i = 0; i < dgrkl.Rows.Count; i++)
                {
                    for (int j = 0; j < dgrkl.Columns.Count; j++)
                    {
                        application.Cells[i + 2, j + 1] = dgrkl.Rows[i].Cells[j].Value?.ToString();
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

        private void ucQuanLyKyLuat_Load(object sender, EventArgs e)
        {

        }
    }
}
