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


namespace quanlysinhvien
{
    public partial class LoginForm : Form
    {
        private ConnectDB db = new ConnectDB();
        public LoginForm()
        {
            InitializeComponent();
        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void checkboxShowpass_CheckedChanged(object sender, EventArgs e)
        {
            txtPassword.PasswordChar = checkboxShowpass.Checked ? '\0': '*';
        }

        private void panel3_Paint(object sender, PaintEventArgs e)
        {

        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            string username = txtUSername.Text.Trim();
            string password = txtPassword.Text.Trim();

            if (AuthenticateUser(username, password))
            {
                MessageBox.Show("Đăng nhập thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);

                //// Mở form chính sau khi đăng nhập thành công
                TrangChu mainForm = new TrangChu();
                this.Hide();
                mainForm.Show();
            }
            else
            {
                MessageBox.Show("Sai tài khoản hoặc mật khẩu!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
      
        }

        private bool AuthenticateUser(string username, string password)
        {
            bool isAuthenticated = false;
            SqlConnection conn = db.Connect(); // Gọi hàm kết nối từ ConnectDB

            try
            {
                string query = "SELECT COUNT(*) FROM users WHERE username = @username AND password = @password";
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@username", username);
                    cmd.Parameters.AddWithValue("@password", password);

                    int count = (int)cmd.ExecuteScalar();
                    isAuthenticated = count > 0;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi truy vấn: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return isAuthenticated;
        }

        private void LoginForm_Load(object sender, EventArgs e)
        {

        }
    }
}
