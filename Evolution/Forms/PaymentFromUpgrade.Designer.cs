namespace Evolution.Forms
{
    partial class PaymentFromUpgrade
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(PaymentFromUpgrade));
            this.transactionslist = new Telerik.WinControls.UI.RadGridView();
            this.radGroupBox1 = new Telerik.WinControls.UI.RadGroupBox();
            this.bSave = new Telerik.WinControls.UI.RadButton();
            this.bExit = new Telerik.WinControls.UI.RadButton();
            this.Found = new Telerik.WinControls.UI.RadLabel();
            this.radLabel1 = new Telerik.WinControls.UI.RadLabel();
            this.grbSearch = new Telerik.WinControls.UI.RadGroupBox();
            this.mebAmount = new Telerik.WinControls.UI.RadMaskedEditBox();
            this.bSearch = new Telerik.WinControls.UI.RadButton();
            ((System.ComponentModel.ISupportInitialize)(this.transactionslist)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.transactionslist.MasterTemplate)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radGroupBox1)).BeginInit();
            this.radGroupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.bSave)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bExit)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Found)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grbSearch)).BeginInit();
            this.grbSearch.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.mebAmount)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bSearch)).BeginInit();
            this.SuspendLayout();
            // 
            // transactionslist
            // 
            this.transactionslist.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.transactionslist.Location = new System.Drawing.Point(6, 6);
            // 
            // 
            // 
            this.transactionslist.MasterTemplate.AllowAddNewRow = false;
            this.transactionslist.MasterTemplate.AutoGenerateColumns = false;
            this.transactionslist.MasterTemplate.AutoSizeColumnsMode = Telerik.WinControls.UI.GridViewAutoSizeColumnsMode.Fill;
            gridViewCheckBoxColumn1.DataType = typeof(int);
            gridViewCheckBoxColumn1.FieldName = "Selected";
            gridViewCheckBoxColumn1.HeaderText = "Select";
            gridViewCheckBoxColumn1.MinWidth = 50;
            gridViewCheckBoxColumn1.Name = "Selected";
            gridViewTextBoxColumn1.FieldName = "AgreementNumber";
            gridViewTextBoxColumn1.HeaderText = "Agreement Number";
            gridViewTextBoxColumn1.MaxWidth = 142;
            gridViewTextBoxColumn1.MinWidth = 142;
            gridViewTextBoxColumn1.Name = "AgreementNumber";
            gridViewTextBoxColumn1.ReadOnly = true;
            gridViewTextBoxColumn1.Width = 142;
            gridViewTextBoxColumn1.WrapText = true;
            gridViewTextBoxColumn2.FieldName = "PaymentType";
            gridViewTextBoxColumn2.HeaderText = "Payment Type";
            gridViewTextBoxColumn2.MaxWidth = 180;
            gridViewTextBoxColumn2.MinWidth = 170;
            gridViewTextBoxColumn2.Name = "PaymentType";
            gridViewTextBoxColumn2.ReadOnly = true;
            gridViewTextBoxColumn2.Width = 170;
            gridViewTextBoxColumn3.DataType = typeof(decimal);
            gridViewTextBoxColumn3.FieldName = "Amount";
            gridViewTextBoxColumn3.FormatString = "{0:N2}";
            gridViewTextBoxColumn3.HeaderText = "Amount";
            gridViewTextBoxColumn3.MaxWidth = 142;
            gridViewTextBoxColumn3.MinWidth = 142;
            gridViewTextBoxColumn3.Name = "Amount";
            gridViewTextBoxColumn3.ReadOnly = true;
            gridViewTextBoxColumn3.TextAlignment = System.Drawing.ContentAlignment.MiddleRight;
            gridViewTextBoxColumn3.Width = 142;
            gridViewTextBoxColumn4.FieldName = "PaymentDate";
            gridViewTextBoxColumn4.HeaderText = "Payment Date";
            gridViewTextBoxColumn4.MaxWidth = 170;
            gridViewTextBoxColumn4.MinWidth = 170;
            gridViewTextBoxColumn4.Name = "PaymentDate";
            gridViewTextBoxColumn4.ReadOnly = true;
            gridViewTextBoxColumn4.Width = 170;
            gridViewTextBoxColumn5.FieldName = "Description";
            gridViewTextBoxColumn5.HeaderText = "Description";
            gridViewTextBoxColumn5.Name = "Description";
            gridViewTextBoxColumn5.ReadOnly = true;
            gridViewTextBoxColumn5.Width = 167;
            gridViewTextBoxColumn6.FieldName = "TransactionID";
            gridViewTextBoxColumn6.HeaderText = "TransactionID";
            gridViewTextBoxColumn6.IsVisible = false;
            gridViewTextBoxColumn6.Name = "TransactionID";
            gridViewTextBoxColumn6.Width = 57;
            gridViewTextBoxColumn7.FieldName = "RealAmount";
            gridViewTextBoxColumn7.FormatString = "{0:N2}";
            gridViewTextBoxColumn7.HeaderText = "Real Amount";
            gridViewTextBoxColumn7.Name = "RealAmount";
            gridViewTextBoxColumn7.ReadOnly = true;
            gridViewTextBoxColumn7.Width = 17;
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
            this.transactionslist.Size = new System.Drawing.Size(873, 386);
            this.transactionslist.TabIndex = 4;
            this.transactionslist.ThemeName = "Breeze";
            // 
            // radGroupBox1
            // 
            this.radGroupBox1.AccessibleRole = System.Windows.Forms.AccessibleRole.Grouping;
            this.radGroupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.radGroupBox1.Controls.Add(this.bSave);
            this.radGroupBox1.Controls.Add(this.bExit);
            this.radGroupBox1.HeaderText = "";
            this.radGroupBox1.Location = new System.Drawing.Point(610, 398);
            this.radGroupBox1.Name = "radGroupBox1";
            this.radGroupBox1.Size = new System.Drawing.Size(270, 40);
            this.radGroupBox1.TabIndex = 5;
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
            this.Found.Location = new System.Drawing.Point(59, 417);
            this.Found.Name = "Found";
            this.Found.Size = new System.Drawing.Size(15, 21);
            this.Found.TabIndex = 10;
            this.Found.Text = "0";
            // 
            // radLabel1
            // 
            this.radLabel1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.radLabel1.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.radLabel1.Location = new System.Drawing.Point(12, 417);
            this.radLabel1.Name = "radLabel1";
            this.radLabel1.Size = new System.Drawing.Size(44, 21);
            this.radLabel1.TabIndex = 9;
            this.radLabel1.Text = "Found";
            // 
            // grbSearch
            // 
            this.grbSearch.AccessibleRole = System.Windows.Forms.AccessibleRole.Grouping;
            this.grbSearch.Controls.Add(this.mebAmount);
            this.grbSearch.Controls.Add(this.bSearch);
            this.grbSearch.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.grbSearch.HeaderText = "";
            this.grbSearch.Location = new System.Drawing.Point(288, 402);
            this.grbSearch.Name = "grbSearch";
            this.grbSearch.Size = new System.Drawing.Size(220, 47);
            this.grbSearch.TabIndex = 14;
            this.grbSearch.Visible = false;
            // 
            // mebAmount
            // 
            this.mebAmount.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.mebAmount.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.mebAmount.Location = new System.Drawing.Point(5, 11);
            this.mebAmount.Mask = "f";
            this.mebAmount.MaskType = Telerik.WinControls.UI.MaskType.Numeric;
            this.mebAmount.Name = "mebAmount";
            this.mebAmount.ReadOnly = true;
            this.mebAmount.Size = new System.Drawing.Size(125, 23);
            this.mebAmount.TabIndex = 5;
            this.mebAmount.TabStop = false;
            this.mebAmount.Text = "0.00";
            this.mebAmount.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.mebAmount.ThemeName = "Breeze";
            // 
            // bSearch
            // 
            this.bSearch.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bSearch.ForeColor = System.Drawing.Color.Black;
            this.bSearch.Image = global::Evolution.Properties.Resources.find;
            this.bSearch.ImageAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            this.bSearch.Location = new System.Drawing.Point(136, 8);
            this.bSearch.Name = "bSearch";
            this.bSearch.Size = new System.Drawing.Size(70, 30);
            this.bSearch.TabIndex = 4;
            this.bSearch.Text = "Search";
            this.bSearch.TextAlignment = System.Drawing.ContentAlignment.MiddleLeft;
            this.bSearch.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.bSearch.Click += new System.EventHandler(this.bSearch_Click);
            ((Telerik.WinControls.UI.RadButtonElement)(this.bSearch.GetChildAt(0))).Image = global::Evolution.Properties.Resources.find;
            ((Telerik.WinControls.UI.RadButtonElement)(this.bSearch.GetChildAt(0))).TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            ((Telerik.WinControls.UI.RadButtonElement)(this.bSearch.GetChildAt(0))).ImageAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            ((Telerik.WinControls.UI.RadButtonElement)(this.bSearch.GetChildAt(0))).TextAlignment = System.Drawing.ContentAlignment.MiddleLeft;
            ((Telerik.WinControls.UI.RadButtonElement)(this.bSearch.GetChildAt(0))).Text = "Search";
            ((Telerik.WinControls.Primitives.ImagePrimitive)(this.bSearch.GetChildAt(0).GetChildAt(1).GetChildAt(0))).ImageScaling = Telerik.WinControls.Enumerations.ImageScaling.SizeToFit;
            // 
            // PaymentFromUpgrade
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(244)))), ((int)(((byte)(251)))), ((int)(((byte)(255)))));
            this.ClientSize = new System.Drawing.Size(884, 450);
            this.Controls.Add(this.grbSearch);
            this.Controls.Add(this.Found);
            this.Controls.Add(this.radLabel1);
            this.Controls.Add(this.radGroupBox1);
            this.Controls.Add(this.transactionslist);
            this.DoubleBuffered = true;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "PaymentFromUpgrade";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Payments From Upgrade";
            this.Load += new System.EventHandler(this.PaymentFromUpgrade_Load);
            this.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.PaymentFromUpgrade_KeyPress);
            ((System.ComponentModel.ISupportInitialize)(this.transactionslist.MasterTemplate)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.transactionslist)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radGroupBox1)).EndInit();
            this.radGroupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.bSave)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bExit)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Found)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grbSearch)).EndInit();
            this.grbSearch.ResumeLayout(false);
            this.grbSearch.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.mebAmount)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bSearch)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Telerik.WinControls.UI.RadGridView transactionslist;
        private Telerik.WinControls.UI.RadGroupBox radGroupBox1;
        private Telerik.WinControls.UI.RadButton bSave;
        private Telerik.WinControls.UI.RadButton bExit;
        private Telerik.WinControls.UI.RadLabel Found;
        private Telerik.WinControls.UI.RadLabel radLabel1;
        private Telerik.WinControls.UI.RadGroupBox grbSearch;
        private Telerik.WinControls.UI.RadButton bSearch;
        private Telerik.WinControls.UI.RadMaskedEditBox mebAmount;
    }
}