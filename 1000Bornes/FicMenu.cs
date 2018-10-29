using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace _1000Bornes
{
    public partial class FicMenu : Form
    {
        Partie NP;
        public FicMenu()
        {
            InitializeComponent();
        }
        string NomFichier = "";

        private void btnNouvellePartie_Click(object sender, EventArgs e)
        {
             NP = new Partie(9); // on instancie une Nouvelle Partie
            FicJeux f = new FicJeux(NP._Joueur1, NP._Joueur2, NP._Pioche, NP._Brule, NP._Fausse, NP._nbrTour,NP._NbrCarteMax, NP._J1JOUE, NP._APioche, NP._AJoue);
            f.ShowDialog();
        }

        private void btnQuitter_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnCharger_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Charger une partie", "Charger", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                if (NomFichier == "") // test si l'adresse est nulle 
                    if (dlgOuvrir.ShowDialog() == DialogResult.OK)
                        // on envoie la boite de dialoge pour sauver le fichier 
                        NomFichier = dlgOuvrir.FileName;
                if (NomFichier != "")
                {
                     NP = new Partie(9);
                    StreamReader sr = new StreamReader(dlgOuvrir.FileName);
                    string lecture;
                    

                    // joueur 1
                    while ((lecture = sr.ReadLine()) != "")
                    {
                        string[] tab = lecture.Split(';');
                        //if (int.Parse(tab[0]) == 1) // on s'assure d'avoir l'identifiant du joueur 1
                        {
                            NP._Joueur1.DistParc = int.Parse(tab[1]);
                            if (tab[2] == "True")
                                NP._Joueur1.FeuVert = true;
                            else
                                NP._Joueur1.FeuVert = false;

                            if (tab[3] == "True")
                                NP._Joueur1.MVitesse = true;
                            else
                                NP._Joueur1.MVitesse = false;

                            if (tab[4] == "True")
                                NP._Joueur1.MPanneE = true;
                            else
                                NP._Joueur1.MPanneE = false;

                            if (tab[5] == "True")
                                NP._Joueur1.MCrevaison = true;
                            else
                                NP._Joueur1.MCrevaison = false;

                            if (tab[6] == "True")
                                NP._Joueur1.MAccident = true;
                            else
                                NP._Joueur1.MAccident = false;

                            if (tab[7] == "True")
                                NP._Joueur1.JPrioritaire = true;
                            else
                                NP._Joueur1.JPrioritaire = false;

                            if (tab[8] == "True")
                                NP._Joueur1.JCiterne = true;
                            else
                                NP._Joueur1.JCiterne = false;

                            if (tab[9] == "True")
                                NP._Joueur1.JIncrevable = true;
                            else
                                NP._Joueur1.JIncrevable = false;

                            if (tab[10] == "True")
                                NP._Joueur1.JAsDuVolant = true;
                            else
                                NP._Joueur1.JAsDuVolant = false;
                        }
                    }
                    // on remplis la main du premier joueur 
                    while ((lecture = sr.ReadLine()) != "")
                    {
                        string[] tab = lecture.Split(';');
                        foreach (string t in tab)
                        {
                            if (t != "")
                            {
                                Cartes carte = new Cartes(t.ToString());
                                NP._Joueur1.Main.Add(carte);
                            }
                        }
                    }
                    //-----------------------------------------------------------------------------------

                    // joueur 2 
                    while ((lecture = sr.ReadLine()) != "")
                    {
                        string[] tab = lecture.Split(';');
                        if (int.Parse(tab[0]) == 2) // on s'assure d'avoir l'identifiant du joueur 1
                        {
                            NP._Joueur2.DistParc = int.Parse(tab[1]);
                            if (tab[2] == "True")
                                NP._Joueur2.FeuVert = true;
                            else
                                NP._Joueur2.FeuVert = false;

                            if (tab[3] == "True")
                                NP._Joueur2.MVitesse = true;
                            else
                                NP._Joueur2.MVitesse = false;

                            if (tab[4] == "True")
                                NP._Joueur2.MPanneE = true;
                            else
                                NP._Joueur2.MPanneE = false;

                            if (tab[5] == "True")
                                NP._Joueur2.MCrevaison = true;
                            else
                                NP._Joueur2.MCrevaison = false;

                            if (tab[6] == "True")
                                NP._Joueur2.MAccident = true;
                            else
                                NP._Joueur2.MAccident = false;

                            if (tab[7] == "True")
                                NP._Joueur2.JPrioritaire = true;
                            else
                                NP._Joueur2.JPrioritaire = false;

                            if (tab[8] == "True")
                                NP._Joueur2.JCiterne = true;
                            else
                                NP._Joueur2.JCiterne = false;

                            if (tab[9] == "True")
                                NP._Joueur2.JIncrevable = true;
                            else
                                NP._Joueur2.JIncrevable = false;

                            if (tab[10] == "True")
                                NP._Joueur2.JAsDuVolant = true;
                            else
                                NP._Joueur2.JAsDuVolant = false;
                        }
                    }

                    // on remplit la main du second joueur
                    while ((lecture = sr.ReadLine()) != "")
                    {
                        string[] tab = lecture.Split(';');
                        foreach (string t in tab)
                            MessageBox.Show(t);

                        foreach (string t in tab)
                        {
                            if (t != "")
                            {
                                Cartes carte = new Cartes(t.ToString());
                                NP._Joueur2.Main.Add(carte);
                            }
                        }
                    }
                    //-----------------------------------------------------------------------------------

                    // parametre de la partie
                    while ((lecture = sr.ReadLine()) != "")
                    {
                        string[] tab = lecture.Split(';');
                        NP._nbrTour = int.Parse(tab[0]);
                        if (tab[1] == "True")
                            NP._J1JOUE = true;
                        else
                            NP._J1JOUE = false;
                        if (tab[2] == "True")
                            NP._APioche = true;
                        else
                            NP._APioche = false;
                        if (tab[3] == "True")
                            NP._AJoue = true;
                        else
                            NP._AJoue = false;
                        //FicJeux f = new FicJeux();
                        //f.ShowDialog();
                    }
                    // decl 
                    while ((lecture = sr.ReadLine()) != "")
                    {
                        string[] tab = lecture.Split(';');
                        foreach (string t in tab)
                        {
                            Cartes carte = new Cartes(t.ToString());
                            NP._Pioche.Add(carte);
                        }
                    }
                    while ((lecture = sr.ReadLine()) != "")
                    {
                        string[] tab = lecture.Split(';');
                        foreach (string t in tab)
                        {
                            Cartes carte = new Cartes(t.ToString());
                            NP._Brule.Add(carte);
                        }
                    }
                    while ((lecture = sr.ReadLine()) != "")
                    {
                        string[] tab = lecture.Split(';');
                        foreach (string t in tab)
                        {
                            Cartes carte = new Cartes(t.ToString());
                            NP._Fausse.Add(carte);
                        }
                    }
                    //-----------------------------------------------------------------------------------

                    FicJeux f = new FicJeux(NP._Joueur1, NP._Joueur2, NP._Pioche, NP._Brule, NP._Fausse, NP._nbrTour,NP._NbrCarteMax, NP._J1JOUE, NP._APioche, NP._AJoue);
                    f.ShowDialog();
                }
                 NomFichier = ""; // remet le nom de fichier a rien 
            }
        }
      
    }
}