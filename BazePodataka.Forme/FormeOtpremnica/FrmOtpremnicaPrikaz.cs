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

namespace BazePodataka.Forme.FormeOtpremnica
{
    public partial class FrmOtpremnicaPrikaz : Form
    {
        List<Otpremnica> otpremnice = new List<Otpremnica>();
        public FrmOtpremnicaPrikaz()
        {
            InitializeComponent();
            PripremiFormu();
        }

        private void PripremiFormu()
        {
            otpremnice = KontrolerOtpremnica.Instance.Select(new Otpremnica());
            if (otpremnice is null) MessageBox.Show("Sistem ne moze da ucita listu");
            dgvPrikaz.DataSource = otpremnice;

        }
        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void btnObrisi_Click(object sender, EventArgs e)
        {
            Otpremnica o = SelectOtpremnica();
            if (o is null) return;
            bool znak = KontrolerOtpremnica.Instance.Delete(o);
        }

        private void btnIzmeni_Click(object sender, EventArgs e)
        {
            Otpremnica o = SelectOtpremnica();
            if (o is null) return;
            FrmOtpremnicaDodaj form = new FrmOtpremnicaDodaj(Operacija.Update, o);
            form.ShowDialog();
        }

        private void btnDodaj_Click(object sender, EventArgs e)
        {
            FrmOtpremnicaDodaj form = new FrmOtpremnicaDodaj(Operacija.Add, null);
            form.ShowDialog();
        }

        private void dgvPrikaz_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
        private Otpremnica SelectOtpremnica()
        {
            Otpremnica otpremnica = null;
            try
            {
                otpremnica = (Otpremnica)dgvPrikaz.SelectedRows[0].DataBoundItem;
                return otpremnica;
            }
            catch (Exception ef)
            {
                MessageBox.Show("Niste selektovali");
                return null;
            }
        }
    }
}
