using BazePodataka.Kontroler.Kontroleri;
using Domen.DomenskeKlase;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BazePodataka.Forme.FormKalkulacijaKafa
{
    public partial class FrmKalkulacijaKafaPrikaz : Form
    {
        private BindingList<KalkulacijaKafa> kalkulacije;
        public FrmKalkulacijaKafaPrikaz()
        {
            InitializeComponent();
            PripremiFormu();
        }
        private void PripremiFormu()
        {
            List<KalkulacijaKafa> lista = KontrolerKalkulacijaKafa.Instance.Select(new KalkulacijaKafa());
            kalkulacije = new BindingList<KalkulacijaKafa>(lista);
            lista = lista.OrderBy((s) => s.DatumOd).ToList();
            if (lista is null) MessageBox.Show("Sistem ne moze da ucita listu");
            dgvPrikaz.DataSource = lista;

        }

        private void btnDodaj_Click(object sender, EventArgs e)
        {
            FrmKalkulacijaKafaDodaj form = new FrmKalkulacijaKafaDodaj();
            form.ShowDialog();
        }

        private void btnObrisi_Click(object sender, EventArgs e)
        {
            KalkulacijaKafa k = SelectKalkulacijaKafa();
            if (k is null) return;
            if (KontrolerKalkulacijaKafa.Instance.Delete(k))
            {
                MessageBox.Show("Uspesno obrisano");
                kalkulacije.Remove(k);

                dgvPrikaz.DataSource = kalkulacije;
            }
            else MessageBox.Show("Neuspesno obrisano!");
        }

        private KalkulacijaKafa SelectKalkulacijaKafa()
        {
            KalkulacijaKafa kalkulacija = null;
            try
            {
                kalkulacija = (KalkulacijaKafa)dgvPrikaz.SelectedRows[0].DataBoundItem;
                return kalkulacija;
            }
            catch (Exception)
            {
                MessageBox.Show("Niste selektovali");
                return null;
            }
        }
    }
}
