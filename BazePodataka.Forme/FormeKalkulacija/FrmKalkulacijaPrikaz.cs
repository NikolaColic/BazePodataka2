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
        List<Kalkulacija> listaKalkulacija = new List<Kalkulacija>();
        public FrmKalkulacijaPrikaz()
        {
            InitializeComponent();
            PripremiFormu();
        }
        private void PripremiFormu()
        {
            listaKalkulacija = KontrolerKalkulacija.Instance.Select(new Kalkulacija());
            if (listaKalkulacija is null) MessageBox.Show("Sistem ne moze da ucita listu");
            dgvPrikazKafa.DataSource = listaKalkulacija;

        }
        private void btnDodaj_Click(object sender, EventArgs e)
        {
            FrmKalkulacijaDodaj form = new FrmKalkulacijaDodaj(Operacija.Add, null);
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
            bool znak = KontrolerKalkulacija.Instance.Delete(k);

        }
        private Kalkulacija SelectKalkulacija()
        {
            Kalkulacija kalkulacija = null;
            try
            {
                kalkulacija = (Kalkulacija)dgvPrikazKafa.SelectedRows[0].DataBoundItem;
                return kalkulacija;
            }
            catch (Exception ef)
            {
                MessageBox.Show("Niste selektovali");
                return null;
            }
        }
    }
}
