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
    public partial class ucQuanLyHocLai : UserControl
    {
        string connectionString = "Data Source=hungf;Initial Catalog=CS_QuanLySinhVien12;Integrated Security=True";
        public ucQuanLyHocLai()
        {
            InitializeComponent();
        }
        private void LoadData()
        {
            string query = @"SELECT
                    hl.MaSV,
                    sv.HoTen,
                    sv.GioiTinh,
                    l.TenLop,
                    mh.TenMon,
                    hl.MaMon  
                FROM HocLai hl   -- Sửa lại từ ThiLai -> HocLai
                JOIN SinhVien sv ON hl.MaSV = sv.MaSV
                JOIN Lop l ON sv.MaLop = l.MaLop
                JOIN MonHoc mh ON hl.MaMon = mh.MaMon";

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                SqlDataAdapter da = new SqlDataAdapter(query, conn);
                DataTable dt = new DataTable();
                da.Fill(dt);
                dataGridView_Hoclai.DataSource = dt;
            }
            dataGridView_Hoclai.Columns["MaSV"].HeaderText = "Mã SV";
                dataGridView_Hoclai.Columns["HoTen"].HeaderText = "Họ và Tên";
                dataGridView_Hoclai.Columns["GioiTinh"].HeaderText = "Giới Tính";
                dataGridView_Hoclai.Columns["TenLop"].HeaderText = "Lớp";
                dataGridView_Hoclai.Columns["TenMon"].HeaderText = "Môn Học Lại";
                dataGridView_Hoclai.Columns["MaMon"].Visible = false; // Ẩn cột MaMon nếu không muốn hiển thị
            }
        
        private void InitializeUI()
        {
            // Chỉ cho phép nhập mã sinh viên và nhấn nút Thêm
            txtMaSV_Hoclai.Enabled = true;
            btnThem_Hoclai.Enabled = true;

            // Ẩn các controls khác
            txtHoten_Hoclai.Enabled = false;
            comboBoxGioitinh_Hoclai.Enabled = false;
            comboBoxLop_Hoclai.Enabled = false;
            btnSua_Hoclai.Enabled = true;
            btnXoa_Hoclai.Enabled = true;
            btnTimKiem_Hoclai.Enabled = true;
            comboBoxMonHoclai.Enabled = false;
        }
        private void ucQuanLyHocLai_Load(object sender, EventArgs e)
        {
            LoadLopHocLai(); // Gọi hàm để load danh sách lớp vào ComboBox
            LoadData();
            InitializeUI();
            LoadMonHocLai();
            comboBoxMonHoclai.Text = "-- Chọn Môn Học Lại --"; // Hiển thị trạng thái mặc định
            comboBoxLop_Hoclai.Text = "-- Chọn lớp Học Lại --"; // Hiển thị trạng thái mặc định
            LoadLopHocLai1();
        }
        private void LoadLopHocLai()
        {
            string query = "SELECT MaLop, TenLop FROM Lop";

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    DataTable dt = new DataTable();
                    da.Fill(dt);

                    comboBoxLop_Hoclai.DataSource = dt;
                    comboBoxLop_Hoclai.DisplayMember = "TenLop"; // Hiển thị tên lớp
                    comboBoxLop_Hoclai.ValueMember = "MaLop";   // Giá trị ẩn là mã lớp
                }
            }
        }
        private void LoadLopHocLai1()
{
    string query = "SELECT MaLop, TenLop FROM Lop";

    using (SqlConnection conn = new SqlConnection(connectionString))
    {
        conn.Open();
        using (SqlCommand cmd = new SqlCommand(query, conn))
        {
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);

                    comboBox_Hoclailop.DataSource = dt;
                    comboBox_Hoclailop.DisplayMember = "TenLop"; // Hiển thị tên lớp
                    comboBox_Hoclailop.ValueMember = "MaLop";   // Giá trị ẩn là mã lớp
                    comboBox_Hoclailop.SelectedIndex = -1;      // Không chọn mặc định
        }
    }
}

        private void LoadMonHocLai()
        {
            string query = "SELECT MaMon, TenMon FROM MonHoc";
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    DataTable dt = new DataTable();
                    da.Fill(dt);

                    comboBoxMonHoclai.DataSource = dt;
                    comboBoxMonHoclai.DisplayMember = "TenMon"; // Hiển thị tên môn học
                    comboBoxMonHoclai.ValueMember = "MaMon";   // Giá trị ẩn là mã môn
                }
            }
        }

        private void btnThem_Hoclai_Click(object sender, EventArgs e)
        {
            string maSV = txtMaSV_Hoclai.Text.Trim();

            if (string.IsNullOrEmpty(maSV))
            {
                MessageBox.Show("Vui lòng nhập Mã SV!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();

                // 📌 **Bước 1: Nếu đã chọn môn thi lại => Kiểm tra trùng và thêm vào database**
                if (comboBoxMonHoclai.Enabled && comboBoxMonHoclai.SelectedValue != null)
                {
                    string maMon = comboBoxMonHoclai.SelectedValue.ToString();

                    // Kiểm tra sinh viên đã đăng ký môn này chưa
                    string checkQuery = "SELECT COUNT(*) FROM HocLai WHERE MaSV = @MaSV AND MaMon = @MaMon";
                    using (SqlCommand checkCmd = new SqlCommand(checkQuery, conn))
                    {
                        checkCmd.Parameters.AddWithValue("@MaSV", maSV);
                        checkCmd.Parameters.AddWithValue("@MaMon", maMon);
                        int count = (int)checkCmd.ExecuteScalar();

                        if (count > 0)
                        {
                            MessageBox.Show("Sinh viên đã đăng ký thi lại môn này!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            return;
                        }
                    }

                    // Nếu không trùng, tiến hành thêm mới
                    string insertQuery = "INSERT INTO HocLai (MaSV, MaMon) VALUES (@MaSV, @MaMon)";
                    using (SqlCommand insertCmd = new SqlCommand(insertQuery, conn))
                    {
                        insertCmd.Parameters.AddWithValue("@MaSV", maSV);
                        insertCmd.Parameters.AddWithValue("@MaMon", maMon);

                        int result = insertCmd.ExecuteNonQuery();
                        if (result > 0)
                        {
                            MessageBox.Show("Thêm sinh viên vào danh sách thi lại thành công!", "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            LoadData(); // Cập nhật DataGridView
                        }
                        else
                        {
                            MessageBox.Show("Lỗi khi thêm sinh viên!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                    return;
                }

                // 📌 **Bước 2: Nếu chưa chọn môn, lấy thông tin sinh viên**
                string query = "SELECT HoTen, GioiTinh, MaLop FROM SinhVien WHERE MaSV = @MaSV";
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@MaSV", maSV);
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.Read()) // Nếu tìm thấy sinh viên
                        {
                            txtHoten_Hoclai.Text = reader["HoTen"].ToString();
                            comboBoxGioitinh_Hoclai.Text = reader["GioiTinh"].ToString();
                            comboBoxLop_Hoclai.Text = reader["MaLop"].ToString();

                            // Hiển thị nhưng vẫn khóa
                            txtHoten_Hoclai.Enabled = false;
                            comboBoxGioitinh_Hoclai.Enabled = false;
                            comboBoxLop_Hoclai.Enabled = false;
                            btnSua_Hoclai.Enabled = true;
                            btnXoa_Hoclai.Enabled = true;
                            btnTimKiem_Hoclai.Enabled = true;

                            // Chỉ mở combobox môn thi lại để chọn
                            comboBoxMonHoclai.Enabled = true;
                        }
                        else
                        {
                            MessageBox.Show("Không tìm thấy sinh viên!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }
            }
        }

        private void dataGridView_Hoclai_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0) // Đảm bảo người dùng không click vào tiêu đề
            {
                DataGridViewRow row = dataGridView_Hoclai.Rows[e.RowIndex];

                // Gán dữ liệu vào các control
                txtMaSV_Hoclai.Text = row.Cells["MaSV"].Value.ToString();
                txtHoten_Hoclai.Text = row.Cells["HoTen"].Value.ToString();
                comboBoxGioitinh_Hoclai.Text = row.Cells["GioiTinh"].Value.ToString();
                comboBoxLop_Hoclai.Text = row.Cells["TenLop"].Value.ToString();

                // Tìm mã môn học dựa trên tên môn học
                string tenMonHocLai = row.Cells["TenMon"].Value.ToString();
                foreach (DataRowView item in comboBoxMonHoclai.Items)
                {
                    if (item["TenMon"].ToString() == tenMonHocLai)
                    {
                        comboBoxMonHoclai.SelectedValue = item["MaMon"];
                        break;
                    }
                }

                // Khóa các trường không cần chỉnh sửa
                txtMaSV_Hoclai.Enabled = false;
                txtHoten_Hoclai.Enabled = false;
                comboBoxGioitinh_Hoclai.Enabled = false;
                comboBoxLop_Hoclai.Enabled = false;

                // Cho phép chỉnh sửa combobox môn học thi lại
                comboBoxMonHoclai.Enabled = true;
                btnSua_Hoclai.Enabled = true;
                btnXoa_Hoclai.Enabled = true;
            }
        }
        private string GetMaLopFromText(string lopText)
        {
            string maLop = null;
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                string query = "SELECT MaLop FROM Lop WHERE TenLop = @TenLop";
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@TenLop", lopText);
                    object result = cmd.ExecuteScalar();
                    if (result != null)
                        maLop = result.ToString();
                }
            }
            return maLop;
        }
        // Hàm lấy MaMon từ TenMon
        private string GetMaMon(string tenMon)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                string query = "SELECT MaMon FROM MonHoc WHERE TenMon = @TenMon";
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@TenMon", tenMon);
                    object result = cmd.ExecuteScalar();
                    return result?.ToString() ?? "";
                }
            }
        }
        private void btnSua_Hoclai_Click(object sender, EventArgs e)
        {
            if (dataGridView_Hoclai.SelectedRows.Count > 0)
            {
                string maSV = txtMaSV_Hoclai.Text;
                string maMonMoi = GetMaMon(comboBoxMonHoclai.Text); // Lấy MaMon từ tên môn
                string maMonCu = dataGridView_Hoclai.SelectedRows[0].Cells["MaMon"].Value.ToString(); // Lấy MaMon cũ từ DataGridView

                // Kiểm tra nếu không thay đổi môn thi lại
                if (maMonMoi == maMonCu)
                {
                    MessageBox.Show("Môn thi lại không có thay đổi!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();

                    // Kiểm tra xem sinh viên đã đăng ký môn thi lại mới chưa
                    string checkQuery = "SELECT COUNT(*) FROM HocLai WHERE MaSV = @MaSV AND MaMon = @MaMonMoi";
                    using (SqlCommand checkCmd = new SqlCommand(checkQuery, conn))
                    {
                        checkCmd.Parameters.AddWithValue("@MaSV", maSV);
                        checkCmd.Parameters.AddWithValue("@MaMonMoi", maMonMoi);
                        int count = (int)checkCmd.ExecuteScalar();

                        if (count > 0)
                        {
                            MessageBox.Show("Sinh viên đã đăng ký thi lại môn này!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            return;
                        }
                    }

                    // Cập nhật môn thi lại theo MaMon
                    string updateQuery = "UPDATE HocLai SET MaMon = @MaMonMoi WHERE MaSV = @MaSV AND MaMon = @MaMonCu";
                    using (SqlCommand updateCmd = new SqlCommand(updateQuery, conn))
                    {
                        updateCmd.Parameters.AddWithValue("@MaSV", maSV);
                        updateCmd.Parameters.AddWithValue("@MaMonMoi", maMonMoi);
                        updateCmd.Parameters.AddWithValue("@MaMonCu", maMonCu);

                        int result = updateCmd.ExecuteNonQuery();
                        if (result > 0)
                        {
                            MessageBox.Show("Cập nhật môn thi lại thành công!", "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            LoadData(); // Cập nhật lại DataGridView
                        }
                        else
                        {
                            MessageBox.Show("Lỗi khi cập nhật môn thi lại!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }
            }
            else
            {
                MessageBox.Show("Vui lòng chọn một sinh viên để sửa!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void btnXoa_Hoclai_Click(object sender, EventArgs e)
        {
            if (dataGridView_Hoclai.SelectedRows.Count > 0)
            {
                string maSV = txtMaSV_Hoclai.Text;
                string maMon = dataGridView_Hoclai.SelectedRows[0].Cells["MaMon"].Value.ToString();

                DialogResult result = MessageBox.Show("Bạn có chắc muốn xóa sinh viên khỏi danh sách thi lại?",
                                                      "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (result == DialogResult.Yes)
                {
                    using (SqlConnection conn = new SqlConnection(connectionString))
                    {
                        conn.Open();

                        string deleteQuery = "DELETE FROM HocLai WHERE MaSV = @MaSV AND MaMon = @MaMon";
                        using (SqlCommand deleteCmd = new SqlCommand(deleteQuery, conn))
                        {
                            deleteCmd.Parameters.AddWithValue("@MaSV", maSV);
                            deleteCmd.Parameters.AddWithValue("@MaMon", maMon);

                            int rowsAffected = deleteCmd.ExecuteNonQuery();
                            if (rowsAffected > 0)
                            {
                                MessageBox.Show("Xóa sinh viên khỏi danh sách thi lại thành công!", "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                LoadData(); // Cập nhật DataGridView
                            }
                            else
                            {
                                MessageBox.Show("Lỗi khi xóa sinh viên!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }
                        }
                    }
                }
            }
            else
            {
                MessageBox.Show("Vui lòng chọn một sinh viên để xóa!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void btnTimKiem_Hoclai_Click(object sender, EventArgs e)
        {
            string maSV = txtSearchMaSV_Hoclai.Text.Trim();
            string hoTen = txtSearchHoten_Hoclai.Text.Trim();
            string maLop = comboBox_Hoclailop.SelectedValue?.ToString(); // Lấy MaLop từ ComboBox
            string lopText = comboBox_Hoclailop.Text.Trim(); // Lấy Text để phòng khi SelectedValue null

            // Nếu chưa chọn gì thì maLop sẽ null, ta sẽ kiểm tra theo Text
            if (string.IsNullOrEmpty(maLop) && !string.IsNullOrEmpty(lopText))
            {
                // Tìm MaLop từ Text hiển thị
                maLop = GetMaLopFromText(lopText);
            }

            // Tạo câu lệnh SQL động
            string query = @"SELECT 
                tl.MaSV, 
                sv.HoTen, 
                sv.GioiTinh, 
                l.TenLop, 
                mh.TenMon 
            FROM HocLai tl
            JOIN SinhVien sv ON tl.MaSV = sv.MaSV
            JOIN Lop l ON sv.MaLop = l.MaLop
            JOIN MonHoc mh ON tl.MaMon = mh.MaMon
            WHERE 1=1";  // 1=1 để dễ dàng thêm điều kiện động

            // Danh sách tham số cho SQL
            List<SqlParameter> parameters = new List<SqlParameter>();

            if (!string.IsNullOrEmpty(maSV))
            {
                query += " AND tl.MaSV LIKE @MaSV";
                parameters.Add(new SqlParameter("@MaSV", "%" + maSV + "%"));
            }

            if (!string.IsNullOrEmpty(hoTen))
            {
                query += " AND sv.HoTen LIKE @HoTen";
                parameters.Add(new SqlParameter("@HoTen", "%" + hoTen + "%"));
            }

            if (!string.IsNullOrEmpty(maLop))
            {
                query += " AND sv.MaLop = @MaLop";
                parameters.Add(new SqlParameter("@MaLop", maLop));
            }

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddRange(parameters.ToArray()); // Thêm tất cả tham số vào truy vấn

                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    DataTable dt = new DataTable();
                    da.Fill(dt);

                    // Kiểm tra nếu không có dữ liệu
                    if (dt.Rows.Count == 0)
                    {
                        MessageBox.Show("Không tìm thấy sinh viên phù hợp!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }

                    // Hiển thị kết quả lên DataGridView
                    dataGridView_Hoclai.DataSource = dt;
                }
            }

        }

        private void comboBox_Hoclai_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
        private void ExportExcel(string path)
        {

            try
            {
                Excel.Application application = new Excel.Application();
                application.Application.Workbooks.Add(Type.Missing);

                // Xuất tiêu đề cột
                for (int i = 0; i < dataGridView_Hoclai.ColumnCount; i++)
                {
                    application.Cells[1, i + 1] = dataGridView_Hoclai.Columns[i].HeaderText;
                }

                // Xuất dữ liệu hàng
                for (int i = 0; i < dataGridView_Hoclai.Rows.Count; i++)
                {
                    for (int j = 0; j < dataGridView_Hoclai.Columns.Count; j++)
                    {
                        application.Cells[i + 2, j + 1] = dataGridView_Hoclai.Rows[i].Cells[j].Value?.ToString();
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
