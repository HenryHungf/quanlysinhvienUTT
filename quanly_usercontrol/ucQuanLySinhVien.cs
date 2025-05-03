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
using System.Text.RegularExpressions;
using Excel = Microsoft.Office.Interop.Excel;

namespace quanlysinhvien.quanly_usercontrol
{
    public partial class ucQuanLySinhVien : UserControl
    {
        private ConnectDB db = new ConnectDB();
        public ucQuanLySinhVien()
        {
            InitializeComponent();
            LoadData();
            LoadCbbLop();
            LoadCbbtkLop();
            LoadCbbKhoa();
        }
        private void LoadData()
        {
            dgrsv.Rows.Clear();

            string query = "SELECT * FROM SinhVien";
            using (SqlConnection conn = db.Connect())
            {
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            dgrsv.Rows.Add(reader["MaSV"], reader["HoTen"], reader["NgaySinh"], reader["DiaChi"], reader["GioiTinh"], reader["DienThoai"], reader["MaLop"], reader["MaKhoaHoc"]);
                        }
                    }
                }
            }
        }

        private void ResetText()
        {
            txtmasv.Clear();
            txtht.Clear();
            txtdc.Clear();
            cbbgt.SelectedIndex = -1;
            dtns.Value = DateTime.Now;
            cbblop.SelectedIndex = -1;
            cbbkhoa.SelectedIndex = -1;
            txtdt.Clear();
        }
        private void LoadCbbLop()
        {
            try
            {
                using (SqlConnection conn = db.Connect())
                {
                    string query = "SELECT MaLop, TenLop FROM Lop";
                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        using (SqlDataAdapter da = new SqlDataAdapter(cmd))
                        {
                            DataTable dt = new DataTable();
                            da.Fill(dt);

                            // Gán dữ liệu vào ComboBox
                            cbblop.DataSource = dt;
                            cbblop.DisplayMember = "TenLop"; // Hiển thị tên ngành
                            cbblop.ValueMember = "MaLop";   // Lưu giá trị là mã ngành
                            cbblop.SelectedIndex = -1;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi tải danh sách lớp: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void LoadCbbtkLop()
        {
            try
            {
                using (SqlConnection conn = db.Connect())
                {
                    string query = "SELECT MaLop, TenLop FROM Lop";
                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        using (SqlDataAdapter da = new SqlDataAdapter(cmd))
                        {
                            DataTable dt = new DataTable();
                            da.Fill(dt);

                            // Gán dữ liệu vào ComboBox
                            cbbtklop.DataSource = dt;
                            cbbtklop.DisplayMember = "TenLop"; 
                            cbbtklop.ValueMember = "MaLop";   
                            cbbtklop.SelectedIndex = -1;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi tải danh sách lớp: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void LoadCbbKhoa()
        {
            try
            {
                using (SqlConnection conn = db.Connect())
                {
                    string query = "SELECT MaKhoaHoc FROM KhoaNamHoc";
                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        using (SqlDataAdapter da = new SqlDataAdapter(cmd))
                        {
                            DataTable dt = new DataTable();
                            da.Fill(dt);

                            // Gán dữ liệu vào ComboBox
                            cbbkhoa.DataSource = dt;
                            cbbkhoa.DisplayMember = "MaKhoaHoc";
                            cbbkhoa.ValueMember = "MaKhoaHoc";
                            cbbkhoa.SelectedIndex = -1;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi tải danh sách khóa năm học: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnthem_Click(object sender, EventArgs e)
        {
            using (SqlConnection conn = db.Connect())
            {
                try
                {
                    // Kiểm tra dữ liệu trước khi lưu
                    if (string.IsNullOrWhiteSpace(txtmasv.Text) ||
                        string.IsNullOrWhiteSpace(txtht.Text) ||
                        string.IsNullOrWhiteSpace(txtdc.Text))
                    {
                        MessageBox.Show("Vui lòng nhập đầy đủ thông tin!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }

                    if (txtmasv.Text.Length > 10)
                    {
                        MessageBox.Show("Mã sinh viên không được quá 10 ký tự!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }

                    if (cbbgt.SelectedItem == null || string.IsNullOrEmpty(cbbgt.Text))
                    {
                        MessageBox.Show("Vui lòng chọn giới tính!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }

                    if (cbblop.SelectedItem == null || string.IsNullOrEmpty(cbblop.Text))
                    {
                        MessageBox.Show("Vui lòng chọn lớp!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }

                    if (cbbkhoa.SelectedItem == null || string.IsNullOrEmpty(cbbkhoa.Text))
                    {
                        MessageBox.Show("Vui lòng chọn khóa!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }

                    if (!Regex.IsMatch(txtdt.Text.Trim(), @"^\d{10}$"))
                    {
                        MessageBox.Show("Số điện thoại phải gồm đúng 10 chữ số!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }

                    string checkQuery = "SELECT COUNT(*) FROM SinhVien WHERE MaSV = @MaSV";
                    using (SqlCommand checkCmd = new SqlCommand(checkQuery, conn))
                    {
                        checkCmd.Parameters.AddWithValue("@MaSV", txtmasv.Text.Trim());
                        int count = Convert.ToInt32(checkCmd.ExecuteScalar());

                        if (count > 0)
                        {
                            MessageBox.Show("Mã sinh viên đã tồn tại! Vui lòng nhập mã khác.", "Lỗi trùng khóa",
                                            MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            return;
                        }
                    }

                    string query = "INSERT INTO SinhVien (MaSV, HoTen, NgaySinh, DiaChi, GioiTinh, DienThoai, MaLop, MaKhoaHoc) " +
                                   "VALUES (@MaSV, @HoTen, @NgaySinh, @DiaChi, @GioiTinh, @DienThoai, @MaLop, @MaKhoaHoc)";

                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@MaSV", txtmasv.Text.Trim());
                        cmd.Parameters.AddWithValue("@HoTen", txtht.Text.Trim());
                        cmd.Parameters.AddWithValue("@NgaySinh", dtns.Value.Date);
                        cmd.Parameters.AddWithValue("@GioiTinh", cbbgt.SelectedItem?.ToString() ?? "Không xác định");
                        cmd.Parameters.AddWithValue("@DiaChi", txtdc.Text.Trim());
                        cmd.Parameters.AddWithValue("@DienThoai", txtdc.Text.Trim());
                        cmd.Parameters.AddWithValue("@MaLop", cbblop.SelectedValue?.ToString() ?? "Không xác định");
                        cmd.Parameters.AddWithValue("@MaKhoaHoc", cbbkhoa.SelectedValue?.ToString() ?? "Không xác định");

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

        private void dgrkhoanamhoc_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dgrsv.Rows[e.RowIndex];

                txtmasv.Text = row.Cells["MaSV"].Value.ToString();
                txtht.Text = row.Cells["HoTen"].Value.ToString();
                dtns.Value = Convert.ToDateTime(row.Cells["NgaySinh"].Value);
                txtdc.Text = row.Cells["DiaChi"].Value.ToString();
                cbbgt.Text = row.Cells["GioiTinh"].Value.ToString();
                txtdt.Text = row.Cells["DienThoai"].Value.ToString();
                cbblop.SelectedValue = row.Cells["MaLop"].Value.ToString();
                cbbkhoa.SelectedValue = row.Cells["MaKhoaHoc"].Value.ToString();

                // Vô hiệu hóa mã sinh viên và nút Thêm, Tìm kiếm
                txtmasv.Enabled = false;
                txttkmasv.Enabled = false;
                cbbtklop.Enabled = false;
                btnthem.Enabled = false;
                btntk.Enabled = false;
            }
        }

        private void btnsua_Click(object sender, EventArgs e)
        {
            if (txtmasv.Text == "")
            {
                MessageBox.Show("Vui lòng chọn sinh viên cần sửa!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (string.IsNullOrWhiteSpace(txtht.Text) ||
                string.IsNullOrWhiteSpace(txtdc.Text))
            {
                MessageBox.Show("Vui lòng nhập đầy đủ thông tin!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (txtmasv.Text.Length > 10)
            {
                MessageBox.Show("Mã sinh viên không được quá 10 ký tự!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            //if (cbbgt.SelectedItem == null || string.IsNullOrEmpty(cbbgt.Text))
            //{
            //    MessageBox.Show("Vui lòng chọn giới tính!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            //    return;
            //}

            if (cbblop.SelectedItem == null || string.IsNullOrEmpty(cbblop.Text))
            {
                MessageBox.Show("Vui lòng chọn lớp!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (cbbkhoa.SelectedItem == null || string.IsNullOrEmpty(cbbkhoa.Text))
            {
                MessageBox.Show("Vui lòng chọn khóa!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (!Regex.IsMatch(txtdt.Text.Trim(), @"^\d{10}$"))
            {
                MessageBox.Show("Số điện thoại phải gồm đúng 10 chữ số!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                using (SqlConnection conn = db.Connect())
                {
                    string query = "UPDATE SinhVien SET HoTen=@HoTen, NgaySinh=@NgaySinh, DiaChi=@DiaChi, GioiTinh=@GioiTinh, DienThoai=@DienThoai, MaLop=@MaLop, MaKhoaHoc=@MaKhoaHoc WHERE MaSV=@MaSV";

                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@MaSV", txtmasv.Text);
                        cmd.Parameters.AddWithValue("@HoTen", txtht.Text);
                        cmd.Parameters.AddWithValue("@NgaySinh", dtns.Value);
                        cmd.Parameters.AddWithValue("@GioiTinh", cbbgt.SelectedItem.ToString());
                        cmd.Parameters.AddWithValue("@DiaChi", txtdc.Text);
                        cmd.Parameters.AddWithValue("@DienThoai", txtdt.Text);
                        cmd.Parameters.AddWithValue("@MaLop", cbblop.SelectedValue.ToString());
                        cmd.Parameters.AddWithValue("@MaKhoaHoc", cbbkhoa.SelectedValue.ToString());
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
            if (string.IsNullOrEmpty(txtmasv.Text))
            {
                MessageBox.Show("Vui lòng chọn sinh viên cần xóa!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
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
                    string query = "DELETE FROM SinhVien WHERE MaSV = @MaSV";
                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@MaSV", txtmasv.Text);
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
            dgrsv.Rows.Clear();

            string MaSv = txttkmasv.Text.Trim();
            string Lop = cbbtklop.SelectedValue != null ? cbbtklop.SelectedValue.ToString() : "";

            if (string.IsNullOrEmpty(MaSv) && (string.IsNullOrEmpty(Lop) || Lop == "Chọn Lớp"))
            {
                MessageBox.Show("Vui lòng nhập mã sinh viên hoặc chọn lớp để tìm kiếm!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            using (SqlConnection conn = db.Connect())
            {
                try
                {
                    
                    string query = "SELECT * FROM SinhVien WHERE 1=1";

                    if (!string.IsNullOrEmpty(MaSv))
                        query += " AND MaSV LIKE @MaSV";

                    if (!string.IsNullOrEmpty(Lop) && Lop != "Chọn Lớp")
                        query += " AND MaLop = @MaLop";

                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        if (!string.IsNullOrEmpty(MaSv))
                            cmd.Parameters.AddWithValue("@MaSV", "%" + MaSv + "%");

                        if (!string.IsNullOrEmpty(Lop) && Lop != "Chọn lớp")
                            cmd.Parameters.AddWithValue("@MaLop", Lop);

                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                dgrsv.Rows.Add(reader["MaSV"], reader["HoTen"], reader["NgaySinh"], reader["DiaChi"], reader["GioiTinh"], reader["DienThoai"], reader["MaLop"], reader["MaKhoaHoc"]);
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
                for (int i = 0; i < dgrsv.ColumnCount; i++)
                {
                    application.Cells[1, i + 1] = dgrsv.Columns[i].HeaderText;
                }

                // Xuất dữ liệu hàng
                for (int i = 0; i < dgrsv.Rows.Count; i++)
                {
                    for (int j = 0; j < dgrsv.Columns.Count; j++)
                    {
                        application.Cells[i + 2, j + 1] = dgrsv.Rows[i].Cells[j].Value?.ToString();
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

        private void ucQuanLySinhVien_Load(object sender, EventArgs e)
        {

        }
    }
}