namespace Forme
{
    partial class KreiranjeKupca
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
            this.NazivTextBox = new System.Windows.Forms.TextBox();
            this.PibTextBox = new System.Windows.Forms.TextBox();
            this.MaticniBrojTextBox = new System.Windows.Forms.TextBox();
            this.AdresaTextBox = new System.Windows.Forms.TextBox();
            this.SacuvajButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(13, 13);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(34, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Naziv";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(16, 41);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(24, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "PIB";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(16, 70);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(61, 13);
            this.label3.TabIndex = 2;
            this.label3.Text = "Matični broj";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(16, 104);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(40, 13);
            this.label4.TabIndex = 3;
            this.label4.Text = "Adresa";
            // 
            // NazivTextBox
            // 
            this.NazivTextBox.Location = new System.Drawing.Point(99, 13);
            this.NazivTextBox.Name = "NazivTextBox";
            this.NazivTextBox.Size = new System.Drawing.Size(173, 20);
            this.NazivTextBox.TabIndex = 4;
            // 
            // PibTextBox
            // 
            this.PibTextBox.Location = new System.Drawing.Point(99, 41);
            this.PibTextBox.Name = "PibTextBox";
            this.PibTextBox.Size = new System.Drawing.Size(173, 20);
            this.PibTextBox.TabIndex = 5;
            // 
            // MaticniBrojTextBox
            // 
            this.MaticniBrojTextBox.Location = new System.Drawing.Point(99, 70);
            this.MaticniBrojTextBox.Name = "MaticniBrojTextBox";
            this.MaticniBrojTextBox.Size = new System.Drawing.Size(173, 20);
            this.MaticniBrojTextBox.TabIndex = 6;
            // 
            // AdresaTextBox
            // 
            this.AdresaTextBox.Location = new System.Drawing.Point(99, 104);
            this.AdresaTextBox.Name = "AdresaTextBox";
            this.AdresaTextBox.Size = new System.Drawing.Size(173, 20);
            this.AdresaTextBox.TabIndex = 7;
            // 
            // SacuvajButton
            // 
            this.SacuvajButton.Location = new System.Drawing.Point(196, 140);
            this.SacuvajButton.Name = "SacuvajButton";
            this.SacuvajButton.Size = new System.Drawing.Size(75, 23);
            this.SacuvajButton.TabIndex = 8;
            this.SacuvajButton.Text = "Sačuvaj";
            this.SacuvajButton.UseVisualStyleBackColor = true;
            this.SacuvajButton.Click += new System.EventHandler(this.SacuvajButton_Click);
            // 
            // KreiranjeKupca
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 181);
            this.Controls.Add(this.SacuvajButton);
            this.Controls.Add(this.AdresaTextBox);
            this.Controls.Add(this.MaticniBrojTextBox);
            this.Controls.Add(this.PibTextBox);
            this.Controls.Add(this.NazivTextBox);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "KreiranjeKupca";
            this.Text = "KreiranjeKupca";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox NazivTextBox;
        private System.Windows.Forms.TextBox PibTextBox;
        private System.Windows.Forms.TextBox MaticniBrojTextBox;
        private System.Windows.Forms.TextBox AdresaTextBox;
        private System.Windows.Forms.Button SacuvajButton;
    }
}