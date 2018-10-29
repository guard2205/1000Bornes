using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _1000Bornes
{
    public partial class EcranPioche : Form
    {
        public int choix;

        public EcranPioche()
        {
            InitializeComponent();
        }

        private void Pioche_Load(object sender, EventArgs e)
        {

        }

        private void btnPiocher_Click(object sender, EventArgs e)
        {
            choix = 1;
            this.Close();
        }

        private void btnAnnuler_Click(object sender, EventArgs e)
        {
            choix = 0;
            this.Close();
        }
    }
}
