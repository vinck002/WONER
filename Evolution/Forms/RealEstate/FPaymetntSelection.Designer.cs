
namespace Evolution.Forms.RealEstate
{
    partial class FPaymetntSelection
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
            Telerik.WinControls.UI.GridViewCheckBoxColumn gridViewCheckBoxColumn1 = new Telerik.WinControls.UI.GridViewCheckBoxColumn();
            Telerik.WinControls.UI.GridViewTextBoxColumn gridViewTextBoxColumn2 = new Telerik.WinControls.UI.GridViewTextBoxColumn();
            Telerik.WinControls.UI.GridViewTextBoxColumn gridViewTextBoxColumn3 = new Telerik.WinControls.UI.GridViewTextBoxColumn();
            Telerik.WinControls.UI.GridViewTextBoxColumn gridViewTextBoxColumn4 = new Telerik.WinControls.UI.GridViewTextBoxColumn();
            Telerik.WinControls.UI.GridViewTextBoxColumn gridViewTextBoxColumn5 = new Telerik.WinControls.UI.GridViewTextBoxColumn();
            Telerik.WinControls.UI.TableViewDefinition tableViewDefinition1 = new Telerik.WinControls.UI.TableViewDefinition();
            this.gvFuturePayment = new Telerik.WinControls.UI.RadGridView();
            this.lblTotalAmount = new Telerik.WinControls.UI.RadLabel();
            this.radLabel20 = new Telerik.WinControls.UI.RadLabel();
            this.radPanel1 = new Telerik.WinControls.UI.RadPanel();
            this.btnProceed = new Telerik.WinControls.UI.RadButton();
            this.btnCancel = new Telerik.WinControls.UI.RadButton();
            this.radPanel2 = new Telerik.WinControls.UI.RadPanel();
            this.ChCheckUncheck = new System.Windows.Forms.CheckBox();
            this.radCheckBox1 = new Telerik.WinControls.UI.RadCheckBox();
            this.radCheckBox2 = new Telerik.WinControls.UI.RadCheckBox();
            this.ChSelectUnselect = new System.Windows.Forms.CheckBox();
            ((System.ComponentModel.ISupportInitialize)(this.gvFuturePayment)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvFuturePayment.MasterTemplate)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblTotalAmount)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel20)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radPanel1)).BeginInit();
            this.radPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.btnProceed)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnCancel)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radPanel2)).BeginInit();
            this.radPanel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.radCheckBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radCheckBox2)).BeginInit();
            this.SuspendLayout();
            // 
            // gvFuturePayment
            // 
            this.gvFuturePayment.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.gvFuturePayment.Cursor = System.Windows.Forms.Cursors.Default;
            this.gvFuturePayment.Font = new System.Drawing.Font("Segoe UI", 8.25F);
            this.gvFuturePayment.ForeColor = System.Drawing.Color.Black;
            this.gvFuturePayment.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.gvFuturePayment.Location = new System.Drawing.Point(0, 33);
            // 
            // 
            // 
            this.gvFuturePayment.MasterTemplate.AllowAddNewRow = false;
            this.gvFuturePayment.MasterTemplate.AllowColumnChooser = false;
            this.gvFuturePayment.MasterTemplate.AllowColumnHeaderContextMenu = false;
            this.gvFuturePayment.MasterTemplate.AllowDragToGroup = false;
            this.gvFuturePayment.MasterTemplate.AllowRowHeaderContextMenu = false;
            this.gvFuturePayment.MasterTemplate.AutoGenerateColumns = false;
            gridViewTextBoxColumn1.EnableExpressionEditor = false;
            gridViewTextBoxColumn1.FieldName = "FuturesPmtPlanID";
            gridViewTextBoxColumn1.HeaderText = "FuturesPmtPlanID";
            gridViewTextBoxColumn1.IsVisible = false;
            gridViewTextBoxColumn1.Name = "FuturesPmtPlanID";
            gridViewCheckBoxColumn1.AllowSort = false;
            gridViewCheckBoxColumn1.EditMode = Telerik.WinControls.UI.EditMode.OnValueChange;
            gridViewCheckBoxColumn1.EnableExpressionEditor = false;
            gridViewCheckBoxColumn1.FieldName = "Check";
            gridViewCheckBoxColumn1.IsPinned = true;
            gridViewCheckBoxColumn1.MinWidth = 20;
            gridViewCheckBoxColumn1.Name = "Check";
            gridViewCheckBoxColumn1.PinPosition = Telerik.WinControls.UI.PinnedColumnPosition.Left;
            gridViewCheckBoxColumn1.Width = 31;
            gridViewTextBoxColumn2.DataType = typeof(System.DateTime);
            gridViewTextBoxColumn2.EnableExpressionEditor = false;
            gridViewTextBoxColumn2.FieldName = "Date";
            gridViewTextBoxColumn2.FormatString = "{0:MM/dd/yyyy}";
            gridViewTextBoxColumn2.HeaderText = "Date";
            gridViewTextBoxColumn2.Name = "Date";
            gridViewTextBoxColumn2.ReadOnly = true;
            gridViewTextBoxColumn2.Width = 105;
            gridViewTextBoxColumn3.EnableExpressionEditor = false;
            gridViewTextBoxColumn3.FieldName = "Description";
            gridViewTextBoxColumn3.HeaderText = "Description";
            gridViewTextBoxColumn3.Name = "Description";
            gridViewTextBoxColumn3.Width = 92;
            gridViewTextBoxColumn4.DataType = typeof(decimal);
            gridViewTextBoxColumn4.EnableExpressionEditor = false;
            gridViewTextBoxColumn4.FieldName = "Amount";
            gridViewTextBoxColumn4.FormatString = "{0:#,##0.00}";
            gridViewTextBoxColumn4.HeaderText = "Amount";
            gridViewTextBoxColumn4.Name = "Amount";
            gridViewTextBoxColumn4.ReadOnly = true;
            gridViewTextBoxColumn4.Width = 101;
            gridViewTextBoxColumn5.DataType = typeof(decimal);
            gridViewTextBoxColumn5.EnableExpressionEditor = false;
            gridViewTextBoxColumn5.FieldName = "Paying";
            gridViewTextBoxColumn5.FormatString = "{0:#,##0.00}";
            gridViewTextBoxColumn5.HeaderText = "Paying";
            gridViewTextBoxColumn5.Name = "Paying";
            gridViewTextBoxColumn5.ReadOnly = true;
            gridViewTextBoxColumn5.Width = 87;
            this.gvFuturePayment.MasterTemplate.Columns.AddRange(new Telerik.WinControls.UI.GridViewDataColumn[] {
            gridViewTextBoxColumn1,
            gridViewCheckBoxColumn1,
            gridViewTextBoxColumn2,
            gridViewTextBoxColumn3,
            gridViewTextBoxColumn4,
            gridViewTextBoxColumn5});
            this.gvFuturePayment.MasterTemplate.EnableGrouping = false;
            this.gvFuturePayment.MasterTemplate.ShowRowHeaderColumn = false;
            this.gvFuturePayment.MasterTemplate.ViewDefinition = tableViewDefinition1;
            this.gvFuturePayment.Name = "gvFuturePayment";
            this.gvFuturePayment.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.gvFuturePayment.Size = new System.Drawing.Size(413, 228);
            this.gvFuturePayment.TabIndex = 121;
            this.gvFuturePayment.CellClick += new Telerik.WinControls.UI.GridViewCellEventHandler(this.gvFuturePayment_CellClick);
            // 
            // lblTotalAmount
            // 
            this.lblTotalAmount.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblTotalAmount.Font = new System.Drawing.Font("Microsoft Sans Serif", 12.25F, System.Drawing.FontStyle.Bold);
            this.lblTotalAmount.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.lblTotalAmount.Location = new System.Drawing.Point(278, 9);
            this.lblTotalAmount.Name = "lblTotalAmount";
            this.lblTotalAmount.Size = new System.Drawing.Size(42, 23);
            this.lblTotalAmount.TabIndex = 123;
            this.lblTotalAmount.Text = "0.00";
            this.lblTotalAmount.TextAlignment = System.Drawing.ContentAlignment.TopLeft;
            // 
            // radLabel20
            // 
            this.radLabel20.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.radLabel20.Font = new System.Drawing.Font("Microsoft Sans Serif", 12.25F);
            this.radLabel20.Location = new System.Drawing.Point(122, 7);
            this.radLabel20.Name = "radLabel20";
            this.radLabel20.Size = new System.Drawing.Size(160, 23);
            this.radLabel20.TabIndex = 122;
            this.radLabel20.Text = "Remaining Amount :";
            this.radLabel20.TextAlignment = System.Drawing.ContentAlignment.TopLeft;
            // 
            // radPanel1
            // 
            this.radPanel1.BackColor = System.Drawing.Color.Azure;
            this.radPanel1.Controls.Add(this.btnProceed);
            this.radPanel1.Controls.Add(this.btnCancel);
            this.radPanel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.radPanel1.Location = new System.Drawing.Point(0, 261);
            this.radPanel1.Name = "radPanel1";
            this.radPanel1.Size = new System.Drawing.Size(415, 32);
            this.radPanel1.TabIndex = 124;
            // 
            // btnProceed
            // 
            this.btnProceed.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btnProceed.ImageAlignment = System.Drawing.ContentAlignment.BottomLeft;
            this.btnProceed.Location = new System.Drawing.Point(232, 3);
            this.btnProceed.Name = "btnProceed";
            this.btnProceed.Size = new System.Drawing.Size(82, 24);
            this.btnProceed.TabIndex = 0;
            this.btnProceed.Text = "Apply";
            this.btnProceed.Click += new System.EventHandler(this.btnProceed_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.ImageAlignment = System.Drawing.ContentAlignment.BottomLeft;
            this.btnCancel.Location = new System.Drawing.Point(320, 4);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(82, 24);
            this.btnCancel.TabIndex = 0;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // radPanel2
            // 
            this.radPanel2.BackColor = System.Drawing.Color.Azure;
            this.radPanel2.Controls.Add(this.ChCheckUncheck);
            this.radPanel2.Controls.Add(this.gvFuturePayment);
            this.radPanel2.Controls.Add(this.radLabel20);
            this.radPanel2.Controls.Add(this.lblTotalAmount);
            this.radPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.radPanel2.Location = new System.Drawing.Point(0, 0);
            this.radPanel2.Name = "radPanel2";
            this.radPanel2.Size = new System.Drawing.Size(415, 261);
            this.radPanel2.TabIndex = 125;
            // 
            // ChCheckUncheck
            // 
            this.ChCheckUncheck.AutoSize = true;
            this.ChCheckUncheck.Location = new System.Drawing.Point(12, 10);
            this.ChCheckUncheck.Name = "ChCheckUncheck";
            this.ChCheckUncheck.Size = new System.Drawing.Size(69, 17);
            this.ChCheckUncheck.TabIndex = 124;
            this.ChCheckUncheck.Text = "SelectAll";
            this.ChCheckUncheck.UseVisualStyleBackColor = true;
            this.ChCheckUncheck.CheckedChanged += new System.EventHandler(this.ChCheckUncheck_CheckedChanged);
            this.ChCheckUncheck.Click += new System.EventHandler(this.ChCheckUncheck_Click);
            // 
            // radCheckBox1
            // 
            this.radCheckBox1.Location = new System.Drawing.Point(25, 6);
            this.radCheckBox1.Name = "radCheckBox1";
            this.radCheckBox1.Size = new System.Drawing.Size(91, 18);
            this.radCheckBox1.TabIndex = 0;
            this.radCheckBox1.Text = "radCheckBox1";
            // 
            // radCheckBox2
            // 
            this.radCheckBox2.BackColor = System.Drawing.Color.Transparent;
            this.radCheckBox2.Location = new System.Drawing.Point(29, 6);
            this.radCheckBox2.Name = "radCheckBox2";
            this.radCheckBox2.Size = new System.Drawing.Size(50, 18);
            this.radCheckBox2.TabIndex = 0;
            this.radCheckBox2.Text = "Check";
            // 
            // ChSelectUnselect
            // 
            this.ChSelectUnselect.AutoSize = true;
            this.ChSelectUnselect.BackColor = System.Drawing.Color.Transparent;
            this.ChSelectUnselect.Location = new System.Drawing.Point(26, 8);
            this.ChSelectUnselect.Name = "ChSelectUnselect";
            this.ChSelectUnselect.Size = new System.Drawing.Size(56, 17);
            this.ChSelectUnselect.TabIndex = 0;
            this.ChSelectUnselect.Text = "Select";
            this.ChSelectUnselect.UseVisualStyleBackColor = false;
            // 
            // FPaymetntSelection
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(415, 293);
            this.ControlBox = false;
            this.Controls.Add(this.radPanel2);
            this.Controls.Add(this.radPanel1);
            this.Name = "FPaymetntSelection";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Paymetnt Selection";
            ((System.ComponentModel.ISupportInitialize)(this.gvFuturePayment.MasterTemplate)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvFuturePayment)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblTotalAmount)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel20)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radPanel1)).EndInit();
            this.radPanel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.btnProceed)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnCancel)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radPanel2)).EndInit();
            this.radPanel2.ResumeLayout(false);
            this.radPanel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.radCheckBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radCheckBox2)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Telerik.WinControls.UI.RadGridView gvFuturePayment;
        private Telerik.WinControls.UI.RadLabel lblTotalAmount;
        private Telerik.WinControls.UI.RadLabel radLabel20;
        private Telerik.WinControls.UI.RadPanel radPanel1;
        private Telerik.WinControls.UI.RadButton btnCancel;
        private Telerik.WinControls.UI.RadPanel radPanel2;
        private Telerik.WinControls.UI.RadButton btnProceed;
        private Telerik.WinControls.UI.RadCheckBox radCheckBox1;
        private Telerik.WinControls.UI.RadCheckBox radCheckBox2;
        private System.Windows.Forms.CheckBox ChSelectUnselect;
        private System.Windows.Forms.CheckBox ChCheckUncheck;
    }
}