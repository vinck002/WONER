
namespace Evolution.Forms
{
    partial class OwnerComisionExpiredDay
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
            Telerik.WinControls.Data.SortDescriptor sortDescriptor1 = new Telerik.WinControls.Data.SortDescriptor();
            Telerik.WinControls.UI.TableViewDefinition tableViewDefinition1 = new Telerik.WinControls.UI.TableViewDefinition();
            this.rdNextToRequest = new Telerik.WinControls.UI.RadRadioButton();
            this.rdExpired = new Telerik.WinControls.UI.RadRadioButton();
            this.bPrint = new Telerik.WinControls.UI.RadButton();
            this.bExit = new Telerik.WinControls.UI.RadButton();
            this.CbMonth = new Telerik.WinControls.UI.RadDropDownList();
            this.radLabel1 = new Telerik.WinControls.UI.RadLabel();
            this.btnSearch = new Telerik.WinControls.UI.RadButton();
            this.bExport = new Telerik.WinControls.UI.RadButton();
            this.ContractList = new Telerik.WinControls.UI.RadGridView();
            this.rbExpired = new Telerik.WinControls.UI.RadGroupBox();
            this.PropertyID = new Telerik.WinControls.UI.RadTextBox();
            this.Btnclear = new Telerik.WinControls.UI.RadButton();
            this.Foundrecords = new Telerik.WinControls.UI.RadLabel();
            this.radLabel8 = new Telerik.WinControls.UI.RadLabel();
            this.radPanel1 = new Telerik.WinControls.UI.RadPanel();
            this.radPanel2 = new Telerik.WinControls.UI.RadPanel();
            ((System.ComponentModel.ISupportInitialize)(this.rdNextToRequest)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rdExpired)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bPrint)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bExit)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.CbMonth)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnSearch)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bExport)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ContractList)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ContractList.MasterTemplate)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rbExpired)).BeginInit();
            this.rbExpired.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.PropertyID)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Btnclear)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Foundrecords)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel8)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radPanel1)).BeginInit();
            this.radPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.radPanel2)).BeginInit();
            this.radPanel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // rdNextToRequest
            // 
            this.rdNextToRequest.Location = new System.Drawing.Point(337, 12);
            this.rdNextToRequest.Name = "rdNextToRequest";
            this.rdNextToRequest.Size = new System.Drawing.Size(103, 18);
            this.rdNextToRequest.TabIndex = 87;
            this.rdNextToRequest.TabStop = false;
            this.rdNextToRequest.Text = "Next To Request";
            this.rdNextToRequest.CheckStateChanged += new System.EventHandler(this.rdNextToRequest_CheckStateChanged);
            // 
            // rdExpired
            // 
            this.rdExpired.CheckState = System.Windows.Forms.CheckState.Checked;
            this.rdExpired.Location = new System.Drawing.Point(278, 12);
            this.rdExpired.Name = "rdExpired";
            this.rdExpired.Size = new System.Drawing.Size(57, 18);
            this.rdExpired.TabIndex = 86;
            this.rdExpired.Text = "Expired";
            this.rdExpired.ToggleState = Telerik.WinControls.Enumerations.ToggleState.On;
            // 
            // bPrint
            // 
            this.bPrint.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.bPrint.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bPrint.ForeColor = System.Drawing.Color.Black;
            this.bPrint.Image = global::Evolution.Properties.Resources.printer_green;
            this.bPrint.ImageAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            this.bPrint.Location = new System.Drawing.Point(526, 6);
            this.bPrint.Name = "bPrint";
            this.bPrint.Size = new System.Drawing.Size(90, 30);
            this.bPrint.TabIndex = 33;
            this.bPrint.Text = "Print";
            this.bPrint.TextAlignment = System.Drawing.ContentAlignment.MiddleLeft;
            this.bPrint.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.bPrint.Click += new System.EventHandler(this.bPrint_Click);
            ((Telerik.WinControls.UI.RadButtonElement)(this.bPrint.GetChildAt(0))).Image = global::Evolution.Properties.Resources.printer_green;
            ((Telerik.WinControls.UI.RadButtonElement)(this.bPrint.GetChildAt(0))).TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            ((Telerik.WinControls.UI.RadButtonElement)(this.bPrint.GetChildAt(0))).ImageAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            ((Telerik.WinControls.UI.RadButtonElement)(this.bPrint.GetChildAt(0))).TextAlignment = System.Drawing.ContentAlignment.MiddleLeft;
            ((Telerik.WinControls.UI.RadButtonElement)(this.bPrint.GetChildAt(0))).Text = "Print";
            ((Telerik.WinControls.Primitives.ImagePrimitive)(this.bPrint.GetChildAt(0).GetChildAt(1).GetChildAt(0))).ImageScaling = Telerik.WinControls.Enumerations.ImageScaling.SizeToFit;
            // 
            // bExit
            // 
            this.bExit.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.bExit.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bExit.ForeColor = System.Drawing.Color.Black;
            this.bExit.Image = global::Evolution.Properties.Resources.salir;
            this.bExit.ImageAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            this.bExit.Location = new System.Drawing.Point(622, 6);
            this.bExit.Name = "bExit";
            this.bExit.Size = new System.Drawing.Size(90, 30);
            this.bExit.TabIndex = 32;
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
            // CbMonth
            // 
            this.CbMonth.AutoSize = false;
            this.CbMonth.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.CbMonth.DropDownAnimationEnabled = true;
            this.CbMonth.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CbMonth.Location = new System.Drawing.Point(125, 5);
            this.CbMonth.Name = "CbMonth";
            this.CbMonth.Size = new System.Drawing.Size(137, 32);
            this.CbMonth.TabIndex = 91;
            this.CbMonth.Tag = "0";
            this.CbMonth.ThemeName = "Breeze";
            // 
            // radLabel1
            // 
            this.radLabel1.Location = new System.Drawing.Point(44, 12);
            this.radLabel1.Name = "radLabel1";
            this.radLabel1.Size = new System.Drawing.Size(75, 18);
            this.radLabel1.TabIndex = 92;
            this.radLabel1.Text = "Target Month";
            // 
            // btnSearch
            // 
            this.btnSearch.AutoScroll = true;
            this.btnSearch.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSearch.ForeColor = System.Drawing.Color.Black;
            this.btnSearch.Image = global::Evolution.Properties.Resources.find;
            this.btnSearch.ImageAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            this.btnSearch.Location = new System.Drawing.Point(446, 6);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(70, 32);
            this.btnSearch.TabIndex = 4;
            this.btnSearch.Text = "Search";
            this.btnSearch.TextAlignment = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnSearch.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            ((Telerik.WinControls.UI.RadButtonElement)(this.btnSearch.GetChildAt(0))).Image = global::Evolution.Properties.Resources.find;
            ((Telerik.WinControls.UI.RadButtonElement)(this.btnSearch.GetChildAt(0))).TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            ((Telerik.WinControls.UI.RadButtonElement)(this.btnSearch.GetChildAt(0))).ImageAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            ((Telerik.WinControls.UI.RadButtonElement)(this.btnSearch.GetChildAt(0))).TextAlignment = System.Drawing.ContentAlignment.MiddleLeft;
            ((Telerik.WinControls.UI.RadButtonElement)(this.btnSearch.GetChildAt(0))).Text = "Search";
            ((Telerik.WinControls.Primitives.ImagePrimitive)(this.btnSearch.GetChildAt(0).GetChildAt(1).GetChildAt(0))).ImageScaling = Telerik.WinControls.Enumerations.ImageScaling.SizeToFit;
            // 
            // bExport
            // 
            this.bExport.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.bExport.Cursor = System.Windows.Forms.Cursors.Hand;
            this.bExport.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bExport.ForeColor = System.Drawing.Color.Black;
            this.bExport.Image = global::Evolution.Properties.Resources.excel;
            this.bExport.ImageAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            this.bExport.Location = new System.Drawing.Point(430, 7);
            this.bExport.Name = "bExport";
            this.bExport.Size = new System.Drawing.Size(90, 30);
            this.bExport.TabIndex = 93;
            this.bExport.Tag = "446";
            this.bExport.Text = "Export Full";
            this.bExport.TextAlignment = System.Drawing.ContentAlignment.MiddleLeft;
            this.bExport.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.bExport.ThemeName = "ControlDefault";
            this.bExport.Click += new System.EventHandler(this.bExport_Click);
            ((Telerik.WinControls.UI.RadButtonElement)(this.bExport.GetChildAt(0))).Image = global::Evolution.Properties.Resources.excel;
            ((Telerik.WinControls.UI.RadButtonElement)(this.bExport.GetChildAt(0))).TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            ((Telerik.WinControls.UI.RadButtonElement)(this.bExport.GetChildAt(0))).ImageAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            ((Telerik.WinControls.UI.RadButtonElement)(this.bExport.GetChildAt(0))).TextAlignment = System.Drawing.ContentAlignment.MiddleLeft;
            ((Telerik.WinControls.UI.RadButtonElement)(this.bExport.GetChildAt(0))).Text = "Export Full";
            ((Telerik.WinControls.Primitives.ImagePrimitive)(this.bExport.GetChildAt(0).GetChildAt(1).GetChildAt(0))).ImageScaling = Telerik.WinControls.Enumerations.ImageScaling.SizeToFit;
            // 
            // ContractList
            // 
            this.ContractList.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(244)))), ((int)(((byte)(253)))), ((int)(((byte)(255)))));
            this.ContractList.Cursor = System.Windows.Forms.Cursors.Default;
            this.ContractList.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ContractList.Font = new System.Drawing.Font("Segoe UI", 9.75F);
            this.ContractList.ForeColor = System.Drawing.SystemColors.ControlText;
            this.ContractList.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.ContractList.Location = new System.Drawing.Point(0, 0);
            // 
            // 
            // 
            this.ContractList.MasterTemplate.AllowAddNewRow = false;
            this.ContractList.MasterTemplate.AllowCellContextMenu = false;
            this.ContractList.MasterTemplate.AllowColumnHeaderContextMenu = false;
            this.ContractList.MasterTemplate.AllowDeleteRow = false;
            this.ContractList.MasterTemplate.AllowRowHeaderContextMenu = false;
            this.ContractList.MasterTemplate.AutoGenerateColumns = false;
            this.ContractList.MasterTemplate.AutoSizeColumnsMode = Telerik.WinControls.UI.GridViewAutoSizeColumnsMode.Fill;
            gridViewTextBoxColumn1.EnableExpressionEditor = false;
            gridViewTextBoxColumn1.FieldName = "AgreementNumber";
            gridViewTextBoxColumn1.HeaderText = "Contract #";
            gridViewTextBoxColumn1.Name = "AgreementNumber";
            gridViewTextBoxColumn1.Width = 134;
            gridViewTextBoxColumn1.WrapText = true;
            gridViewTextBoxColumn2.EnableExpressionEditor = false;
            gridViewTextBoxColumn2.FieldName = "Us_Per_Week";
            gridViewTextBoxColumn2.HeaderText = "US$ Peer Week";
            gridViewTextBoxColumn2.Name = "Us_Per_Week";
            gridViewTextBoxColumn2.Width = 141;
            gridViewTextBoxColumn3.EnableExpressionEditor = false;
            gridViewTextBoxColumn3.FieldName = "Week_period_Year";
            gridViewTextBoxColumn3.HeaderText = "Week Period Year";
            gridViewTextBoxColumn3.Name = "Week_period_Year";
            gridViewTextBoxColumn3.Width = 215;
            gridViewTextBoxColumn4.EnableExpressionEditor = false;
            gridViewTextBoxColumn4.FieldName = "FourWeek";
            gridViewTextBoxColumn4.HeaderText = "4 Week";
            gridViewTextBoxColumn4.Name = "FourWeek";
            gridViewTextBoxColumn4.Width = 88;
            gridViewTextBoxColumn5.EnableExpressionEditor = false;
            gridViewTextBoxColumn5.FieldName = "ContractStatus";
            gridViewTextBoxColumn5.HeaderText = "Contrat Status";
            gridViewTextBoxColumn5.Name = "ContractStatus";
            gridViewTextBoxColumn5.Width = 123;
            this.ContractList.MasterTemplate.Columns.AddRange(new Telerik.WinControls.UI.GridViewDataColumn[] {
            gridViewTextBoxColumn1,
            gridViewTextBoxColumn2,
            gridViewTextBoxColumn3,
            gridViewTextBoxColumn4,
            gridViewTextBoxColumn5});
            sortDescriptor1.PropertyName = "column1";
            this.ContractList.MasterTemplate.SortDescriptors.AddRange(new Telerik.WinControls.Data.SortDescriptor[] {
            sortDescriptor1});
            this.ContractList.MasterTemplate.ViewDefinition = tableViewDefinition1;
            this.ContractList.Name = "ContractList";
            this.ContractList.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.ContractList.ShowGroupPanel = false;
            this.ContractList.Size = new System.Drawing.Size(718, 403);
            this.ContractList.TabIndex = 94;
            this.ContractList.ThemeName = "Breeze";
            // 
            // rbExpired
            // 
            this.rbExpired.AccessibleRole = System.Windows.Forms.AccessibleRole.Grouping;
            this.rbExpired.Controls.Add(this.PropertyID);
            this.rbExpired.Controls.Add(this.radLabel1);
            this.rbExpired.Controls.Add(this.Btnclear);
            this.rbExpired.Controls.Add(this.btnSearch);
            this.rbExpired.Controls.Add(this.rdNextToRequest);
            this.rbExpired.Controls.Add(this.CbMonth);
            this.rbExpired.Controls.Add(this.rdExpired);
            this.rbExpired.Dock = System.Windows.Forms.DockStyle.Top;
            this.rbExpired.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rbExpired.HeaderText = "";
            this.rbExpired.Location = new System.Drawing.Point(0, 0);
            this.rbExpired.Name = "rbExpired";
            this.rbExpired.Size = new System.Drawing.Size(718, 43);
            this.rbExpired.TabIndex = 96;
            // 
            // PropertyID
            // 
            this.PropertyID.AutoSize = false;
            this.PropertyID.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.PropertyID.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.PropertyID.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.PropertyID.Location = new System.Drawing.Point(5, 3);
            this.PropertyID.Name = "PropertyID";
            this.PropertyID.Size = new System.Drawing.Size(34, 33);
            this.PropertyID.TabIndex = 93;
            this.PropertyID.Text = "OC";
            this.PropertyID.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.PropertyID.ThemeName = "Breeze";
            // 
            // Btnclear
            // 
            this.Btnclear.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Btnclear.ForeColor = System.Drawing.Color.Black;
            this.Btnclear.Image = global::Evolution.Properties.Resources.edit_clear__1_;
            this.Btnclear.ImageAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            this.Btnclear.Location = new System.Drawing.Point(895, 8);
            this.Btnclear.Name = "Btnclear";
            this.Btnclear.Size = new System.Drawing.Size(70, 30);
            this.Btnclear.TabIndex = 5;
            this.Btnclear.Text = "Clear";
            this.Btnclear.TextAlignment = System.Drawing.ContentAlignment.MiddleLeft;
            this.Btnclear.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            ((Telerik.WinControls.UI.RadButtonElement)(this.Btnclear.GetChildAt(0))).Image = global::Evolution.Properties.Resources.edit_clear__1_;
            ((Telerik.WinControls.UI.RadButtonElement)(this.Btnclear.GetChildAt(0))).TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            ((Telerik.WinControls.UI.RadButtonElement)(this.Btnclear.GetChildAt(0))).ImageAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            ((Telerik.WinControls.UI.RadButtonElement)(this.Btnclear.GetChildAt(0))).TextAlignment = System.Drawing.ContentAlignment.MiddleLeft;
            ((Telerik.WinControls.UI.RadButtonElement)(this.Btnclear.GetChildAt(0))).Text = "Clear";
            ((Telerik.WinControls.Primitives.ImagePrimitive)(this.Btnclear.GetChildAt(0).GetChildAt(1).GetChildAt(0))).ImageScaling = Telerik.WinControls.Enumerations.ImageScaling.SizeToFit;
            // 
            // Foundrecords
            // 
            this.Foundrecords.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.Foundrecords.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Foundrecords.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.Foundrecords.Location = new System.Drawing.Point(384, 12);
            this.Foundrecords.Name = "Foundrecords";
            this.Foundrecords.Size = new System.Drawing.Size(15, 21);
            this.Foundrecords.TabIndex = 98;
            this.Foundrecords.Text = "0";
            this.Foundrecords.TextAlignment = System.Drawing.ContentAlignment.TopLeft;
            // 
            // radLabel8
            // 
            this.radLabel8.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.radLabel8.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.radLabel8.Location = new System.Drawing.Point(340, 12);
            this.radLabel8.Name = "radLabel8";
            this.radLabel8.Size = new System.Drawing.Size(44, 21);
            this.radLabel8.TabIndex = 97;
            this.radLabel8.Text = "Found";
            this.radLabel8.TextAlignment = System.Drawing.ContentAlignment.TopLeft;
            // 
            // radPanel1
            // 
            this.radPanel1.Controls.Add(this.Foundrecords);
            this.radPanel1.Controls.Add(this.bExport);
            this.radPanel1.Controls.Add(this.radLabel8);
            this.radPanel1.Controls.Add(this.bExit);
            this.radPanel1.Controls.Add(this.bPrint);
            this.radPanel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.radPanel1.Location = new System.Drawing.Point(0, 446);
            this.radPanel1.Name = "radPanel1";
            this.radPanel1.Size = new System.Drawing.Size(718, 40);
            this.radPanel1.TabIndex = 0;
            // 
            // radPanel2
            // 
            this.radPanel2.AutoScroll = true;
            this.radPanel2.Controls.Add(this.ContractList);
            this.radPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.radPanel2.Location = new System.Drawing.Point(0, 43);
            this.radPanel2.Name = "radPanel2";
            this.radPanel2.Size = new System.Drawing.Size(718, 403);
            this.radPanel2.TabIndex = 97;
            // 
            // OwnerComisionExpiredDay
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(244)))), ((int)(((byte)(253)))), ((int)(((byte)(255)))));
            this.ClientSize = new System.Drawing.Size(718, 486);
            this.Controls.Add(this.radPanel2);
            this.Controls.Add(this.radPanel1);
            this.Controls.Add(this.rbExpired);
            this.MaximizeBox = false;
            this.Name = "OwnerComisionExpiredDay";
            this.Text = "Owner Comision Expired/To Exp. Day";
            ((System.ComponentModel.ISupportInitialize)(this.rdNextToRequest)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rdExpired)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bPrint)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bExit)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.CbMonth)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnSearch)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bExport)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ContractList.MasterTemplate)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ContractList)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rbExpired)).EndInit();
            this.rbExpired.ResumeLayout(false);
            this.rbExpired.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.PropertyID)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Btnclear)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Foundrecords)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel8)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radPanel1)).EndInit();
            this.radPanel1.ResumeLayout(false);
            this.radPanel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.radPanel2)).EndInit();
            this.radPanel2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private Telerik.WinControls.UI.RadRadioButton rdNextToRequest;
        private Telerik.WinControls.UI.RadRadioButton rdExpired;
        private Telerik.WinControls.UI.RadButton bPrint;
        private Telerik.WinControls.UI.RadButton bExit;
        private Telerik.WinControls.UI.RadLabel radLabel1;
        private Telerik.WinControls.UI.RadDropDownList CbMonth;
        private Telerik.WinControls.UI.RadButton btnSearch;
        private Telerik.WinControls.UI.RadButton bExport;
        private Telerik.WinControls.UI.RadGridView ContractList;
        private Telerik.WinControls.UI.RadGroupBox rbExpired;
        private Telerik.WinControls.UI.RadButton Btnclear;
        private Telerik.WinControls.UI.RadLabel Foundrecords;
        private Telerik.WinControls.UI.RadLabel radLabel8;
        private Telerik.WinControls.UI.RadTextBox PropertyID;
        private Telerik.WinControls.UI.RadPanel radPanel1;
        private Telerik.WinControls.UI.RadPanel radPanel2;
    }
}