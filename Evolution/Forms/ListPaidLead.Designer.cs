
namespace Evolution.Forms
{
    partial class ListPaidLead
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
            Telerik.WinControls.UI.GridViewTextBoxColumn gridViewTextBoxColumn1 = new Telerik.WinControls.UI.GridViewTextBoxColumn();
            Telerik.WinControls.UI.GridViewTextBoxColumn gridViewTextBoxColumn2 = new Telerik.WinControls.UI.GridViewTextBoxColumn();
            Telerik.WinControls.UI.TableViewDefinition tableViewDefinition1 = new Telerik.WinControls.UI.TableViewDefinition();
            this.dtgLead = new Telerik.WinControls.UI.RadGridView();
            ((System.ComponentModel.ISupportInitialize)(this.dtgLead)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtgLead.MasterTemplate)).BeginInit();
            this.SuspendLayout();
            // 
            // dtgLead
            // 
            this.dtgLead.BackColor = System.Drawing.SystemColors.Control;
            this.dtgLead.CausesValidation = false;
            this.dtgLead.Cursor = System.Windows.Forms.Cursors.Default;
            this.dtgLead.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dtgLead.EnableAnalytics = false;
            this.dtgLead.EnableHotTracking = false;
            this.dtgLead.Font = new System.Drawing.Font("Segoe UI", 8.25F);
            this.dtgLead.ForeColor = System.Drawing.SystemColors.ControlText;
            this.dtgLead.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.dtgLead.Location = new System.Drawing.Point(0, 0);
            // 
            // 
            // 
            this.dtgLead.MasterTemplate.AllowAddNewRow = false;
            this.dtgLead.MasterTemplate.AllowCellContextMenu = false;
            this.dtgLead.MasterTemplate.AllowColumnHeaderContextMenu = false;
            this.dtgLead.MasterTemplate.AllowColumnReorder = false;
            this.dtgLead.MasterTemplate.AllowColumnResize = false;
            this.dtgLead.MasterTemplate.AllowDeleteRow = false;
            this.dtgLead.MasterTemplate.AllowDragToGroup = false;
            this.dtgLead.MasterTemplate.AllowEditRow = false;
            this.dtgLead.MasterTemplate.AllowRowHeaderContextMenu = false;
            this.dtgLead.MasterTemplate.AllowRowResize = false;
            this.dtgLead.MasterTemplate.AutoGenerateColumns = false;
            gridViewTextBoxColumn1.AllowGroup = false;
            gridViewTextBoxColumn1.AllowResize = false;
            gridViewTextBoxColumn1.AllowSort = false;
            gridViewTextBoxColumn1.EnableExpressionEditor = false;
            gridViewTextBoxColumn1.FieldName = "CompanyReportPaidLeadID";
            gridViewTextBoxColumn1.HeaderText = "#Lead";
            gridViewTextBoxColumn1.Name = "CompanyReportPaidLeadID";
            gridViewTextBoxColumn1.ReadOnly = true;
            gridViewTextBoxColumn1.Width = 115;
            gridViewTextBoxColumn2.EnableExpressionEditor = false;
            gridViewTextBoxColumn2.FieldName = "CompanyReportHistoryID";
            gridViewTextBoxColumn2.HeaderText = "column2";
            gridViewTextBoxColumn2.IsVisible = false;
            gridViewTextBoxColumn2.Name = "CompanyReportHistoryID";
            this.dtgLead.MasterTemplate.Columns.AddRange(new Telerik.WinControls.UI.GridViewDataColumn[] {
            gridViewTextBoxColumn1,
            gridViewTextBoxColumn2});
            this.dtgLead.MasterTemplate.EnableGrouping = false;
            this.dtgLead.MasterTemplate.EnableSorting = false;
            this.dtgLead.MasterTemplate.ShowFilteringRow = false;
            this.dtgLead.MasterTemplate.ShowRowHeaderColumn = false;
            this.dtgLead.MasterTemplate.ViewDefinition = tableViewDefinition1;
            this.dtgLead.Name = "dtgLead";
            this.dtgLead.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.dtgLead.ShowGroupPanel = false;
            this.dtgLead.ShowGroupPanelScrollbars = false;
            this.dtgLead.ShowItemToolTips = false;
            this.dtgLead.Size = new System.Drawing.Size(120, 237);
            this.dtgLead.TabIndex = 0;
            // 
            // ListPaidLead
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(120, 237);
            this.Controls.Add(this.dtgLead);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "ListPaidLead";
            this.Opacity = 0.9D;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            ((System.ComponentModel.ISupportInitialize)(this.dtgLead.MasterTemplate)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtgLead)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Telerik.WinControls.UI.RadGridView dtgLead;
    }
}