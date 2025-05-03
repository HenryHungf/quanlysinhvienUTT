namespace quanlysinhvien.quanly_usercontrol
{
    partial class ucQuanLyMonHoc
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
            this.dataGridViewMOnhoc = new System.Windows.Forms.DataGridView();
            this.groupBoxtMonHoc = new System.Windows.Forms.GroupBox();
            this.label4 = new System.Windows.Forms.Label();
            this.comboBoxNganh = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txt_sotinchi_Search = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.txtSearch_ten_monHoc = new System.Windows.Forms.TextBox();
            this.txtSearch_MamonHoc = new System.Windows.Forms.TextBox();
            this.btnTimKiem_monHoc = new System.Windows.Forms.Button();
            this.btnXoa_monHoc = new System.Windows.Forms.Button();
            this.btnSua_monHoc = new System.Windows.Forms.Button();
            this.btnThem_monHoc = new System.Windows.Forms.Button();
            this.txtSotinChi = new System.Windows.Forms.TextBox();
            this.txtten_MOnHoc = new System.Windows.Forms.TextBox();
            this.txtMaMOnHoc = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.Export = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewMOnhoc)).BeginInit();
            this.groupBoxtMonHoc.SuspendLayout();
            this.SuspendLayout();
            // 
            // dataGridViewMOnhoc
            // 
            this.dataGridViewMOnhoc.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridViewMOnhoc.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewMOnhoc.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.dataGridViewMOnhoc.Location = new System.Drawing.Point(47, 77);
            this.dataGridViewMOnhoc.Name = "dataGridViewMOnhoc";
            this.dataGridViewMOnhoc.RowHeadersWidth = 82;
            this.dataGridViewMOnhoc.RowTemplate.Height = 33;
            this.dataGridViewMOnhoc.Size = new System.Drawing.Size(1484, 475);
            this.dataGridViewMOnhoc.TabIndex = 6;
            this.dataGridViewMOnhoc.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridViewMOnhoc_CellClick);
            // 
            // groupBoxtMonHoc
            // 
            this.groupBoxtMonHoc.Controls.Add(this.label4);
            this.groupBoxtMonHoc.Controls.Add(this.comboBoxNganh);
            this.groupBoxtMonHoc.Controls.Add(this.label3);
            this.groupBoxtMonHoc.Controls.Add(this.txt_sotinchi_Search);
            this.groupBoxtMonHoc.Controls.Add(this.label9);
            this.groupBoxtMonHoc.Controls.Add(this.label8);
            this.groupBoxtMonHoc.Controls.Add(this.txtSearch_ten_monHoc);
            this.groupBoxtMonHoc.Controls.Add(this.txtSearch_MamonHoc);
            this.groupBoxtMonHoc.Controls.Add(this.btnTimKiem_monHoc);
            this.groupBoxtMonHoc.Controls.Add(this.btnXoa_monHoc);
            this.groupBoxtMonHoc.Controls.Add(this.btnSua_monHoc);
            this.groupBoxtMonHoc.Controls.Add(this.btnThem_monHoc);
            this.groupBoxtMonHoc.Controls.Add(this.txtSotinChi);
            this.groupBoxtMonHoc.Controls.Add(this.txtten_MOnHoc);
            this.groupBoxtMonHoc.Controls.Add(this.txtMaMOnHoc);
            this.groupBoxtMonHoc.Controls.Add(this.label6);
            this.groupBoxtMonHoc.Controls.Add(this.label2);
            this.groupBoxtMonHoc.Controls.Add(this.label1);
            this.groupBoxtMonHoc.Location = new System.Drawing.Point(47, 583);
            this.groupBoxtMonHoc.Name = "groupBoxtMonHoc";
            this.groupBoxtMonHoc.Size = new System.Drawing.Size(1484, 489);
            this.groupBoxtMonHoc.TabIndex = 5;
            this.groupBoxtMonHoc.TabStop = false;
            this.groupBoxtMonHoc.Text = "Thông tin Môn học";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(690, 115);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(75, 25);
            this.label4.TabIndex = 26;
            this.label4.Text = "Ngành";
            // 
            // comboBoxNganh
            // 
            this.comboBoxNganh.FormattingEnabled = true;
            this.comboBoxNganh.Location = new System.Drawing.Point(802, 107);
            this.comboBoxNganh.Name = "comboBoxNganh";
            this.comboBoxNganh.Size = new System.Drawing.Size(319, 33);
            this.comboBoxNganh.TabIndex = 25;
            this.comboBoxNganh.Text = "Chọn ngành";
            this.comboBoxNganh.SelectedIndexChanged += new System.EventHandler(this.comboBoxNganh_SelectedIndexChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(1177, 363);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(101, 25);
            this.label3.TabIndex = 24;
            this.label3.Text = "Số tín chỉ";
            // 
            // txt_sotinchi_Search
            // 
            this.txt_sotinchi_Search.Location = new System.Drawing.Point(1077, 402);
            this.txt_sotinchi_Search.Multiline = true;
            this.txt_sotinchi_Search.Name = "txt_sotinchi_Search";
            this.txt_sotinchi_Search.Size = new System.Drawing.Size(319, 58);
            this.txt_sotinchi_Search.TabIndex = 23;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(822, 363);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(97, 25);
            this.label9.TabIndex = 22;
            this.label9.Text = "Tên Môn";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(511, 363);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(90, 25);
            this.label8.TabIndex = 21;
            this.label8.Text = "Mã Môn";
            // 
            // txtSearch_ten_monHoc
            // 
            this.txtSearch_ten_monHoc.Location = new System.Drawing.Point(753, 406);
            this.txtSearch_ten_monHoc.Multiline = true;
            this.txtSearch_ten_monHoc.Name = "txtSearch_ten_monHoc";
            this.txtSearch_ten_monHoc.Size = new System.Drawing.Size(246, 58);
            this.txtSearch_ten_monHoc.TabIndex = 20;
            // 
            // txtSearch_MamonHoc
            // 
            this.txtSearch_MamonHoc.Location = new System.Drawing.Point(429, 406);
            this.txtSearch_MamonHoc.Multiline = true;
            this.txtSearch_MamonHoc.Name = "txtSearch_MamonHoc";
            this.txtSearch_MamonHoc.Size = new System.Drawing.Size(246, 58);
            this.txtSearch_MamonHoc.TabIndex = 19;
            // 
            // btnTimKiem_monHoc
            // 
            this.btnTimKiem_monHoc.Location = new System.Drawing.Point(120, 406);
            this.btnTimKiem_monHoc.Name = "btnTimKiem_monHoc";
            this.btnTimKiem_monHoc.Size = new System.Drawing.Size(186, 54);
            this.btnTimKiem_monHoc.TabIndex = 18;
            this.btnTimKiem_monHoc.Text = "Tìm kiếm";
            this.btnTimKiem_monHoc.UseVisualStyleBackColor = true;
            this.btnTimKiem_monHoc.Click += new System.EventHandler(this.btnTimKiem_monHoc_Click);
            // 
            // btnXoa_monHoc
            // 
            this.btnXoa_monHoc.Location = new System.Drawing.Point(1237, 250);
            this.btnXoa_monHoc.Name = "btnXoa_monHoc";
            this.btnXoa_monHoc.Size = new System.Drawing.Size(186, 54);
            this.btnXoa_monHoc.TabIndex = 17;
            this.btnXoa_monHoc.Text = "Xóa";
            this.btnXoa_monHoc.UseVisualStyleBackColor = true;
            this.btnXoa_monHoc.Click += new System.EventHandler(this.btnXoa_monHoc_Click);
            // 
            // btnSua_monHoc
            // 
            this.btnSua_monHoc.Location = new System.Drawing.Point(1237, 153);
            this.btnSua_monHoc.Name = "btnSua_monHoc";
            this.btnSua_monHoc.Size = new System.Drawing.Size(186, 54);
            this.btnSua_monHoc.TabIndex = 16;
            this.btnSua_monHoc.Text = "Sửa";
            this.btnSua_monHoc.UseVisualStyleBackColor = true;
            this.btnSua_monHoc.Click += new System.EventHandler(this.btnSua_monHoc_Click);
            // 
            // btnThem_monHoc
            // 
            this.btnThem_monHoc.Location = new System.Drawing.Point(1237, 67);
            this.btnThem_monHoc.Name = "btnThem_monHoc";
            this.btnThem_monHoc.Size = new System.Drawing.Size(186, 54);
            this.btnThem_monHoc.TabIndex = 15;
            this.btnThem_monHoc.Text = "Thêm";
            this.btnThem_monHoc.UseVisualStyleBackColor = true;
            this.btnThem_monHoc.Click += new System.EventHandler(this.btnThem_monHoc_Click);
            // 
            // txtSotinChi
            // 
            this.txtSotinChi.Location = new System.Drawing.Point(163, 250);
            this.txtSotinChi.Name = "txtSotinChi";
            this.txtSotinChi.Size = new System.Drawing.Size(319, 31);
            this.txtSotinChi.TabIndex = 14;
            // 
            // txtten_MOnHoc
            // 
            this.txtten_MOnHoc.Location = new System.Drawing.Point(163, 153);
            this.txtten_MOnHoc.Name = "txtten_MOnHoc";
            this.txtten_MOnHoc.Size = new System.Drawing.Size(474, 31);
            this.txtten_MOnHoc.TabIndex = 8;
            // 
            // txtMaMOnHoc
            // 
            this.txtMaMOnHoc.Location = new System.Drawing.Point(163, 67);
            this.txtMaMOnHoc.Name = "txtMaMOnHoc";
            this.txtMaMOnHoc.Size = new System.Drawing.Size(474, 31);
            this.txtMaMOnHoc.TabIndex = 7;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(39, 250);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(101, 25);
            this.label6.TabIndex = 5;
            this.label6.Text = "Số tín chỉ";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(6, 168);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(141, 25);
            this.label2.TabIndex = 1;
            this.label2.Text = "Tên Môn Học";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 73);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(134, 25);
            this.label1.TabIndex = 0;
            this.label1.Text = "Mã Môn Học";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.BackColor = System.Drawing.Color.Wheat;
            this.label10.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.label10.Location = new System.Drawing.Point(37, 19);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(410, 55);
            this.label10.TabIndex = 23;
            this.label10.Text = "Quản lý Môn Học";
            // 
            // Export
            // 
            this.Export.BackColor = System.Drawing.Color.Coral;
            this.Export.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.875F, ((System.Drawing.FontStyle)(((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic) 
                | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.Export.Location = new System.Drawing.Point(1345, 17);
            this.Export.Name = "Export";
            this.Export.Size = new System.Drawing.Size(186, 54);
            this.Export.TabIndex = 30;
            this.Export.Text = "Xuất Excel";
            this.Export.UseVisualStyleBackColor = false;
            this.Export.Click += new System.EventHandler(this.Export_Click);
            // 
            // ucQuanLyMonHoc
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.Controls.Add(this.Export);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.dataGridViewMOnhoc);
            this.Controls.Add(this.groupBoxtMonHoc);
            this.Name = "ucQuanLyMonHoc";
            this.Size = new System.Drawing.Size(1579, 1149);
            this.Load += new System.EventHandler(this.ucQuanLyMonHoc_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewMOnhoc)).EndInit();
            this.groupBoxtMonHoc.ResumeLayout(false);
            this.groupBoxtMonHoc.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridViewMOnhoc;
        private System.Windows.Forms.GroupBox groupBoxtMonHoc;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox txtSearch_ten_monHoc;
        private System.Windows.Forms.TextBox txtSearch_MamonHoc;
        private System.Windows.Forms.Button btnTimKiem_monHoc;
        private System.Windows.Forms.Button btnXoa_monHoc;
        private System.Windows.Forms.Button btnSua_monHoc;
        private System.Windows.Forms.Button btnThem_monHoc;
        private System.Windows.Forms.TextBox txtSotinChi;
        private System.Windows.Forms.TextBox txtten_MOnHoc;
        private System.Windows.Forms.TextBox txtMaMOnHoc;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txt_sotinchi_Search;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox comboBoxNganh;
        private System.Windows.Forms.Button Export;
    }
}
