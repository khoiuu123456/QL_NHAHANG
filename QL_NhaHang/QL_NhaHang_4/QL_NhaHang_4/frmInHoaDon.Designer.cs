namespace QL_NhaHang_4
{
    partial class frmInHoaDon
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmInHoaDon));
            this.crystalInHoaDon = new CrystalDecisions.Windows.Forms.CrystalReportViewer();
            this.SuspendLayout();
            // 
            // crystalInHoaDon
            // 
            this.crystalInHoaDon.ActiveViewIndex = -1;
            this.crystalInHoaDon.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.crystalInHoaDon.Cursor = System.Windows.Forms.Cursors.Default;
            this.crystalInHoaDon.Dock = System.Windows.Forms.DockStyle.Fill;
            this.crystalInHoaDon.Location = new System.Drawing.Point(0, 0);
            this.crystalInHoaDon.Name = "crystalInHoaDon";
            this.crystalInHoaDon.Size = new System.Drawing.Size(624, 803);
            this.crystalInHoaDon.TabIndex = 0;
            this.crystalInHoaDon.ToolPanelView = CrystalDecisions.Windows.Forms.ToolPanelViewType.None;
            // 
            // frmInHoaDon
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(624, 803);
            this.Controls.Add(this.crystalInHoaDon);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmInHoaDon";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Xuất hóa đơn";
            this.Load += new System.EventHandler(this.frmInHoaDon_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private CrystalDecisions.Windows.Forms.CrystalReportViewer crystalInHoaDon;
    }
}