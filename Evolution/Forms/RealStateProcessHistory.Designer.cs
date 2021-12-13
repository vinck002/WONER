namespace Evolution.Forms
{
    partial class RealStateProcessHistory
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(RealStateProcessHistory));
            this.radGroupBox5 = new Telerik.WinControls.UI.RadGroupBox();
            this.BtnExit = new Telerik.WinControls.UI.RadButton();
            this.txtTotalPaid = new Telerik.WinControls.UI.RadTextBox();
            this.radLabel3 = new Telerik.WinControls.UI.RadLabel();
            this.grdPayments = new Telerik.WinControls.UI.RadGridView();
            this.btnCancel = new Telerik.WinControls.UI.RadButton();
            this.breezeTheme1 = new Telerik.WinControls.Themes.BreezeTheme();
            this.bgwSearch = new System.ComponentModel.BackgroundWorker();
            ((System.ComponentModel.ISupportInitialize)(this.radGroupBox5)).BeginInit();
            this.radGroupBox5.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.BtnExit)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtTotalPaid)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdPayments)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdPayments.MasterTemplate)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnCancel)).BeginInit();
            this.SuspendLayout();
            // 
            // radGroupBox5
            // 
            this.radGroupBox5.AccessibleRole = System.Windows.Forms.AccessibleRole.Grouping;
            this.radGroupBox5.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(242)))), ((int)(((byte)(250)))), ((int)(((byte)(255)))));
            this.radGroupBox5.Controls.Add(this.BtnExit);
            this.radGroupBox5.Controls.Add(this.txtTotalPaid);
            this.radGroupBox5.Controls.Add(this.radLabel3);
            this.radGroupBox5.Controls.Add(this.grdPayments);
            this.radGroupBox5.Controls.Add(this.btnCancel);
            this.radGroupBox5.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.radGroupBox5.GroupBoxStyle = Telerik.WinControls.UI.RadGroupBoxStyle.Office;
            this.radGroupBox5.HeaderAlignment = Telerik.WinControls.UI.HeaderAlignment.Center;
            this.radGroupBox5.HeaderText = "Payments Processed";
            this.radGroupBox5.Location = new System.Drawing.Point(3, 1);
            this.radGroupBox5.Name = "radGroupBox5";
            // 
            // 
            // 
            this.radGroupBox5.RootElement.ControlBounds = new System.Drawing.Rectangle(3, 1, 200, 100);
            this.radGroupBox5.Size = new System.Drawing.Size(791, 496);
            this.radGroupBox5.TabIndex = 66;
            this.radGroupBox5.Text = "Payments Processed";
            this.radGroupBox5.Click += new System.EventHandler(this.radGroupBox5_Click);
            ((Telerik.WinControls.UI.RadGroupBoxElement)(this.radGroupBox5.GetChildAt(0))).HeaderAlignment = Telerik.WinControls.UI.HeaderAlignment.Center;
            ((Telerik.WinControls.UI.GroupBoxHeader)(this.radGroupBox5.GetChildAt(0).GetChildAt(1))).GroupBoxStyle = Telerik.WinControls.UI.RadGroupBoxStyle.Office;
            ((Telerik.WinControls.Primitives.FillPrimitive)(this.radGroupBox5.GetChildAt(0).GetChildAt(1).GetChildAt(0))).BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(228)))), ((int)(((byte)(238)))), ((int)(((byte)(250)))));
            ((Telerik.WinControls.Primitives.FillPrimitive)(this.radGroupBox5.GetChildAt(0).GetChildAt(1).GetChildAt(0))).SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.None;
            // 
            // BtnExit
            // 
            this.BtnExit.Cursor = System.Windows.Forms.Cursors.Hand;
            this.BtnExit.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnExit.ForeColor = System.Drawing.Color.Black;
            this.BtnExit.Image = global::Evolution.Properties.Resources.salir;
            this.BtnExit.ImageAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            this.BtnExit.Location = new System.Drawing.Point(681, 463);
            this.BtnExit.Name = "BtnExit";
            this.BtnExit.Size = new System.Drawing.Size(102, 28);
            this.BtnExit.TabIndex = 68;
            this.BtnExit.Text = "Exit";
            this.BtnExit.TextAlignment = System.Drawing.ContentAlignment.MiddleLeft;
            this.BtnExit.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.BtnExit.ThemeName = "Aqua";
            this.BtnExit.Click += new System.EventHandler(this.BtnExit_Click);
            ((Telerik.WinControls.UI.RadButtonElement)(this.BtnExit.GetChildAt(0))).Image = global::Evolution.Properties.Resources.salir;
            ((Telerik.WinControls.UI.RadButtonElement)(this.BtnExit.GetChildAt(0))).TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            ((Telerik.WinControls.UI.RadButtonElement)(this.BtnExit.GetChildAt(0))).ImageAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            ((Telerik.WinControls.UI.RadButtonElement)(this.BtnExit.GetChildAt(0))).TextAlignment = System.Drawing.ContentAlignment.MiddleLeft;
            ((Telerik.WinControls.UI.RadButtonElement)(this.BtnExit.GetChildAt(0))).Text = "Exit";
            ((Telerik.WinControls.Primitives.FillPrimitive)(this.BtnExit.GetChildAt(0).GetChildAt(0))).BackColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(232)))), ((int)(((byte)(241)))), ((int)(((byte)(252)))));
            ((Telerik.WinControls.Primitives.FillPrimitive)(this.BtnExit.GetChildAt(0).GetChildAt(0))).BackColor3 = System.Drawing.Color.FromArgb(((int)(((byte)(232)))), ((int)(((byte)(241)))), ((int)(((byte)(252)))));
            ((Telerik.WinControls.Primitives.FillPrimitive)(this.BtnExit.GetChildAt(0).GetChildAt(0))).BackColor4 = System.Drawing.Color.FromArgb(((int)(((byte)(232)))), ((int)(((byte)(241)))), ((int)(((byte)(252)))));
            ((Telerik.WinControls.Primitives.FillPrimitive)(this.BtnExit.GetChildAt(0).GetChildAt(0))).BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(232)))), ((int)(((byte)(241)))), ((int)(((byte)(252)))));
            ((Telerik.WinControls.Primitives.ImagePrimitive)(this.BtnExit.GetChildAt(0).GetChildAt(1).GetChildAt(0))).ImageScaling = Telerik.WinControls.Enumerations.ImageScaling.SizeToFit;
            // 
            // txtTotalPaid
            // 
            this.txtTotalPaid.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.txtTotalPaid.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtTotalPaid.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.txtTotalPaid.Location = new System.Drawing.Point(47, 462);
            this.txtTotalPaid.Name = "txtTotalPaid";
            this.txtTotalPaid.ReadOnly = true;
            // 
            // 
            // 
            this.txtTotalPaid.RootElement.ControlBounds = new System.Drawing.Rectangle(47, 462, 100, 20);
            this.txtTotalPaid.RootElement.StretchVertically = true;
            this.txtTotalPaid.Size = new System.Drawing.Size(136, 28);
            this.txtTotalPaid.TabIndex = 67;
            this.txtTotalPaid.Text = "0.00";
            this.txtTotalPaid.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtTotalPaid.ThemeName = "Breeze";
            // 
            // radLabel3
            // 
            this.radLabel3.BackColor = System.Drawing.Color.Transparent;
            this.radLabel3.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.radLabel3.Location = new System.Drawing.Point(5, 465);
            this.radLabel3.Name = "radLabel3";
            // 
            // 
            // 
            this.radLabel3.RootElement.ControlBounds = new System.Drawing.Rectangle(5, 465, 100, 18);
            this.radLabel3.Size = new System.Drawing.Size(36, 21);
            this.radLabel3.TabIndex = 66;
            this.radLabel3.Text = "Total";
            // 
            // grdPayments
            // 
            this.grdPayments.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(237)))), ((int)(((byte)(246)))), ((int)(((byte)(194)))));
            this.grdPayments.Cursor = System.Windows.Forms.Cursors.Default;
            this.grdPayments.Font = new System.Drawing.Font("Segoe UI", 9.75F);
            this.grdPayments.ForeColor = System.Drawing.SystemColors.ControlText;
            this.grdPayments.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.grdPayments.Location = new System.Drawing.Point(5, 21);
            // 
            // 
            // 
            this.grdPayments.MasterTemplate.AllowAddNewRow = false;
            this.grdPayments.MasterTemplate.AllowColumnReorder = false;
            this.grdPayments.MasterTemplate.AllowDragToGroup = false;
            this.grdPayments.MasterTemplate.AutoGenerateColumns = false;
            gridViewTextBoxColumn1.EnableExpressionEditor = false;
            gridViewTextBoxColumn1.FieldName = "amount";
            gridViewTextBoxColumn1.FormatString = "{0:n2}";
            gridViewTextBoxColumn1.HeaderText = "Amount";
            gridViewTextBoxColumn1.Name = "amount";
            gridViewTextBoxColumn1.ReadOnly = true;
            gridViewTextBoxColumn1.TextAlignment = System.Drawing.ContentAlignment.MiddleRight;
            gridViewTextBoxColumn1.Width = 150;
            gridViewTextBoxColumn2.EnableExpressionEditor = false;
            gridViewTextBoxColumn2.FieldName = "EffectiveDate";
            gridViewTextBoxColumn2.FormatString = "{0:MMM-dd-yyyy}";
            gridViewTextBoxColumn2.HeaderText = "Effective Date";
            gridViewTextBoxColumn2.Name = "EffectiveDate";
            gridViewTextBoxColumn2.ReadOnly = true;
            gridViewTextBoxColumn2.Width = 150;
            gridViewTextBoxColumn3.FieldName = "CreationDate";
            gridViewTextBoxColumn3.HeaderText = "Creation Date";
            gridViewTextBoxColumn3.Name = "CreationDate";
            gridViewTextBoxColumn3.Width = 150;
            gridViewTextBoxColumn4.FieldName = "ProcessNo";
            gridViewTextBoxColumn4.HeaderText = "Process No";
            gridViewTextBoxColumn4.Name = "ProcessNo";
            gridViewTextBoxColumn4.Width = 150;
            gridViewTextBoxColumn5.FieldName = "UserName";
            gridViewTextBoxColumn5.HeaderText = "User Name";
            gridViewTextBoxColumn5.Name = "UserName";
            gridViewTextBoxColumn5.Width = 150;
            this.grdPayments.MasterTemplate.Columns.AddRange(new Telerik.WinControls.UI.GridViewDataColumn[] {
            gridViewTextBoxColumn1,
            gridViewTextBoxColumn2,
            gridViewTextBoxColumn3,
            gridViewTextBoxColumn4,
            gridViewTextBoxColumn5});
            this.grdPayments.MasterTemplate.ShowGroupedColumns = true;
            this.grdPayments.MasterTemplate.ViewDefinition = tableViewDefinition1;
            this.grdPayments.Name = "grdPayments";
            this.grdPayments.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.grdPayments.ShowGroupPanel = false;
            this.grdPayments.Size = new System.Drawing.Size(779, 435);
            this.grdPayments.TabIndex = 65;
            this.grdPayments.ThemeName = "Breeze";
            // 
            // btnCancel
            // 
            this.btnCancel.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnCancel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCancel.ForeColor = System.Drawing.Color.Black;
            this.btnCancel.Image = global::Evolution.Properties.Resources.remove;
            this.btnCancel.ImageAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            this.btnCancel.Location = new System.Drawing.Point(578, 463);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(97, 28);
            this.btnCancel.TabIndex = 25;
            this.btnCancel.Tag = "464";
            this.btnCancel.Text = "Cancel";
            this.btnCancel.TextAlignment = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnCancel.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnCancel.ThemeName = "Aqua";
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            ((Telerik.WinControls.UI.RadButtonElement)(this.btnCancel.GetChildAt(0))).Image = global::Evolution.Properties.Resources.remove;
            ((Telerik.WinControls.UI.RadButtonElement)(this.btnCancel.GetChildAt(0))).TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            ((Telerik.WinControls.UI.RadButtonElement)(this.btnCancel.GetChildAt(0))).ImageAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            ((Telerik.WinControls.UI.RadButtonElement)(this.btnCancel.GetChildAt(0))).TextAlignment = System.Drawing.ContentAlignment.MiddleLeft;
            ((Telerik.WinControls.UI.RadButtonElement)(this.btnCancel.GetChildAt(0))).Text = "Cancel";
            ((Telerik.WinControls.Primitives.FillPrimitive)(this.btnCancel.GetChildAt(0).GetChildAt(0))).BackColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(232)))), ((int)(((byte)(241)))), ((int)(((byte)(252)))));
            ((Telerik.WinControls.Primitives.FillPrimitive)(this.btnCancel.GetChildAt(0).GetChildAt(0))).BackColor3 = System.Drawing.Color.FromArgb(((int)(((byte)(232)))), ((int)(((byte)(241)))), ((int)(((byte)(252)))));
            ((Telerik.WinControls.Primitives.FillPrimitive)(this.btnCancel.GetChildAt(0).GetChildAt(0))).BackColor4 = System.Drawing.Color.FromArgb(((int)(((byte)(232)))), ((int)(((byte)(241)))), ((int)(((byte)(252)))));
            ((Telerik.WinControls.Primitives.FillPrimitive)(this.btnCancel.GetChildAt(0).GetChildAt(0))).BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(232)))), ((int)(((byte)(241)))), ((int)(((byte)(252)))));
            ((Telerik.WinControls.Primitives.ImagePrimitive)(this.btnCancel.GetChildAt(0).GetChildAt(1).GetChildAt(0))).ImageScaling = Telerik.WinControls.Enumerations.ImageScaling.SizeToFit;
            // 
            // bgwSearch
            // 
            this.bgwSearch.DoWork += new System.ComponentModel.DoWorkEventHandler(this.bgwSearch_DoWork);
            this.bgwSearch.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.bgwSearch_RunWorkerCompleted);
            // 
            // RealStateProcessHistory
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(242)))), ((int)(((byte)(250)))), ((int)(((byte)(255)))));
            this.ClientSize = new System.Drawing.Size(798, 501);
            this.Controls.Add(this.radGroupBox5);
            this.DoubleBuffered = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "RealStateProcessHistory";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Process History";
            this.Load += new System.EventHandler(this.RealStateProcessHistory_Load);
            this.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.RealStateProcessHistory_KeyPress);
            ((System.ComponentModel.ISupportInitialize)(this.radGroupBox5)).EndInit();
            this.radGroupBox5.ResumeLayout(false);
            this.radGroupBox5.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.BtnExit)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtTotalPaid)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdPayments.MasterTemplate)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdPayments)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnCancel)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Telerik.WinControls.UI.RadGroupBox radGroupBox5;
        private Telerik.WinControls.UI.RadButton BtnExit;
        private Telerik.WinControls.UI.RadTextBox txtTotalPaid;
        private Telerik.WinControls.UI.RadLabel radLabel3;
        private Telerik.WinControls.UI.RadGridView grdPayments;
        private Telerik.WinControls.UI.RadButton btnCancel;
        private Telerik.WinControls.Themes.BreezeTheme breezeTheme1;
        private System.ComponentModel.BackgroundWorker bgwSearch;
    }
}