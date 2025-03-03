namespace GUI_QLBanHang
{
    partial class FrmThongKe
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

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            this.tcThongKe = new System.Windows.Forms.TabControl();
            this.tpsanpham = new System.Windows.Forms.TabPage();
            this.dgvsp = new System.Windows.Forms.DataGridView();
            this.tptonkho = new System.Windows.Forms.TabPage();
            this.dgvtonkho = new System.Windows.Forms.DataGridView();
            this.tpLogSanPham = new System.Windows.Forms.TabPage();
            this.dgvLogSanPham = new System.Windows.Forms.DataGridView();
            this.tcThongKe.SuspendLayout();
            this.tpsanpham.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvsp)).BeginInit();
            this.tptonkho.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvtonkho)).BeginInit();
            this.tpLogSanPham.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvLogSanPham)).BeginInit();
            this.SuspendLayout();
            // 
            // tcThongKe
            // 
            this.tcThongKe.Controls.Add(this.tpsanpham);
            this.tcThongKe.Controls.Add(this.tptonkho);
            this.tcThongKe.Controls.Add(this.tpLogSanPham);
            this.tcThongKe.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tcThongKe.Location = new System.Drawing.Point(0, 0);
            this.tcThongKe.Margin = new System.Windows.Forms.Padding(4);
            this.tcThongKe.Name = "tcThongKe";
            this.tcThongKe.SelectedIndex = 0;
            this.tcThongKe.Size = new System.Drawing.Size(882, 453);
            this.tcThongKe.TabIndex = 0;
            this.tcThongKe.Selected += new System.Windows.Forms.TabControlEventHandler(this.TcThongKe_Selected);
            // 
            // tpsanpham
            // 
            this.tpsanpham.CausesValidation = false;
            this.tpsanpham.Controls.Add(this.dgvsp);
            this.tpsanpham.Location = new System.Drawing.Point(4, 25);
            this.tpsanpham.Margin = new System.Windows.Forms.Padding(4);
            this.tpsanpham.Name = "tpsanpham";
            this.tpsanpham.Padding = new System.Windows.Forms.Padding(4);
            this.tpsanpham.Size = new System.Drawing.Size(874, 424);
            this.tpsanpham.TabIndex = 0;
            this.tpsanpham.Text = "Sản Phẩm Nhập Kho";
            this.tpsanpham.UseVisualStyleBackColor = true;
            // 
            // dgvsp
            // 
            this.dgvsp.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvsp.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvsp.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvsp.Location = new System.Drawing.Point(4, 4);
            this.dgvsp.Margin = new System.Windows.Forms.Padding(4);
            this.dgvsp.Name = "dgvsp";
            this.dgvsp.RowHeadersWidth = 51;
            this.dgvsp.Size = new System.Drawing.Size(866, 416);
            this.dgvsp.TabIndex = 0;
            // 
            // tptonkho
            // 
            this.tptonkho.CausesValidation = false;
            this.tptonkho.Controls.Add(this.dgvtonkho);
            this.tptonkho.Location = new System.Drawing.Point(4, 25);
            this.tptonkho.Margin = new System.Windows.Forms.Padding(4);
            this.tptonkho.Name = "tptonkho";
            this.tptonkho.Padding = new System.Windows.Forms.Padding(4);
            this.tptonkho.Size = new System.Drawing.Size(874, 424);
            this.tptonkho.TabIndex = 1;
            this.tptonkho.Text = "Tồn Kho";
            this.tptonkho.UseVisualStyleBackColor = true;
            // 
            // dgvtonkho
            // 
            this.dgvtonkho.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvtonkho.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvtonkho.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvtonkho.Location = new System.Drawing.Point(4, 4);
            this.dgvtonkho.Margin = new System.Windows.Forms.Padding(4);
            this.dgvtonkho.Name = "dgvtonkho";
            this.dgvtonkho.RowHeadersWidth = 51;
            this.dgvtonkho.Size = new System.Drawing.Size(866, 416);
            this.dgvtonkho.TabIndex = 0;
            // 
            // tpLogSanPham
            // 
            this.tpLogSanPham.Controls.Add(this.dgvLogSanPham);
            this.tpLogSanPham.Location = new System.Drawing.Point(4, 25);
            this.tpLogSanPham.Name = "tpLogSanPham";
            this.tpLogSanPham.Padding = new System.Windows.Forms.Padding(3);
            this.tpLogSanPham.Size = new System.Drawing.Size(874, 424);
            this.tpLogSanPham.TabIndex = 2;
            this.tpLogSanPham.Text = "Lịch sử chỉnh sửa sản phẩm";
            this.tpLogSanPham.UseVisualStyleBackColor = true;
            // 
            // dgvLogSanPham
            // 
            this.dgvLogSanPham.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvLogSanPham.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.DisplayedCells;
            this.dgvLogSanPham.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvLogSanPham.DefaultCellStyle = dataGridViewCellStyle2;
            this.dgvLogSanPham.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvLogSanPham.Location = new System.Drawing.Point(3, 3);
            this.dgvLogSanPham.Margin = new System.Windows.Forms.Padding(4);
            this.dgvLogSanPham.Name = "dgvLogSanPham";
            this.dgvLogSanPham.RowHeadersWidth = 51;
            this.dgvLogSanPham.Size = new System.Drawing.Size(868, 418);
            this.dgvLogSanPham.TabIndex = 1;
            // 
            // FrmThongKe
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(882, 453);
            this.Controls.Add(this.tcThongKe);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.MaximizeBox = false;
            this.Name = "FrmThongKe";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "FrmThongKe";
            this.Load += new System.EventHandler(this.FrmThongKe_Load);
            this.tcThongKe.ResumeLayout(false);
            this.tpsanpham.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvsp)).EndInit();
            this.tptonkho.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvtonkho)).EndInit();
            this.tpLogSanPham.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvLogSanPham)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tcThongKe;
        private System.Windows.Forms.TabPage tpsanpham;
        private System.Windows.Forms.TabPage tptonkho;
        private System.Windows.Forms.DataGridView dgvsp;
        private System.Windows.Forms.DataGridView dgvtonkho;
        private System.Windows.Forms.TabPage tpLogSanPham;
        private System.Windows.Forms.DataGridView dgvLogSanPham;
    }
}