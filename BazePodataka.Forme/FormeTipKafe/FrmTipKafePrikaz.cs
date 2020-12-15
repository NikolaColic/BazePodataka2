using BazePodataka.Kontroler.Kontroleri;
using Domen.DomenskeKlase;
using Domen.Korisno;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BazePodataka.Forme.FormeTipKafe
{
    public partial class FrmTipKafePrikaz : Form
    {
        List<TipKafe> tipovi = new List<TipKafe>();
        public FrmTipKafePrikaz()
        {
            InitializeComponent();
            PripremiFormu();
        }
        private void PripremiFormu()
        {
            tipovi = KontrolerTipKafe.Instance.Select(new TipKafe());
            if (tipovi is null) MessageBox.Show("Sistem ne moze da ucita listu");
            dgvPrikaz.DataSource = tipovi;
        }
        private void btnDodaj_Click(object sender, EventArgs e)
        {
            FrmTipKafeDodaj form = new FrmTipKafeDodaj(Operacija.Add, null);
            form.ShowDialog();
        }

        private void btnIzmeni_Click(object sender, EventArgs e)
        {
            TipKafe tip = SelectTipKafe();
            if (tip is null) return;
            FrmTipKafeDodaj form = new FrmTipKafeDodaj(Operacija.Update, tip);
            form.ShowDialog();
        }

        private void btnObrisi_Click(object sender, EventArgs e)
        {
            TipKafe tip = SelectTipKafe();
            if (tip is null) return;
            bool znak = KontrolerTipKafe.Instance.Delete(tip);
        }
        private TipKafe SelectTipKafe()
        {
            TipKafe tipkafe = null;
            try
            {
                tipkafe = (TipKafe)dgvPrikaz.SelectedRows[0].DataBoundItem;
                return tipkafe;
            }
            catch (Exception ef)
            {
                MessageBox.Show("Niste selektovali");
                return null;
            }
        }
    }
}
