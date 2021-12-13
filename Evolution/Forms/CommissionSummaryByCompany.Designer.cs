namespace Evolution.Forms
{
    partial class CommissionSummaryByCompany
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
            Telerik.WinControls.UI.GridViewCheckBoxColumn gridViewCheckBoxColumn1 = new Telerik.WinControls.UI.GridViewCheckBoxColumn();
            Telerik.WinControls.UI.GridViewTextBoxColumn gridViewTextBoxColumn2 = new Telerik.WinControls.UI.GridViewTextBoxColumn();
            Telerik.WinControls.UI.TableViewDefinition tableViewDefinition1 = new Telerik.WinControls.UI.TableViewDefinition();
            Telerik.WinControls.UI.GridViewTextBoxColumn gridViewTextBoxColumn3 = new Telerik.WinControls.UI.GridViewTextBoxColumn();
            Telerik.WinControls.UI.GridViewCheckBoxColumn gridViewCheckBoxColumn2 = new Telerik.WinControls.UI.GridViewCheckBoxColumn();
            Telerik.WinControls.UI.GridViewTextBoxColumn gridViewTextBoxColumn4 = new Telerik.WinControls.UI.GridViewTextBoxColumn();
            Telerik.WinControls.UI.GridViewTextBoxColumn gridViewTextBoxColumn5 = new Telerik.WinControls.UI.GridViewTextBoxColumn();
            Telerik.WinControls.UI.TableViewDefinition tableViewDefinition2 = new Telerik.WinControls.UI.TableViewDefinition();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CommissionSummaryByCompany));
            this.gbFilter = new Telerik.WinControls.UI.RadGroupBox();
            this.rdbPaid = new Telerik.WinControls.UI.RadRadioButton();
            this.rdbProcess = new Telerik.WinControls.UI.RadRadioButton();
            this.GRDType = new Telerik.WinControls.UI.RadGridView();
            this.cbCheckAll = new Telerik.WinControls.UI.RadCheckBox();
            this.GRDCompany = new Telerik.WinControls.UI.RadGridView();
            this.ckbsummary = new Telerik.WinControls.UI.RadCheckBox();
            this.lblCompany = new Telerik.WinControls.UI.RadLabel();
            this.CreationDate2 = new Telerik.WinControls.UI.RadDateTimePicker();
            this.CreationDate1 = new Telerik.WinControls.UI.RadDateTimePicker();
            this.Btnclear = new Telerik.WinControls.UI.RadButton();
            this.bSearch = new Telerik.WinControls.UI.RadButton();
            this.breezeTheme1 = new Telerik.WinControls.Themes.BreezeTheme();
            this.bgwSearch = new System.ComponentModel.BackgroundWorker();
            ((System.ComponentModel.ISupportInitialize)(this.gbFilter)).BeginInit();
            this.gbFilter.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.rdbPaid)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rdbProcess)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.GRDType)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.GRDType.MasterTemplate)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cbCheckAll)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.GRDCompany)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.GRDCompany.MasterTemplate)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ckbsummary)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblCompany)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.CreationDate2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.CreationDate1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Btnclear)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bSearch)).BeginInit();
            this.SuspendLayout();
            // 
            // gbFilter
            // 
            this.gbFilter.AccessibleRole = System.Windows.Forms.AccessibleRole.Grouping;
            this.gbFilter.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(244)))), ((int)(((byte)(253)))), ((int)(((byte)(255)))));
            this.gbFilter.Controls.Add(this.rdbPaid);
            this.gbFilter.Controls.Add(this.rdbProcess);
            this.gbFilter.Controls.Add(this.GRDType);
            this.gbFilter.Controls.Add(this.cbCheckAll);
            this.gbFilter.Controls.Add(this.GRDCompany);
            this.gbFilter.Controls.Add(this.ckbsummary);
            this.gbFilter.Controls.Add(this.lblCompany);
            this.gbFilter.Controls.Add(this.CreationDate2);
            this.gbFilter.Controls.Add(this.CreationDate1);
            this.gbFilter.Controls.Add(this.Btnclear);
            this.gbFilter.Controls.Add(this.bSearch);
            this.gbFilter.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gbFilter.GroupBoxStyle = Telerik.WinControls.UI.RadGroupBoxStyle.Office;
            this.gbFilter.HeaderAlignment = Telerik.WinControls.UI.HeaderAlignment.Center;
            this.gbFilter.HeaderText = "Filter";
            this.gbFilter.Location = new System.Drawing.Point(3, 3);
            this.gbFilter.Name = "gbFilter";
            // 
            // 
            // 
            this.gbFilter.RootElement.ControlBounds = new System.Drawing.Rectangle(3, 3, 200, 100);
            this.gbFilter.Size = new System.Drawing.Size(593, 319);
            this.gbFilter.TabIndex = 31;
            this.gbFilter.Text = "Filter";
            // 
            // rdbPaid
            // 
            this.rdbPaid.Location = new System.Drawing.Point(367, 280);
            this.rdbPaid.Name = "rdbPaid";
            this.rdbPaid.Size = new System.Drawing.Size(42, 18);
            this.rdbPaid.TabIndex = 85;
            this.rdbPaid.TabStop = false;
            this.rdbPaid.Text = "Paid";
            // 
            // rdbProcess
            // 
            this.rdbProcess.CheckState = System.Windows.Forms.CheckState.Checked;
            this.rdbProcess.Location = new System.Drawing.Point(291, 280);
            this.rdbProcess.Name = "rdbProcess";
            this.rdbProcess.Size = new System.Drawing.Size(70, 18);
            this.rdbProcess.TabIndex = 84;
            this.rdbProcess.Text = "Processed";
            this.rdbProcess.ToggleState = Telerik.WinControls.Enumerations.ToggleState.On;
            // 
            // GRDType
            // 
            this.GRDType.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.GRDType.Cursor = System.Windows.Forms.Cursors.Hand;
            this.GRDType.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.GRDType.Location = new System.Drawing.Point(5, 24);
            // 
            // 
            // 
            this.GRDType.MasterTemplate.AllowAddNewRow = false;
            this.GRDType.MasterTemplate.AllowCellContextMenu = false;
            this.GRDType.MasterTemplate.AllowColumnHeaderContextMenu = false;
            this.GRDType.MasterTemplate.AllowDeleteRow = false;
            this.GRDType.MasterTemplate.AllowRowHeaderContextMenu = false;
            this.GRDType.MasterTemplate.AutoGenerateColumns = false;
            gridViewTextBoxColumn1.FieldName = "TypeID";
            gridViewTextBoxColumn1.HeaderText = "TypeID";
            gridViewTextBoxColumn1.IsVisible = false;
            gridViewTextBoxColumn1.Name = "TypeID";
            gridViewCheckBoxColumn1.DataType = typeof(int);
            gridViewCheckBoxColumn1.FieldName = "selected";
            gridViewCheckBoxColumn1.HeaderText = "Select";
            gridViewCheckBoxColumn1.Name = "Select";
            gridViewCheckBoxColumn1.ReadOnly = true;
            gridViewCheckBoxColumn1.Width = 60;
            gridViewTextBoxColumn2.FieldName = "Description";
            gridViewTextBoxColumn2.HeaderText = "Type";
            gridViewTextBoxColumn2.Name = "Description";
            gridViewTextBoxColumn2.ReadOnly = true;
            gridViewTextBoxColumn2.Width = 200;
            this.GRDType.MasterTemplate.Columns.AddRange(new Telerik.WinControls.UI.GridViewDataColumn[] {
            gridViewTextBoxColumn1,
            gridViewCheckBoxColumn1,
            gridViewTextBoxColumn2});
            this.GRDType.MasterTemplate.ViewDefinition = tableViewDefinition1;
            this.GRDType.Name = "GRDType";
            // 
            // 
            // 
            this.GRDType.RootElement.ControlBounds = new System.Drawing.Rectangle(5, 24, 240, 150);
            this.GRDType.ShowGroupPanel = false;
            this.GRDType.Size = new System.Drawing.Size(286, 207);
            this.GRDType.TabIndex = 39;
            this.GRDType.ThemeName = "Breeze";
            this.GRDType.CellClick += new Telerik.WinControls.UI.GridViewCellEventHandler(this.GRDType_CellClick);
            // 
            // cbCheckAll
            // 
            this.cbCheckAll.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(244)))), ((int)(((byte)(253)))), ((int)(((byte)(255)))));
            this.cbCheckAll.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbCheckAll.Location = new System.Drawing.Point(297, 237);
            this.cbCheckAll.Name = "cbCheckAll";
            // 
            // 
            // 
            this.cbCheckAll.RootElement.ControlBounds = new System.Drawing.Rectangle(297, 237, 100, 18);
            this.cbCheckAll.RootElement.StretchHorizontally = true;
            this.cbCheckAll.RootElement.StretchVertically = true;
            this.cbCheckAll.Size = new System.Drawing.Size(90, 18);
            this.cbCheckAll.TabIndex = 38;
            this.cbCheckAll.Text = "Check All";
            this.cbCheckAll.CheckStateChanged += new System.EventHandler(this.cbCheckAll_CheckStateChanged);
            // 
            // GRDCompany
            // 
            this.GRDCompany.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.GRDCompany.Cursor = System.Windows.Forms.Cursors.Hand;
            this.GRDCompany.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.GRDCompany.Location = new System.Drawing.Point(297, 24);
            // 
            // 
            // 
            this.GRDCompany.MasterTemplate.AllowAddNewRow = false;
            this.GRDCompany.MasterTemplate.AllowCellContextMenu = false;
            this.GRDCompany.MasterTemplate.AllowColumnHeaderContextMenu = false;
            this.GRDCompany.MasterTemplate.AllowDeleteRow = false;
            this.GRDCompany.MasterTemplate.AllowRowHeaderContextMenu = false;
            this.GRDCompany.MasterTemplate.AutoGenerateColumns = false;
            gridViewTextBoxColumn3.FieldName = "CompanyNameID";
            gridViewTextBoxColumn3.HeaderText = "CompanyNameID";
            gridViewTextBoxColumn3.IsVisible = false;
            gridViewTextBoxColumn3.Name = "CompanyNameID";
            gridViewCheckBoxColumn2.DataType = typeof(int);
            gridViewCheckBoxColumn2.FieldName = "selected";
            gridViewCheckBoxColumn2.HeaderText = "Select";
            gridViewCheckBoxColumn2.Name = "Select";
            gridViewCheckBoxColumn2.Width = 60;
            gridViewTextBoxColumn4.FieldName = "Description";
            gridViewTextBoxColumn4.HeaderText = "Description";
            gridViewTextBoxColumn4.Name = "Description";
            gridViewTextBoxColumn4.ReadOnly = true;
            gridViewTextBoxColumn4.Width = 200;
            gridViewTextBoxColumn5.FieldName = "Type";
            gridViewTextBoxColumn5.HeaderText = "TypeID";
            gridViewTextBoxColumn5.Name = "TypeID";
            this.GRDCompany.MasterTemplate.Columns.AddRange(new Telerik.WinControls.UI.GridViewDataColumn[] {
            gridViewTextBoxColumn3,
            gridViewCheckBoxColumn2,
            gridViewTextBoxColumn4,
            gridViewTextBoxColumn5});
            this.GRDCompany.MasterTemplate.ViewDefinition = tableViewDefinition2;
            this.GRDCompany.Name = "GRDCompany";
            // 
            // 
            // 
            this.GRDCompany.RootElement.ControlBounds = new System.Drawing.Rectangle(297, 24, 240, 150);
            this.GRDCompany.ShowGroupPanel = false;
            this.GRDCompany.Size = new System.Drawing.Size(286, 207);
            this.GRDCompany.TabIndex = 37;
            this.GRDCompany.ThemeName = "Breeze";
            // 
            // ckbsummary
            // 
            this.ckbsummary.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(244)))), ((int)(((byte)(253)))), ((int)(((byte)(255)))));
            this.ckbsummary.CheckState = System.Windows.Forms.CheckState.Checked;
            this.ckbsummary.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ckbsummary.Location = new System.Drawing.Point(93, 247);
            this.ckbsummary.Name = "ckbsummary";
            // 
            // 
            // 
            this.ckbsummary.RootElement.ControlBounds = new System.Drawing.Rectangle(93, 247, 100, 18);
            this.ckbsummary.RootElement.StretchHorizontally = true;
            this.ckbsummary.RootElement.StretchVertically = true;
            this.ckbsummary.Size = new System.Drawing.Size(89, 18);
            this.ckbsummary.TabIndex = 36;
            this.ckbsummary.Text = "Summary";
            this.ckbsummary.ToggleState = Telerik.WinControls.Enumerations.ToggleState.On;
            // 
            // lblCompany
            // 
            this.lblCompany.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCompany.Location = new System.Drawing.Point(5, 272);
            this.lblCompany.Name = "lblCompany";
            this.lblCompany.Size = new System.Drawing.Size(76, 21);
            this.lblCompany.TabIndex = 30;
            this.lblCompany.Text = "Date Range";
            this.lblCompany.TextAlignment = System.Drawing.ContentAlignment.TopLeft;
            // 
            // CreationDate2
            // 
            this.CreationDate2.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.CreationDate2.CustomFormat = "MM-dd-yyyy";
            this.CreationDate2.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CreationDate2.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.CreationDate2.Location = new System.Drawing.Point(190, 271);
            this.CreationDate2.MinDate = new System.DateTime(2000, 12, 1, 0, 0, 0, 0);
            this.CreationDate2.Name = "CreationDate2";
            // 
            // 
            // 
            this.CreationDate2.RootElement.ControlBounds = new System.Drawing.Rectangle(190, 271, 164, 20);
            this.CreationDate2.RootElement.StretchVertically = true;
            this.CreationDate2.Size = new System.Drawing.Size(91, 28);
            this.CreationDate2.TabIndex = 1;
            this.CreationDate2.TabStop = false;
            this.CreationDate2.Text = "09-19-2018";
            this.CreationDate2.ThemeName = "Breeze";
            this.CreationDate2.Value = new System.DateTime(2018, 9, 19, 0, 0, 0, 0);
            // 
            // CreationDate1
            // 
            this.CreationDate1.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.CreationDate1.CustomFormat = "MM-dd-yyyy";
            this.CreationDate1.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CreationDate1.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.CreationDate1.Location = new System.Drawing.Point(93, 271);
            this.CreationDate1.MinDate = new System.DateTime(2000, 12, 1, 0, 0, 0, 0);
            this.CreationDate1.Name = "CreationDate1";
            // 
            // 
            // 
            this.CreationDate1.RootElement.ControlBounds = new System.Drawing.Rectangle(93, 271, 164, 20);
            this.CreationDate1.RootElement.StretchVertically = true;
            this.CreationDate1.Size = new System.Drawing.Size(91, 28);
            this.CreationDate1.TabIndex = 0;
            this.CreationDate1.TabStop = false;
            this.CreationDate1.Text = "09-19-2018";
            this.CreationDate1.ThemeName = "Breeze";
            this.CreationDate1.Value = new System.DateTime(2018, 9, 19, 0, 0, 0, 0);
            // 
            // Btnclear
            // 
            this.Btnclear.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.Btnclear.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Btnclear.ForeColor = System.Drawing.Color.Black;
            this.Btnclear.Image = global::Evolution.Properties.Resources.edit_clear__1_;
            this.Btnclear.ImageAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            this.Btnclear.Location = new System.Drawing.Point(513, 270);
            this.Btnclear.Name = "Btnclear";
            // 
            // 
            // 
            this.Btnclear.RootElement.ControlBounds = new System.Drawing.Rectangle(513, 270, 110, 24);
            this.Btnclear.Size = new System.Drawing.Size(70, 32);
            this.Btnclear.TabIndex = 5;
            this.Btnclear.Text = "Clear";
            this.Btnclear.TextAlignment = System.Drawing.ContentAlignment.MiddleLeft;
            this.Btnclear.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.Btnclear.Click += new System.EventHandler(this.Btnclear_Click);
            ((Telerik.WinControls.UI.RadButtonElement)(this.Btnclear.GetChildAt(0))).Image = global::Evolution.Properties.Resources.edit_clear__1_;
            ((Telerik.WinControls.UI.RadButtonElement)(this.Btnclear.GetChildAt(0))).TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            ((Telerik.WinControls.UI.RadButtonElement)(this.Btnclear.GetChildAt(0))).ImageAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            ((Telerik.WinControls.UI.RadButtonElement)(this.Btnclear.GetChildAt(0))).TextAlignment = System.Drawing.ContentAlignment.MiddleLeft;
            ((Telerik.WinControls.UI.RadButtonElement)(this.Btnclear.GetChildAt(0))).Text = "Clear";
            ((Telerik.WinControls.Primitives.ImagePrimitive)(this.Btnclear.GetChildAt(0).GetChildAt(1).GetChildAt(0))).ImageScaling = Telerik.WinControls.Enumerations.ImageScaling.SizeToFit;
            // 
            // bSearch
            // 
            this.bSearch.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.bSearch.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bSearch.ForeColor = System.Drawing.Color.Black;
            this.bSearch.Image = global::Evolution.Properties.Resources.printer_green;
            this.bSearch.ImageAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            this.bSearch.Location = new System.Drawing.Point(437, 270);
            this.bSearch.Name = "bSearch";
            // 
            // 
            // 
            this.bSearch.RootElement.ControlBounds = new System.Drawing.Rectangle(437, 270, 110, 24);
            this.bSearch.Size = new System.Drawing.Size(70, 32);
            this.bSearch.TabIndex = 4;
            this.bSearch.Text = "Print";
            this.bSearch.TextAlignment = System.Drawing.ContentAlignment.MiddleLeft;
            this.bSearch.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.bSearch.Click += new System.EventHandler(this.bSearch_Click);
            ((Telerik.WinControls.UI.RadButtonElement)(this.bSearch.GetChildAt(0))).Image = global::Evolution.Properties.Resources.printer_green;
            ((Telerik.WinControls.UI.RadButtonElement)(this.bSearch.GetChildAt(0))).TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            ((Telerik.WinControls.UI.RadButtonElement)(this.bSearch.GetChildAt(0))).ImageAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            ((Telerik.WinControls.UI.RadButtonElement)(this.bSearch.GetChildAt(0))).TextAlignment = System.Drawing.ContentAlignment.MiddleLeft;
            ((Telerik.WinControls.UI.RadButtonElement)(this.bSearch.GetChildAt(0))).Text = "Print";
            ((Telerik.WinControls.Primitives.ImagePrimitive)(this.bSearch.GetChildAt(0).GetChildAt(1).GetChildAt(0))).ImageScaling = Telerik.WinControls.Enumerations.ImageScaling.SizeToFit;
            // 
            // bgwSearch
            // 
            this.bgwSearch.DoWork += new System.ComponentModel.DoWorkEventHandler(this.bgwSearch_DoWork);
            this.bgwSearch.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.bgwSearch_RunWorkerCompleted);
            // 
            // CommissionSummaryByCompany
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(244)))), ((int)(((byte)(253)))), ((int)(((byte)(255)))));
            this.ClientSize = new System.Drawing.Size(598, 331);
            this.Controls.Add(this.gbFilter);
            this.DoubleBuffered = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.Name = "CommissionSummaryByCompany";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Commission Summary By Company";
            this.Load += new System.EventHandler(this.CommissionSummaryByCompany_Load);
            this.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.CommissionSummaryByCompany_KeyPress);
            ((System.ComponentModel.ISupportInitialize)(this.gbFilter)).EndInit();
            this.gbFilter.ResumeLayout(false);
            this.gbFilter.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.rdbPaid)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rdbProcess)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.GRDType.MasterTemplate)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.GRDType)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cbCheckAll)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.GRDCompany.MasterTemplate)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.GRDCompany)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ckbsummary)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblCompany)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.CreationDate2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.CreationDate1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Btnclear)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bSearch)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Telerik.WinControls.UI.RadGroupBox gbFilter;
        private Telerik.WinControls.UI.RadCheckBox ckbsummary;
        private Telerik.WinControls.UI.RadLabel lblCompany;
        private Telerik.WinControls.UI.RadDateTimePicker CreationDate2;
        private Telerik.WinControls.UI.RadDateTimePicker CreationDate1;
        private Telerik.WinControls.UI.RadButton Btnclear;
        private Telerik.WinControls.UI.RadButton bSearch;
        private Telerik.WinControls.Themes.BreezeTheme breezeTheme1;
        private System.ComponentModel.BackgroundWorker bgwSearch;
        private Telerik.WinControls.UI.RadGridView GRDCompany;
        private Telerik.WinControls.UI.RadCheckBox cbCheckAll;
        private Telerik.WinControls.UI.RadGridView GRDType;
        private Telerik.WinControls.UI.RadRadioButton rdbPaid;
        private Telerik.WinControls.UI.RadRadioButton rdbProcess;
    }
}