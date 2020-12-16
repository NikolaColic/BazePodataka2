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
    public partial class FrmKomitentPrikaz : Form
    {
        BindingList<Komitent> komitenti;
        public FrmKomitentPrikaz()
        {
            InitializeComponent();
            PripremiFormu();
        }
        private void PripremiFormu()
        {
            List<Komitent> lista = KontrolerKomitent.Instance.Select(new Komitent());
            komitenti = new BindingList<Komitent>(lista);
            if (lista is null) MessageBox.Show("Sistem ne moze da ucita listu");
            dgvPrikaz.DataSource = lista;

        }

        private void btnDodaj_Click(object sender, EventArgs e)
        {
            Komitent k = new Komitent() { KomitentId = komitenti.Max((m) => m.KomitentId) + 1 };
            FrmKomitentDodaj form = new FrmKomitentDodaj(Operacija.Add, k);
            form.ShowDialog();
        }

        private void btnIzmeni_Click(object sender, EventArgs e)
        {
            Komitent k = SelectKomitent();
            if (k is null) return;
            FrmKomitentDodaj form = new FrmKomitentDodaj(Operacija.Update, k);
            form.ShowDialog();
        }

        private void btnObrisi_Click(object sender, EventArgs e)
        {
            Komitent k = SelectKomitent();
            if (k is null) return;
            if (KontrolerKomitent.Instance.Delete(k))
            {
                MessageBox.Show("Uspesno obrisano");
                komitenti.Remove(k);
                dgvPrikaz.DataSource = komitenti;
            }
            else MessageBox.Show("Neuspesno obrisano!");
        }
        private Komitent SelectKomitent()
        {
            Komitent komitent = null;
            try
            {
                komitent = (Komitent)dgvPrikaz.SelectedRows[0].DataBoundItem;
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
