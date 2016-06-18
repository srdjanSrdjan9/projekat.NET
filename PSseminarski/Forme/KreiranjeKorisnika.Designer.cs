namespace Forme
{
    partial class KreiranjeKorisnika
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
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.ImeTextBox = new System.Windows.Forms.TextBox();
            this.PrezimeTextBox = new System.Windows.Forms.TextBox();
            this.AdresaTextBox = new System.Windows.Forms.TextBox();
            this.JmbgTextBox = new System.Windows.Forms.TextBox();
            this.SacuvajButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(13, 13);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(24, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Ime";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(13, 43);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(44, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Prezime";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(13, 71);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(40, 13);
            this.label3.TabIndex = 2;
            this.label3.Text = "Adresa";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(13, 104);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(36, 13);
            this.label4.TabIndex = 3;
            this.label4.Text = "JMBG";
            // 
            // ImeTextBox
            // 
            this.ImeTextBox.Location = new System.Drawing.Point(85, 13);
            this.ImeTextBox.Name = "ImeTextBox";
            this.ImeTextBox.Size = new System.Drawing.Size(187, 20);
            this.ImeTextBox.TabIndex = 4;
            // 
            // PrezimeTextBox
            // 
            this.PrezimeTextBox.Location = new System.Drawing.Point(85, 43);
            this.PrezimeTextBox.Name = "PrezimeTextBox";
            this.PrezimeTextBox.Size = new System.Drawing.Size(187, 20);
            this.PrezimeTextBox.TabIndex = 5;
            // 
            // AdresaTextBox
            // 
            this.AdresaTextBox.Location = new System.Drawing.Point(85, 71);
            this.AdresaTextBox.Name = "AdresaTextBox";
            this.AdresaTextBox.Size = new System.Drawing.Size(187, 20);
            this.AdresaTextBox.TabIndex = 6;
            // 
            // JmbgTextBox
            // 
            this.JmbgTextBox.Location = new System.Drawing.Point(85, 104);
            this.JmbgTextBox.MaxLength = 13;
            this.JmbgTextBox.Name = "JmbgTextBox";
            this.JmbgTextBox.Size = new System.Drawing.Size(187, 20);
            this.JmbgTextBox.TabIndex = 7;
            // 
            // SacuvajButton
            // 
            this.SacuvajButton.Location = new System.Drawing.Point(196, 141);
            this.SacuvajButton.Name = "SacuvajButton";
            this.SacuvajButton.Size = new System.Drawing.Size(75, 23);
            this.SacuvajButton.TabIndex = 8;
            this.SacuvajButton.Text = "Sačuvaj";
            this.SacuvajButton.UseVisualStyleBackColor = true;
            this.SacuvajButton.Click += new System.EventHandler(this.SacuvajButton_Click);
            // 
            // KreiranjeKorisnika
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 194);
            this.Controls.Add(this.SacuvajButton);
            this.Controls.Add(this.JmbgTextBox);
            this.Controls.Add(this.AdresaTextBox);
            this.Controls.Add(this.PrezimeTextBox);
            this.Controls.Add(this.ImeTextBox);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "KreiranjeKorisnika";
            this.Text = "Kreiranje korisnika";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox ImeTextBox;
        private System.Windows.Forms.TextBox PrezimeTextBox;
        private System.Windows.Forms.TextBox AdresaTextBox;
        private System.Windows.Forms.TextBox JmbgTextBox;
        private System.Windows.Forms.Button SacuvajButton;
    }
}