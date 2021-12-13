namespace Evolution.Forms
{
    partial class SelectReport
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
            this.radTitleBar1 = new Telerik.WinControls.UI.RadTitleBar();
            this.radGroupBox1 = new Telerik.WinControls.UI.RadGroupBox();
            this.ExportToExcel = new Telerik.WinControls.UI.RadCheckBox();
            this.bOwnership = new Telerik.WinControls.UI.RadRadioButton();
            this.bDetail = new Telerik.WinControls.UI.RadRadioButton();
            this.bsummary = new Telerik.WinControls.UI.RadRadioButton();
            this.radGroupBox2 = new Telerik.WinControls.UI.RadGroupBox();
            this.bCancel = new Telerik.WinControls.UI.RadButton();
            this.bPrint = new Telerik.WinControls.UI.RadButton();
            ((System.ComponentModel.ISupportInitialize)(this.radTitleBar1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radGroupBox1)).BeginInit();
            this.radGroupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ExportToExcel)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bOwnership)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bDetail)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bsummary)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radGroupBox2)).BeginInit();
            this.radGroupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.bCancel)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bPrint)).BeginInit();
            this.SuspendLayout();
            // 
            // radTitleBar1
            // 
            this.radTitleBar1.Dock = System.Windows.Forms.DockStyle.Top;
            this.radTitleBar1.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.radTitleBar1.ForeColor = System.Drawing.Color.Black;
            this.radTitleBar1.Location = new System.Drawing.Point(0, 0);
            this.radTitleBar1.Name = "radTitleBar1";
            this.radTitleBar1.Size = new System.Drawing.Size(348, 30);
            this.radTitleBar1.TabIndex = 0;
            this.radTitleBar1.TabStop = false;
            this.radTitleBar1.Text = "Select Report";
            // 
            // radGroupBox1
            // 
            this.radGroupBox1.AccessibleRole = System.Windows.Forms.AccessibleRole.Grouping;
            this.radGroupBox1.Controls.Add(this.ExportToExcel);
            this.radGroupBox1.Controls.Add(this.bOwnership);
            this.radGroupBox1.Controls.Add(this.bDetail);
            this.radGroupBox1.Controls.Add(this.bsummary);
            this.radGroupBox1.HeaderText = "";
            this.radGroupBox1.Location = new System.Drawing.Point(33, 47);
            this.radGroupBox1.Name = "radGroupBox1";
            this.radGroupBox1.Size = new System.Drawing.Size(283, 100);
            this.radGroupBox1.TabIndex = 1;
            // 
            // ExportToExcel
            // 
            this.ExportToExcel.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ExportToExcel.Location = new System.Drawing.Point(157, 38);
            this.ExportToExcel.Name = "ExportToExcel";
            this.ExportToExcel.Size = new System.Drawing.Size(110, 21);
            this.ExportToExcel.TabIndex = 3;
            this.ExportToExcel.Text = "Export To Excel";
            this.ExportToExcel.Visible = false;
            // 
            // bOwnership
            // 
            this.bOwnership.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bOwnership.Location = new System.Drawing.Point(18, 65);
            this.bOwnership.Name = "bOwnership";
            this.bOwnership.Size = new System.Drawing.Size(152, 21);
            this.bOwnership.TabIndex = 2;
            this.bOwnership.TabStop = false;
            this.bOwnership.Text = "Settlement Ownership";
            // 
            // bDetail
            // 
            this.bDetail.CheckState = System.Windows.Forms.CheckState.Checked;
            this.bDetail.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bDetail.Location = new System.Drawing.Point(18, 38);
            this.bDetail.Name = "bDetail";
            this.bDetail.Size = new System.Drawing.Size(123, 21);
            this.bDetail.TabIndex = 1;
            this.bDetail.Text = "Settlement Detail";
            this.bDetail.ToggleState = Telerik.WinControls.Enumerations.ToggleState.On;
            // 
            // bsummary
            // 
            this.bsummary.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bsummary.Location = new System.Drawing.Point(18, 11);
            this.bsummary.Name = "bsummary";
            this.bsummary.Size = new System.Drawing.Size(144, 21);
            this.bsummary.TabIndex = 0;
            this.bsummary.TabStop = false;
            this.bsummary.Text = "Settlement Summary";
            // 
            // radGroupBox2
            // 
            this.radGroupBox2.AccessibleRole = System.Windows.Forms.AccessibleRole.Grouping;
            this.radGroupBox2.Controls.Add(this.bCancel);
            this.radGroupBox2.Controls.Add(this.bPrint);
            this.radGroupBox2.HeaderText = "";
            this.radGroupBox2.Location = new System.Drawing.Point(76, 153);
            this.radGroupBox2.Name = "radGroupBox2";
            this.radGroupBox2.Size = new System.Drawing.Size(240, 42);
            this.radGroupBox2.TabIndex = 2;
            // 
            // bCancel
            // 
            this.bCancel.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bCancel.ForeColor = System.Drawing.Color.Black;
            this.bCancel.Image = global::Evolution.Properties.Resources.stop;
            this.bCancel.ImageAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            this.bCancel.Location = new System.Drawing.Point(121, 4);
            this.bCancel.Name = "bCancel";
            this.bCancel.Size = new System.Drawing.Size(110, 34);
            this.bCancel.TabIndex = 1;
            this.bCancel.Text = "Cancel";
            this.bCancel.TextAlignment = System.Drawing.ContentAlignment.MiddleLeft;
            this.bCancel.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.bCancel.Click += new System.EventHandler(this.bCancel_Click);
            ((Telerik.WinControls.UI.RadButtonElement)(this.bCancel.GetChildAt(0))).Image = global::Evolution.Properties.Resources.stop;
            ((Telerik.WinControls.UI.RadButtonElement)(this.bCancel.GetChildAt(0))).TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            ((Telerik.WinControls.UI.RadButtonElement)(this.bCancel.GetChildAt(0))).ImageAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            ((Telerik.WinControls.UI.RadButtonElement)(this.bCancel.GetChildAt(0))).TextAlignment = System.Drawing.ContentAlignment.MiddleLeft;
            ((Telerik.WinControls.UI.RadButtonElement)(this.bCancel.GetChildAt(0))).Text = "Cancel";
            ((Telerik.WinControls.Primitives.ImagePrimitive)(this.bCancel.GetChildAt(0).GetChildAt(1).GetChildAt(0))).ImageScaling = Telerik.WinControls.Enumerations.ImageScaling.SizeToFit;
            // 
            // bPrint
            // 
            this.bPrint.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bPrint.ForeColor = System.Drawing.Color.Black;
            this.bPrint.Image = global::Evolution.Properties.Resources.printer_green;
            this.bPrint.ImageAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            this.bPrint.Location = new System.Drawing.Point(5, 4);
            this.bPrint.Name = "bPrint";
            this.bPrint.Size = new System.Drawing.Size(110, 34);
            this.bPrint.TabIndex = 0;
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
            // SelectReport
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(244)))), ((int)(((byte)(251)))), ((int)(((byte)(255)))));
            this.ClientSize = new System.Drawing.Size(348, 215);
            this.Controls.Add(this.radGroupBox2);
            this.Controls.Add(this.radGroupBox1);
            this.Controls.Add(this.radTitleBar1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "SelectReport";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Select Report";
            this.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.SelectReport_KeyPress);
            ((System.ComponentModel.ISupportInitialize)(this.radTitleBar1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radGroupBox1)).EndInit();
            this.radGroupBox1.ResumeLayout(false);
            this.radGroupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ExportToExcel)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bOwnership)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bDetail)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bsummary)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radGroupBox2)).EndInit();
            this.radGroupBox2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.bCancel)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bPrint)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Telerik.WinControls.UI.RadTitleBar radTitleBar1;
        private Telerik.WinControls.UI.RadGroupBox radGroupBox1;
        private Telerik.WinControls.UI.RadGroupBox radGroupBox2;
        private Telerik.WinControls.UI.RadRadioButton bOwnership;
        private Telerik.WinControls.UI.RadRadioButton bDetail;
        private Telerik.WinControls.UI.RadRadioButton bsummary;
        private Telerik.WinControls.UI.RadButton bCancel;
        private Telerik.WinControls.UI.RadButton bPrint;
        private Telerik.WinControls.UI.RadCheckBox ExportToExcel;
    }
}