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

namespace BazePodataka.Forme.FormeProfaktura
{
    public partial class FrmProfakturaDodaj : Form
    {
        Profaktura profaktura;
        public FrmProfakturaDodaj(Operacija operacija, Profaktura profaktura2)
        {
            InitializeComponent();
            PripremiFormu();
            profaktura = profaktura2;
            if (operacija == Operacija.Update)
            {
                ButtonUpdate();
                PopuniVrednosti(profaktura2);
            }
            if (operacija == Operacija.Add)
            {
                ButtonAdd();
            }
        }
        private void PripremiFormu()
        {
            List<Trebovanje> trebovanja = KontrolerTrebovanje.Instance.Select(new Trebovanje());
            List<Komitent> komitenti = KontrolerKomitent.Instance.Select(new Komitent());
            cmbKomitent.DataSource = komitenti;
            cmbTrebovanje.DataSource = trebovanja;
        }
        private void PopuniVrednosti(Profaktura profaktura)
        {
            txtDatum.Text = profaktura.Datum.ToString();
            txtDepozit.Text = profaktura.Depozit.ToString();
            txtOpis.Text = profaktura.Opis.ToString();
            txtStopaPdv.Text = profaktura.StopaPoreza.ToString();
            cmbKomitent.SelectedItem = profaktura.Komitent;
            cmbTrebovanje.SelectedItem = profaktura.Trebovanje;
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
            Profaktura p = Kreiraj();
            if (p is null) return;
            if (KontrolerProfaktura.Instance.Update(p)) MessageBox.Show("Uspesno!");
            else MessageBox.Show("Neuspesno!");
        }

        private void btnDodaj_Click(object sender, EventArgs e)
        {
            Profaktura p = Kreiraj();
            if (p is null) return;
            if (KontrolerProfaktura.Instance.Insert(p)) MessageBox.Show("Uspesno!");
            else MessageBox.Show("Neuspesno!");
        }

        private Profaktura Kreiraj()
        {
            try
            {
                Profaktura p = new Profaktura()
                {
                    BrojFakture = profaktura.BrojFakture,
                    Datum = Convert.ToDateTime(txtDatum.Text),
                    Depozit = Convert.ToDouble(txtDepozit.Text),
                    StopaPoreza = Convert.ToDouble(txtStopaPdv.Text),
                    Opis = txtOpis.Text,
                    Komitent = (Komitent)cmbKomitent.SelectedItem,
                    Trebovanje = (Trebovanje)cmbTrebovanje.SelectedItem
                };
                return p;
            }
            catch (Exception)
            {
                MessageBox.Show("Pogresan unos");
                return null;
            }
        }
    }
}
