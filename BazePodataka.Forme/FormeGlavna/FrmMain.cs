using BazePodataka.Forme.FormeKafa;
using BazePodataka.Forme.FormeKalkulacija;
using BazePodataka.Forme.FormeKomitent;
using BazePodataka.Forme.FormeOtpremnica;
using BazePodataka.Forme.FormeProfaktura;
using BazePodataka.Forme.FormeTipKafe;
using BazePodataka.Forme.FormeTrebovanje;
using BazePodataka.Forme.FormKalkulacijaKafa;
using BazePodataka.Forme.FormValuta;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BazePodataka.Forme.FormeGlavna
{
    public partial class FrmMain : Form
    {
        public FrmMain()
        {
            InitializeComponent();
        }

        private void kafaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmKafaPrikaz forma = new FrmKafaPrikaz();
            forma.ShowDialog();
        }

        private void kalkulacijaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmKalkulacijaPrikaz forma = new FrmKalkulacijaPrikaz();
            forma.ShowDialog();
        }

        private void komitentToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmKomitentPrikaz forma = new FrmKomitentPrikaz();
            forma.ShowDialog();
        }

        private void otpremnicaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmOtpremnicaPrikaz forma = new FrmOtpremnicaPrikaz();
            forma.ShowDialog();
        }

        private void profakturaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmProfakturaPrikaz forma = new FrmProfakturaPrikaz();
            forma.ShowDialog();
        }

        private void tipKafeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmTipKafePrikaz forma = new FrmTipKafePrikaz();
            forma.ShowDialog();
        }

        private void trebovanjeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmTrebovanjePrikaz forma = new FrmTrebovanjePrikaz();
            forma.ShowDialog();
        }

        private void valutaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmValutaPrikaz forma = new FrmValutaPrikaz();
            forma.ShowDialog();
        }

        private void komitentPogledToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmKomitentPogledPrikaz forma = new FrmKomitentPogledPrikaz();
            forma.ShowDialog();
        }

        private void kalkulacijaKafaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmKalkulacijaKafaPrikaz forma = new FrmKalkulacijaKafaPrikaz();
            forma.ShowDialog();
        }
    }
}
