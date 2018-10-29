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
    
    public partial class EcranChoix : Form
    {
        public int choix; 
        public EcranChoix()
        {
            InitializeComponent();
        }

        private void btnLeave_Click(object sender, EventArgs e)
        {
            choix = 0;
            this.Close();
        }

        private void btnPlay_Click(object sender, EventArgs e)
        {
            choix = 1;
            this.Close();

        }

        private void btnBruler_Click(object sender, EventArgs e)
        {
            choix = 2;
            this.Close();

        }
    }
}
