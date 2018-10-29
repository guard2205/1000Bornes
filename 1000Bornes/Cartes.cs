using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _1000Bornes
{
    public class Cartes
    {
        public enum Nom
        {
            //botes
            Prioritaire,
            Citerne,
            Increvable,
            AsDuVolant,
            //Attaques
            FeuRouge,
            LimitationVitesse,
            PanneEssence,
            Crevaison,
            Accident,
            //Parades
            FeuVert,
            FinLimitationVitesse,
            FinPanneEssence,
            RoueSecours,
            Reparations,
            //Bornes
            Escargot,   // 25
            Canard,     // 50
            Papillon,   // 75
            Lapin,      // 100
            Oiseaux     // 200
        }

        #region Données Membres
        public Nom _Nom;
        #endregion

        #region constructeur
        public Cartes( Nom nom)
        {
            this._Nom = nom;
        }
        public Cartes (string nom)
        {
          this._Nom = Determination(nom);
        }
        static Cartes.Nom Determination(string snom)
        {
            Cartes.Nom nom = new Cartes.Nom();
            switch (snom)
            {
                case "Prioritaire":
                    {
                        nom = Nom.Prioritaire;
                        break;
                    }
                case "Citerne":
                    {
                        nom = Nom.Citerne;
                        break;
                    }
                case "Increvable":
                    {
                        nom = Nom.Increvable;
                        break;
                    }
                case "AsDuVolant":
                    {
                        nom = Nom.AsDuVolant;
                        break;
                    }
                case "FeuRouge":
                    {
                        nom = Nom.FeuRouge;
                        break;
                    }
                case "LimitationVitesse":
                    {
                        nom = Nom.LimitationVitesse;
                        break;
                    }
                case "PanneEssence":
                    {
                        nom = Nom.PanneEssence;
                        break;
                    }
                case "Crevaison":
                    {
                        nom = Nom.Crevaison;
                        break;
                    }
                case "Accident":
                    {
                        nom = Nom.Accident;
                        break;
                    }
                case "FeuVert":
                    {
                        nom = Nom.FeuVert;
                        break;
                    }
                case "FinLimitationVitesse":
                    {
                        nom = Nom.FinLimitationVitesse;
                        break;
                    }
                case "FinPanneEssence":
                    {
                        nom = Nom.FinPanneEssence;
                        break;
                    }
                case "RoueSecours":
                    {
                        nom = Nom.RoueSecours;
                        break;
                    }
                case "Reparations":
                    {
                        nom = Nom.Reparations;
                        break;
                    }
                case "Escargot":
                    {
                        nom = Nom.Escargot;
                        break;
                    }
                case "Canard":
                    {
                        nom = Nom.Canard;
                        break;
                    }
                case "Papillon":
                    {
                        nom = Nom.Papillon;
                        break;
                    }
                case "Lapin":
                    {
                        nom = Nom.Lapin;
                        break;
                    }
                case "Oiseaux":
                    {
                        nom = Nom.Oiseaux;
                        break;
                    }
                default:
                    {
                        break;
                    }
            }
            return nom;
        }
        #endregion 
    }
}
