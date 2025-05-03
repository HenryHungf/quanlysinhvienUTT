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
    public partial class ucQuanLyLop: UserControl
    {
        private ConnectDB db = new ConnectDB();
        public ucQuanLyLop()
        {
            InitializeComponent();
            LoadData();
            LoadCbbMaNganh();
        }

        private void LoadData()
        {
            dgrlop.Rows.Clear();

            string query = "SELECT * FROM Lop";
            using (SqlConnection conn = db.Connect())
            {
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            dgrlop.Rows.Add(reader["MaLop"], reader["TenLop"], reader["MaNganh"]);
                        }
                    }
                }
            }
        }

        private void ResetText()
        {
            txtlop.Clear();
            txttenlop.Clear();
            cbbnganh.SelectedIndex = -1;
        }
        private void LoadCbbMaNganh()
        {
            try
            {
                using (SqlConnection conn = db.Connect())
                {
                    string query = "SELECT MaNganh, TenNganh FROM Nganh";
                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        using (SqlDataAdapter da = new SqlDataAdapter(cmd))
                        {
                            DataTable dt = new DataTable();
                            da.Fill(dt);

                            // Gán dữ liệu vào ComboBox
                            cbbnganh.DataSource = dt;
                            cbbnganh.DisplayMember = "TenNganh";
                            cbbnganh.ValueMember = "MaNganh";
                            cbbnganh.SelectedIndex = -1;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi tải danh sách ngành: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            using (SqlConnection conn = db.Connect())
            {
                try
                {
                    // Kiểm tra dữ liệu trước khi lưu
                    if (string.IsNullOrWhiteSpace(txtlop.Text) ||
                        string.IsNullOrWhiteSpace(txttenlop.Text))
                    {
                        MessageBox.Show("Vui lòng nhập đầy đủ thông tin!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }

                    if (cbbnganh.SelectedItem == null || string.IsNullOrEmpty(cbbnganh.Text))
                    {
                        MessageBox.Show("Vui lòng chọn ngành!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }

                    string checkQuery = "SELECT COUNT(*) FROM Lop WHERE MaLop = @MaLop";
                    using (SqlCommand checkCmd = new SqlCommand(checkQuery, conn))
                    {
                        checkCmd.Parameters.AddWithValue("@MaLop", txtlop.Text.Trim());
                        int count = Convert.ToInt32(checkCmd.ExecuteScalar());

                        if (count > 0)
                        {
                            MessageBox.Show("Mã lớp đã tồn tại! Vui lòng nhập mã khác.", "Lỗi trùng khóa",
                                            MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            return;
                        }
                    }

                    string query = "INSERT INTO Lop (MaLop, TenLop, MaNganh) " +
                                   "VALUES (@MaLop, @TenLop, @MaNganh)";

                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@MaLop", txtlop.Text.Trim());
                        cmd.Parameters.AddWithValue("@TenLop", txttenlop.Text.Trim());
                        cmd.Parameters.AddWithValue("@MaNganh", cbbnganh.SelectedValue?.ToString() ?? "Không xác định");

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

        private void dgrlop_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dgrlop.Rows[e.RowIndex];

                txtlop.Text = row.Cells["MaLop"].Value.ToString();
                txttenlop.Text = row.Cells["TenLop"].Value.ToString();
                cbbnganh.SelectedValue = row.Cells["MaNganh"].Value.ToString();

                // Vô hiệu hóa mã sinh viên và nút Thêm, Tìm kiếm
                txtlop.Enabled = false;
                txttkml.Enabled = false;
                txttktl.Enabled = false;
                btnThem.Enabled = false;
                btnTimKiem.Enabled = false;
            }
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            if (txtlop.Text == "")
            {
                MessageBox.Show("Vui lòng chọn lớp cần sửa!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                using (SqlConnection conn = db.Connect())
                {
                    string query = "UPDATE Lop SET TenLop=@TenLop, MaNganh=@MaNganh WHERE MaLop=@MaLop";

                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@MaLop", txtlop.Text);
                        cmd.Parameters.AddWithValue("@TenLop", txttenlop.Text);
                        cmd.Parameters.AddWithValue("@MaNganh", cbbnganh.SelectedValue.ToString());
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

        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtlop.Text))
            {
                MessageBox.Show("Vui lòng chọn lớp cần xóa!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Xác nhận trước khi xóa
            DialogResult result = MessageBox.Show("Bạn có chắc chắn muốn xóa lớp này?", "Xác nhận xóa", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.No)
            {
                return;
            }

            try
            {
                using (SqlConnection conn = db.Connect())
                {
                    // Câu lệnh DELETE
                    string query = "DELETE FROM Lop WHERE MaLop = @MaLop";
                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@MaLop", txtlop.Text);
                        int rowsAffected = cmd.ExecuteNonQuery();

                        if (rowsAffected > 0)
                        {
                            MessageBox.Show("Xóa lớp thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            LoadData();
                        }
                        else
                        {
                            MessageBox.Show("Không tìm thấy lớp để xóa!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi xóa lớp: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnTimKiem_Click(object sender, EventArgs e)
        {
            dgrlop.Rows.Clear();

            string MaLop = txtlop.Text.Trim();
            string TenLop = txttenlop.Text.Trim();

            if (string.IsNullOrEmpty(MaLop) && (string.IsNullOrEmpty(TenLop) ))
            {
                MessageBox.Show("Vui lòng nhập mã sinh viên hoặc chọn lớp để tìm kiếm!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            using (SqlConnection conn = db.Connect())
            {
                try
                {
                    string query = "SELECT * FROM Lop WHERE 1=1";

                    if (!string.IsNullOrEmpty(MaLop))
                        query += " AND MaLop LIKE @MaLop";

                    if (!string.IsNullOrEmpty(TenLop))
                        query += " AND TenLop LIKE @TenLop";

                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        if (!string.IsNullOrEmpty(MaLop))
                            cmd.Parameters.AddWithValue("@MaLop", "%" + MaLop + "%");

                        if (!string.IsNullOrEmpty(TenLop))
                            cmd.Parameters.AddWithValue("@TenLop", "%" + TenLop + "%");

                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                dgrlop.Rows.Add(reader["MaLop"], reader["TenLop"], reader["MaNganh"]);
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
                for (int i = 0; i < dgrlop.ColumnCount; i++)
                {
                    application.Cells[1, i + 1] = dgrlop.Columns[i].HeaderText;
                }

                // Xuất dữ liệu hàng
                for (int i = 0; i < dgrlop.Rows.Count; i++)
                {
                    for (int j = 0; j < dgrlop.Columns.Count; j++)
                    {
                        application.Cells[i + 2, j + 1] = dgrlop.Rows[i].Cells[j].Value?.ToString();
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

        private void ucQuanLyLop_Load(object sender, EventArgs e)
        {

        }
    }
}
