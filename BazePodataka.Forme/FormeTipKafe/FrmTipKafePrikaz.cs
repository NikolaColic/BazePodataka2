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
        BindingList<TipKafe> tipovi;
        public FrmTipKafePrikaz()
        {
            InitializeComponent();
            PripremiFormu();
        }
        private void PripremiFormu()
        {
            List<TipKafe> lista = KontrolerTipKafe.Instance.Select(new TipKafe());
            tipovi = new BindingList<TipKafe>(lista);
            if (lista is null) MessageBox.Show("Sistem ne moze da ucita listu");
            dgvPrikaz.DataSource = lista;
        }
        private void btnDodaj_Click(object sender, EventArgs e)
        {
            TipKafe tip = new TipKafe() { TipKafeId = tipovi.Max(m => m.TipKafeId) + 1 };
            FrmTipKafeDodaj form = new FrmTipKafeDodaj(Operacija.Add, tip);
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
            if (KontrolerTipKafe.Instance.Delete(tip))
            {
                MessageBox.Show("Uspesno!");
                tipovi.Remove(tip);
                return;
            }
            MessageBox.Show("Neuspesno!");
        }
        private TipKafe SelectTipKafe()
        {
            TipKafe tipkafe = null;
            try
            {
                tipkafe = (TipKafe)dgvPrikaz.SelectedRows[0].DataBoundItem;
                return tipkafe;
            }
            catch (Exception)
            {
                MessageBox.Show("Niste selektovali");
                return null;
            }
        }
    }
}
