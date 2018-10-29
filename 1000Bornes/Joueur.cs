using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace _1000Bornes
{
    public class Joueur
    {
        #region Donnees membres 

        public int identification;
        public List<Cartes> Main = new List<Cartes>();
        public int DistParc = 0;        // distance parcourue par le joueur
        public bool FeuVert = false;    // si le feu est vert le joueur peut avancer

        // maluces disponible sur le véhicule
        public bool MVitesse = false ;     // Maluce : Limitation de vitesse a 50km/h
        public bool MPanneE = false;       // Maluce : Panne d'essence ( véhicule inamovible)
        public bool MCrevaison = false;    // Maluce : Crevaison ( vehicule inamovible )
        public bool MAccident = false;             // Maluce : Accident  ( véhicule inamovible )

        // joker disponible sur le véhicule 
        public bool JPrioritaire = false;   // si les joker sont ok, la maluce n'a pas d'effet , ici Mvitesse ne fait rien
        public bool JCiterne = false;       // ici MPanneE ne fait rien
        public bool JIncrevable = false;    // ici MCrevaison ne fait rien
        public bool JAsDuVolant = false;    // ici MAccident ne fait rien 



        #endregion

        #region Constructeur 
        public Joueur(int id)
        {
            this.identification = id;
        }
        #endregion 

        #region Accesseurs  
        #endregion 

        #region Methode  
        #endregion 
    }
}
