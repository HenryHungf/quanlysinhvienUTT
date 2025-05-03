namespace quanlysinhvien.quanly_usercontrol
{
    partial class ucQuanLyKhoaNamHoc
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
            this.dgrkhoanamhoc = new System.Windows.Forms.DataGridView();
            this.MaKhoaHoc = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.NamBatDau = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.NamKetThuc = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.groupBoxtMonHoc = new System.Windows.Forms.GroupBox();
            this.label9 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.txttkkh = new System.Windows.Forms.TextBox();
            this.btntk = new System.Windows.Forms.Button();
            this.btnxoa = new System.Windows.Forms.Button();
            this.btnsua = new System.Windows.Forms.Button();
            this.btnthem = new System.Windows.Forms.Button();
            this.txtnamkt = new System.Windows.Forms.TextBox();
            this.txtnambd = new System.Windows.Forms.TextBox();
            this.txtmakh = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dgrkhoanamhoc)).BeginInit();
            this.groupBoxtMonHoc.SuspendLayout();
            this.SuspendLayout();
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.BackColor = System.Drawing.Color.Wheat;
            this.label10.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.label10.Location = new System.Drawing.Point(28, 22);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(549, 55);
            this.label10.TabIndex = 24;
            this.label10.Text = "Quản lý Khóa Năm Học";
            // 
            // dgrkhoanamhoc
            // 
            this.dgrkhoanamhoc.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgrkhoanamhoc.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.MaKhoaHoc,
            this.NamBatDau,
            this.NamKetThuc});
            this.dgrkhoanamhoc.Location = new System.Drawing.Point(38, 100);
            this.dgrkhoanamhoc.Name = "dgrkhoanamhoc";
            this.dgrkhoanamhoc.RowHeadersWidth = 82;
            this.dgrkhoanamhoc.RowTemplate.Height = 33;
            this.dgrkhoanamhoc.Size = new System.Drawing.Size(1484, 475);
            this.dgrkhoanamhoc.TabIndex = 25;
            this.dgrkhoanamhoc.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgrkhoanamhoc_CellClick);
            // 
            // MaKhoaHoc
            // 
            this.MaKhoaHoc.HeaderText = "Mã khóa học";
            this.MaKhoaHoc.MinimumWidth = 6;
            this.MaKhoaHoc.Name = "MaKhoaHoc";
            this.MaKhoaHoc.Width = 125;
            // 
            // NamBatDau
            // 
            this.NamBatDau.HeaderText = "Năm bắt đầu";
            this.NamBatDau.MinimumWidth = 6;
            this.NamBatDau.Name = "NamBatDau";
            this.NamBatDau.Width = 125;
            // 
            // NamKetThuc
            // 
            this.NamKetThuc.HeaderText = "Năm kết thúc";
            this.NamKetThuc.MinimumWidth = 6;
            this.NamKetThuc.Name = "NamKetThuc";
            this.NamKetThuc.Width = 125;
            // 
            // groupBoxtMonHoc
            // 
            this.groupBoxtMonHoc.Controls.Add(this.label9);
            this.groupBoxtMonHoc.Controls.Add(this.label8);
            this.groupBoxtMonHoc.Controls.Add(this.txttkkh);
            this.groupBoxtMonHoc.Controls.Add(this.btntk);
            this.groupBoxtMonHoc.Controls.Add(this.btnxoa);
            this.groupBoxtMonHoc.Controls.Add(this.btnsua);
            this.groupBoxtMonHoc.Controls.Add(this.btnthem);
            this.groupBoxtMonHoc.Controls.Add(this.txtnamkt);
            this.groupBoxtMonHoc.Controls.Add(this.txtnambd);
            this.groupBoxtMonHoc.Controls.Add(this.txtmakh);
            this.groupBoxtMonHoc.Controls.Add(this.label6);
            this.groupBoxtMonHoc.Controls.Add(this.label2);
            this.groupBoxtMonHoc.Controls.Add(this.label1);
            this.groupBoxtMonHoc.Location = new System.Drawing.Point(38, 609);
            this.groupBoxtMonHoc.Name = "groupBoxtMonHoc";
            this.groupBoxtMonHoc.Size = new System.Drawing.Size(1484, 489);
            this.groupBoxtMonHoc.TabIndex = 26;
            this.groupBoxtMonHoc.TabStop = false;
            this.groupBoxtMonHoc.Text = "Thông tin khóa năm học";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(822, 362);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(0, 25);
            this.label9.TabIndex = 22;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(6, 427);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(142, 25);
            this.label8.TabIndex = 21;
            this.label8.Text = "Mã khóa học:";
            // 
            // txttkkh
            // 
            this.txttkkh.Location = new System.Drawing.Point(164, 406);
            this.txttkkh.Multiline = true;
            this.txttkkh.Name = "txttkkh";
            this.txttkkh.Size = new System.Drawing.Size(316, 46);
            this.txttkkh.TabIndex = 19;
            // 
            // btntk
            // 
            this.btntk.Location = new System.Drawing.Point(550, 397);
            this.btntk.Name = "btntk";
            this.btntk.Size = new System.Drawing.Size(186, 55);
            this.btntk.TabIndex = 18;
            this.btntk.Text = "Tìm kiếm";
            this.btntk.UseVisualStyleBackColor = true;
            this.btntk.Click += new System.EventHandler(this.btntk_Click);
            // 
            // btnxoa
            // 
            this.btnxoa.Location = new System.Drawing.Point(1238, 250);
            this.btnxoa.Name = "btnxoa";
            this.btnxoa.Size = new System.Drawing.Size(186, 55);
            this.btnxoa.TabIndex = 17;
            this.btnxoa.Text = "Xóa";
            this.btnxoa.UseVisualStyleBackColor = true;
            this.btnxoa.Click += new System.EventHandler(this.btnxoa_Click);
            // 
            // btnsua
            // 
            this.btnsua.Location = new System.Drawing.Point(1238, 153);
            this.btnsua.Name = "btnsua";
            this.btnsua.Size = new System.Drawing.Size(186, 55);
            this.btnsua.TabIndex = 16;
            this.btnsua.Text = "Sửa";
            this.btnsua.UseVisualStyleBackColor = true;
            this.btnsua.Click += new System.EventHandler(this.btnsua_Click);
            // 
            // btnthem
            // 
            this.btnthem.Location = new System.Drawing.Point(1238, 67);
            this.btnthem.Name = "btnthem";
            this.btnthem.Size = new System.Drawing.Size(186, 55);
            this.btnthem.TabIndex = 15;
            this.btnthem.Text = "Thêm";
            this.btnthem.UseVisualStyleBackColor = true;
            this.btnthem.Click += new System.EventHandler(this.btnthem_Click);
            // 
            // txtnamkt
            // 
            this.txtnamkt.Location = new System.Drawing.Point(164, 250);
            this.txtnamkt.Name = "txtnamkt";
            this.txtnamkt.Size = new System.Drawing.Size(474, 31);
            this.txtnamkt.TabIndex = 14;
            // 
            // txtnambd
            // 
            this.txtnambd.Location = new System.Drawing.Point(164, 153);
            this.txtnambd.Name = "txtnambd";
            this.txtnambd.Size = new System.Drawing.Size(474, 31);
            this.txtnambd.TabIndex = 8;
            // 
            // txtmakh
            // 
            this.txtmakh.Location = new System.Drawing.Point(164, 67);
            this.txtmakh.Name = "txtmakh";
            this.txtmakh.Size = new System.Drawing.Size(474, 31);
            this.txtmakh.TabIndex = 7;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(6, 259);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(144, 25);
            this.label6.TabIndex = 5;
            this.label6.Text = "Năm kết thúc:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(6, 169);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(140, 25);
            this.label2.TabIndex = 1;
            this.label2.Text = "Năm bắt đầu:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 73);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(142, 25);
            this.label1.TabIndex = 0;
            this.label1.Text = "Mã khóa học:";
            // 
            // ucQuanLyKhoaNamHoc
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.groupBoxtMonHoc);
            this.Controls.Add(this.dgrkhoanamhoc);
            this.Controls.Add(this.label10);
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "ucQuanLyKhoaNamHoc";
            this.Size = new System.Drawing.Size(1580, 1148);
            this.Load += new System.EventHandler(this.ucQuanLyKhoaNamHoc_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgrkhoanamhoc)).EndInit();
            this.groupBoxtMonHoc.ResumeLayout(false);
            this.groupBoxtMonHoc.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.DataGridView dgrkhoanamhoc;
        private System.Windows.Forms.GroupBox groupBoxtMonHoc;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox txttkkh;
        private System.Windows.Forms.Button btntk;
        private System.Windows.Forms.Button btnxoa;
        private System.Windows.Forms.Button btnsua;
        private System.Windows.Forms.Button btnthem;
        private System.Windows.Forms.TextBox txtnamkt;
        private System.Windows.Forms.TextBox txtnambd;
        private System.Windows.Forms.TextBox txtmakh;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridViewTextBoxColumn MaKhoaHoc;
        private System.Windows.Forms.DataGridViewTextBoxColumn NamBatDau;
        private System.Windows.Forms.DataGridViewTextBoxColumn NamKetThuc;
    }
}
