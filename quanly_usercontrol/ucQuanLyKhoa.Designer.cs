namespace quanlysinhvien.quanly_usercontrol
{
    partial class ucQuanLyKhoa
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
            this.dgrKhoa = new System.Windows.Forms.DataGridView();
            this.MaKhoa = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TenKhoa = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.groupBoxtMonHoc = new System.Windows.Forms.GroupBox();
            this.txttkmakh = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.txttktenkh = new System.Windows.Forms.TextBox();
            this.btntk = new System.Windows.Forms.Button();
            this.btnxoa = new System.Windows.Forms.Button();
            this.btnsua = new System.Windows.Forms.Button();
            this.btnthem = new System.Windows.Forms.Button();
            this.txttenkh = new System.Windows.Forms.TextBox();
            this.txtmakh = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dgrKhoa)).BeginInit();
            this.groupBoxtMonHoc.SuspendLayout();
            this.SuspendLayout();
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.BackColor = System.Drawing.Color.Wheat;
            this.label10.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.label10.Location = new System.Drawing.Point(40, 31);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(327, 55);
            this.label10.TabIndex = 25;
            this.label10.Text = "Quản lý Khoa";
            // 
            // dgrKhoa
            // 
            this.dgrKhoa.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgrKhoa.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.MaKhoa,
            this.TenKhoa});
            this.dgrKhoa.Location = new System.Drawing.Point(36, 108);
            this.dgrKhoa.Name = "dgrKhoa";
            this.dgrKhoa.RowHeadersWidth = 82;
            this.dgrKhoa.RowTemplate.Height = 33;
            this.dgrKhoa.Size = new System.Drawing.Size(1484, 475);
            this.dgrKhoa.TabIndex = 26;
            this.dgrKhoa.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgrKhoa_CellClick);
            // 
            // MaKhoa
            // 
            this.MaKhoa.HeaderText = "Mã khoa";
            this.MaKhoa.MinimumWidth = 6;
            this.MaKhoa.Name = "MaKhoa";
            this.MaKhoa.Width = 125;
            // 
            // TenKhoa
            // 
            this.TenKhoa.HeaderText = "Tên khoa";
            this.TenKhoa.MinimumWidth = 6;
            this.TenKhoa.Name = "TenKhoa";
            this.TenKhoa.Width = 125;
            // 
            // groupBoxtMonHoc
            // 
            this.groupBoxtMonHoc.Controls.Add(this.txttkmakh);
            this.groupBoxtMonHoc.Controls.Add(this.label3);
            this.groupBoxtMonHoc.Controls.Add(this.label9);
            this.groupBoxtMonHoc.Controls.Add(this.label8);
            this.groupBoxtMonHoc.Controls.Add(this.txttktenkh);
            this.groupBoxtMonHoc.Controls.Add(this.btntk);
            this.groupBoxtMonHoc.Controls.Add(this.btnxoa);
            this.groupBoxtMonHoc.Controls.Add(this.btnsua);
            this.groupBoxtMonHoc.Controls.Add(this.btnthem);
            this.groupBoxtMonHoc.Controls.Add(this.txttenkh);
            this.groupBoxtMonHoc.Controls.Add(this.txtmakh);
            this.groupBoxtMonHoc.Controls.Add(this.label2);
            this.groupBoxtMonHoc.Controls.Add(this.label1);
            this.groupBoxtMonHoc.Location = new System.Drawing.Point(36, 612);
            this.groupBoxtMonHoc.Name = "groupBoxtMonHoc";
            this.groupBoxtMonHoc.Size = new System.Drawing.Size(1484, 489);
            this.groupBoxtMonHoc.TabIndex = 27;
            this.groupBoxtMonHoc.TabStop = false;
            this.groupBoxtMonHoc.Text = "Thông tin khoa";
            // 
            // txttkmakh
            // 
            this.txttkmakh.Location = new System.Drawing.Point(230, 403);
            this.txttkmakh.Multiline = true;
            this.txttkmakh.Name = "txttkmakh";
            this.txttkmakh.Size = new System.Drawing.Size(316, 46);
            this.txttkmakh.TabIndex = 24;
            this.txttkmakh.WordWrap = false;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(106, 427);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(101, 25);
            this.label3.TabIndex = 23;
            this.label3.Text = "Mã khoa:";
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
            this.label8.Location = new System.Drawing.Point(692, 427);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(101, 25);
            this.label8.TabIndex = 21;
            this.label8.Text = "tên khoa:";
            // 
            // txttktenkh
            // 
            this.txttktenkh.Location = new System.Drawing.Point(848, 403);
            this.txttktenkh.Multiline = true;
            this.txttktenkh.Name = "txttktenkh";
            this.txttktenkh.Size = new System.Drawing.Size(316, 46);
            this.txttktenkh.TabIndex = 19;
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
            // txttenkh
            // 
            this.txttenkh.Location = new System.Drawing.Point(164, 153);
            this.txttenkh.Name = "txttenkh";
            this.txttenkh.Size = new System.Drawing.Size(474, 31);
            this.txttenkh.TabIndex = 8;
            // 
            // txtmakh
            // 
            this.txtmakh.Location = new System.Drawing.Point(164, 67);
            this.txtmakh.Name = "txtmakh";
            this.txtmakh.Size = new System.Drawing.Size(474, 31);
            this.txtmakh.TabIndex = 7;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(6, 169);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(108, 25);
            this.label2.TabIndex = 1;
            this.label2.Text = "Tên khoa:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 73);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(101, 25);
            this.label1.TabIndex = 0;
            this.label1.Text = "Mã khoa:";
            // 
            // ucQuanLyKhoa
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.groupBoxtMonHoc);
            this.Controls.Add(this.dgrKhoa);
            this.Controls.Add(this.label10);
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "ucQuanLyKhoa";
            this.Size = new System.Drawing.Size(1580, 1148);
            this.Load += new System.EventHandler(this.ucQuanLyKhoa_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgrKhoa)).EndInit();
            this.groupBoxtMonHoc.ResumeLayout(false);
            this.groupBoxtMonHoc.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.DataGridView dgrKhoa;
        private System.Windows.Forms.GroupBox groupBoxtMonHoc;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox txttktenkh;
        private System.Windows.Forms.Button btntk;
        private System.Windows.Forms.Button btnxoa;
        private System.Windows.Forms.Button btnsua;
        private System.Windows.Forms.Button btnthem;
        private System.Windows.Forms.TextBox txttenkh;
        private System.Windows.Forms.TextBox txtmakh;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridViewTextBoxColumn MaKhoa;
        private System.Windows.Forms.DataGridViewTextBoxColumn TenKhoa;
        private System.Windows.Forms.TextBox txttkmakh;
        private System.Windows.Forms.Label label3;
    }
}
