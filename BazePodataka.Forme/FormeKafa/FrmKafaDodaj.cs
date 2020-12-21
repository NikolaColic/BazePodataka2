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

namespace BazePodataka.Forme.FormeKafa
{
    public partial class FrmKafaDodaj : Form
    {
        Kafa kafa;
        public FrmKafaDodaj(Operacija operacija, Kafa kafa)
        {
           
            InitializeComponent();
            PripremiFormu();
            this.kafa = kafa;
            if (operacija == Operacija.Update)
            {
                ButtonUpdate();
                PopuniVrednosti(kafa);
            }
            if (operacija == Operacija.Add)
            {
                ButtonAdd();
            }
        }

        private void PripremiFormu()
        {
            List<TipKafe> tipovi = KontrolerTipKafe.Instance.Select(new TipKafe());
            cmbTipKafe.DataSource = tipovi;
            List<Kalkulacija> kalkulacija = KontrolerKalkulacija.Instance.Select(new Kalkulacija());
        }

        private void PopuniVrednosti(Kafa kafa)
        {
            txtNaziv.Text = kafa.NazivKafe;
            txtOpis.Text = kafa.Opis;
            cmbTipKafe.SelectedItem = kafa.TipKafe;
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
            Kafa k = KreirajObjekat();
            if (k is null) return;
            k.KafaId = kafa.KafaId;
            if (KontrolerKafa.Instance.Update(k)) MessageBox.Show("Uspesna izmena!");
            else MessageBox.Show("Neuspesna izmena");
        }

        private void btnDodaj_Click(object sender, EventArgs e)
        {

            Kafa k = KreirajObjekat();
            if (k is null) return;
            if (KontrolerKafa.Instance.Insert(k)) MessageBox.Show("Uspesan unos!");
            else MessageBox.Show("Neuspesan unos!");

        }

        private Kafa KreirajObjekat()
        {
            try
            {
                Kafa k = new Kafa()
                {
                    KafaId = kafa.KafaId,
                    NazivKafe = txtNaziv.Text,
                    Opis = txtOpis.Text,
                    TipKafe = (TipKafe)cmbTipKafe.SelectedItem
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
