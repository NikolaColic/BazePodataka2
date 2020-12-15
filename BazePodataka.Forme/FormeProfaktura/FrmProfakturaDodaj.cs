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
            if (operacija == Operacija.Update)
            {
                profaktura = profaktura2;
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
            bool znak = KontrolerProfaktura.Instance.Update(new Profaktura());
        }

        private void btnDodaj_Click(object sender, EventArgs e)
        {
            bool znak = KontrolerProfaktura.Instance.Insert(new Profaktura());
        }
    }
}
