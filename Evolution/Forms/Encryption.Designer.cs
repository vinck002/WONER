namespace Evolution.Forms
{
    partial class Encryption
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Encryption));
            this.Encryptdata = new Telerik.WinControls.UI.RadTextBox();
            this.radTitleBar1 = new Telerik.WinControls.UI.RadTitleBar();
            this.bEncrypt = new Telerik.WinControls.UI.RadButton();
            this.radGroupBox1 = new Telerik.WinControls.UI.RadGroupBox();
            this.bExit = new Telerik.WinControls.UI.RadButton();
            this.bDecrypt = new Telerik.WinControls.UI.RadButton();
            this.Decryptdata = new Telerik.WinControls.UI.RadTextBox();
            ((System.ComponentModel.ISupportInitialize)(this.Encryptdata)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radTitleBar1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bEncrypt)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radGroupBox1)).BeginInit();
            this.radGroupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.bExit)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bDecrypt)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Decryptdata)).BeginInit();
            this.SuspendLayout();
            // 
            // Encryptdata
            // 
            this.Encryptdata.AutoSize = false;
            this.Encryptdata.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Encryptdata.Location = new System.Drawing.Point(12, 36);
            this.Encryptdata.Multiline = true;
            this.Encryptdata.Name = "Encryptdata";
            this.Encryptdata.NullText = "Type Here To Encryption";
            this.Encryptdata.Size = new System.Drawing.Size(568, 67);
            this.Encryptdata.TabIndex = 0;
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
            this.radTitleBar1.Size = new System.Drawing.Size(591, 30);
            this.radTitleBar1.TabIndex = 1;
            this.radTitleBar1.TabStop = false;
            this.radTitleBar1.Text = "Encryption";
            // 
            // bEncrypt
            // 
            this.bEncrypt.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bEncrypt.ForeColor = System.Drawing.Color.Black;
            this.bEncrypt.Location = new System.Drawing.Point(26, 9);
            this.bEncrypt.Name = "bEncrypt";
            this.bEncrypt.Size = new System.Drawing.Size(118, 38);
            this.bEncrypt.TabIndex = 2;
            this.bEncrypt.Text = "Encrypt";
            this.bEncrypt.Click += new System.EventHandler(this.bEncrypt_Click);
            // 
            // radGroupBox1
            // 
            this.radGroupBox1.AccessibleRole = System.Windows.Forms.AccessibleRole.Grouping;
            this.radGroupBox1.Controls.Add(this.bDecrypt);
            this.radGroupBox1.Controls.Add(this.bExit);
            this.radGroupBox1.Controls.Add(this.bEncrypt);
            this.radGroupBox1.HeaderText = "";
            this.radGroupBox1.Location = new System.Drawing.Point(127, 234);
            this.radGroupBox1.Name = "radGroupBox1";
            this.radGroupBox1.Size = new System.Drawing.Size(452, 70);
            this.radGroupBox1.TabIndex = 3;
            // 
            // bExit
            // 
            this.bExit.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bExit.ForeColor = System.Drawing.Color.Black;
            this.bExit.Location = new System.Drawing.Point(288, 9);
            this.bExit.Name = "bExit";
            this.bExit.Size = new System.Drawing.Size(118, 38);
            this.bExit.TabIndex = 3;
            this.bExit.Text = "Exit";
            this.bExit.Click += new System.EventHandler(this.bExit_Click);
            // 
            // bDecrypt
            // 
            this.bDecrypt.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bDecrypt.ForeColor = System.Drawing.Color.Black;
            this.bDecrypt.Location = new System.Drawing.Point(164, 9);
            this.bDecrypt.Name = "bDecrypt";
            this.bDecrypt.Size = new System.Drawing.Size(118, 38);
            this.bDecrypt.TabIndex = 4;
            this.bDecrypt.Text = "Decrypt";
            this.bDecrypt.Click += new System.EventHandler(this.bDecrypt_Click);
            // 
            // Decryptdata
            // 
            this.Decryptdata.AutoSize = false;
            this.Decryptdata.BackColor = System.Drawing.Color.LightCyan;
            this.Decryptdata.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Decryptdata.Location = new System.Drawing.Point(12, 109);
            this.Decryptdata.Multiline = true;
            this.Decryptdata.Name = "Decryptdata";
            this.Decryptdata.Size = new System.Drawing.Size(568, 119);
            this.Decryptdata.TabIndex = 4;
            // 
            // Encryption
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.PowderBlue;
            this.ClientSize = new System.Drawing.Size(591, 316);
            this.Controls.Add(this.Decryptdata);
            this.Controls.Add(this.radGroupBox1);
            this.Controls.Add(this.radTitleBar1);
            this.Controls.Add(this.Encryptdata);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Encryption";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Encryption";
            ((System.ComponentModel.ISupportInitialize)(this.Encryptdata)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radTitleBar1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bEncrypt)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radGroupBox1)).EndInit();
            this.radGroupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.bExit)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bDecrypt)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Decryptdata)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Telerik.WinControls.UI.RadTextBox Encryptdata;
        private Telerik.WinControls.UI.RadTitleBar radTitleBar1;
        private Telerik.WinControls.UI.RadButton bEncrypt;
        private Telerik.WinControls.UI.RadGroupBox radGroupBox1;
        private Telerik.WinControls.UI.RadButton bDecrypt;
        private Telerik.WinControls.UI.RadButton bExit;
        private Telerik.WinControls.UI.RadTextBox Decryptdata;
    }
}