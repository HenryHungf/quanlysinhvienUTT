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
    public partial class ucQuanLyBaoLuu : UserControl

    {
        string connectionString = "Data Source=hungf;Initial Catalog=CS_QuanLySinhVien12;Integrated Security=True";
        public ucQuanLyBaoLuu()

        {
            InitializeComponent();

        }

        private void LoadData()
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                try
                {
                    conn.Open();
                    string query = @"
                        SELECT SV.MaSV, SV.HoTen, SV.NgaySinh, SV.GioiTinh, SV.DienThoai, L.TenLop
                        FROM BaoLuu BL
                        JOIN SinhVien SV ON BL.MaSV = SV.MaSV
                        JOIN Lop L ON SV.MaLop = L.MaLop";

                    SqlDataAdapter da = new SqlDataAdapter(query, conn);
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    dataGridViewBaoLuu.DataSource = dt;
                    dataGridViewBaoLuu.Columns["MaSV"].HeaderText = "Mã SV";
                    dataGridViewBaoLuu.Columns["HoTen"].HeaderText = "Họ tên";
                    dataGridViewBaoLuu.Columns["NgaySinh"].HeaderText = "Ngày Sinh";
                    dataGridViewBaoLuu.Columns["GioiTinh"].HeaderText = "Giới Tính";
                    dataGridViewBaoLuu.Columns["DienThoai"].HeaderText = "SĐT";
                    dataGridViewBaoLuu.Columns["TenLop"].HeaderText = "Tên lớp";

                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi khi tải dữ liệu bảo lưu: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
        // 2. Hàm tải danh sách lớp vào ComboBox
        private void LoadComboBoxLop()
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                try
                {
                    conn.Open();
                    string query = "SELECT MaLop, TenLop FROM Lop";
                    SqlDataAdapter da = new SqlDataAdapter(query, conn);
                    DataTable dt = new DataTable();
                    da.Fill(dt);

                    comboBoxLopBaoLuu.DataSource = dt;
                    comboBoxLopBaoLuu.DisplayMember = "TenLop";
                    comboBoxLopBaoLuu.ValueMember = "MaLop";
                    comboBoxLopBaoLuu.SelectedIndex = -1; // Không chọn mặc định
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi khi tải danh sách lớp: " + ex.Message);
                }
            }
        }

        private void label10_Click(object sender, EventArgs e)
        {

        }

        private void ucQuanLyBaoLuu_Load(object sender, EventArgs e)
        {

            comboBoxLopBaoLuu.SelectedIndexChanged -= comboBoxLopBaoLuu_SelectedIndexChanged;
            LoadData();
            LoadComboBoxLop();
            comboBoxLopBaoLuu.Text = "-- Chọn Lớp --";
            comboBoxLopBaoLuu.SelectedIndexChanged += comboBoxLopBaoLuu_SelectedIndexChanged;
        }
        private void comboBoxLopBaoLuu_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBoxLopBaoLuu.SelectedValue != null)
            {
                string maLop = comboBoxLopBaoLuu.SelectedValue.ToString();
                LoadSinhVien(maLop);
            }
        }
        private void LoadSinhVien(string maLop)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                try
                {
                    conn.Open();
                    string query = "SELECT MaSV, HoTen FROM SinhVien WHERE MaLop = @MaLop";
                    SqlCommand cmd = new SqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@MaLop", maLop);

                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    DataTable dt = new DataTable();
                    da.Fill(dt);

                    if (dt.Rows.Count > 0)
                    {
                        // Hiển thị danh sách sinh viên trong combobox
                        comboBoxMaSV.DataSource = dt;
                        comboBoxMaSV.DisplayMember = "MaSV";
                        comboBoxMaSV.ValueMember = "MaSV";
                        comboBoxMaSV.SelectedIndex = -1;

                        comboBoxHotenBaoLuu.DataSource = dt.Copy();
                        comboBoxHotenBaoLuu.DisplayMember = "HoTen";
                        comboBoxHotenBaoLuu.ValueMember = "MaSV";
                        comboBoxHotenBaoLuu.SelectedIndex = -1;
                    }
                    else
                    {
                        MessageBox.Show("Không có sinh viên nào trong lớp này.");
                        comboBoxMaSV.DataSource = null;
                        comboBoxHotenBaoLuu.DataSource = null;
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi khi tải danh sách sinh viên: " + ex.Message);
                }
            }
        }


        private void btnThemBaoLuu_Click(object sender, EventArgs e)
        {
            string maSV = comboBoxMaSV.SelectedValue?.ToString();

            if (string.IsNullOrEmpty(maSV))
            {
                MessageBox.Show("Vui lòng chọn sinh viên!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                try
                {
                    conn.Open();

                    // Kiểm tra sinh viên đã có trong bảng BaoLuu chưa
                    string checkQuery = "SELECT COUNT(*) FROM BaoLuu WHERE MaSV = @MaSV";
                    using (SqlCommand checkCmd = new SqlCommand(checkQuery, conn))
                    {
                        checkCmd.Parameters.AddWithValue("@MaSV", maSV);
                        int count = (int)checkCmd.ExecuteScalar();
                        if (count > 0)
                        {
                            MessageBox.Show("Sinh viên này đã có trong danh sách bảo lưu!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return;
                        }
                    }

                    // Thêm vào bảng BaoLuu (chỉ có MaSV)
                    string insertQuery = "INSERT INTO BaoLuu (MaSV) VALUES (@MaSV)";
                    using (SqlCommand cmd = new SqlCommand(insertQuery, conn))
                    {
                        cmd.Parameters.AddWithValue("@MaSV", maSV);
                        cmd.ExecuteNonQuery();
                    }

                    MessageBox.Show("Thêm sinh viên bảo lưu thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LoadData(); // Cập nhật lại danh sách trên DataGridView
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi khi thêm dữ liệu: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void comboBoxMaSV_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBoxMaSV.SelectedValue != null)
            {
                comboBoxHotenBaoLuu.SelectedValue = comboBoxMaSV.SelectedValue;
            }
        }

        private void comboBoxHotenBaoLuu_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBoxHotenBaoLuu.SelectedValue != null)
            {
                comboBoxMaSV.SelectedValue = comboBoxHotenBaoLuu.SelectedValue;
            }
        }

        private void comboBoxLopBaoLuu_SelectedIndexChanged_1(object sender, EventArgs e)
        {
            if (comboBoxLopBaoLuu.SelectedItem != null && comboBoxLopBaoLuu.SelectedValue is string maLop)
            {
                MessageBox.Show("Mã lớp được chọn: " + maLop);
                LoadSinhVien(maLop);
            }
        }

        private void dataGridViewBaoLuu_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0) // Kiểm tra nếu không phải là tiêu đề cột
            {
                DataGridViewRow row = dataGridViewBaoLuu.Rows[e.RowIndex];

                string maSV = row.Cells["MaSV"].Value?.ToString();
                string hoTen = row.Cells["HoTen"].Value?.ToString();
                string tenLop = row.Cells["TenLop"].Value?.ToString(); // Lấy TenLop thay vì MaLop

                if (!string.IsNullOrEmpty(maSV))
                {
                    // Gán giá trị vào các ComboBox
                    comboBoxMaSV.SelectedValue = maSV;
                    comboBoxHotenBaoLuu.Text = hoTen;
                    comboBoxLopBaoLuu.Text = tenLop; // Set Text vì không có MaLop
                }
                else
                {
                    MessageBox.Show("Dữ liệu không hợp lệ!");
                }
            }
            btnTimKiemsvBaoLuu.Enabled = false; // Khóa nút tìm kiếm
            txtSearchHotenBaoLuu.Enabled = false;
            txtSearchMaSVBaoLuu.Enabled = false;
        }
    

        private void btnXoaBaoLuu_Click(object sender, EventArgs e)
        {
            string maSV = comboBoxMaSV.SelectedValue?.ToString();

            if (string.IsNullOrEmpty(maSV))
            {
                MessageBox.Show("Vui lòng chọn sinh viên để xóa!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            DialogResult result = MessageBox.Show("Bạn có chắc chắn muốn xóa sinh viên này khỏi danh sách bảo lưu?",
                                                  "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

            if (result == DialogResult.Yes)
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    try
                    {
                        conn.Open();

                        // Xóa sinh viên khỏi bảng BaoLuu
                        string deleteQuery = "DELETE FROM BaoLuu WHERE MaSV = @MaSV";
                        using (SqlCommand cmd = new SqlCommand(deleteQuery, conn))
                        {
                            cmd.Parameters.AddWithValue("@MaSV", maSV);
                            cmd.ExecuteNonQuery();
                        }

                        MessageBox.Show("Xóa sinh viên bảo lưu thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        LoadData(); // Cập nhật lại danh sách trên DataGridView
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Lỗi khi xóa dữ liệu: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }

        private void btnTimKiemsvBaoLuu_Click(object sender, EventArgs e)
        {
            string searchMaSV = txtSearchMaSVBaoLuu.Text.Trim();
            string searchHoTen = txtSearchHotenBaoLuu.Text.Trim();

            // Kiểm tra nếu cả hai ô đều trống
            if (string.IsNullOrEmpty(searchMaSV) && string.IsNullOrEmpty(searchHoTen))
            {
                MessageBox.Show("Vui lòng nhập Mã sinh viên hoặc Họ tên để tìm kiếm!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Tạo truy vấn SQL
            string query = @"
        SELECT SV.MaSV, SV.HoTen, SV.NgaySinh, SV.GioiTinh, SV.DienThoai, L.MaLop, L.TenLop
        FROM BaoLuu BL
        JOIN SinhVien SV ON BL.MaSV = SV.MaSV
        JOIN Lop L ON SV.MaLop = L.MaLop
        WHERE (@MaSV = '' OR SV.MaSV LIKE '%' + @MaSV + '%')
        AND (@HoTen = '' OR SV.HoTen LIKE '%' + @HoTen + '%')";

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                SqlDataAdapter da = new SqlDataAdapter(query, conn);
                da.SelectCommand.Parameters.AddWithValue("@MaSV", searchMaSV);
                da.SelectCommand.Parameters.AddWithValue("@HoTen", searchHoTen);

                DataTable dt = new DataTable();
                da.Fill(dt);

                if (dt.Rows.Count > 0)
                {
                    dataGridViewBaoLuu.DataSource = dt;
                }
                else
                {
                    MessageBox.Show("Không tìm thấy sinh viên nào phù hợp!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    dataGridViewBaoLuu.DataSource = null; // Xóa dữ liệu cũ
                }
            }
        }

        private void dataGridViewBaoLuu_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
        private void ExportExcel(string path)
        {

            try
            {
                Excel.Application application = new Excel.Application();
                application.Application.Workbooks.Add(Type.Missing);

                // Xuất tiêu đề cột
                for (int i = 0; i < dataGridViewBaoLuu.ColumnCount; i++)
                {
                    application.Cells[1, i + 1] = dataGridViewBaoLuu.Columns[i].HeaderText;
                }

                // Xuất dữ liệu hàng
                for (int i = 0; i < dataGridViewBaoLuu.Rows.Count; i++)
                {
                    for (int j = 0; j < dataGridViewBaoLuu.Columns.Count; j++)
                    {
                        application.Cells[i + 2, j + 1] = dataGridViewBaoLuu.Rows[i].Cells[j].Value?.ToString();
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
            else
            {
                MessageBox.Show("Looix!", "Thông báo", MessageBoxButtons.RetryCancel, MessageBoxIcon.Information);
            }

        }
    }
    }

