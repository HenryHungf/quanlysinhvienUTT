namespace quanlysinhvien.quanly_usercontrol
{
    partial class ucQuanLyBaoLuu
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
            this.dataGridViewBaoLuu = new System.Windows.Forms.DataGridView();
            this.groupBoxBaoLuu = new System.Windows.Forms.GroupBox();
            this.comboBoxHotenBaoLuu = new System.Windows.Forms.ComboBox();
            this.comboBoxMaSV = new System.Windows.Forms.ComboBox();
            this.label9 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.txtSearchHotenBaoLuu = new System.Windows.Forms.TextBox();
            this.txtSearchMaSVBaoLuu = new System.Windows.Forms.TextBox();
            this.btnTimKiemsvBaoLuu = new System.Windows.Forms.Button();
            this.btnXoaBaoLuu = new System.Windows.Forms.Button();
            this.btnThemBaoLuu = new System.Windows.Forms.Button();
            this.comboBoxLopBaoLuu = new System.Windows.Forms.ComboBox();
            this.label7 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.Export = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewBaoLuu)).BeginInit();
            this.groupBoxBaoLuu.SuspendLayout();
            this.SuspendLayout();
            // 
            // dataGridViewBaoLuu
            // 
            this.dataGridViewBaoLuu.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewBaoLuu.Location = new System.Drawing.Point(47, 77);
            this.dataGridViewBaoLuu.Name = "dataGridViewBaoLuu";
            this.dataGridViewBaoLuu.RowHeadersWidth = 82;
            this.dataGridViewBaoLuu.RowTemplate.Height = 33;
            this.dataGridViewBaoLuu.Size = new System.Drawing.Size(1484, 486);
            this.dataGridViewBaoLuu.TabIndex = 6;
            this.dataGridViewBaoLuu.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridViewBaoLuu_CellClick);
            this.dataGridViewBaoLuu.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridViewBaoLuu_CellContentClick);
            // 
            // groupBoxBaoLuu
            // 
            this.groupBoxBaoLuu.Controls.Add(this.comboBoxHotenBaoLuu);
            this.groupBoxBaoLuu.Controls.Add(this.comboBoxMaSV);
            this.groupBoxBaoLuu.Controls.Add(this.label9);
            this.groupBoxBaoLuu.Controls.Add(this.label8);
            this.groupBoxBaoLuu.Controls.Add(this.txtSearchHotenBaoLuu);
            this.groupBoxBaoLuu.Controls.Add(this.txtSearchMaSVBaoLuu);
            this.groupBoxBaoLuu.Controls.Add(this.btnTimKiemsvBaoLuu);
            this.groupBoxBaoLuu.Controls.Add(this.btnXoaBaoLuu);
            this.groupBoxBaoLuu.Controls.Add(this.btnThemBaoLuu);
            this.groupBoxBaoLuu.Controls.Add(this.comboBoxLopBaoLuu);
            this.groupBoxBaoLuu.Controls.Add(this.label7);
            this.groupBoxBaoLuu.Controls.Add(this.label2);
            this.groupBoxBaoLuu.Controls.Add(this.label1);
            this.groupBoxBaoLuu.Location = new System.Drawing.Point(47, 583);
            this.groupBoxBaoLuu.Name = "groupBoxBaoLuu";
            this.groupBoxBaoLuu.Size = new System.Drawing.Size(1484, 523);
            this.groupBoxBaoLuu.TabIndex = 5;
            this.groupBoxBaoLuu.TabStop = false;
            this.groupBoxBaoLuu.Text = "Thông tin Sinh Viên Bảo Lưu";
            // 
            // comboBoxHotenBaoLuu
            // 
            this.comboBoxHotenBaoLuu.FormattingEnabled = true;
            this.comboBoxHotenBaoLuu.Location = new System.Drawing.Point(465, 194);
            this.comboBoxHotenBaoLuu.Name = "comboBoxHotenBaoLuu";
            this.comboBoxHotenBaoLuu.Size = new System.Drawing.Size(319, 33);
            this.comboBoxHotenBaoLuu.TabIndex = 24;
            this.comboBoxHotenBaoLuu.SelectedIndexChanged += new System.EventHandler(this.comboBoxHotenBaoLuu_SelectedIndexChanged);
            // 
            // comboBoxMaSV
            // 
            this.comboBoxMaSV.FormattingEnabled = true;
            this.comboBoxMaSV.Location = new System.Drawing.Point(465, 118);
            this.comboBoxMaSV.Name = "comboBoxMaSV";
            this.comboBoxMaSV.Size = new System.Drawing.Size(319, 33);
            this.comboBoxMaSV.TabIndex = 23;
            this.comboBoxMaSV.SelectedIndexChanged += new System.EventHandler(this.comboBoxMaSV_SelectedIndexChanged);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(858, 363);
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
            // txtSearchHotenBaoLuu
            // 
            this.txtSearchHotenBaoLuu.Location = new System.Drawing.Point(808, 406);
            this.txtSearchHotenBaoLuu.Multiline = true;
            this.txtSearchHotenBaoLuu.Name = "txtSearchHotenBaoLuu";
            this.txtSearchHotenBaoLuu.Size = new System.Drawing.Size(328, 58);
            this.txtSearchHotenBaoLuu.TabIndex = 20;
            // 
            // txtSearchMaSVBaoLuu
            // 
            this.txtSearchMaSVBaoLuu.Location = new System.Drawing.Point(429, 406);
            this.txtSearchMaSVBaoLuu.Multiline = true;
            this.txtSearchMaSVBaoLuu.Name = "txtSearchMaSVBaoLuu";
            this.txtSearchMaSVBaoLuu.Size = new System.Drawing.Size(246, 58);
            this.txtSearchMaSVBaoLuu.TabIndex = 19;
            // 
            // btnTimKiemsvBaoLuu
            // 
            this.btnTimKiemsvBaoLuu.Location = new System.Drawing.Point(120, 406);
            this.btnTimKiemsvBaoLuu.Name = "btnTimKiemsvBaoLuu";
            this.btnTimKiemsvBaoLuu.Size = new System.Drawing.Size(186, 54);
            this.btnTimKiemsvBaoLuu.TabIndex = 18;
            this.btnTimKiemsvBaoLuu.Text = "Tìm kiếm";
            this.btnTimKiemsvBaoLuu.UseVisualStyleBackColor = true;
            this.btnTimKiemsvBaoLuu.Click += new System.EventHandler(this.btnTimKiemsvBaoLuu_Click);
            // 
            // btnXoaBaoLuu
            // 
            this.btnXoaBaoLuu.Location = new System.Drawing.Point(1237, 173);
            this.btnXoaBaoLuu.Name = "btnXoaBaoLuu";
            this.btnXoaBaoLuu.Size = new System.Drawing.Size(186, 54);
            this.btnXoaBaoLuu.TabIndex = 17;
            this.btnXoaBaoLuu.Text = "Xóa";
            this.btnXoaBaoLuu.UseVisualStyleBackColor = true;
            this.btnXoaBaoLuu.Click += new System.EventHandler(this.btnXoaBaoLuu_Click);
            // 
            // btnThemBaoLuu
            // 
            this.btnThemBaoLuu.Location = new System.Drawing.Point(1237, 67);
            this.btnThemBaoLuu.Name = "btnThemBaoLuu";
            this.btnThemBaoLuu.Size = new System.Drawing.Size(186, 54);
            this.btnThemBaoLuu.TabIndex = 15;
            this.btnThemBaoLuu.Text = "Thêm";
            this.btnThemBaoLuu.UseVisualStyleBackColor = true;
            this.btnThemBaoLuu.Click += new System.EventHandler(this.btnThemBaoLuu_Click);
            // 
            // comboBoxLopBaoLuu
            // 
            this.comboBoxLopBaoLuu.FormattingEnabled = true;
            this.comboBoxLopBaoLuu.Location = new System.Drawing.Point(465, 40);
            this.comboBoxLopBaoLuu.Name = "comboBoxLopBaoLuu";
            this.comboBoxLopBaoLuu.Size = new System.Drawing.Size(319, 33);
            this.comboBoxLopBaoLuu.TabIndex = 13;
            this.comboBoxLopBaoLuu.SelectedIndexChanged += new System.EventHandler(this.comboBoxLopBaoLuu_SelectedIndexChanged_1);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(348, 43);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(48, 25);
            this.label7.TabIndex = 6;
            this.label7.Text = "Lớp";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(348, 202);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(104, 25);
            this.label2.TabIndex = 1;
            this.label2.Text = "Họ và tên";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(348, 118);
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
            this.label10.Location = new System.Drawing.Point(46, 10);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(397, 55);
            this.label10.TabIndex = 7;
            this.label10.Text = "Quản lý Bảo Lưu";
            this.label10.Click += new System.EventHandler(this.label10_Click);
            // 
            // Export
            // 
            this.Export.BackColor = System.Drawing.Color.Coral;
            this.Export.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.875F, ((System.Drawing.FontStyle)(((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic) 
                | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.Export.Location = new System.Drawing.Point(1345, 10);
            this.Export.Name = "Export";
            this.Export.Size = new System.Drawing.Size(186, 54);
            this.Export.TabIndex = 30;
            this.Export.Text = "Xuất Excel";
            this.Export.UseVisualStyleBackColor = false;
            this.Export.Click += new System.EventHandler(this.Export_Click);
            // 
            // ucQuanLyBaoLuu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.Export);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.dataGridViewBaoLuu);
            this.Controls.Add(this.groupBoxBaoLuu);
            this.Name = "ucQuanLyBaoLuu";
            this.Size = new System.Drawing.Size(1579, 1149);
            this.Load += new System.EventHandler(this.ucQuanLyBaoLuu_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewBaoLuu)).EndInit();
            this.groupBoxBaoLuu.ResumeLayout(false);
            this.groupBoxBaoLuu.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridViewBaoLuu;
        private System.Windows.Forms.GroupBox groupBoxBaoLuu;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox txtSearchHotenBaoLuu;
        private System.Windows.Forms.TextBox txtSearchMaSVBaoLuu;
        private System.Windows.Forms.Button btnTimKiemsvBaoLuu;
        private System.Windows.Forms.Button btnXoaBaoLuu;
        private System.Windows.Forms.Button btnThemBaoLuu;
        private System.Windows.Forms.ComboBox comboBoxLopBaoLuu;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.ComboBox comboBoxHotenBaoLuu;
        private System.Windows.Forms.ComboBox comboBoxMaSV;
        private System.Windows.Forms.Button Export;
    }
}
