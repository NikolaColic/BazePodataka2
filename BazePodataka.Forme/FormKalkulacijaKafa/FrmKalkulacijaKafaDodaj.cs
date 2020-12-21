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
    public partial class FrmKalkulacijaKafaDodaj : Form
    {
        public FrmKalkulacijaKafaDodaj()
        {
            InitializeComponent();
            PripremiFormu();
        }
        private void PripremiFormu()
        {
            List<Kafa> kafe = KontrolerKafa.Instance.Select(new Kafa());
            cmbKafa.DataSource = kafe;
            List<Kalkulacija> kalkulacija = KontrolerKalkulacija.Instance.Select(new Kalkulacija());
            cmbKalkulacija.DataSource = kalkulacija;
        }

        private void btnDodaj_Click(object sender, EventArgs e)
        {
            KalkulacijaKafa kk = KreirajKalkulaciju();
            if (kk is null) return;
            if (KontrolerKalkulacijaKafa.Instance.Insert(kk)) MessageBox.Show("Uspesno!");
            else MessageBox.Show("Neuspesno!");
        }

        private KalkulacijaKafa KreirajKalkulaciju()
        {
            try
            {
                KalkulacijaKafa k = new KalkulacijaKafa()
                {
                    DatumOd = Convert.ToDateTime(txtDatumOd.Text),
                    Kafa = (Kafa)cmbKafa.SelectedItem,
                    Kalkulacija = (Kalkulacija)cmbKalkulacija.SelectedItem,

                };
                return k;
            }
            catch (Exception)
            {
                MessageBox.Show("Pogresan unos!");
                return null;
            }
        }
    }
}
