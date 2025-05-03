namespace quanlysinhvien.quanly_usercontrol
{
    partial class ucQuanLySinhVien
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
            this.dgrsv = new System.Windows.Forms.DataGridView();
            this.MaSV = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.HoTen = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.NgaySinh = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DiaChi = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.GioiTinh = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DienThoai = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.MaLop = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.MaKhoaHoc = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.btntk = new System.Windows.Forms.Button();
            this.cbbtklop = new System.Windows.Forms.ComboBox();
            this.label9 = new System.Windows.Forms.Label();
            this.txttkmasv = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.txtdt = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.cbbkhoa = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.cbblop = new System.Windows.Forms.ComboBox();
            this.txtdc = new System.Windows.Forms.TextBox();
            this.cbbgt = new System.Windows.Forms.ComboBox();
            this.dtns = new System.Windows.Forms.DateTimePicker();
            this.label8 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.btnxoa = new System.Windows.Forms.Button();
            this.btnsua = new System.Windows.Forms.Button();
            this.btnthem = new System.Windows.Forms.Button();
            this.txtht = new System.Windows.Forms.TextBox();
            this.txtmasv = new System.Windows.Forms.TextBox();
            this.txt = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.Export = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgrsv)).BeginInit();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.BackColor = System.Drawing.Color.Wheat;
            this.label10.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.label10.Location = new System.Drawing.Point(30, 31);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(424, 55);
            this.label10.TabIndex = 25;
            this.label10.Text = "Quản lý Sinh Viên";
            // 
            // dgrsv
            // 
            this.dgrsv.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgrsv.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.MaSV,
            this.HoTen,
            this.NgaySinh,
            this.DiaChi,
            this.GioiTinh,
            this.DienThoai,
            this.MaLop,
            this.MaKhoaHoc});
            this.dgrsv.Location = new System.Drawing.Point(39, 112);
            this.dgrsv.Name = "dgrsv";
            this.dgrsv.RowHeadersWidth = 82;
            this.dgrsv.RowTemplate.Height = 33;
            this.dgrsv.Size = new System.Drawing.Size(1484, 475);
            this.dgrsv.TabIndex = 26;
            this.dgrsv.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgrkhoanamhoc_CellClick);
            // 
            // MaSV
            // 
            this.MaSV.HeaderText = "Mã sinh viên";
            this.MaSV.MinimumWidth = 6;
            this.MaSV.Name = "MaSV";
            this.MaSV.Width = 125;
            // 
            // HoTen
            // 
            this.HoTen.HeaderText = "Họ tên";
            this.HoTen.MinimumWidth = 6;
            this.HoTen.Name = "HoTen";
            this.HoTen.Width = 125;
            // 
            // NgaySinh
            // 
            this.NgaySinh.HeaderText = "Ngày sinh";
            this.NgaySinh.MinimumWidth = 6;
            this.NgaySinh.Name = "NgaySinh";
            this.NgaySinh.Width = 125;
            // 
            // DiaChi
            // 
            this.DiaChi.HeaderText = "Địa chỉ";
            this.DiaChi.MinimumWidth = 6;
            this.DiaChi.Name = "DiaChi";
            this.DiaChi.Width = 125;
            // 
            // GioiTinh
            // 
            this.GioiTinh.HeaderText = "Giới Tính";
            this.GioiTinh.MinimumWidth = 6;
            this.GioiTinh.Name = "GioiTinh";
            this.GioiTinh.Width = 125;
            // 
            // DienThoai
            // 
            this.DienThoai.HeaderText = "Điện thoại";
            this.DienThoai.MinimumWidth = 6;
            this.DienThoai.Name = "DienThoai";
            this.DienThoai.Width = 125;
            // 
            // MaLop
            // 
            this.MaLop.HeaderText = "Mã lớp";
            this.MaLop.MinimumWidth = 6;
            this.MaLop.Name = "MaLop";
            this.MaLop.Width = 125;
            // 
            // MaKhoaHoc
            // 
            this.MaKhoaHoc.HeaderText = "Mã khóa học";
            this.MaKhoaHoc.MinimumWidth = 6;
            this.MaKhoaHoc.Name = "MaKhoaHoc";
            this.MaKhoaHoc.Width = 125;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.btntk);
            this.groupBox2.Controls.Add(this.cbbtklop);
            this.groupBox2.Controls.Add(this.label9);
            this.groupBox2.Controls.Add(this.txttkmasv);
            this.groupBox2.Controls.Add(this.label5);
            this.groupBox2.Controls.Add(this.txtdt);
            this.groupBox2.Controls.Add(this.label2);
            this.groupBox2.Controls.Add(this.cbbkhoa);
            this.groupBox2.Controls.Add(this.label1);
            this.groupBox2.Controls.Add(this.cbblop);
            this.groupBox2.Controls.Add(this.txtdc);
            this.groupBox2.Controls.Add(this.cbbgt);
            this.groupBox2.Controls.Add(this.dtns);
            this.groupBox2.Controls.Add(this.label8);
            this.groupBox2.Controls.Add(this.label7);
            this.groupBox2.Controls.Add(this.label6);
            this.groupBox2.Controls.Add(this.label4);
            this.groupBox2.Controls.Add(this.btnxoa);
            this.groupBox2.Controls.Add(this.btnsua);
            this.groupBox2.Controls.Add(this.btnthem);
            this.groupBox2.Controls.Add(this.txtht);
            this.groupBox2.Controls.Add(this.txtmasv);
            this.groupBox2.Controls.Add(this.txt);
            this.groupBox2.Controls.Add(this.label3);
            this.groupBox2.Location = new System.Drawing.Point(39, 611);
            this.groupBox2.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Padding = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.groupBox2.Size = new System.Drawing.Size(1484, 502);
            this.groupBox2.TabIndex = 27;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Thông tin cho tiết sinh viên";
            // 
            // btntk
            // 
            this.btntk.Location = new System.Drawing.Point(1214, 391);
            this.btntk.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btntk.Name = "btntk";
            this.btntk.Size = new System.Drawing.Size(158, 47);
            this.btntk.TabIndex = 25;
            this.btntk.Text = "Tìm kiếm";
            this.btntk.UseVisualStyleBackColor = true;
            this.btntk.Click += new System.EventHandler(this.btntk_Click);
            // 
            // cbbtklop
            // 
            this.cbbtklop.FormattingEnabled = true;
            this.cbbtklop.Location = new System.Drawing.Point(648, 400);
            this.cbbtklop.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.cbbtklop.Name = "cbbtklop";
            this.cbbtklop.Size = new System.Drawing.Size(274, 33);
            this.cbbtklop.TabIndex = 24;
            this.cbbtklop.Text = "Chọn mã lớp";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(578, 408);
            this.label9.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(54, 25);
            this.label9.TabIndex = 23;
            this.label9.Text = "Lớp:";
            // 
            // txttkmasv
            // 
            this.txttkmasv.Location = new System.Drawing.Point(186, 403);
            this.txttkmasv.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txttkmasv.Name = "txttkmasv";
            this.txttkmasv.Size = new System.Drawing.Size(276, 31);
            this.txttkmasv.TabIndex = 22;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(46, 408);
            this.label5.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(140, 25);
            this.label5.TabIndex = 21;
            this.label5.Text = "Mã sinh viên:";
            // 
            // txtdt
            // 
            this.txtdt.Location = new System.Drawing.Point(650, 270);
            this.txtdt.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txtdt.Name = "txtdt";
            this.txtdt.Size = new System.Drawing.Size(274, 31);
            this.txtdt.TabIndex = 20;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(542, 275);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(115, 25);
            this.label2.TabIndex = 19;
            this.label2.Text = "Điện thoại:";
            // 
            // cbbkhoa
            // 
            this.cbbkhoa.FormattingEnabled = true;
            this.cbbkhoa.Location = new System.Drawing.Point(650, 194);
            this.cbbkhoa.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.cbbkhoa.Name = "cbbkhoa";
            this.cbbkhoa.Size = new System.Drawing.Size(274, 33);
            this.cbbkhoa.TabIndex = 18;
            this.cbbkhoa.Text = "Chọn khóa năm học";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(542, 197);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(68, 25);
            this.label1.TabIndex = 17;
            this.label1.Text = "Khóa:";
            // 
            // cbblop
            // 
            this.cbblop.FormattingEnabled = true;
            this.cbblop.Location = new System.Drawing.Point(650, 128);
            this.cbblop.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.cbblop.Name = "cbblop";
            this.cbblop.Size = new System.Drawing.Size(274, 33);
            this.cbblop.TabIndex = 16;
            this.cbblop.Text = "Chọn mã lớp";
            // 
            // txtdc
            // 
            this.txtdc.Location = new System.Drawing.Point(186, 270);
            this.txtdc.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txtdc.Name = "txtdc";
            this.txtdc.Size = new System.Drawing.Size(276, 31);
            this.txtdc.TabIndex = 15;
            // 
            // cbbgt
            // 
            this.cbbgt.FormattingEnabled = true;
            this.cbbgt.Items.AddRange(new object[] {
            "Nam",
            "Nữ"});
            this.cbbgt.Location = new System.Drawing.Point(648, 53);
            this.cbbgt.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.cbbgt.Name = "cbbgt";
            this.cbbgt.Size = new System.Drawing.Size(208, 33);
            this.cbbgt.TabIndex = 14;
            this.cbbgt.Text = "Chọn giới tính";
            // 
            // dtns
            // 
            this.dtns.Location = new System.Drawing.Point(186, 197);
            this.dtns.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.dtns.Name = "dtns";
            this.dtns.Size = new System.Drawing.Size(276, 31);
            this.dtns.TabIndex = 13;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(46, 270);
            this.label8.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(84, 25);
            this.label8.TabIndex = 12;
            this.label8.Text = "Địa chỉ:";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(537, 133);
            this.label7.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(54, 25);
            this.label7.TabIndex = 11;
            this.label7.Text = "Lớp:";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(542, 58);
            this.label6.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(97, 25);
            this.label6.TabIndex = 10;
            this.label6.Text = "Giới tính:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(46, 208);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(114, 25);
            this.label4.TabIndex = 9;
            this.label4.Text = "Ngày sinh:";
            // 
            // btnxoa
            // 
            this.btnxoa.Location = new System.Drawing.Point(1214, 248);
            this.btnxoa.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnxoa.Name = "btnxoa";
            this.btnxoa.Size = new System.Drawing.Size(158, 47);
            this.btnxoa.TabIndex = 7;
            this.btnxoa.Text = "Xóa";
            this.btnxoa.UseVisualStyleBackColor = true;
            this.btnxoa.Click += new System.EventHandler(this.btnxoa_Click);
            // 
            // btnsua
            // 
            this.btnsua.Location = new System.Drawing.Point(1214, 150);
            this.btnsua.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnsua.Name = "btnsua";
            this.btnsua.Size = new System.Drawing.Size(158, 47);
            this.btnsua.TabIndex = 6;
            this.btnsua.Text = "Sửa";
            this.btnsua.UseVisualStyleBackColor = true;
            this.btnsua.Click += new System.EventHandler(this.btnsua_Click);
            // 
            // btnthem
            // 
            this.btnthem.Location = new System.Drawing.Point(1214, 59);
            this.btnthem.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnthem.Name = "btnthem";
            this.btnthem.Size = new System.Drawing.Size(158, 47);
            this.btnthem.TabIndex = 5;
            this.btnthem.Text = "Thêm";
            this.btnthem.UseVisualStyleBackColor = true;
            this.btnthem.Click += new System.EventHandler(this.btnthem_Click);
            // 
            // txtht
            // 
            this.txtht.Location = new System.Drawing.Point(186, 133);
            this.txtht.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txtht.Name = "txtht";
            this.txtht.Size = new System.Drawing.Size(276, 31);
            this.txtht.TabIndex = 4;
            // 
            // txtmasv
            // 
            this.txtmasv.Location = new System.Drawing.Point(186, 55);
            this.txtmasv.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txtmasv.Name = "txtmasv";
            this.txtmasv.Size = new System.Drawing.Size(276, 31);
            this.txtmasv.TabIndex = 3;
            // 
            // txt
            // 
            this.txt.AutoSize = true;
            this.txt.Location = new System.Drawing.Point(46, 133);
            this.txt.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.txt.Name = "txt";
            this.txt.Size = new System.Drawing.Size(110, 25);
            this.txt.TabIndex = 2;
            this.txt.Text = "Họ và tên:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(46, 59);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(140, 25);
            this.label3.TabIndex = 1;
            this.label3.Text = "Mã sinh viên:";
            // 
            // Export
            // 
            this.Export.BackColor = System.Drawing.Color.Coral;
            this.Export.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.875F, ((System.Drawing.FontStyle)(((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic) 
                | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.Export.Location = new System.Drawing.Point(1252, 31);
            this.Export.Name = "Export";
            this.Export.Size = new System.Drawing.Size(186, 55);
            this.Export.TabIndex = 33;
            this.Export.Text = "Xuất Excel";
            this.Export.UseVisualStyleBackColor = false;
            this.Export.Click += new System.EventHandler(this.Export_Click);
            // 
            // ucQuanLySinhVien
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.Export);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.dgrsv);
            this.Controls.Add(this.label10);
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "ucQuanLySinhVien";
            this.Size = new System.Drawing.Size(1580, 1148);
            this.Load += new System.EventHandler(this.ucQuanLySinhVien_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgrsv)).EndInit();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.DataGridView dgrsv;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.ComboBox cbblop;
        private System.Windows.Forms.TextBox txtdc;
        private System.Windows.Forms.ComboBox cbbgt;
        private System.Windows.Forms.DateTimePicker dtns;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button btnxoa;
        private System.Windows.Forms.Button btnsua;
        private System.Windows.Forms.Button btnthem;
        private System.Windows.Forms.TextBox txtht;
        private System.Windows.Forms.TextBox txtmasv;
        private System.Windows.Forms.Label txt;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtdt;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox cbbkhoa;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridViewTextBoxColumn MaSV;
        private System.Windows.Forms.DataGridViewTextBoxColumn HoTen;
        private System.Windows.Forms.DataGridViewTextBoxColumn NgaySinh;
        private System.Windows.Forms.DataGridViewTextBoxColumn DiaChi;
        private System.Windows.Forms.DataGridViewTextBoxColumn GioiTinh;
        private System.Windows.Forms.DataGridViewTextBoxColumn DienThoai;
        private System.Windows.Forms.DataGridViewTextBoxColumn MaLop;
        private System.Windows.Forms.DataGridViewTextBoxColumn MaKhoaHoc;
        private System.Windows.Forms.Button btntk;
        private System.Windows.Forms.ComboBox cbbtklop;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox txttkmasv;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button Export;
    }
}
