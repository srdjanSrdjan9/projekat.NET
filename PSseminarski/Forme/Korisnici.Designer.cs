namespace Forme
{
    partial class Korisnici
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
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.DodajKorisnikaButton = new System.Windows.Forms.Button();
            this.BrisanjeKorisnikaButton = new System.Windows.Forms.Button();
            this.AzurirajKorisnikabButton = new System.Windows.Forms.Button();
            this.OsveziButton = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(12, 90);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(609, 233);
            this.dataGridView1.TabIndex = 0;
            // 
            // DodajKorisnikaButton
            // 
            this.DodajKorisnikaButton.Location = new System.Drawing.Point(13, 13);
            this.DodajKorisnikaButton.Name = "DodajKorisnikaButton";
            this.DodajKorisnikaButton.Size = new System.Drawing.Size(94, 23);
            this.DodajKorisnikaButton.TabIndex = 1;
            this.DodajKorisnikaButton.Text = "Dodaj korisnika";
            this.DodajKorisnikaButton.UseVisualStyleBackColor = true;
            this.DodajKorisnikaButton.Click += new System.EventHandler(this.DodajKorisnikaButton_Click);
            // 
            // BrisanjeKorisnikaButton
            // 
            this.BrisanjeKorisnikaButton.Location = new System.Drawing.Point(114, 12);
            this.BrisanjeKorisnikaButton.Name = "BrisanjeKorisnikaButton";
            this.BrisanjeKorisnikaButton.Size = new System.Drawing.Size(97, 23);
            this.BrisanjeKorisnikaButton.TabIndex = 2;
            this.BrisanjeKorisnikaButton.Text = "Obriši korisnika";
            this.BrisanjeKorisnikaButton.UseVisualStyleBackColor = true;
            this.BrisanjeKorisnikaButton.Click += new System.EventHandler(this.BrisanjeKorisnikaButton_Click);
            // 
            // AzurirajKorisnikabButton
            // 
            this.AzurirajKorisnikabButton.Location = new System.Drawing.Point(218, 12);
            this.AzurirajKorisnikabButton.Name = "AzurirajKorisnikabButton";
            this.AzurirajKorisnikabButton.Size = new System.Drawing.Size(95, 23);
            this.AzurirajKorisnikabButton.TabIndex = 3;
            this.AzurirajKorisnikabButton.Text = "Ažuriraj korisnika";
            this.AzurirajKorisnikabButton.UseVisualStyleBackColor = true;
            this.AzurirajKorisnikabButton.Click += new System.EventHandler(this.AzurirajKorisnikabButton_Click);
            // 
            // OsveziButton
            // 
            this.OsveziButton.Location = new System.Drawing.Point(319, 12);
            this.OsveziButton.Name = "OsveziButton";
            this.OsveziButton.Size = new System.Drawing.Size(94, 23);
            this.OsveziButton.TabIndex = 4;
            this.OsveziButton.Text = "Osveži podatke";
            this.OsveziButton.UseVisualStyleBackColor = true;
            this.OsveziButton.Click += new System.EventHandler(this.OsveziButton_Click);
            // 
            // Korisnici
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(633, 335);
            this.Controls.Add(this.OsveziButton);
            this.Controls.Add(this.AzurirajKorisnikabButton);
            this.Controls.Add(this.BrisanjeKorisnikaButton);
            this.Controls.Add(this.DodajKorisnikaButton);
            this.Controls.Add(this.dataGridView1);
            this.Name = "Korisnici";
            this.Text = "Korisnici";
            this.Load += new System.EventHandler(this.Korisnici_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Button DodajKorisnikaButton;
        private System.Windows.Forms.Button BrisanjeKorisnikaButton;
        private System.Windows.Forms.Button AzurirajKorisnikabButton;
        private System.Windows.Forms.Button OsveziButton;
    }
}