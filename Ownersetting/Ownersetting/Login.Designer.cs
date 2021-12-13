namespace Ownersetting
{
    partial class Login
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
            this.Password = new Telerik.WinControls.UI.RadTextBox();
            this.radLabel1 = new Telerik.WinControls.UI.RadLabel();
            this.bCancel = new Telerik.WinControls.UI.RadButton();
            this.bAcept = new Telerik.WinControls.UI.RadButton();
            ((System.ComponentModel.ISupportInitialize)(this.Password)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bCancel)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bAcept)).BeginInit();
            this.SuspendLayout();
            // 
            // Password
            // 
            this.Password.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Password.Location = new System.Drawing.Point(81, 29);
            this.Password.Name = "Password";
            this.Password.PasswordChar = '●';
            this.Password.Size = new System.Drawing.Size(153, 23);
            this.Password.TabIndex = 0;
            this.Password.UseSystemPasswordChar = true;
            this.Password.TextChanged += new System.EventHandler(this.radTextBox1_TextChanged);
            // 
            // radLabel1
            // 
            this.radLabel1.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.radLabel1.Location = new System.Drawing.Point(12, 29);
            this.radLabel1.Name = "radLabel1";
            this.radLabel1.Size = new System.Drawing.Size(63, 21);
            this.radLabel1.TabIndex = 1;
            this.radLabel1.Text = "Password";
            // 
            // bCancel
            // 
            this.bCancel.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bCancel.ForeColor = System.Drawing.Color.Black;
            this.bCancel.Image = global::Ownersetting.Properties.Resources.stop;
            this.bCancel.ImageAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            this.bCancel.Location = new System.Drawing.Point(128, 68);
            this.bCancel.Name = "bCancel";
            this.bCancel.Size = new System.Drawing.Size(110, 32);
            this.bCancel.TabIndex = 3;
            this.bCancel.Text = "Cancel";
            this.bCancel.TextAlignment = System.Drawing.ContentAlignment.MiddleLeft;
            this.bCancel.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.bCancel.Click += new System.EventHandler(this.bCancel_Click);
            ((Telerik.WinControls.UI.RadButtonElement)(this.bCancel.GetChildAt(0))).Image = global::Ownersetting.Properties.Resources.stop;
            ((Telerik.WinControls.UI.RadButtonElement)(this.bCancel.GetChildAt(0))).TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            ((Telerik.WinControls.UI.RadButtonElement)(this.bCancel.GetChildAt(0))).ImageAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            ((Telerik.WinControls.UI.RadButtonElement)(this.bCancel.GetChildAt(0))).TextAlignment = System.Drawing.ContentAlignment.MiddleLeft;
            ((Telerik.WinControls.UI.RadButtonElement)(this.bCancel.GetChildAt(0))).Text = "Cancel";
            ((Telerik.WinControls.Primitives.ImagePrimitive)(this.bCancel.GetChildAt(0).GetChildAt(1).GetChildAt(0))).ImageScaling = Telerik.WinControls.Enumerations.ImageScaling.SizeToFit;
            // 
            // bAcept
            // 
            this.bAcept.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bAcept.ForeColor = System.Drawing.Color.Black;
            this.bAcept.Image = global::Ownersetting.Properties.Resources.ok;
            this.bAcept.ImageAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            this.bAcept.Location = new System.Drawing.Point(12, 68);
            this.bAcept.Name = "bAcept";
            this.bAcept.Size = new System.Drawing.Size(110, 32);
            this.bAcept.TabIndex = 2;
            this.bAcept.Text = "OK";
            this.bAcept.TextAlignment = System.Drawing.ContentAlignment.MiddleLeft;
            this.bAcept.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.bAcept.Click += new System.EventHandler(this.bAcept_Click);
            ((Telerik.WinControls.UI.RadButtonElement)(this.bAcept.GetChildAt(0))).Image = global::Ownersetting.Properties.Resources.ok;
            ((Telerik.WinControls.UI.RadButtonElement)(this.bAcept.GetChildAt(0))).TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            ((Telerik.WinControls.UI.RadButtonElement)(this.bAcept.GetChildAt(0))).ImageAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            ((Telerik.WinControls.UI.RadButtonElement)(this.bAcept.GetChildAt(0))).TextAlignment = System.Drawing.ContentAlignment.MiddleLeft;
            ((Telerik.WinControls.UI.RadButtonElement)(this.bAcept.GetChildAt(0))).Text = "OK";
            ((Telerik.WinControls.Primitives.ImagePrimitive)(this.bAcept.GetChildAt(0).GetChildAt(1).GetChildAt(0))).ImageScaling = Telerik.WinControls.Enumerations.ImageScaling.SizeToFit;
            // 
            // Login
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.ClientSize = new System.Drawing.Size(246, 125);
            this.Controls.Add(this.bCancel);
            this.Controls.Add(this.bAcept);
            this.Controls.Add(this.radLabel1);
            this.Controls.Add(this.Password);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "Login";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Login";
            ((System.ComponentModel.ISupportInitialize)(this.Password)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bCancel)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bAcept)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Telerik.WinControls.UI.RadTextBox Password;
        private Telerik.WinControls.UI.RadLabel radLabel1;
        private Telerik.WinControls.UI.RadButton bAcept;
        private Telerik.WinControls.UI.RadButton bCancel;
    }
}