namespace _1000Bornes
{
    partial class FicMenu
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
            this.btnNouvellePartie = new System.Windows.Forms.Button();
            this.btnCharger = new System.Windows.Forms.Button();
            this.btnQuitter = new System.Windows.Forms.Button();
            this.dlgOuvrir = new System.Windows.Forms.OpenFileDialog();
            this.SuspendLayout();
            // 
            // btnNouvellePartie
            // 
            this.btnNouvellePartie.Location = new System.Drawing.Point(11, 12);
            this.btnNouvellePartie.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnNouvellePartie.Name = "btnNouvellePartie";
            this.btnNouvellePartie.Size = new System.Drawing.Size(608, 85);
            this.btnNouvellePartie.TabIndex = 0;
            this.btnNouvellePartie.Text = "Nouvelle Partie";
            this.btnNouvellePartie.UseVisualStyleBackColor = true;
            this.btnNouvellePartie.Click += new System.EventHandler(this.btnNouvellePartie_Click);
            // 
            // btnCharger
            // 
            this.btnCharger.Location = new System.Drawing.Point(12, 103);
            this.btnCharger.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnCharger.Name = "btnCharger";
            this.btnCharger.Size = new System.Drawing.Size(608, 85);
            this.btnCharger.TabIndex = 1;
            this.btnCharger.Text = "Charger une partie";
            this.btnCharger.UseVisualStyleBackColor = true;
            this.btnCharger.Click += new System.EventHandler(this.btnCharger_Click);
            // 
            // btnQuitter
            // 
            this.btnQuitter.Location = new System.Drawing.Point(12, 194);
            this.btnQuitter.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnQuitter.Name = "btnQuitter";
            this.btnQuitter.Size = new System.Drawing.Size(608, 85);
            this.btnQuitter.TabIndex = 2;
            this.btnQuitter.Text = "Quitter";
            this.btnQuitter.UseVisualStyleBackColor = true;
            this.btnQuitter.Click += new System.EventHandler(this.btnQuitter_Click);
            // 
            // dlgOuvrir
            // 
            this.dlgOuvrir.FileName = "openFileDialog1";
            // 
            // FicMenu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(631, 287);
            this.Controls.Add(this.btnQuitter);
            this.Controls.Add(this.btnCharger);
            this.Controls.Add(this.btnNouvellePartie);
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "FicMenu";
            this.Text = "FicMenu";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnNouvellePartie;
        private System.Windows.Forms.Button btnCharger;
        private System.Windows.Forms.Button btnQuitter;
        private System.Windows.Forms.OpenFileDialog dlgOuvrir;
    }
}