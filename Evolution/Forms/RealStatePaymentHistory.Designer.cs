namespace Evolution.Forms
{
    partial class RealStatePaymentHistory
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
            Telerik.WinControls.UI.GridViewTextBoxColumn gridViewTextBoxColumn8 = new Telerik.WinControls.UI.GridViewTextBoxColumn();
            Telerik.WinControls.UI.GridViewTextBoxColumn gridViewTextBoxColumn9 = new Telerik.WinControls.UI.GridViewTextBoxColumn();
            Telerik.WinControls.UI.TableViewDefinition tableViewDefinition2 = new Telerik.WinControls.UI.TableViewDefinition();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(RealStatePaymentHistory));
            this.breezeTheme1 = new Telerik.WinControls.Themes.BreezeTheme();
            this.bgwSearch = new System.ComponentModel.BackgroundWorker();
            this.radGroupBox5 = new Telerik.WinControls.UI.RadGroupBox();
            this.BtnExit = new Telerik.WinControls.UI.RadButton();
            this.txtTotalPaid = new Telerik.WinControls.UI.RadTextBox();
            this.radLabel3 = new Telerik.WinControls.UI.RadLabel();
            this.grdPayments = new Telerik.WinControls.UI.RadGridView();
            this.btnInactive = new Telerik.WinControls.UI.RadButton();
            this.radGroupBox1 = new Telerik.WinControls.UI.RadGroupBox();
            this.txtTotalFeeGenerated = new Telerik.WinControls.UI.RadTextBox();
            this.radLabel5 = new Telerik.WinControls.UI.RadLabel();
            this.grdFee = new Telerik.WinControls.UI.RadGridView();
            this.lblOwner = new Telerik.WinControls.UI.RadLabel();
            ((System.ComponentModel.ISupportInitialize)(this.radGroupBox5)).BeginInit();
            this.radGroupBox5.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.BtnExit)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtTotalPaid)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdPayments)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdPayments.MasterTemplate)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnInactive)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radGroupBox1)).BeginInit();
            this.radGroupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtTotalFeeGenerated)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel5)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdFee)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdFee.MasterTemplate)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblOwner)).BeginInit();
            this.SuspendLayout();
            // 
            // bgwSearch
            // 
            this.bgwSearch.DoWork += new System.ComponentModel.DoWorkEventHandler(this.bgwSearch_DoWork);
            this.bgwSearch.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.bgwSearch_RunWorkerCompleted);
            // 
            // radGroupBox5
            // 
            this.radGroupBox5.AccessibleRole = System.Windows.Forms.AccessibleRole.Grouping;
            this.radGroupBox5.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(242)))), ((int)(((byte)(250)))), ((int)(((byte)(255)))));
            this.radGroupBox5.Controls.Add(this.BtnExit);
            this.radGroupBox5.Controls.Add(this.txtTotalPaid);
            this.radGroupBox5.Controls.Add(this.radLabel3);
            this.radGroupBox5.Controls.Add(this.grdPayments);
            this.radGroupBox5.Controls.Add(this.btnInactive);
            this.radGroupBox5.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.radGroupBox5.GroupBoxStyle = Telerik.WinControls.UI.RadGroupBoxStyle.Office;
            this.radGroupBox5.HeaderAlignment = Telerik.WinControls.UI.HeaderAlignment.Center;
            this.radGroupBox5.HeaderText = "Payments Processed";
            this.radGroupBox5.Location = new System.Drawing.Point(309, 25);
            this.radGroupBox5.Name = "radGroupBox5";
            // 
            // 
            // 
            this.radGroupBox5.RootElement.ControlBounds = new System.Drawing.Rectangle(309, 25, 200, 100);
            this.radGroupBox5.Size = new System.Drawing.Size(603, 386);
            this.radGroupBox5.TabIndex = 65;
            this.radGroupBox5.Text = "Payments Processed";
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
            this.BtnExit.Location = new System.Drawing.Point(496, 352);
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
            this.txtTotalPaid.Location = new System.Drawing.Point(47, 353);
            this.txtTotalPaid.Name = "txtTotalPaid";
            this.txtTotalPaid.ReadOnly = true;
            // 
            // 
            // 
            this.txtTotalPaid.RootElement.ControlBounds = new System.Drawing.Rectangle(47, 353, 100, 20);
            this.txtTotalPaid.RootElement.StretchVertically = true;
            this.txtTotalPaid.Size = new System.Drawing.Size(110, 28);
            this.txtTotalPaid.TabIndex = 67;
            this.txtTotalPaid.Text = "0.00";
            this.txtTotalPaid.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtTotalPaid.ThemeName = "Breeze";
            // 
            // radLabel3
            // 
            this.radLabel3.BackColor = System.Drawing.Color.Transparent;
            this.radLabel3.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.radLabel3.Location = new System.Drawing.Point(5, 354);
            this.radLabel3.Name = "radLabel3";
            // 
            // 
            // 
            this.radLabel3.RootElement.ControlBounds = new System.Drawing.Rectangle(5, 354, 100, 18);
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
            gridViewTextBoxColumn1.FieldName = "RealStatePaymentHistoryID";
            gridViewTextBoxColumn1.HeaderText = "RealStatePaymentHistoryID";
            gridViewTextBoxColumn1.IsVisible = false;
            gridViewTextBoxColumn1.Name = "RealStatePaymentHistoryID";
            gridViewTextBoxColumn1.Width = 100;
            gridViewTextBoxColumn2.EnableExpressionEditor = false;
            gridViewTextBoxColumn2.FieldName = "amount";
            gridViewTextBoxColumn2.FormatString = "{0:n2}";
            gridViewTextBoxColumn2.HeaderText = "Amount";
            gridViewTextBoxColumn2.Name = "amount";
            gridViewTextBoxColumn2.ReadOnly = true;
            gridViewTextBoxColumn2.TextAlignment = System.Drawing.ContentAlignment.MiddleRight;
            gridViewTextBoxColumn2.Width = 100;
            gridViewTextBoxColumn3.EnableExpressionEditor = false;
            gridViewTextBoxColumn3.FieldName = "EffectiveDate";
            gridViewTextBoxColumn3.FormatString = "{0:MMM-dd-yyyy}";
            gridViewTextBoxColumn3.HeaderText = "Effective Date";
            gridViewTextBoxColumn3.Name = "EffectiveDate";
            gridViewTextBoxColumn3.ReadOnly = true;
            gridViewTextBoxColumn3.Width = 150;
            gridViewTextBoxColumn4.FieldName = "CreationDate";
            gridViewTextBoxColumn4.HeaderText = "Creation Date";
            gridViewTextBoxColumn4.Name = "CreationDate";
            gridViewTextBoxColumn4.Width = 150;
            gridViewTextBoxColumn5.FieldName = "ProcessNo";
            gridViewTextBoxColumn5.HeaderText = "Process No";
            gridViewTextBoxColumn5.Name = "ProcessNo";
            gridViewTextBoxColumn5.Width = 150;
            gridViewTextBoxColumn6.FieldName = "UserName";
            gridViewTextBoxColumn6.HeaderText = "User Name";
            gridViewTextBoxColumn6.Name = "UserName";
            gridViewTextBoxColumn6.Width = 150;
            gridViewTextBoxColumn7.FieldName = "Reference";
            gridViewTextBoxColumn7.HeaderText = "Reference";
            gridViewTextBoxColumn7.Name = "Reference";
            gridViewTextBoxColumn7.Width = 150;
            this.grdPayments.MasterTemplate.Columns.AddRange(new Telerik.WinControls.UI.GridViewDataColumn[] {
            gridViewTextBoxColumn1,
            gridViewTextBoxColumn2,
            gridViewTextBoxColumn3,
            gridViewTextBoxColumn4,
            gridViewTextBoxColumn5,
            gridViewTextBoxColumn6,
            gridViewTextBoxColumn7});
            this.grdPayments.MasterTemplate.ShowGroupedColumns = true;
            this.grdPayments.MasterTemplate.ViewDefinition = tableViewDefinition1;
            this.grdPayments.Name = "grdPayments";
            this.grdPayments.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.grdPayments.ShowGroupPanel = false;
            this.grdPayments.Size = new System.Drawing.Size(593, 325);
            this.grdPayments.TabIndex = 65;
            this.grdPayments.ThemeName = "Breeze";
            // 
            // btnInactive
            // 
            this.btnInactive.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnInactive.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnInactive.ForeColor = System.Drawing.Color.Black;
            this.btnInactive.Image = global::Evolution.Properties.Resources.remove;
            this.btnInactive.ImageAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            this.btnInactive.Location = new System.Drawing.Point(393, 352);
            this.btnInactive.Name = "btnInactive";
            this.btnInactive.Size = new System.Drawing.Size(97, 28);
            this.btnInactive.TabIndex = 25;
            this.btnInactive.Tag = "463";
            this.btnInactive.Text = "Inactive";
            this.btnInactive.TextAlignment = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnInactive.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnInactive.ThemeName = "Aqua";
            this.btnInactive.Click += new System.EventHandler(this.btnInactive_Click);
            ((Telerik.WinControls.UI.RadButtonElement)(this.btnInactive.GetChildAt(0))).Image = global::Evolution.Properties.Resources.remove;
            ((Telerik.WinControls.UI.RadButtonElement)(this.btnInactive.GetChildAt(0))).TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            ((Telerik.WinControls.UI.RadButtonElement)(this.btnInactive.GetChildAt(0))).ImageAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            ((Telerik.WinControls.UI.RadButtonElement)(this.btnInactive.GetChildAt(0))).TextAlignment = System.Drawing.ContentAlignment.MiddleLeft;
            ((Telerik.WinControls.UI.RadButtonElement)(this.btnInactive.GetChildAt(0))).Text = "Inactive";
            ((Telerik.WinControls.Primitives.FillPrimitive)(this.btnInactive.GetChildAt(0).GetChildAt(0))).BackColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(232)))), ((int)(((byte)(241)))), ((int)(((byte)(252)))));
            ((Telerik.WinControls.Primitives.FillPrimitive)(this.btnInactive.GetChildAt(0).GetChildAt(0))).BackColor3 = System.Drawing.Color.FromArgb(((int)(((byte)(232)))), ((int)(((byte)(241)))), ((int)(((byte)(252)))));
            ((Telerik.WinControls.Primitives.FillPrimitive)(this.btnInactive.GetChildAt(0).GetChildAt(0))).BackColor4 = System.Drawing.Color.FromArgb(((int)(((byte)(232)))), ((int)(((byte)(241)))), ((int)(((byte)(252)))));
            ((Telerik.WinControls.Primitives.FillPrimitive)(this.btnInactive.GetChildAt(0).GetChildAt(0))).BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(232)))), ((int)(((byte)(241)))), ((int)(((byte)(252)))));
            ((Telerik.WinControls.Primitives.ImagePrimitive)(this.btnInactive.GetChildAt(0).GetChildAt(1).GetChildAt(0))).ImageScaling = Telerik.WinControls.Enumerations.ImageScaling.SizeToFit;
            // 
            // radGroupBox1
            // 
            this.radGroupBox1.AccessibleRole = System.Windows.Forms.AccessibleRole.Grouping;
            this.radGroupBox1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(242)))), ((int)(((byte)(250)))), ((int)(((byte)(255)))));
            this.radGroupBox1.Controls.Add(this.txtTotalFeeGenerated);
            this.radGroupBox1.Controls.Add(this.radLabel5);
            this.radGroupBox1.Controls.Add(this.grdFee);
            this.radGroupBox1.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.radGroupBox1.GroupBoxStyle = Telerik.WinControls.UI.RadGroupBoxStyle.Office;
            this.radGroupBox1.HeaderAlignment = Telerik.WinControls.UI.HeaderAlignment.Center;
            this.radGroupBox1.HeaderText = "Fee Generation ";
            this.radGroupBox1.Location = new System.Drawing.Point(3, 25);
            this.radGroupBox1.Name = "radGroupBox1";
            // 
            // 
            // 
            this.radGroupBox1.RootElement.ControlBounds = new System.Drawing.Rectangle(3, 25, 200, 100);
            this.radGroupBox1.Size = new System.Drawing.Size(300, 386);
            this.radGroupBox1.TabIndex = 66;
            this.radGroupBox1.Text = "Fee Generation ";
            ((Telerik.WinControls.UI.RadGroupBoxElement)(this.radGroupBox1.GetChildAt(0))).HeaderAlignment = Telerik.WinControls.UI.HeaderAlignment.Center;
            ((Telerik.WinControls.UI.GroupBoxHeader)(this.radGroupBox1.GetChildAt(0).GetChildAt(1))).GroupBoxStyle = Telerik.WinControls.UI.RadGroupBoxStyle.Office;
            ((Telerik.WinControls.Primitives.FillPrimitive)(this.radGroupBox1.GetChildAt(0).GetChildAt(1).GetChildAt(0))).BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(228)))), ((int)(((byte)(238)))), ((int)(((byte)(250)))));
            ((Telerik.WinControls.Primitives.FillPrimitive)(this.radGroupBox1.GetChildAt(0).GetChildAt(1).GetChildAt(0))).SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.None;
            // 
            // txtTotalFeeGenerated
            // 
            this.txtTotalFeeGenerated.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.txtTotalFeeGenerated.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtTotalFeeGenerated.ForeColor = System.Drawing.Color.DarkBlue;
            this.txtTotalFeeGenerated.Location = new System.Drawing.Point(47, 353);
            this.txtTotalFeeGenerated.Name = "txtTotalFeeGenerated";
            this.txtTotalFeeGenerated.ReadOnly = true;
            // 
            // 
            // 
            this.txtTotalFeeGenerated.RootElement.ControlBounds = new System.Drawing.Rectangle(47, 353, 100, 20);
            this.txtTotalFeeGenerated.RootElement.StretchVertically = true;
            this.txtTotalFeeGenerated.Size = new System.Drawing.Size(110, 28);
            this.txtTotalFeeGenerated.TabIndex = 67;
            this.txtTotalFeeGenerated.Text = "0.00";
            this.txtTotalFeeGenerated.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtTotalFeeGenerated.ThemeName = "Breeze";
            // 
            // radLabel5
            // 
            this.radLabel5.BackColor = System.Drawing.Color.Transparent;
            this.radLabel5.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.radLabel5.Location = new System.Drawing.Point(5, 354);
            this.radLabel5.Name = "radLabel5";
            // 
            // 
            // 
            this.radLabel5.RootElement.ControlBounds = new System.Drawing.Rectangle(5, 354, 100, 18);
            this.radLabel5.Size = new System.Drawing.Size(36, 21);
            this.radLabel5.TabIndex = 66;
            this.radLabel5.Text = "Total";
            // 
            // grdFee
            // 
            this.grdFee.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(237)))), ((int)(((byte)(246)))), ((int)(((byte)(194)))));
            this.grdFee.Cursor = System.Windows.Forms.Cursors.Default;
            this.grdFee.Font = new System.Drawing.Font("Segoe UI", 9.75F);
            this.grdFee.ForeColor = System.Drawing.SystemColors.ControlText;
            this.grdFee.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.grdFee.Location = new System.Drawing.Point(5, 21);
            // 
            // 
            // 
            this.grdFee.MasterTemplate.AllowAddNewRow = false;
            this.grdFee.MasterTemplate.AllowColumnReorder = false;
            this.grdFee.MasterTemplate.AllowDragToGroup = false;
            this.grdFee.MasterTemplate.AutoGenerateColumns = false;
            gridViewTextBoxColumn8.EnableExpressionEditor = false;
            gridViewTextBoxColumn8.FieldName = "amount";
            gridViewTextBoxColumn8.FormatString = "{0:n2}";
            gridViewTextBoxColumn8.HeaderText = "Amount";
            gridViewTextBoxColumn8.Name = "amount";
            gridViewTextBoxColumn8.ReadOnly = true;
            gridViewTextBoxColumn8.TextAlignment = System.Drawing.ContentAlignment.MiddleRight;
            gridViewTextBoxColumn8.Width = 100;
            gridViewTextBoxColumn9.EnableExpressionEditor = false;
            gridViewTextBoxColumn9.FieldName = "Generationdate";
            gridViewTextBoxColumn9.FormatString = "{0:MMM-dd-yyyy}";
            gridViewTextBoxColumn9.HeaderText = "Generation Date";
            gridViewTextBoxColumn9.Name = "Generationdate";
            gridViewTextBoxColumn9.ReadOnly = true;
            gridViewTextBoxColumn9.Width = 150;
            this.grdFee.MasterTemplate.Columns.AddRange(new Telerik.WinControls.UI.GridViewDataColumn[] {
            gridViewTextBoxColumn8,
            gridViewTextBoxColumn9});
            this.grdFee.MasterTemplate.ShowGroupedColumns = true;
            this.grdFee.MasterTemplate.ViewDefinition = tableViewDefinition2;
            this.grdFee.Name = "grdFee";
            this.grdFee.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.grdFee.ShowGroupPanel = false;
            this.grdFee.Size = new System.Drawing.Size(287, 326);
            this.grdFee.TabIndex = 65;
            this.grdFee.ThemeName = "Breeze";
            // 
            // lblOwner
            // 
            this.lblOwner.AutoSize = false;
            this.lblOwner.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.lblOwner.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblOwner.Location = new System.Drawing.Point(3, -2);
            this.lblOwner.Name = "lblOwner";
            // 
            // 
            // 
            this.lblOwner.RootElement.ControlBounds = new System.Drawing.Rectangle(3, -2, 100, 18);
            this.lblOwner.Size = new System.Drawing.Size(907, 21);
            this.lblOwner.TabIndex = 67;
            this.lblOwner.Text = "Total";
            this.lblOwner.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // RealStatePaymentHistory
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(242)))), ((int)(((byte)(250)))), ((int)(((byte)(255)))));
            this.ClientSize = new System.Drawing.Size(915, 416);
            this.Controls.Add(this.lblOwner);
            this.Controls.Add(this.radGroupBox1);
            this.Controls.Add(this.radGroupBox5);
            this.DoubleBuffered = true;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "RealStatePaymentHistory";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Payment & Fee Generation History";
            this.Load += new System.EventHandler(this.RealStatePaymentHistory_Load);
            this.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.RealStatePaymentHistory_KeyPress);
            ((System.ComponentModel.ISupportInitialize)(this.radGroupBox5)).EndInit();
            this.radGroupBox5.ResumeLayout(false);
            this.radGroupBox5.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.BtnExit)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtTotalPaid)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdPayments.MasterTemplate)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdPayments)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnInactive)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radGroupBox1)).EndInit();
            this.radGroupBox1.ResumeLayout(false);
            this.radGroupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtTotalFeeGenerated)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel5)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdFee.MasterTemplate)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdFee)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblOwner)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private Telerik.WinControls.Themes.BreezeTheme breezeTheme1;
        private System.ComponentModel.BackgroundWorker bgwSearch;
        private Telerik.WinControls.UI.RadGroupBox radGroupBox5;
        private Telerik.WinControls.UI.RadGridView grdPayments;
        private Telerik.WinControls.UI.RadButton btnInactive;
        private Telerik.WinControls.UI.RadGroupBox radGroupBox1;
        private Telerik.WinControls.UI.RadGridView grdFee;
        private Telerik.WinControls.UI.RadTextBox txtTotalFeeGenerated;
        private Telerik.WinControls.UI.RadLabel radLabel5;
        private Telerik.WinControls.UI.RadButton BtnExit;
        private Telerik.WinControls.UI.RadTextBox txtTotalPaid;
        private Telerik.WinControls.UI.RadLabel radLabel3;
        private Telerik.WinControls.UI.RadLabel lblOwner;
    }
}