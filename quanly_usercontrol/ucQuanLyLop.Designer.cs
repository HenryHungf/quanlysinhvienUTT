namespace quanlysinhvien.quanly_usercontrol
{
    partial class ucQuanLyLop
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
            this.label10 = new System.Windows.Forms.Label();
            this.Export = new System.Windows.Forms.Button();
            this.dgrlop = new System.Windows.Forms.DataGridView();
            this.MaLop = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TenLop = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.MaNganh = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.groupBoxttSinhVien = new System.Windows.Forms.GroupBox();
            this.label9 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.txttktl = new System.Windows.Forms.TextBox();
            this.txttkml = new System.Windows.Forms.TextBox();
            this.btnTimKiem = new System.Windows.Forms.Button();
            this.btnXoa = new System.Windows.Forms.Button();
            this.btnSua = new System.Windows.Forms.Button();
            this.btnThem = new System.Windows.Forms.Button();
            this.cbbnganh = new System.Windows.Forms.ComboBox();
            this.txttenlop = new System.Windows.Forms.TextBox();
            this.txtlop = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dgrlop)).BeginInit();
            this.groupBoxttSinhVien.SuspendLayout();
            this.SuspendLayout();
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.BackColor = System.Drawing.Color.Wheat;
            this.label10.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.label10.Location = new System.Drawing.Point(42, 28);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(294, 55);
            this.label10.TabIndex = 8;
            this.label10.Text = "Quản lý Lớp";
            // 
            // Export
            // 
            this.Export.BackColor = System.Drawing.Color.Coral;
            this.Export.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.875F, ((System.Drawing.FontStyle)(((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic) 
                | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.Export.Location = new System.Drawing.Point(1288, 39);
            this.Export.Name = "Export";
            this.Export.Size = new System.Drawing.Size(186, 55);
            this.Export.TabIndex = 31;
            this.Export.Text = "Xuất Excel";
            this.Export.UseVisualStyleBackColor = false;
            this.Export.Click += new System.EventHandler(this.Export_Click);
            // 
            // dgrlop
            // 
            this.dgrlop.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgrlop.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.MaLop,
            this.TenLop,
            this.MaNganh});
            this.dgrlop.Location = new System.Drawing.Point(51, 117);
            this.dgrlop.Name = "dgrlop";
            this.dgrlop.RowHeadersWidth = 82;
            this.dgrlop.RowTemplate.Height = 33;
            this.dgrlop.Size = new System.Drawing.Size(1484, 475);
            this.dgrlop.TabIndex = 32;
            this.dgrlop.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgrlop_CellClick);
            // 
            // MaLop
            // 
            this.MaLop.HeaderText = "Mã lớp";
            this.MaLop.MinimumWidth = 6;
            this.MaLop.Name = "MaLop";
            this.MaLop.Width = 125;
            // 
            // TenLop
            // 
            this.TenLop.HeaderText = "Tên lớp";
            this.TenLop.MinimumWidth = 6;
            this.TenLop.Name = "TenLop";
            this.TenLop.Width = 125;
            // 
            // MaNganh
            // 
            this.MaNganh.HeaderText = "Mã ngành";
            this.MaNganh.MinimumWidth = 6;
            this.MaNganh.Name = "MaNganh";
            this.MaNganh.Width = 125;
            // 
            // groupBoxttSinhVien
            // 
            this.groupBoxttSinhVien.Controls.Add(this.label9);
            this.groupBoxttSinhVien.Controls.Add(this.label8);
            this.groupBoxttSinhVien.Controls.Add(this.txttktl);
            this.groupBoxttSinhVien.Controls.Add(this.txttkml);
            this.groupBoxttSinhVien.Controls.Add(this.btnTimKiem);
            this.groupBoxttSinhVien.Controls.Add(this.btnXoa);
            this.groupBoxttSinhVien.Controls.Add(this.btnSua);
            this.groupBoxttSinhVien.Controls.Add(this.btnThem);
            this.groupBoxttSinhVien.Controls.Add(this.cbbnganh);
            this.groupBoxttSinhVien.Controls.Add(this.txttenlop);
            this.groupBoxttSinhVien.Controls.Add(this.txtlop);
            this.groupBoxttSinhVien.Controls.Add(this.label5);
            this.groupBoxttSinhVien.Controls.Add(this.label2);
            this.groupBoxttSinhVien.Controls.Add(this.label1);
            this.groupBoxttSinhVien.Location = new System.Drawing.Point(51, 619);
            this.groupBoxttSinhVien.Name = "groupBoxttSinhVien";
            this.groupBoxttSinhVien.Size = new System.Drawing.Size(1484, 489);
            this.groupBoxttSinhVien.TabIndex = 33;
            this.groupBoxttSinhVien.TabStop = false;
            this.groupBoxttSinhVien.Text = "Thông tin Sinh Viên";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(608, 416);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(90, 25);
            this.label9.TabIndex = 22;
            this.label9.Text = "Tên lớp:";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(129, 416);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(90, 25);
            this.label8.TabIndex = 21;
            this.label8.Text = "Mã Lớp:";
            // 
            // txttktl
            // 
            this.txttktl.Location = new System.Drawing.Point(753, 416);
            this.txttktl.Multiline = true;
            this.txttktl.Name = "txttktl";
            this.txttktl.Size = new System.Drawing.Size(253, 34);
            this.txttktl.TabIndex = 20;
            // 
            // txttkml
            // 
            this.txttkml.Location = new System.Drawing.Point(238, 411);
            this.txttkml.Multiline = true;
            this.txttkml.Name = "txttkml";
            this.txttkml.Size = new System.Drawing.Size(247, 38);
            this.txttkml.TabIndex = 19;
            // 
            // btnTimKiem
            // 
            this.btnTimKiem.Location = new System.Drawing.Point(1238, 397);
            this.btnTimKiem.Name = "btnTimKiem";
            this.btnTimKiem.Size = new System.Drawing.Size(186, 55);
            this.btnTimKiem.TabIndex = 18;
            this.btnTimKiem.Text = "Tìm kiếm";
            this.btnTimKiem.UseVisualStyleBackColor = true;
            this.btnTimKiem.Click += new System.EventHandler(this.btnTimKiem_Click);
            // 
            // btnXoa
            // 
            this.btnXoa.Location = new System.Drawing.Point(1238, 250);
            this.btnXoa.Name = "btnXoa";
            this.btnXoa.Size = new System.Drawing.Size(186, 55);
            this.btnXoa.TabIndex = 17;
            this.btnXoa.Text = "Xóa";
            this.btnXoa.UseVisualStyleBackColor = true;
            this.btnXoa.Click += new System.EventHandler(this.btnXoa_Click);
            // 
            // btnSua
            // 
            this.btnSua.Location = new System.Drawing.Point(1238, 153);
            this.btnSua.Name = "btnSua";
            this.btnSua.Size = new System.Drawing.Size(186, 55);
            this.btnSua.TabIndex = 16;
            this.btnSua.Text = "Sửa";
            this.btnSua.UseVisualStyleBackColor = true;
            this.btnSua.Click += new System.EventHandler(this.btnSua_Click);
            // 
            // btnThem
            // 
            this.btnThem.Location = new System.Drawing.Point(1238, 67);
            this.btnThem.Name = "btnThem";
            this.btnThem.Size = new System.Drawing.Size(186, 55);
            this.btnThem.TabIndex = 15;
            this.btnThem.Text = "Thêm";
            this.btnThem.UseVisualStyleBackColor = true;
            this.btnThem.Click += new System.EventHandler(this.btnThem_Click);
            // 
            // cbbnganh
            // 
            this.cbbnganh.FormattingEnabled = true;
            this.cbbnganh.Location = new System.Drawing.Point(808, 67);
            this.cbbnganh.Name = "cbbnganh";
            this.cbbnganh.Size = new System.Drawing.Size(319, 33);
            this.cbbnganh.TabIndex = 12;
            this.cbbnganh.Text = "--Chọn Ngành--";
            // 
            // txttenlop
            // 
            this.txttenlop.Location = new System.Drawing.Point(134, 133);
            this.txttenlop.Name = "txttenlop";
            this.txttenlop.Size = new System.Drawing.Size(325, 31);
            this.txttenlop.TabIndex = 8;
            // 
            // txtlop
            // 
            this.txtlop.Location = new System.Drawing.Point(132, 67);
            this.txtlop.Name = "txtlop";
            this.txtlop.Size = new System.Drawing.Size(326, 31);
            this.txtlop.TabIndex = 7;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(652, 73);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(75, 25);
            this.label5.TabIndex = 4;
            this.label5.Text = "Ngành";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(22, 139);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(91, 25);
            this.label2.TabIndex = 1;
            this.label2.Text = "Tên Lớp";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(22, 73);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(77, 25);
            this.label1.TabIndex = 0;
            this.label1.Text = "Mã lớp";
            // 
            // ucQuanLyLop
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.groupBoxttSinhVien);
            this.Controls.Add(this.dgrlop);
            this.Controls.Add(this.Export);
            this.Controls.Add(this.label10);
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "ucQuanLyLop";
            this.Size = new System.Drawing.Size(1580, 1148);
            this.Load += new System.EventHandler(this.ucQuanLyLop_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgrlop)).EndInit();
            this.groupBoxttSinhVien.ResumeLayout(false);
            this.groupBoxttSinhVien.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Button Export;
        private System.Windows.Forms.DataGridView dgrlop;
        private System.Windows.Forms.DataGridViewTextBoxColumn MaLop;
        private System.Windows.Forms.DataGridViewTextBoxColumn TenLop;
        private System.Windows.Forms.DataGridViewTextBoxColumn MaNganh;
        private System.Windows.Forms.GroupBox groupBoxttSinhVien;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox txttktl;
        private System.Windows.Forms.TextBox txttkml;
        private System.Windows.Forms.Button btnTimKiem;
        private System.Windows.Forms.Button btnXoa;
        private System.Windows.Forms.Button btnSua;
        private System.Windows.Forms.Button btnThem;
        private System.Windows.Forms.ComboBox cbbnganh;
        private System.Windows.Forms.TextBox txttenlop;
        private System.Windows.Forms.TextBox txtlop;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
    }
}
