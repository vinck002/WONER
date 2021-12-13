namespace Ownersetting
{
    partial class Encryptions
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Encryptions));
            this.Decryptdata = new Telerik.WinControls.UI.RadTextBox();
            this.radGroupBox1 = new Telerik.WinControls.UI.RadGroupBox();
            this.bDecrypt = new Telerik.WinControls.UI.RadButton();
            this.bExit = new Telerik.WinControls.UI.RadButton();
            this.bEncrypt = new Telerik.WinControls.UI.RadButton();
            this.Encryptdata = new Telerik.WinControls.UI.RadTextBox();
            this.radTitleBar1 = new Telerik.WinControls.UI.RadTitleBar();
            ((System.ComponentModel.ISupportInitialize)(this.Decryptdata)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radGroupBox1)).BeginInit();
            this.radGroupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.bDecrypt)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bExit)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bEncrypt)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Encryptdata)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radTitleBar1)).BeginInit();
            this.SuspendLayout();
            // 
            // Decryptdata
            // 
            this.Decryptdata.AutoSize = false;
            this.Decryptdata.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(236)))), ((int)(((byte)(254)))), ((int)(((byte)(199)))));
            this.Decryptdata.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Decryptdata.Location = new System.Drawing.Point(12, 122);
            this.Decryptdata.Multiline = true;
            this.Decryptdata.Name = "Decryptdata";
            this.Decryptdata.Size = new System.Drawing.Size(660, 158);
            this.Decryptdata.TabIndex = 7;
            // 
            // radGroupBox1
            // 
            this.radGroupBox1.AccessibleRole = System.Windows.Forms.AccessibleRole.Grouping;
            this.radGroupBox1.Controls.Add(this.bDecrypt);
            this.radGroupBox1.Controls.Add(this.bExit);
            this.radGroupBox1.Controls.Add(this.bEncrypt);
            this.radGroupBox1.HeaderText = "";
            this.radGroupBox1.Location = new System.Drawing.Point(290, 298);
            this.radGroupBox1.Name = "radGroupBox1";
            this.radGroupBox1.Size = new System.Drawing.Size(382, 57);
            this.radGroupBox1.TabIndex = 6;
            // 
            // bDecrypt
            // 
            this.bDecrypt.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bDecrypt.ForeColor = System.Drawing.Color.Black;
            this.bDecrypt.Image = global::Ownersetting.Properties.Resources.stock_lock_open;
            this.bDecrypt.ImageAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            this.bDecrypt.Location = new System.Drawing.Point(129, 9);
            this.bDecrypt.Name = "bDecrypt";
            this.bDecrypt.Size = new System.Drawing.Size(118, 38);
            this.bDecrypt.TabIndex = 4;
            this.bDecrypt.Text = "Decrypt";
            this.bDecrypt.TextAlignment = System.Drawing.ContentAlignment.MiddleLeft;
            this.bDecrypt.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.bDecrypt.Click += new System.EventHandler(this.bDecrypt_Click);
            ((Telerik.WinControls.UI.RadButtonElement)(this.bDecrypt.GetChildAt(0))).Image = global::Ownersetting.Properties.Resources.stock_lock_open;
            ((Telerik.WinControls.UI.RadButtonElement)(this.bDecrypt.GetChildAt(0))).TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            ((Telerik.WinControls.UI.RadButtonElement)(this.bDecrypt.GetChildAt(0))).ImageAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            ((Telerik.WinControls.UI.RadButtonElement)(this.bDecrypt.GetChildAt(0))).TextAlignment = System.Drawing.ContentAlignment.MiddleLeft;
            ((Telerik.WinControls.UI.RadButtonElement)(this.bDecrypt.GetChildAt(0))).Text = "Decrypt";
            ((Telerik.WinControls.Primitives.ImagePrimitive)(this.bDecrypt.GetChildAt(0).GetChildAt(1).GetChildAt(0))).ImageScaling = Telerik.WinControls.Enumerations.ImageScaling.SizeToFit;
            // 
            // bExit
            // 
            this.bExit.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bExit.ForeColor = System.Drawing.Color.Black;
            this.bExit.Image = global::Ownersetting.Properties.Resources.salir1;
            this.bExit.ImageAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            this.bExit.Location = new System.Drawing.Point(253, 9);
            this.bExit.Name = "bExit";
            this.bExit.Size = new System.Drawing.Size(118, 38);
            this.bExit.TabIndex = 3;
            this.bExit.Text = "Exit";
            this.bExit.TextAlignment = System.Drawing.ContentAlignment.MiddleLeft;
            this.bExit.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.bExit.Click += new System.EventHandler(this.bExit_Click);
            ((Telerik.WinControls.UI.RadButtonElement)(this.bExit.GetChildAt(0))).Image = global::Ownersetting.Properties.Resources.salir1;
            ((Telerik.WinControls.UI.RadButtonElement)(this.bExit.GetChildAt(0))).TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            ((Telerik.WinControls.UI.RadButtonElement)(this.bExit.GetChildAt(0))).ImageAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            ((Telerik.WinControls.UI.RadButtonElement)(this.bExit.GetChildAt(0))).TextAlignment = System.Drawing.ContentAlignment.MiddleLeft;
            ((Telerik.WinControls.UI.RadButtonElement)(this.bExit.GetChildAt(0))).Text = "Exit";
            ((Telerik.WinControls.Primitives.ImagePrimitive)(this.bExit.GetChildAt(0).GetChildAt(1).GetChildAt(0))).ImageScaling = Telerik.WinControls.Enumerations.ImageScaling.SizeToFit;
            // 
            // bEncrypt
            // 
            this.bEncrypt.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bEncrypt.ForeColor = System.Drawing.Color.Black;
            this.bEncrypt.Image = global::Ownersetting.Properties.Resources.lock_yellow;
            this.bEncrypt.ImageAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            this.bEncrypt.Location = new System.Drawing.Point(5, 9);
            this.bEncrypt.Name = "bEncrypt";
            this.bEncrypt.Size = new System.Drawing.Size(118, 38);
            this.bEncrypt.TabIndex = 2;
            this.bEncrypt.Text = "Encrypt";
            this.bEncrypt.TextAlignment = System.Drawing.ContentAlignment.MiddleLeft;
            this.bEncrypt.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.bEncrypt.Click += new System.EventHandler(this.bEncrypt_Click);
            ((Telerik.WinControls.UI.RadButtonElement)(this.bEncrypt.GetChildAt(0))).Image = global::Ownersetting.Properties.Resources.lock_yellow;
            ((Telerik.WinControls.UI.RadButtonElement)(this.bEncrypt.GetChildAt(0))).TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            ((Telerik.WinControls.UI.RadButtonElement)(this.bEncrypt.GetChildAt(0))).ImageAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            ((Telerik.WinControls.UI.RadButtonElement)(this.bEncrypt.GetChildAt(0))).TextAlignment = System.Drawing.ContentAlignment.MiddleLeft;
            ((Telerik.WinControls.UI.RadButtonElement)(this.bEncrypt.GetChildAt(0))).Text = "Encrypt";
            ((Telerik.WinControls.Primitives.ImagePrimitive)(this.bEncrypt.GetChildAt(0).GetChildAt(1).GetChildAt(0))).ImageScaling = Telerik.WinControls.Enumerations.ImageScaling.SizeToFit;
            // 
            // Encryptdata
            // 
            this.Encryptdata.AutoSize = false;
            this.Encryptdata.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Encryptdata.Location = new System.Drawing.Point(12, 49);
            this.Encryptdata.Multiline = true;
            this.Encryptdata.Name = "Encryptdata";
            this.Encryptdata.NullText = "Type Here To Encryption";
            this.Encryptdata.Size = new System.Drawing.Size(660, 67);
            this.Encryptdata.TabIndex = 5;
            this.Encryptdata.Text = "Data Source=DESKTOP-RAI88E0\\SQLEXPRESS_2012;Initial Catalog=Owner;User ID=sa;Pass" +
    "word=evolutions";
            // 
            // radTitleBar1
            // 
            this.radTitleBar1.Dock = System.Windows.Forms.DockStyle.Top;
            this.radTitleBar1.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.radTitleBar1.ForeColor = System.Drawing.Color.Black;
            this.radTitleBar1.Location = new System.Drawing.Point(0, 0);
            this.radTitleBar1.Name = "radTitleBar1";
            this.radTitleBar1.Size = new System.Drawing.Size(684, 30);
            this.radTitleBar1.TabIndex = 8;
            this.radTitleBar1.TabStop = false;
            this.radTitleBar1.Text = "Encryptions";
            // 
            // Encryptions
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.ClientSize = new System.Drawing.Size(684, 367);
            this.Controls.Add(this.radTitleBar1);
            this.Controls.Add(this.Decryptdata);
            this.Controls.Add(this.radGroupBox1);
            this.Controls.Add(this.Encryptdata);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Encryptions";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Encryptions";
            ((System.ComponentModel.ISupportInitialize)(this.Decryptdata)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radGroupBox1)).EndInit();
            this.radGroupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.bDecrypt)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bExit)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bEncrypt)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Encryptdata)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radTitleBar1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Telerik.WinControls.UI.RadTextBox Decryptdata;
        private Telerik.WinControls.UI.RadGroupBox radGroupBox1;
        private Telerik.WinControls.UI.RadButton bDecrypt;
        private Telerik.WinControls.UI.RadButton bExit;
        private Telerik.WinControls.UI.RadButton bEncrypt;
        private Telerik.WinControls.UI.RadTextBox Encryptdata;
        private Telerik.WinControls.UI.RadTitleBar radTitleBar1;
    }
}