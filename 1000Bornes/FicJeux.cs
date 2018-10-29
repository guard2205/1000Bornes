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
    public partial class FicJeux : Form
    {
        #region Données Membres 

        // données propres aux joueurs et a la partie
        Joueur Player1 = new Joueur(1);
        Joueur Player2 = new Joueur(2);

        List<Cartes> Pioche = new List<Cartes>();
        List<Cartes> Brule = new List<Cartes>();
        List<Cartes> Fausse = new List<Cartes>();

    //    bool debugPioche = false;
        int nbrTour = 0;
        bool J1JOUE = true; // Le joueur 1 joue de base 
        bool APioche = false;   // variable indiquant si le joueur a pioché ou non 
        bool AJoue = false; // le joueur a déjà joué ou bruler, il peut terminer le tour
        int nbrCarteMax;

        // gesiton des affichages du jeux

        // affichage des cartes et états des joueurs 
        List<PictureBox> LPBCarteMainJ1 = new List<PictureBox>();  // affichage carte main joueur 1
        List<PictureBox> LPBCarteMainJ2 = new List<PictureBox>();  // affichage carte main joueur 2

        List<PictureBox> LPBCarteEtatJ1 = new List<PictureBox>();  // affichage carte etat du joueur 1
        List<PictureBox> LPBCarteEtatJ2 = new List<PictureBox>();  // affichage carte etat du joueur 2

        PictureBox pbPioche;
        PictureBox pbBrule;
        PictureBox pbFausse;


        // positionnement des cartes
        public int SMX = 136;                   // Size Max en largreur
        public int SMY = 186;                   // Size Max en Hauteur
        public int SmX = 91;    // Size min en largeur
        public int SmY = 124;    // Size min en Hauteur

        // Données Sauvegarde
        private string NomFichier = "";
        #endregion 
        private void RefreshCartesMain()
        {
            int i = 0;
            SuppressionCartes(LPBCarteMainJ1); // on supprime les cartes avant de les afficher
            SuppressionCartes(LPBCarteMainJ2);

            // on parcourt chaque carte de la main
            foreach (Cartes l in Player1.Main)
            {

                PictureBox pbcarte = new PictureBox();  // on crée une nouvelle pb
                LPBCarteMainJ1.Add(pbcarte);            // on l'ajoute a la liste
                pbcarte.Name = "PBj1_" + i.ToString();  // on nomme et numérote la carte en fonction du joueur 
                if (J1JOUE)
                    DeterminationImage(Player1.Main[i], LPBCarteMainJ1[i], true);   // on détermine l'image a afficher
                                                                                    // si elle est face visible, on l'a met true
                else
                    DeterminationImage(Player1.Main[i], LPBCarteMainJ1[i], false); // si elle est face cachée, on l'a met false

                Point tmp = new Point();    // permet de recalcuer la position de notre carte
                Format(pbcarte, 1);         // permet de définir le format de la carte 
                tmp.X = 100 + (i * 2 * (LPBCarteMainJ1[i].Size.Width) / 3);  // calcul de la position des cartes X et Y 
                tmp.Y = 20;

                pbcarte.Location = tmp;    // reposition de la carte
                this.Controls.Add(LPBCarteMainJ1[i]); // ajout d'un pb au controls, la fenetre devant le parent de la pictureBox 
                i++;
                pbcarte.Click += Pbcarte_Click;     // permet d'activer les event sur les cartes
            }
            i = 0;

            // remplisage de la 2e main 
            // les méthodes appliquées sont similaires 
            foreach (Cartes l in Player2.Main)
            {
                PictureBox pbcarte = new PictureBox();
                LPBCarteMainJ2.Add(pbcarte);
                pbcarte.Name = "PBj2_" + i.ToString();
                if (!J1JOUE)
                    DeterminationImage(Player2.Main[i], LPBCarteMainJ2[i], true);
                else
                    DeterminationImage(Player2.Main[i], LPBCarteMainJ2[i], false);

                Point tmp = new Point();
                Format(pbcarte, 1);

                tmp.X = 100 + (i * 2 * (LPBCarteMainJ2[i].Size.Width) / 3);
                tmp.Y = 20 + SMY + (2 * SmY) + 20; // dernier 20 car 20 = 5 + 10 + 5 

                pbcarte.Location = tmp;
                this.Controls.Add(LPBCarteMainJ2[i]);
                i++;
                pbcarte.Click += Pbcarte_Click;     // permet d'activer les event sur les cartes
            }
        }

        private void RefreshCarteEtat()
        {
            // on refresh, donc on suppriume ce qu'on a afficher
            SuppressionCartes(LPBCarteEtatJ1); // on supprime le vecteur pb carte état 
            SuppressionCartes(LPBCarteEtatJ2);
            int i = 0;
            for (i = 0; i < 5; i++)
            {
                PictureBox Pbcarte1 = new PictureBox();
                Format(Pbcarte1, 2);
                PictureBox Pbcarte2 = new PictureBox();
                Format(Pbcarte2, 2);

                LPBCarteEtatJ1.Add(Pbcarte1);
                LPBCarteEtatJ2.Add(Pbcarte2);
                Point tmp1 = new Point();
                tmp1.X = 100 + (int)(i * (13 / 10) * (LPBCarteEtatJ1[i].Size.Width));
                tmp1.Y = 20 + SMY + 5;

                Point tmp2 = new Point();
                tmp2.X = 100 + (int)(i * (13 / 10) * (LPBCarteEtatJ2[i].Size.Width));
                tmp2.Y = tmp1.Y + SmY + 10;

                Pbcarte1.Location = tmp1;
                Pbcarte2.Location = tmp2;

                this.Controls.Add(LPBCarteEtatJ1[i]);
                this.Controls.Add(LPBCarteEtatJ2[i]);
            }
            //foreach (PictureBox l in Player1.LPBCarteEtat)

            // Affichage joueur 1
            // méthode similaire a détermination image, sauf que la méthode image fonctionne avec la var Carte.Nom, dont je n'ai pas accès pour les cartes états.
            {
                if (!Player1.FeuVert)
                {
                    LPBCarteEtatJ1[0].Image = Properties.Resources.FeuRouge;
                }
                else
                {
                    LPBCarteEtatJ1[0].Image = Properties.Resources.FeuVert;
                }
                if (Player1.JPrioritaire)
                    LPBCarteEtatJ1[1].Image = Properties.Resources.Prioritaire;
                else
                {
                    if (Player1.MVitesse)
                        LPBCarteEtatJ1[1].Image = Properties.Resources.LimVit;
                    else
                        LPBCarteEtatJ1[1].Image = Properties.Resources.FinLimVit;
                }
                if (Player1.JCiterne)
                    LPBCarteEtatJ1[2].Image = Properties.Resources.CiterneD_essence;
                else
                {
                    if (Player1.MVitesse)
                        LPBCarteEtatJ1[2].Image = Properties.Resources.PanneEss;
                    else
                        LPBCarteEtatJ1[2].Image = Properties.Resources.Essence;
                }
                if (Player1.JIncrevable)
                    LPBCarteEtatJ1[3].Image = Properties.Resources.Increvable;
                else
                {
                    if (Player1.MCrevaison)
                        LPBCarteEtatJ1[3].Image = Properties.Resources.Crevaison;
                    else
                        LPBCarteEtatJ1[3].Image = Properties.Resources.RoueDeSecours;
                }
                if (Player1.JAsDuVolant)
                    LPBCarteEtatJ1[4].Image = Properties.Resources.AsDuVolant;
                else
                {
                    if (Player1.MAccident)
                        LPBCarteEtatJ1[4].Image = Properties.Resources.Accident;
                    else
                        LPBCarteEtatJ1[4].Image = Properties.Resources.Reparation;
                }
            }
            //foreach (PictureBox l in Player2.LPBCarteEtat)
            {
                // affichage joueur 2 
                // gere le feu
                if (!Player2.FeuVert)
                {
                    LPBCarteEtatJ2[0].Image = Properties.Resources.FeuRouge;
                }
                else
                {
                    LPBCarteEtatJ2[0].Image = Properties.Resources.FeuVert;
                }
                // gere si on a un véhicule prioritaire
                if (Player2.JPrioritaire)
                    LPBCarteEtatJ2[1].Image = Properties.Resources.Prioritaire;
                else
                {
                    if (Player2.MVitesse)
                        LPBCarteEtatJ2[1].Image = Properties.Resources.LimVit;
                    else
                        LPBCarteEtatJ2[1].Image = Properties.Resources.FinLimVit;
                }
                // Citerne
                if (Player2.JCiterne)
                    LPBCarteEtatJ2[2].Image = Properties.Resources.CiterneD_essence;
                else
                {
                    if (Player2.MPanneE)
                        LPBCarteEtatJ2[2].Image = Properties.Resources.PanneEss;
                    else
                        LPBCarteEtatJ2[2].Image = Properties.Resources.Essence;
                }
                // increvable
                if (Player2.JIncrevable)
                    LPBCarteEtatJ2[3].Image = Properties.Resources.Increvable;
                else
                {
                    if (Player2.MCrevaison)
                        LPBCarteEtatJ2[3].Image = Properties.Resources.Crevaison;
                    else
                        LPBCarteEtatJ2[3].Image = Properties.Resources.RoueDeSecours;
                }
                // accident
                if (Player2.JAsDuVolant)
                    LPBCarteEtatJ2[4].Image = Properties.Resources.AsDuVolant;
                else
                {
                    if (Player2.MAccident)
                        LPBCarteEtatJ2[4].Image = Properties.Resources.Accident;
                    else
                        LPBCarteEtatJ2[4].Image = Properties.Resources.Reparation;
                }
            }
        }
        private void DeleteCarteDeck()
        {

            if (Pioche.Count() > 0 && nbrTour > 1)
            {
                pbPioche.Dispose();
                Controls.Remove(pbPioche);
            }
            if ( Fausse.Count()>1 )
            {
                pbFausse.Dispose();
                Controls.Remove(pbFausse);
            }
            if (Brule.Count()>1)
            {
                pbBrule.Dispose();
                Controls.Remove(pbBrule);
            }
        }
        private void RefreshCarteDeck() // refresh les cartes deck/fausse/brule
        {
            int Xmin = (5 * SmX) + 100 + 10; // 5 fois les petites pb + 100 de marge
            int Y = 50 + SMY + SmY - (SMY / 2); // 50 de marge, une pb puis ensuite on centre l'image
            int Ylbl = Y - 10;

            DeleteCarteDeck();



            lblFausse.Location = new Point(Xmin, Ylbl);
            // Nous nous occupons d'abord de la partie graphique de la fause 
            if (Fausse.Count > 0) // s'il y a plus d'une carte, on affiche le deck
            {
                pbFausse = new PictureBox();
                pbFausse.Location = new Point(Xmin, Y); // les pictures box sont instanciées en général 
                DeterminationImage(Fausse[(Fausse.Count()) - 1], pbFausse, true);
                Format(pbFausse, 1);
                Controls.Add(pbFausse);
            }
            Xmin += 5 + SMX;    // le 5 permet de faire un petit écart entre les decks 
            lblBrule.Location = new Point(Xmin, Ylbl);
            // Partie graphique de la brule
            if (Brule.Count > 0)
            {
                pbBrule = new PictureBox();
                pbBrule.Location = new Point(Xmin, Y);
                DeterminationImage(Brule[(Brule.Count()) - 1], pbBrule, true);
                Format(pbBrule, 1);
                Controls.Add(pbBrule);
            }
            // Partie graphique de la pioche 
            Xmin += 5 + SMX;
            lblPioche.Location = new Point(Xmin, Ylbl);

            if (Pioche.Count > 0)
            {
                pbPioche = new PictureBox();
                pbPioche.Location = new Point(Xmin, Y);
                pbPioche.Image = Properties.Resources.EcranPrincipal;
                pbPioche.Name = "Pioche";
                Format(pbPioche, 1);
                Controls.Add(pbPioche);
                 pbPioche.Click += pbPioche_Click; // desactive l'evenement bug sur la pioche
            }
        }

        private void pbPioche_Click(object sender, EventArgs e)
        {
            // on ajoute la méthode de pioche

            if (Pioche.Count > 0)   // sécurité pour s'assurer d'un nombre de carte positif
            {
                if (!APioche)
                {
                  
                        EcranPioche f = new EcranPioche();
                        f.ShowDialog();
                        // il me faut remettre la pb au milieu 
                        if (f.choix == 1)
                            PiocheDeck();
                }

                else
                {
                    MessageBox.Show(" Vous avez déjà pioché ce tour-ci");
                }
            }
        }

        private void RefreshCarteJoueur() // refresh les cartes état et main
        {
            RefreshCartesMain();
            RefreshCarteEtat();
        }
        private void RefreshToutesCartes() // refresh les cartes état/ main / deck / fause / 
        {
            RefreshCarteJoueur();
            RefreshCarteDeck();
            LblKmJ1.Text = Player1.DistParc + " km";
            LblKmJ2.Text = Player2.DistParc + " km";
            lblInfoTour.Text = nbrTour.ToString();
            lblNbrCartes.Text = Pioche.Count.ToString() + " Cartes";
        }
        private void Pbcarte_Click(object sender, EventArgs e)
        {
            // losqu'on clique sur la carte
            
            
            if (APioche)// d'abord on vérifie d'avoir bien pioché
            {
                if (AJoue) // ensuite on verifie si on a déjà joué
                    MessageBox.Show("Vous avez déjà joué ce tour-ci");
                else // si on a pas joué
                {
                    // sender c'est l'élement qui déclenche l'evenement
                    // c'est un argument qui peut etre lié au type d'évenement (style clique souris droit/gauche/molette) 
                    bool derniereCarte = false;  
                    PictureBox pbcarte = (PictureBox)sender;
                    string[] tab = pbcarte.Name.Split('_'); //On récupère le numéro de la PB DE LA CARTE QU ON JOUE
                    int NuméroCarte = int.Parse(tab[1]);    // NUMERO DE LA CARTE QUON VEUT JOUER
                    string pb = tab[0]; // on récupère le joueur pour l'affichage 

                    if (J1JOUE) // tour du joueur 1
                    {
                        if (pb == "PBj1") // on test si le nom de la carte est JOUEUR 1 
                        {
                            // on regarde si c'est la derniere carte a joué de notre partie
                            if ( Pioche.Count()==0) // on n'a plus de carte dans la pioche                        
                            {
                                if (Player2.Main.Count() == 0) // le joueur deux n'a plus de carte en main, c'est la derniere carte que joue le joueur 1
                                {
                                    if (Player1.Main.Count() == 1) // c'est la dernière carte du joueur 1 
                                        // les deux joueurs n'ont donc plus de cartes en main
                                        derniereCarte = true;
                                }
                            }
                            EcranChoix Ec = new EcranChoix();   // fenetre de choix
                            Ec.ShowDialog();
                            if (Ec.choix>0)
                            Interaction(Ec.choix, NuméroCarte); // la méthode qui gère de transferer une carte d'un paquet a l'autre, en incluant les modification de bool
                            Ec.Dispose();
                            RefreshToutesCartes();
                            if (derniereCarte)
                            {
                                if (Player1.DistParc > Player2.DistParc)
                                    MessageBox.Show("Fin de partie, Joueur 1 gagne ! " + '\n' + " Joueur 1 : " + Player1.DistParc.ToString() + " km" + '\n' + " Joueur 2 : " + Player2.DistParc.ToString() + " km");
                                if (Player1.DistParc == Player2.DistParc)
                                    MessageBox.Show(" Les deux Joueurs ont parcouru " + Player1.DistParc.ToString() + " km ");
                                if (Player1.DistParc < Player2.DistParc)
                                    MessageBox.Show("Fin de partie, Joueur 2 gagne ! " + '\n' + " Joueur 1 : " + Player1.DistParc.ToString() + " km" + '\n' + " Joueur 2 : " + Player2.DistParc.ToString() + " km");

                                this.Close();
                            }
                            if (Player1.DistParc >= 1000)
                            {
                                MessageBox.Show("Vous avez parcouru " + Player1.DistParc + " km\n !Vous avez gagné !\n La partie est finie");

                                this.Close();
                            }
                        }
                        else
                        {
                            MessageBox.Show("Ce n'est pas votre main !");
                        }

                    }
                    else    // tour du joueur 2 
                    {
                        if (pb == "PBj2")
                        {
                            // on regarde si c'est la derniere carte a joué de notre partie
                            if (Pioche.Count() == 0) // on n'a plus de carte dans la pioche                        
                            {
                                if (Player1.Main.Count() == 0) // le joueur 1 n'a plus de carte en main, c'est la derniere carte que joue le joueur 2
                                {
                                    if (Player2.Main.Count() == 1) // c'est la dernière carte du joueur 2 
                                        // les deux joueurs n'ont donc plus de cartes en main apres cette cartes 
                                        derniereCarte = true;
                                }

                            }
                            EcranChoix Ec = new EcranChoix();
                            Ec.ShowDialog();
                            Interaction(Ec.choix, NuméroCarte);
                            RefreshToutesCartes();
                            if (derniereCarte)
                            {
                                if (Player1.DistParc > Player2.DistParc)
                                 MessageBox.Show("Fin de partie, Joueur 1 gagne ! " + '\n' + " Joueur 1 : " + Player1.DistParc.ToString() +" km" + '\n' + " Joueur 2 : " + Player2.DistParc.ToString() + " km");
                                if (Player1.DistParc == Player2.DistParc)
                                    MessageBox.Show(" Les deux Joueurs ont parcouru " + Player1.DistParc.ToString() + " km ");
                                if (Player1.DistParc < Player2.DistParc)
                                    MessageBox.Show("Fin de partie, Joueur 2 gagne ! " + '\n' + " Joueur 1 : " + Player1.DistParc.ToString() + " km" + '\n' + " Joueur 2 : " + Player2.DistParc.ToString() + " km");

                                this.Close();
                            }
                            if (Player2.DistParc >= 1000)
                            {
                                MessageBox.Show("Vous avez parcouru " + Player2.DistParc + " km\n !Vous avez gagné !\n La partie est finie");
                                this.Close();
                            }
                        }
                        else
                        {
                            MessageBox.Show("Ce n'est pas votre main !");
                        }
                    }
                }
            }
            else
                MessageBox.Show("Vous Devez piocher d'abord!");
        }
        private void Interaction(int n, int NumCarte)   
            // méthode qui permet de jouer les cartes avec l'implication que ça peut avoir, et de gerer l'affichage des cartes
        {
            // n correcspond au choix
            if (n == 1)    // nous sommes dans le cas ou la carte est jouée 
            {
                if (J1JOUE) // joueur 1 joue
                {
                    JouerCarte(Player1.Main[NumCarte], Player2, Player1);   // joue la carte 
                    // gere les effets que ça a sur la partie
                    if (AJoue)
                    {
                        Fausse.Add(Player1.Main[NumCarte]); // on add dans la list de fausse 
                        Player1.Main.RemoveAt(NumCarte);    // on retire la carte de la main
                    }
                }
                else
                {
                    JouerCarte(Player2.Main[NumCarte], Player1, Player2);
                    if (AJoue)
                    {
                        Fausse.Add(Player2.Main[NumCarte]);
                        
                        Player2.Main.RemoveAt(NumCarte);
                    }
                }
            }
            if (n == 2) // choix ou la carte est brulée 
            {
                if (J1JOUE)
                {
                    Brule.Add(Player1.Main[NumCarte]);
                    Player1.Main.RemoveAt(NumCarte);
                }
                else
                {
                    Player2.Main.RemoveAt(NumCarte);
                    Brule.Add(Player2.Main[NumCarte]);
                }
                AJoue = true;
            }
        }

        private void SuppressionCartes(List<PictureBox> pbMain) // méthode utilisée dans l'affichage qui permet de supprimer les pb
        {
            while (pbMain.Count() > 0)   // tant que le nombre de carte en main est plus grand que 1
            {
                pbMain[pbMain.Count - 1].Dispose(); // on se met sur la bonne position de la carte
                Controls.Remove(pbMain[pbMain.Count - 1]);
                pbMain.RemoveAt(pbMain.Count - 1);
            }
        }

        private void Format(PictureBox pbcarte, int type)
        {
            // type permet de savoir si la carte est une carte état ou une carte normal de jeux / deck

            if (type == 1)  // carte de main/deck 
            {
                pbcarte.Size = new Size(SMX, SMY);
                pbcarte.SizeMode = PictureBoxSizeMode.StretchImage;
            }
            // carte état
            else
            {
                pbcarte.Size = new Size(SmX, SmY);
                pbcarte.SizeMode = PictureBoxSizeMode.StretchImage;
            }
        }
        private void DeterminationImage(Cartes CarteAAffich, PictureBox pbCarte, bool cote)
        {
            // en fonction de la carte a afficher, modifie la picture box concernée par la carte 

            // on modifie d'abord la taille de l'image
            if (cote)
            {
                string choix = CarteAAffich._Nom.ToString();
                switch (choix)
                {
                    case "Prioritaire":
                        pbCarte.Image = Properties.Resources.Prioritaire;
                        break;
                    case "Citerne":
                        pbCarte.Image = Properties.Resources.CiterneD_essence;
                        break;
                    case "Increvable":
                        pbCarte.Image = Properties.Resources.Increvable;
                        break;
                    case "AsDuVolant":
                        pbCarte.Image = Properties.Resources.AsDuVolant;
                        break;
                    case "FeuRouge":
                        pbCarte.Image = Properties.Resources.FeuRouge;
                        break;
                    case "LimitationVitesse":
                        pbCarte.Image = Properties.Resources.LimVit;
                        break;
                    case "PanneEssence":
                        pbCarte.Image = Properties.Resources.PanneEss;
                        break;
                    case "Crevaison":
                        pbCarte.Image = Properties.Resources.Crevaison;
                        break;
                    case "Accident":
                        pbCarte.Image = Properties.Resources.Accident;
                        break;
                    case "FeuVert":
                        pbCarte.Image = Properties.Resources.FeuVert;
                        break;
                    case "FinLimitationVitesse":
                        pbCarte.Image = Properties.Resources.FinLimVit;
                        break;
                    case "FinPanneEssence":
                        pbCarte.Image = Properties.Resources.Essence;
                        break;
                    case "RoueSecours":
                        pbCarte.Image = Properties.Resources.RoueDeSecours;
                        break;
                    case "Reparations":
                        pbCarte.Image = Properties.Resources.Reparation;
                        break;
                    case "Escargot":
                        pbCarte.Image = Properties.Resources._25esc;
                        break;
                    case "Canard":
                        pbCarte.Image = Properties.Resources._50can;
                        break;
                    case "Papillon":
                        pbCarte.Image = Properties.Resources._75pap;
                        break;
                    case "Lapin":
                        pbCarte.Image = Properties.Resources._100lap;
                        break;
                    case "Oiseaux":
                        pbCarte.Image = Properties.Resources._200hir;
                        break;
                    default:
                        pbCarte.Image = Properties.Resources.EcranPrincipal;
                        break;
                }
            }
            else
                pbCarte.Image = Properties.Resources.EcranPrincipal;


        }

        public FicJeux(Joueur _Joueur1, Joueur _Joueur2, List<Cartes> _Pioche, List<Cartes> _Brule, List<Cartes> _Fausse, int _nbrTour,int _nbreCarteMax, bool _J1JOUE, bool _APioche, bool _AJoue) // constructeur si c'est une nouvelle partie
        {
            // constructeur de la partie 
            Player1 = _Joueur1;
            Player2 = _Joueur2;

            Pioche = _Pioche;
            Brule = _Brule;
            Fausse = _Fausse;

            nbrTour = _nbrTour;
            nbrCarteMax = _nbreCarteMax;

            J1JOUE = _J1JOUE; // Le joueur 1 joue de base 
            APioche = _APioche;   // variable indiquant si le joueur a pioché ou non 
            AJoue = _AJoue; // le joueur a déjà joué ou bruler, il peut terminer le tour

            InitializeComponent();
            Activationbouton(nbrTour);
            if (nbrTour > 0) // des qu'on lance une partie on passe le premier tour.
                 RefreshToutesCartes();
        }


        public void EcranJeux_Load(object sender, EventArgs e)
        {

        }
        // Methode Remplir
        // elle permet de remplir le deck avec les cartes
        public void RemplirDeck()
        {
            int i;
            // Cartes bottes
            // 4 cartes 
            for (i = 0; i < 4; i++)
            {
                Cartes Carte = new Cartes(Cartes.Nom.Prioritaire);
                Pioche.Add(Carte);
            }

            //=========================================================================

            // Cartes Attaque
            // 18 cartes 

            // Feu vert
            // 5 cartes
            for (i = 0; i <= 4; i++)
            {
                Cartes Carte = new Cartes(Cartes.Nom.FeuRouge);
                Pioche.Add(Carte);
            }
            // Limitation vitesse 
            // 4 cartes
            for (i = 0; i <= 3; i++)
            {
                Cartes Carte = new Cartes(Cartes.Nom.LimitationVitesse);
                Pioche.Add(Carte);
            }
            // Panne d'essence
            // 3 cartes 
            for (i = 0; i <= 2; i++)
            {
                Cartes Carte = new Cartes(Cartes.Nom.PanneEssence);
                Pioche.Add(Carte);
            }
            // Crevaison 
            // 3 cartes 
            for (i = 0; i <= 2; i++)
            {
                Cartes Carte = new Cartes(Cartes.Nom.Crevaison);
                Pioche.Add(Carte);
            }
            // Crevaison 
            // 3 cartes 
            for (i = 0; i <= 2; i++)
            {
                Cartes Carte = new Cartes(Cartes.Nom.Accident);
                Pioche.Add(Carte);
            }

            //=========================================================================

            // Cartes Parades
            // 38 Cartes 

            // Feu Vert
            // 14 cartes
            for (i = 0; i < 14; i++)
            {
                Cartes Carte = new Cartes(Cartes.Nom.FeuVert);
                Pioche.Add(Carte);
            }
            // Limitation de Vitesse 
            // 6 Cartes 
            for (i = 0; i < 6; i++)
            {
                Cartes Carte = new Cartes(Cartes.Nom.FinLimitationVitesse);
                Pioche.Add(Carte);
            }
            // Essence 
            // 6 Cartes 
            for (i = 0; i < 6; i++)
            {
                Cartes Carte = new Cartes(Cartes.Nom.FinPanneEssence);
                Pioche.Add(Carte);
            }
            // Roue de secours 
            // 6 cartes 
            for (i = 0; i < 6; i++)
            {
                Cartes Carte = new Cartes(Cartes.Nom.RoueSecours);
                Pioche.Add(Carte);
            }
            // Reparations 
            // 6 Cartes 

            for (i = 0; i < 6; i++)
            {
                Cartes Carte = new Cartes(Cartes.Nom.Reparations);
                Pioche.Add(Carte);
            }
            //=========================================================================
            //Cartes Bornes
            // 46 Cartes 

            // escargot - 25 km 
            for (i = 0; i < 10; i++)
            {
                Cartes Carte = new Cartes(Cartes.Nom.Escargot);
                Pioche.Add(Carte);
            }
            // canard - 25 km
            // 10 cartes
            for (i = 0; i < 10; i++)
            {
                Cartes Carte = new Cartes(Cartes.Nom.Canard);
                Pioche.Add(Carte);
            }
            // papillon 75 km 
            // 10 cartes 
            for (i = 0; i < 10; i++)
            {
                Cartes Carte = new Cartes(Cartes.Nom.Papillon);
                Pioche.Add(Carte);
            }
            // Lapin - 100 km 
            // 12 cartes 
            for (i = 0; i < 12; i++)
            {
                Cartes Carte = new Cartes(Cartes.Nom.Lapin);
                Pioche.Add(Carte);
            }
            // Oiseaux - 100 km
            // 4 Cartes 
            for (i = 0; i < 4; i++)
            {
                Cartes Carte = new Cartes(Cartes.Nom.Oiseaux);
                Pioche.Add(Carte);
            }
            //=========================================================================

        }
        private void Activationbouton(int nbr)
        {

            if (nbr == 0)
            {
                // si le nombre de tour est nul, on peut accéder a commencer la partie
                btnPioche.Enabled = btnTerminerTour.Enabled = btnSauvegarde.Enabled = false;
                btnStart.Enabled = true;
            }
            else
            {
                btnPioche.Enabled = btnTerminerTour.Enabled = btnSauvegarde.Enabled = true;
                btnStart.Enabled = false;
            }
        }

        private void btnStart_Click(object sender, EventArgs e)
        {
            if (J1JOUE)
                MessageBox.Show(" Le joueur 1 commence la partie");
            else
                MessageBox.Show(" Le joueur 2 commence la partie");

            if (nbrTour == 0) // si le nombre de tour est égale a zero
            {
                RemplirDeck();
                for (int i = 0; i < nbrCarteMax-1; i++)
                {
                    PiocheDeck(Player1);
                    PiocheDeck(Player2);
                }
                nbrTour++;
                Activationbouton(nbrTour);
                RefreshToutesCartes();
            }
        }
        private void btnPioche_Click(object sender, EventArgs e)
        {
            PiocheDeck();
        }
       
        private void PiocheDeck()
        {
            if (!APioche  )
            {
                if (Pioche.Count > 0) // le nombre de carte est plus grand que 0
                {
                    if (J1JOUE)    // tour joueur 1 pair
                    {
                        if (Player1.Main.Count < nbrCarteMax)
                        {
                            PiocheDeck(Player1);
                            APioche = true;
                        }
                        else
                            MessageBox.Show("Vous avez déjà "+ nbrCarteMax .ToString()+ " cartes en main !");
                    }
                    else                // tour joueur 2 impair
                    {
                        if (Player2.Main.Count < nbrCarteMax)
                        {
                            PiocheDeck(Player2);
                            APioche = true;
                        }
                        else
                            MessageBox.Show("Vous avez déjà" + nbrCarteMax.ToString() + " cartes en main !");
                    }
                    //APioche = true;
                }
                else
                {
                    MessageBox.Show("! Il n'y a plus de carte dans le deck " +'\n'+ "On considère que vous avez pioché");
                    APioche = true;
                }
            }
            else
                MessageBox.Show("! Vous avez déjà pioché ce tour-ci !");
        }
        private void PiocheDeck(Joueur player)
        {
            if (Pioche.Count > 0)
            {
                Random rnd = new Random();      // besoin d'un nombre aléatoire pour piocher une carte au hasard dans le tas
                int i = rnd.Next(0, Pioche.Count);
                player.Main.Add(Pioche[i]);
                Pioche.RemoveAt(i);
                lblNbrCarteJ1.Text = "Carte J1 : " + Player1.Main.Count();
                lblNbrCarteJ2.Text = "Carte J2 : " + Player2.Main.Count();
                lblNbrCartes.Text = Pioche.Count.ToString() + " Cartes";

                RefreshCartesMain();
            }
            else
            {
                MessageBox.Show("! Il n'y a plus de carte dans le deck ! ");
                APioche = true;
            }
        }

        private void btnTerminerTour_Click(object sender, EventArgs e)
        {
            if (!APioche)
            {
                MessageBox.Show("Vous devez d'abord piocher/jouer/bruler une carte !");
            }
            else
            {
                if (!AJoue)
                {
                    MessageBox.Show("Vous devez d'abord jouer ou bruler une carte");
                }
                else
                {
                    if (J1JOUE)
                     PiocheDeck(Player2);

                    else
                        PiocheDeck(Player1);
                    AJoue = false;

                    nbrTour++;
                    J1JOUE = !J1JOUE;
                    lblInfoTour.Text = "Tour : " + nbrTour.ToString();
                    RefreshCartesMain();
                }
            }
            
        }

        private void JouerCarte(Cartes cible, Joueur adversaire, Joueur player)
        {
            string choix = cible._Nom.ToString();
            switch (choix)
            {
                // d'abord les bonus, on test pour savoir si les maluce sont activé, si elles sont activées on les désactive 
                // et on passe le joker en true 
                case "Prioritaire":
                    if (player.MVitesse)
                        player.MVitesse = false;
                    player.JPrioritaire = true;
                    AJoue = !AJoue;
                    break;
                case "Citerne":
                    if (player.MPanneE)
                        player.MPanneE = false;
                    player.JCiterne = true;
                    AJoue = !AJoue;
                    break;
                case "Increvable":
                    if (player.MCrevaison)
                        player.MCrevaison = false;
                    player.JIncrevable = true;
                    AJoue = !AJoue;
                    break;
                case "AsDuVolant":
                    if (player.MAccident)
                        player.MAccident = false;
                    player.JAsDuVolant = true;
                    AJoue = !AJoue;
                    break;
                //Attaques 
                // elles ont lieu sur les adversaires, elle viennent modifier les états de maluce a vrai
                // on
                case "FeuRouge":
                    adversaire.FeuVert = false;
                    AJoue = !AJoue;
                    break;
                case "LimitationVitesse":
                    if (!adversaire.JPrioritaire)
                        adversaire.MVitesse = true;
                    AJoue = !AJoue;
                    break;
                case "PanneEssence":
                    if (!adversaire.JCiterne)
                        adversaire.MPanneE = true;
                    AJoue = !AJoue;
                    break;
                case "Crevaison":
                    if (!adversaire.JIncrevable)
                        adversaire.MCrevaison = true;
                    AJoue = !AJoue;
                    break;
                case "Accident":
                    if (!adversaire.JAsDuVolant)
                        adversaire.MAccident = true;
                    AJoue = !AJoue;
                    break;
                //Parades
                case "FeuVert":
                    player.FeuVert = true;
                    AJoue = !AJoue;
                    break;
                case "FinLimitationVitesse":
                    if (!player.JPrioritaire)
                        player.MVitesse = false;
                    AJoue = !AJoue;
                    break;
                case "FinPanneEssence":
                    if (!player.JCiterne)
                        player.MPanneE = false;
                    AJoue = !AJoue;
                    break;
                case "RoueSecours":
                    if (!player.JIncrevable)
                        player.MCrevaison = false;
                    AJoue = !AJoue;
                    break;
                case "Reparations":
                    if (!player.JAsDuVolant)
                        player.MAccident = false;
                    AJoue = !AJoue;
                    break;
                //Bornes
                case "Escargot":   // 25
                    if (player.FeuVert) // on teste d'abord le feu vert pour savoir si ça vaut le coup 
                    {
                        if (!player.MCrevaison && !player.MPanneE && !player.MAccident) // on ne met pas la maluce de limitation de vitesse
                        {
                            player.DistParc += 25;
                            AJoue = true;
                        }
                        else
                        {
                            MessageBox.Show("Vous avez un maluce, vous ne pouvez pas avancer");
                            AJoue = false;
                        }
                    }
                    else
                    {
                        MessageBox.Show("Vous n'avez pas le feu Vert !");
                        AJoue = false;
                    }
                    break;
                case "Canard":     // 50
                    if (player.FeuVert)
                    {
                        if (!player.MCrevaison && !player.MPanneE && !player.MAccident) // on ne met pas la maluce de limitation de vitesse
                        {
                            player.DistParc += 50;
                            AJoue = true;
                        }
                        else
                        {
                            MessageBox.Show("Vous avez un maluce, vous ne pouvez pas avancer");
                            AJoue = false;
                        }
                    }
                    else
                    {
                        MessageBox.Show("Vous n'avez pas le feu Vert !");
                        AJoue = false;
                    }
                    break;
                case "Papillon":  // 75
                    if (player.FeuVert)
                    {
                        if (!player.MCrevaison && !player.MVitesse && !player.MPanneE && !player.MAccident)
                        {
                            player.DistParc += 75;
                            AJoue = true;
                        }
                        else
                        {
                            MessageBox.Show("Vous avez un maluce, vous ne pouvez pas avancer");
                            AJoue = false;
                        }
                    }
                    else
                    {
                        MessageBox.Show("Vous n'avez pas le feu Vert !");
                        AJoue = false;
                    }

                    break;
                case "Lapin":      // 100
                    if (player.FeuVert)
                    {
                        if (!player.MCrevaison && !player.MVitesse && !player.MPanneE && !player.MAccident)
                        {
                            player.DistParc += 100;
                            AJoue = true;
                        }
                        else
                        {
                            MessageBox.Show("Vous avez un maluce, vous ne pouvez pas avancer");
                            AJoue = false;
                        }
                    }
                    else
                    {
                        MessageBox.Show("Vous n'avez pas le feu Vert !");
                        AJoue = false;
                    }
                    break;
                case "Oiseaux":     // 200
                    if (player.FeuVert)
                    {
                        if (!player.MCrevaison && !player.MVitesse && !player.MPanneE && !player.MAccident)
                        {
                            player.DistParc += 200;
                            AJoue = true;
                        }
                        else
                        {
                            MessageBox.Show("Vous avez un maluce, vous ne pouvez pas avancer");
                            AJoue = false;
                        }

                    }
                    else
                    {
                        MessageBox.Show("Vous n'avez pas le feu Vert !");
                        AJoue = false;
                    }

                    break;
                default:
                    MessageBox.Show("default du switch"); break;
            }
        }
        public void btnTest_Click(object sender, EventArgs e)
        {
            Pioche.Clear();
        }

        private void btntest2_Click(object sender, EventArgs e)
        {
            Player1.DistParc = 1000;
        }

        private void btnSauvegarde_Click(object sender, EventArgs e)
        {
            VerifierSauver();
        }

        private void VerifierSauver()
        // creation d'une methode pour verifier si on veut enregistrer la modification
        {

            if (MessageBox.Show("Enregistrer la Partie en cours ?",
                "Sauvegarde",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question) == DialogResult.Yes)
                EnregistrerFichier();
            
        }
        private void EnregistrerFichier()
        {
            if (NomFichier == "") // test si l'adresse est nulle 
                if (dlgSauvegarde.ShowDialog() == DialogResult.OK)
                    // on envoie la boite de dialoge pour sauver le fichier 
                    NomFichier = dlgSauvegarde.FileName;
            if (NomFichier != "")
            {
                StreamWriter sw = new StreamWriter(dlgSauvegarde.FileName);

                // il nous faut donc écrire dans notre fichier les infos nécessaires pour initilialiser une partie 

                // tout d'abord écrire toutes les données des joueurs en commençant par le 1
                sw.WriteLine(Player1.identification + ";" + Player1.DistParc + ";" + Player1.FeuVert + ";" + Player1.MVitesse + ";" + Player1.MPanneE + ";" + Player1.MCrevaison + ";" + Player1.MAccident
                    + ";" + Player1.JPrioritaire + ";" + Player1.JCiterne + ";" + Player1.JIncrevable + ";" + Player1.JAsDuVolant);
                sw.WriteLine("");

                // ensuite on enregistre sa main
                foreach (Cartes tmp in Player1.Main)
                {
                    sw.Write(tmp._Nom + ";");
                }
                sw.WriteLine("");
                sw.WriteLine("");

                //-----------------------------------------------------------------------------------
                // on fait de même pour le joueur 2 
                // tout d'abord écrire toutes les données des joueurs en commençant par le 1
                sw.WriteLine(Player2.identification + ";" + Player2.DistParc + ";" + Player2.FeuVert + ";" + Player2.MVitesse + ";" + Player2.MPanneE + ";" + Player2.MCrevaison + ";" + Player2.MAccident
                    + ";" + Player2.JPrioritaire + ";" + Player2.JCiterne + ";" + Player2.JIncrevable + ";" + Player2.JAsDuVolant);
                sw.WriteLine("");

                // ensuite on enregistre sa main
                foreach (Cartes tmp in Player2.Main)
                {
                    sw.Write(tmp._Nom + ";");
                }
                sw.WriteLine("");
                sw.WriteLine("");


                //-----------------------------------------------------------------------------------
                // maintenant il nous faut enregistrer les caractéristiques de la partie
                sw.WriteLine(nbrTour + ";" + J1JOUE + ";" + APioche + ";" + AJoue);
                sw.WriteLine("");

                // aussi les decks constituant la partie 

                foreach (Cartes tmp in Pioche)
                {
                    sw.Write(tmp._Nom + ";");
                }
                sw.WriteLine("");
                sw.WriteLine("");

                foreach (Cartes tmp in Brule)
                {
                    sw.Write(tmp._Nom + ";");
                }
                sw.WriteLine("");
                sw.WriteLine("");

                foreach (Cartes tmp in Fausse)
                {
                    sw.Write(tmp._Nom + ";");
                }
                sw.WriteLine("");
                sw.WriteLine("");

                sw.Close();

            }
}
        private void dlgSauvegarde_FileOk(object sender, CancelEventArgs e)
        {

        }
    }
}
