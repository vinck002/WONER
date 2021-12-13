namespace Evolution.Forms
{
    partial class R_AnnualSettlementSummary
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
            Telerik.WinControls.UI.GridViewTextBoxColumn gridViewTextBoxColumn3 = new Telerik.WinControls.UI.GridViewTextBoxColumn();
            Telerik.WinControls.UI.TableViewDefinition tableViewDefinition1 = new Telerik.WinControls.UI.TableViewDefinition();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(R_AnnualSettlementSummary));
            this.radLabel2 = new Telerik.WinControls.UI.RadLabel();
            this.CreationDate2 = new Telerik.WinControls.UI.RadDateTimePicker();
            this.CreationDate1 = new Telerik.WinControls.UI.RadDateTimePicker();
            this.Btnclear = new Telerik.WinControls.UI.RadButton();
            this.bSearch = new Telerik.WinControls.UI.RadButton();
            this.bExit = new Telerik.WinControls.UI.RadButton();
            this.GRDSalesfloor = new Telerik.WinControls.UI.RadGridView();
            this.breezeTheme1 = new Telerik.WinControls.Themes.BreezeTheme();
            this.bgwSearch = new System.ComponentModel.BackgroundWorker();
            this.ddlSalesfloor = new Telerik.WinControls.UI.RadDropDownList();
            this.radLabel1 = new Telerik.WinControls.UI.RadLabel();
            this.radLabel3 = new Telerik.WinControls.UI.RadLabel();
            this.btnAdd = new Telerik.WinControls.UI.RadButton();
            this.btnRemove = new Telerik.WinControls.UI.RadButton();
            this.mebYear = new Telerik.WinControls.UI.RadMaskedEditBox();
            this.rdbPaid = new Telerik.WinControls.UI.RadRadioButton();
            this.rdbProcess = new Telerik.WinControls.UI.RadRadioButton();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.CreationDate2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.CreationDate1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Btnclear)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bSearch)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bExit)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.GRDSalesfloor)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.GRDSalesfloor.MasterTemplate)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ddlSalesfloor)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnAdd)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnRemove)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.mebYear)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rdbPaid)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rdbProcess)).BeginInit();
            this.SuspendLayout();
            // 
            // radLabel2
            // 
            this.radLabel2.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.radLabel2.Location = new System.Drawing.Point(28, 18);
            this.radLabel2.Name = "radLabel2";
            this.radLabel2.Size = new System.Drawing.Size(76, 21);
            this.radLabel2.TabIndex = 41;
            this.radLabel2.Text = "Date Range";
            this.radLabel2.TextAlignment = System.Drawing.ContentAlignment.TopLeft;
            // 
            // CreationDate2
            // 
            this.CreationDate2.AutoSize = false;
            this.CreationDate2.CustomFormat = "";
            this.CreationDate2.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CreationDate2.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.CreationDate2.Location = new System.Drawing.Point(206, 12);
            this.CreationDate2.MinDate = new System.DateTime(2000, 1, 1, 0, 0, 0, 0);
            this.CreationDate2.Name = "CreationDate2";
            this.CreationDate2.Size = new System.Drawing.Size(90, 32);
            this.CreationDate2.TabIndex = 1;
            this.CreationDate2.TabStop = false;
            this.CreationDate2.Text = "12/13/2017";
            this.CreationDate2.ThemeName = "Breeze";
            this.CreationDate2.Value = new System.DateTime(2017, 12, 13, 0, 0, 0, 0);
            // 
            // CreationDate1
            // 
            this.CreationDate1.AutoSize = false;
            this.CreationDate1.CustomFormat = "";
            this.CreationDate1.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CreationDate1.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.CreationDate1.Location = new System.Drawing.Point(110, 12);
            this.CreationDate1.MinDate = new System.DateTime(2000, 1, 1, 0, 0, 0, 0);
            this.CreationDate1.Name = "CreationDate1";
            this.CreationDate1.Size = new System.Drawing.Size(90, 32);
            this.CreationDate1.TabIndex = 0;
            this.CreationDate1.TabStop = false;
            this.CreationDate1.Text = "12/13/2017";
            this.CreationDate1.ThemeName = "Breeze";
            this.CreationDate1.Value = new System.DateTime(2017, 12, 13, 0, 0, 0, 0);
            // 
            // Btnclear
            // 
            this.Btnclear.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Btnclear.ForeColor = System.Drawing.Color.Black;
            this.Btnclear.Image = global::Evolution.Properties.Resources.edit_clear__1_;
            this.Btnclear.ImageAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            this.Btnclear.Location = new System.Drawing.Point(281, 387);
            this.Btnclear.Name = "Btnclear";
            this.Btnclear.Size = new System.Drawing.Size(70, 32);
            this.Btnclear.TabIndex = 9;
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
            this.bSearch.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bSearch.ForeColor = System.Drawing.Color.Black;
            this.bSearch.Image = global::Evolution.Properties.Resources.printer_green;
            this.bSearch.ImageAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            this.bSearch.Location = new System.Drawing.Point(205, 387);
            this.bSearch.Name = "bSearch";
            this.bSearch.Size = new System.Drawing.Size(70, 32);
            this.bSearch.TabIndex = 8;
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
            // bExit
            // 
            this.bExit.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bExit.ForeColor = System.Drawing.Color.Black;
            this.bExit.Image = global::Evolution.Properties.Resources.salir;
            this.bExit.ImageAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            this.bExit.Location = new System.Drawing.Point(357, 387);
            this.bExit.Name = "bExit";
            this.bExit.Size = new System.Drawing.Size(70, 32);
            this.bExit.TabIndex = 10;
            this.bExit.Text = "Exit";
            this.bExit.TextAlignment = System.Drawing.ContentAlignment.MiddleLeft;
            this.bExit.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.bExit.Click += new System.EventHandler(this.bExit_Click);
            ((Telerik.WinControls.UI.RadButtonElement)(this.bExit.GetChildAt(0))).Image = global::Evolution.Properties.Resources.salir;
            ((Telerik.WinControls.UI.RadButtonElement)(this.bExit.GetChildAt(0))).TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            ((Telerik.WinControls.UI.RadButtonElement)(this.bExit.GetChildAt(0))).ImageAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            ((Telerik.WinControls.UI.RadButtonElement)(this.bExit.GetChildAt(0))).TextAlignment = System.Drawing.ContentAlignment.MiddleLeft;
            ((Telerik.WinControls.UI.RadButtonElement)(this.bExit.GetChildAt(0))).Text = "Exit";
            ((Telerik.WinControls.Primitives.ImagePrimitive)(this.bExit.GetChildAt(0).GetChildAt(1).GetChildAt(0))).ImageScaling = Telerik.WinControls.Enumerations.ImageScaling.SizeToFit;
            // 
            // GRDSalesfloor
            // 
            this.GRDSalesfloor.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(237)))), ((int)(((byte)(246)))), ((int)(((byte)(194)))));
            this.GRDSalesfloor.Cursor = System.Windows.Forms.Cursors.Default;
            this.GRDSalesfloor.Font = new System.Drawing.Font("Segoe UI", 9.75F);
            this.GRDSalesfloor.ForeColor = System.Drawing.SystemColors.ControlText;
            this.GRDSalesfloor.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.GRDSalesfloor.Location = new System.Drawing.Point(5, 118);
            // 
            // 
            // 
            this.GRDSalesfloor.MasterTemplate.AllowAddNewRow = false;
            this.GRDSalesfloor.MasterTemplate.AllowColumnReorder = false;
            this.GRDSalesfloor.MasterTemplate.AllowDragToGroup = false;
            this.GRDSalesfloor.MasterTemplate.AutoGenerateColumns = false;
            gridViewTextBoxColumn1.EnableExpressionEditor = false;
            gridViewTextBoxColumn1.FieldName = "SalesFloorID";
            gridViewTextBoxColumn1.HeaderText = "SalesFloorID";
            gridViewTextBoxColumn1.IsVisible = false;
            gridViewTextBoxColumn1.Name = "SalesFloorID";
            gridViewTextBoxColumn1.ReadOnly = true;
            gridViewTextBoxColumn1.Width = 100;
            gridViewTextBoxColumn2.AllowGroup = false;
            gridViewTextBoxColumn2.AllowSort = false;
            gridViewTextBoxColumn2.EnableExpressionEditor = false;
            gridViewTextBoxColumn2.HeaderText = "Year";
            gridViewTextBoxColumn2.Name = "Year";
            gridViewTextBoxColumn2.ReadOnly = true;
            gridViewTextBoxColumn2.Width = 90;
            gridViewTextBoxColumn3.AllowGroup = false;
            gridViewTextBoxColumn3.AllowSort = false;
            gridViewTextBoxColumn3.EnableExpressionEditor = false;
            gridViewTextBoxColumn3.HeaderText = "SalesFloor";
            gridViewTextBoxColumn3.Name = "SalesFloor";
            gridViewTextBoxColumn3.ReadOnly = true;
            gridViewTextBoxColumn3.Width = 300;
            this.GRDSalesfloor.MasterTemplate.Columns.AddRange(new Telerik.WinControls.UI.GridViewDataColumn[] {
            gridViewTextBoxColumn1,
            gridViewTextBoxColumn2,
            gridViewTextBoxColumn3});
            this.GRDSalesfloor.MasterTemplate.EnableGrouping = false;
            this.GRDSalesfloor.MasterTemplate.EnableSorting = false;
            this.GRDSalesfloor.MasterTemplate.ShowGroupedColumns = true;
            this.GRDSalesfloor.MasterTemplate.ViewDefinition = tableViewDefinition1;
            this.GRDSalesfloor.Name = "GRDSalesfloor";
            this.GRDSalesfloor.ReadOnly = true;
            this.GRDSalesfloor.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.GRDSalesfloor.ShowGroupPanel = false;
            this.GRDSalesfloor.Size = new System.Drawing.Size(422, 263);
            this.GRDSalesfloor.TabIndex = 67;
            this.GRDSalesfloor.ThemeName = "Breeze";
            // 
            // bgwSearch
            // 
            this.bgwSearch.DoWork += new System.ComponentModel.DoWorkEventHandler(this.bgwSearch_DoWork);
            this.bgwSearch.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.bgwSearch_RunWorkerCompleted);
            // 
            // ddlSalesfloor
            // 
            this.ddlSalesfloor.AutoSize = false;
            this.ddlSalesfloor.DropDownStyle = Telerik.WinControls.RadDropDownStyle.DropDownList;
            this.ddlSalesfloor.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ddlSalesfloor.Location = new System.Drawing.Point(110, 50);
            this.ddlSalesfloor.Name = "ddlSalesfloor";
            this.ddlSalesfloor.NullText = "Company Name";
            this.ddlSalesfloor.Size = new System.Drawing.Size(317, 28);
            this.ddlSalesfloor.TabIndex = 4;
            this.ddlSalesfloor.ThemeName = "Breeze";
            // 
            // radLabel1
            // 
            this.radLabel1.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.radLabel1.Location = new System.Drawing.Point(37, 53);
            this.radLabel1.Name = "radLabel1";
            this.radLabel1.Size = new System.Drawing.Size(67, 21);
            this.radLabel1.TabIndex = 70;
            this.radLabel1.Text = "SalesFloor";
            this.radLabel1.TextAlignment = System.Drawing.ContentAlignment.TopLeft;
            // 
            // radLabel3
            // 
            this.radLabel3.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.radLabel3.Location = new System.Drawing.Point(71, 87);
            this.radLabel3.Name = "radLabel3";
            this.radLabel3.Size = new System.Drawing.Size(33, 21);
            this.radLabel3.TabIndex = 71;
            this.radLabel3.Text = "Year";
            this.radLabel3.TextAlignment = System.Drawing.ContentAlignment.TopLeft;
            // 
            // btnAdd
            // 
            this.btnAdd.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAdd.ForeColor = System.Drawing.Color.Black;
            this.btnAdd.Image = global::Evolution.Properties.Resources.Add;
            this.btnAdd.ImageAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            this.btnAdd.Location = new System.Drawing.Point(239, 84);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(70, 28);
            this.btnAdd.TabIndex = 6;
            this.btnAdd.Text = "Add";
            this.btnAdd.TextAlignment = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnAdd.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            ((Telerik.WinControls.UI.RadButtonElement)(this.btnAdd.GetChildAt(0))).Image = global::Evolution.Properties.Resources.Add;
            ((Telerik.WinControls.UI.RadButtonElement)(this.btnAdd.GetChildAt(0))).TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            ((Telerik.WinControls.UI.RadButtonElement)(this.btnAdd.GetChildAt(0))).ImageAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            ((Telerik.WinControls.UI.RadButtonElement)(this.btnAdd.GetChildAt(0))).TextAlignment = System.Drawing.ContentAlignment.MiddleLeft;
            ((Telerik.WinControls.UI.RadButtonElement)(this.btnAdd.GetChildAt(0))).Text = "Add";
            ((Telerik.WinControls.Primitives.ImagePrimitive)(this.btnAdd.GetChildAt(0).GetChildAt(1).GetChildAt(0))).ImageScaling = Telerik.WinControls.Enumerations.ImageScaling.SizeToFit;
            // 
            // btnRemove
            // 
            this.btnRemove.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnRemove.ForeColor = System.Drawing.Color.Black;
            this.btnRemove.Image = global::Evolution.Properties.Resources.quitar;
            this.btnRemove.ImageAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            this.btnRemove.Location = new System.Drawing.Point(315, 84);
            this.btnRemove.Name = "btnRemove";
            this.btnRemove.Size = new System.Drawing.Size(84, 28);
            this.btnRemove.TabIndex = 7;
            this.btnRemove.Text = "Remove";
            this.btnRemove.TextAlignment = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnRemove.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnRemove.Click += new System.EventHandler(this.btnRemove_Click);
            ((Telerik.WinControls.UI.RadButtonElement)(this.btnRemove.GetChildAt(0))).Image = global::Evolution.Properties.Resources.quitar;
            ((Telerik.WinControls.UI.RadButtonElement)(this.btnRemove.GetChildAt(0))).TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            ((Telerik.WinControls.UI.RadButtonElement)(this.btnRemove.GetChildAt(0))).ImageAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            ((Telerik.WinControls.UI.RadButtonElement)(this.btnRemove.GetChildAt(0))).TextAlignment = System.Drawing.ContentAlignment.MiddleLeft;
            ((Telerik.WinControls.UI.RadButtonElement)(this.btnRemove.GetChildAt(0))).Text = "Remove";
            ((Telerik.WinControls.Primitives.ImagePrimitive)(this.btnRemove.GetChildAt(0).GetChildAt(1).GetChildAt(0))).ImageScaling = Telerik.WinControls.Enumerations.ImageScaling.SizeToFit;
            // 
            // mebYear
            // 
            this.mebYear.AutoSize = false;
            this.mebYear.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.mebYear.Location = new System.Drawing.Point(110, 84);
            this.mebYear.Mask = "d";
            this.mebYear.MaskType = Telerik.WinControls.UI.MaskType.Numeric;
            this.mebYear.Name = "mebYear";
            this.mebYear.Size = new System.Drawing.Size(109, 28);
            this.mebYear.TabIndex = 5;
            this.mebYear.TabStop = false;
            this.mebYear.Text = "0";
            this.mebYear.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.mebYear.ThemeName = "Breeze";
            // 
            // rdbPaid
            // 
            this.rdbPaid.Location = new System.Drawing.Point(385, 21);
            this.rdbPaid.Name = "rdbPaid";
            this.rdbPaid.Size = new System.Drawing.Size(42, 18);
            this.rdbPaid.TabIndex = 3;
            this.rdbPaid.TabStop = false;
            this.rdbPaid.Text = "Paid";
            // 
            // rdbProcess
            // 
            this.rdbProcess.CheckState = System.Windows.Forms.CheckState.Checked;
            this.rdbProcess.Location = new System.Drawing.Point(309, 21);
            this.rdbProcess.Name = "rdbProcess";
            this.rdbProcess.Size = new System.Drawing.Size(70, 18);
            this.rdbProcess.TabIndex = 2;
            this.rdbProcess.Text = "Processed";
            this.rdbProcess.ToggleState = Telerik.WinControls.Enumerations.ToggleState.On;
            // 
            // R_AnnualSettlementSummary
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(244)))), ((int)(((byte)(253)))), ((int)(((byte)(255)))));
            this.ClientSize = new System.Drawing.Size(429, 420);
            this.Controls.Add(this.rdbPaid);
            this.Controls.Add(this.rdbProcess);
            this.Controls.Add(this.mebYear);
            this.Controls.Add(this.btnRemove);
            this.Controls.Add(this.btnAdd);
            this.Controls.Add(this.radLabel3);
            this.Controls.Add(this.radLabel1);
            this.Controls.Add(this.ddlSalesfloor);
            this.Controls.Add(this.GRDSalesfloor);
            this.Controls.Add(this.bExit);
            this.Controls.Add(this.Btnclear);
            this.Controls.Add(this.bSearch);
            this.Controls.Add(this.radLabel2);
            this.Controls.Add(this.CreationDate2);
            this.Controls.Add(this.CreationDate1);
            this.DoubleBuffered = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.Name = "R_AnnualSettlementSummary";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Annual Settlement Summary";
            this.Load += new System.EventHandler(this.R_AnnualSettlementSummary_Load);
            this.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.R_AnnualSettlementSummary_KeyPress);
            ((System.ComponentModel.ISupportInitialize)(this.radLabel2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.CreationDate2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.CreationDate1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Btnclear)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bSearch)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bExit)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.GRDSalesfloor.MasterTemplate)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.GRDSalesfloor)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ddlSalesfloor)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnAdd)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnRemove)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.mebYear)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rdbPaid)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rdbProcess)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Telerik.WinControls.UI.RadLabel radLabel2;
        private Telerik.WinControls.UI.RadDateTimePicker CreationDate2;
        private Telerik.WinControls.UI.RadDateTimePicker CreationDate1;
        private Telerik.WinControls.UI.RadButton Btnclear;
        private Telerik.WinControls.UI.RadButton bSearch;
        private Telerik.WinControls.UI.RadButton bExit;
        private Telerik.WinControls.UI.RadGridView GRDSalesfloor;
        private Telerik.WinControls.Themes.BreezeTheme breezeTheme1;
        private System.ComponentModel.BackgroundWorker bgwSearch;
        private Telerik.WinControls.UI.RadDropDownList ddlSalesfloor;
        private Telerik.WinControls.UI.RadLabel radLabel1;
        private Telerik.WinControls.UI.RadLabel radLabel3;
        private Telerik.WinControls.UI.RadButton btnAdd;
        private Telerik.WinControls.UI.RadButton btnRemove;
        private Telerik.WinControls.UI.RadMaskedEditBox mebYear;
        private Telerik.WinControls.UI.RadRadioButton rdbPaid;
        private Telerik.WinControls.UI.RadRadioButton rdbProcess;
    }
}