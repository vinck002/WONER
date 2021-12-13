namespace Evolution.Forms
{
    partial class R_WeeklyReport
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(R_WeeklyReport));
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            this.breezeTheme1 = new Telerik.WinControls.Themes.BreezeTheme();
            this.radGroupBox5 = new Telerik.WinControls.UI.RadGroupBox();
            this.radLabel2 = new Telerik.WinControls.UI.RadLabel();
            this.ckbExportExcel = new Telerik.WinControls.UI.RadCheckBox();
            this.radLabel1 = new Telerik.WinControls.UI.RadLabel();
            this.Paymentmethod = new Telerik.WinControls.UI.RadDropDownList();
            this.CreationDate2 = new Telerik.WinControls.UI.RadDateTimePicker();
            this.CreationDate1 = new Telerik.WinControls.UI.RadDateTimePicker();
            this.Btnclear = new Telerik.WinControls.UI.RadButton();
            this.PropertyID = new Telerik.WinControls.UI.RadTextBox();
            this.SalesfloorID = new Telerik.WinControls.UI.RadTextBox();
            this.bSearch = new Telerik.WinControls.UI.RadButton();
            this.bExit = new Telerik.WinControls.UI.RadButton();
            this.rdbPaid = new Telerik.WinControls.UI.RadRadioButton();
            this.rdbProcess = new Telerik.WinControls.UI.RadRadioButton();
            ((System.ComponentModel.ISupportInitialize)(this.radGroupBox5)).BeginInit();
            this.radGroupBox5.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ckbExportExcel)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Paymentmethod)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.CreationDate2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.CreationDate1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Btnclear)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.PropertyID)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.SalesfloorID)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bSearch)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bExit)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rdbPaid)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rdbProcess)).BeginInit();
            this.SuspendLayout();
            // 
            // backgroundWorker1
            // 
            this.backgroundWorker1.DoWork += new System.ComponentModel.DoWorkEventHandler(this.backgroundWorker1_DoWork);
            this.backgroundWorker1.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.backgroundWorker1_RunWorkerCompleted);
            // 
            // radGroupBox5
            // 
            this.radGroupBox5.AccessibleRole = System.Windows.Forms.AccessibleRole.Grouping;
            this.radGroupBox5.Controls.Add(this.rdbPaid);
            this.radGroupBox5.Controls.Add(this.rdbProcess);
            this.radGroupBox5.Controls.Add(this.radLabel2);
            this.radGroupBox5.Controls.Add(this.ckbExportExcel);
            this.radGroupBox5.Controls.Add(this.radLabel1);
            this.radGroupBox5.Controls.Add(this.Paymentmethod);
            this.radGroupBox5.Controls.Add(this.CreationDate2);
            this.radGroupBox5.Controls.Add(this.CreationDate1);
            this.radGroupBox5.Controls.Add(this.Btnclear);
            this.radGroupBox5.Controls.Add(this.PropertyID);
            this.radGroupBox5.Controls.Add(this.SalesfloorID);
            this.radGroupBox5.Controls.Add(this.bSearch);
            this.radGroupBox5.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.radGroupBox5.GroupBoxStyle = Telerik.WinControls.UI.RadGroupBoxStyle.Office;
            this.radGroupBox5.HeaderAlignment = Telerik.WinControls.UI.HeaderAlignment.Center;
            this.radGroupBox5.HeaderText = "Payments History";
            this.radGroupBox5.Location = new System.Drawing.Point(6, 6);
            this.radGroupBox5.Name = "radGroupBox5";
            this.radGroupBox5.Size = new System.Drawing.Size(608, 131);
            this.radGroupBox5.TabIndex = 29;
            this.radGroupBox5.Text = "Payments History";
            ((Telerik.WinControls.UI.RadGroupBoxElement)(this.radGroupBox5.GetChildAt(0))).HeaderAlignment = Telerik.WinControls.UI.HeaderAlignment.Center;
            ((Telerik.WinControls.UI.GroupBoxHeader)(this.radGroupBox5.GetChildAt(0).GetChildAt(1))).GroupBoxStyle = Telerik.WinControls.UI.RadGroupBoxStyle.Office;
            ((Telerik.WinControls.Primitives.FillPrimitive)(this.radGroupBox5.GetChildAt(0).GetChildAt(1).GetChildAt(0))).BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(233)))), ((int)(((byte)(243)))), ((int)(((byte)(250)))));
            ((Telerik.WinControls.Primitives.FillPrimitive)(this.radGroupBox5.GetChildAt(0).GetChildAt(1).GetChildAt(0))).SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.None;
            ((Telerik.WinControls.Primitives.FillPrimitive)(this.radGroupBox5.GetChildAt(0).GetChildAt(2).GetChildAt(0))).BackColor = System.Drawing.Color.Red;
            ((Telerik.WinControls.Primitives.FillPrimitive)(this.radGroupBox5.GetChildAt(0).GetChildAt(2).GetChildAt(0))).SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.None;
            // 
            // radLabel2
            // 
            this.radLabel2.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.radLabel2.Location = new System.Drawing.Point(40, 73);
            this.radLabel2.Name = "radLabel2";
            this.radLabel2.Size = new System.Drawing.Size(76, 21);
            this.radLabel2.TabIndex = 38;
            this.radLabel2.Text = "Date Range";
            this.radLabel2.TextAlignment = System.Drawing.ContentAlignment.TopLeft;
            // 
            // ckbExportExcel
            // 
            this.ckbExportExcel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(244)))), ((int)(((byte)(253)))), ((int)(((byte)(255)))));
            this.ckbExportExcel.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ckbExportExcel.Location = new System.Drawing.Point(343, 36);
            this.ckbExportExcel.Name = "ckbExportExcel";
            // 
            // 
            // 
            this.ckbExportExcel.RootElement.ControlBounds = new System.Drawing.Rectangle(343, 30, 100, 18);
            this.ckbExportExcel.RootElement.StretchHorizontally = true;
            this.ckbExportExcel.RootElement.StretchVertically = true;
            this.ckbExportExcel.Size = new System.Drawing.Size(243, 18);
            this.ckbExportExcel.TabIndex = 37;
            this.ckbExportExcel.Text = "Export To Excel Summarized By Property";
            this.ckbExportExcel.CheckStateChanged += new System.EventHandler(this.ckbExportExcel_CheckStateChanged);
            // 
            // radLabel1
            // 
            this.radLabel1.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.radLabel1.Location = new System.Drawing.Point(8, 33);
            this.radLabel1.Name = "radLabel1";
            this.radLabel1.Size = new System.Drawing.Size(109, 21);
            this.radLabel1.TabIndex = 30;
            this.radLabel1.Text = "Payment Method";
            this.radLabel1.TextAlignment = System.Drawing.ContentAlignment.TopLeft;
            // 
            // Paymentmethod
            // 
            this.Paymentmethod.AutoSize = false;
            this.Paymentmethod.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.Paymentmethod.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Paymentmethod.Location = new System.Drawing.Point(123, 27);
            this.Paymentmethod.Name = "Paymentmethod";
            this.Paymentmethod.NullText = "Payment Method";
            this.Paymentmethod.Size = new System.Drawing.Size(214, 32);
            this.Paymentmethod.TabIndex = 0;
            this.Paymentmethod.Tag = "0";
            this.Paymentmethod.ThemeName = "Breeze";
            // 
            // CreationDate2
            // 
            this.CreationDate2.AutoSize = false;
            this.CreationDate2.CustomFormat = "";
            this.CreationDate2.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CreationDate2.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.CreationDate2.Location = new System.Drawing.Point(218, 66);
            this.CreationDate2.Name = "CreationDate2";
            this.CreationDate2.Size = new System.Drawing.Size(90, 32);
            this.CreationDate2.TabIndex = 2;
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
            this.CreationDate1.Location = new System.Drawing.Point(122, 66);
            this.CreationDate1.Name = "CreationDate1";
            this.CreationDate1.Size = new System.Drawing.Size(90, 32);
            this.CreationDate1.TabIndex = 1;
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
            this.Btnclear.Location = new System.Drawing.Point(477, 67);
            this.Btnclear.Name = "Btnclear";
            this.Btnclear.Size = new System.Drawing.Size(70, 32);
            this.Btnclear.TabIndex = 6;
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
            // PropertyID
            // 
            this.PropertyID.AutoSize = false;
            this.PropertyID.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.PropertyID.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.PropertyID.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.PropertyID.Location = new System.Drawing.Point(354, 66);
            this.PropertyID.Name = "PropertyID";
            this.PropertyID.Size = new System.Drawing.Size(34, 33);
            this.PropertyID.TabIndex = 4;
            this.PropertyID.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.PropertyID.ThemeName = "Breeze";
            this.PropertyID.TextChanged += new System.EventHandler(this.PropertyID_TextChanged);
            // 
            // SalesfloorID
            // 
            this.SalesfloorID.AutoSize = false;
            this.SalesfloorID.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.SalesfloorID.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.SalesfloorID.Location = new System.Drawing.Point(314, 66);
            this.SalesfloorID.Name = "SalesfloorID";
            this.SalesfloorID.Size = new System.Drawing.Size(34, 33);
            this.SalesfloorID.TabIndex = 3;
            this.SalesfloorID.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.SalesfloorID.ThemeName = "Breeze";
            this.SalesfloorID.TextChanged += new System.EventHandler(this.SalesfloorID_TextChanged);
            this.SalesfloorID.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.SalesfloorID_KeyPress);
            // 
            // bSearch
            // 
            this.bSearch.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bSearch.ForeColor = System.Drawing.Color.Black;
            this.bSearch.Image = global::Evolution.Properties.Resources.printer_green;
            this.bSearch.ImageAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            this.bSearch.Location = new System.Drawing.Point(401, 67);
            this.bSearch.Name = "bSearch";
            this.bSearch.Size = new System.Drawing.Size(70, 32);
            this.bSearch.TabIndex = 5;
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
            this.bExit.Location = new System.Drawing.Point(544, 143);
            this.bExit.Name = "bExit";
            this.bExit.Size = new System.Drawing.Size(70, 32);
            this.bExit.TabIndex = 7;
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
            // rdbPaid
            // 
            this.rdbPaid.Location = new System.Drawing.Point(282, 104);
            this.rdbPaid.Name = "rdbPaid";
            this.rdbPaid.Size = new System.Drawing.Size(106, 18);
            this.rdbPaid.TabIndex = 87;
            this.rdbPaid.TabStop = false;
            this.rdbPaid.Text = "Commission Paid";
            this.rdbPaid.Visible = false;
            // 
            // rdbProcess
            // 
            this.rdbProcess.CheckState = System.Windows.Forms.CheckState.Checked;
            this.rdbProcess.Location = new System.Drawing.Point(123, 104);
            this.rdbProcess.Name = "rdbProcess";
            this.rdbProcess.Size = new System.Drawing.Size(135, 18);
            this.rdbProcess.TabIndex = 86;
            this.rdbProcess.Text = "Commission Processed";
            this.rdbProcess.ToggleState = Telerik.WinControls.Enumerations.ToggleState.On;
            this.rdbProcess.Visible = false;
            // 
            // R_WeeklyReport
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(244)))), ((int)(((byte)(253)))), ((int)(((byte)(255)))));
            this.ClientSize = new System.Drawing.Size(620, 179);
            this.Controls.Add(this.bExit);
            this.Controls.Add(this.radGroupBox5);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.Name = "R_WeeklyReport";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Weekly Payments Report";
            this.Load += new System.EventHandler(this.R_WeeklyReport_Load);
            this.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.R_WeeklyReport_KeyPress);
            ((System.ComponentModel.ISupportInitialize)(this.radGroupBox5)).EndInit();
            this.radGroupBox5.ResumeLayout(false);
            this.radGroupBox5.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ckbExportExcel)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Paymentmethod)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.CreationDate2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.CreationDate1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Btnclear)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.PropertyID)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.SalesfloorID)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bSearch)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bExit)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rdbPaid)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rdbProcess)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.ComponentModel.BackgroundWorker backgroundWorker1;
        private Telerik.WinControls.Themes.BreezeTheme breezeTheme1;
        private Telerik.WinControls.UI.RadGroupBox radGroupBox5;
        private Telerik.WinControls.UI.RadLabel radLabel1;
        private Telerik.WinControls.UI.RadDropDownList Paymentmethod;
        private Telerik.WinControls.UI.RadDateTimePicker CreationDate2;
        private Telerik.WinControls.UI.RadDateTimePicker CreationDate1;
        private Telerik.WinControls.UI.RadButton Btnclear;
        private Telerik.WinControls.UI.RadTextBox PropertyID;
        private Telerik.WinControls.UI.RadTextBox SalesfloorID;
        private Telerik.WinControls.UI.RadButton bSearch;
        private Telerik.WinControls.UI.RadButton bExit;
        private Telerik.WinControls.UI.RadLabel radLabel2;
        private Telerik.WinControls.UI.RadCheckBox ckbExportExcel;
        private Telerik.WinControls.UI.RadRadioButton rdbPaid;
        private Telerik.WinControls.UI.RadRadioButton rdbProcess;
    }
}