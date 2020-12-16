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

namespace BazePodataka.Forme.FormeKalkulacija
{
    public partial class FrmKalkulacijaPrikaz : Form
    {
        BindingList<Kalkulacija> listaKalkulacija;
        public FrmKalkulacijaPrikaz()
        {
            InitializeComponent();
            PripremiFormu();
        }
        private void PripremiFormu()
        {
            List<Kalkulacija> listaKalkulacija2 = KontrolerKalkulacija.Instance.Select(new Kalkulacija());
            listaKalkulacija = new BindingList<Kalkulacija>(listaKalkulacija2);
            if (listaKalkulacija2 is null) MessageBox.Show("Sistem ne moze da ucita listu");
            dgvPrikazKafa.DataSource = listaKalkulacija2;

        }
        private void btnDodaj_Click(object sender, EventArgs e)
        {
            int max = listaKalkulacija.Max((k) => k.SifraKalkulacije);
            FrmKalkulacijaDodaj form = new FrmKalkulacijaDodaj(Operacija.Add, new Kalkulacija() { SifraKalkulacije = max +1});
            form.ShowDialog();
        }

        private void btnIzmeni_Click(object sender, EventArgs e)
        {
            Kalkulacija k = SelectKalkulacija();
            if (k is null) return;
            FrmKalkulacijaDodaj form = new FrmKalkulacijaDodaj(Operacija.Update, k);
            form.ShowDialog();
        }

        private void btnObrisi_Click(object sender, EventArgs e)
        {
            Kalkulacija k = SelectKalkulacija();
            if (k is null) return;
            if (KontrolerKalkulacija.Instance.Delete(k))
            {
                MessageBox.Show("Uspesno obrisano");
                listaKalkulacija.Remove(k);
                dgvPrikazKafa.DataSource = listaKalkulacija;
                dgvPrikazKafa.Refresh();
            }
            else MessageBox.Show("Neuspesan unos");

        }
        private Kalkulacija SelectKalkulacija()
        {
            Kalkulacija kalkulacija = null;
            try
            {
                kalkulacija = (Kalkulacija)dgvPrikazKafa.SelectedRows[0].DataBoundItem;
                return kalkulacija;
            }
            catch (Exception )
            {
                MessageBox.Show("Niste selektovali");
                return null;
            }
        }
    }
}
