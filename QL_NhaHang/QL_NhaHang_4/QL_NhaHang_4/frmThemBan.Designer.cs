namespace QL_NhaHang_4
{
    partial class frmThemBan
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
            this.label1 = new System.Windows.Forms.Label();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.btnThemBan = new System.Windows.Forms.Button();
            this.btnClearBan = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(12, 12);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(85, 25);
            this.label1.TabIndex = 0;
            this.label1.Text = "Tên bàn";
            // 
            // textBox1
            // 
            this.textBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox1.Location = new System.Drawing.Point(104, 12);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(268, 27);
            this.textBox1.TabIndex = 1;
            // 
            // btnThemBan
            // 
            this.btnThemBan.BackColor = System.Drawing.Color.LimeGreen;
            this.btnThemBan.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnThemBan.ForeColor = System.Drawing.Color.White;
            this.btnThemBan.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnThemBan.Location = new System.Drawing.Point(138, 68);
            this.btnThemBan.Name = "btnThemBan";
            this.btnThemBan.Size = new System.Drawing.Size(106, 40);
            this.btnThemBan.TabIndex = 9;
            this.btnThemBan.Text = "Thêm bàn";
            this.btnThemBan.UseVisualStyleBackColor = false;
            // 
            // btnClearBan
            // 
            this.btnClearBan.BackColor = System.Drawing.Color.Honeydew;
            this.btnClearBan.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnClearBan.ForeColor = System.Drawing.Color.Black;
            this.btnClearBan.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnClearBan.Location = new System.Drawing.Point(266, 68);
            this.btnClearBan.Name = "btnClearBan";
            this.btnClearBan.Size = new System.Drawing.Size(106, 40);
            this.btnClearBan.TabIndex = 10;
            this.btnClearBan.Text = "Clear";
            this.btnClearBan.UseVisualStyleBackColor = false;
            // 
            // frmThemBan
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1301, 766);
            this.Controls.Add(this.btnClearBan);
            this.Controls.Add(this.btnThemBan);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.label1);
            this.Name = "frmThemBan";
            this.Text = "Thêm mới bàn ăn";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Button btnThemBan;
        private System.Windows.Forms.Button btnClearBan;
    }
}