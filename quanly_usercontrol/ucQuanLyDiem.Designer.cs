namespace quanlysinhvien.quanly_usercontrol
{
    partial class ucQuanLyDiem
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
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.groupBoxttDiem = new System.Windows.Forms.GroupBox();
            this.label5 = new System.Windows.Forms.Label();
            this.txtDiem = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.combox_Search_Monhocdiem = new System.Windows.Forms.ComboBox();
            this.comboBoxMonHoc_diem = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.txtSearchHoten_diem = new System.Windows.Forms.TextBox();
            this.txtSearchMaSV_Diem = new System.Windows.Forms.TextBox();
            this.btnTimKiem_diem = new System.Windows.Forms.Button();
            this.btnXoaDiem = new System.Windows.Forms.Button();
            this.btnSuaDiem = new System.Windows.Forms.Button();
            this.btnThemDiem = new System.Windows.Forms.Button();
            this.comboBoxLop = new System.Windows.Forms.ComboBox();
            this.txtHoten = new System.Windows.Forms.TextBox();
            this.txtMaSV = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.Export = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.groupBoxttDiem.SuspendLayout();
            this.SuspendLayout();
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(47, 77);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowHeadersWidth = 82;
            this.dataGridView1.RowTemplate.Height = 33;
            this.dataGridView1.Size = new System.Drawing.Size(1484, 475);
            this.dataGridView1.TabIndex = 6;
            this.dataGridView1.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellClick);
            // 
            // groupBoxttDiem
            // 
            this.groupBoxttDiem.Controls.Add(this.label5);
            this.groupBoxttDiem.Controls.Add(this.txtDiem);
            this.groupBoxttDiem.Controls.Add(this.label4);
            this.groupBoxttDiem.Controls.Add(this.combox_Search_Monhocdiem);
            this.groupBoxttDiem.Controls.Add(this.comboBoxMonHoc_diem);
            this.groupBoxttDiem.Controls.Add(this.label3);
            this.groupBoxttDiem.Controls.Add(this.label9);
            this.groupBoxttDiem.Controls.Add(this.label8);
            this.groupBoxttDiem.Controls.Add(this.txtSearchHoten_diem);
            this.groupBoxttDiem.Controls.Add(this.txtSearchMaSV_Diem);
            this.groupBoxttDiem.Controls.Add(this.btnTimKiem_diem);
            this.groupBoxttDiem.Controls.Add(this.btnXoaDiem);
            this.groupBoxttDiem.Controls.Add(this.btnSuaDiem);
            this.groupBoxttDiem.Controls.Add(this.btnThemDiem);
            this.groupBoxttDiem.Controls.Add(this.comboBoxLop);
            this.groupBoxttDiem.Controls.Add(this.txtHoten);
            this.groupBoxttDiem.Controls.Add(this.txtMaSV);
            this.groupBoxttDiem.Controls.Add(this.label7);
            this.groupBoxttDiem.Controls.Add(this.label2);
            this.groupBoxttDiem.Controls.Add(this.label1);
            this.groupBoxttDiem.Location = new System.Drawing.Point(47, 583);
            this.groupBoxttDiem.Name = "groupBoxttDiem";
            this.groupBoxttDiem.Size = new System.Drawing.Size(1484, 489);
            this.groupBoxttDiem.TabIndex = 5;
            this.groupBoxttDiem.TabStop = false;
            this.groupBoxttDiem.Text = "Thông tin Điểm";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(1150, 363);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(98, 25);
            this.label5.TabIndex = 28;
            this.label5.Text = "Môn Học";
            // 
            // txtDiem
            // 
            this.txtDiem.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.txtDiem.Location = new System.Drawing.Point(840, 165);
            this.txtDiem.Multiline = true;
            this.txtDiem.Name = "txtDiem";
            this.txtDiem.Size = new System.Drawing.Size(281, 61);
            this.txtDiem.TabIndex = 27;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.875F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.label4.Location = new System.Drawing.Point(683, 182);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(88, 33);
            this.label4.TabIndex = 26;
            this.label4.Text = "Điểm";
            // 
            // combox_Search_Monhocdiem
            // 
            this.combox_Search_Monhocdiem.FormattingEnabled = true;
            this.combox_Search_Monhocdiem.Location = new System.Drawing.Point(1076, 406);
            this.combox_Search_Monhocdiem.Name = "combox_Search_Monhocdiem";
            this.combox_Search_Monhocdiem.Size = new System.Drawing.Size(281, 33);
            this.combox_Search_Monhocdiem.TabIndex = 25;
            // 
            // comboBoxMonHoc_diem
            // 
            this.comboBoxMonHoc_diem.FormattingEnabled = true;
            this.comboBoxMonHoc_diem.Location = new System.Drawing.Point(840, 67);
            this.comboBoxMonHoc_diem.Name = "comboBoxMonHoc_diem";
            this.comboBoxMonHoc_diem.Size = new System.Drawing.Size(281, 33);
            this.comboBoxMonHoc_diem.TabIndex = 24;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(683, 73);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(98, 25);
            this.label3.TabIndex = 23;
            this.label3.Text = "Môn Học";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(835, 363);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(104, 25);
            this.label9.TabIndex = 22;
            this.label9.Text = "Họ và tên";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(511, 363);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(76, 25);
            this.label8.TabIndex = 21;
            this.label8.Text = "Mã SV";
            // 
            // txtSearchHoten_diem
            // 
            this.txtSearchHoten_diem.Location = new System.Drawing.Point(753, 406);
            this.txtSearchHoten_diem.Multiline = true;
            this.txtSearchHoten_diem.Name = "txtSearchHoten_diem";
            this.txtSearchHoten_diem.Size = new System.Drawing.Size(246, 58);
            this.txtSearchHoten_diem.TabIndex = 20;
            // 
            // txtSearchMaSV_Diem
            // 
            this.txtSearchMaSV_Diem.Location = new System.Drawing.Point(429, 406);
            this.txtSearchMaSV_Diem.Multiline = true;
            this.txtSearchMaSV_Diem.Name = "txtSearchMaSV_Diem";
            this.txtSearchMaSV_Diem.Size = new System.Drawing.Size(246, 58);
            this.txtSearchMaSV_Diem.TabIndex = 19;
            // 
            // btnTimKiem_diem
            // 
            this.btnTimKiem_diem.Location = new System.Drawing.Point(120, 406);
            this.btnTimKiem_diem.Name = "btnTimKiem_diem";
            this.btnTimKiem_diem.Size = new System.Drawing.Size(186, 54);
            this.btnTimKiem_diem.TabIndex = 18;
            this.btnTimKiem_diem.Text = "Tìm kiếm";
            this.btnTimKiem_diem.UseVisualStyleBackColor = true;
            this.btnTimKiem_diem.Click += new System.EventHandler(this.btnTimKiem_diem_Click);
            // 
            // btnXoaDiem
            // 
            this.btnXoaDiem.Location = new System.Drawing.Point(1237, 250);
            this.btnXoaDiem.Name = "btnXoaDiem";
            this.btnXoaDiem.Size = new System.Drawing.Size(186, 54);
            this.btnXoaDiem.TabIndex = 17;
            this.btnXoaDiem.Text = "Xóa";
            this.btnXoaDiem.UseVisualStyleBackColor = true;
            this.btnXoaDiem.Click += new System.EventHandler(this.btnXoaDiem_Click);
            // 
            // btnSuaDiem
            // 
            this.btnSuaDiem.Location = new System.Drawing.Point(1237, 153);
            this.btnSuaDiem.Name = "btnSuaDiem";
            this.btnSuaDiem.Size = new System.Drawing.Size(186, 54);
            this.btnSuaDiem.TabIndex = 16;
            this.btnSuaDiem.Text = "Sửa";
            this.btnSuaDiem.UseVisualStyleBackColor = true;
            this.btnSuaDiem.Click += new System.EventHandler(this.btnSuaDiem_Click);
            // 
            // btnThemDiem
            // 
            this.btnThemDiem.Location = new System.Drawing.Point(1237, 67);
            this.btnThemDiem.Name = "btnThemDiem";
            this.btnThemDiem.Size = new System.Drawing.Size(186, 54);
            this.btnThemDiem.TabIndex = 15;
            this.btnThemDiem.Text = "Thêm";
            this.btnThemDiem.UseVisualStyleBackColor = true;
            this.btnThemDiem.Click += new System.EventHandler(this.btnThemDiem_Click);
            // 
            // comboBoxLop
            // 
            this.comboBoxLop.FormattingEnabled = true;
            this.comboBoxLop.Location = new System.Drawing.Point(132, 214);
            this.comboBoxLop.Name = "comboBoxLop";
            this.comboBoxLop.Size = new System.Drawing.Size(319, 33);
            this.comboBoxLop.TabIndex = 13;
            // 
            // txtHoten
            // 
            this.txtHoten.Location = new System.Drawing.Point(133, 133);
            this.txtHoten.Name = "txtHoten";
            this.txtHoten.Size = new System.Drawing.Size(474, 31);
            this.txtHoten.TabIndex = 8;
            // 
            // txtMaSV
            // 
            this.txtMaSV.Location = new System.Drawing.Point(132, 67);
            this.txtMaSV.Name = "txtMaSV";
            this.txtMaSV.Size = new System.Drawing.Size(474, 31);
            this.txtMaSV.TabIndex = 7;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(23, 214);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(48, 25);
            this.label7.TabIndex = 6;
            this.label7.Text = "Lớp";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(23, 139);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(104, 25);
            this.label2.TabIndex = 1;
            this.label2.Text = "Họ và tên";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(23, 74);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(76, 25);
            this.label1.TabIndex = 0;
            this.label1.Text = "Mã SV";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.BackColor = System.Drawing.Color.Wheat;
            this.label10.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.label10.Location = new System.Drawing.Point(48, 19);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(326, 55);
            this.label10.TabIndex = 7;
            this.label10.Text = "Quản lý Điểm";
            // 
            // Export
            // 
            this.Export.BackColor = System.Drawing.Color.Coral;
            this.Export.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.875F, ((System.Drawing.FontStyle)(((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic) 
                | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.Export.Location = new System.Drawing.Point(448, 17);
            this.Export.Name = "Export";
            this.Export.Size = new System.Drawing.Size(186, 54);
            this.Export.TabIndex = 29;
            this.Export.Text = "Xuất Excel";
            this.Export.UseVisualStyleBackColor = false;
            this.Export.Click += new System.EventHandler(this.Export_Click);
            // 
            // ucQuanLyDiem
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.Export);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.groupBoxttDiem);
            this.Name = "ucQuanLyDiem";
            this.Size = new System.Drawing.Size(1579, 1149);
            this.Load += new System.EventHandler(this.ucQuanLyDiem_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.groupBoxttDiem.ResumeLayout(false);
            this.groupBoxttDiem.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.GroupBox groupBoxttDiem;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox txtSearchHoten_diem;
        private System.Windows.Forms.TextBox txtSearchMaSV_Diem;
        private System.Windows.Forms.Button btnTimKiem_diem;
        private System.Windows.Forms.Button btnXoaDiem;
        private System.Windows.Forms.Button btnSuaDiem;
        private System.Windows.Forms.Button btnThemDiem;
        private System.Windows.Forms.ComboBox comboBoxLop;
        private System.Windows.Forms.TextBox txtHoten;
        private System.Windows.Forms.TextBox txtMaSV;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.ComboBox combox_Search_Monhocdiem;
        private System.Windows.Forms.ComboBox comboBoxMonHoc_diem;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtDiem;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button Export;
    }
}
