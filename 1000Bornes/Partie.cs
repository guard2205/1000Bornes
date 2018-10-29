using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace _1000Bornes
{
    public class Partie
    {
        #region Données Membres
        public Joueur _Joueur1;
        public Joueur _Joueur2;

        public List<Cartes> _Pioche;
        public List<Cartes> _Brule;
        public List<Cartes> _Fausse;

        Random aleatoire = new Random();

        public int _nbrTour = 0;
        public int _NbrCarteMax;
        public bool _J1JOUE = true; // Le joueur 1 joue de base 
        public bool _APioche = false;   // variable indiquant si le joueur a pioché ou non 
        public bool _AJoue = false; // le joueur a déjà joué ou bruler, il peut terminer le tour
        #endregion

        #region Constructeurs 
        //  Il nous faut alors le constructeur de nouvelle partie ou tout est initialisé
        public Partie(int NbrCarteMax)
        {
            _Joueur1 = new Joueur(1);
            _Joueur2 = new Joueur(2);

            _Pioche = new List<Cartes>();
            _Brule = new List<Cartes>();
            _Fausse = new List<Cartes>();

            _nbrTour = 0;
            _NbrCarteMax = NbrCarteMax;

            int test = aleatoire.Next(100);
            if (test<50)
                _J1JOUE = true;
            
            else
                _J1JOUE = false;

            _APioche = false;
            _AJoue = false;
        }

        // si on instancie une sauvegarde, il nous faut alors allez rechercher ces données 
        public Partie(Joueur Joueur1, Joueur Joueur2, List<Cartes> Pioche, List<Cartes> Brule, List<Cartes> Fausse, int nbrTour, bool J1Joue, bool Apioche, bool Ajoue)
        {
            _Joueur1 = Joueur1;
            _Joueur2 = Joueur2;

            _Pioche = Pioche;
            _Brule = Brule;
            _Fausse = Fausse;

            _nbrTour = nbrTour;
            _J1JOUE = J1Joue;
            _APioche = Apioche;
            _AJoue = Ajoue;
        }
        #endregion 
    }
}
