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
    public partial class ucQuanLyDiem : UserControl
    {
        public string connectionString = "Data Source=hungf;Initial Catalog=CS_QuanLySinhVien12;Integrated Security=True";
        public ucQuanLyDiem()
        {
            InitializeComponent();
        }

        private void ucQuanLyDiem_Load(object sender, EventArgs e)
        {

            LoadSinhVienKhenThuong();
            LoadComboBoxLop();
            LoadComboBoxMonHoc();
            comboBoxLop.Text = "-- Chọn Lớp --";
            comboBoxMonHoc_diem.Text = "-- Chọn Môn Học --";
            combox_Search_Monhocdiem.Text = "--Chọn môn học--";
            LoadComboBoxMonHocytk();

        }
        // Hiển thị dữ liệu lên DataGridView
        private void LoadSinhVienKhenThuong()
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                string query = @"SELECT 
                                d.MaSV, 
                                sv.HoTen, 
                                l.TenLop, 
                                mh.TenMon, 
                                d.Diem
                            FROM Diem d
                            INNER JOIN SinhVien sv ON d.MaSV = sv.MaSV
                            INNER JOIN Lop l ON sv.MaLop = l.MaLop
                            INNER JOIN MonHoc mh ON d.MaMon = mh.MaMon";

                SqlDataAdapter da = new SqlDataAdapter(query, conn);
                DataTable dt = new DataTable();
                da.Fill(dt);

                dataGridView1.DataSource = dt;
               dataGridView1.Columns["MaSV"].HeaderText = "Mã SV";
               dataGridView1.Columns["HoTen"].HeaderText = "Họ Tên";
                dataGridView1.Columns["TenLop"].HeaderText = "Lớp";
                dataGridView1.Columns["TenMon"].HeaderText = "Môn Học";
                dataGridView1.Columns["Diem"].HeaderText = "Điểm";
                txtHoten.Enabled = false;
              


            }
        }
        private void LoadComboBoxLop()
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                try
                {
                    conn.Open();
                    string query = "SELECT MaLop, TenLop FROM Lop";
                    SqlDataAdapter adapter = new SqlDataAdapter(query, conn);
                    DataTable dt = new DataTable();
                    adapter.Fill(dt);

                    comboBoxLop.DataSource = dt;
                    comboBoxLop.DisplayMember = "TenLop";
                    comboBoxLop.ValueMember = "MaLop";
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi khi tải dữ liệu lớp: " + ex.Message);
                }
            }
        }
        private void LoadComboBoxMonHoc()
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                try
                {
                    conn.Open();
                    string query = "SELECT MaMon, TenMon FROM MonHoc";
                    SqlDataAdapter da = new SqlDataAdapter(query, conn);
                    DataTable dt = new DataTable();
                    da.Fill(dt);

                    comboBoxMonHoc_diem.DataSource = dt;
                    comboBoxMonHoc_diem.DisplayMember = "TenMon"; // Hiển thị tên môn học
                    comboBoxMonHoc_diem.ValueMember = "MaMon"; // Lưu mã môn
                    comboBoxMonHoc_diem.SelectedIndex = -1; // Mặc định chưa chọn môn nào
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi khi tải danh sách môn học: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
        private void LoadComboBoxMonHocytk()
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                try
                {
                    conn.Open();
                    string query = "SELECT MaMon, TenMon FROM MonHoc";
                    SqlDataAdapter da = new SqlDataAdapter(query, conn);
                    DataTable dt = new DataTable();
                    da.Fill(dt);

                    combox_Search_Monhocdiem.DataSource = dt;
                    combox_Search_Monhocdiem.DisplayMember = "TenMon"; // Hiển thị tên môn học
                    combox_Search_Monhocdiem.ValueMember = "MaMon"; // Lưu mã môn
                    combox_Search_Monhocdiem.SelectedIndex = -1; // Mặc định chưa chọn môn nào
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi khi tải danh sách môn học: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
        private bool isFirstClick = true;  // Xác định trạng thái của nút Thêm

        private void btnThemDiem_Click(object sender, EventArgs e)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                try
                {
                    conn.Open();

                    if (isFirstClick)  // Nếu là lần bấm đầu tiên
                    {
                        if (string.IsNullOrWhiteSpace(txtMaSV.Text))
                        {
                            MessageBox.Show("Vui lòng nhập Mã Sinh Viên!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            return;
                        }

                        string query = @"SELECT sv.HoTen, l.TenLop 
                                 FROM SinhVien sv
                                 INNER JOIN Lop l ON sv.MaLop = l.MaLop
                                 WHERE sv.MaSV = @MaSV";

                        SqlCommand cmd = new SqlCommand(query, conn);
                        cmd.Parameters.AddWithValue("@MaSV", txtMaSV.Text.Trim());

                        SqlDataReader reader = cmd.ExecuteReader();

                        if (reader.Read())  // Nếu tìm thấy sinh viên
                        {
                            txtHoten.Text = reader["HoTen"].ToString();
                            comboBoxLop.Text = reader["TenLop"].ToString();
                            isFirstClick = false;  // Chuyển sang trạng thái xác nhận thêm
                            btnThemDiem.Text = "Xác nhận";
                        }
                        else
                        {
                            MessageBox.Show("Không tìm thấy sinh viên!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                        reader.Close();
                    }
                    else  // Nếu là lần bấm thứ hai
                    {
                        if (comboBoxMonHoc_diem.SelectedValue == null || string.IsNullOrWhiteSpace(txtDiem.Text))
                        {
                            MessageBox.Show("Vui lòng nhập đầy đủ Môn Học và Điểm!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            return;
                        }
                        // Kiểm tra nếu điểm nhập vào là số nguyên hoặc số thực
                        if (!decimal.TryParse(txtDiem.Text, out decimal diem))
                        {
                            MessageBox.Show("Điểm phải là số nguyên hoặc số thực!", "Lỗi nhập điểm", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            txtDiem.Focus();
                            return;
                        }

                        // Kiểm tra điểm trong khoảng hợp lệ (0 - 10)
                        if (diem < 0 || diem > 10)
                        {
                            MessageBox.Show("Điểm phải nằm trong khoảng từ 0 đến 10!", "Lỗi nhập điểm", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            txtDiem.Focus();
                            return;
                        }

                        // Thêm điểm vào bảng Diem
                        string insertQuery = @"INSERT INTO Diem (MaSV, MaMon, Diem) VALUES (@MaSV, @MaMon, @Diem)";
                        SqlCommand insertCmd = new SqlCommand(insertQuery, conn);
                        insertCmd.Parameters.AddWithValue("@MaSV", txtMaSV.Text.Trim());
                        insertCmd.Parameters.AddWithValue("@MaMon", comboBoxMonHoc_diem.SelectedValue);
                        insertCmd.Parameters.AddWithValue("@Diem", Convert.ToDecimal(txtDiem.Text));

                        int result = insertCmd.ExecuteNonQuery();
                        if (result > 0)
                        {
                            MessageBox.Show("Thêm điểm thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            LoadSinhVienKhenThuong();  // Cập nhật lại danh sách điểm
                        }
                        else
                        {
                            MessageBox.Show("Thêm điểm thất bại!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }

                        // Reset trạng thái nút Thêm
                        isFirstClick = true;
                        btnThemDiem.Text = "Thêm";
                        txtMaSV.Clear();
                        txtHoten.Clear();
                        txtDiem.Clear();
                        comboBoxMonHoc_diem.SelectedIndex = -1;
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void btnSuaDiem_Click(object sender, EventArgs e)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                try
                {
                    conn.Open();

                    if (selectedMaSV == "")
                    {
                        MessageBox.Show("Vui lòng chọn một sinh viên từ danh sách!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }

                    if (comboBoxMonHoc_diem.SelectedValue == null || string.IsNullOrWhiteSpace(txtDiem.Text))
                    {
                        MessageBox.Show("Vui lòng nhập đầy đủ Môn Học và Điểm!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }

                    // Kiểm tra điểm nhập vào có phải số hợp lệ hay không
                    if (!float.TryParse(txtDiem.Text, out float diem))
                    {
                        MessageBox.Show("Điểm phải là số!", "Lỗi nhập điểm", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        txtDiem.Focus();
                        return;
                    }

                    // Kiểm tra điểm có nằm trong khoảng hợp lệ không
                    if (diem < 0 || diem > 10)
                    {
                        MessageBox.Show("Điểm phải nằm trong khoảng từ 0 đến 10!", "Lỗi nhập điểm", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        txtDiem.Focus();
                        return;
                    }


                    // Cập nhật điểm vào database
                    string updateQuery = @"UPDATE Diem 
               SET MaMon = @MaMon, Diem = @Diem
               WHERE MaSV = @MaSV AND MaMon = @OldMaMon";

                    SqlCommand cmd = new SqlCommand(updateQuery, conn);
                    cmd.Parameters.AddWithValue("@MaSV", selectedMaSV);
                    cmd.Parameters.AddWithValue("@OldMaMon", selectedMaMon); // 🟢 Dùng MaMon đúng
                    cmd.Parameters.AddWithValue("@MaMon", comboBoxMonHoc_diem.SelectedValue); // Môn học mới
                    cmd.Parameters.AddWithValue("@Diem", diem);

                    int result = cmd.ExecuteNonQuery();
                    if (result > 0)
                    {
                        MessageBox.Show("Cập nhật điểm thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        LoadSinhVienKhenThuong(); // Cập nhật lại danh sách
                    }
                    else
                    {
                        MessageBox.Show("Cập nhật điểm thất bại!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }

                    // Reset trạng thái
                    selectedMaSV = "";
                    selectedMaMon = "";
                    txtMaSV.Clear();
                    txtSearchHoten_diem.Clear();
                    txtDiem.Clear();
                    comboBoxMonHoc_diem.SelectedIndex = -1;

                    // Mở khóa lại các ô
                    txtMaSV.Enabled = true;
                    txtHoten.Enabled = true;
                    comboBoxLop.Enabled = true;
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }

        }
        // Biến kiểm tra trạng thái chỉnh sửa
        private string selectedMaSV = "";
        private string selectedMaMon = "";
        private string selectedTenMon = "";
        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0) // Kiểm tra nếu không phải tiêu đề
            {
                DataGridViewRow row = dataGridView1.Rows[e.RowIndex];

                // Lấy dữ liệu từ DataGridView
                selectedMaSV = row.Cells["MaSV"].Value.ToString();
                selectedTenMon = row.Cells["TenMon"].Value.ToString(); // Lấy Tên Môn

                txtMaSV.Text = selectedMaSV;
                txtHoten.Text = row.Cells["HoTen"].Value.ToString();
                comboBoxLop.Text = row.Cells["TenLop"].Value.ToString();
                txtDiem.Text = row.Cells["Diem"].Value.ToString();

                // 🟢 Tìm MaMon tương ứng với TenMon trong ComboBox
                selectedMaMon = FindMaMonByTenMon(selectedTenMon);

                // Gán giá trị MaMon cho ComboBox
                comboBoxMonHoc_diem.SelectedValue = selectedMaMon;

                // Khóa các ô không được chỉnh sửa
                txtMaSV.Enabled = false;
                txtHoten.Enabled = false;
                comboBoxLop.Enabled = false;
                comboBoxMonHoc_diem.Enabled = true;
                txtDiem.Enabled = true;
            }
     
        }
        private string FindMaMonByTenMon(string tenMon)
        {
            foreach (var item in comboBoxMonHoc_diem.Items)
            {
                DataRowView rowView = item as DataRowView;
                if (rowView != null && rowView["TenMon"].ToString() == tenMon)
                {
                    return rowView["MaMon"].ToString(); // Trả về MaMon tương ứng
                }
            }
            return ""; // Trả về rỗng nếu không tìm thấy
        }

        private void btnTimKiem_diem_Click(object sender, EventArgs e)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                try
                {
                    conn.Open();

                    // Lấy giá trị từ các ô tìm kiếm
                    string maSV = txtSearchMaSV_Diem.Text.Trim();
                    string hoTen = txtSearchHoten_diem.Text.Trim();
                    string maMon = combox_Search_Monhocdiem.SelectedValue?.ToString();
                    string maLop = comboBoxLop.SelectedValue?.ToString();

                    // Tạo câu lệnh SQL động
                    string query = "SELECT d.MaSV, sv.HoTen, mh.TenMon, d.Diem, l.TenLop " +
                                   "FROM Diem d " +
                                   "JOIN SinhVien sv ON d.MaSV = sv.MaSV " +
                                   "JOIN MonHoc mh ON d.MaMon = mh.MaMon " +
                                   "JOIN Lop l ON sv.MaLop = l.MaLop " +
                                   "WHERE 1 = 1 "; // Luôn đúng để nối điều kiện

                    List<SqlParameter> parameters = new List<SqlParameter>();

                    // Nếu có nhập Mã Sinh Viên -> tìm kiếm gần đúng hoặc chính xác
                    if (!string.IsNullOrEmpty(maSV))
                    {
                        query += " AND d.MaSV LIKE @MaSV ";
                        parameters.Add(new SqlParameter("@MaSV", "%" + maSV + "%")); // Tìm kiếm gần đúng
                    }

                    // Nếu có nhập Họ Tên -> tìm kiếm gần đúng hoặc chính xác
                    if (!string.IsNullOrEmpty(hoTen))
                    {
                        query += " AND sv.HoTen LIKE @HoTen ";
                        parameters.Add(new SqlParameter("@HoTen", "%" + hoTen + "%"));
                    }

                    // Nếu chọn Môn Học từ ComboBox
                    if (!string.IsNullOrEmpty(maMon))
                    {
                        query += " AND d.MaMon = @MaMon ";
                        parameters.Add(new SqlParameter("@MaMon", maMon));
                    }

                    // Nếu chọn Lớp từ ComboBox
                    if (!string.IsNullOrEmpty(maLop))
                    {
                        query += " AND sv.MaLop = @MaLop ";
                        parameters.Add(new SqlParameter("@MaLop", maLop));
                    }

                    // Thực thi truy vấn
                    SqlCommand cmd = new SqlCommand(query, conn);
                    cmd.Parameters.AddRange(parameters.ToArray());

                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    DataTable dt = new DataTable();
                    da.Fill(dt);

                    // Hiển thị kết quả lên DataGridView
                    dataGridView1.DataSource = dt;

                    if (dt.Rows.Count == 0)
                    {
                        MessageBox.Show("Không tìm thấy kết quả phù hợp!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi khi tìm kiếm: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void btnXoaDiem_Click(object sender, EventArgs e)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                try
                {
                    conn.Open();

                    // Kiểm tra xem người dùng đã chọn sinh viên chưa
                    if (string.IsNullOrEmpty(selectedMaSV) || string.IsNullOrEmpty(selectedMaMon))
                    {
                        MessageBox.Show("Vui lòng chọn một sinh viên và môn học để xóa điểm!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }

                    // Xác nhận trước khi xóa
                    DialogResult confirm = MessageBox.Show("Bạn có chắc chắn muốn xóa điểm của sinh viên này?", "Xác nhận xóa", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                    if (confirm == DialogResult.No) return;

                    // Câu lệnh DELETE trong SQL
                    string deleteQuery = "DELETE FROM Diem WHERE MaSV = @MaSV AND MaMon = @MaMon";
                    SqlCommand cmd = new SqlCommand(deleteQuery, conn);
                    cmd.Parameters.AddWithValue("@MaSV", selectedMaSV);
                    cmd.Parameters.AddWithValue("@MaMon", selectedMaMon);

                    int result = cmd.ExecuteNonQuery();
                    if (result > 0)
                    {
                        MessageBox.Show("Xóa điểm thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        LoadSinhVienKhenThuong(); // Load lại dữ liệu sau khi xóa
                    }
                    else
                    {
                        MessageBox.Show("Xóa điểm thất bại! Vui lòng kiểm tra lại.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }

                    // Reset trạng thái
                    selectedMaSV = "";
                    selectedMaMon = "";
                    txtMaSV.Clear();
                    txtHoten.Clear();
                    txtDiem.Clear();
                    comboBoxMonHoc_diem.SelectedIndex = -1;

                    // Mở khóa lại các ô nhập
                    txtMaSV.Enabled = true;
                    txtHoten.Enabled = true;
                    comboBoxLop.Enabled = true;
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
                for (int i = 0; i < dataGridView1.ColumnCount; i++)
                {
                    application.Cells[1, i + 1] = dataGridView1.Columns[i].HeaderText;
                }

                // Xuất dữ liệu hàng
                for (int i = 0; i < dataGridView1.Rows.Count; i++)
                {
                    for (int j = 0; j < dataGridView1.Columns.Count; j++)
                    {
                        application.Cells[i + 2, j + 1] = dataGridView1.Rows[i].Cells[j].Value?.ToString();
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
