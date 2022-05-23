
namespace Evolution.Forms
{
    partial class LeadStatus
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
            Telerik.WinControls.UI.GridViewCheckBoxColumn gridViewCheckBoxColumn1 = new Telerik.WinControls.UI.GridViewCheckBoxColumn();
            Telerik.WinControls.UI.GridViewTextBoxColumn gridViewTextBoxColumn1 = new Telerik.WinControls.UI.GridViewTextBoxColumn();
            Telerik.WinControls.UI.GridViewTextBoxColumn gridViewTextBoxColumn2 = new Telerik.WinControls.UI.GridViewTextBoxColumn();
            Telerik.WinControls.UI.GridViewTextBoxColumn gridViewTextBoxColumn3 = new Telerik.WinControls.UI.GridViewTextBoxColumn();
            Telerik.WinControls.UI.GridViewTextBoxColumn gridViewTextBoxColumn4 = new Telerik.WinControls.UI.GridViewTextBoxColumn();
            Telerik.WinControls.UI.TableViewDefinition tableViewDefinition1 = new Telerik.WinControls.UI.TableViewDefinition();
            this.dtgLead = new Telerik.WinControls.UI.RadGridView();
            this.lblLeadToPay = new Telerik.WinControls.UI.RadLabel();
            this.radLabel8 = new Telerik.WinControls.UI.RadLabel();
            this.radLabel10 = new Telerik.WinControls.UI.RadLabel();
            this.lblLeadQty = new Telerik.WinControls.UI.RadLabel();
            this.radLabel7 = new Telerik.WinControls.UI.RadLabel();
            this.RealPaymentDate = new Telerik.WinControls.UI.RadDateTimePicker();
            this.radLabel6 = new Telerik.WinControls.UI.RadLabel();
            this.CreationDate1 = new Telerik.WinControls.UI.RadDateTimePicker();
            this.radLabel4 = new Telerik.WinControls.UI.RadLabel();
            this.Amount = new Telerik.WinControls.UI.RadTextBox();
            this.bApply = new Telerik.WinControls.UI.RadButton();
            this.lblSource = new Telerik.WinControls.UI.RadLabel();
            ((System.ComponentModel.ISupportInitialize)(this.dtgLead)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtgLead.MasterTemplate)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblLeadToPay)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel8)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel10)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblLeadQty)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel7)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.RealPaymentDate)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel6)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.CreationDate1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Amount)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bApply)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblSource)).BeginInit();
            this.SuspendLayout();
            // 
            // dtgLead
            // 
            this.dtgLead.BackColor = System.Drawing.SystemColors.Control;
            this.dtgLead.CausesValidation = false;
            this.dtgLead.Cursor = System.Windows.Forms.Cursors.Default;
            this.dtgLead.EnableAnalytics = false;
            this.dtgLead.EnableHotTracking = false;
            this.dtgLead.Font = new System.Drawing.Font("Segoe UI", 8.25F);
            this.dtgLead.ForeColor = System.Drawing.SystemColors.ControlText;
            this.dtgLead.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.dtgLead.Location = new System.Drawing.Point(2, 24);
            // 
            // 
            // 
            this.dtgLead.MasterTemplate.AllowAddNewRow = false;
            this.dtgLead.MasterTemplate.AllowCellContextMenu = false;
            this.dtgLead.MasterTemplate.AllowColumnHeaderContextMenu = false;
            this.dtgLead.MasterTemplate.AllowDeleteRow = false;
            this.dtgLead.MasterTemplate.AllowDragToGroup = false;
            this.dtgLead.MasterTemplate.AllowEditRow = false;
            this.dtgLead.MasterTemplate.AllowRowHeaderContextMenu = false;
            this.dtgLead.MasterTemplate.AllowRowResize = false;
            this.dtgLead.MasterTemplate.AutoGenerateColumns = false;
            gridViewCheckBoxColumn1.AllowSort = false;
            gridViewCheckBoxColumn1.EnableExpressionEditor = false;
            gridViewCheckBoxColumn1.FieldName = "Selected";
            gridViewCheckBoxColumn1.HeaderText = "Select";
            gridViewCheckBoxColumn1.MinWidth = 20;
            gridViewCheckBoxColumn1.Name = "Selected";
            gridViewCheckBoxColumn1.Width = 40;
            gridViewTextBoxColumn1.AllowGroup = false;
            gridViewTextBoxColumn1.AllowResize = false;
            gridViewTextBoxColumn1.AllowSort = false;
            gridViewTextBoxColumn1.EnableExpressionEditor = false;
            gridViewTextBoxColumn1.FieldName = "LeadID";
            gridViewTextBoxColumn1.HeaderText = "#Lead";
            gridViewTextBoxColumn1.Name = "LeadID";
            gridViewTextBoxColumn1.ReadOnly = true;
            gridViewTextBoxColumn1.Width = 115;
            gridViewTextBoxColumn2.EnableExpressionEditor = false;
            gridViewTextBoxColumn2.FieldName = "CompanyReportHistoryID";
            gridViewTextBoxColumn2.HeaderText = "column2";
            gridViewTextBoxColumn2.IsVisible = false;
            gridViewTextBoxColumn2.Name = "CompanyReportHistoryID";
            gridViewTextBoxColumn3.EnableExpressionEditor = false;
            gridViewTextBoxColumn3.FieldName = "AgreementNumber";
            gridViewTextBoxColumn3.HeaderText = "Contract#";
            gridViewTextBoxColumn3.Name = "AgreementNumber";
            gridViewTextBoxColumn3.ReadOnly = true;
            gridViewTextBoxColumn3.Width = 107;
            gridViewTextBoxColumn4.EnableExpressionEditor = false;
            gridViewTextBoxColumn4.FieldName = "StatusPaid";
            gridViewTextBoxColumn4.HeaderText = "StatusPaid";
            gridViewTextBoxColumn4.IsVisible = false;
            gridViewTextBoxColumn4.Name = "StatusPaid";
            this.dtgLead.MasterTemplate.Columns.AddRange(new Telerik.WinControls.UI.GridViewDataColumn[] {
            gridViewCheckBoxColumn1,
            gridViewTextBoxColumn1,
            gridViewTextBoxColumn2,
            gridViewTextBoxColumn3,
            gridViewTextBoxColumn4});
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
            this.dtgLead.Size = new System.Drawing.Size(268, 243);
            this.dtgLead.TabIndex = 1;
            // 
            // lblLeadToPay
            // 
            this.lblLeadToPay.BackColor = System.Drawing.Color.White;
            this.lblLeadToPay.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblLeadToPay.ForeColor = System.Drawing.Color.Green;
            this.lblLeadToPay.Location = new System.Drawing.Point(224, 272);
            this.lblLeadToPay.Name = "lblLeadToPay";
            this.lblLeadToPay.Size = new System.Drawing.Size(34, 21);
            this.lblLeadToPay.TabIndex = 17;
            this.lblLeadToPay.Text = "0.00";
            this.lblLeadToPay.TextAlignment = System.Drawing.ContentAlignment.TopLeft;
            this.lblLeadToPay.ThemeName = "Aqua";
            // 
            // radLabel8
            // 
            this.radLabel8.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.radLabel8.Location = new System.Drawing.Point(15, 2);
            this.radLabel8.Name = "radLabel8";
            this.radLabel8.Size = new System.Drawing.Size(31, 21);
            this.radLabel8.TabIndex = 15;
            this.radLabel8.Text = "Qty:";
            this.radLabel8.TextAlignment = System.Drawing.ContentAlignment.TopLeft;
            // 
            // radLabel10
            // 
            this.radLabel10.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.radLabel10.Location = new System.Drawing.Point(69, 272);
            this.radLabel10.Name = "radLabel10";
            this.radLabel10.Size = new System.Drawing.Size(158, 21);
            this.radLabel10.TabIndex = 16;
            this.radLabel10.Text = "Lead Qty Pending To Pay:";
            this.radLabel10.TextAlignment = System.Drawing.ContentAlignment.TopLeft;
            // 
            // lblLeadQty
            // 
            this.lblLeadQty.BackColor = System.Drawing.Color.White;
            this.lblLeadQty.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblLeadQty.ForeColor = System.Drawing.Color.Green;
            this.lblLeadQty.Location = new System.Drawing.Point(46, 3);
            this.lblLeadQty.Name = "lblLeadQty";
            this.lblLeadQty.Size = new System.Drawing.Size(15, 21);
            this.lblLeadQty.TabIndex = 14;
            this.lblLeadQty.Text = "0";
            this.lblLeadQty.TextAlignment = System.Drawing.ContentAlignment.TopLeft;
            this.lblLeadQty.ThemeName = "Aqua";
            // 
            // radLabel7
            // 
            this.radLabel7.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.radLabel7.Location = new System.Drawing.Point(2, 328);
            this.radLabel7.Name = "radLabel7";
            this.radLabel7.Size = new System.Drawing.Size(118, 21);
            this.radLabel7.TabIndex = 26;
            this.radLabel7.Text = "Real Payment Date";
            // 
            // RealPaymentDate
            // 
            this.RealPaymentDate.CustomFormat = "";
            this.RealPaymentDate.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.RealPaymentDate.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.RealPaymentDate.Location = new System.Drawing.Point(126, 326);
            this.RealPaymentDate.Name = "RealPaymentDate";
            this.RealPaymentDate.Size = new System.Drawing.Size(144, 28);
            this.RealPaymentDate.TabIndex = 25;
            this.RealPaymentDate.TabStop = false;
            this.RealPaymentDate.Text = "12/12/2017";
            this.RealPaymentDate.ThemeName = "Breeze";
            this.RealPaymentDate.Value = new System.DateTime(2017, 12, 12, 0, 0, 0, 0);
            // 
            // radLabel6
            // 
            this.radLabel6.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.radLabel6.Location = new System.Drawing.Point(15, 359);
            this.radLabel6.Name = "radLabel6";
            this.radLabel6.Size = new System.Drawing.Size(105, 21);
            this.radLabel6.TabIndex = 24;
            this.radLabel6.Text = "Application Date";
            // 
            // CreationDate1
            // 
            this.CreationDate1.CustomFormat = "";
            this.CreationDate1.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CreationDate1.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.CreationDate1.Location = new System.Drawing.Point(126, 358);
            this.CreationDate1.Name = "CreationDate1";
            this.CreationDate1.Size = new System.Drawing.Size(144, 28);
            this.CreationDate1.TabIndex = 23;
            this.CreationDate1.TabStop = false;
            this.CreationDate1.Text = "12/12/2017";
            this.CreationDate1.ThemeName = "Breeze";
            this.CreationDate1.Value = new System.DateTime(2017, 12, 12, 0, 0, 0, 0);
            // 
            // radLabel4
            // 
            this.radLabel4.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.radLabel4.Location = new System.Drawing.Point(65, 297);
            this.radLabel4.Name = "radLabel4";
            this.radLabel4.Size = new System.Drawing.Size(55, 21);
            this.radLabel4.TabIndex = 22;
            this.radLabel4.Text = "Amount";
            // 
            // Amount
            // 
            this.Amount.Enabled = false;
            this.Amount.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Amount.Location = new System.Drawing.Point(126, 297);
            this.Amount.Name = "Amount";
            this.Amount.Size = new System.Drawing.Size(144, 28);
            this.Amount.TabIndex = 21;
            this.Amount.ThemeName = "Breeze";
            // 
            // bApply
            // 
            this.bApply.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(167)))), ((int)(((byte)(219)))), ((int)(((byte)(244)))));
            this.bApply.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bApply.ForeColor = System.Drawing.Color.Black;
            this.bApply.Image = global::Evolution.Properties.Resources.ok;
            this.bApply.ImageAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            this.bApply.Location = new System.Drawing.Point(126, 392);
            this.bApply.Name = "bApply";
            this.bApply.Size = new System.Drawing.Size(144, 30);
            this.bApply.TabIndex = 27;
            this.bApply.Text = "Apply Payment";
            this.bApply.TextAlignment = System.Drawing.ContentAlignment.MiddleLeft;
            this.bApply.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.bApply.Click += new System.EventHandler(this.bApply_Click);
            ((Telerik.WinControls.UI.RadButtonElement)(this.bApply.GetChildAt(0))).Image = global::Evolution.Properties.Resources.ok;
            ((Telerik.WinControls.UI.RadButtonElement)(this.bApply.GetChildAt(0))).TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            ((Telerik.WinControls.UI.RadButtonElement)(this.bApply.GetChildAt(0))).ImageAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            ((Telerik.WinControls.UI.RadButtonElement)(this.bApply.GetChildAt(0))).TextAlignment = System.Drawing.ContentAlignment.MiddleLeft;
            ((Telerik.WinControls.UI.RadButtonElement)(this.bApply.GetChildAt(0))).Text = "Apply Payment";
            ((Telerik.WinControls.Primitives.FillPrimitive)(this.bApply.GetChildAt(0).GetChildAt(0))).BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(233)))), ((int)(((byte)(241)))), ((int)(((byte)(252)))));
            ((Telerik.WinControls.Primitives.ImagePrimitive)(this.bApply.GetChildAt(0).GetChildAt(1).GetChildAt(0))).ImageScaling = Telerik.WinControls.Enumerations.ImageScaling.SizeToFit;
            // 
            // lblSource
            // 
            this.lblSource.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSource.Location = new System.Drawing.Point(135, 2);
            this.lblSource.Name = "lblSource";
            this.lblSource.Size = new System.Drawing.Size(50, 21);
            this.lblSource.TabIndex = 28;
            this.lblSource.Text = "Source";
            this.lblSource.TextAlignment = System.Drawing.ContentAlignment.TopLeft;
            // 
            // LeadStatus
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(244)))), ((int)(((byte)(251)))), ((int)(((byte)(255)))));
            this.ClientSize = new System.Drawing.Size(277, 427);
            this.Controls.Add(this.lblSource);
            this.Controls.Add(this.bApply);
            this.Controls.Add(this.radLabel7);
            this.Controls.Add(this.RealPaymentDate);
            this.Controls.Add(this.radLabel6);
            this.Controls.Add(this.CreationDate1);
            this.Controls.Add(this.radLabel4);
            this.Controls.Add(this.Amount);
            this.Controls.Add(this.lblLeadToPay);
            this.Controls.Add(this.radLabel8);
            this.Controls.Add(this.radLabel10);
            this.Controls.Add(this.lblLeadQty);
            this.Controls.Add(this.dtgLead);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "LeadStatus";
            this.Text = "Lead Status";
            ((System.ComponentModel.ISupportInitialize)(this.dtgLead.MasterTemplate)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtgLead)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblLeadToPay)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel8)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel10)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblLeadQty)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel7)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.RealPaymentDate)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel6)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.CreationDate1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Amount)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bApply)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblSource)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Telerik.WinControls.UI.RadGridView dtgLead;
        private Telerik.WinControls.UI.RadLabel lblLeadToPay;
        private Telerik.WinControls.UI.RadLabel radLabel8;
        private Telerik.WinControls.UI.RadLabel radLabel10;
        private Telerik.WinControls.UI.RadLabel lblLeadQty;
        private Telerik.WinControls.UI.RadLabel radLabel7;
        private Telerik.WinControls.UI.RadDateTimePicker RealPaymentDate;
        private Telerik.WinControls.UI.RadLabel radLabel6;
        private Telerik.WinControls.UI.RadDateTimePicker CreationDate1;
        private Telerik.WinControls.UI.RadLabel radLabel4;
        private Telerik.WinControls.UI.RadTextBox Amount;
        private Telerik.WinControls.UI.RadButton bApply;
        private Telerik.WinControls.UI.RadLabel lblSource;
    }
}