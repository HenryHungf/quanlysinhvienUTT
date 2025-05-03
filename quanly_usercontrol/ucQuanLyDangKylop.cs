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
    public partial class ucQuanLyDangKylop : UserControl
         

    {
        string connectionString = "Data Source=hungf;Initial Catalog=CS_QuanLySinhVien12;Integrated Security=True ";
        public ucQuanLyDangKylop()
        {
            InitializeComponent();
        }

        private void label10_Click(object sender, EventArgs e)
        {

        }

        private void ucQuanLyDangKylop_Load(object sender, EventArgs e)
        {
            LoadData();       // Hiển thị danh sách sinh viên lên DataGridView
            LoadComboBoxLop(); // Hiển thị danh sách lớp lên ComboBox
            comboBoxLop_DKlop.Text = "-- Chọn Lớp --"; // 
        }
        private void LoadData()
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
               
                {
                    try
                    {
                        conn.Open();
                        string query = "SELECT MaSV, HoTen, NgaySinh, GioiTinh, DienThoai, MaLop FROM SinhVien " +
                            "";
                        SqlDataAdapter da = new SqlDataAdapter(query, conn);
                        DataTable dt = new DataTable();
                        da.Fill(dt);
                        dataGridViewDangkylop.DataSource = dt;
                        dataGridViewDangkylop.Columns["MaSV"].HeaderText = "Mã SV";
                        dataGridViewDangkylop.Columns["HoTen"].HeaderText = "Họ Tên";
                        dataGridViewDangkylop.Columns["NgaySinh"].HeaderText = "Ngày Sinh";
                        dataGridViewDangkylop.Columns["GioiTinh"].HeaderText = "Giới Tính";
                        dataGridViewDangkylop.Columns["DienThoai"].HeaderText = "SĐT";
                        dataGridViewDangkylop.Columns["MaLop"].HeaderText = "Mã Lớp";

                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Lỗi khi tải dữ liệu: " + ex.Message);
                    }
                }
            }
        }
        // Where MaLop ='CNTT'
        // "WHERE MaLop = 'CNTT' AND GioiTinh = 'Nam'";
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

                    comboBoxLop_DKlop.DataSource = dt;
                    comboBoxLop_DKlop.DisplayMember = "TenLop"; // Hiển thị tên lớp
                    comboBoxLop_DKlop.ValueMember = "MaLop"; // Giá trị là mã lớp
                    comboBoxLop_DKlop.SelectedIndex = -1; // Không chọn mặc định
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi khi tải danh sách lớp: " + ex.Message);
                }
            }

        }

        private void comboBoxLop_DKlop_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void btnThem_DKlop_Click(object sender, EventArgs e)
        {
            // Lấy dữ liệu từ các control
            string maSV = txtMaSV_DKlop.Text.Trim();
            string hoTen = txtHoten_DKlop.Text.Trim();
            DateTime ngaySinh = dateTimePicker1.Value;
            string gioiTinh = comboBoxGioitinh_DKlop.Text.Trim();
            string dienThoai = txtDienthoai_DKlop.Text.Trim();
            string maLop = comboBoxLop_DKlop.SelectedValue?.ToString(); // Lấy giá trị MaLop từ ComboBox

            // Kiểm tra các trường không được để trống
            if (string.IsNullOrEmpty(maSV) || string.IsNullOrEmpty(hoTen) || string.IsNullOrEmpty(dienThoai) || string.IsNullOrEmpty(maLop))
            {
                MessageBox.Show("Vui lòng nhập đầy đủ thông tin!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Kiểm tra số điện thoại: chỉ chứa số, có 10 ký tự, bắt đầu bằng số 0
            if (!System.Text.RegularExpressions.Regex.IsMatch(dienThoai, @"^0\d{0,9}$"))
            {
                MessageBox.Show("Số điện thoại không hợp lệ! Phải bắt đầu bằng số 0 và tối đa 10 số.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                try
                {
                    conn.Open();

                    // Kiểm tra mã sinh viên đã tồn tại chưa
                    string checkQuery = "SELECT COUNT(*) FROM SinhVien WHERE MaSV = @MaSV";
                    using (SqlCommand checkCmd = new SqlCommand(checkQuery, conn))
                    {
                        checkCmd.Parameters.AddWithValue("@MaSV", maSV);
                        int exists = (int)checkCmd.ExecuteScalar();
                        if (exists > 0)
                        {
                            MessageBox.Show("Mã sinh viên đã tồn tại!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return;
                        }
                    }

                    // Nếu không trùng, thực hiện thêm sinh viên
                    string insertQuery = @"
                INSERT INTO SinhVien (MaSV, HoTen, NgaySinh, GioiTinh, DienThoai, MaLop)
                VALUES (@MaSV, @HoTen, @NgaySinh, @GioiTinh, @DienThoai, @MaLop)";

                    using (SqlCommand cmd = new SqlCommand(insertQuery, conn))
                    {
                        cmd.Parameters.AddWithValue("@MaSV", maSV);
                        cmd.Parameters.AddWithValue("@HoTen", hoTen);
                        cmd.Parameters.AddWithValue("@NgaySinh", ngaySinh);
                        cmd.Parameters.AddWithValue("@GioiTinh", gioiTinh);
                        cmd.Parameters.AddWithValue("@DienThoai", dienThoai);
                        cmd.Parameters.AddWithValue("@MaLop", maLop);

                        cmd.ExecuteNonQuery();
                        MessageBox.Show("Thêm sinh viên thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);

                        // Sau khi thêm, tải lại dữ liệu
                        LoadData();
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi khi thêm sinh viên: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void dataGridViewDangkylop_CellClick(object sender, DataGridViewCellEventArgs e)
        {


            // Kiểm tra nếu người dùng click vào dòng hợp lệ
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dataGridViewDangkylop.Rows[e.RowIndex];

                // Hiển thị dữ liệu lên các TextBox và ComboBox
                txtMaSV_DKlop.Text = row.Cells["MaSV"].Value.ToString();
                txtHoten_DKlop.Text = row.Cells["HoTen"].Value.ToString();
                dateTimePicker1.Value = Convert.ToDateTime(row.Cells["NgaySinh"].Value);
                comboBoxGioitinh_DKlop.Text = row.Cells["GioiTinh"].Value.ToString();
                txtDienthoai_DKlop.Text = row.Cells["DienThoai"].Value.ToString();
                comboBoxLop_DKlop.SelectedValue = row.Cells["MaLop"].Value.ToString();

                // Kích hoạt nút Sửa
                btnSua_DKlop.Enabled = true;
                txtMaSV_DKlop.Enabled = false;
                btnThem_DKlop.Enabled = false;
                btnTimKiem_DKlop.Enabled = false;
                
            }
        }

        private void btnSua_DKlop_Click(object sender, EventArgs e)
        {
            // Lấy dữ liệu từ các control
            string maSV = txtMaSV_DKlop.Text.Trim();
            string hoTen = txtHoten_DKlop.Text.Trim();
            DateTime ngaySinh = dateTimePicker1.Value;
            string gioiTinh = comboBoxGioitinh_DKlop.Text.Trim();
            string dienThoai = txtDienthoai_DKlop.Text.Trim();
            string maLop = comboBoxLop_DKlop.SelectedValue?.ToString();

            // Kiểm tra không để trống dữ liệu
            if (string.IsNullOrEmpty(maSV) || string.IsNullOrEmpty(hoTen) || string.IsNullOrEmpty(dienThoai) || string.IsNullOrEmpty(maLop))
            {
                MessageBox.Show("Vui lòng nhập đầy đủ thông tin!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Kiểm tra số điện thoại hợp lệ (chỉ số, bắt đầu bằng 0, 10 ký tự)
            if (!System.Text.RegularExpressions.Regex.IsMatch(dienThoai, @"^0\d{0,9}$"))
            {
                MessageBox.Show("Số điện thoại không hợp lệ! Phải bắt đầu bằng số 0 và tối đa 10 số.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                try
                {
                    conn.Open();

                    // Cập nhật thông tin sinh viên
                    string updateQuery = @"
                UPDATE SinhVien
                SET HoTen = @HoTen, NgaySinh = @NgaySinh, GioiTinh = @GioiTinh, 
                    DienThoai = @DienThoai, MaLop = @MaLop
                WHERE MaSV = @MaSV";

                    using (SqlCommand cmd = new SqlCommand(updateQuery, conn))
                    {
                        cmd.Parameters.AddWithValue("@MaSV", maSV);
                        cmd.Parameters.AddWithValue("@HoTen", hoTen);
                        cmd.Parameters.AddWithValue("@NgaySinh", ngaySinh);
                        cmd.Parameters.AddWithValue("@GioiTinh", gioiTinh);
                        cmd.Parameters.AddWithValue("@DienThoai", dienThoai);
                        cmd.Parameters.AddWithValue("@MaLop", maLop);

                        int rowsAffected = cmd.ExecuteNonQuery();
                        if (rowsAffected > 0)
                        {
                            MessageBox.Show("Cập nhật thông tin thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            LoadData(); // Cập nhật lại DataGridView
                        }
                        else
                        {
                            MessageBox.Show("Không tìm thấy sinh viên để cập nhật!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi khi cập nhật: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void btnTimKiem_DKlop_Click(object sender, EventArgs e)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                try
                {
                    conn.Open();
                    string query = "SELECT MaSV, HoTen, NgaySinh, GioiTinh, DienThoai, MaLop FROM SinhVien WHERE 1=1";

                    // Danh sách tham số
                    List<SqlParameter> parameters = new List<SqlParameter>();

                    // Nếu chọn lớp
                    if (comboBoxLop_DKlop.SelectedIndex != -1)
                    {
                        query += " AND MaLop = @MaLop";
                        parameters.Add(new SqlParameter("@MaLop", comboBoxLop_DKlop.SelectedValue));
                    }

                    // Nếu nhập Mã SV
                    if (!string.IsNullOrWhiteSpace(txtMaSV_DKlop.Text))
                    {
                        query += " AND MaSV LIKE @MaSV";
                        parameters.Add(new SqlParameter("@MaSV", "%" + txtMaSV_DKlop.Text.Trim() + "%"));
                    }

                    // Nếu nhập Họ tên
                    if (!string.IsNullOrWhiteSpace(txtHoten_DKlop.Text))
                    {
                        query += " AND HoTen LIKE @HoTen";
                        parameters.Add(new SqlParameter("@HoTen", "%" + txtHoten_DKlop.Text.Trim() + "%"));
                    }
                    //// Nếu nhập số điện thoại
                    //if (!string.IsNullOrWhiteSpace(txtDienthoai_DKlop.Text))
                    //{
                    //    query += " AND DienThoai LIKE @DienThoai";
                    //    parameters.Add(new SqlParameter("@DienThoai", "%" + txtDienthoai_DKlop.Text.Trim() + "%"));
                    //}

                    //// Nếu chọn ngày sinh
                    //DateTime selectedDate = dateTimePicker1.Value.Date;
                    //if (dateTimePicker1.Checked) // Nếu bạn dùng CheckBox để kích hoạt tìm theo ngày sinh
                    //{
                    //    query += " AND NgaySinh = @NgaySinh";
                    //    parameters.Add(new SqlParameter("@NgaySinh", selectedDate));
                    //}
                    // Nếu chọn Giới tính
                    if (comboBoxGioitinh_DKlop.SelectedIndex != -1)
                    {
                        query += " AND GioiTinh = @GioiTinh";
                        parameters.Add(new SqlParameter("@GioiTinh", comboBoxGioitinh_DKlop.SelectedItem.ToString()));
                    }

                    SqlCommand cmd = new SqlCommand(query, conn);
                    cmd.Parameters.AddRange(parameters.ToArray());

                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    DataTable dt = new DataTable();
                    da.Fill(dt);

                    // Hiển thị dữ liệu lên DataGridView
                    dataGridViewDangkylop.DataSource = dt;

                    // Nếu không có kết quả, thông báo
                    if (dt.Rows.Count == 0)
                    {
                        MessageBox.Show("Không tìm thấy kết quả!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
                for (int i = 0; i < dataGridViewDangkylop.ColumnCount; i++)
                {
                    application.Cells[1, i + 1] = dataGridViewDangkylop.Columns[i].HeaderText;
                }

                // Xuất dữ liệu hàng
                for (int i = 0; i < dataGridViewDangkylop.Rows.Count; i++)
                {
                    for (int j = 0; j < dataGridViewDangkylop.Columns.Count; j++)
                    {
                        application.Cells[i + 2, j + 1] = dataGridViewDangkylop.Rows[i].Cells[j].Value?.ToString();
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

        private void btnXoa_DKlop_Click(object sender, EventArgs e)
        {

            // Lấy mã sinh viên cần xóa
            string maSV = txtMaSV_DKlop.Text.Trim();

            // Kiểm tra xem người dùng đã chọn sinh viên hay chưa
            if (string.IsNullOrEmpty(maSV))
            {
                MessageBox.Show("Vui lòng chọn sinh viên cần xóa!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Xác nhận xóa
            DialogResult result = MessageBox.Show("Bạn có chắc chắn muốn xóa sinh viên này?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.No)
            {
                return;
            }

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                try
                {
                    conn.Open();
                    //

                    //// Xóa bản ghi liên quan trong bảng KhenThuong trước
                    //string deleteKhenThuongQuery = "DELETE FROM KhenThuong WHERE MaSV = @MaSV";
                    //using (SqlCommand cmdKhenThuong = new SqlCommand(deleteKhenThuongQuery, conn))
                    //{
                    //    cmdKhenThuong.Parameters.AddWithValue("@MaSV", maSV);
                    //    cmdKhenThuong.ExecuteNonQuery();
                    //}

                    //// xóa điểm
                    //string deleteDiemQuery = "DELETE FROM Diem WHERE MaSV = @MaSV";
                    //using (SqlCommand cmdDiem = new SqlCommand(deleteDiemQuery, conn))
                    //{
                    //    cmdDiem.Parameters.AddWithValue("@MaSV", maSV);
                    //   cmdDiem.ExecuteNonQuery();
                    //}

                    ////xóa học lại
                    //string deleteHocLaiQuery = "DELETE FROM HocLai WHERE MaSV = @MaSV";
                    //using (SqlCommand cmdHocLai = new SqlCommand(deleteHocLaiQuery, conn))
                    //{
                    //    cmdHocLai.Parameters.AddWithValue("@MaSV", maSV);
                    //    cmdHocLai.ExecuteNonQuery();
                    //}
                    //// xóa thi lại
                    //string deleteThiLaiQuery = "DELETE FROM ThiLai WHERE MaSV = @MaSV";
                    //using (SqlCommand cmdThiLai = new SqlCommand(deleteThiLaiQuery, conn))
                    //{
                    //    cmdThiLai.Parameters.AddWithValue("@MaSV", maSV);
                    //    cmdThiLai.ExecuteNonQuery();
                    //}
                    //// xóa kỷ luật
                    //string deleteKyLuatQuery = "DELETE FROM KyLuat WHERE MaSV = @MaSV";
                    //using (SqlCommand cmdKyLuat = new SqlCommand(deleteKyLuatQuery, conn))
                    //{
                    //    cmdKyLuat.Parameters.AddWithValue("@MaSV", maSV);
                    //    cmdKyLuat.ExecuteNonQuery();
                    //}

                    ////xóa bảo lưu
                    //string deleteBaoLuuQuery = "DELETE FROM BaoLuu WHERE MaSV = @MaSV";
                    //using (SqlCommand cmdBaoLuu = new SqlCommand(deleteBaoLuuQuery, conn))
                    //{
                    //    cmdBaoLuu.Parameters.AddWithValue("@MaSV", maSV);
                    //    cmdBaoLuu.ExecuteNonQuery();
                    //}
                    ////học bổng
                    //string deleteHocBongQuery = "DELETE FROM HocBong WHERE MaSV = @MaSV";
                    //using (SqlCommand cmdHocBong = new SqlCommand(deleteHocBongQuery, conn))
                    //{
                    //    cmdHocBong.Parameters.AddWithValue("@MaSV", maSV);
                    //    cmdHocBong.ExecuteNonQuery();
                    //}

                    //
                    
                    // 2. Xóa bản ghi liên quan trong bảng DangKyLop
                    string deleteDangKyLop = "DELETE FROM DangKyLop WHERE MaSV = @MaSV";
                    using (SqlCommand cmd = new SqlCommand(deleteDangKyLop, conn))
                    {
                        cmd.Parameters.AddWithValue("@MaSV", maSV);
                        cmd.ExecuteNonQuery();
                    }


                    // sau đó mới xóa sinh viên 
                    string deleteQuery = "DELETE FROM SinhVien WHERE MaSV = @MaSV";

                    using (SqlCommand cmd = new SqlCommand(deleteQuery, conn))
                    {
                        cmd.Parameters.AddWithValue("@MaSV", maSV);

                        int rowsAffected = cmd.ExecuteNonQuery();
                        if (rowsAffected > 0)
                        {
                            MessageBox.Show("Xóa sinh viên thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            LoadData(); // Tải lại dữ liệu sau khi xóa

                            // Reset form
                            txtMaSV_DKlop.Clear();
                            txtHoten_DKlop.Clear();
                            txtDienthoai_DKlop.Clear();
                            comboBoxGioitinh_DKlop.SelectedIndex = -1;
                            comboBoxLop_DKlop.SelectedIndex = -1;
                            dateTimePicker1.Value = DateTime.Now;

                            btnThem_DKlop.Enabled = true;
                            btnSua_DKlop.Enabled = false;
                            txtMaSV_DKlop.Enabled = true;
                            btnTimKiem_DKlop.Enabled = true;
                        }
                        else
                        {
                            MessageBox.Show("Không tìm thấy sinh viên để xóa!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi khi xóa sinh viên: Vì Sinh viên trong danh sách Khen Thưởng hoặc có Điểm trong hệ thống " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
    }
}
