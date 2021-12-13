namespace Evolution.Forms
{
    partial class CompanyPaymentAdjustment
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
            Telerik.WinControls.UI.GridViewTextBoxColumn gridViewTextBoxColumn6 = new Telerik.WinControls.UI.GridViewTextBoxColumn();
            Telerik.WinControls.UI.GridViewTextBoxColumn gridViewTextBoxColumn7 = new Telerik.WinControls.UI.GridViewTextBoxColumn();
            Telerik.WinControls.UI.TableViewDefinition tableViewDefinition1 = new Telerik.WinControls.UI.TableViewDefinition();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CompanyPaymentAdjustment));
            this.radTitleBar1 = new Telerik.WinControls.UI.RadTitleBar();
            this.PaymentAdjustList = new Telerik.WinControls.UI.RadGridView();
            this.BtnExit = new Telerik.WinControls.UI.RadButton();
            this.radLabel2 = new Telerik.WinControls.UI.RadLabel();
            this.Searching = new Telerik.WinControls.UI.RadTextBox();
            ((System.ComponentModel.ISupportInitialize)(this.radTitleBar1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.PaymentAdjustList)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.PaymentAdjustList.MasterTemplate)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.BtnExit)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Searching)).BeginInit();
            this.SuspendLayout();
            // 
            // radTitleBar1
            // 
            this.radTitleBar1.Dock = System.Windows.Forms.DockStyle.Top;
            this.radTitleBar1.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.radTitleBar1.ForeColor = System.Drawing.Color.Black;
            this.radTitleBar1.Location = new System.Drawing.Point(0, 0);
            this.radTitleBar1.Name = "radTitleBar1";
            this.radTitleBar1.Size = new System.Drawing.Size(1059, 30);
            this.radTitleBar1.TabIndex = 17;
            this.radTitleBar1.TabStop = false;
            this.radTitleBar1.Text = "Payment Adjustment";
            this.radTitleBar1.ThemeName = "Breeze";
            ((Telerik.WinControls.UI.RadTitleBarElement)(this.radTitleBar1.GetChildAt(0))).Text = "Payment Adjustment";
            ((Telerik.WinControls.Primitives.FillPrimitive)(this.radTitleBar1.GetChildAt(0).GetChildAt(0))).BackColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(219)))), ((int)(((byte)(238)))), ((int)(((byte)(246)))));
            ((Telerik.WinControls.Primitives.FillPrimitive)(this.radTitleBar1.GetChildAt(0).GetChildAt(0))).BackColor3 = System.Drawing.Color.FromArgb(((int)(((byte)(219)))), ((int)(((byte)(238)))), ((int)(((byte)(246)))));
            ((Telerik.WinControls.Primitives.FillPrimitive)(this.radTitleBar1.GetChildAt(0).GetChildAt(0))).BackColor4 = System.Drawing.Color.FromArgb(((int)(((byte)(219)))), ((int)(((byte)(238)))), ((int)(((byte)(246)))));
            ((Telerik.WinControls.Primitives.FillPrimitive)(this.radTitleBar1.GetChildAt(0).GetChildAt(0))).BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(219)))), ((int)(((byte)(238)))), ((int)(((byte)(246)))));
            ((Telerik.WinControls.Primitives.FillPrimitive)(this.radTitleBar1.GetChildAt(0).GetChildAt(0))).SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.None;
            // 
            // PaymentAdjustList
            // 
            this.PaymentAdjustList.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(237)))), ((int)(((byte)(246)))), ((int)(((byte)(194)))));
            this.PaymentAdjustList.Cursor = System.Windows.Forms.Cursors.Default;
            this.PaymentAdjustList.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.PaymentAdjustList.ForeColor = System.Drawing.SystemColors.ControlText;
            this.PaymentAdjustList.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.PaymentAdjustList.Location = new System.Drawing.Point(12, 69);
            // 
            // 
            // 
            this.PaymentAdjustList.MasterTemplate.AllowAddNewRow = false;
            this.PaymentAdjustList.MasterTemplate.AllowColumnReorder = false;
            this.PaymentAdjustList.MasterTemplate.AllowDragToGroup = false;
            this.PaymentAdjustList.MasterTemplate.AllowEditRow = false;
            this.PaymentAdjustList.MasterTemplate.AutoGenerateColumns = false;
            gridViewTextBoxColumn1.FieldName = "AgreementNumber";
            gridViewTextBoxColumn1.HeaderText = "Agreement Number";
            gridViewTextBoxColumn1.Name = "AgreementNumber";
            gridViewTextBoxColumn1.Width = 150;
            gridViewTextBoxColumn1.WrapText = true;
            gridViewTextBoxColumn2.FieldName = "TransactionType";
            gridViewTextBoxColumn2.HeaderText = "Transaction Type";
            gridViewTextBoxColumn2.Name = "TransactionType";
            gridViewTextBoxColumn2.Width = 220;
            gridViewTextBoxColumn2.WrapText = true;
            gridViewTextBoxColumn3.FieldName = "Amount";
            gridViewTextBoxColumn3.FormatString = "{0:n2}";
            gridViewTextBoxColumn3.HeaderText = "Amount";
            gridViewTextBoxColumn3.Name = "Amount";
            gridViewTextBoxColumn3.Width = 100;
            gridViewTextBoxColumn4.FieldName = "CreationDate";
            gridViewTextBoxColumn4.HeaderText = "Creation Date";
            gridViewTextBoxColumn4.Name = "CreationDate";
            gridViewTextBoxColumn4.Width = 120;
            gridViewTextBoxColumn5.FieldName = "UserName";
            gridViewTextBoxColumn5.HeaderText = "UserName";
            gridViewTextBoxColumn5.Name = "UserName";
            gridViewTextBoxColumn5.Width = 170;
            gridViewTextBoxColumn6.FieldName = "Reference";
            gridViewTextBoxColumn6.HeaderText = "Reference";
            gridViewTextBoxColumn6.Name = "Reference";
            gridViewTextBoxColumn6.Width = 110;
            gridViewTextBoxColumn7.FieldName = "CompanyName";
            gridViewTextBoxColumn7.HeaderText = "CompanyName";
            gridViewTextBoxColumn7.Name = "CompanyName";
            gridViewTextBoxColumn7.Width = 120;
            this.PaymentAdjustList.MasterTemplate.Columns.AddRange(new Telerik.WinControls.UI.GridViewDataColumn[] {
            gridViewTextBoxColumn1,
            gridViewTextBoxColumn2,
            gridViewTextBoxColumn3,
            gridViewTextBoxColumn4,
            gridViewTextBoxColumn5,
            gridViewTextBoxColumn6,
            gridViewTextBoxColumn7});
            this.PaymentAdjustList.MasterTemplate.ShowGroupedColumns = true;
            this.PaymentAdjustList.MasterTemplate.ViewDefinition = tableViewDefinition1;
            this.PaymentAdjustList.Name = "PaymentAdjustList";
            this.PaymentAdjustList.ReadOnly = true;
            this.PaymentAdjustList.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.PaymentAdjustList.ShowGroupPanel = false;
            this.PaymentAdjustList.Size = new System.Drawing.Size(1035, 387);
            this.PaymentAdjustList.TabIndex = 18;
            this.PaymentAdjustList.Text = "radGridView1";
            this.PaymentAdjustList.ThemeName = "Breeze";
            // 
            // BtnExit
            // 
            this.BtnExit.Cursor = System.Windows.Forms.Cursors.Hand;
            this.BtnExit.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnExit.ForeColor = System.Drawing.Color.Black;
            this.BtnExit.Image = global::Evolution.Properties.Resources.salir;
            this.BtnExit.ImageAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            this.BtnExit.Location = new System.Drawing.Point(945, 462);
            this.BtnExit.Name = "BtnExit";
            this.BtnExit.Size = new System.Drawing.Size(102, 36);
            this.BtnExit.TabIndex = 19;
            this.BtnExit.Text = "Exit";
            this.BtnExit.TextAlignment = System.Drawing.ContentAlignment.MiddleLeft;
            this.BtnExit.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.BtnExit.ThemeName = "ControlDefault";
            this.BtnExit.Click += new System.EventHandler(this.BtnExit_Click);
            ((Telerik.WinControls.UI.RadButtonElement)(this.BtnExit.GetChildAt(0))).Image = global::Evolution.Properties.Resources.salir;
            ((Telerik.WinControls.UI.RadButtonElement)(this.BtnExit.GetChildAt(0))).TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            ((Telerik.WinControls.UI.RadButtonElement)(this.BtnExit.GetChildAt(0))).ImageAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            ((Telerik.WinControls.UI.RadButtonElement)(this.BtnExit.GetChildAt(0))).TextAlignment = System.Drawing.ContentAlignment.MiddleLeft;
            ((Telerik.WinControls.UI.RadButtonElement)(this.BtnExit.GetChildAt(0))).Text = "Exit";
            ((Telerik.WinControls.Primitives.ImagePrimitive)(this.BtnExit.GetChildAt(0).GetChildAt(1).GetChildAt(0))).ImageScaling = Telerik.WinControls.Enumerations.ImageScaling.SizeToFit;
            // 
            // radLabel2
            // 
            this.radLabel2.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.radLabel2.Location = new System.Drawing.Point(21, 39);
            this.radLabel2.Name = "radLabel2";
            this.radLabel2.Size = new System.Drawing.Size(46, 21);
            this.radLabel2.TabIndex = 25;
            this.radLabel2.Text = "Search";
            // 
            // Searching
            // 
            this.Searching.AutoSize = false;
            this.Searching.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Searching.ForeColor = System.Drawing.Color.Black;
            this.Searching.Location = new System.Drawing.Point(73, 35);
            this.Searching.Name = "Searching";
            this.Searching.NullText = "Contact #";
            this.Searching.Size = new System.Drawing.Size(244, 29);
            this.Searching.TabIndex = 24;
            this.Searching.ThemeName = "Breeze";
            this.Searching.TextChanged += new System.EventHandler(this.Amount_TextChanged);
            // 
            // CompanyPaymentAdjustment
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Azure;
            this.ClientSize = new System.Drawing.Size(1059, 505);
            this.Controls.Add(this.radLabel2);
            this.Controls.Add(this.Searching);
            this.Controls.Add(this.BtnExit);
            this.Controls.Add(this.PaymentAdjustList);
            this.Controls.Add(this.radTitleBar1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "CompanyPaymentAdjustment";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Payment Adjustment";
            this.Activated += new System.EventHandler(this.CompanyPaymentAdjustment_Activated);
            this.Load += new System.EventHandler(this.CompanyPaymentAdjustment_Load);
            this.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.CompanyPaymentAdjustment_KeyPress);
            ((System.ComponentModel.ISupportInitialize)(this.radTitleBar1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.PaymentAdjustList.MasterTemplate)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.PaymentAdjustList)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.BtnExit)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Searching)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Telerik.WinControls.UI.RadTitleBar radTitleBar1;
        private Telerik.WinControls.UI.RadGridView PaymentAdjustList;
        private Telerik.WinControls.UI.RadButton BtnExit;
        private Telerik.WinControls.UI.RadLabel radLabel2;
        private Telerik.WinControls.UI.RadTextBox Searching;
    }
}