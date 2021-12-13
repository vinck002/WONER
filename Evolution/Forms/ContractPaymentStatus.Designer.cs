namespace Evolution.Forms
{
    partial class ContractPaymentStatus
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ContractPaymentStatus));
            this.transactionslist = new Telerik.WinControls.UI.RadGridView();
            this.radGroupBox2 = new Telerik.WinControls.UI.RadGroupBox();
            this.AllowPay = new Telerik.WinControls.UI.RadCheckBox();
            this.AgreementNumber = new Telerik.WinControls.UI.RadLabel();
            this.radTitleBar1 = new Telerik.WinControls.UI.RadTitleBar();
            this.bExit = new Telerik.WinControls.UI.RadButton();
            this.bInactivate = new Telerik.WinControls.UI.RadButton();
            this.bSave = new Telerik.WinControls.UI.RadButton();
            ((System.ComponentModel.ISupportInitialize)(this.transactionslist)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.transactionslist.MasterTemplate)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radGroupBox2)).BeginInit();
            this.radGroupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.AllowPay)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.AgreementNumber)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radTitleBar1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bExit)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bInactivate)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bSave)).BeginInit();
            this.SuspendLayout();
            // 
            // transactionslist
            // 
            this.transactionslist.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.transactionslist.Location = new System.Drawing.Point(23, 98);
            // 
            // 
            // 
            this.transactionslist.MasterTemplate.AllowAddNewRow = false;
            this.transactionslist.MasterTemplate.AutoSizeColumnsMode = Telerik.WinControls.UI.GridViewAutoSizeColumnsMode.Fill;
            this.transactionslist.MasterTemplate.ViewDefinition = tableViewDefinition1;
            this.transactionslist.Name = "transactionslist";
            this.transactionslist.ReadOnly = true;
            this.transactionslist.ShowGroupPanel = false;
            this.transactionslist.Size = new System.Drawing.Size(579, 129);
            this.transactionslist.TabIndex = 3;
            this.transactionslist.ThemeName = "Breeze";
            // 
            // radGroupBox2
            // 
            this.radGroupBox2.AccessibleRole = System.Windows.Forms.AccessibleRole.Grouping;
            this.radGroupBox2.Controls.Add(this.AllowPay);
            this.radGroupBox2.Controls.Add(this.AgreementNumber);
            this.radGroupBox2.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.radGroupBox2.HeaderText = "";
            this.radGroupBox2.Location = new System.Drawing.Point(23, 40);
            this.radGroupBox2.Name = "radGroupBox2";
            // 
            // 
            // 
            this.radGroupBox2.RootElement.FocusBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(197)))), ((int)(((byte)(234)))), ((int)(((byte)(221)))));
            this.radGroupBox2.Size = new System.Drawing.Size(341, 52);
            this.radGroupBox2.TabIndex = 14;
            this.radGroupBox2.ThemeName = "Breeze";
            // 
            // AllowPay
            // 
            this.AllowPay.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.AllowPay.Location = new System.Drawing.Point(5, 13);
            this.AllowPay.Name = "AllowPay";
            this.AllowPay.Size = new System.Drawing.Size(151, 30);
            this.AllowPay.TabIndex = 1;
            this.AllowPay.Text = "Allow Payment";
            // 
            // AgreementNumber
            // 
            this.AgreementNumber.BackColor = System.Drawing.Color.White;
            this.AgreementNumber.Font = new System.Drawing.Font("Segoe UI", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.AgreementNumber.ForeColor = System.Drawing.Color.Black;
            this.AgreementNumber.Location = new System.Drawing.Point(162, 10);
            this.AgreementNumber.Name = "AgreementNumber";
            this.AgreementNumber.Size = new System.Drawing.Size(139, 33);
            this.AgreementNumber.TabIndex = 0;
            this.AgreementNumber.Text = "04-04-25900";
            // 
            // radTitleBar1
            // 
            this.radTitleBar1.Dock = System.Windows.Forms.DockStyle.Top;
            this.radTitleBar1.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.radTitleBar1.ForeColor = System.Drawing.Color.Black;
            this.radTitleBar1.Location = new System.Drawing.Point(0, 0);
            this.radTitleBar1.Name = "radTitleBar1";
            this.radTitleBar1.Size = new System.Drawing.Size(622, 30);
            this.radTitleBar1.TabIndex = 15;
            this.radTitleBar1.TabStop = false;
            this.radTitleBar1.Text = "Contract Payment Status";
            this.radTitleBar1.ThemeName = "Breeze";
            ((Telerik.WinControls.UI.RadTitleBarElement)(this.radTitleBar1.GetChildAt(0))).Text = "Contract Payment Status";
            ((Telerik.WinControls.Primitives.FillPrimitive)(this.radTitleBar1.GetChildAt(0).GetChildAt(0))).BackColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(211)))), ((int)(((byte)(235)))), ((int)(((byte)(246)))));
            ((Telerik.WinControls.Primitives.FillPrimitive)(this.radTitleBar1.GetChildAt(0).GetChildAt(0))).BackColor3 = System.Drawing.Color.FromArgb(((int)(((byte)(211)))), ((int)(((byte)(235)))), ((int)(((byte)(246)))));
            ((Telerik.WinControls.Primitives.FillPrimitive)(this.radTitleBar1.GetChildAt(0).GetChildAt(0))).BackColor4 = System.Drawing.Color.FromArgb(((int)(((byte)(211)))), ((int)(((byte)(235)))), ((int)(((byte)(246)))));
            ((Telerik.WinControls.Primitives.FillPrimitive)(this.radTitleBar1.GetChildAt(0).GetChildAt(0))).BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(211)))), ((int)(((byte)(235)))), ((int)(((byte)(246)))));
            ((Telerik.WinControls.Primitives.FillPrimitive)(this.radTitleBar1.GetChildAt(0).GetChildAt(0))).SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.None;
            // 
            // bExit
            // 
            this.bExit.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bExit.ForeColor = System.Drawing.Color.Black;
            this.bExit.Image = global::Evolution.Properties.Resources.salir;
            this.bExit.ImageAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            this.bExit.Location = new System.Drawing.Point(492, 233);
            this.bExit.Name = "bExit";
            this.bExit.Size = new System.Drawing.Size(110, 32);
            this.bExit.TabIndex = 16;
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
            // bInactivate
            // 
            this.bInactivate.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bInactivate.ForeColor = System.Drawing.Color.Black;
            this.bInactivate.Image = global::Evolution.Properties.Resources.stop;
            this.bInactivate.ImageAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            this.bInactivate.Location = new System.Drawing.Point(376, 233);
            this.bInactivate.Name = "bInactivate";
            this.bInactivate.Size = new System.Drawing.Size(110, 32);
            this.bInactivate.TabIndex = 17;
            this.bInactivate.Text = "Inactivate";
            this.bInactivate.TextAlignment = System.Drawing.ContentAlignment.MiddleLeft;
            this.bInactivate.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.bInactivate.Click += new System.EventHandler(this.bInactivate_Click);
            ((Telerik.WinControls.UI.RadButtonElement)(this.bInactivate.GetChildAt(0))).Image = global::Evolution.Properties.Resources.stop;
            ((Telerik.WinControls.UI.RadButtonElement)(this.bInactivate.GetChildAt(0))).TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            ((Telerik.WinControls.UI.RadButtonElement)(this.bInactivate.GetChildAt(0))).ImageAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            ((Telerik.WinControls.UI.RadButtonElement)(this.bInactivate.GetChildAt(0))).TextAlignment = System.Drawing.ContentAlignment.MiddleLeft;
            ((Telerik.WinControls.UI.RadButtonElement)(this.bInactivate.GetChildAt(0))).Text = "Inactivate";
            ((Telerik.WinControls.Primitives.ImagePrimitive)(this.bInactivate.GetChildAt(0).GetChildAt(1).GetChildAt(0))).ImageScaling = Telerik.WinControls.Enumerations.ImageScaling.SizeToFit;
            // 
            // bSave
            // 
            this.bSave.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bSave.ForeColor = System.Drawing.Color.Black;
            this.bSave.Image = global::Evolution.Properties.Resources.save;
            this.bSave.ImageAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            this.bSave.Location = new System.Drawing.Point(260, 233);
            this.bSave.Name = "bSave";
            this.bSave.Size = new System.Drawing.Size(110, 32);
            this.bSave.TabIndex = 18;
            this.bSave.Text = "Save";
            this.bSave.TextAlignment = System.Drawing.ContentAlignment.MiddleLeft;
            this.bSave.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.bSave.Click += new System.EventHandler(this.bSave_Click);
            ((Telerik.WinControls.UI.RadButtonElement)(this.bSave.GetChildAt(0))).Image = global::Evolution.Properties.Resources.save;
            ((Telerik.WinControls.UI.RadButtonElement)(this.bSave.GetChildAt(0))).TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            ((Telerik.WinControls.UI.RadButtonElement)(this.bSave.GetChildAt(0))).ImageAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            ((Telerik.WinControls.UI.RadButtonElement)(this.bSave.GetChildAt(0))).TextAlignment = System.Drawing.ContentAlignment.MiddleLeft;
            ((Telerik.WinControls.UI.RadButtonElement)(this.bSave.GetChildAt(0))).Text = "Save";
            ((Telerik.WinControls.Primitives.ImagePrimitive)(this.bSave.GetChildAt(0).GetChildAt(1).GetChildAt(0))).ImageScaling = Telerik.WinControls.Enumerations.ImageScaling.SizeToFit;
            // 
            // ContractPaymentStatus
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(244)))), ((int)(((byte)(251)))), ((int)(((byte)(255)))));
            this.ClientSize = new System.Drawing.Size(622, 273);
            this.Controls.Add(this.bSave);
            this.Controls.Add(this.bInactivate);
            this.Controls.Add(this.bExit);
            this.Controls.Add(this.radTitleBar1);
            this.Controls.Add(this.radGroupBox2);
            this.Controls.Add(this.transactionslist);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "ContractPaymentStatus";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Contract Payment Status";
            this.Activated += new System.EventHandler(this.ContractPaymentStatus_Activated);
            this.Load += new System.EventHandler(this.ContractPaymentStatus_Load);
            this.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.ContractPaymentStatus_KeyPress);
            ((System.ComponentModel.ISupportInitialize)(this.transactionslist.MasterTemplate)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.transactionslist)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radGroupBox2)).EndInit();
            this.radGroupBox2.ResumeLayout(false);
            this.radGroupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.AllowPay)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.AgreementNumber)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radTitleBar1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bExit)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bInactivate)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bSave)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Telerik.WinControls.UI.RadGridView transactionslist;
        private Telerik.WinControls.UI.RadGroupBox radGroupBox2;
        private Telerik.WinControls.UI.RadLabel AgreementNumber;
        private Telerik.WinControls.UI.RadTitleBar radTitleBar1;
        private Telerik.WinControls.UI.RadButton bExit;
        private Telerik.WinControls.UI.RadCheckBox AllowPay;
        private Telerik.WinControls.UI.RadButton bInactivate;
        private Telerik.WinControls.UI.RadButton bSave;
    }
}