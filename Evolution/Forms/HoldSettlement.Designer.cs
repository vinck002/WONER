namespace Evolution.Forms
{
    partial class HoldSettlement
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
            Telerik.WinControls.UI.RadGridView holdtransactions;
            Telerik.WinControls.UI.GridViewTextBoxColumn gridViewTextBoxColumn1 = new Telerik.WinControls.UI.GridViewTextBoxColumn();
            Telerik.WinControls.UI.GridViewTextBoxColumn gridViewTextBoxColumn2 = new Telerik.WinControls.UI.GridViewTextBoxColumn();
            Telerik.WinControls.UI.GridViewTextBoxColumn gridViewTextBoxColumn3 = new Telerik.WinControls.UI.GridViewTextBoxColumn();
            Telerik.WinControls.UI.GridViewTextBoxColumn gridViewTextBoxColumn4 = new Telerik.WinControls.UI.GridViewTextBoxColumn();
            Telerik.WinControls.UI.TableViewDefinition tableViewDefinition1 = new Telerik.WinControls.UI.TableViewDefinition();
            Telerik.WinControls.UI.GridViewTextBoxColumn gridViewTextBoxColumn5 = new Telerik.WinControls.UI.GridViewTextBoxColumn();
            Telerik.WinControls.UI.GridViewTextBoxColumn gridViewTextBoxColumn6 = new Telerik.WinControls.UI.GridViewTextBoxColumn();
            Telerik.WinControls.UI.GridViewTextBoxColumn gridViewTextBoxColumn7 = new Telerik.WinControls.UI.GridViewTextBoxColumn();
            Telerik.WinControls.UI.GridViewTextBoxColumn gridViewTextBoxColumn8 = new Telerik.WinControls.UI.GridViewTextBoxColumn();
            Telerik.WinControls.UI.TableViewDefinition tableViewDefinition2 = new Telerik.WinControls.UI.TableViewDefinition();
            this.radTitleBar1 = new Telerik.WinControls.UI.RadTitleBar();
            this.radGroupBox1 = new Telerik.WinControls.UI.RadGroupBox();
            this.Membername = new Telerik.WinControls.UI.RadLabel();
            this.AgreementNumber = new Telerik.WinControls.UI.RadLabel();
            this.radGroupBox2 = new Telerik.WinControls.UI.RadGroupBox();
            this.radLabel2 = new Telerik.WinControls.UI.RadLabel();
            this.radLabel1 = new Telerik.WinControls.UI.RadLabel();
            this.bRelease = new Telerik.WinControls.UI.RadRadioButton();
            this.bHold = new Telerik.WinControls.UI.RadRadioButton();
            this.Comment = new Telerik.WinControls.UI.RadTextBox();
            this.Transactiondate = new Telerik.WinControls.UI.RadDateTimePicker();
            this.bCancel = new Telerik.WinControls.UI.RadButton();
            this.bApply = new Telerik.WinControls.UI.RadButton();
            this.transactionshold = new Telerik.WinControls.UI.RadGridView();
            holdtransactions = new Telerik.WinControls.UI.RadGridView();
            ((System.ComponentModel.ISupportInitialize)(holdtransactions)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(holdtransactions.MasterTemplate)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radTitleBar1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radGroupBox1)).BeginInit();
            this.radGroupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Membername)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.AgreementNumber)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radGroupBox2)).BeginInit();
            this.radGroupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bRelease)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bHold)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Comment)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Transactiondate)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bCancel)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bApply)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.transactionshold)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.transactionshold.MasterTemplate)).BeginInit();
            this.SuspendLayout();
            // 
            // holdtransactions
            // 
            holdtransactions.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            holdtransactions.Location = new System.Drawing.Point(635, 36);
            // 
            // 
            // 
            holdtransactions.MasterTemplate.AllowAddNewRow = false;
            gridViewTextBoxColumn1.HeaderText = "STATUS";
            gridViewTextBoxColumn1.Name = "status";
            gridViewTextBoxColumn1.Width = 125;
            gridViewTextBoxColumn2.HeaderText = "COMMENT";
            gridViewTextBoxColumn2.Name = "COMMENT";
            gridViewTextBoxColumn2.Width = 250;
            gridViewTextBoxColumn3.HeaderText = "USER NAME";
            gridViewTextBoxColumn3.Name = "USERNAME";
            gridViewTextBoxColumn3.Width = 200;
            gridViewTextBoxColumn4.HeaderText = "TRANSACTION DATE";
            gridViewTextBoxColumn4.Name = "TRANSACTIONDATE";
            gridViewTextBoxColumn4.Width = 180;
            holdtransactions.MasterTemplate.Columns.AddRange(new Telerik.WinControls.UI.GridViewDataColumn[] {
            gridViewTextBoxColumn1,
            gridViewTextBoxColumn2,
            gridViewTextBoxColumn3,
            gridViewTextBoxColumn4});
            holdtransactions.MasterTemplate.ViewDefinition = tableViewDefinition1;
            holdtransactions.Name = "holdtransactions";
            holdtransactions.ReadOnly = true;
            holdtransactions.ShowGroupPanel = false;
            holdtransactions.Size = new System.Drawing.Size(61, 69);
            holdtransactions.TabIndex = 1;
            holdtransactions.Visible = false;
            // 
            // radTitleBar1
            // 
            this.radTitleBar1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(173)))), ((int)(((byte)(230)))), ((int)(((byte)(217)))));
            this.radTitleBar1.Dock = System.Windows.Forms.DockStyle.Top;
            this.radTitleBar1.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.radTitleBar1.ForeColor = System.Drawing.Color.Black;
            this.radTitleBar1.Location = new System.Drawing.Point(0, 0);
            this.radTitleBar1.Name = "radTitleBar1";
            this.radTitleBar1.Size = new System.Drawing.Size(804, 30);
            this.radTitleBar1.TabIndex = 0;
            this.radTitleBar1.TabStop = false;
            this.radTitleBar1.Text = "Hold Settlement";
            this.radTitleBar1.ThemeName = "Breeze";
            ((Telerik.WinControls.UI.RadTitleBarElement)(this.radTitleBar1.GetChildAt(0))).Text = "Hold Settlement";
            ((Telerik.WinControls.Primitives.FillPrimitive)(this.radTitleBar1.GetChildAt(0).GetChildAt(0))).BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(227)))), ((int)(((byte)(239)))), ((int)(((byte)(246)))));
            ((Telerik.WinControls.Primitives.FillPrimitive)(this.radTitleBar1.GetChildAt(0).GetChildAt(0))).SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.None;
            ((Telerik.WinControls.Primitives.BorderPrimitive)(this.radTitleBar1.GetChildAt(0).GetChildAt(1))).BoxStyle = Telerik.WinControls.BorderBoxStyle.FourBorders;
            ((Telerik.WinControls.Primitives.BorderPrimitive)(this.radTitleBar1.GetChildAt(0).GetChildAt(1))).LeftShadowColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(207)))), ((int)(((byte)(248)))), ((int)(((byte)(238)))));
            ((Telerik.WinControls.Primitives.BorderPrimitive)(this.radTitleBar1.GetChildAt(0).GetChildAt(1))).InnerColor4 = System.Drawing.Color.FromArgb(((int)(((byte)(143)))), ((int)(((byte)(238)))), ((int)(((byte)(187)))));
            ((Telerik.WinControls.Primitives.BorderPrimitive)(this.radTitleBar1.GetChildAt(0).GetChildAt(1))).SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.Default;
            // 
            // radGroupBox1
            // 
            this.radGroupBox1.AccessibleRole = System.Windows.Forms.AccessibleRole.Grouping;
            this.radGroupBox1.Controls.Add(this.Membername);
            this.radGroupBox1.Controls.Add(this.AgreementNumber);
            this.radGroupBox1.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.radGroupBox1.HeaderText = "Info";
            this.radGroupBox1.Location = new System.Drawing.Point(12, 36);
            this.radGroupBox1.Name = "radGroupBox1";
            this.radGroupBox1.Size = new System.Drawing.Size(530, 57);
            this.radGroupBox1.TabIndex = 2;
            this.radGroupBox1.Text = "Info";
            ((Telerik.WinControls.Primitives.FillPrimitive)(this.radGroupBox1.GetChildAt(0).GetChildAt(1).GetChildAt(0))).BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(227)))), ((int)(((byte)(239)))), ((int)(((byte)(246)))));
            ((Telerik.WinControls.Primitives.FillPrimitive)(this.radGroupBox1.GetChildAt(0).GetChildAt(1).GetChildAt(0))).SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.None;
            // 
            // Membername
            // 
            this.Membername.BackColor = System.Drawing.Color.White;
            this.Membername.Font = new System.Drawing.Font("Segoe UI", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Membername.ForeColor = System.Drawing.SystemColors.InfoText;
            this.Membername.Location = new System.Drawing.Point(206, 18);
            this.Membername.Name = "Membername";
            this.Membername.Size = new System.Drawing.Size(256, 33);
            this.Membername.TabIndex = 1;
            this.Membername.Text = "Jose luis vargar almonte";
            // 
            // AgreementNumber
            // 
            this.AgreementNumber.BackColor = System.Drawing.Color.White;
            this.AgreementNumber.Font = new System.Drawing.Font("Segoe UI", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.AgreementNumber.ForeColor = System.Drawing.SystemColors.InfoText;
            this.AgreementNumber.Location = new System.Drawing.Point(29, 18);
            this.AgreementNumber.Name = "AgreementNumber";
            this.AgreementNumber.Size = new System.Drawing.Size(139, 33);
            this.AgreementNumber.TabIndex = 0;
            this.AgreementNumber.Text = "04-04-25900";
            // 
            // radGroupBox2
            // 
            this.radGroupBox2.AccessibleRole = System.Windows.Forms.AccessibleRole.Grouping;
            this.radGroupBox2.Controls.Add(this.radLabel2);
            this.radGroupBox2.Controls.Add(this.radLabel1);
            this.radGroupBox2.Controls.Add(this.bRelease);
            this.radGroupBox2.Controls.Add(this.bHold);
            this.radGroupBox2.Controls.Add(this.Comment);
            this.radGroupBox2.Controls.Add(this.Transactiondate);
            this.radGroupBox2.Controls.Add(this.bCancel);
            this.radGroupBox2.Controls.Add(this.bApply);
            this.radGroupBox2.HeaderText = "";
            this.radGroupBox2.Location = new System.Drawing.Point(12, 364);
            this.radGroupBox2.Name = "radGroupBox2";
            this.radGroupBox2.Size = new System.Drawing.Size(780, 66);
            this.radGroupBox2.TabIndex = 3;
            // 
            // radLabel2
            // 
            this.radLabel2.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.radLabel2.Location = new System.Drawing.Point(127, 40);
            this.radLabel2.Name = "radLabel2";
            this.radLabel2.Size = new System.Drawing.Size(105, 21);
            this.radLabel2.TabIndex = 7;
            this.radLabel2.Text = "Application Date";
            this.radLabel2.TextAlignment = System.Drawing.ContentAlignment.TopLeft;
            // 
            // radLabel1
            // 
            this.radLabel1.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.radLabel1.Location = new System.Drawing.Point(167, 13);
            this.radLabel1.Name = "radLabel1";
            this.radLabel1.Size = new System.Drawing.Size(65, 21);
            this.radLabel1.TabIndex = 6;
            this.radLabel1.Text = "Reference";
            // 
            // bRelease
            // 
            this.bRelease.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bRelease.Location = new System.Drawing.Point(41, 10);
            this.bRelease.Name = "bRelease";
            this.bRelease.Size = new System.Drawing.Size(66, 21);
            this.bRelease.TabIndex = 5;
            this.bRelease.TabStop = false;
            this.bRelease.Text = "Release";
            // 
            // bHold
            // 
            this.bHold.CheckState = System.Windows.Forms.CheckState.Checked;
            this.bHold.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bHold.Location = new System.Drawing.Point(41, 40);
            this.bHold.Name = "bHold";
            this.bHold.Size = new System.Drawing.Size(49, 21);
            this.bHold.TabIndex = 4;
            this.bHold.Text = "Hold";
            this.bHold.ToggleState = Telerik.WinControls.Enumerations.ToggleState.On;
            // 
            // Comment
            // 
            this.Comment.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Comment.Location = new System.Drawing.Point(246, 9);
            this.Comment.Name = "Comment";
            this.Comment.NullText = "Reference";
            this.Comment.Size = new System.Drawing.Size(255, 23);
            this.Comment.TabIndex = 3;
            // 
            // Transactiondate
            // 
            this.Transactiondate.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Transactiondate.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.Transactiondate.Location = new System.Drawing.Point(246, 38);
            this.Transactiondate.Name = "Transactiondate";
            this.Transactiondate.Size = new System.Drawing.Size(134, 23);
            this.Transactiondate.TabIndex = 2;
            this.Transactiondate.TabStop = false;
            this.Transactiondate.Text = "08/04/2017";
            this.Transactiondate.Value = new System.DateTime(2017, 8, 4, 0, 0, 0, 0);
            // 
            // bCancel
            // 
            this.bCancel.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bCancel.ForeColor = System.Drawing.Color.Black;
            this.bCancel.Image = global::Evolution.Properties.Resources.salir;
            this.bCancel.ImageAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            this.bCancel.Location = new System.Drawing.Point(658, 24);
            this.bCancel.Name = "bCancel";
            this.bCancel.Size = new System.Drawing.Size(110, 32);
            this.bCancel.TabIndex = 1;
            this.bCancel.Text = "Exit";
            this.bCancel.TextAlignment = System.Drawing.ContentAlignment.MiddleLeft;
            this.bCancel.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.bCancel.Click += new System.EventHandler(this.bCancel_Click);
            ((Telerik.WinControls.UI.RadButtonElement)(this.bCancel.GetChildAt(0))).Image = global::Evolution.Properties.Resources.salir;
            ((Telerik.WinControls.UI.RadButtonElement)(this.bCancel.GetChildAt(0))).TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            ((Telerik.WinControls.UI.RadButtonElement)(this.bCancel.GetChildAt(0))).ImageAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            ((Telerik.WinControls.UI.RadButtonElement)(this.bCancel.GetChildAt(0))).TextAlignment = System.Drawing.ContentAlignment.MiddleLeft;
            ((Telerik.WinControls.UI.RadButtonElement)(this.bCancel.GetChildAt(0))).Text = "Exit";
            ((Telerik.WinControls.Primitives.ImagePrimitive)(this.bCancel.GetChildAt(0).GetChildAt(1).GetChildAt(0))).ImageScaling = Telerik.WinControls.Enumerations.ImageScaling.SizeToFit;
            // 
            // bApply
            // 
            this.bApply.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bApply.ForeColor = System.Drawing.Color.Black;
            this.bApply.Image = global::Evolution.Properties.Resources.ok;
            this.bApply.ImageAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            this.bApply.Location = new System.Drawing.Point(542, 24);
            this.bApply.Name = "bApply";
            this.bApply.Size = new System.Drawing.Size(110, 32);
            this.bApply.TabIndex = 0;
            this.bApply.Text = "Apply";
            this.bApply.TextAlignment = System.Drawing.ContentAlignment.MiddleLeft;
            this.bApply.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.bApply.Click += new System.EventHandler(this.bApply_Click);
            ((Telerik.WinControls.UI.RadButtonElement)(this.bApply.GetChildAt(0))).Image = global::Evolution.Properties.Resources.ok;
            ((Telerik.WinControls.UI.RadButtonElement)(this.bApply.GetChildAt(0))).TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            ((Telerik.WinControls.UI.RadButtonElement)(this.bApply.GetChildAt(0))).ImageAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            ((Telerik.WinControls.UI.RadButtonElement)(this.bApply.GetChildAt(0))).TextAlignment = System.Drawing.ContentAlignment.MiddleLeft;
            ((Telerik.WinControls.UI.RadButtonElement)(this.bApply.GetChildAt(0))).Text = "Apply";
            ((Telerik.WinControls.Primitives.ImagePrimitive)(this.bApply.GetChildAt(0).GetChildAt(1).GetChildAt(0))).ImageScaling = Telerik.WinControls.Enumerations.ImageScaling.SizeToFit;
            // 
            // transactionshold
            // 
            this.transactionshold.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.transactionshold.Location = new System.Drawing.Point(12, 99);
            // 
            // 
            // 
            this.transactionshold.MasterTemplate.AllowAddNewRow = false;
            gridViewTextBoxColumn5.FieldName = "status_description";
            gridViewTextBoxColumn5.HeaderText = "Status";
            gridViewTextBoxColumn5.Name = "Status";
            gridViewTextBoxColumn5.Width = 130;
            gridViewTextBoxColumn6.FieldName = "remarks";
            gridViewTextBoxColumn6.HeaderText = "Reference";
            gridViewTextBoxColumn6.Name = "COMMENT";
            gridViewTextBoxColumn6.Width = 250;
            gridViewTextBoxColumn7.FieldName = "username";
            gridViewTextBoxColumn7.HeaderText = "User Name";
            gridViewTextBoxColumn7.Name = "USERNAME";
            gridViewTextBoxColumn7.Width = 200;
            gridViewTextBoxColumn8.FieldName = "Transaction_date";
            gridViewTextBoxColumn8.FormatString = "{0:MM-dd-yyyy}";
            gridViewTextBoxColumn8.HeaderText = "Transaction Date";
            gridViewTextBoxColumn8.Name = "TRANSACTIONDATE";
            gridViewTextBoxColumn8.Width = 200;
            this.transactionshold.MasterTemplate.Columns.AddRange(new Telerik.WinControls.UI.GridViewDataColumn[] {
            gridViewTextBoxColumn5,
            gridViewTextBoxColumn6,
            gridViewTextBoxColumn7,
            gridViewTextBoxColumn8});
            this.transactionshold.MasterTemplate.ViewDefinition = tableViewDefinition2;
            this.transactionshold.Name = "transactionshold";
            this.transactionshold.ReadOnly = true;
            this.transactionshold.ShowGroupPanel = false;
            this.transactionshold.Size = new System.Drawing.Size(780, 259);
            this.transactionshold.TabIndex = 4;
            // 
            // HoldSettlement
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(244)))), ((int)(((byte)(251)))), ((int)(((byte)(255)))));
            this.ClientSize = new System.Drawing.Size(804, 440);
            this.Controls.Add(this.transactionshold);
            this.Controls.Add(this.radGroupBox2);
            this.Controls.Add(this.radGroupBox1);
            this.Controls.Add(holdtransactions);
            this.Controls.Add(this.radTitleBar1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "HoldSettlement";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Hold Settlement";
            this.Activated += new System.EventHandler(this.HoldSettlement_Activated);
            this.Load += new System.EventHandler(this.HoldSettlement_Load);
            this.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.HoldSettlement_KeyPress);
            ((System.ComponentModel.ISupportInitialize)(holdtransactions.MasterTemplate)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(holdtransactions)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radTitleBar1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radGroupBox1)).EndInit();
            this.radGroupBox1.ResumeLayout(false);
            this.radGroupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Membername)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.AgreementNumber)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radGroupBox2)).EndInit();
            this.radGroupBox2.ResumeLayout(false);
            this.radGroupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bRelease)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bHold)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Comment)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Transactiondate)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bCancel)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bApply)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.transactionshold.MasterTemplate)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.transactionshold)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Telerik.WinControls.UI.RadTitleBar radTitleBar1;
        private Telerik.WinControls.UI.RadGroupBox radGroupBox1;
        private Telerik.WinControls.UI.RadLabel Membername;
        private Telerik.WinControls.UI.RadLabel AgreementNumber;
        private Telerik.WinControls.UI.RadGroupBox radGroupBox2;
        private Telerik.WinControls.UI.RadButton bCancel;
        private Telerik.WinControls.UI.RadButton bApply;
        private Telerik.WinControls.UI.RadDateTimePicker Transactiondate;
        private Telerik.WinControls.UI.RadTextBox Comment;
        private Telerik.WinControls.UI.RadRadioButton bRelease;
        private Telerik.WinControls.UI.RadRadioButton bHold;
        private Telerik.WinControls.UI.RadGridView transactionshold;
        private Telerik.WinControls.UI.RadLabel radLabel2;
        private Telerik.WinControls.UI.RadLabel radLabel1;
    }
}