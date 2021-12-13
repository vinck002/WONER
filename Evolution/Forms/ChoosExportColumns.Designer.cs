
namespace Evolution.Forms
{
    partial class ChoosExportColumns
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
            Telerik.WinControls.UI.GridViewCheckBoxColumn gridViewCheckBoxColumn1 = new Telerik.WinControls.UI.GridViewCheckBoxColumn();
            Telerik.WinControls.UI.GridViewTextBoxColumn gridViewTextBoxColumn1 = new Telerik.WinControls.UI.GridViewTextBoxColumn();
            Telerik.WinControls.UI.GridViewTextBoxColumn gridViewTextBoxColumn2 = new Telerik.WinControls.UI.GridViewTextBoxColumn();
            Telerik.WinControls.UI.GridViewTextBoxColumn gridViewTextBoxColumn3 = new Telerik.WinControls.UI.GridViewTextBoxColumn();
            Telerik.WinControls.UI.GridViewTextBoxColumn gridViewTextBoxColumn4 = new Telerik.WinControls.UI.GridViewTextBoxColumn();
            Telerik.WinControls.UI.GridViewTextBoxColumn gridViewTextBoxColumn5 = new Telerik.WinControls.UI.GridViewTextBoxColumn();
            Telerik.WinControls.UI.GridViewTextBoxColumn gridViewTextBoxColumn6 = new Telerik.WinControls.UI.GridViewTextBoxColumn();
            Telerik.WinControls.Data.SortDescriptor sortDescriptor1 = new Telerik.WinControls.Data.SortDescriptor();
            Telerik.WinControls.UI.TableViewDefinition tableViewDefinition1 = new Telerik.WinControls.UI.TableViewDefinition();
            this.grvCollumsCheck = new Telerik.WinControls.UI.RadGridView();
            this.radPanel1 = new Telerik.WinControls.UI.RadPanel();
            this.bExit = new Telerik.WinControls.UI.RadButton();
            this.bProccess = new Telerik.WinControls.UI.RadButton();
            this.radButton1 = new Telerik.WinControls.UI.RadButton();
            this.radPanel2 = new Telerik.WinControls.UI.RadPanel();
            ((System.ComponentModel.ISupportInitialize)(this.grvCollumsCheck)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvCollumsCheck.MasterTemplate)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radPanel1)).BeginInit();
            this.radPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.bExit)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bProccess)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radButton1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radPanel2)).BeginInit();
            this.radPanel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // grvCollumsCheck
            // 
            this.grvCollumsCheck.AutoScroll = true;
            this.grvCollumsCheck.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(242)))), ((int)(((byte)(250)))), ((int)(((byte)(255)))));
            this.grvCollumsCheck.Cursor = System.Windows.Forms.Cursors.Default;
            this.grvCollumsCheck.Font = new System.Drawing.Font("Segoe UI", 8.25F);
            this.grvCollumsCheck.ForeColor = System.Drawing.Color.Black;
            this.grvCollumsCheck.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.grvCollumsCheck.Location = new System.Drawing.Point(0, 0);
            // 
            // 
            // 
            this.grvCollumsCheck.MasterTemplate.AddNewRowPosition = Telerik.WinControls.UI.SystemRowPosition.Bottom;
            this.grvCollumsCheck.MasterTemplate.AllowAddNewRow = false;
            this.grvCollumsCheck.MasterTemplate.AllowDeleteRow = false;
            this.grvCollumsCheck.MasterTemplate.AllowDragToGroup = false;
            this.grvCollumsCheck.MasterTemplate.AllowEditRow = false;
            this.grvCollumsCheck.MasterTemplate.AllowRowResize = false;
            this.grvCollumsCheck.MasterTemplate.AutoGenerateColumns = false;
            gridViewCheckBoxColumn1.AllowGroup = false;
            gridViewCheckBoxColumn1.EnableExpressionEditor = false;
            gridViewCheckBoxColumn1.EnableHeaderCheckBox = true;
            gridViewCheckBoxColumn1.FieldName = "Visible";
            gridViewCheckBoxColumn1.MinWidth = 20;
            gridViewCheckBoxColumn1.Name = "Visible";
            gridViewCheckBoxColumn1.Width = 34;
            gridViewTextBoxColumn1.EnableExpressionEditor = false;
            gridViewTextBoxColumn1.FieldName = "Description";
            gridViewTextBoxColumn1.HeaderText = "Description";
            gridViewTextBoxColumn1.Name = "Description";
            gridViewTextBoxColumn1.SortOrder = Telerik.WinControls.UI.RadSortOrder.Ascending;
            gridViewTextBoxColumn1.Width = 225;
            gridViewTextBoxColumn2.EnableExpressionEditor = false;
            gridViewTextBoxColumn2.FieldName = "FormCode";
            gridViewTextBoxColumn2.HeaderText = "FormCode";
            gridViewTextBoxColumn2.IsVisible = false;
            gridViewTextBoxColumn2.Name = "FormCode";
            gridViewTextBoxColumn3.EnableExpressionEditor = false;
            gridViewTextBoxColumn3.FieldName = "Id";
            gridViewTextBoxColumn3.HeaderText = "Id";
            gridViewTextBoxColumn3.IsVisible = false;
            gridViewTextBoxColumn3.Name = "Id";
            gridViewTextBoxColumn4.EnableExpressionEditor = false;
            gridViewTextBoxColumn4.FieldName = "ColumnName";
            gridViewTextBoxColumn4.HeaderText = "ColumnName";
            gridViewTextBoxColumn4.IsVisible = false;
            gridViewTextBoxColumn4.Name = "ColumnName";
            gridViewTextBoxColumn5.EnableExpressionEditor = false;
            gridViewTextBoxColumn5.FieldName = "ColumnNumber";
            gridViewTextBoxColumn5.HeaderText = "Column #";
            gridViewTextBoxColumn5.IsVisible = false;
            gridViewTextBoxColumn5.Name = "ColumnNumber";
            gridViewTextBoxColumn6.EnableExpressionEditor = false;
            gridViewTextBoxColumn6.FieldName = "DefaultColumns";
            gridViewTextBoxColumn6.HeaderText = "DefaultColumns";
            gridViewTextBoxColumn6.IsVisible = false;
            gridViewTextBoxColumn6.Name = "DefaultCollumns";
            this.grvCollumsCheck.MasterTemplate.Columns.AddRange(new Telerik.WinControls.UI.GridViewDataColumn[] {
            gridViewCheckBoxColumn1,
            gridViewTextBoxColumn1,
            gridViewTextBoxColumn2,
            gridViewTextBoxColumn3,
            gridViewTextBoxColumn4,
            gridViewTextBoxColumn5,
            gridViewTextBoxColumn6});
            this.grvCollumsCheck.MasterTemplate.EnableGrouping = false;
            sortDescriptor1.PropertyName = "Description";
            this.grvCollumsCheck.MasterTemplate.SortDescriptors.AddRange(new Telerik.WinControls.Data.SortDescriptor[] {
            sortDescriptor1});
            this.grvCollumsCheck.MasterTemplate.ViewDefinition = tableViewDefinition1;
            this.grvCollumsCheck.Name = "grvCollumsCheck";
            this.grvCollumsCheck.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.grvCollumsCheck.Size = new System.Drawing.Size(292, 422);
            this.grvCollumsCheck.TabIndex = 0;
            this.grvCollumsCheck.CellClick += new Telerik.WinControls.UI.GridViewCellEventHandler(this.grvCollumsCheck_CellClick);
            this.grvCollumsCheck.Click += new System.EventHandler(this.grvCollumsCheck_Click);
            // 
            // radPanel1
            // 
            this.radPanel1.Controls.Add(this.grvCollumsCheck);
            this.radPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.radPanel1.Location = new System.Drawing.Point(0, 0);
            this.radPanel1.Name = "radPanel1";
            this.radPanel1.Size = new System.Drawing.Size(283, 472);
            this.radPanel1.TabIndex = 1;
            // 
            // bExit
            // 
            this.bExit.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.bExit.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.bExit.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bExit.ForeColor = System.Drawing.Color.Black;
            this.bExit.Image = global::Evolution.Properties.Resources.salir;
            this.bExit.ImageAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            this.bExit.Location = new System.Drawing.Point(219, 8);
            this.bExit.Name = "bExit";
            // 
            // 
            // 
            this.bExit.RootElement.ControlBounds = new System.Drawing.Rectangle(219, 8, 110, 24);
            this.bExit.Size = new System.Drawing.Size(57, 30);
            this.bExit.TabIndex = 9;
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
            // bProccess
            // 
            this.bProccess.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.bProccess.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.bProccess.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bProccess.ForeColor = System.Drawing.Color.Black;
            this.bProccess.Image = global::Evolution.Properties.Resources.ok;
            this.bProccess.ImageAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            this.bProccess.Location = new System.Drawing.Point(153, 8);
            this.bProccess.Name = "bProccess";
            // 
            // 
            // 
            this.bProccess.RootElement.ControlBounds = new System.Drawing.Rectangle(153, 8, 110, 24);
            this.bProccess.Size = new System.Drawing.Size(60, 30);
            this.bProccess.TabIndex = 8;
            this.bProccess.Text = "Apply";
            this.bProccess.TextAlignment = System.Drawing.ContentAlignment.MiddleLeft;
            this.bProccess.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.bProccess.Click += new System.EventHandler(this.bProccess_Click);
            ((Telerik.WinControls.UI.RadButtonElement)(this.bProccess.GetChildAt(0))).Image = global::Evolution.Properties.Resources.ok;
            ((Telerik.WinControls.UI.RadButtonElement)(this.bProccess.GetChildAt(0))).TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            ((Telerik.WinControls.UI.RadButtonElement)(this.bProccess.GetChildAt(0))).ImageAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            ((Telerik.WinControls.UI.RadButtonElement)(this.bProccess.GetChildAt(0))).TextAlignment = System.Drawing.ContentAlignment.MiddleLeft;
            ((Telerik.WinControls.UI.RadButtonElement)(this.bProccess.GetChildAt(0))).Text = "Apply";
            ((Telerik.WinControls.Primitives.ImagePrimitive)(this.bProccess.GetChildAt(0).GetChildAt(1).GetChildAt(0))).ImageScaling = Telerik.WinControls.Enumerations.ImageScaling.SizeToFit;
            // 
            // radButton1
            // 
            this.radButton1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.radButton1.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.radButton1.BackgroundImage = global::Evolution.Properties.Resources.undo;
            this.radButton1.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.radButton1.ForeColor = System.Drawing.Color.Black;
            this.radButton1.Image = global::Evolution.Properties.Resources.process;
            this.radButton1.ImageAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            this.radButton1.Location = new System.Drawing.Point(10, 8);
            this.radButton1.Name = "radButton1";
            // 
            // 
            // 
            this.radButton1.RootElement.ControlBounds = new System.Drawing.Rectangle(10, 8, 110, 24);
            this.radButton1.Size = new System.Drawing.Size(69, 30);
            this.radButton1.TabIndex = 10;
            this.radButton1.Text = "Default";
            this.radButton1.TextAlignment = System.Drawing.ContentAlignment.MiddleLeft;
            this.radButton1.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.radButton1.Visible = false;
            ((Telerik.WinControls.UI.RadButtonElement)(this.radButton1.GetChildAt(0))).Image = global::Evolution.Properties.Resources.process;
            ((Telerik.WinControls.UI.RadButtonElement)(this.radButton1.GetChildAt(0))).TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            ((Telerik.WinControls.UI.RadButtonElement)(this.radButton1.GetChildAt(0))).ImageAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            ((Telerik.WinControls.UI.RadButtonElement)(this.radButton1.GetChildAt(0))).TextAlignment = System.Drawing.ContentAlignment.MiddleLeft;
            ((Telerik.WinControls.UI.RadButtonElement)(this.radButton1.GetChildAt(0))).Text = "Default";
            ((Telerik.WinControls.Primitives.ImagePrimitive)(this.radButton1.GetChildAt(0).GetChildAt(1).GetChildAt(0))).ImageScaling = Telerik.WinControls.Enumerations.ImageScaling.SizeToFit;
            // 
            // radPanel2
            // 
            this.radPanel2.Controls.Add(this.radButton1);
            this.radPanel2.Controls.Add(this.bExit);
            this.radPanel2.Controls.Add(this.bProccess);
            this.radPanel2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.radPanel2.Location = new System.Drawing.Point(0, 428);
            this.radPanel2.Name = "radPanel2";
            this.radPanel2.Size = new System.Drawing.Size(283, 44);
            this.radPanel2.TabIndex = 1;
            // 
            // ChoosExportColumns
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(242)))), ((int)(((byte)(250)))), ((int)(((byte)(255)))));
            this.ClientSize = new System.Drawing.Size(283, 472);
            this.Controls.Add(this.radPanel2);
            this.Controls.Add(this.radPanel1);
            this.MaximizeBox = false;
            this.Name = "ChoosExportColumns";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Columns To Export";
            ((System.ComponentModel.ISupportInitialize)(this.grvCollumsCheck.MasterTemplate)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvCollumsCheck)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radPanel1)).EndInit();
            this.radPanel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.bExit)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bProccess)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radButton1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radPanel2)).EndInit();
            this.radPanel2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private Telerik.WinControls.UI.RadGridView grvCollumsCheck;
        private Telerik.WinControls.UI.RadPanel radPanel1;
        private Telerik.WinControls.UI.RadButton bExit;
        private Telerik.WinControls.UI.RadButton bProccess;
        private Telerik.WinControls.UI.RadButton radButton1;
        private Telerik.WinControls.UI.RadPanel radPanel2;
    }
}