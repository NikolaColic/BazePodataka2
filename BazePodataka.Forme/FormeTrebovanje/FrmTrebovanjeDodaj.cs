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

namespace BazePodataka.Forme.FormeTrebovanje
{
    public partial class FrmTrebovanjeDodaj : Form
    {
        Trebovanje trebovanje;
        BindingList<StavkaTrebovanja> stavke = new BindingList<StavkaTrebovanja>();
        public FrmTrebovanjeDodaj(Operacija operacija, Trebovanje trebovanje)
        {
            InitializeComponent();
            PripremiFormu();
            if (operacija == Operacija.Update)
            {
                this.trebovanje = trebovanje;
                ButtonUpdate();
                PopuniVrednosti(trebovanje);
            }
            if (operacija == Operacija.Add)
            {
                ButtonAdd();
            }
            txtUkupno.Enabled = false;
        }
        private void PripremiFormu()
        {
            List<Kafa> kafe = KontrolerKafa.Instance.Select(new Kafa());
            List<Komitent> komitenti = KontrolerKomitent.Instance.Select(new Komitent());
            cmbKomitent.DataSource = komitenti;
            cmbKafa.DataSource = kafe;
        }
        private void PopuniVrednosti(Trebovanje trebovanje)
        {
            txtDatum.Text = trebovanje.Datum.ToString();
            txtKolicina.Text = "";
            txtCena.Text = "";
            txtUkupno.Text = trebovanje.Ukupno.ToString();
            cmbKomitent.SelectedItem = trebovanje.Komitent;
            cmbKomitent.Enabled = false;
            dgvStavke.DataSource = trebovanje.ListaStavki;
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
            bool znak = KontrolerTrebovanje.Instance.Update(new Trebovanje());
        }

        private void btnDodaj_Click(object sender, EventArgs e)
        {
            bool znak = KontrolerTrebovanje.Instance.Insert(new Trebovanje());
        }

        private void btnDodajStavku_Click(object sender, EventArgs e)
        {
            stavke.Add(new StavkaTrebovanja());
            dgvStavke.DataSource = stavke;
        }
    }
}
