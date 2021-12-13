namespace Evolution.Forms
{
    partial class ViewDTSPayments
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
            Telerik.WinControls.UI.TableViewDefinition tableViewDefinition1 = new Telerik.WinControls.UI.TableViewDefinition();
            this.radTitleBar1 = new Telerik.WinControls.UI.RadTitleBar();
            this.radGroupBox1 = new Telerik.WinControls.UI.RadGroupBox();
            this.bExit = new Telerik.WinControls.UI.RadButton();
            this.Balancedue = new Telerik.WinControls.UI.RadLabel();
            this.radLabel6 = new Telerik.WinControls.UI.RadLabel();
            this.Paidtotal = new Telerik.WinControls.UI.RadLabel();
            this.radLabel4 = new Telerik.WinControls.UI.RadLabel();
            this.Membership = new Telerik.WinControls.UI.RadLabel();
            this.radLabel2 = new Telerik.WinControls.UI.RadLabel();
            this.Contractnumber = new Telerik.WinControls.UI.RadLabel();
            this.Paymentlist = new Telerik.WinControls.UI.RadGridView();
            ((System.ComponentModel.ISupportInitialize)(this.radTitleBar1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radGroupBox1)).BeginInit();
            this.radGroupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.bExit)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Balancedue)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel6)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Paidtotal)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Membership)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Contractnumber)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Paymentlist)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Paymentlist.MasterTemplate)).BeginInit();
            this.SuspendLayout();
            // 
            // radTitleBar1
            // 
            this.radTitleBar1.BackColor = System.Drawing.Color.Honeydew;
            this.radTitleBar1.Dock = System.Windows.Forms.DockStyle.Top;
            this.radTitleBar1.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.radTitleBar1.ForeColor = System.Drawing.Color.Black;
            this.radTitleBar1.Location = new System.Drawing.Point(0, 0);
            this.radTitleBar1.Name = "radTitleBar1";
            this.radTitleBar1.Size = new System.Drawing.Size(849, 30);
            this.radTitleBar1.TabIndex = 0;
            this.radTitleBar1.TabStop = false;
            this.radTitleBar1.Text = "View Payments";
            // 
            // radGroupBox1
            // 
            this.radGroupBox1.AccessibleRole = System.Windows.Forms.AccessibleRole.Grouping;
            this.radGroupBox1.Controls.Add(this.bExit);
            this.radGroupBox1.Controls.Add(this.Balancedue);
            this.radGroupBox1.Controls.Add(this.radLabel6);
            this.radGroupBox1.Controls.Add(this.Paidtotal);
            this.radGroupBox1.Controls.Add(this.radLabel4);
            this.radGroupBox1.Controls.Add(this.Membership);
            this.radGroupBox1.Controls.Add(this.radLabel2);
            this.radGroupBox1.Controls.Add(this.Contractnumber);
            this.radGroupBox1.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.radGroupBox1.HeaderText = "Info";
            this.radGroupBox1.Location = new System.Drawing.Point(12, 36);
            this.radGroupBox1.Name = "radGroupBox1";
            this.radGroupBox1.Size = new System.Drawing.Size(825, 64);
            this.radGroupBox1.TabIndex = 1;
            this.radGroupBox1.Text = "Info";
            // 
            // bExit
            // 
            this.bExit.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bExit.ForeColor = System.Drawing.Color.Black;
            this.bExit.Image = global::Evolution.Properties.Resources.salir;
            this.bExit.ImageAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            this.bExit.Location = new System.Drawing.Point(710, 21);
            this.bExit.Name = "bExit";
            this.bExit.Size = new System.Drawing.Size(110, 30);
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
            // Balancedue
            // 
            this.Balancedue.BackColor = System.Drawing.Color.White;
            this.Balancedue.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Balancedue.ForeColor = System.Drawing.Color.Red;
            this.Balancedue.Location = new System.Drawing.Point(601, 30);
            this.Balancedue.Name = "Balancedue";
            this.Balancedue.Size = new System.Drawing.Size(87, 21);
            this.Balancedue.TabIndex = 6;
            this.Balancedue.Text = "16-16-25900";
            this.Balancedue.TextAlignment = System.Drawing.ContentAlignment.TopLeft;
            // 
            // radLabel6
            // 
            this.radLabel6.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.radLabel6.Location = new System.Drawing.Point(515, 30);
            this.radLabel6.Name = "radLabel6";
            this.radLabel6.Size = new System.Drawing.Size(80, 21);
            this.radLabel6.TabIndex = 5;
            this.radLabel6.Text = "Balance Due";
            this.radLabel6.TextAlignment = System.Drawing.ContentAlignment.TopLeft;
            // 
            // Paidtotal
            // 
            this.Paidtotal.BackColor = System.Drawing.Color.White;
            this.Paidtotal.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Paidtotal.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.Paidtotal.Location = new System.Drawing.Point(413, 30);
            this.Paidtotal.Name = "Paidtotal";
            this.Paidtotal.Size = new System.Drawing.Size(87, 21);
            this.Paidtotal.TabIndex = 4;
            this.Paidtotal.Text = "16-16-25900";
            this.Paidtotal.TextAlignment = System.Drawing.ContentAlignment.TopLeft;
            // 
            // radLabel4
            // 
            this.radLabel4.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.radLabel4.Location = new System.Drawing.Point(342, 30);
            this.radLabel4.Name = "radLabel4";
            this.radLabel4.Size = new System.Drawing.Size(65, 21);
            this.radLabel4.TabIndex = 3;
            this.radLabel4.Text = "Total Paid";
            this.radLabel4.TextAlignment = System.Drawing.ContentAlignment.TopLeft;
            // 
            // Membership
            // 
            this.Membership.BackColor = System.Drawing.Color.White;
            this.Membership.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Membership.ForeColor = System.Drawing.Color.DodgerBlue;
            this.Membership.Location = new System.Drawing.Point(249, 30);
            this.Membership.Name = "Membership";
            this.Membership.Size = new System.Drawing.Size(87, 21);
            this.Membership.TabIndex = 2;
            this.Membership.Text = "16-16-25900";
            this.Membership.TextAlignment = System.Drawing.ContentAlignment.TopLeft;
            // 
            // radLabel2
            // 
            this.radLabel2.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.radLabel2.Location = new System.Drawing.Point(129, 30);
            this.radLabel2.Name = "radLabel2";
            this.radLabel2.Size = new System.Drawing.Size(114, 21);
            this.radLabel2.TabIndex = 1;
            this.radLabel2.Text = "Total Membership";
            // 
            // Contractnumber
            // 
            this.Contractnumber.BackColor = System.Drawing.Color.White;
            this.Contractnumber.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Contractnumber.Location = new System.Drawing.Point(17, 30);
            this.Contractnumber.Name = "Contractnumber";
            this.Contractnumber.Size = new System.Drawing.Size(87, 21);
            this.Contractnumber.TabIndex = 0;
            this.Contractnumber.Text = "16-16-25900";
            // 
            // Paymentlist
            // 
            this.Paymentlist.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Paymentlist.Location = new System.Drawing.Point(12, 106);
            // 
            // 
            // 
            this.Paymentlist.MasterTemplate.AllowAddNewRow = false;
            gridViewTextBoxColumn1.FieldName = "datecreate";
            gridViewTextBoxColumn1.FormatString = "{0:MM-dd-yyyy}";
            gridViewTextBoxColumn1.HeaderText = "Transaction Date";
            gridViewTextBoxColumn1.Name = "datecreate";
            gridViewTextBoxColumn1.Width = 115;
            gridViewTextBoxColumn2.FieldName = "transactiontype";
            gridViewTextBoxColumn2.HeaderText = "Transaction Type";
            gridViewTextBoxColumn2.Name = "transactiontype";
            gridViewTextBoxColumn2.Width = 200;
            gridViewTextBoxColumn3.FieldName = "paymentmethod";
            gridViewTextBoxColumn3.HeaderText = "Payment Method";
            gridViewTextBoxColumn3.Name = "paymentmethod";
            gridViewTextBoxColumn3.Width = 150;
            gridViewTextBoxColumn4.FieldName = "description";
            gridViewTextBoxColumn4.HeaderText = "Description";
            gridViewTextBoxColumn4.Name = "description";
            gridViewTextBoxColumn4.Width = 200;
            gridViewTextBoxColumn5.FieldName = "amount";
            gridViewTextBoxColumn5.FormatString = "{0:N2}";
            gridViewTextBoxColumn5.HeaderText = "Amount";
            gridViewTextBoxColumn5.Name = "amount";
            gridViewTextBoxColumn5.TextAlignment = System.Drawing.ContentAlignment.MiddleRight;
            gridViewTextBoxColumn5.Width = 130;
            this.Paymentlist.MasterTemplate.Columns.AddRange(new Telerik.WinControls.UI.GridViewDataColumn[] {
            gridViewTextBoxColumn1,
            gridViewTextBoxColumn2,
            gridViewTextBoxColumn3,
            gridViewTextBoxColumn4,
            gridViewTextBoxColumn5});
            this.Paymentlist.MasterTemplate.ViewDefinition = tableViewDefinition1;
            this.Paymentlist.Name = "Paymentlist";
            this.Paymentlist.ReadOnly = true;
            this.Paymentlist.ShowGroupPanel = false;
            this.Paymentlist.Size = new System.Drawing.Size(820, 269);
            this.Paymentlist.TabIndex = 2;
            // 
            // ViewDTSPayments
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.MintCream;
            this.ClientSize = new System.Drawing.Size(849, 387);
            this.Controls.Add(this.Paymentlist);
            this.Controls.Add(this.radGroupBox1);
            this.Controls.Add(this.radTitleBar1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "ViewDTSPayments";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "View Payments";
            this.Load += new System.EventHandler(this.ViewDTSPayments_Load);
            ((System.ComponentModel.ISupportInitialize)(this.radTitleBar1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radGroupBox1)).EndInit();
            this.radGroupBox1.ResumeLayout(false);
            this.radGroupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.bExit)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Balancedue)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel6)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Paidtotal)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Membership)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Contractnumber)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Paymentlist.MasterTemplate)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Paymentlist)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Telerik.WinControls.UI.RadTitleBar radTitleBar1;
        private Telerik.WinControls.UI.RadGroupBox radGroupBox1;
        private Telerik.WinControls.UI.RadButton bExit;
        private Telerik.WinControls.UI.RadLabel Balancedue;
        private Telerik.WinControls.UI.RadLabel radLabel6;
        private Telerik.WinControls.UI.RadLabel Paidtotal;
        private Telerik.WinControls.UI.RadLabel radLabel4;
        private Telerik.WinControls.UI.RadLabel Membership;
        private Telerik.WinControls.UI.RadLabel radLabel2;
        private Telerik.WinControls.UI.RadLabel Contractnumber;
        private Telerik.WinControls.UI.RadGridView Paymentlist;
    }
}