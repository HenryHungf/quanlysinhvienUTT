namespace quanlysinhvien.quanly_usercontrol
{
    partial class ucQuanLyHocBong
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
            this.dgrhocbong = new System.Windows.Forms.DataGridView();
            this.MaSV = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TenHocBong = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.GiaTri = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.groupBoxtMonHoc = new System.Windows.Forms.GroupBox();
            this.cbbutkmasv = new System.Windows.Forms.ComboBox();
            this.txttktenhb = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.cbbmasv = new System.Windows.Forms.ComboBox();
            this.label9 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.btntk = new System.Windows.Forms.Button();
            this.btnxoa = new System.Windows.Forms.Button();
            this.btnsua = new System.Windows.Forms.Button();
            this.btnthem = new System.Windows.Forms.Button();
            this.txtgiatri = new System.Windows.Forms.TextBox();
            this.txttenhb = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.Export = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgrhocbong)).BeginInit();
            this.groupBoxtMonHoc.SuspendLayout();
            this.SuspendLayout();
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.BackColor = System.Drawing.Color.Wheat;
            this.label10.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.label10.Location = new System.Drawing.Point(46, 34);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(430, 55);
            this.label10.TabIndex = 25;
            this.label10.Text = "Quản lý Học Bổng";
            // 
            // dgrhocbong
            // 
            this.dgrhocbong.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgrhocbong.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.MaSV,
            this.TenHocBong,
            this.GiaTri});
            this.dgrhocbong.Location = new System.Drawing.Point(42, 111);
            this.dgrhocbong.Name = "dgrhocbong";
            this.dgrhocbong.RowHeadersWidth = 82;
            this.dgrhocbong.RowTemplate.Height = 33;
            this.dgrhocbong.Size = new System.Drawing.Size(1484, 475);
            this.dgrhocbong.TabIndex = 26;
            this.dgrhocbong.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgrhocbong_CellClick);
            // 
            // MaSV
            // 
            this.MaSV.HeaderText = "Mã sinh viên";
            this.MaSV.MinimumWidth = 6;
            this.MaSV.Name = "MaSV";
            this.MaSV.Width = 125;
            // 
            // TenHocBong
            // 
            this.TenHocBong.HeaderText = "Tên học bổng";
            this.TenHocBong.MinimumWidth = 6;
            this.TenHocBong.Name = "TenHocBong";
            this.TenHocBong.Width = 125;
            // 
            // GiaTri
            // 
            this.GiaTri.HeaderText = "Giá trị";
            this.GiaTri.MinimumWidth = 6;
            this.GiaTri.Name = "GiaTri";
            this.GiaTri.Width = 125;
            // 
            // groupBoxtMonHoc
            // 
            this.groupBoxtMonHoc.Controls.Add(this.cbbutkmasv);
            this.groupBoxtMonHoc.Controls.Add(this.txttktenhb);
            this.groupBoxtMonHoc.Controls.Add(this.label3);
            this.groupBoxtMonHoc.Controls.Add(this.cbbmasv);
            this.groupBoxtMonHoc.Controls.Add(this.label9);
            this.groupBoxtMonHoc.Controls.Add(this.label8);
            this.groupBoxtMonHoc.Controls.Add(this.btntk);
            this.groupBoxtMonHoc.Controls.Add(this.btnxoa);
            this.groupBoxtMonHoc.Controls.Add(this.btnsua);
            this.groupBoxtMonHoc.Controls.Add(this.btnthem);
            this.groupBoxtMonHoc.Controls.Add(this.txtgiatri);
            this.groupBoxtMonHoc.Controls.Add(this.txttenhb);
            this.groupBoxtMonHoc.Controls.Add(this.label6);
            this.groupBoxtMonHoc.Controls.Add(this.label2);
            this.groupBoxtMonHoc.Controls.Add(this.label1);
            this.groupBoxtMonHoc.Location = new System.Drawing.Point(42, 622);
            this.groupBoxtMonHoc.Name = "groupBoxtMonHoc";
            this.groupBoxtMonHoc.Size = new System.Drawing.Size(1484, 489);
            this.groupBoxtMonHoc.TabIndex = 27;
            this.groupBoxtMonHoc.TabStop = false;
            this.groupBoxtMonHoc.Text = "Thông tin học bổng";
            // 
            // cbbutkmasv
            // 
            this.cbbutkmasv.FormattingEnabled = true;
            this.cbbutkmasv.Location = new System.Drawing.Point(164, 414);
            this.cbbutkmasv.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.cbbutkmasv.Name = "cbbutkmasv";
            this.cbbutkmasv.Size = new System.Drawing.Size(372, 33);
            this.cbbutkmasv.TabIndex = 26;
            // 
            // txttktenhb
            // 
            this.txttktenhb.Location = new System.Drawing.Point(784, 406);
            this.txttktenhb.Multiline = true;
            this.txttktenhb.Name = "txttktenhb";
            this.txttktenhb.Size = new System.Drawing.Size(316, 46);
            this.txttktenhb.TabIndex = 25;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(618, 427);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(150, 25);
            this.label3.TabIndex = 24;
            this.label3.Text = "Tên học bổng:";
            // 
            // cbbmasv
            // 
            this.cbbmasv.FormattingEnabled = true;
            this.cbbmasv.Location = new System.Drawing.Point(164, 73);
            this.cbbmasv.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.cbbmasv.Name = "cbbmasv";
            this.cbbmasv.Size = new System.Drawing.Size(474, 33);
            this.cbbmasv.TabIndex = 23;
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
            this.label8.Size = new System.Drawing.Size(140, 25);
            this.label8.TabIndex = 21;
            this.label8.Text = "Mã sinh viên:";
            // 
            // btntk
            // 
            this.btntk.Location = new System.Drawing.Point(1238, 397);
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
            // txtgiatri
            // 
            this.txtgiatri.Location = new System.Drawing.Point(164, 250);
            this.txtgiatri.Name = "txtgiatri";
            this.txtgiatri.Size = new System.Drawing.Size(474, 31);
            this.txtgiatri.TabIndex = 14;
            // 
            // txttenhb
            // 
            this.txttenhb.Location = new System.Drawing.Point(164, 153);
            this.txttenhb.Name = "txttenhb";
            this.txttenhb.Size = new System.Drawing.Size(474, 31);
            this.txttenhb.TabIndex = 8;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(6, 259);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(75, 25);
            this.label6.TabIndex = 5;
            this.label6.Text = "Giá trị:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(6, 169);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(150, 25);
            this.label2.TabIndex = 1;
            this.label2.Text = "Tên học bổng:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 73);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(140, 25);
            this.label1.TabIndex = 0;
            this.label1.Text = "Mã sinh viên:";
            // 
            // Export
            // 
            this.Export.BackColor = System.Drawing.Color.Coral;
            this.Export.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.875F, ((System.Drawing.FontStyle)(((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic) 
                | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.Export.Location = new System.Drawing.Point(1280, 34);
            this.Export.Name = "Export";
            this.Export.Size = new System.Drawing.Size(186, 55);
            this.Export.TabIndex = 31;
            this.Export.Text = "Xuất Excel";
            this.Export.UseVisualStyleBackColor = false;
            this.Export.Click += new System.EventHandler(this.Export_Click);
            // 
            // ucQuanLyHocBong
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.Export);
            this.Controls.Add(this.groupBoxtMonHoc);
            this.Controls.Add(this.dgrhocbong);
            this.Controls.Add(this.label10);
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "ucQuanLyHocBong";
            this.Size = new System.Drawing.Size(1580, 1148);
            this.Load += new System.EventHandler(this.ucQuanLyHocBong_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgrhocbong)).EndInit();
            this.groupBoxtMonHoc.ResumeLayout(false);
            this.groupBoxtMonHoc.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.DataGridView dgrhocbong;
        private System.Windows.Forms.DataGridViewTextBoxColumn MaSV;
        private System.Windows.Forms.DataGridViewTextBoxColumn TenHocBong;
        private System.Windows.Forms.DataGridViewTextBoxColumn GiaTri;
        private System.Windows.Forms.GroupBox groupBoxtMonHoc;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Button btntk;
        private System.Windows.Forms.Button btnxoa;
        private System.Windows.Forms.Button btnsua;
        private System.Windows.Forms.Button btnthem;
        private System.Windows.Forms.TextBox txtgiatri;
        private System.Windows.Forms.TextBox txttenhb;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cbbmasv;
        private System.Windows.Forms.TextBox txttktenhb;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox cbbutkmasv;
        private System.Windows.Forms.Button Export;
    }
}
