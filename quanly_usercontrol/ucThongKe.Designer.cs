namespace quanlysinhvien.quanly_usercontrol
{
    partial class ucThongKe
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
            this.dgrtk = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.dgrtk)).BeginInit();
            this.SuspendLayout();
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.BackColor = System.Drawing.Color.Wheat;
            this.label10.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.label10.Location = new System.Drawing.Point(58, 38);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(241, 55);
            this.label10.TabIndex = 9;
            this.label10.Text = "Thống Kê";
            // 
            // dgrtk
            // 
            this.dgrtk.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgrtk.Location = new System.Drawing.Point(54, 148);
            this.dgrtk.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.dgrtk.Name = "dgrtk";
            this.dgrtk.RowHeadersWidth = 51;
            this.dgrtk.RowTemplate.Height = 24;
            this.dgrtk.Size = new System.Drawing.Size(1452, 908);
            this.dgrtk.TabIndex = 10;
            // 
            // ucThongKe
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.dgrtk);
            this.Controls.Add(this.label10);
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "ucThongKe";
            this.Size = new System.Drawing.Size(1580, 1148);
            this.Load += new System.EventHandler(this.ucThongKe_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgrtk)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.DataGridView dgrtk;
    }
}
