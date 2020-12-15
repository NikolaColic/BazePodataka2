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
            if (operacija == Operacija.Update)
            {
                this.otpremnica = otpremnica;
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
            bool znak = KontrolerOtpremnica.Instance.Update(new Otpremnica());
        }

        private void btnDodaj_Click(object sender, EventArgs e)
        {
            bool znak = KontrolerOtpremnica.Instance.Insert(new Otpremnica());
        }
    }
}
