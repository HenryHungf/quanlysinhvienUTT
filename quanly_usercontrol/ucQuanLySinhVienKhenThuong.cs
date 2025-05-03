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
 
    public partial class ucQuanLySinhVienKhenThuong : UserControl
    {
        public string connectionString = "Data Source=hungf;Initial Catalog=CS_QuanLySinhVien12;Integrated Security=True";
        public ucQuanLySinhVienKhenThuong()
        {
            InitializeComponent();
        }

        private void ucQuanLySinhVienKhenThuong_Load(object sender, EventArgs e)
        {
            LoadLop();
            InitializeUI();
            LoadSinhVienKhenThuong();
            LoadLopToComboBox();
        }

        private void LoadLop()
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                string query = "SELECT MaLop, TenLop FROM Lop";
                SqlDataAdapter da = new SqlDataAdapter(query, conn);
                DataTable dt = new DataTable();
                da.Fill(dt);

                comboBoxLop_KhenThuong.DataSource = dt;
                comboBoxLop_KhenThuong.DisplayMember = "TenLop";
                comboBoxLop_KhenThuong.ValueMember = "MaLop";
                comboBoxLop_KhenThuong.SelectedIndex = -1; // Không chọn lớp nào mặc định
            }
        }
        // Hiển thị dữ liệu lên DataGridView
        private void LoadSinhVienKhenThuong()
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                string query = @"
                    SELECT 
                        sv.MaSV, 
                        sv.HoTen, 
                        sv.GioiTinh, 
                        sv.NgaySinh, 
                        sv.DiaChi, 
                        sv.DienThoai, 
                        l.TenLop, 
                        kt.LyDo 
                    FROM KhenThuong kt
                    JOIN SinhVien sv ON kt.MaSV = sv.MaSV
                    JOIN Lop l ON sv.MaLop = l.MaLop ";

                SqlDataAdapter da = new SqlDataAdapter(query, conn);
                DataTable dt = new DataTable();
                da.Fill(dt);

                dataGridViewKhenThuong.DataSource = dt;
                dataGridViewKhenThuong.Columns["MaSV"].HeaderText = "Mã SV";
                dataGridViewKhenThuong.Columns["HoTen"].HeaderText = "Họ Tên";
                dataGridViewKhenThuong.Columns["GioiTinh"].HeaderText = "Giới tính";
                dataGridViewKhenThuong.Columns["NgaySinh"].HeaderText = "Ngày sinh";
                dataGridViewKhenThuong.Columns["DiaChi"].HeaderText = "Địa chỉ";
                dataGridViewKhenThuong.Columns["DienThoai"].HeaderText = "Điện thoại";
                dataGridViewKhenThuong.Columns["Tenlop"].HeaderText = "Tên lớp";
                dataGridViewKhenThuong.Columns["LyDo"].HeaderText = "Lý do";
            }
        }//Where l.MaLop ='KT1'

        // Biến kiểm tra trạng thái của nút "Thêm"
        private bool isFirstClick = true;

        private void btnThem_KhenThuong_Click(object sender, EventArgs e)
        {
            string maSV = txtMaSVKhenThuong.Text.Trim();

            if (isFirstClick)
            {
                // Ấn lần 1: Hiển thị và khóa thông tin sinh viên
                if (string.IsNullOrEmpty(maSV))
                {
                    MessageBox.Show("Vui lòng nhập mã sinh viên!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    try
                    {
                        conn.Open();
                        string query = "SELECT HoTen, NgaySinh, DiaChi, GioiTinh, DienThoai, MaLop FROM SinhVien WHERE MaSV = @MaSV";
                        using (SqlCommand cmd = new SqlCommand(query, conn))
                        {
                            cmd.Parameters.AddWithValue("@MaSV", maSV);
                            using (SqlDataReader reader = cmd.ExecuteReader())
                            {
                                if (reader.Read())
                                {
                                    // Gán dữ liệu vào các textbox
                                    txtHotenKhenThuong.Text = reader["HoTen"].ToString();
                                    dateTimePicker1.Value = Convert.ToDateTime(reader["NgaySinh"]);
                                    txtDiachiKhenThuong.Text = reader["DiaChi"].ToString();
                                    comboBoxGioitinhKhenThuong.Text = reader["GioiTinh"].ToString();
                                    txtDienthoai_KhenThuong.Text = reader["DienThoai"].ToString();
                                    comboBoxLop_KhenThuong.SelectedValue = reader["MaLop"].ToString();

                                   

                                    // Mở ô nhập lý do khen thưởng
                                    txtLYDOKHENTHUONG_KhenThuong.Enabled = true;
                                    txtLYDOKHENTHUONG_KhenThuong.Focus();
                                    btnThem_KhenThuong.Text = "Xác nhận";
                                    isFirstClick = false;
                                }
                                else
                                {
                                    MessageBox.Show("Không tìm thấy sinh viên!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                }
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Lỗi khi truy vấn dữ liệu: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            else
            {
                // Ấn lần 2: Thêm sinh viên vào bảng KhenThuong
                string lyDo = txtLYDOKHENTHUONG_KhenThuong.Text.Trim();

                if (string.IsNullOrEmpty(lyDo))
                {
                    MessageBox.Show("Vui lòng nhập lý do khen thưởng!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    try
                    {
                        conn.Open();

                        // Kiểm tra xem sinh viên đã có trong bảng KhenThuong chưa
                        string checkQuery = "SELECT COUNT(*) FROM KhenThuong WHERE MaSV = @MaSV";
                        using (SqlCommand checkCmd = new SqlCommand(checkQuery, conn))
                        {
                            checkCmd.Parameters.AddWithValue("@MaSV", maSV);
                            int count = (int)checkCmd.ExecuteScalar();
                            if (count > 0)
                            {
                                MessageBox.Show("Sinh viên này đã được khen thưởng trước đó!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                return;
                            }
                        }


                        // Nếu chưa có, thêm mới khen thưởng
                        string insertQuery = "INSERT INTO KhenThuong (MaSV, LyDo) VALUES (@MaSV, @LyDo)";
                        using (SqlCommand cmd = new SqlCommand(insertQuery, conn))
                        {
                            cmd.Parameters.AddWithValue("@MaSV", maSV);
                            cmd.Parameters.AddWithValue("@LyDo", lyDo);

                            int result = cmd.ExecuteNonQuery();
                            if (result > 0)
                            {
                                MessageBox.Show("Thêm khen thưởng thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                LoadSinhVienKhenThuong(); // Cập nhật DataGridView

                            }
                            else
                            {
                                MessageBox.Show("Thêm khen thưởng thất bại!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }
                        }
                     



                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Lỗi khi thêm dữ liệu: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }

        private void InitializeUI()
        {
            // Chỉ cho phép nhập mã sinh viên và nhấn nút Thêm
            txtMaSVKhenThuong.Enabled = true;
            btnThem_KhenThuong.Enabled = true;

            // Ẩn các controls khác
            txtHotenKhenThuong.Enabled = false;
            comboBoxGioitinhKhenThuong.Enabled = false;
            comboBoxLop_KhenThuong.Enabled = false;
            btnSua_KhenThuong.Enabled = true;
            btnXoa_KhenThuong.Enabled = true;
            btnTimKiem_KhenThuong.Enabled = true;
            txtDienthoai_KhenThuong.Enabled = false;
            dateTimePicker1.Enabled = false;
            txtDiachiKhenThuong.Enabled = false;
           
        }

        private void dataGridViewKhenThuong_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0) // Đảm bảo không click vào tiêu đề cột
            {
                DataGridViewRow row = dataGridViewKhenThuong.Rows[e.RowIndex];

                // Hiển thị dữ liệu vào các ô nhập
                txtMaSVKhenThuong.Text = row.Cells["MaSV"].Value.ToString();
                txtHotenKhenThuong.Text = row.Cells["HoTen"].Value.ToString();
                dateTimePicker1.Value = Convert.ToDateTime(row.Cells["NgaySinh"].Value);
                txtDiachiKhenThuong.Text = row.Cells["DiaChi"].Value.ToString();
                comboBoxGioitinhKhenThuong.Text = row.Cells["GioiTinh"].Value.ToString();
                txtDienthoai_KhenThuong.Text = row.Cells["DienThoai"].Value.ToString();
                comboBoxLop_KhenThuong.SelectedValue = row.Cells["TenLop"].Value.ToString();
                txtLYDOKHENTHUONG_KhenThuong.Text = row.Cells["LyDo"].Value.ToString();

                // Khóa các trường không cho chỉnh sửa
                txtMaSVKhenThuong.Enabled = false;
                txtHotenKhenThuong.Enabled = false;
                dateTimePicker1.Enabled = false;
                txtDiachiKhenThuong.Enabled = false;
                comboBoxGioitinhKhenThuong.Enabled = false;
                txtDienthoai_KhenThuong.Enabled = false;
                comboBoxLop_KhenThuong.Enabled = false;

                // Chỉ mở ô nhập lý do khen thưởng
                txtLYDOKHENTHUONG_KhenThuong.Enabled = true;
            }
        }

        private void btnSua_KhenThuong_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtMaSVKhenThuong.Text.Trim()))
            {
                MessageBox.Show("Vui lòng chọn một sinh viên để sửa!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string maSV = txtMaSVKhenThuong.Text.Trim();
            string lyDoMoi = txtLYDOKHENTHUONG_KhenThuong.Text.Trim();

            if (string.IsNullOrEmpty(lyDoMoi))
            {
                MessageBox.Show("Lý do khen thưởng không được để trống!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                try
                {
                    conn.Open();
                    string updateQuery = "UPDATE KhenThuong SET LyDo = @LyDo WHERE MaSV = @MaSV";
                    using (SqlCommand cmd = new SqlCommand(updateQuery, conn))
                    {
                        cmd.Parameters.AddWithValue("@MaSV", maSV);
                        cmd.Parameters.AddWithValue("@LyDo", lyDoMoi);

                        int result = cmd.ExecuteNonQuery();
                        if (result > 0)
                        {
                            MessageBox.Show("Cập nhật lý do khen thưởng thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            LoadSinhVienKhenThuong(); // Cập nhật lại DataGridView
                        }
                        else
                        {
                            MessageBox.Show("Cập nhật thất bại!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi khi cập nhật dữ liệu: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void btnXoa_KhenThuong_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtMaSVKhenThuong.Text.Trim()))
            {
                MessageBox.Show("Vui lòng chọn sinh viên cần xóa khen thưởng!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string maSV = txtMaSVKhenThuong.Text.Trim();

            DialogResult result = MessageBox.Show("Bạn có chắc chắn muốn xóa khen thưởng của sinh viên này không?",
                                                  "Xác nhận xóa", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    try
                    {
                        conn.Open();
                        string query = "DELETE FROM KhenThuong WHERE MaSV = @MaSV";
                        using (SqlCommand cmd = new SqlCommand(query, conn))
                        {
                            cmd.Parameters.AddWithValue("@MaSV", maSV);
                            int rowsAffected = cmd.ExecuteNonQuery();

                            if (rowsAffected > 0)
                            {
                                MessageBox.Show("Xóa khen thưởng thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                LoadSinhVienKhenThuong(); // Cập nhật lại DataGridView

                                // Reset lại form
                                ResetFormKhenThuong();
                            }
                            else
                            {
                                MessageBox.Show("Không tìm thấy dữ liệu để xóa!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Lỗi khi xóa: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }
        private void ResetFormKhenThuong()
        {
            txtMaSVKhenThuong.Clear();
            txtHotenKhenThuong.Clear();
            dateTimePicker1.Value = DateTime.Now;
            txtDiachiKhenThuong.Clear();
            comboBoxGioitinhKhenThuong.SelectedIndex = -1;
            txtDienthoai_KhenThuong.Clear();
            comboBoxLop_KhenThuong.SelectedIndex = -1;
            txtLYDOKHENTHUONG_KhenThuong.Clear();
        }

        private void btnTimKiem_KhenThuong_Click(object sender, EventArgs e)
        {
            string maSV = txtSearchMaSV_KhenThuong.Text.Trim();
            string hoTen = txtSearchHoten_KhenThuong.Text.Trim();
            string maLop = comboBoxTKlop.SelectedIndex >= 0 ? comboBoxTKlop.SelectedValue.ToString() : "";
           // string lyDo = txtLYDOKHENTHUONG_KhenThuong.Text.Trim(); // Thêm dòng này


            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                try
                {
                    conn.Open();
                    string query = "SELECT kt.MaSV, sv.HoTen, sv.NgaySinh, sv.DiaChi, sv.GioiTinh, sv.DienThoai, sv.MaLop, kt.LyDo " +
                                   "FROM KhenThuong kt " +
                                   "INNER JOIN SinhVien sv ON kt.MaSV = sv.MaSV WHERE 1=1";

                    List<SqlParameter> parameters = new List<SqlParameter>();

                    // Tìm theo Mã SV (Chữ + số, tìm gần đúng)
                    if (!string.IsNullOrEmpty(maSV))
                    {
                        query += " AND kt.MaSV LIKE @MaSV";
                        parameters.Add(new SqlParameter("@MaSV", "%" + maSV + "%"));
                    }

                    // Tìm theo Họ tên (Tìm gần đúng)
                    if (!string.IsNullOrEmpty(hoTen))
                    {
                        query += " AND sv.HoTen LIKE @HoTen";
                        parameters.Add(new SqlParameter("@HoTen", "%" + hoTen + "%"));
                    }

                    // Tìm theo Lớp (Chính xác)
                    if (!string.IsNullOrEmpty(maLop))
                    {
                        query += " AND sv.MaLop = @MaLop";
                        parameters.Add(new SqlParameter("@MaLop", maLop));
                    }
                    // ✅ Thêm điều kiện tìm theo lý do khen thưởng
                    //if (!string.IsNullOrEmpty(lyDo))
                    //{
                    //    query += " AND kt.LyDo LIKE @LyDo";
                    //    parameters.Add(new SqlParameter("@LyDo", "%" + lyDo + "%"));
                    //}
                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        cmd.Parameters.AddRange(parameters.ToArray());

                        SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                        DataTable dt = new DataTable();
                        adapter.Fill(dt);

                        dataGridViewKhenThuong.DataSource = dt;
                        //if (dt.Rows.Count == 0)
                        //{
                        //    MessageBox.Show("Không tìm thấy kết quả!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        //}
                    }

                }
                catch (Exception ex)
                {

                    MessageBox.Show("Lỗi khi tìm kiếm: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
        private void LoadLopToComboBox()
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                try
                {
                    conn.Open();
                    string query = "SELECT MaLop, TenLop FROM Lop"; // Lấy mã lớp & tên lớp
                    SqlDataAdapter adapter = new SqlDataAdapter(query, conn);
                    DataTable dt = new DataTable();
                    adapter.Fill(dt);

                    // Đổ dữ liệu vào ComboBox
                    comboBoxTKlop.DataSource = dt;
                    comboBoxTKlop.DisplayMember = "TenLop";  // Hiển thị tên lớp
                    comboBoxTKlop.ValueMember = "MaLop";  // Lấy giá trị là mã lớp

                    // Tùy chọn trống (cho phép tìm kiếm không cần chọn lớp)
                    comboBoxTKlop.SelectedIndex = -1;
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi khi tải danh sách lớp: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
                for (int i = 0; i < dataGridViewKhenThuong.ColumnCount; i++)
                {
                    application.Cells[1, i + 1] = dataGridViewKhenThuong.Columns[i].HeaderText;
                }

                // Xuất dữ liệu hàng
                for (int i = 0; i < dataGridViewKhenThuong.Rows.Count; i++)
                {
                    for (int j = 0; j < dataGridViewKhenThuong.Columns.Count; j++)
                    {
                        application.Cells[i + 2, j + 1] = dataGridViewKhenThuong.Rows[i].Cells[j].Value?.ToString();
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
