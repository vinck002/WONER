
namespace Evolution.Forms
{
    partial class HoldCanceledContract
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
            Telerik.WinControls.UI.GridViewDecimalColumn gridViewDecimalColumn1 = new Telerik.WinControls.UI.GridViewDecimalColumn();
            Telerik.WinControls.UI.GridViewTextBoxColumn gridViewTextBoxColumn3 = new Telerik.WinControls.UI.GridViewTextBoxColumn();
            Telerik.WinControls.UI.TableViewDefinition tableViewDefinition1 = new Telerik.WinControls.UI.TableViewDefinition();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(HoldCanceledContract));
            this.GRDContractList = new Telerik.WinControls.UI.RadGridView();
            this.radGroupBox1 = new Telerik.WinControls.UI.RadGroupBox();
            this.radLabel4 = new Telerik.WinControls.UI.RadLabel();
            this.radLabel2 = new Telerik.WinControls.UI.RadLabel();
            this.ApplicationDate = new Telerik.WinControls.UI.RadDateTimePicker();
            this.Remarks = new Telerik.WinControls.UI.RadTextBox();
            this.bExit = new Telerik.WinControls.UI.RadButton();
            this.bApply = new Telerik.WinControls.UI.RadButton();
            ((System.ComponentModel.ISupportInitialize)(this.GRDContractList)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.GRDContractList.MasterTemplate)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radGroupBox1)).BeginInit();
            this.radGroupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ApplicationDate)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Remarks)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bExit)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bApply)).BeginInit();
            this.SuspendLayout();
            // 
            // GRDContractList
            // 
            this.GRDContractList.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.GRDContractList.Location = new System.Drawing.Point(3, 3);
            // 
            // 
            // 
            this.GRDContractList.MasterTemplate.AllowAddNewRow = false;
            this.GRDContractList.MasterTemplate.AllowColumnReorder = false;
            gridViewCheckBoxColumn1.DataType = typeof(int);
            gridViewCheckBoxColumn1.FieldName = "Selected";
            gridViewCheckBoxColumn1.HeaderText = "Select";
            gridViewCheckBoxColumn1.Name = "Selected";
            gridViewCheckBoxColumn1.Width = 80;
            gridViewTextBoxColumn1.FieldName = "ContractNo";
            gridViewTextBoxColumn1.HeaderText = "Contract No.";
            gridViewTextBoxColumn1.Name = "ContractNo";
            gridViewTextBoxColumn1.ReadOnly = true;
            gridViewTextBoxColumn1.Width = 250;
            gridViewTextBoxColumn2.FieldName = "Status";
            gridViewTextBoxColumn2.HeaderText = "Status";
            gridViewTextBoxColumn2.Name = "Status";
            gridViewTextBoxColumn2.ReadOnly = true;
            gridViewTextBoxColumn2.Width = 225;
            gridViewDecimalColumn1.FieldName = "BalanceDue";
            gridViewDecimalColumn1.FormatString = "{0:N2}";
            gridViewDecimalColumn1.HeaderText = "Balance Due";
            gridViewDecimalColumn1.Minimum = new decimal(new int[] {
            0,
            0,
            0,
            0});
            gridViewDecimalColumn1.Name = "BalanceDue";
            gridViewDecimalColumn1.Width = 150;
            gridViewTextBoxColumn3.FieldName = "AgreementID";
            gridViewTextBoxColumn3.HeaderText = "AgreementID";
            gridViewTextBoxColumn3.IsVisible = false;
            gridViewTextBoxColumn3.Name = "AgreementID";
            this.GRDContractList.MasterTemplate.Columns.AddRange(new Telerik.WinControls.UI.GridViewDataColumn[] {
            gridViewCheckBoxColumn1,
            gridViewTextBoxColumn1,
            gridViewTextBoxColumn2,
            gridViewDecimalColumn1,
            gridViewTextBoxColumn3});
            this.GRDContractList.MasterTemplate.ViewDefinition = tableViewDefinition1;
            this.GRDContractList.Name = "GRDContractList";
            this.GRDContractList.ShowGroupPanel = false;
            this.GRDContractList.Size = new System.Drawing.Size(771, 428);
            this.GRDContractList.TabIndex = 5;
            // 
            // radGroupBox1
            // 
            this.radGroupBox1.AccessibleRole = System.Windows.Forms.AccessibleRole.Grouping;
            this.radGroupBox1.BackColor = System.Drawing.Color.Transparent;
            this.radGroupBox1.Controls.Add(this.radLabel4);
            this.radGroupBox1.Controls.Add(this.radLabel2);
            this.radGroupBox1.Controls.Add(this.ApplicationDate);
            this.radGroupBox1.Controls.Add(this.Remarks);
            this.radGroupBox1.Controls.Add(this.bExit);
            this.radGroupBox1.Controls.Add(this.bApply);
            this.radGroupBox1.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.radGroupBox1.GroupBoxStyle = Telerik.WinControls.UI.RadGroupBoxStyle.Office;
            this.radGroupBox1.HeaderText = "Set Hold With Cancelation Credit Note";
            this.radGroupBox1.Location = new System.Drawing.Point(3, 437);
            this.radGroupBox1.Name = "radGroupBox1";
            // 
            // 
            // 
            this.radGroupBox1.RootElement.ControlBounds = new System.Drawing.Rectangle(12, 446, 200, 100);
            this.radGroupBox1.Size = new System.Drawing.Size(771, 65);
            this.radGroupBox1.TabIndex = 6;
            this.radGroupBox1.Text = "Set Hold With Cancelation Credit Note";
            // 
            // radLabel4
            // 
            this.radLabel4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(244)))), ((int)(((byte)(251)))), ((int)(((byte)(255)))));
            this.radLabel4.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.radLabel4.Location = new System.Drawing.Point(299, 30);
            this.radLabel4.Name = "radLabel4";
            // 
            // 
            // 
            this.radLabel4.RootElement.ControlBounds = new System.Drawing.Rectangle(299, 24, 100, 18);
            this.radLabel4.Size = new System.Drawing.Size(105, 21);
            this.radLabel4.TabIndex = 9;
            this.radLabel4.Text = "Application Date";
            // 
            // radLabel2
            // 
            this.radLabel2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(244)))), ((int)(((byte)(251)))), ((int)(((byte)(255)))));
            this.radLabel2.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.radLabel2.Location = new System.Drawing.Point(5, 30);
            this.radLabel2.Name = "radLabel2";
            // 
            // 
            // 
            this.radLabel2.RootElement.ControlBounds = new System.Drawing.Rectangle(5, 26, 100, 18);
            this.radLabel2.Size = new System.Drawing.Size(74, 21);
            this.radLabel2.TabIndex = 7;
            this.radLabel2.Text = "Description";
            // 
            // ApplicationDate
            // 
            this.ApplicationDate.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.ApplicationDate.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ApplicationDate.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.ApplicationDate.Location = new System.Drawing.Point(410, 30);
            this.ApplicationDate.MinDate = new System.DateTime(2000, 1, 1, 0, 0, 0, 0);
            this.ApplicationDate.Name = "ApplicationDate";
            // 
            // 
            // 
            this.ApplicationDate.RootElement.ControlBounds = new System.Drawing.Rectangle(410, 24, 164, 20);
            this.ApplicationDate.RootElement.StretchVertically = true;
            this.ApplicationDate.Size = new System.Drawing.Size(117, 23);
            this.ApplicationDate.TabIndex = 5;
            this.ApplicationDate.TabStop = false;
            this.ApplicationDate.Text = "08/04/2017";
            this.ApplicationDate.Value = new System.DateTime(2017, 8, 4, 0, 0, 0, 0);
            // 
            // Remarks
            // 
            this.Remarks.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.Remarks.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Remarks.Location = new System.Drawing.Point(85, 30);
            this.Remarks.Name = "Remarks";
            this.Remarks.NullText = "Remarks";
            // 
            // 
            // 
            this.Remarks.RootElement.ControlBounds = new System.Drawing.Rectangle(85, 26, 100, 20);
            this.Remarks.RootElement.StretchVertically = true;
            this.Remarks.Size = new System.Drawing.Size(208, 23);
            this.Remarks.TabIndex = 3;
            this.Remarks.Text = "Canceled";
            // 
            // bExit
            // 
            this.bExit.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(244)))), ((int)(((byte)(251)))), ((int)(((byte)(255)))));
            this.bExit.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bExit.ForeColor = System.Drawing.Color.Black;
            this.bExit.Image = global::Evolution.Properties.Resources.salir;
            this.bExit.ImageAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            this.bExit.Location = new System.Drawing.Point(649, 26);
            this.bExit.Name = "bExit";
            // 
            // 
            // 
            this.bExit.RootElement.ControlBounds = new System.Drawing.Rectangle(649, 26, 110, 24);
            this.bExit.Size = new System.Drawing.Size(110, 32);
            this.bExit.TabIndex = 1;
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
            // bApply
            // 
            this.bApply.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(244)))), ((int)(((byte)(251)))), ((int)(((byte)(255)))));
            this.bApply.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bApply.ForeColor = System.Drawing.Color.Black;
            this.bApply.Image = global::Evolution.Properties.Resources.ok;
            this.bApply.ImageAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            this.bApply.Location = new System.Drawing.Point(533, 26);
            this.bApply.Name = "bApply";
            // 
            // 
            // 
            this.bApply.RootElement.ControlBounds = new System.Drawing.Rectangle(533, 26, 110, 24);
            this.bApply.Size = new System.Drawing.Size(110, 31);
            this.bApply.TabIndex = 0;
            this.bApply.Text = "Apply";
            this.bApply.TextAlignment = System.Drawing.ContentAlignment.MiddleLeft;
            this.bApply.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.bApply.ThemeName = "ControlDefault";
            this.bApply.Click += new System.EventHandler(this.bApply_Click);
            ((Telerik.WinControls.UI.RadButtonElement)(this.bApply.GetChildAt(0))).Image = global::Evolution.Properties.Resources.ok;
            ((Telerik.WinControls.UI.RadButtonElement)(this.bApply.GetChildAt(0))).TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            ((Telerik.WinControls.UI.RadButtonElement)(this.bApply.GetChildAt(0))).ImageAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            ((Telerik.WinControls.UI.RadButtonElement)(this.bApply.GetChildAt(0))).TextAlignment = System.Drawing.ContentAlignment.MiddleLeft;
            ((Telerik.WinControls.UI.RadButtonElement)(this.bApply.GetChildAt(0))).Text = "Apply";
            ((Telerik.WinControls.Primitives.ImagePrimitive)(this.bApply.GetChildAt(0).GetChildAt(1).GetChildAt(0))).ImageScaling = Telerik.WinControls.Enumerations.ImageScaling.SizeToFit;
            // 
            // HoldCanceledContract
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(244)))), ((int)(((byte)(251)))), ((int)(((byte)(255)))));
            this.ClientSize = new System.Drawing.Size(777, 503);
            this.Controls.Add(this.radGroupBox1);
            this.Controls.Add(this.GRDContractList);
            this.DoubleBuffered = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "HoldCanceledContract";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Set Hold Canceled Contracts";
            this.Load += new System.EventHandler(this.HoldCanceledContract_Load);
            this.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.HoldCanceledContract_KeyPress);
            ((System.ComponentModel.ISupportInitialize)(this.GRDContractList.MasterTemplate)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.GRDContractList)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radGroupBox1)).EndInit();
            this.radGroupBox1.ResumeLayout(false);
            this.radGroupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ApplicationDate)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Remarks)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bExit)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bApply)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Telerik.WinControls.UI.RadGridView GRDContractList;
        private Telerik.WinControls.UI.RadGroupBox radGroupBox1;
        private Telerik.WinControls.UI.RadLabel radLabel4;
        private Telerik.WinControls.UI.RadLabel radLabel2;
        private Telerik.WinControls.UI.RadDateTimePicker ApplicationDate;
        private Telerik.WinControls.UI.RadTextBox Remarks;
        private Telerik.WinControls.UI.RadButton bExit;
        private Telerik.WinControls.UI.RadButton bApply;
    }
}