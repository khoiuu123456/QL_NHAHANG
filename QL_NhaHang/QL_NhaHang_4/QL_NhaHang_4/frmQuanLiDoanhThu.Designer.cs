namespace QL_NhaHang_4
{
    partial class frmQuanLiDoanhThu
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
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea1 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend1 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series1 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.Title title1 = new System.Windows.Forms.DataVisualization.Charting.Title();
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea2 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend2 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series2 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.Title title2 = new System.Windows.Forms.DataVisualization.Charting.Title();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.panel2 = new System.Windows.Forms.Panel();
            this.splitContainer2 = new System.Windows.Forms.SplitContainer();
            this.chartDoanThuThang = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.chartLuongNV = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnLocDoanhThu = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.cboNam = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.gridHoaDon = new System.Windows.Forms.DataGridView();
            this.panel3 = new System.Windows.Forms.Panel();
            this.txtHDNam = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.txtHDThang = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label4 = new System.Windows.Forms.Label();
            this.cboNamDoanhThu = new System.Windows.Forms.ComboBox();
            this.btnLocNgay = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.txtNgay = new System.Windows.Forms.DateTimePicker();
            this.thang = new System.Windows.Forms.Label();
            this.cboThangDoanhThu = new System.Windows.Forms.ComboBox();
            this.txtHDNgay = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).BeginInit();
            this.splitContainer2.Panel1.SuspendLayout();
            this.splitContainer2.Panel2.SuspendLayout();
            this.splitContainer2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chartDoanThuThang)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chartLuongNV)).BeginInit();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridHoaDon)).BeginInit();
            this.panel3.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.panel2);
            this.splitContainer1.Panel1.Controls.Add(this.panel1);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.gridHoaDon);
            this.splitContainer1.Panel2.Controls.Add(this.panel3);
            this.splitContainer1.Size = new System.Drawing.Size(1301, 766);
            this.splitContainer1.SplitterDistance = 664;
            this.splitContainer1.TabIndex = 0;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.splitContainer2);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(0, 42);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(664, 724);
            this.panel2.TabIndex = 1;
            // 
            // splitContainer2
            // 
            this.splitContainer2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer2.Location = new System.Drawing.Point(0, 0);
            this.splitContainer2.Name = "splitContainer2";
            this.splitContainer2.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer2.Panel1
            // 
            this.splitContainer2.Panel1.Controls.Add(this.chartDoanThuThang);
            // 
            // splitContainer2.Panel2
            // 
            this.splitContainer2.Panel2.Controls.Add(this.chartLuongNV);
            this.splitContainer2.Size = new System.Drawing.Size(664, 724);
            this.splitContainer2.SplitterDistance = 345;
            this.splitContainer2.TabIndex = 0;
            // 
            // chartDoanThuThang
            // 
            chartArea1.Name = "ChartArea1";
            this.chartDoanThuThang.ChartAreas.Add(chartArea1);
            this.chartDoanThuThang.Dock = System.Windows.Forms.DockStyle.Fill;
            legend1.Name = "Legend1";
            this.chartDoanThuThang.Legends.Add(legend1);
            this.chartDoanThuThang.Location = new System.Drawing.Point(0, 0);
            this.chartDoanThuThang.Name = "chartDoanThuThang";
            series1.ChartArea = "ChartArea1";
            series1.IsValueShownAsLabel = true;
            series1.Legend = "Legend1";
            series1.Name = "Tiền bán";
            series1.YValuesPerPoint = 2;
            this.chartDoanThuThang.Series.Add(series1);
            this.chartDoanThuThang.Size = new System.Drawing.Size(664, 345);
            this.chartDoanThuThang.TabIndex = 0;
            this.chartDoanThuThang.Text = "Tổng doanh thu theo tháng";
            title1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            title1.Name = "Title1";
            title1.Text = "Tổng doanh thu theo tháng";
            this.chartDoanThuThang.Titles.Add(title1);
            // 
            // chartLuongNV
            // 
            chartArea2.Name = "ChartArea1";
            this.chartLuongNV.ChartAreas.Add(chartArea2);
            this.chartLuongNV.Dock = System.Windows.Forms.DockStyle.Fill;
            legend2.Name = "Legend1";
            this.chartLuongNV.Legends.Add(legend2);
            this.chartLuongNV.Location = new System.Drawing.Point(0, 0);
            this.chartLuongNV.Name = "chartLuongNV";
            this.chartLuongNV.Palette = System.Windows.Forms.DataVisualization.Charting.ChartColorPalette.SeaGreen;
            series2.ChartArea = "ChartArea1";
            series2.IsValueShownAsLabel = true;
            series2.Legend = "Legend1";
            series2.Name = "Lương";
            series2.YValuesPerPoint = 2;
            this.chartLuongNV.Series.Add(series2);
            this.chartLuongNV.Size = new System.Drawing.Size(664, 375);
            this.chartLuongNV.TabIndex = 0;
            this.chartLuongNV.Text = "chart1";
            title2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            title2.Name = "Title1";
            title2.Text = "Tổng chi phí cho lương nhân viên";
            this.chartLuongNV.Titles.Add(title2);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.btnLocDoanhThu);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.cboNam);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(664, 42);
            this.panel1.TabIndex = 0;
            // 
            // btnLocDoanhThu
            // 
            this.btnLocDoanhThu.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnLocDoanhThu.BackColor = System.Drawing.Color.Goldenrod;
            this.btnLocDoanhThu.FlatAppearance.BorderSize = 0;
            this.btnLocDoanhThu.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnLocDoanhThu.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnLocDoanhThu.ForeColor = System.Drawing.Color.White;
            this.btnLocDoanhThu.Location = new System.Drawing.Point(582, 9);
            this.btnLocDoanhThu.Name = "btnLocDoanhThu";
            this.btnLocDoanhThu.Size = new System.Drawing.Size(78, 27);
            this.btnLocDoanhThu.TabIndex = 71;
            this.btnLocDoanhThu.Text = "Lọc";
            this.btnLocDoanhThu.UseVisualStyleBackColor = false;
            this.btnLocDoanhThu.Click += new System.EventHandler(this.btnLocDoanhThu_Click);
            // 
            // label3
            // 
            this.label3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(532, 12);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(44, 20);
            this.label3.TabIndex = 70;
            this.label3.Text = "Năm";
            // 
            // cboNam
            // 
            this.cboNam.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.cboNam.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboNam.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboNam.FormattingEnabled = true;
            this.cboNam.Items.AddRange(new object[] {
            "2021",
            "2022",
            "2023",
            "2024",
            "2025",
            "2026",
            "2027",
            "2028",
            "2029",
            "2030"});
            this.cboNam.Location = new System.Drawing.Point(443, 8);
            this.cboNam.Name = "cboNam";
            this.cboNam.Size = new System.Drawing.Size(83, 28);
            this.cboNam.TabIndex = 69;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Crimson;
            this.label1.Location = new System.Drawing.Point(3, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(287, 29);
            this.label1.TabIndex = 0;
            this.label1.Text = "THỐNG KÊ DOANH THU";
            // 
            // gridHoaDon
            // 
            this.gridHoaDon.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.gridHoaDon.BackgroundColor = System.Drawing.SystemColors.Control;
            this.gridHoaDon.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gridHoaDon.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridHoaDon.Location = new System.Drawing.Point(0, 234);
            this.gridHoaDon.Name = "gridHoaDon";
            this.gridHoaDon.RowTemplate.Height = 24;
            this.gridHoaDon.Size = new System.Drawing.Size(633, 532);
            this.gridHoaDon.TabIndex = 1;
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.txtHDNam);
            this.panel3.Controls.Add(this.label7);
            this.panel3.Controls.Add(this.txtHDThang);
            this.panel3.Controls.Add(this.label6);
            this.panel3.Controls.Add(this.label5);
            this.panel3.Controls.Add(this.groupBox1);
            this.panel3.Controls.Add(this.txtHDNgay);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel3.Location = new System.Drawing.Point(0, 0);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(633, 234);
            this.panel3.TabIndex = 0;
            // 
            // txtHDNam
            // 
            this.txtHDNam.ForeColor = System.Drawing.Color.Crimson;
            this.txtHDNam.Location = new System.Drawing.Point(110, 186);
            this.txtHDNam.Name = "txtHDNam";
            this.txtHDNam.ReadOnly = true;
            this.txtHDNam.Size = new System.Drawing.Size(347, 27);
            this.txtHDNam.TabIndex = 11;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.ForeColor = System.Drawing.Color.DarkGreen;
            this.label7.Location = new System.Drawing.Point(7, 189);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(44, 20);
            this.label7.TabIndex = 10;
            this.label7.Text = "Năm";
            // 
            // txtHDThang
            // 
            this.txtHDThang.ForeColor = System.Drawing.Color.Crimson;
            this.txtHDThang.Location = new System.Drawing.Point(110, 141);
            this.txtHDThang.Name = "txtHDThang";
            this.txtHDThang.ReadOnly = true;
            this.txtHDThang.Size = new System.Drawing.Size(347, 27);
            this.txtHDThang.TabIndex = 9;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.ForeColor = System.Drawing.Color.DarkGreen;
            this.label6.Location = new System.Drawing.Point(7, 144);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(55, 20);
            this.label6.TabIndex = 8;
            this.label6.Text = "Tháng";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.ForeColor = System.Drawing.Color.DarkGreen;
            this.label5.Location = new System.Drawing.Point(7, 102);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(47, 20);
            this.label5.TabIndex = 6;
            this.label5.Text = "Ngày";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.cboNamDoanhThu);
            this.groupBox1.Controls.Add(this.btnLocNgay);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.txtNgay);
            this.groupBox1.Controls.Add(this.thang);
            this.groupBox1.Controls.Add(this.cboThangDoanhThu);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox1.ForeColor = System.Drawing.Color.MidnightBlue;
            this.groupBox1.Location = new System.Drawing.Point(0, 0);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(633, 90);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "TỔNG TIỀN BÁN ĐƯỢC TRONG NGÀY";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(417, 37);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(44, 20);
            this.label4.TabIndex = 74;
            this.label4.Text = "Năm";
            // 
            // cboNamDoanhThu
            // 
            this.cboNamDoanhThu.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboNamDoanhThu.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboNamDoanhThu.FormattingEnabled = true;
            this.cboNamDoanhThu.Items.AddRange(new object[] {
            "2021",
            "2022",
            "2023",
            "2024",
            "2025",
            "2026",
            "2027",
            "2028",
            "2029",
            "2030"});
            this.cboNamDoanhThu.Location = new System.Drawing.Point(462, 31);
            this.cboNamDoanhThu.Name = "cboNamDoanhThu";
            this.cboNamDoanhThu.Size = new System.Drawing.Size(83, 28);
            this.cboNamDoanhThu.TabIndex = 73;
            // 
            // btnLocNgay
            // 
            this.btnLocNgay.BackColor = System.Drawing.Color.Goldenrod;
            this.btnLocNgay.FlatAppearance.BorderSize = 0;
            this.btnLocNgay.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnLocNgay.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnLocNgay.ForeColor = System.Drawing.Color.White;
            this.btnLocNgay.Location = new System.Drawing.Point(557, 32);
            this.btnLocNgay.Name = "btnLocNgay";
            this.btnLocNgay.Size = new System.Drawing.Size(70, 27);
            this.btnLocNgay.TabIndex = 72;
            this.btnLocNgay.Text = "Lọc";
            this.btnLocNgay.UseVisualStyleBackColor = false;
            this.btnLocNgay.Click += new System.EventHandler(this.btnLocNgay_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(7, 32);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(88, 20);
            this.label2.TabIndex = 0;
            this.label2.Text = "Chọn ngày";
            // 
            // txtNgay
            // 
            this.txtNgay.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.txtNgay.Location = new System.Drawing.Point(110, 32);
            this.txtNgay.Name = "txtNgay";
            this.txtNgay.Size = new System.Drawing.Size(128, 27);
            this.txtNgay.TabIndex = 1;
            // 
            // thang
            // 
            this.thang.AutoSize = true;
            this.thang.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.thang.Location = new System.Drawing.Point(257, 36);
            this.thang.Name = "thang";
            this.thang.Size = new System.Drawing.Size(55, 20);
            this.thang.TabIndex = 68;
            this.thang.Text = "Tháng";
            // 
            // cboThangDoanhThu
            // 
            this.cboThangDoanhThu.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboThangDoanhThu.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboThangDoanhThu.FormattingEnabled = true;
            this.cboThangDoanhThu.Items.AddRange(new object[] {
            "1",
            "2",
            "3",
            "4",
            "5",
            "6",
            "7",
            "8",
            "9",
            "10",
            "11",
            "12"});
            this.cboThangDoanhThu.Location = new System.Drawing.Point(318, 31);
            this.cboThangDoanhThu.Name = "cboThangDoanhThu";
            this.cboThangDoanhThu.Size = new System.Drawing.Size(79, 28);
            this.cboThangDoanhThu.TabIndex = 67;
            // 
            // txtHDNgay
            // 
            this.txtHDNgay.ForeColor = System.Drawing.Color.Crimson;
            this.txtHDNgay.Location = new System.Drawing.Point(110, 102);
            this.txtHDNgay.Name = "txtHDNgay";
            this.txtHDNgay.ReadOnly = true;
            this.txtHDNgay.Size = new System.Drawing.Size(347, 27);
            this.txtHDNgay.TabIndex = 7;
            // 
            // frmQuanLiDoanhThu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(120F, 120F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.ClientSize = new System.Drawing.Size(1301, 766);
            this.Controls.Add(this.splitContainer1);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "frmQuanLiDoanhThu";
            this.Text = "Quản lý doanh thu";
            this.Load += new System.EventHandler(this.frmQuanLiDoanhThu_Load);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.splitContainer2.Panel1.ResumeLayout(false);
            this.splitContainer2.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).EndInit();
            this.splitContainer2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.chartDoanThuThang)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chartLuongNV)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridHoaDon)).EndInit();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.SplitContainer splitContainer2;
        private System.Windows.Forms.DataVisualization.Charting.Chart chartDoanThuThang;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnLocDoanhThu;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox cboNam;
        private System.Windows.Forms.Label thang;
        private System.Windows.Forms.ComboBox cboThangDoanhThu;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.DataGridView gridHoaDon;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.DateTimePicker txtNgay;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnLocNgay;
        private System.Windows.Forms.TextBox txtHDNam;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox txtHDThang;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtHDNgay;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox cboNamDoanhThu;
        private System.Windows.Forms.DataVisualization.Charting.Chart chartLuongNV;
    }
}