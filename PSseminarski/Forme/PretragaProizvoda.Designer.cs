namespace Forme
{
    partial class PretragaProizvoda
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
            this.RobaComboBox = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.PrimljenoTextBox = new System.Windows.Forms.TextBox();
            this.ProdatoTextBox = new System.Windows.Forms.TextBox();
            this.DajStanjeButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(13, 13);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(33, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Roba";
            // 
            // RobaComboBox
            // 
            this.RobaComboBox.FormattingEnabled = true;
            this.RobaComboBox.Location = new System.Drawing.Point(76, 13);
            this.RobaComboBox.Name = "RobaComboBox";
            this.RobaComboBox.Size = new System.Drawing.Size(260, 21);
            this.RobaComboBox.TabIndex = 1;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(16, 56);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(49, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Primljeno";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(19, 99);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(44, 13);
            this.label3.TabIndex = 3;
            this.label3.Text = "Prodato";
            // 
            // PrimljenoTextBox
            // 
            this.PrimljenoTextBox.Location = new System.Drawing.Point(108, 56);
            this.PrimljenoTextBox.Name = "PrimljenoTextBox";
            this.PrimljenoTextBox.Size = new System.Drawing.Size(100, 20);
            this.PrimljenoTextBox.TabIndex = 4;
            // 
            // ProdatoTextBox
            // 
            this.ProdatoTextBox.Location = new System.Drawing.Point(108, 99);
            this.ProdatoTextBox.Name = "ProdatoTextBox";
            this.ProdatoTextBox.Size = new System.Drawing.Size(100, 20);
            this.ProdatoTextBox.TabIndex = 5;
            // 
            // DajStanjeButton
            // 
            this.DajStanjeButton.Location = new System.Drawing.Point(16, 146);
            this.DajStanjeButton.Name = "DajStanjeButton";
            this.DajStanjeButton.Size = new System.Drawing.Size(91, 23);
            this.DajStanjeButton.TabIndex = 6;
            this.DajStanjeButton.Text = "Proveri stanje";
            this.DajStanjeButton.UseVisualStyleBackColor = true;
            this.DajStanjeButton.Click += new System.EventHandler(this.DajStanjeButton_Click);
            // 
            // PretragaProizvoda
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(348, 261);
            this.Controls.Add(this.DajStanjeButton);
            this.Controls.Add(this.ProdatoTextBox);
            this.Controls.Add(this.PrimljenoTextBox);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.RobaComboBox);
            this.Controls.Add(this.label1);
            this.Name = "PretragaProizvoda";
            this.Text = "PretragaProizvoda";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox RobaComboBox;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox PrimljenoTextBox;
        private System.Windows.Forms.TextBox ProdatoTextBox;
        private System.Windows.Forms.Button DajStanjeButton;
    }
}