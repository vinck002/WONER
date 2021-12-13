namespace Evolution.Forms
{
    partial class ViewPaymentDetail
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
            Telerik.WinControls.UI.GridViewTextBoxColumn gridViewTextBoxColumn4 = new Telerik.WinControls.UI.GridViewTextBoxColumn();
            Telerik.WinControls.UI.GridViewTextBoxColumn gridViewTextBoxColumn5 = new Telerik.WinControls.UI.GridViewTextBoxColumn();
            Telerik.WinControls.UI.GridViewCheckBoxColumn gridViewCheckBoxColumn1 = new Telerik.WinControls.UI.GridViewCheckBoxColumn();
            Telerik.WinControls.UI.GridViewTextBoxColumn gridViewTextBoxColumn6 = new Telerik.WinControls.UI.GridViewTextBoxColumn();
            Telerik.WinControls.UI.GridViewCheckBoxColumn gridViewCheckBoxColumn2 = new Telerik.WinControls.UI.GridViewCheckBoxColumn();
            Telerik.WinControls.UI.GridViewTextBoxColumn gridViewTextBoxColumn7 = new Telerik.WinControls.UI.GridViewTextBoxColumn();
            Telerik.WinControls.UI.GridViewTextBoxColumn gridViewTextBoxColumn8 = new Telerik.WinControls.UI.GridViewTextBoxColumn();
            Telerik.WinControls.UI.TableViewDefinition tableViewDefinition1 = new Telerik.WinControls.UI.TableViewDefinition();
            this.transactionslist = new Telerik.WinControls.UI.RadGridView();
            this.bExit = new Telerik.WinControls.UI.RadButton();
            this.radTitleBar1 = new Telerik.WinControls.UI.RadTitleBar();
            this.radGroupBox2 = new Telerik.WinControls.UI.RadGroupBox();
            this.Membername = new Telerik.WinControls.UI.RadLabel();
            this.AgreementNumber = new Telerik.WinControls.UI.RadLabel();
            this.breezeTheme1 = new Telerik.WinControls.Themes.BreezeTheme();
            this.bHold = new Telerik.WinControls.UI.RadButton();
            this.bInactive = new Telerik.WinControls.UI.RadButton();
            ((System.ComponentModel.ISupportInitialize)(this.transactionslist)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.transactionslist.MasterTemplate)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bExit)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radTitleBar1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radGroupBox2)).BeginInit();
            this.radGroupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Membername)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.AgreementNumber)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bHold)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bInactive)).BeginInit();
            this.SuspendLayout();
            // 
            // transactionslist
            // 
            this.transactionslist.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.transactionslist.Location = new System.Drawing.Point(5, 94);
            // 
            // 
            // 
            this.transactionslist.MasterTemplate.AllowAddNewRow = false;
            this.transactionslist.MasterTemplate.AutoGenerateColumns = false;
            gridViewTextBoxColumn1.FieldName = "TRANSACTIONTYPE";
            gridViewTextBoxColumn1.HeaderText = "Transaction Type";
            gridViewTextBoxColumn1.Name = "TRANSACTIONTYPE";
            gridViewTextBoxColumn1.ReadOnly = true;
            gridViewTextBoxColumn1.Width = 280;
            gridViewTextBoxColumn2.FieldName = "DESCRIPTION";
            gridViewTextBoxColumn2.HeaderText = "Description";
            gridViewTextBoxColumn2.Name = "DESCRIPTION";
            gridViewTextBoxColumn2.ReadOnly = true;
            gridViewTextBoxColumn2.Width = 180;
            gridViewTextBoxColumn3.DataType = typeof(decimal);
            gridViewTextBoxColumn3.FieldName = "AMOUNT";
            gridViewTextBoxColumn3.FormatString = "{0:N2}";
            gridViewTextBoxColumn3.HeaderText = "Amount";
            gridViewTextBoxColumn3.Name = "AMOUNT";
            gridViewTextBoxColumn3.ReadOnly = true;
            gridViewTextBoxColumn3.TextAlignment = System.Drawing.ContentAlignment.MiddleRight;
            gridViewTextBoxColumn3.Width = 130;
            gridViewTextBoxColumn4.FieldName = "datecreate";
            gridViewTextBoxColumn4.HeaderText = "Date";
            gridViewTextBoxColumn4.Name = "DATE";
            gridViewTextBoxColumn4.ReadOnly = true;
            gridViewTextBoxColumn4.Width = 100;
            gridViewTextBoxColumn5.FieldName = "USERNAME";
            gridViewTextBoxColumn5.HeaderText = "User Name";
            gridViewTextBoxColumn5.Name = "USERNAME";
            gridViewTextBoxColumn5.ReadOnly = true;
            gridViewTextBoxColumn5.Width = 180;
            gridViewCheckBoxColumn1.DataType = typeof(int);
            gridViewCheckBoxColumn1.FieldName = "Hold";
            gridViewCheckBoxColumn1.HeaderText = "Hold";
            gridViewCheckBoxColumn1.Name = "Hold";
            gridViewCheckBoxColumn1.Width = 60;
            gridViewTextBoxColumn6.FieldName = "transactionID";
            gridViewTextBoxColumn6.HeaderText = "transactionID";
            gridViewTextBoxColumn6.IsVisible = false;
            gridViewTextBoxColumn6.Name = "transactionID";
            gridViewCheckBoxColumn2.DataType = typeof(int);
            gridViewCheckBoxColumn2.FieldName = "hold2";
            gridViewCheckBoxColumn2.HeaderText = "Hold2";
            gridViewCheckBoxColumn2.IsVisible = false;
            gridViewCheckBoxColumn2.Name = "Hold2";
            gridViewCheckBoxColumn2.Width = 60;
            gridViewTextBoxColumn7.FieldName = "AgreementID";
            gridViewTextBoxColumn7.HeaderText = "AgreementID";
            gridViewTextBoxColumn7.IsVisible = false;
            gridViewTextBoxColumn7.Name = "AgreementID";
            gridViewTextBoxColumn8.FieldName = "Type";
            gridViewTextBoxColumn8.HeaderText = "Type";
            gridViewTextBoxColumn8.IsVisible = false;
            gridViewTextBoxColumn8.Name = "Type";
            this.transactionslist.MasterTemplate.Columns.AddRange(new Telerik.WinControls.UI.GridViewDataColumn[] {
            gridViewTextBoxColumn1,
            gridViewTextBoxColumn2,
            gridViewTextBoxColumn3,
            gridViewTextBoxColumn4,
            gridViewTextBoxColumn5,
            gridViewCheckBoxColumn1,
            gridViewTextBoxColumn6,
            gridViewCheckBoxColumn2,
            gridViewTextBoxColumn7,
            gridViewTextBoxColumn8});
            this.transactionslist.MasterTemplate.ViewDefinition = tableViewDefinition1;
            this.transactionslist.Name = "transactionslist";
            this.transactionslist.ShowGroupPanel = false;
            this.transactionslist.Size = new System.Drawing.Size(965, 376);
            this.transactionslist.TabIndex = 2;
            this.transactionslist.ThemeName = "Breeze";
            // 
            // bExit
            // 
            this.bExit.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bExit.ForeColor = System.Drawing.Color.Black;
            this.bExit.Image = global::Evolution.Properties.Resources.salir;
            this.bExit.ImageAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            this.bExit.Location = new System.Drawing.Point(860, 476);
            this.bExit.Name = "bExit";
            this.bExit.Size = new System.Drawing.Size(110, 32);
            this.bExit.TabIndex = 3;
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
            // radTitleBar1
            // 
            this.radTitleBar1.Dock = System.Windows.Forms.DockStyle.Top;
            this.radTitleBar1.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.radTitleBar1.ForeColor = System.Drawing.Color.Black;
            this.radTitleBar1.Location = new System.Drawing.Point(0, 0);
            this.radTitleBar1.Name = "radTitleBar1";
            this.radTitleBar1.Size = new System.Drawing.Size(976, 30);
            this.radTitleBar1.TabIndex = 4;
            this.radTitleBar1.TabStop = false;
            this.radTitleBar1.Text = "Payment Detail View";
            this.radTitleBar1.ThemeName = "Breeze";
            ((Telerik.WinControls.UI.RadTitleBarElement)(this.radTitleBar1.GetChildAt(0))).Text = "Payment Detail View";
            ((Telerik.WinControls.Primitives.FillPrimitive)(this.radTitleBar1.GetChildAt(0).GetChildAt(0))).BackColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(211)))), ((int)(((byte)(235)))), ((int)(((byte)(246)))));
            ((Telerik.WinControls.Primitives.FillPrimitive)(this.radTitleBar1.GetChildAt(0).GetChildAt(0))).BackColor3 = System.Drawing.Color.FromArgb(((int)(((byte)(211)))), ((int)(((byte)(235)))), ((int)(((byte)(246)))));
            ((Telerik.WinControls.Primitives.FillPrimitive)(this.radTitleBar1.GetChildAt(0).GetChildAt(0))).BackColor4 = System.Drawing.Color.FromArgb(((int)(((byte)(211)))), ((int)(((byte)(235)))), ((int)(((byte)(246)))));
            ((Telerik.WinControls.Primitives.FillPrimitive)(this.radTitleBar1.GetChildAt(0).GetChildAt(0))).BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(211)))), ((int)(((byte)(235)))), ((int)(((byte)(246)))));
            ((Telerik.WinControls.Primitives.FillPrimitive)(this.radTitleBar1.GetChildAt(0).GetChildAt(0))).SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.None;
            // 
            // radGroupBox2
            // 
            this.radGroupBox2.AccessibleRole = System.Windows.Forms.AccessibleRole.Grouping;
            this.radGroupBox2.Controls.Add(this.Membername);
            this.radGroupBox2.Controls.Add(this.AgreementNumber);
            this.radGroupBox2.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.radGroupBox2.HeaderText = "";
            this.radGroupBox2.Location = new System.Drawing.Point(5, 36);
            this.radGroupBox2.Name = "radGroupBox2";
            // 
            // 
            // 
            this.radGroupBox2.RootElement.FocusBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(197)))), ((int)(((byte)(234)))), ((int)(((byte)(221)))));
            this.radGroupBox2.Size = new System.Drawing.Size(505, 52);
            this.radGroupBox2.TabIndex = 13;
            this.radGroupBox2.ThemeName = "Breeze";
            // 
            // Membername
            // 
            this.Membername.BackColor = System.Drawing.Color.White;
            this.Membername.Font = new System.Drawing.Font("Segoe UI", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Membername.ForeColor = System.Drawing.Color.Black;
            this.Membername.Location = new System.Drawing.Point(206, 10);
            this.Membername.Name = "Membername";
            this.Membername.Size = new System.Drawing.Size(256, 33);
            this.Membername.TabIndex = 1;
            this.Membername.Text = "Jose luis vargar almonte";
            // 
            // AgreementNumber
            // 
            this.AgreementNumber.BackColor = System.Drawing.Color.White;
            this.AgreementNumber.Font = new System.Drawing.Font("Segoe UI", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.AgreementNumber.ForeColor = System.Drawing.Color.Black;
            this.AgreementNumber.Location = new System.Drawing.Point(29, 10);
            this.AgreementNumber.Name = "AgreementNumber";
            this.AgreementNumber.Size = new System.Drawing.Size(139, 33);
            this.AgreementNumber.TabIndex = 0;
            this.AgreementNumber.Text = "04-04-25900";
            // 
            // bHold
            // 
            this.bHold.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bHold.ForeColor = System.Drawing.Color.Black;
            this.bHold.Image = global::Evolution.Properties.Resources.Hold;
            this.bHold.ImageAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            this.bHold.Location = new System.Drawing.Point(744, 476);
            this.bHold.Name = "bHold";
            this.bHold.Size = new System.Drawing.Size(110, 32);
            this.bHold.TabIndex = 14;
            this.bHold.Text = "Set Hold";
            this.bHold.TextAlignment = System.Drawing.ContentAlignment.MiddleLeft;
            this.bHold.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.bHold.Click += new System.EventHandler(this.bHold_Click);
            ((Telerik.WinControls.UI.RadButtonElement)(this.bHold.GetChildAt(0))).Image = global::Evolution.Properties.Resources.Hold;
            ((Telerik.WinControls.UI.RadButtonElement)(this.bHold.GetChildAt(0))).TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            ((Telerik.WinControls.UI.RadButtonElement)(this.bHold.GetChildAt(0))).ImageAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            ((Telerik.WinControls.UI.RadButtonElement)(this.bHold.GetChildAt(0))).TextAlignment = System.Drawing.ContentAlignment.MiddleLeft;
            ((Telerik.WinControls.UI.RadButtonElement)(this.bHold.GetChildAt(0))).Text = "Set Hold";
            ((Telerik.WinControls.Primitives.ImagePrimitive)(this.bHold.GetChildAt(0).GetChildAt(1).GetChildAt(0))).ImageScaling = Telerik.WinControls.Enumerations.ImageScaling.SizeToFit;
            // 
            // bInactive
            // 
            this.bInactive.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bInactive.ForeColor = System.Drawing.Color.Black;
            this.bInactive.Image = global::Evolution.Properties.Resources.stop;
            this.bInactive.ImageAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            this.bInactive.Location = new System.Drawing.Point(589, 476);
            this.bInactive.Name = "bInactive";
            this.bInactive.Size = new System.Drawing.Size(149, 32);
            this.bInactive.TabIndex = 15;
            this.bInactive.Text = "Inactive Payment";
            this.bInactive.TextAlignment = System.Drawing.ContentAlignment.MiddleLeft;
            this.bInactive.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.bInactive.Click += new System.EventHandler(this.bInactive_Click);
            ((Telerik.WinControls.UI.RadButtonElement)(this.bInactive.GetChildAt(0))).Image = global::Evolution.Properties.Resources.stop;
            ((Telerik.WinControls.UI.RadButtonElement)(this.bInactive.GetChildAt(0))).TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            ((Telerik.WinControls.UI.RadButtonElement)(this.bInactive.GetChildAt(0))).ImageAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            ((Telerik.WinControls.UI.RadButtonElement)(this.bInactive.GetChildAt(0))).TextAlignment = System.Drawing.ContentAlignment.MiddleLeft;
            ((Telerik.WinControls.UI.RadButtonElement)(this.bInactive.GetChildAt(0))).Text = "Inactive Payment";
            ((Telerik.WinControls.Primitives.ImagePrimitive)(this.bInactive.GetChildAt(0).GetChildAt(1).GetChildAt(0))).ImageScaling = Telerik.WinControls.Enumerations.ImageScaling.SizeToFit;
            // 
            // ViewPaymentDetail
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(244)))), ((int)(((byte)(251)))), ((int)(((byte)(255)))));
            this.ClientSize = new System.Drawing.Size(976, 514);
            this.Controls.Add(this.bInactive);
            this.Controls.Add(this.bHold);
            this.Controls.Add(this.radGroupBox2);
            this.Controls.Add(this.radTitleBar1);
            this.Controls.Add(this.bExit);
            this.Controls.Add(this.transactionslist);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "ViewPaymentDetail";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Payment Detail View";
            this.Load += new System.EventHandler(this.ViewPaymentDetail_Load);
            this.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.ViewPaymentDetail_KeyPress);
            ((System.ComponentModel.ISupportInitialize)(this.transactionslist.MasterTemplate)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.transactionslist)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bExit)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radTitleBar1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radGroupBox2)).EndInit();
            this.radGroupBox2.ResumeLayout(false);
            this.radGroupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Membername)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.AgreementNumber)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bHold)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bInactive)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Telerik.WinControls.UI.RadGridView transactionslist;
        private Telerik.WinControls.UI.RadButton bExit;
        private Telerik.WinControls.UI.RadTitleBar radTitleBar1;
        private Telerik.WinControls.UI.RadGroupBox radGroupBox2;
        private Telerik.WinControls.UI.RadLabel Membername;
        private Telerik.WinControls.UI.RadLabel AgreementNumber;
        private Telerik.WinControls.Themes.BreezeTheme breezeTheme1;
        private Telerik.WinControls.UI.RadButton bHold;
        private Telerik.WinControls.UI.RadButton bInactive;
    }
}