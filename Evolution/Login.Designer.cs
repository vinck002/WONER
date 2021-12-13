namespace Evolution
{
    partial class Login
    {
        /// <summary>
        /// Variable del diseñador necesaria.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpiar los recursos que se estén usando.
        /// </summary>
        /// <param name="disposing">true si los recursos administrados se deben desechar; false en caso contrario.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código generado por el Diseñador de Windows Forms

        /// <summary>
        /// Método necesario para admitir el Diseñador. No se puede modificar
        /// el contenido de este método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Login));
            this.user = new Telerik.WinControls.UI.RadTextBox();
            this.password = new Telerik.WinControls.UI.RadTextBox();
            this.Btnlogin = new Telerik.WinControls.UI.RadButton();
            this.Btnquit = new Telerik.WinControls.UI.RadButton();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.breezeTheme1 = new Telerik.WinControls.Themes.BreezeTheme();
            this.radSpellChecker1 = new Telerik.WinControls.UI.RadSpellChecker();
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            ((System.ComponentModel.ISupportInitialize)(this.user)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.password)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Btnlogin)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Btnquit)).BeginInit();
            this.SuspendLayout();
            // 
            // user
            // 
            this.user.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.user.Font = new System.Drawing.Font("Arial", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.user.Location = new System.Drawing.Point(158, 42);
            this.user.Name = "user";
            this.user.Size = new System.Drawing.Size(280, 32);
            this.user.TabIndex = 0;
            this.user.ThemeName = "Breeze";
            ((Telerik.WinControls.UI.RadTextBoxElement)(this.user.GetChildAt(0))).Text = "";
            ((Telerik.WinControls.Primitives.BorderPrimitive)(this.user.GetChildAt(0).GetChildAt(2))).ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(207)))), ((int)(((byte)(207)))), ((int)(((byte)(207)))));
            // 
            // password
            // 
            this.password.Font = new System.Drawing.Font("Arial", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.password.Location = new System.Drawing.Point(158, 79);
            this.password.Name = "password";
            this.password.PasswordChar = '|';
            this.password.Size = new System.Drawing.Size(280, 32);
            this.password.TabIndex = 1;
            this.password.ThemeName = "Breeze";
            // 
            // Btnlogin
            // 
            this.Btnlogin.BackColor = System.Drawing.Color.White;
            this.Btnlogin.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Btnlogin.ForeColor = System.Drawing.Color.White;
            this.Btnlogin.Image = global::Evolution.Properties.Resources.User;
            this.Btnlogin.Location = new System.Drawing.Point(444, 42);
            this.Btnlogin.Name = "Btnlogin";
            this.Btnlogin.Size = new System.Drawing.Size(110, 30);
            this.Btnlogin.TabIndex = 2;
            this.Btnlogin.Text = "Login";
            this.Btnlogin.ThemeName = "Breeze";
            this.Btnlogin.Click += new System.EventHandler(this.Btnlogin_Click);
            ((Telerik.WinControls.UI.RadButtonElement)(this.Btnlogin.GetChildAt(0))).Image = global::Evolution.Properties.Resources.User;
            ((Telerik.WinControls.UI.RadButtonElement)(this.Btnlogin.GetChildAt(0))).Text = "Login";
            ((Telerik.WinControls.Primitives.FillPrimitive)(this.Btnlogin.GetChildAt(0).GetChildAt(0))).BackColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(70)))), ((int)(((byte)(193)))), ((int)(((byte)(98)))));
            ((Telerik.WinControls.Primitives.FillPrimitive)(this.Btnlogin.GetChildAt(0).GetChildAt(0))).BackColor3 = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(204)))), ((int)(((byte)(118)))));
            ((Telerik.WinControls.Primitives.FillPrimitive)(this.Btnlogin.GetChildAt(0).GetChildAt(0))).BackColor4 = System.Drawing.Color.FromArgb(((int)(((byte)(73)))), ((int)(((byte)(201)))), ((int)(((byte)(31)))));
            ((Telerik.WinControls.Primitives.FillPrimitive)(this.Btnlogin.GetChildAt(0).GetChildAt(0))).BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(206)))), ((int)(((byte)(48)))));
            ((Telerik.WinControls.Primitives.ImagePrimitive)(this.Btnlogin.GetChildAt(0).GetChildAt(1).GetChildAt(0))).BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            ((Telerik.WinControls.Primitives.ImagePrimitive)(this.Btnlogin.GetChildAt(0).GetChildAt(1).GetChildAt(0))).AutoSize = false;
            ((Telerik.WinControls.Primitives.TextPrimitive)(this.Btnlogin.GetChildAt(0).GetChildAt(1).GetChildAt(1))).LineLimit = false;
            ((Telerik.WinControls.Primitives.TextPrimitive)(this.Btnlogin.GetChildAt(0).GetChildAt(1).GetChildAt(1))).BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(185)))), ((int)(((byte)(71)))));
            ((Telerik.WinControls.Primitives.TextPrimitive)(this.Btnlogin.GetChildAt(0).GetChildAt(1).GetChildAt(1))).Alignment = System.Drawing.ContentAlignment.MiddleCenter;
            ((Telerik.WinControls.Primitives.BorderPrimitive)(this.Btnlogin.GetChildAt(0).GetChildAt(2))).InnerColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(156)))), ((int)(((byte)(46)))));
            ((Telerik.WinControls.Primitives.BorderPrimitive)(this.Btnlogin.GetChildAt(0).GetChildAt(2))).ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(35)))), ((int)(((byte)(181)))), ((int)(((byte)(61)))));
            ((Telerik.WinControls.Primitives.BorderPrimitive)(this.Btnlogin.GetChildAt(0).GetChildAt(2))).BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(203)))), ((int)(((byte)(49)))));
            // 
            // Btnquit
            // 
            this.Btnquit.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.Btnquit.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Btnquit.ForeColor = System.Drawing.Color.White;
            this.Btnquit.Image = global::Evolution.Properties.Resources.salir;
            this.Btnquit.Location = new System.Drawing.Point(444, 79);
            this.Btnquit.Name = "Btnquit";
            this.Btnquit.Size = new System.Drawing.Size(110, 30);
            this.Btnquit.TabIndex = 3;
            this.Btnquit.Text = "Quit";
            this.Btnquit.Click += new System.EventHandler(this.Btnquit_Click);
            ((Telerik.WinControls.UI.RadButtonElement)(this.Btnquit.GetChildAt(0))).Image = global::Evolution.Properties.Resources.salir;
            ((Telerik.WinControls.UI.RadButtonElement)(this.Btnquit.GetChildAt(0))).Text = "Quit";
            ((Telerik.WinControls.Primitives.ImagePrimitive)(this.Btnquit.GetChildAt(0).GetChildAt(1).GetChildAt(0))).AutoSize = false;
            ((Telerik.WinControls.Primitives.BorderPrimitive)(this.Btnquit.GetChildAt(0).GetChildAt(2))).ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(186)))), ((int)(((byte)(11)))), ((int)(((byte)(16)))));
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Black;
            this.label1.Location = new System.Drawing.Point(38, 45);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(114, 24);
            this.label1.TabIndex = 4;
            this.label1.Text = "User Name";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.Black;
            this.label2.Location = new System.Drawing.Point(52, 80);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(100, 24);
            this.label2.TabIndex = 5;
            this.label2.Text = "Password";
            // 
            // backgroundWorker1
            // 
            this.backgroundWorker1.DoWork += new System.ComponentModel.DoWorkEventHandler(this.backgroundWorker1_DoWork);
            // 
            // Login
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(579, 157);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.Btnquit);
            this.Controls.Add(this.Btnlogin);
            this.Controls.Add(this.password);
            this.Controls.Add(this.user);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.KeyPreview = true;
            this.Name = "Login";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Login";
            this.TransparencyKey = System.Drawing.Color.Teal;
            this.Activated += new System.EventHandler(this.Login_Activated);
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
            this.Load += new System.EventHandler(this.Form1_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Login_KeyDown);
            this.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.Form1_KeyPress);
            ((System.ComponentModel.ISupportInitialize)(this.user)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.password)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Btnlogin)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Btnquit)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Telerik.WinControls.UI.RadTextBox user;
        private Telerik.WinControls.UI.RadTextBox password;
        private Telerik.WinControls.UI.RadButton Btnlogin;
        private Telerik.WinControls.UI.RadButton Btnquit;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private Telerik.WinControls.Themes.BreezeTheme breezeTheme1;
        private Telerik.WinControls.UI.RadSpellChecker radSpellChecker1;
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
    }
}

