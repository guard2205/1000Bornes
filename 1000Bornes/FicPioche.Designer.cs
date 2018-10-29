namespace _1000Bornes
{
    partial class EcranPioche
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
            this.btnPiocher = new System.Windows.Forms.Button();
            this.btnAnnuler = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnPiocher
            // 
            this.btnPiocher.Location = new System.Drawing.Point(12, 12);
            this.btnPiocher.Name = "btnPiocher";
            this.btnPiocher.Size = new System.Drawing.Size(137, 36);
            this.btnPiocher.TabIndex = 0;
            this.btnPiocher.Text = "Piocher";
            this.btnPiocher.UseVisualStyleBackColor = true;
            this.btnPiocher.Click += new System.EventHandler(this.btnPiocher_Click);
            // 
            // btnAnnuler
            // 
            this.btnAnnuler.Location = new System.Drawing.Point(12, 54);
            this.btnAnnuler.Name = "btnAnnuler";
            this.btnAnnuler.Size = new System.Drawing.Size(137, 36);
            this.btnAnnuler.TabIndex = 1;
            this.btnAnnuler.Text = "Annuler";
            this.btnAnnuler.UseVisualStyleBackColor = true;
            this.btnAnnuler.Click += new System.EventHandler(this.btnAnnuler_Click);
            // 
            // EcranPioche
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(157, 99);
            this.Controls.Add(this.btnAnnuler);
            this.Controls.Add(this.btnPiocher);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "EcranPioche";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Pioche";
            this.Load += new System.EventHandler(this.Pioche_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnPiocher;
        private System.Windows.Forms.Button btnAnnuler;
    }
}