namespace Evolution.Forms
{
    partial class TransferPayments
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
            Telerik.WinControls.UI.TableViewDefinition tableViewDefinition1 = new Telerik.WinControls.UI.TableViewDefinition();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(TransferPayments));
            this.radTitleBar1 = new Telerik.WinControls.UI.RadTitleBar();
            this.Paymentlist = new Telerik.WinControls.UI.RadGridView();
            this.radGroupBox1 = new Telerik.WinControls.UI.RadGroupBox();
            this.radLabel1 = new Telerik.WinControls.UI.RadLabel();
            this.sheetname = new Telerik.WinControls.UI.RadTextBox();
            this.bExit = new Telerik.WinControls.UI.RadButton();
            this.bTransfer = new Telerik.WinControls.UI.RadButton();
            this.bLoadexcel = new Telerik.WinControls.UI.RadButton();
            ((System.ComponentModel.ISupportInitialize)(this.radTitleBar1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Paymentlist)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Paymentlist.MasterTemplate)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radGroupBox1)).BeginInit();
            this.radGroupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.sheetname)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bExit)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bTransfer)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bLoadexcel)).BeginInit();
            this.SuspendLayout();
            // 
            // radTitleBar1
            // 
            this.radTitleBar1.BackColor = System.Drawing.Color.MintCream;
            this.radTitleBar1.Dock = System.Windows.Forms.DockStyle.Top;
            this.radTitleBar1.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.radTitleBar1.ForeColor = System.Drawing.Color.Black;
            this.radTitleBar1.Location = new System.Drawing.Point(0, 0);
            this.radTitleBar1.Name = "radTitleBar1";
            this.radTitleBar1.Size = new System.Drawing.Size(1088, 30);
            this.radTitleBar1.TabIndex = 0;
            this.radTitleBar1.TabStop = false;
            this.radTitleBar1.Text = "Transfer Payments";
            // 
            // Paymentlist
            // 
            this.Paymentlist.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Paymentlist.Location = new System.Drawing.Point(12, 36);
            // 
            // 
            // 
            this.Paymentlist.MasterTemplate.AllowAddNewRow = false;
            this.Paymentlist.MasterTemplate.AutoSizeColumnsMode = Telerik.WinControls.UI.GridViewAutoSizeColumnsMode.Fill;
            this.Paymentlist.MasterTemplate.ViewDefinition = tableViewDefinition1;
            this.Paymentlist.Name = "Paymentlist";
            this.Paymentlist.ReadOnly = true;
            this.Paymentlist.ShowGroupPanel = false;
            this.Paymentlist.Size = new System.Drawing.Size(1064, 525);
            this.Paymentlist.TabIndex = 1;
            this.Paymentlist.Text = "radGridView1";
            // 
            // radGroupBox1
            // 
            this.radGroupBox1.AccessibleRole = System.Windows.Forms.AccessibleRole.Grouping;
            this.radGroupBox1.Controls.Add(this.radLabel1);
            this.radGroupBox1.Controls.Add(this.sheetname);
            this.radGroupBox1.Controls.Add(this.bExit);
            this.radGroupBox1.Controls.Add(this.bTransfer);
            this.radGroupBox1.Controls.Add(this.bLoadexcel);
            this.radGroupBox1.HeaderText = "";
            this.radGroupBox1.Location = new System.Drawing.Point(540, 567);
            this.radGroupBox1.Name = "radGroupBox1";
            this.radGroupBox1.Size = new System.Drawing.Size(536, 67);
            this.radGroupBox1.TabIndex = 2;
            // 
            // radLabel1
            // 
            this.radLabel1.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.radLabel1.Location = new System.Drawing.Point(5, 30);
            this.radLabel1.Name = "radLabel1";
            this.radLabel1.Size = new System.Drawing.Size(119, 21);
            this.radLabel1.TabIndex = 4;
            this.radLabel1.Text = "Excel Sheet Name";
            this.radLabel1.TextAlignment = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // sheetname
            // 
            this.sheetname.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.sheetname.Location = new System.Drawing.Point(130, 29);
            this.sheetname.Name = "sheetname";
            this.sheetname.Size = new System.Drawing.Size(142, 23);
            this.sheetname.TabIndex = 3;
            this.sheetname.Text = "Sheet1";
            // 
            // bExit
            // 
            this.bExit.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bExit.ForeColor = System.Drawing.Color.Black;
            this.bExit.Image = global::Evolution.Properties.Resources.salir;
            this.bExit.ImageAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            this.bExit.Location = new System.Drawing.Point(448, 10);
            this.bExit.Name = "bExit";
            this.bExit.Size = new System.Drawing.Size(79, 44);
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
            // bTransfer
            // 
            this.bTransfer.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bTransfer.ForeColor = System.Drawing.Color.Black;
            this.bTransfer.Image = global::Evolution.Properties.Resources.transfer1;
            this.bTransfer.ImageAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            this.bTransfer.Location = new System.Drawing.Point(363, 10);
            this.bTransfer.Name = "bTransfer";
            this.bTransfer.Size = new System.Drawing.Size(79, 44);
            this.bTransfer.TabIndex = 1;
            this.bTransfer.Tag = "454";
            this.bTransfer.Text = "Transfer";
            this.bTransfer.TextAlignment = System.Drawing.ContentAlignment.MiddleLeft;
            this.bTransfer.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.bTransfer.Click += new System.EventHandler(this.bTransfer_Click);
            ((Telerik.WinControls.UI.RadButtonElement)(this.bTransfer.GetChildAt(0))).Image = global::Evolution.Properties.Resources.transfer1;
            ((Telerik.WinControls.UI.RadButtonElement)(this.bTransfer.GetChildAt(0))).TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            ((Telerik.WinControls.UI.RadButtonElement)(this.bTransfer.GetChildAt(0))).ImageAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            ((Telerik.WinControls.UI.RadButtonElement)(this.bTransfer.GetChildAt(0))).TextAlignment = System.Drawing.ContentAlignment.MiddleLeft;
            ((Telerik.WinControls.UI.RadButtonElement)(this.bTransfer.GetChildAt(0))).Text = "Transfer";
            ((Telerik.WinControls.Primitives.ImagePrimitive)(this.bTransfer.GetChildAt(0).GetChildAt(1).GetChildAt(0))).ImageScaling = Telerik.WinControls.Enumerations.ImageScaling.SizeToFit;
            // 
            // bLoadexcel
            // 
            this.bLoadexcel.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bLoadexcel.ForeColor = System.Drawing.Color.Black;
            this.bLoadexcel.Image = global::Evolution.Properties.Resources.loadfile;
            this.bLoadexcel.ImageAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            this.bLoadexcel.Location = new System.Drawing.Point(278, 10);
            this.bLoadexcel.Name = "bLoadexcel";
            this.bLoadexcel.Size = new System.Drawing.Size(79, 44);
            this.bLoadexcel.TabIndex = 0;
            this.bLoadexcel.Tag = "453";
            this.bLoadexcel.Text = "Load Excel File";
            this.bLoadexcel.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.bLoadexcel.TextWrap = true;
            this.bLoadexcel.Click += new System.EventHandler(this.bLoadexcel_Click);
            ((Telerik.WinControls.UI.RadButtonElement)(this.bLoadexcel.GetChildAt(0))).Image = global::Evolution.Properties.Resources.loadfile;
            ((Telerik.WinControls.UI.RadButtonElement)(this.bLoadexcel.GetChildAt(0))).TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            ((Telerik.WinControls.UI.RadButtonElement)(this.bLoadexcel.GetChildAt(0))).ImageAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            ((Telerik.WinControls.UI.RadButtonElement)(this.bLoadexcel.GetChildAt(0))).Text = "Load Excel File";
            ((Telerik.WinControls.Primitives.ImagePrimitive)(this.bLoadexcel.GetChildAt(0).GetChildAt(1).GetChildAt(0))).ImageScaling = Telerik.WinControls.Enumerations.ImageScaling.SizeToFit;
            // 
            // TransferPayments
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.MintCream;
            this.ClientSize = new System.Drawing.Size(1088, 646);
            this.Controls.Add(this.radGroupBox1);
            this.Controls.Add(this.Paymentlist);
            this.Controls.Add(this.radTitleBar1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "TransferPayments";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Transfer Payments";
            this.Activated += new System.EventHandler(this.TransferPayments_Activated);
            this.Load += new System.EventHandler(this.TransferPayments_Load);
            ((System.ComponentModel.ISupportInitialize)(this.radTitleBar1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Paymentlist.MasterTemplate)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Paymentlist)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radGroupBox1)).EndInit();
            this.radGroupBox1.ResumeLayout(false);
            this.radGroupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.sheetname)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bExit)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bTransfer)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bLoadexcel)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Telerik.WinControls.UI.RadTitleBar radTitleBar1;
        private Telerik.WinControls.UI.RadGridView Paymentlist;
        private Telerik.WinControls.UI.RadGroupBox radGroupBox1;
        private Telerik.WinControls.UI.RadButton bExit;
        private Telerik.WinControls.UI.RadButton bTransfer;
        private Telerik.WinControls.UI.RadButton bLoadexcel;
        private Telerik.WinControls.UI.RadLabel radLabel1;
        private Telerik.WinControls.UI.RadTextBox sheetname;
    }
}