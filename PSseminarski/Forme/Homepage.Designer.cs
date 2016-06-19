namespace Forme
{
    partial class Homepage
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
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.dokumentiToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.prijemniceToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.otpremniceToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.reversToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.klijentiToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.korisniciToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.dobavljačiToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.kupciToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.dokumentiToolStripMenuItem,
            this.klijentiToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(435, 24);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // dokumentiToolStripMenuItem
            // 
            this.dokumentiToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.prijemniceToolStripMenuItem,
            this.otpremniceToolStripMenuItem,
            this.reversToolStripMenuItem});
            this.dokumentiToolStripMenuItem.Name = "dokumentiToolStripMenuItem";
            this.dokumentiToolStripMenuItem.Size = new System.Drawing.Size(78, 20);
            this.dokumentiToolStripMenuItem.Text = "Dokumenti";
            // 
            // prijemniceToolStripMenuItem
            // 
            this.prijemniceToolStripMenuItem.Name = "prijemniceToolStripMenuItem";
            this.prijemniceToolStripMenuItem.Size = new System.Drawing.Size(137, 22);
            this.prijemniceToolStripMenuItem.Text = "Prijemnice";
            // 
            // otpremniceToolStripMenuItem
            // 
            this.otpremniceToolStripMenuItem.Name = "otpremniceToolStripMenuItem";
            this.otpremniceToolStripMenuItem.Size = new System.Drawing.Size(137, 22);
            this.otpremniceToolStripMenuItem.Text = "Otpremnice";
            // 
            // reversToolStripMenuItem
            // 
            this.reversToolStripMenuItem.Name = "reversToolStripMenuItem";
            this.reversToolStripMenuItem.Size = new System.Drawing.Size(137, 22);
            this.reversToolStripMenuItem.Text = "Revers";
            // 
            // klijentiToolStripMenuItem
            // 
            this.klijentiToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.korisniciToolStripMenuItem,
            this.dobavljačiToolStripMenuItem,
            this.kupciToolStripMenuItem});
            this.klijentiToolStripMenuItem.Name = "klijentiToolStripMenuItem";
            this.klijentiToolStripMenuItem.Size = new System.Drawing.Size(55, 20);
            this.klijentiToolStripMenuItem.Text = "Klijenti";
            // 
            // korisniciToolStripMenuItem
            // 
            this.korisniciToolStripMenuItem.Name = "korisniciToolStripMenuItem";
            this.korisniciToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.korisniciToolStripMenuItem.Text = "Korisnici";
            this.korisniciToolStripMenuItem.Click += new System.EventHandler(this.korisniciToolStripMenuItem_Click);
            // 
            // dobavljačiToolStripMenuItem
            // 
            this.dobavljačiToolStripMenuItem.Name = "dobavljačiToolStripMenuItem";
            this.dobavljačiToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.dobavljačiToolStripMenuItem.Text = "Dobavljači";
            this.dobavljačiToolStripMenuItem.Click += new System.EventHandler(this.dobavljačiToolStripMenuItem_Click);
            // 
            // kupciToolStripMenuItem
            // 
            this.kupciToolStripMenuItem.Name = "kupciToolStripMenuItem";
            this.kupciToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.kupciToolStripMenuItem.Text = "Kupci";
            this.kupciToolStripMenuItem.Click += new System.EventHandler(this.kupciToolStripMenuItem_Click);
            // 
            // Homepage
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(435, 261);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "Homepage";
            this.Text = "Homepage";
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem dokumentiToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem prijemniceToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem otpremniceToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem reversToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem klijentiToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem korisniciToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem dobavljačiToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem kupciToolStripMenuItem;
    }
}