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

namespace quanlysinhvien.quanly_usercontrol
{
    public partial class ucQuanLyKhoaNamHoc: UserControl
    {
        private ConnectDB db = new ConnectDB();
        public ucQuanLyKhoaNamHoc()
        {
            InitializeComponent();
            LoadData();
        }

        private void LoadData()
        {
            dgrkhoanamhoc.Rows.Clear();

            string query = "SELECT * FROM KhoaNamHoc";
            using (SqlConnection conn = db.Connect())
            {
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            dgrkhoanamhoc.Rows.Add(reader["MaKhoaHoc"], reader["NamBatDau"], reader["NamKetThuc"]);
                        }
                    }
                }
            }
        }

        private void ResetText()
        {
            txtmakh.Clear();
            txtnambd.Clear();
            txtnamkt.Clear();
        }

        private void btnthem_Click(object sender, EventArgs e)
        {
            using (SqlConnection conn = db.Connect())
            {
                try
                {
                    // Kiểm tra dữ liệu trước khi lưu
                    if (string.IsNullOrWhiteSpace(txtmakh.Text) ||
                        string.IsNullOrWhiteSpace(txtnambd.Text) ||
                        string.IsNullOrWhiteSpace(txtnamkt.Text))
                    {
                        MessageBox.Show("Vui lòng nhập đầy đủ thông tin!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }

                    if (txtmakh.Text.Length > 10)
                    {
                        MessageBox.Show("Mã khóa học không được quá 10 ký tự!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }

                    // Kiểm tra năm bắt đầu và năm kết thúc có phải là số hay không
                    if (!int.TryParse(txtnambd.Text.Trim(), out int namBD) || !int.TryParse(txtnamkt.Text.Trim(), out int namKT))
                    {
                        MessageBox.Show("Năm bắt đầu và năm kết thúc phải là số!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }

                    // Kiểm tra hợp lệ về khoảng năm
                    if (namBD < 1990 || namKT < 1990 || namKT < namBD)
                    {
                        MessageBox.Show("Vui lòng nhập năm hợp lệ! Năm kết thúc phải lớn hơn hoặc bằng năm bắt đầu.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }

                    string checkQuery = "SELECT COUNT(*) FROM KhoaNamHoc WHERE MaKhoaHoc = @MaKhoaHoc";
                    using (SqlCommand checkCmd = new SqlCommand(checkQuery, conn))
                    {
                        checkCmd.Parameters.AddWithValue("@MaKhoaHoc", txtmakh.Text.Trim());
                        int count = Convert.ToInt32(checkCmd.ExecuteScalar());

                        if (count > 0)
                        {
                            MessageBox.Show("Mã khóa năm học đã tồn tại! Vui lòng nhập mã khác.", "Lỗi trùng khóa",
                                            MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            return;
                        }
                    }

                    string query = "INSERT INTO KhoaNamHoc (MaKhoaHoc, NamBatDau, NamKetThuc) " +
                                   "VALUES (@MaKhoaHoc, @NamBatDau, @NamKetThuc)";

                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@MaKhoaHoc", txtmakh.Text.Trim());
                        cmd.Parameters.AddWithValue("@NamBatDau", txtnambd.Text.Trim());
                        cmd.Parameters.AddWithValue("@NamKetThuc", txtnamkt.Text.Trim());
                        
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
                DataGridViewRow row = dgrkhoanamhoc.Rows[e.RowIndex];

                txtmakh.Text = row.Cells["MaKhoaHoc"].Value.ToString();
                txtnambd.Text = row.Cells["NamBatDau"].Value.ToString();
                txtnamkt.Text = row.Cells["NamKetThuc"].Value.ToString();

                // Vô hiệu hóa mã sinh viên và nút Thêm, Tìm kiếm
                txtmakh.Enabled = false;
                txttkkh.Enabled = false;
                btnthem.Enabled = false;
                btntk.Enabled = false;
            }
        }

        private void btnsua_Click(object sender, EventArgs e)
        {
            if (txtmakh.Text == "")
            {
                MessageBox.Show("Vui lòng chọn mã khóa học cần sửa!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Kiểm tra năm bắt đầu và năm kết thúc có phải là số hay không
            if (!int.TryParse(txtnambd.Text.Trim(), out int namBD) || !int.TryParse(txtnamkt.Text.Trim(), out int namKT))
            {
                MessageBox.Show("Năm bắt đầu và năm kết thúc phải là số!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Kiểm tra hợp lệ về khoảng năm
            if (namBD < 3000 || namKT < 3000 || namKT < namBD)
            {
                MessageBox.Show("Vui lòng nhập năm hợp lệ! Năm kết thúc phải lớn hơn hoặc bằng năm bắt đầu.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                using (SqlConnection conn = db.Connect())
                {
                    string query = "UPDATE KhoaNamHoc SET NamBatDau=@NamBatDau, NamKetThuc=@NamKetThuc WHERE MaKhoaHoc=@MaKhoaHoc";

                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@MaKhoaHoc", txtmakh.Text.Trim());
                        cmd.Parameters.AddWithValue("@NamBatDau", txtnambd.Text.Trim());
                        cmd.Parameters.AddWithValue("@NamKetThuc", txtnamkt.Text.Trim());
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
            if (string.IsNullOrEmpty(txtmakh.Text))
            {
                MessageBox.Show("Vui lòng chọn khóa năm học cần xóa!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Xác nhận trước khi xóa
            DialogResult result = MessageBox.Show("Bạn có chắc chắn muốn xóa khóa năm học này?", "Xác nhận xóa", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.No)
            {
                return;
            }

            try
            {
                using (SqlConnection conn = db.Connect())
                {
                    // Câu lệnh DELETE
                    string query = "DELETE FROM KhoaNamHoc WHERE MaKhoaHoc = @MaKhoaHoc";
                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@MaKhoaHoc", txtmakh.Text);
                        int rowsAffected = cmd.ExecuteNonQuery();

                        if (rowsAffected > 0)
                        {
                            MessageBox.Show("Xóa khóa năm học thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            LoadData();
                        }
                        else
                        {
                            MessageBox.Show("Không tìm thấy khóa năm học để xóa!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi xóa khóa năm học: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btntk_Click(object sender, EventArgs e)
        {
            dgrkhoanamhoc.Rows.Clear();

            if (string.IsNullOrEmpty(txtmakh.Text))
            {
                MessageBox.Show("Vui lòng chọn khóa năm học cần tìm kiếm!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            using (SqlConnection conn = db.Connect())
            {
                try
                {
                    string MaKhoaHoc = txttkkh.Text.Trim();

                    string query = "SELECT * FROM KhoaNamHoc WHERE 1=1";

                    if (!string.IsNullOrEmpty(MaKhoaHoc))
                        query += " AND MaKhoaHoc LIKE @MaKhoaHoc";

                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        if (!string.IsNullOrEmpty(MaKhoaHoc))
                            cmd.Parameters.AddWithValue("@MaKhoaHoc", "%" + MaKhoaHoc + "%");


                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                dgrkhoanamhoc.Rows.Add(reader["MaKhoaHoc"], reader["NamBatDau"], reader["NamKetThuc"]);
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

        private void ucQuanLyKhoaNamHoc_Load(object sender, EventArgs e)
        {

        }
    }
}
