namespace quanlysinhvien.quanly_usercontrol
{
    partial class ucQuanLyNganh
    {
        /// <summary> 
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.dataGridView_Nganh = new System.Windows.Forms.DataGridView();
            this.groupBoxtNganh = new System.Windows.Forms.GroupBox();
            this.label9 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.txtSearchten_Nganh = new System.Windows.Forms.TextBox();
            this.txtSearchMa_Nganh = new System.Windows.Forms.TextBox();
            this.btnTimKiem = new System.Windows.Forms.Button();
            this.btnXoa_Nganh = new System.Windows.Forms.Button();
            this.btnSua_Nganh = new System.Windows.Forms.Button();
            this.btnThem_Nganh = new System.Windows.Forms.Button();
            this.txt_tenNganh = new System.Windows.Forms.TextBox();
            this.txtMaNganh = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.Export = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_Nganh)).BeginInit();
            this.groupBoxtNganh.SuspendLayout();
            this.SuspendLayout();
            // 
            // dataGridView_Nganh
            // 
            this.dataGridView_Nganh.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridView_Nganh.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView_Nganh.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(128)))));
            this.dataGridView_Nganh.Location = new System.Drawing.Point(47, 77);
            this.dataGridView_Nganh.Name = "dataGridView_Nganh";
            this.dataGridView_Nganh.RowHeadersWidth = 82;
            this.dataGridView_Nganh.RowTemplate.Height = 33;
            this.dataGridView_Nganh.Size = new System.Drawing.Size(1484, 475);
            this.dataGridView_Nganh.TabIndex = 6;
            this.dataGridView_Nganh.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView_Nganh_CellClick);
            // 
            // groupBoxtNganh
            // 
            this.groupBoxtNganh.Controls.Add(this.label9);
            this.groupBoxtNganh.Controls.Add(this.label8);
            this.groupBoxtNganh.Controls.Add(this.txtSearchten_Nganh);
            this.groupBoxtNganh.Controls.Add(this.txtSearchMa_Nganh);
            this.groupBoxtNganh.Controls.Add(this.btnTimKiem);
            this.groupBoxtNganh.Controls.Add(this.btnXoa_Nganh);
            this.groupBoxtNganh.Controls.Add(this.btnSua_Nganh);
            this.groupBoxtNganh.Controls.Add(this.btnThem_Nganh);
            this.groupBoxtNganh.Controls.Add(this.txt_tenNganh);
            this.groupBoxtNganh.Controls.Add(this.txtMaNganh);
            this.groupBoxtNganh.Controls.Add(this.label2);
            this.groupBoxtNganh.Controls.Add(this.label1);
            this.groupBoxtNganh.Location = new System.Drawing.Point(47, 583);
            this.groupBoxtNganh.Name = "groupBoxtNganh";
            this.groupBoxtNganh.Size = new System.Drawing.Size(1484, 489);
            this.groupBoxtNganh.TabIndex = 5;
            this.groupBoxtNganh.TabStop = false;
            this.groupBoxtNganh.Text = "Thông tin Sinh Viên";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(835, 363);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(75, 25);
            this.label9.TabIndex = 22;
            this.label9.Text = "Ngành";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(511, 363);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(111, 25);
            this.label8.TabIndex = 21;
            this.label8.Text = "Mã Ngành";
            // 
            // txtSearchten_Nganh
            // 
            this.txtSearchten_Nganh.Location = new System.Drawing.Point(753, 406);
            this.txtSearchten_Nganh.Multiline = true;
            this.txtSearchten_Nganh.Name = "txtSearchten_Nganh";
            this.txtSearchten_Nganh.Size = new System.Drawing.Size(246, 58);
            this.txtSearchten_Nganh.TabIndex = 20;
            this.txtSearchten_Nganh.TextChanged += new System.EventHandler(this.txtSearchten_Nganh_TextChanged);
            // 
            // txtSearchMa_Nganh
            // 
            this.txtSearchMa_Nganh.Location = new System.Drawing.Point(429, 406);
            this.txtSearchMa_Nganh.Multiline = true;
            this.txtSearchMa_Nganh.Name = "txtSearchMa_Nganh";
            this.txtSearchMa_Nganh.Size = new System.Drawing.Size(246, 58);
            this.txtSearchMa_Nganh.TabIndex = 19;
            // 
            // btnTimKiem
            // 
            this.btnTimKiem.Location = new System.Drawing.Point(120, 406);
            this.btnTimKiem.Name = "btnTimKiem";
            this.btnTimKiem.Size = new System.Drawing.Size(186, 54);
            this.btnTimKiem.TabIndex = 18;
            this.btnTimKiem.Text = "Tìm kiếm";
            this.btnTimKiem.UseVisualStyleBackColor = true;
            this.btnTimKiem.Click += new System.EventHandler(this.btnTimKiem_Click);
            // 
            // btnXoa_Nganh
            // 
            this.btnXoa_Nganh.Location = new System.Drawing.Point(1237, 250);
            this.btnXoa_Nganh.Name = "btnXoa_Nganh";
            this.btnXoa_Nganh.Size = new System.Drawing.Size(186, 54);
            this.btnXoa_Nganh.TabIndex = 17;
            this.btnXoa_Nganh.Text = "Xóa";
            this.btnXoa_Nganh.UseVisualStyleBackColor = true;
            this.btnXoa_Nganh.Click += new System.EventHandler(this.btnXoa_Nganh_Click);
            // 
            // btnSua_Nganh
            // 
            this.btnSua_Nganh.Location = new System.Drawing.Point(1237, 153);
            this.btnSua_Nganh.Name = "btnSua_Nganh";
            this.btnSua_Nganh.Size = new System.Drawing.Size(186, 54);
            this.btnSua_Nganh.TabIndex = 16;
            this.btnSua_Nganh.Text = "Sửa";
            this.btnSua_Nganh.UseVisualStyleBackColor = true;
            this.btnSua_Nganh.Click += new System.EventHandler(this.btnSua_Nganh_Click);
            // 
            // btnThem_Nganh
            // 
            this.btnThem_Nganh.Location = new System.Drawing.Point(1237, 67);
            this.btnThem_Nganh.Name = "btnThem_Nganh";
            this.btnThem_Nganh.Size = new System.Drawing.Size(186, 54);
            this.btnThem_Nganh.TabIndex = 15;
            this.btnThem_Nganh.Text = "Thêm";
            this.btnThem_Nganh.UseVisualStyleBackColor = true;
            this.btnThem_Nganh.Click += new System.EventHandler(this.btnThem_Nganh_Click);
            // 
            // txt_tenNganh
            // 
            this.txt_tenNganh.Location = new System.Drawing.Point(159, 204);
            this.txt_tenNganh.Name = "txt_tenNganh";
            this.txt_tenNganh.Size = new System.Drawing.Size(474, 31);
            this.txt_tenNganh.TabIndex = 8;
            // 
            // txtMaNganh
            // 
            this.txtMaNganh.Location = new System.Drawing.Point(159, 68);
            this.txtMaNganh.Name = "txtMaNganh";
            this.txtMaNganh.Size = new System.Drawing.Size(474, 31);
            this.txtMaNganh.TabIndex = 7;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(22, 210);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(118, 25);
            this.label2.TabIndex = 1;
            this.label2.Text = "Tên Ngành";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(23, 74);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(111, 25);
            this.label1.TabIndex = 0;
            this.label1.Text = "Mã Ngành";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.BackColor = System.Drawing.Color.Wheat;
            this.label10.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.label10.Location = new System.Drawing.Point(37, 9);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(358, 55);
            this.label10.TabIndex = 7;
            this.label10.Text = "Quản lý Ngành";
            // 
            // Export
            // 
            this.Export.BackColor = System.Drawing.Color.Coral;
            this.Export.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.875F, ((System.Drawing.FontStyle)(((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic) 
                | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.Export.Location = new System.Drawing.Point(1345, 18);
            this.Export.Name = "Export";
            this.Export.Size = new System.Drawing.Size(186, 54);
            this.Export.TabIndex = 30;
            this.Export.Text = "Xuất Excel";
            this.Export.UseVisualStyleBackColor = false;
            this.Export.Click += new System.EventHandler(this.Export_Click);
            // 
            // ucQuanLyNganh
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.Controls.Add(this.Export);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.dataGridView_Nganh);
            this.Controls.Add(this.groupBoxtNganh);
            this.Name = "ucQuanLyNganh";
            this.Size = new System.Drawing.Size(1579, 1149);
            this.Load += new System.EventHandler(this.ucQuanLyNganh_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_Nganh)).EndInit();
            this.groupBoxtNganh.ResumeLayout(false);
            this.groupBoxtNganh.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView_Nganh;
        private System.Windows.Forms.GroupBox groupBoxtNganh;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox txtSearchten_Nganh;
        private System.Windows.Forms.TextBox txtSearchMa_Nganh;
        private System.Windows.Forms.Button btnTimKiem;
        private System.Windows.Forms.Button btnXoa_Nganh;
        private System.Windows.Forms.Button btnSua_Nganh;
        private System.Windows.Forms.Button btnThem_Nganh;
        private System.Windows.Forms.TextBox txt_tenNganh;
        private System.Windows.Forms.TextBox txtMaNganh;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Button Export;
    }
}
