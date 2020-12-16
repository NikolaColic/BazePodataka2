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

namespace BazePodataka.Forme.FormeKomitent
{
    public partial class FrmKomitentPogledPrikaz : Form
    {
        BindingList<KomitentPogled> komitenti;
        public FrmKomitentPogledPrikaz()
        {
            InitializeComponent();
            PripremiFormu();
        }
        private void PripremiFormu()
        {
            List<KomitentPogled> lista = KontrolerKomitentPogled.Instance.Select(new KomitentPogled());
            komitenti = new BindingList<KomitentPogled>(lista);
            if (lista is null) MessageBox.Show("Sistem ne moze da ucita listu");
            dgvPrikaz.DataSource = lista;

        }

        private void btnDodaj_Click(object sender, EventArgs e)
        {
            KomitentPogled k = new KomitentPogled() { KomitentId = komitenti.Max((m) => m.KomitentId) + 1 };
            FrmKomitentPogledDodaj form = new FrmKomitentPogledDodaj(Operacija.Add, k);
            form.ShowDialog();
        }

        private void btnIzmeni_Click(object sender, EventArgs e)
        {
            KomitentPogled k = SelectKomitent();
            if (k is null) return;
            FrmKomitentPogledDodaj form = new FrmKomitentPogledDodaj(Operacija.Update, k);
            form.ShowDialog();
        }

        private void btnObrisi_Click(object sender, EventArgs e)
        {
            KomitentPogled k = SelectKomitent();
            if (k is null) return;
            if (KontrolerKomitentPogled.Instance.Delete(k))
            {
                MessageBox.Show("Uspesno obrisano");
                komitenti.Remove(k);
                dgvPrikaz.DataSource = komitenti;
            }
            else MessageBox.Show("Neuspesno obrisano!");
        }
        private KomitentPogled SelectKomitent()
        {
            KomitentPogled komitent = null;
            try
            {
                komitent = (KomitentPogled)dgvPrikaz.SelectedRows[0].DataBoundItem;
                return komitent;
            }
            catch (Exception )
            {
                MessageBox.Show("Niste selektovali");
                return null;
            }
        }
    }
}
