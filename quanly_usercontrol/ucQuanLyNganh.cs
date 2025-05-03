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
    public partial class ucQuanLyNganh : UserControl
    {
        string connectionString = "Data Source=hungf;Initial Catalog=CS_QuanLySinhVien12;Integrated Security=True";
        // Biến toàn cục
        SqlConnection conn;
        SqlDataAdapter da;
        DataTable dt;
        public ucQuanLyNganh()
        {
            InitializeComponent();
        }

        private void ucQuanLyNganh_Load(object sender, EventArgs e)
        {
            conn = new SqlConnection(connectionString);
            LoadData();
          
        }
        private void LoadData()
        {
            try
            {
                string query = "SELECT * FROM Nganh";
                da = new SqlDataAdapter(query, conn);
                dt = new DataTable();
                da.Fill(dt);
                dataGridView_Nganh.DataSource = dt;
                dataGridView_Nganh.Columns["MaNganh"].HeaderText = "Mã Ngành";
                dataGridView_Nganh.Columns["TenNganh"].HeaderText = "Tên Ngành";
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message);
            }
        }
        // Where MaLop ='CNTT'
        // "WHERE MaLop = 'CNTT' AND GioiTinh = 'Nam'";

        private void btnThem_Nganh_Click(object sender, EventArgs e)
        {
            string maNganh = txtMaNganh.Text.Trim();
            string tenNganh = txt_tenNganh.Text.Trim();

            // Kiểm tra rỗng
            if (string.IsNullOrEmpty(maNganh) || string.IsNullOrEmpty(tenNganh))
            {
                MessageBox.Show("Vui lòng nhập đầy đủ thông tin mã ngành và tên ngành.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                conn.Open();

                // Kiểm tra trùng mã ngành
                string checkQuery = "SELECT COUNT(*) FROM Nganh WHERE MaNganh = @MaNganh";
                SqlCommand checkCmd = new SqlCommand(checkQuery, conn);
                checkCmd.Parameters.AddWithValue("@MaNganh", maNganh);
                int count = (int)checkCmd.ExecuteScalar();

                if (count > 0)
                {
                    MessageBox.Show("Mã ngành đã tồn tại. Vui lòng nhập mã khác.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                // Thêm ngành mới
                string insertQuery = "INSERT INTO Nganh (MaNganh, TenNganh) VALUES (@MaNganh, @TenNganh)";
                SqlCommand insertCmd = new SqlCommand(insertQuery, conn);
                insertCmd.Parameters.AddWithValue("@MaNganh", maNganh);
                insertCmd.Parameters.AddWithValue("@TenNganh", tenNganh);
                int rowsAffected = insertCmd.ExecuteNonQuery();

                if (rowsAffected > 0)
                {
                    MessageBox.Show("Thêm ngành thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LoadData(); // Cập nhật lại DataGridView
                    txtMaNganh.Clear();
                    txt_tenNganh.Clear();
                }
                else
                {
                    MessageBox.Show("Thêm ngành thất bại.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                conn.Close();
            }

        }

        private void btnSua_Nganh_Click(object sender, EventArgs e)
        {
            string maNganh = txtMaNganh.Text.Trim();
            string tenNganh = txt_tenNganh.Text.Trim();

            // Kiểm tra rỗng
            if (string.IsNullOrEmpty(tenNganh))
            {
                MessageBox.Show("Vui lòng nhập tên ngành mới.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Xác nhận người dùng có muốn sửa hay không
            DialogResult result = MessageBox.Show("Bạn có chắc chắn muốn sửa ngành này?", "Xác nhận",
                                                  MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.No)
                return;

            // Sử dụng `using` để tự động đóng kết nối
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                try
                {
                    conn.Open();

                    // Kiểm tra mã ngành có tồn tại không
                    string checkQuery = "SELECT COUNT(*) FROM Nganh WHERE MaNganh = @MaNganh";
                    using (SqlCommand checkCmd = new SqlCommand(checkQuery, conn))
                    {
                        checkCmd.Parameters.AddWithValue("@MaNganh", maNganh);
                        int count = (int)checkCmd.ExecuteScalar();

                        if (count == 0)
                        {
                            MessageBox.Show("Mã ngành không tồn tại.Không sửa được mã. Vui lòng kiểm tra lại.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            return;
                        }
                    }

                    // Cập nhật ngành
                    string updateQuery = "UPDATE Nganh SET TenNganh = @TenNganh WHERE MaNganh = @MaNganh";
                    using (SqlCommand updateCmd = new SqlCommand(updateQuery, conn))
                    {
                        updateCmd.Parameters.AddWithValue("@MaNganh", maNganh);
                        updateCmd.Parameters.AddWithValue("@TenNganh", tenNganh);
                        int rowsAffected = updateCmd.ExecuteNonQuery();

                        if (rowsAffected > 0)
                        {
                            MessageBox.Show("Cập nhật ngành thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            LoadData(); // Cập nhật lại DataGridView
                            txt_tenNganh.Clear();
                        }
                        else
                        {
                            MessageBox.Show("Cập nhật ngành thất bại.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void dataGridView_Nganh_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            // Kiểm tra nếu người dùng click vào một dòng hợp lệ (không phải tiêu đề)
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dataGridView_Nganh.Rows[e.RowIndex];

                // Gán dữ liệu từ DataGridView vào các TextBox
                txtMaNganh.Text = row.Cells["MaNganh"].Value.ToString();
                txt_tenNganh.Text = row.Cells["TenNganh"].Value.ToString();

                // Khóa ô nhập Mã Ngành để tránh sửa mã ngành
                txtMaNganh.Enabled = false;
                txtSearchMa_Nganh.Enabled = false;
                txtSearchten_Nganh.Enabled = false;
                btnThem_Nganh.Enabled = false;
                btnTimKiem.Enabled = false;
            }
        }

        private void btnXoa_Nganh_Click(object sender, EventArgs e)
        {
            if (dataGridView_Nganh.SelectedRows.Count == 0)
            {
                MessageBox.Show("Vui lòng chọn ngành cần xóa!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string maNganh = txtMaNganh.Text.Trim();

            DialogResult result = MessageBox.Show("Bạn có chắc chắn muốn xóa ngành này không?", "Xác nhận xóa",
                                                  MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                try
                {
                    using (SqlConnection conn = new SqlConnection(connectionString))
                    {
                        conn.Open();
                        // xóa nếu xóa cả lớp sinh viên ngành
                        // Kiểm tra xem ngành có lớp nào không
                        string checkQuery = "SELECT COUNT(*) FROM Lop WHERE MaNganh = @MaNganh";

                        using (SqlCommand checkCmd = new SqlCommand(checkQuery, conn))
                        {
                            checkCmd.Parameters.AddWithValue("@MaNganh", maNganh);
                            int count = (int)checkCmd.ExecuteScalar();

                            if (count > 0)
                            {
                                MessageBox.Show("Không thể xóa ngành vì ( có sinh viên học ngành này) và vẫn còn lớp thuộc ngành này!",
                                                "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                return;
                            }
                        }

                        //// cá bước xóa ngành
                        //// 1. Lấy danh sách MaMon của ngành
                        //string getMaMonQuery = "SELECT MaMon FROM MonHoc WHERE MaNganh = @MaNganh";
                        //List<string> danhSachMaMon = new List<string>();

                        //using (SqlCommand cmd = new SqlCommand(getMaMonQuery, conn))
                        //{
                        //    cmd.Parameters.AddWithValue("@MaNganh", maNganh);
                        //    using (SqlDataReader reader = cmd.ExecuteReader())
                        //    {
                        //        while (reader.Read())
                        //        {
                        //            danhSachMaMon.Add(reader["MaMon"].ToString());
                        //        }
                        //    }
                        //}

                        //// 2. Xóa dữ liệu liên quan đến từng MaMon
                        //foreach (string maMon in danhSachMaMon)
                        //{
                        //    // Xóa trong ThiLai
                        //    string deleteThiLai = "DELETE FROM ThiLai WHERE MaMon = @MaMon";
                        //    using (SqlCommand cmdDelThiLai = new SqlCommand(deleteThiLai, conn))
                        //    {
                        //        cmdDelThiLai.Parameters.AddWithValue("@MaMon", maMon);
                        //        cmdDelThiLai.ExecuteNonQuery();
                        //    }

                        //    // Xóa trong Diem
                        //    string deleteDiem = "DELETE FROM Diem WHERE MaMon = @MaMon";
                        //    using (SqlCommand cmdDelDiem = new SqlCommand(deleteDiem, conn))
                        //    {
                        //        cmdDelDiem.Parameters.AddWithValue("@MaMon", maMon);
                        //        cmdDelDiem.ExecuteNonQuery();
                        //    }

                        //    // Xóa trong HocLai
                        //    string deleteHocLai = "DELETE FROM HocLai WHERE MaMon = @MaMon";
                        //    using (SqlCommand cmdDelHocLai = new SqlCommand(deleteHocLai, conn))
                        //    {
                        //        cmdDelHocLai.Parameters.AddWithValue("@MaMon", maMon);
                        //        cmdDelHocLai.ExecuteNonQuery();
                        //    }
                        //}

                        //// 3. Xóa môn học thuộc ngành
                        //string deleteMonHoc = "DELETE FROM MonHoc WHERE MaNganh = @MaNganh";
                        //using (SqlCommand cmdDelMonHoc = new SqlCommand(deleteMonHoc, conn))
                        //{
                        //    cmdDelMonHoc.Parameters.AddWithValue("@MaNganh", maNganh);
                        //    cmdDelMonHoc.ExecuteNonQuery();
                        //}

                        //// 4. Lấy danh sách các lớp thuộc ngành
                        //string getLopQuery = "SELECT MaLop FROM Lop WHERE MaNganh = @MaNganh";
                        //List<string> dsLop = new List<string>();

                        //using (SqlCommand cmdLop = new SqlCommand(getLopQuery, conn))
                        //{
                        //    cmdLop.Parameters.AddWithValue("@MaNganh", maNganh);
                        //    using (SqlDataReader reader = cmdLop.ExecuteReader())
                        //    {
                        //        while (reader.Read())
                        //        {
                        //            dsLop.Add(reader.GetString(0)); // MaLop
                        //        }
                        //    }
                        //}

                        //// 5. Xóa sinh viên trong từng lớp
                        //// 5. Xóa sinh viên trong từng lớp
                        //foreach (string maLop in dsLop)
                        //{
                        //    string deleteSV = "DELETE FROM SinhVien WHERE MaLop = @MaLop";
                        //    using (SqlCommand cmdDelSV = new SqlCommand(deleteSV, conn))
                        //    {
                        //        cmdDelSV.Parameters.AddWithValue("@MaLop", maLop);
                        //        cmdDelSV.ExecuteNonQuery();
                        //    }
                        //}

                        //// 5.0 Xóa khen thưởng của sinh viên thuộc các lớp ngành này
                        //foreach (string maLop in dsLop)
                        //{
                        //    // Lấy danh sách mã sinh viên
                        //    string getSinhVienQuery = "SELECT MaSV FROM SinhVien WHERE MaLop = @MaLop";
                        //    List<string> dsMaSV = new List<string>();

                        //    using (SqlCommand cmdGetSV = new SqlCommand(getSinhVienQuery, conn))
                        //    {
                        //        cmdGetSV.Parameters.AddWithValue("@MaLop", maLop);
                        //        using (SqlDataReader reader = cmdGetSV.ExecuteReader())
                        //        {
                        //            while (reader.Read())
                        //            {
                        //                dsMaSV.Add(reader.GetString(0));
                        //            }
                        //        }
                        //    }


                        //    // Xóa khen thưởng theo MaSV
                        //    foreach (string maSV in dsMaSV)
                        //    {
                        //        string deleteKT = "DELETE FROM KhenThuong WHERE MaSV = @MaSV";
                        //        using (SqlCommand cmdDelKT = new SqlCommand(deleteKT, conn))
                        //        {
                        //            cmdDelKT.Parameters.AddWithValue("@MaSV", maSV);
                        //            cmdDelKT.ExecuteNonQuery();
                        //        }
                        //    }
                        //}

                        //// 6. Xóa lớp
                        //string deleteLop = "DELETE FROM Lop WHERE MaNganh = @MaNganh";
                        //using (SqlCommand cmdDelLop = new SqlCommand(deleteLop, conn))
                        //{
                        //    cmdDelLop.Parameters.AddWithValue("@MaNganh", maNganh);
                        //    cmdDelLop.ExecuteNonQuery();
                        //}



                        // ok đến đây

                        // Nếu không có lớp nào liên quan, tiến hành xóa
                        string deleteQuery = "DELETE FROM Nganh WHERE MaNganh = @MaNganh";

                        using (SqlCommand deleteCmd = new SqlCommand(deleteQuery, conn))
                        {
                            deleteCmd.Parameters.AddWithValue("@MaNganh", maNganh);
                            int rowsAffected = deleteCmd.ExecuteNonQuery();

                            if (rowsAffected > 0)
                            {
                                MessageBox.Show("Xóa ngành thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                LoadData(); // Cập nhật lại danh sách ngành
                                ResetFields(); // Xóa dữ liệu trên các ô nhập
                            }
                            else
                            {
                                MessageBox.Show("Ngành không tồn tại hoặc đã bị xóa trước đó.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi khi xóa ngành: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        
        }
          private void ResetFields()
        {
            txtMaNganh.Clear();
            txt_tenNganh.Clear();
        }

        private void btnTimKiem_Click(object sender, EventArgs e)
        {
            string maNganh = txtSearchMa_Nganh.Text.Trim();
            string tenNganh = txtSearchten_Nganh.Text.Trim();

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                string query = "SELECT * FROM Nganh WHERE 1=1"; // Luôn đúng, giúp nối điều kiện dễ dàng

                if (!string.IsNullOrEmpty(maNganh))
                {
                    query += " AND MaNganh LIKE @MaNganh";
                }
                if (!string.IsNullOrEmpty(tenNganh))
                {
                    query += " AND TenNganh LIKE @TenNganh";
                }

                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    if (!string.IsNullOrEmpty(maNganh))
                        cmd.Parameters.AddWithValue("@MaNganh", "%" + maNganh + "%");

                    if (!string.IsNullOrEmpty(tenNganh))
                        cmd.Parameters.AddWithValue("@TenNganh", "%" + tenNganh + "%");

                    SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                    DataTable dt = new DataTable();
                    adapter.Fill(dt);
                    dataGridView_Nganh.DataSource = dt; // Hiển thị kết quả trong DataGridView
                    //if (dt.Rows.Count == 0)
                    //{
                    //    MessageBox.Show("Không tìm thấy kết quả!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    //}
                }
            }
        }

        private void txtSearchten_Nganh_TextChanged(object sender, EventArgs e)
        {

        }
        private void ExportExcel(string path)
        {

            try
            {
                Excel.Application application = new Excel.Application();
                application.Application.Workbooks.Add(Type.Missing);

                // Xuất tiêu đề cột
                for (int i = 0; i < dataGridView_Nganh.ColumnCount; i++)
                {
                    application.Cells[1, i + 1] = dataGridView_Nganh.Columns[i].HeaderText;
                }

                // Xuất dữ liệu hàng
                for (int i = 0; i < dataGridView_Nganh.Rows.Count; i++)
                {
                    for (int j = 0; j < dataGridView_Nganh.Columns.Count; j++)
                    {
                        application.Cells[i + 2, j + 1] = dataGridView_Nganh.Rows[i].Cells[j].Value?.ToString();
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





// ----------code để xóa được mã ngành khi tồn tại ngành trong lớp------------
//// 1️⃣ Lấy danh sách các lớp thuộc ngành
//string getLopQuery = "SELECT MaLop FROM Lop WHERE MaNganh = @MaNganh";
//List<string> danhSachLop = new List<string>();

//using (SqlCommand getLopCmd = new SqlCommand(getLopQuery, conn))
//{
//    getLopCmd.Parameters.AddWithValue("@MaNganh", maNganh);
//    using (SqlDataReader reader = getLopCmd.ExecuteReader())
//    {
//        while (reader.Read())
//        {
//            danhSachLop.Add(reader.GetString(0)); // Lấy MaLop
//        }
//    }
//}

//// 2️⃣ Xóa toàn bộ sinh viên trong các lớp thuộc ngành
//foreach (string maLop in danhSachLop)
//{
//    string deleteSVQuery = "DELETE FROM SinhVien WHERE MaLop = @MaLop";
//    using (SqlCommand deleteSVCmd = new SqlCommand(deleteSVQuery, conn))
//    {
//        deleteSVCmd.Parameters.AddWithValue("@MaLop", maLop);
//        deleteSVCmd.ExecuteNonQuery();
//    }
//}

//// 3️⃣ Xóa tất cả lớp thuộc ngành
//string deleteLopQuery = "DELETE FROM Lop WHERE MaNganh = @MaNganh";
//using (SqlCommand deleteLopCmd = new SqlCommand(deleteLopQuery, conn))
//{
//    deleteLopCmd.Parameters.AddWithValue("@MaNganh", maNganh);
//    deleteLopCmd.ExecuteNonQuery();
//}

//// 4️⃣ Xóa ngành
//string deleteNganhQuery = "DELETE FROM Nganh WHERE MaNganh = @MaNganh";
//using (SqlCommand deleteNganhCmd = new SqlCommand(deleteNganhQuery, conn))
//{
//    deleteNganhCmd.Parameters.AddWithValue("@MaNganh", maNganh);
//    int rowsAffected = deleteNganhCmd.ExecuteNonQuery();

//    if (rowsAffected > 0)
//    {
//        MessageBox.Show("Xóa ngành và tất cả dữ liệu liên quan thành công!",
//                        "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
//        LoadData(); // Cập nhật lại danh sách ngành
//        ResetFields(); // Xóa dữ liệu trên các ô nhập
//    }
//    else
//    {
//        MessageBox.Show("Ngành không tồn tại hoặc đã bị xóa trước đó.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
//    }
//}
//            }
//        }
//        catch (Exception ex)
//        {
//            MessageBox.Show("Lỗi khi xóa ngành: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
//        }
//    }