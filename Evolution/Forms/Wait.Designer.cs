namespace Evolution.Forms
{
    partial class Wait
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Wait));
            this.breezeTheme1 = new Telerik.WinControls.Themes.BreezeTheme();
            this.lineRingWaitingBarIndicatorElement1 = new Telerik.WinControls.UI.LineRingWaitingBarIndicatorElement();
            this.radWaitingBar1 = new Telerik.WinControls.UI.RadWaitingBar();
            this.lineRingWaitingBarIndicatorElement2 = new Telerik.WinControls.UI.LineRingWaitingBarIndicatorElement();
            this.radLabel1 = new Telerik.WinControls.UI.RadLabel();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.radWaitingBar1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel1)).BeginInit();
            this.SuspendLayout();
            // 
            // lineRingWaitingBarIndicatorElement1
            // 
            this.lineRingWaitingBarIndicatorElement1.AutoSize = false;
            this.lineRingWaitingBarIndicatorElement1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(59)))), ((int)(((byte)(242)))), ((int)(((byte)(135)))));
            this.lineRingWaitingBarIndicatorElement1.BackColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(171)))), ((int)(((byte)(43)))));
            this.lineRingWaitingBarIndicatorElement1.BackColor3 = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(135)))), ((int)(((byte)(38)))));
            this.lineRingWaitingBarIndicatorElement1.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(162)))), ((int)(((byte)(57)))));
            this.lineRingWaitingBarIndicatorElement1.BorderColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(35)))), ((int)(((byte)(173)))), ((int)(((byte)(67)))));
            this.lineRingWaitingBarIndicatorElement1.BorderColor3 = System.Drawing.Color.FromArgb(((int)(((byte)(19)))), ((int)(((byte)(200)))), ((int)(((byte)(29)))));
            this.lineRingWaitingBarIndicatorElement1.Bounds = new System.Drawing.Rectangle(0, 0, 150, 150);
            this.lineRingWaitingBarIndicatorElement1.DisabledTextRenderingHint = System.Drawing.Text.TextRenderingHint.SystemDefault;
            this.lineRingWaitingBarIndicatorElement1.ElementColor = System.Drawing.Color.FromArgb(((int)(((byte)(19)))), ((int)(((byte)(166)))), ((int)(((byte)(39)))));
            this.lineRingWaitingBarIndicatorElement1.ElementColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(18)))), ((int)(((byte)(147)))), ((int)(((byte)(56)))));
            this.lineRingWaitingBarIndicatorElement1.ElementColor3 = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(161)))), ((int)(((byte)(54)))));
            this.lineRingWaitingBarIndicatorElement1.Name = "lineRingWaitingBarIndicatorElement1";
            this.lineRingWaitingBarIndicatorElement1.Text = "Please Wait";
            this.lineRingWaitingBarIndicatorElement1.TextAlignment = System.Drawing.ContentAlignment.BottomCenter;
            this.lineRingWaitingBarIndicatorElement1.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.lineRingWaitingBarIndicatorElement1.TextRenderingHint = System.Drawing.Text.TextRenderingHint.SystemDefault;
            this.lineRingWaitingBarIndicatorElement1.TextWrap = true;
            this.lineRingWaitingBarIndicatorElement1.UseCompatibleTextRendering = false;
            // 
            // radWaitingBar1
            // 
            this.radWaitingBar1.Location = new System.Drawing.Point(12, 12);
            this.radWaitingBar1.Name = "radWaitingBar1";
            this.radWaitingBar1.Size = new System.Drawing.Size(70, 70);
            this.radWaitingBar1.TabIndex = 0;
            this.radWaitingBar1.Text = "radWaitingBar1";
            this.radWaitingBar1.WaitingIndicators.Add(this.lineRingWaitingBarIndicatorElement2);
            this.radWaitingBar1.WaitingSpeed = 50;
            this.radWaitingBar1.WaitingStyle = Telerik.WinControls.Enumerations.WaitingBarStyles.LineRing;
            // 
            // lineRingWaitingBarIndicatorElement2
            // 
            this.lineRingWaitingBarIndicatorElement2.AutoSize = false;
            this.lineRingWaitingBarIndicatorElement2.Bounds = new System.Drawing.Rectangle(0, 0, 90, 70);
            this.lineRingWaitingBarIndicatorElement2.ElementColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(167)))), ((int)(((byte)(71)))));
            this.lineRingWaitingBarIndicatorElement2.ElementColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(242)))), ((int)(((byte)(66)))), ((int)(((byte)(13)))));
            this.lineRingWaitingBarIndicatorElement2.ElementColor3 = System.Drawing.Color.FromArgb(((int)(((byte)(244)))), ((int)(((byte)(233)))), ((int)(((byte)(26)))));
            this.lineRingWaitingBarIndicatorElement2.Name = "lineRingWaitingBarIndicatorElement2";
            // 
            // radLabel1
            // 
            this.radLabel1.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.radLabel1.ForeColor = System.Drawing.Color.Green;
            this.radLabel1.Location = new System.Drawing.Point(12, 88);
            this.radLabel1.Name = "radLabel1";
            this.radLabel1.Size = new System.Drawing.Size(92, 25);
            this.radLabel1.TabIndex = 1;
            this.radLabel1.Text = "Please Wait";
            // 
            // timer1
            // 
            this.timer1.Enabled = true;
            // 
            // Wait
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(113, 128);
            this.Controls.Add(this.radLabel1);
            this.Controls.Add(this.radWaitingBar1);
            this.DoubleBuffered = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.KeyPreview = true;
            this.Name = "Wait";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Load += new System.EventHandler(this.Wait_Load);
            this.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.Wait_KeyPress);
            ((System.ComponentModel.ISupportInitialize)(this.radWaitingBar1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private Telerik.WinControls.Themes.BreezeTheme breezeTheme1;
        private Telerik.WinControls.UI.LineRingWaitingBarIndicatorElement lineRingWaitingBarIndicatorElement1;
        private Telerik.WinControls.UI.RadWaitingBar radWaitingBar1;
        private Telerik.WinControls.UI.LineRingWaitingBarIndicatorElement lineRingWaitingBarIndicatorElement2;
        private Telerik.WinControls.UI.RadLabel radLabel1;
        private System.Windows.Forms.Timer timer1;
    }
}