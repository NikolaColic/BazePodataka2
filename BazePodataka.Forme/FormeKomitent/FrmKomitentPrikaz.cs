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
        List<Komitent> komitenti = new List<Komitent>();
        public FrmKomitentPrikaz()
        {
            InitializeComponent();
            PripremiFormu();
        }
        private void PripremiFormu()
        {
            komitenti = KontrolerKomitent.Instance.Select(new Komitent());
            if (komitenti is null) MessageBox.Show("Sistem ne moze da ucita listu");
            dgvPrikaz.DataSource = komitenti;

        }

        private void btnDodaj_Click(object sender, EventArgs e)
        {
            FrmKomitentDodaj form = new FrmKomitentDodaj(Operacija.Add, null);
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
            bool znak = KontrolerKomitent.Instance.Delete(k);
        }
        private Komitent SelectKomitent()
        {
            Komitent komitent = null;
            try
            {
                komitent = (Komitent)dgvPrikaz.SelectedRows[0].DataBoundItem;
                return komitent;
            }
            catch (Exception ef)
            {
                MessageBox.Show("Niste selektovali");
                return null;
            }
        }
    }
}
