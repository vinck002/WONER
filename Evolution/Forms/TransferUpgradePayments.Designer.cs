namespace Evolution.Forms
{
    partial class TransferUpgradePayments
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
            Telerik.WinControls.UI.GridViewTextBoxColumn gridViewTextBoxColumn5 = new Telerik.WinControls.UI.GridViewTextBoxColumn();
            Telerik.WinControls.UI.GridViewTextBoxColumn gridViewTextBoxColumn6 = new Telerik.WinControls.UI.GridViewTextBoxColumn();
            Telerik.WinControls.UI.GridViewTextBoxColumn gridViewTextBoxColumn7 = new Telerik.WinControls.UI.GridViewTextBoxColumn();
            Telerik.WinControls.UI.TableViewDefinition tableViewDefinition1 = new Telerik.WinControls.UI.TableViewDefinition();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(TransferUpgradePayments));
            this.radTitleBar1 = new Telerik.WinControls.UI.RadTitleBar();
            this.transactionslist = new Telerik.WinControls.UI.RadGridView();
            this.radGroupBox1 = new Telerik.WinControls.UI.RadGroupBox();
            this.bSave = new Telerik.WinControls.UI.RadButton();
            this.bExit = new Telerik.WinControls.UI.RadButton();
            this.Found = new Telerik.WinControls.UI.RadLabel();
            this.radLabel1 = new Telerik.WinControls.UI.RadLabel();
            this.AgreementNumber = new Telerik.WinControls.UI.RadLabel();
            ((System.ComponentModel.ISupportInitialize)(this.radTitleBar1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.transactionslist)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.transactionslist.MasterTemplate)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radGroupBox1)).BeginInit();
            this.radGroupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.bSave)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bExit)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Found)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.AgreementNumber)).BeginInit();
            this.SuspendLayout();
            // 
            // radTitleBar1
            // 
            this.radTitleBar1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(173)))), ((int)(((byte)(230)))), ((int)(((byte)(217)))));
            this.radTitleBar1.Dock = System.Windows.Forms.DockStyle.Top;
            this.radTitleBar1.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.radTitleBar1.ForeColor = System.Drawing.Color.Black;
            this.radTitleBar1.Location = new System.Drawing.Point(0, 0);
            this.radTitleBar1.Name = "radTitleBar1";
            this.radTitleBar1.Size = new System.Drawing.Size(869, 30);
            this.radTitleBar1.TabIndex = 2;
            this.radTitleBar1.TabStop = false;
            this.radTitleBar1.Text = "Transfer Upgrade Payments";
            this.radTitleBar1.ThemeName = "Breeze";
            ((Telerik.WinControls.UI.RadTitleBarElement)(this.radTitleBar1.GetChildAt(0))).Text = "Transfer Upgrade Payments";
            ((Telerik.WinControls.Primitives.FillPrimitive)(this.radTitleBar1.GetChildAt(0).GetChildAt(0))).BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(227)))), ((int)(((byte)(239)))), ((int)(((byte)(246)))));
            ((Telerik.WinControls.Primitives.FillPrimitive)(this.radTitleBar1.GetChildAt(0).GetChildAt(0))).SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.None;
            // 
            // transactionslist
            // 
            this.transactionslist.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.transactionslist.Location = new System.Drawing.Point(12, 83);
            // 
            // 
            // 
            this.transactionslist.MasterTemplate.AllowAddNewRow = false;
            this.transactionslist.MasterTemplate.AutoGenerateColumns = false;
            this.transactionslist.MasterTemplate.AutoSizeColumnsMode = Telerik.WinControls.UI.GridViewAutoSizeColumnsMode.Fill;
            gridViewCheckBoxColumn1.DataType = typeof(int);
            gridViewCheckBoxColumn1.FieldName = "Value";
            gridViewCheckBoxColumn1.HeaderText = "Select";
            gridViewCheckBoxColumn1.MaxWidth = 50;
            gridViewCheckBoxColumn1.Name = "Select";
            gridViewTextBoxColumn1.FieldName = "AgreementID";
            gridViewTextBoxColumn1.HeaderText = "AgreementID";
            gridViewTextBoxColumn1.IsVisible = false;
            gridViewTextBoxColumn1.Name = "AgreementID";
            gridViewTextBoxColumn1.Width = 134;
            gridViewTextBoxColumn2.FieldName = "AgreementNumber";
            gridViewTextBoxColumn2.HeaderText = "Agreement Number";
            gridViewTextBoxColumn2.MaxWidth = 142;
            gridViewTextBoxColumn2.MinWidth = 142;
            gridViewTextBoxColumn2.Name = "AgreementNumber";
            gridViewTextBoxColumn2.ReadOnly = true;
            gridViewTextBoxColumn2.Width = 142;
            gridViewTextBoxColumn2.WrapText = true;
            gridViewTextBoxColumn3.FieldName = "PaymentType";
            gridViewTextBoxColumn3.HeaderText = "Payment Type";
            gridViewTextBoxColumn3.MaxWidth = 180;
            gridViewTextBoxColumn3.MinWidth = 170;
            gridViewTextBoxColumn3.Name = "PaymentType";
            gridViewTextBoxColumn3.ReadOnly = true;
            gridViewTextBoxColumn3.Width = 171;
            gridViewTextBoxColumn4.DataType = typeof(decimal);
            gridViewTextBoxColumn4.FieldName = "Amount";
            gridViewTextBoxColumn4.FormatString = "{0:N2}";
            gridViewTextBoxColumn4.HeaderText = "Amount";
            gridViewTextBoxColumn4.MaxWidth = 142;
            gridViewTextBoxColumn4.MinWidth = 142;
            gridViewTextBoxColumn4.Name = "Amount";
            gridViewTextBoxColumn4.ReadOnly = true;
            gridViewTextBoxColumn4.TextAlignment = System.Drawing.ContentAlignment.MiddleRight;
            gridViewTextBoxColumn4.Width = 142;
            gridViewTextBoxColumn5.FieldName = "PaymentDate";
            gridViewTextBoxColumn5.HeaderText = "Payment Date";
            gridViewTextBoxColumn5.MaxWidth = 170;
            gridViewTextBoxColumn5.MinWidth = 170;
            gridViewTextBoxColumn5.Name = "PaymentDate";
            gridViewTextBoxColumn5.ReadOnly = true;
            gridViewTextBoxColumn5.Width = 170;
            gridViewTextBoxColumn6.FieldName = "Description";
            gridViewTextBoxColumn6.HeaderText = "Description";
            gridViewTextBoxColumn6.Name = "Description";
            gridViewTextBoxColumn6.ReadOnly = true;
            gridViewTextBoxColumn6.Width = 154;
            gridViewTextBoxColumn7.FieldName = "TransactionID";
            gridViewTextBoxColumn7.HeaderText = "TransactionID";
            gridViewTextBoxColumn7.IsVisible = false;
            gridViewTextBoxColumn7.Name = "TransactionID";
            gridViewTextBoxColumn7.Width = 57;
            this.transactionslist.MasterTemplate.Columns.AddRange(new Telerik.WinControls.UI.GridViewDataColumn[] {
            gridViewCheckBoxColumn1,
            gridViewTextBoxColumn1,
            gridViewTextBoxColumn2,
            gridViewTextBoxColumn3,
            gridViewTextBoxColumn4,
            gridViewTextBoxColumn5,
            gridViewTextBoxColumn6,
            gridViewTextBoxColumn7});
            this.transactionslist.MasterTemplate.ViewDefinition = tableViewDefinition1;
            this.transactionslist.Name = "transactionslist";
            this.transactionslist.ShowGroupPanel = false;
            this.transactionslist.Size = new System.Drawing.Size(845, 363);
            this.transactionslist.TabIndex = 3;
            this.transactionslist.ThemeName = "Breeze";
            // 
            // radGroupBox1
            // 
            this.radGroupBox1.AccessibleRole = System.Windows.Forms.AccessibleRole.Grouping;
            this.radGroupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.radGroupBox1.Controls.Add(this.bSave);
            this.radGroupBox1.Controls.Add(this.bExit);
            this.radGroupBox1.HeaderText = "";
            this.radGroupBox1.Location = new System.Drawing.Point(587, 452);
            this.radGroupBox1.Name = "radGroupBox1";
            this.radGroupBox1.Size = new System.Drawing.Size(270, 40);
            this.radGroupBox1.TabIndex = 4;
            // 
            // bSave
            // 
            this.bSave.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bSave.ForeColor = System.Drawing.Color.Black;
            this.bSave.Image = global::Evolution.Properties.Resources.transfer1;
            this.bSave.ImageAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            this.bSave.Location = new System.Drawing.Point(5, 4);
            this.bSave.Name = "bSave";
            this.bSave.Size = new System.Drawing.Size(144, 32);
            this.bSave.TabIndex = 3;
            this.bSave.Text = "Payments Transfer";
            this.bSave.TextAlignment = System.Drawing.ContentAlignment.MiddleLeft;
            this.bSave.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.bSave.Click += new System.EventHandler(this.bSave_Click);
            ((Telerik.WinControls.UI.RadButtonElement)(this.bSave.GetChildAt(0))).Image = global::Evolution.Properties.Resources.transfer1;
            ((Telerik.WinControls.UI.RadButtonElement)(this.bSave.GetChildAt(0))).TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            ((Telerik.WinControls.UI.RadButtonElement)(this.bSave.GetChildAt(0))).ImageAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            ((Telerik.WinControls.UI.RadButtonElement)(this.bSave.GetChildAt(0))).TextAlignment = System.Drawing.ContentAlignment.MiddleLeft;
            ((Telerik.WinControls.UI.RadButtonElement)(this.bSave.GetChildAt(0))).Text = "Payments Transfer";
            ((Telerik.WinControls.Primitives.ImagePrimitive)(this.bSave.GetChildAt(0).GetChildAt(1).GetChildAt(0))).ImageScaling = Telerik.WinControls.Enumerations.ImageScaling.SizeToFit;
            // 
            // bExit
            // 
            this.bExit.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bExit.ForeColor = System.Drawing.Color.Black;
            this.bExit.Image = global::Evolution.Properties.Resources.salir;
            this.bExit.ImageAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            this.bExit.Location = new System.Drawing.Point(155, 4);
            this.bExit.Name = "bExit";
            this.bExit.Size = new System.Drawing.Size(110, 32);
            this.bExit.TabIndex = 2;
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
            // Found
            // 
            this.Found.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.Found.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Found.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.Found.Location = new System.Drawing.Point(73, 462);
            this.Found.Name = "Found";
            this.Found.Size = new System.Drawing.Size(15, 21);
            this.Found.TabIndex = 8;
            this.Found.Text = "0";
            // 
            // radLabel1
            // 
            this.radLabel1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.radLabel1.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.radLabel1.Location = new System.Drawing.Point(26, 462);
            this.radLabel1.Name = "radLabel1";
            this.radLabel1.Size = new System.Drawing.Size(44, 21);
            this.radLabel1.TabIndex = 7;
            this.radLabel1.Text = "Found";
            // 
            // AgreementNumber
            // 
            this.AgreementNumber.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.AgreementNumber.BackColor = System.Drawing.Color.White;
            this.AgreementNumber.Font = new System.Drawing.Font("Segoe UI", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.AgreementNumber.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.AgreementNumber.Location = new System.Drawing.Point(12, 36);
            this.AgreementNumber.Name = "AgreementNumber";
            this.AgreementNumber.Size = new System.Drawing.Size(178, 41);
            this.AgreementNumber.TabIndex = 9;
            this.AgreementNumber.Text = "01-01-21765";
            // 
            // TransferUpgradePayments
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(244)))), ((int)(((byte)(251)))), ((int)(((byte)(255)))));
            this.ClientSize = new System.Drawing.Size(869, 504);
            this.Controls.Add(this.AgreementNumber);
            this.Controls.Add(this.Found);
            this.Controls.Add(this.radLabel1);
            this.Controls.Add(this.radGroupBox1);
            this.Controls.Add(this.transactionslist);
            this.Controls.Add(this.radTitleBar1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "TransferUpgradePayments";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Transfer Upgrade Payments";
            this.Load += new System.EventHandler(this.TransferUpgradePayments_Load);
            this.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.TransferUpgradePayments_KeyPress);
            ((System.ComponentModel.ISupportInitialize)(this.radTitleBar1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.transactionslist.MasterTemplate)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.transactionslist)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radGroupBox1)).EndInit();
            this.radGroupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.bSave)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bExit)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Found)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.AgreementNumber)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Telerik.WinControls.UI.RadTitleBar radTitleBar1;
        private Telerik.WinControls.UI.RadGridView transactionslist;
        private Telerik.WinControls.UI.RadGroupBox radGroupBox1;
        private Telerik.WinControls.UI.RadButton bSave;
        private Telerik.WinControls.UI.RadButton bExit;
        private Telerik.WinControls.UI.RadLabel Found;
        private Telerik.WinControls.UI.RadLabel radLabel1;
        private Telerik.WinControls.UI.RadLabel AgreementNumber;
    }
}