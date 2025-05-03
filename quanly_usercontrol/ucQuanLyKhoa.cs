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

namespace quanlysinhvien.quanly_usercontrol
{
    public partial class ucQuanLyKhoa: UserControl
    {
        private ConnectDB db = new ConnectDB();
        public ucQuanLyKhoa()
        {
            InitializeComponent();
            LoadData();
        }

        private void LoadData()
        {
            dgrKhoa.Rows.Clear();

            string query = "SELECT * FROM Khoa";
            using (SqlConnection conn = db.Connect())
            {
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            dgrKhoa.Rows.Add(reader["MaKhoa"], reader["TenKhoa"]);
                        }
                    }
                }
            }
        }

        private void ResetText()
        {
            txtmakh.Clear();
            txttenkh.Clear();
        }

        private void btnthem_Click(object sender, EventArgs e)
        {
            using (SqlConnection conn = db.Connect())
            {
                try
                {
                    // Kiểm tra dữ liệu trước khi lưu
                    if (string.IsNullOrWhiteSpace(txtmakh.Text) ||
                        string.IsNullOrWhiteSpace(txttenkh.Text))
                    {
                        MessageBox.Show("Vui lòng nhập đầy đủ thông tin!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }

                    if (txtmakh.Text.Length > 10)
                    {
                        MessageBox.Show("Mã khoa không được quá 10 ký tự!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }

                    string checkQuery = "SELECT COUNT(*) FROM Khoa WHERE MaKhoa = @MaKhoa";
                    using (SqlCommand checkCmd = new SqlCommand(checkQuery, conn))
                    {
                        checkCmd.Parameters.AddWithValue("@MaKhoa", txtmakh.Text.Trim());
                        int count = Convert.ToInt32(checkCmd.ExecuteScalar());

                        if (count > 0)
                        {
                            MessageBox.Show("Mã khoa đã tồn tại! Vui lòng nhập mã khác.", "Lỗi trùng khóa",
                                            MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            return;
                        }
                    }

                    string query = "INSERT INTO Khoa (MaKhoa, TenKhoa) " +
                                   "VALUES (@MaKhoa, @TenKhoa)";

                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@MaKhoa", txtmakh.Text.Trim());
                        cmd.Parameters.AddWithValue("@TenKhoa", txttenkh.Text.Trim());
                        
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

        private void dgrKhoa_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dgrKhoa.Rows[e.RowIndex];

                txtmakh.Text = row.Cells["MaKhoa"].Value.ToString();
                txttenkh.Text = row.Cells["TenKhoa"].Value.ToString();
            }
        }

        private void btnsua_Click(object sender, EventArgs e)
        {
            if (txtmakh.Text == "")
            {
                MessageBox.Show("Vui lòng chọn mã khoa cần sửa!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                using (SqlConnection conn = db.Connect())
                {
                    string query = "UPDATE Khoa SET TenKhoa=@TenKhoa WHERE MaKhoa=@MaKhoa";

                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@MaKhoa", txtmakh.Text.Trim());
                        cmd.Parameters.AddWithValue("@TenKhoa", txttenkh.Text.Trim());
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
                MessageBox.Show("Vui lòng chọn khoa cần xóa!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Xác nhận trước khi xóa
            DialogResult result = MessageBox.Show("Bạn có chắc chắn muốn xóa khoa này?", "Xác nhận xóa", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.No)
            {
                return;
            }

            try
            {
                using (SqlConnection conn = db.Connect())
                {
                    // Câu lệnh DELETE
                    string query = "DELETE FROM Khoa WHERE MaKhoa = @MaKhoa";
                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@MaKhoa", txtmakh.Text);
                        int rowsAffected = cmd.ExecuteNonQuery();

                        if (rowsAffected > 0)
                        {
                            MessageBox.Show("Xóa khoa thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            LoadData();
                        }
                        else
                        {
                            MessageBox.Show("Không tìm thấy khoa để xóa!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
            dgrKhoa.Rows.Clear();

            if (string.IsNullOrEmpty(txtmakh.Text))
            {
                MessageBox.Show("Vui lòng chọn khoa cần tìm kiếm!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            using (SqlConnection conn = db.Connect())
            {
                try
                {
                    string MaKhoa = txttkmakh.Text.Trim();
                    string TenKhoa = txttktenkh.Text.Trim();

                    string query = "SELECT * FROM Khoa WHERE 1=1";

                    if (!string.IsNullOrEmpty(MaKhoa))
                        query += " AND MaKhoa LIKE @MaKhoa";
                    if (!string.IsNullOrEmpty(TenKhoa))
                        query += " AND TenKhoa LIKE @TenKhoa";

                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        if (!string.IsNullOrEmpty(MaKhoa))
                            cmd.Parameters.AddWithValue("@MaKhoa", "%" + MaKhoa + "%");
                        if (!string.IsNullOrEmpty(TenKhoa))
                            cmd.Parameters.AddWithValue("@TenKhoa", "%" + TenKhoa + "%");


                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                dgrKhoa.Rows.Add(reader["MaKhoa"], reader["TenKhoa"]);
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

        private void ucQuanLyKhoa_Load(object sender, EventArgs e)
        {

        }
    }
}
