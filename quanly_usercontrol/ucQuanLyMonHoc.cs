using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using OfficeOpenXml;
using Excel = Microsoft.Office.Interop.Excel;

namespace quanlysinhvien.quanly_usercontrol
{
    public partial class ucQuanLyMonHoc : UserControl
    {
        string connectionString = "Data Source=hungf;Initial Catalog=CS_QuanLySinhVien12;Integrated Security=True";

        public ucQuanLyMonHoc()
        {
            InitializeComponent();
        }

        private void ucQuanLyMonHoc_Load(object sender, EventArgs e)
        {
            LoadData();
            LoadComboBoxNganh();
            comboBoxNganh.Text = "-- Chọn Ngành --"; // Hiển thị trạng thái mặc định
        }
        private void LoadData()
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                try
                {
                    conn.Open();
                    string query = "SELECT MaMon, TenMon, SoTinChi, MaNganh FROM MonHoc";
                    SqlDataAdapter adapter = new SqlDataAdapter(query, conn);
                    DataTable dt = new DataTable();
                    adapter.Fill(dt);
                    dataGridViewMOnhoc.DataSource = dt;

                    dataGridViewMOnhoc.Columns["MaMon"].HeaderText = "Mã Môn";
                    dataGridViewMOnhoc.Columns["TenMon"].HeaderText = "Tên Môn";
                    dataGridViewMOnhoc.Columns["SoTinChi"].HeaderText = "Số tín chỉ";
                    dataGridViewMOnhoc.Columns["MaNganh"].HeaderText = "Mã Ngành";
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi khi tải dữ liệu: " + ex.Message);
                }
            }
        }
       // Where MaNganh = 'CNTT'
        // Where MaLop ='CNTT'
        // "WHERE MaLop = 'CNTT' AND GioiTinh = 'Nam'";
        private void LoadComboBoxNganh()
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                try
                {
                    conn.Open();
                    string query = "SELECT MaNganh, TenNganh FROM Nganh";
                    SqlDataAdapter adapter = new SqlDataAdapter(query, conn);
                    DataTable dt = new DataTable();
                    adapter.Fill(dt);

                    // Gán dữ liệu cho ComboBox
                    comboBoxNganh.DataSource = dt;
                    // sửa display là sửa được hiển thị mã hay tên của combobox
                    comboBoxNganh.DisplayMember = "TenNganh";  // Hiển thị tên ngành
                    comboBoxNganh.ValueMember = "MaNganh";     // Giá trị thực sự là mã ngành
                    comboBoxNganh.SelectedIndex = -1;         // Không chọn mặc định
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi khi tải ngành: " + ex.Message);
                }
            }
        }
        private void comboBoxNganh_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void btnThem_monHoc_Click(object sender, EventArgs e)
        {
            // Kiểm tra dữ liệu đầu vào
            if (string.IsNullOrWhiteSpace(txtMaMOnHoc.Text) ||
                string.IsNullOrWhiteSpace(txtten_MOnHoc.Text) ||
                string.IsNullOrWhiteSpace(txtSotinChi.Text) ||
                comboBoxNganh.SelectedIndex == -1)
            {
                MessageBox.Show("Vui lòng nhập đầy đủ thông tin!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Lấy dữ liệu từ các control
            string maMon = txtMaMOnHoc.Text.Trim();
            string tenMon = txtten_MOnHoc.Text.Trim();
            int soTinChi;

            if (!int.TryParse(txtSotinChi.Text.Trim(), out soTinChi))
            {
                MessageBox.Show("Số tín chỉ phải là số nguyên!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            string maNganh = comboBoxNganh.SelectedValue.ToString();

            // Kết nối SQL và thêm dữ liệu
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                try
                {
                    conn.Open();
                    // Kiểm tra xem MaLop đã tồn tại chưa
                    string checkQuery = "SELECT COUNT(*) FROM MonHoc WHERE MaMon = @MaMon";
                    using (SqlCommand checkCmd = new SqlCommand(checkQuery, conn))
                    {
                        checkCmd.Parameters.AddWithValue("@MaMon", maMon);
                        int count = (int)checkCmd.ExecuteScalar();

                        if (count > 0) // Nếu đã tồn tại
                        {
                            MessageBox.Show("Mã Môn Học đã tồn tại. Vui lòng nhập mã khác!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            return; // Dừng lại
                        }
                    }
                    string query = "INSERT INTO MonHoc (MaMon, TenMon, SoTinChi, MaNganh) VALUES (@MaMon, @TenMon, @SoTinChi, @MaNganh)";
                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@MaMon", maMon);
                        cmd.Parameters.AddWithValue("@TenMon", tenMon);
                        cmd.Parameters.AddWithValue("@SoTinChi", soTinChi);
                        cmd.Parameters.AddWithValue("@MaNganh", maNganh);

                        int result = cmd.ExecuteNonQuery();
                        if (result > 0)
                        {
                            MessageBox.Show("Thêm môn học thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            LoadData(); // Cập nhật lại DataGridView sau khi thêm
                        }
                        else
                        {
                            MessageBox.Show("Thêm môn học thất bại!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi khi thêm môn học: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void dataGridViewMOnhoc_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0) // Đảm bảo không click vào tiêu đề
            {
                DataGridViewRow row = dataGridViewMOnhoc.Rows[e.RowIndex];

                // Gán dữ liệu lên các TextBox và ComboBox
                txtMaMOnHoc.Text = row.Cells["MaMon"].Value.ToString();
                txtten_MOnHoc.Text = row.Cells["TenMon"].Value.ToString();
                txtSotinChi.Text = row.Cells["SoTinChi"].Value.ToString();
                comboBoxNganh.SelectedValue = row.Cells["MaNganh"].Value.ToString();

                // Khóa ô nhập mã môn học khi sửa
                txtMaMOnHoc.Enabled = false;
                btnThem_monHoc.Enabled = false;
                btnTimKiem_monHoc.Enabled = false;
                txtSearch_MamonHoc.Enabled = false;
                txtSearch_ten_monHoc.Enabled = false;
                txt_sotinchi_Search.Enabled = false;

            }
        }

        private void btnSua_monHoc_Click(object sender, EventArgs e)
        {
            // Kiểm tra dữ liệu đầu vào
            if (string.IsNullOrWhiteSpace(txtMaMOnHoc.Text) ||
                string.IsNullOrWhiteSpace(txtten_MOnHoc.Text) ||
                string.IsNullOrWhiteSpace(txtSotinChi.Text) ||
                comboBoxNganh.SelectedIndex == -1)
            {
                MessageBox.Show("Vui lòng nhập đầy đủ thông tin!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string maMon = txtMaMOnHoc.Text.Trim();
            string tenMon = txtten_MOnHoc.Text.Trim();
            int soTinChi;

            if (!int.TryParse(txtSotinChi.Text.Trim(), out soTinChi))
            {
                MessageBox.Show("Số tín chỉ phải là số nguyên!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            string maNganh = comboBoxNganh.SelectedValue.ToString();

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                try
                {
                    conn.Open();
                    string query = "UPDATE MonHoc SET TenMon = @TenMon, SoTinChi = @SoTinChi, MaNganh = @MaNganh WHERE MaMon = @MaMon";
                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@TenMon", tenMon);
                        cmd.Parameters.AddWithValue("@SoTinChi", soTinChi);
                        cmd.Parameters.AddWithValue("@MaNganh", maNganh);
                        cmd.Parameters.AddWithValue("@MaMon", maMon);

                        int result = cmd.ExecuteNonQuery();
                        if (result > 0)
                        {
                            MessageBox.Show("Cập nhật môn học thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            LoadData(); // Cập nhật lại DataGridView sau khi sửa
                        }
                        else
                        {
                            MessageBox.Show("Cập nhật môn học thất bại!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi khi sửa môn học: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }

        }
        private void btnLamMoi_Click(object sender, EventArgs e)
        {
            txtMaMOnHoc.Text = "";
            txtten_MOnHoc.Text = "";
            txtSotinChi.Text = "";
            comboBoxNganh.SelectedIndex = -1;
            txtMaMOnHoc.Enabled = true; // Mở khóa nhập mã môn học khi thêm mới
        }

        private void btnXoa_monHoc_Click(object sender, EventArgs e)
        {
            if (dataGridViewMOnhoc.SelectedRows.Count == 0)
            {
                MessageBox.Show("Vui lòng chọn môn học cần xóa!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string maMon = dataGridViewMOnhoc.SelectedRows[0].Cells["MaMon"].Value.ToString();

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();

                // Kiểm tra xem có dữ liệu liên quan trong HocLai không
                string checkQuery = "SELECT COUNT(*) FROM HocLai WHERE MaMon = @MaMon";
                using (SqlCommand checkCmd = new SqlCommand(checkQuery, conn))
                {
                    checkCmd.Parameters.AddWithValue("@MaMon", maMon);
                    int count = (int)checkCmd.ExecuteScalar();

                    if (count > 0)
                    {
                        MessageBox.Show("Không thể xóa! Môn học vì có Học Sinh HọC Lại đang được sử dụng trong bảng Học Lại.",
                                        "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                }

                // Nếu không có dữ liệu liên quan, tiến hành xóa
                string deleteQuery = "DELETE FROM MonHoc WHERE MaMon = @MaMon";
                using (SqlCommand cmd = new SqlCommand(deleteQuery, conn))
                {
                    cmd.Parameters.AddWithValue("@MaMon", maMon);
                    int rowsAffected = cmd.ExecuteNonQuery();
                    if (rowsAffected > 0)
                    {
                        MessageBox.Show("Xóa môn học thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        LoadData();
                    }
                    else
                    {
                        MessageBox.Show("Xóa thất bại!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }

        private void btnTimKiem_monHoc_Click(object sender, EventArgs e)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                try
                {
                    conn.Open();

                    // Khởi tạo truy vấn SQL động
                    string query = "SELECT MaMon, TenMon, SoTinChi, MaNganh FROM MonHoc WHERE 1=1";

                    // Danh sách tham số
                    List<SqlParameter> parameters = new List<SqlParameter>();

                    // Thêm điều kiện tìm kiếm nếu có nhập dữ liệu
                    if (!string.IsNullOrWhiteSpace(txtSearch_MamonHoc.Text))
                    {
                        query += " AND MaMon LIKE @MaMon";
                        parameters.Add(new SqlParameter("@MaMon", "%" + txtSearch_MamonHoc.Text.Trim() + "%"));
                    }

                    if (!string.IsNullOrWhiteSpace(txtSearch_ten_monHoc.Text))
                    {
                        query += " AND TenMon LIKE @TenMon";
                        parameters.Add(new SqlParameter("@TenMon", "%" + txtSearch_ten_monHoc.Text.Trim() + "%"));
                    }

                    if (!string.IsNullOrWhiteSpace(txt_sotinchi_Search.Text))
                    {
                        if (int.TryParse(txt_sotinchi_Search.Text.Trim(), out int soTinChi))
                        {
                            query += " AND SoTinChi = @SoTinChi";
                            parameters.Add(new SqlParameter("@SoTinChi", soTinChi));
                        }
                        else
                        {
                            MessageBox.Show("Số tín chỉ phải là số nguyên!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            return;
                        }
                    }

                    if (comboBoxNganh.SelectedIndex != -1)
                    {
                        query += " AND MaNganh = @MaNganh";
                        parameters.Add(new SqlParameter("@MaNganh", comboBoxNganh.SelectedValue.ToString()));
                    }

                    // Thực thi truy vấn
                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        cmd.Parameters.AddRange(parameters.ToArray());
                        SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                        DataTable dt = new DataTable();
                        adapter.Fill(dt);

                        // Kiểm tra nếu không có dữ liệu
                        if (dt.Rows.Count == 0)
                        {
                            MessageBox.Show("Không tìm thấy kết quả phù hợp!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                        else
                        {
                            dataGridViewMOnhoc.DataSource = dt;
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi khi tìm kiếm: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
                for (int i = 0; i < dataGridViewMOnhoc.ColumnCount; i++)
                {
                    application.Cells[1, i + 1] = dataGridViewMOnhoc.Columns[i].HeaderText;
                }

                // Xuất dữ liệu hàng
                for (int i = 0; i < dataGridViewMOnhoc.Rows.Count; i++)
                {
                    for (int j = 0; j < dataGridViewMOnhoc.Columns.Count; j++)
                    {
                        application.Cells[i + 2, j + 1] = dataGridViewMOnhoc.Rows[i].Cells[j].Value?.ToString();
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
    }
}
