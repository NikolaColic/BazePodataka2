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
    public partial class FrmOtpremnicaDodaj : Form
    {
        Otpremnica otpremnica;
        public FrmOtpremnicaDodaj(Operacija operacija, Otpremnica otpremnica)
        {
            InitializeComponent();
            PripremiFormu();
            this.otpremnica = otpremnica;
            if (operacija == Operacija.Update)
            {
                ButtonUpdate();
                PopuniVrednosti(otpremnica);
            }
            if (operacija == Operacija.Add)
            {
                ButtonAdd();
            }
        }

        private void PripremiFormu()
        {
            List<Valuta> valute = KontrolerValuta.Instance.Select(new Valuta());
            cmbValuta.DataSource = valute;
        }

        private void PopuniVrednosti(Otpremnica otpremnica)
        {
            txtAvansi.Text = otpremnica.UplaceniAvansi.ToString();
            txtDatumIzdavanja.Text = otpremnica.DatumIzdavanja.ToString();
            txtDatumPrometa.Text = otpremnica.DatumPrometa.ToString();
            txtNapomena.Text = otpremnica.Napomena.ToString();
            txtPreostalo.Text = otpremnica.PreostaloUplata.ToString();
            cmbValuta.SelectedItem = otpremnica.Valuta;
        }

        private void ButtonAdd()
        {
            btnDodaj.Visible = true;
            btnIzmeni.Visible = false;
        }

        private void ButtonUpdate()
        {
            btnDodaj.Visible = false;
            btnIzmeni.Visible = true;
        }

        private void btnIzmeni_Click(object sender, EventArgs e)
        {
            Otpremnica o = KreirajOtpremnicu();
            if (o is null) return;
            if (KontrolerOtpremnica.Instance.Update(o)) MessageBox.Show("Uspesno!");
            else MessageBox.Show("Neuspesno!");
        }

        private void btnDodaj_Click(object sender, EventArgs e)
        {
            Otpremnica o = KreirajOtpremnicu();
            if (o is null) return;
            if (KontrolerOtpremnica.Instance.Insert(o)) MessageBox.Show("Uspesno!");
            else MessageBox.Show("Neuspesno!");
        }

        private Otpremnica KreirajOtpremnicu()
        {
            try
            {
                Otpremnica o = new Otpremnica()
                {
                    SifraOtpremnice = otpremnica.SifraOtpremnice,
                    DatumIzdavanja = Convert.ToDateTime(txtDatumIzdavanja.Text),
                    DatumPrometa = Convert.ToDateTime(txtDatumPrometa.Text),
                    Napomena = txtNapomena.Text,
                    PreostaloUplata = Convert.ToDouble(txtPreostalo.Text),
                    UplaceniAvansi = Convert.ToDouble(txtAvansi.Text),
                    Valuta = (Valuta)cmbValuta.SelectedItem
                };
                return o;
            }
            catch (Exception)
            {
                MessageBox.Show("Pogresan unos");
                return null;
            }
        }
    }
}
