namespace _1000Bornes
{
    partial class FicJeux
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
            this.btnStart = new System.Windows.Forms.Button();
            this.btnPioche = new System.Windows.Forms.Button();
            this.btnTerminerTour = new System.Windows.Forms.Button();
            this.gbMenu = new System.Windows.Forms.GroupBox();
            this.btnSauvegarde = new System.Windows.Forms.Button();
            this.gbInfo = new System.Windows.Forms.GroupBox();
            this.lblNbrCarteJ2 = new System.Windows.Forms.Label();
            this.lblNbrCarteJ1 = new System.Windows.Forms.Label();
            this.lblNbrCartes = new System.Windows.Forms.Label();
            this.lblInfoTour = new System.Windows.Forms.Label();
            this.btnTest = new System.Windows.Forms.Button();
            this.btntest2 = new System.Windows.Forms.Button();
            this.lblTextKmJ1 = new System.Windows.Forms.Label();
            this.LblKmJ1 = new System.Windows.Forms.Label();
            this.LblKmJ2 = new System.Windows.Forms.Label();
            this.lblKmTextJ2 = new System.Windows.Forms.Label();
            this.gbJ1 = new System.Windows.Forms.GroupBox();
            this.gbJ2 = new System.Windows.Forms.GroupBox();
            this.lblPioche = new System.Windows.Forms.Label();
            this.lblFausse = new System.Windows.Forms.Label();
            this.lblBrule = new System.Windows.Forms.Label();
            this.dlgSauvegarde = new System.Windows.Forms.SaveFileDialog();
            this.gbMenu.SuspendLayout();
            this.gbInfo.SuspendLayout();
            this.gbJ1.SuspendLayout();
            this.gbJ2.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnStart
            // 
            this.btnStart.Location = new System.Drawing.Point(5, 21);
            this.btnStart.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnStart.Name = "btnStart";
            this.btnStart.Size = new System.Drawing.Size(93, 68);
            this.btnStart.TabIndex = 0;
            this.btnStart.Text = "Commencer la partie";
            this.btnStart.UseVisualStyleBackColor = true;
            this.btnStart.Click += new System.EventHandler(this.btnStart_Click);
            // 
            // btnPioche
            // 
            this.btnPioche.Location = new System.Drawing.Point(5, 95);
            this.btnPioche.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnPioche.Name = "btnPioche";
            this.btnPioche.Size = new System.Drawing.Size(93, 68);
            this.btnPioche.TabIndex = 1;
            this.btnPioche.Text = "Pioche";
            this.btnPioche.UseVisualStyleBackColor = true;
            this.btnPioche.Click += new System.EventHandler(this.btnPioche_Click);
            // 
            // btnTerminerTour
            // 
            this.btnTerminerTour.Location = new System.Drawing.Point(5, 169);
            this.btnTerminerTour.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnTerminerTour.Name = "btnTerminerTour";
            this.btnTerminerTour.Size = new System.Drawing.Size(93, 68);
            this.btnTerminerTour.TabIndex = 2;
            this.btnTerminerTour.Text = "Terminer le tour";
            this.btnTerminerTour.UseVisualStyleBackColor = true;
            this.btnTerminerTour.Click += new System.EventHandler(this.btnTerminerTour_Click);
            // 
            // gbMenu
            // 
            this.gbMenu.Controls.Add(this.btnSauvegarde);
            this.gbMenu.Controls.Add(this.btnStart);
            this.gbMenu.Controls.Add(this.btnTerminerTour);
            this.gbMenu.Controls.Add(this.btnPioche);
            this.gbMenu.Location = new System.Drawing.Point(12, 71);
            this.gbMenu.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.gbMenu.Name = "gbMenu";
            this.gbMenu.Padding = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.gbMenu.Size = new System.Drawing.Size(105, 316);
            this.gbMenu.TabIndex = 3;
            this.gbMenu.TabStop = false;
            this.gbMenu.Text = "Menu";
            // 
            // btnSauvegarde
            // 
            this.btnSauvegarde.Location = new System.Drawing.Point(5, 241);
            this.btnSauvegarde.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnSauvegarde.Name = "btnSauvegarde";
            this.btnSauvegarde.Size = new System.Drawing.Size(93, 68);
            this.btnSauvegarde.TabIndex = 3;
            this.btnSauvegarde.Text = "SAVE";
            this.btnSauvegarde.UseVisualStyleBackColor = true;
            this.btnSauvegarde.Click += new System.EventHandler(this.btnSauvegarde_Click);
            // 
            // gbInfo
            // 
            this.gbInfo.Controls.Add(this.lblNbrCarteJ2);
            this.gbInfo.Controls.Add(this.lblNbrCarteJ1);
            this.gbInfo.Controls.Add(this.lblNbrCartes);
            this.gbInfo.Controls.Add(this.lblInfoTour);
            this.gbInfo.Location = new System.Drawing.Point(12, 513);
            this.gbInfo.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.gbInfo.Name = "gbInfo";
            this.gbInfo.Padding = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.gbInfo.Size = new System.Drawing.Size(105, 114);
            this.gbInfo.TabIndex = 4;
            this.gbInfo.TabStop = false;
            this.gbInfo.Text = "Informations";
            // 
            // lblNbrCarteJ2
            // 
            this.lblNbrCarteJ2.AutoSize = true;
            this.lblNbrCarteJ2.Location = new System.Drawing.Point(5, 90);
            this.lblNbrCarteJ2.Name = "lblNbrCarteJ2";
            this.lblNbrCarteJ2.Size = new System.Drawing.Size(69, 17);
            this.lblNbrCarteJ2.TabIndex = 3;
            this.lblNbrCarteJ2.Text = "Carte J2 :";
            // 
            // lblNbrCarteJ1
            // 
            this.lblNbrCarteJ1.AutoSize = true;
            this.lblNbrCarteJ1.Location = new System.Drawing.Point(5, 73);
            this.lblNbrCarteJ1.Name = "lblNbrCarteJ1";
            this.lblNbrCarteJ1.Size = new System.Drawing.Size(69, 17);
            this.lblNbrCarteJ1.TabIndex = 2;
            this.lblNbrCarteJ1.Text = "Carte J1 :";
            // 
            // lblNbrCartes
            // 
            this.lblNbrCartes.AutoSize = true;
            this.lblNbrCartes.Location = new System.Drawing.Point(5, 46);
            this.lblNbrCartes.Name = "lblNbrCartes";
            this.lblNbrCartes.Size = new System.Drawing.Size(85, 17);
            this.lblNbrCartes.TabIndex = 1;
            this.lblNbrCartes.Text = "106 Cartes  ";
            // 
            // lblInfoTour
            // 
            this.lblInfoTour.AutoSize = true;
            this.lblInfoTour.Location = new System.Drawing.Point(5, 18);
            this.lblInfoTour.Name = "lblInfoTour";
            this.lblInfoTour.Size = new System.Drawing.Size(58, 17);
            this.lblInfoTour.TabIndex = 0;
            this.lblInfoTour.Text = "Tour : 0";
            // 
            // btnTest
            // 
            this.btnTest.Location = new System.Drawing.Point(19, 406);
            this.btnTest.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnTest.Name = "btnTest";
            this.btnTest.Size = new System.Drawing.Size(93, 46);
            this.btnTest.TabIndex = 54;
            this.btnTest.Text = "remove";
            this.btnTest.UseVisualStyleBackColor = true;
            this.btnTest.Click += new System.EventHandler(this.btnTest_Click);
            // 
            // btntest2
            // 
            this.btntest2.Location = new System.Drawing.Point(19, 458);
            this.btntest2.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btntest2.Name = "btntest2";
            this.btntest2.Size = new System.Drawing.Size(93, 46);
            this.btntest2.TabIndex = 78;
            this.btntest2.Text = "relocalisation";
            this.btntest2.UseVisualStyleBackColor = true;
            this.btntest2.Click += new System.EventHandler(this.btntest2_Click);
            // 
            // lblTextKmJ1
            // 
            this.lblTextKmJ1.AutoSize = true;
            this.lblTextKmJ1.Location = new System.Drawing.Point(5, 18);
            this.lblTextKmJ1.Name = "lblTextKmJ1";
            this.lblTextKmJ1.Size = new System.Drawing.Size(100, 17);
            this.lblTextKmJ1.TabIndex = 79;
            this.lblTextKmJ1.Text = "Nombre de km";
            // 
            // LblKmJ1
            // 
            this.LblKmJ1.AutoSize = true;
            this.LblKmJ1.Location = new System.Drawing.Point(5, 34);
            this.LblKmJ1.Name = "LblKmJ1";
            this.LblKmJ1.Size = new System.Drawing.Size(38, 17);
            this.LblKmJ1.TabIndex = 80;
            this.LblKmJ1.Text = "0 km";
            // 
            // LblKmJ2
            // 
            this.LblKmJ2.AutoSize = true;
            this.LblKmJ2.Location = new System.Drawing.Point(5, 36);
            this.LblKmJ2.Name = "LblKmJ2";
            this.LblKmJ2.Size = new System.Drawing.Size(38, 17);
            this.LblKmJ2.TabIndex = 82;
            this.LblKmJ2.Text = "0 km";
            // 
            // lblKmTextJ2
            // 
            this.lblKmTextJ2.AutoSize = true;
            this.lblKmTextJ2.Location = new System.Drawing.Point(3, 18);
            this.lblKmTextJ2.Name = "lblKmTextJ2";
            this.lblKmTextJ2.Size = new System.Drawing.Size(100, 17);
            this.lblKmTextJ2.TabIndex = 81;
            this.lblKmTextJ2.Text = "Nombre de km";
            // 
            // gbJ1
            // 
            this.gbJ1.Controls.Add(this.lblTextKmJ1);
            this.gbJ1.Controls.Add(this.LblKmJ1);
            this.gbJ1.Location = new System.Drawing.Point(12, 12);
            this.gbJ1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.gbJ1.Name = "gbJ1";
            this.gbJ1.Padding = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.gbJ1.Size = new System.Drawing.Size(109, 54);
            this.gbJ1.TabIndex = 3;
            this.gbJ1.TabStop = false;
            this.gbJ1.Text = "Joueur 1";
            // 
            // gbJ2
            // 
            this.gbJ2.Controls.Add(this.LblKmJ2);
            this.gbJ2.Controls.Add(this.lblKmTextJ2);
            this.gbJ2.Location = new System.Drawing.Point(12, 633);
            this.gbJ2.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.gbJ2.Name = "gbJ2";
            this.gbJ2.Padding = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.gbJ2.Size = new System.Drawing.Size(107, 57);
            this.gbJ2.TabIndex = 83;
            this.gbJ2.TabStop = false;
            this.gbJ2.Text = "Joueur 2";
            // 
            // lblPioche
            // 
            this.lblPioche.AutoSize = true;
            this.lblPioche.Location = new System.Drawing.Point(811, 298);
            this.lblPioche.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblPioche.Name = "lblPioche";
            this.lblPioche.Size = new System.Drawing.Size(51, 17);
            this.lblPioche.TabIndex = 84;
            this.lblPioche.Text = "Pioche";
            // 
            // lblFausse
            // 
            this.lblFausse.AutoSize = true;
            this.lblFausse.Location = new System.Drawing.Point(965, 298);
            this.lblFausse.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblFausse.Name = "lblFausse";
            this.lblFausse.Size = new System.Drawing.Size(54, 17);
            this.lblFausse.TabIndex = 85;
            this.lblFausse.Text = "Fausse";
            // 
            // lblBrule
            // 
            this.lblBrule.AutoSize = true;
            this.lblBrule.Location = new System.Drawing.Point(669, 298);
            this.lblBrule.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblBrule.Name = "lblBrule";
            this.lblBrule.Size = new System.Drawing.Size(41, 17);
            this.lblBrule.TabIndex = 86;
            this.lblBrule.Text = "Brule";
            // 
            // dlgSauvegarde
            // 
            this.dlgSauvegarde.FileOk += new System.ComponentModel.CancelEventHandler(this.dlgSauvegarde_FileOk);
            // 
            // FicJeux
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1180, 889);
            this.Controls.Add(this.lblBrule);
            this.Controls.Add(this.lblFausse);
            this.Controls.Add(this.lblPioche);
            this.Controls.Add(this.gbJ2);
            this.Controls.Add(this.gbJ1);
            this.Controls.Add(this.btntest2);
            this.Controls.Add(this.btnTest);
            this.Controls.Add(this.gbInfo);
            this.Controls.Add(this.gbMenu);
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "FicJeux";
            this.Text = "Mille Bornes - Ecran de Jeux";
            this.Load += new System.EventHandler(this.EcranJeux_Load);
            this.gbMenu.ResumeLayout(false);
            this.gbInfo.ResumeLayout(false);
            this.gbInfo.PerformLayout();
            this.gbJ1.ResumeLayout(false);
            this.gbJ1.PerformLayout();
            this.gbJ2.ResumeLayout(false);
            this.gbJ2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnStart;
        private System.Windows.Forms.Button btnPioche;
        private System.Windows.Forms.Button btnTerminerTour;
        private System.Windows.Forms.GroupBox gbMenu;
        private System.Windows.Forms.GroupBox gbInfo;
        private System.Windows.Forms.Label lblInfoTour;
        private System.Windows.Forms.Label lblNbrCartes;
        private System.Windows.Forms.Label lblNbrCarteJ2;
        private System.Windows.Forms.Label lblNbrCarteJ1;
        private System.Windows.Forms.Button btnTest;
        private System.Windows.Forms.Button btntest2;
        private System.Windows.Forms.Label lblTextKmJ1;
        private System.Windows.Forms.Label LblKmJ1;
        private System.Windows.Forms.Label LblKmJ2;
        private System.Windows.Forms.Label lblKmTextJ2;
        private System.Windows.Forms.GroupBox gbJ1;
        private System.Windows.Forms.GroupBox gbJ2;
        private System.Windows.Forms.Label lblPioche;
        private System.Windows.Forms.Label lblFausse;
        private System.Windows.Forms.Label lblBrule;
        private System.Windows.Forms.Button btnSauvegarde;
        private System.Windows.Forms.SaveFileDialog dlgSauvegarde;
    }
}