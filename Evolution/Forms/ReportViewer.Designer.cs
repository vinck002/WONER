namespace Evolution.Forms
{
    partial class ReportViewer
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
            this.crystalReportViewer2 = new CrystalDecisions.Windows.Forms.CrystalReportViewer();
            this.SuspendLayout();
            // 
            // crystalReportViewer2
            // 
            this.crystalReportViewer2.ActiveViewIndex = -1;
            this.crystalReportViewer2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.crystalReportViewer2.Cursor = System.Windows.Forms.Cursors.Default;
            this.crystalReportViewer2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.crystalReportViewer2.Location = new System.Drawing.Point(0, 0);
            this.crystalReportViewer2.Name = "crystalReportViewer2";
            this.crystalReportViewer2.Size = new System.Drawing.Size(623, 338);
            this.crystalReportViewer2.TabIndex = 0;
            this.crystalReportViewer2.ToolPanelView = CrystalDecisions.Windows.Forms.ToolPanelViewType.None;
            // 
            // ReportViewer
            // 
            this.ClientSize = new System.Drawing.Size(623, 338);
            this.Controls.Add(this.crystalReportViewer2);
            this.Name = "ReportViewer";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Report Viewer";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.ReportViewer_Load);
            this.ResumeLayout(false);

        }

        #endregion

       /* private Telerik.WinControls.UI.RadTitleBar radTitleBar1;
        private Reports.SettlementReport SettlementReport1;
        private CrystalDecisions.CrystalReports.Engine.ReportDocument reportDocument1;
        private Reports.SettlementReport SettlementReport2;
        private Reports.SettlementReport SettlementReport3;
        private Reports.SettlementReport SettlementReport4;
        private Reports.SettlementReport SettlementReport5;
        private CrystalDecisions.CrystalReports.Engine.ReportDocument reportDocument2;
        private CrystalDecisions.CrystalReports.Engine.ReportDocument reportDocument3;
        private CrystalDecisions.CrystalReports.Engine.ReportDocument reportDocument4;
        private CrystalDecisions.CrystalReports.Engine.ReportDocument reportDocument5;
        private CrystalDecisions.CrystalReports.Engine.ReportDocument reportDocument6;
        private CrystalDecisions.CrystalReports.Engine.ReportDocument reportDocument7;
        private CrystalDecisions.CrystalReports.Engine.ReportDocument reportDocument8;
        private Reports.OCPaymentReport OCPaymentReport1;
        private CrystalDecisions.Windows.Forms.CrystalReportViewer crystalReportViewer1;*/
        private CrystalDecisions.Windows.Forms.CrystalReportViewer crystalReportViewer2;
    }
}