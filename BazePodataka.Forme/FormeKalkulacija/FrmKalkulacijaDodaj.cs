using BazePodataka.Kontroler.Kontroleri;
using Domen.DomenskeKlase;
using Domen.Korisno;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BazePodataka.Forme.FormeKalkulacija
{
    public partial class FrmKalkulacijaDodaj : Form
    {
        Kalkulacija kalkulacija;
        public FrmKalkulacijaDodaj(Operacija operacija, Kalkulacija kalkulacija)
        {
            InitializeComponent();
            this.kalkulacija = kalkulacija;
            if (operacija == Operacija.Update)
            {
                ButtonUpdate();
                PopuniVrednosti(kalkulacija);
            }
            if (operacija == Operacija.Add)
            {
                ButtonAdd();
            }
        }

        private void PopuniVrednosti(Kalkulacija kalkulacija)
        {
            txtDatum.Text = kalkulacija.Datum.ToString();
            txtKolicina.Text = kalkulacija.Kolicina.ToString();
            txtOtkupnaCena.Text = kalkulacija.OktupnaCena.ToString();
            txtProdajna.Text = kalkulacija.ProdajnaCena.ToString();
            txtStopaRabata.Text = kalkulacija.StopaRabata.ToString();
            txtStopaRUC.Text = kalkulacija.StopaRUC.ToString();
            txtZavisniTrosak.Text = kalkulacija.ZavisniTrosak.ToString();
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
            Kalkulacija k = KreirajKalkulaciju();
            if (k is null) return;
            if (KontrolerKalkulacija.Instance.Update(k)) MessageBox.Show("Uspesna izmena");
            else MessageBox.Show("Neuspesna izmena");

        }

        private void btnDodaj_Click(object sender, EventArgs e)
        {
            Kalkulacija k = KreirajKalkulaciju();
            if (k is null) return;
            if (KontrolerKalkulacija.Instance.Insert(k)) MessageBox.Show("Uspesan unos");
            else MessageBox.Show("Neuspesan unos");
        }

        private Kalkulacija KreirajKalkulaciju()
        {
            
            try
            {
                DateTime datum = Convert.ToDateTime(txtDatum.Text.Trim());
                Kalkulacija k = new Kalkulacija()
                {
                    SifraKalkulacije = kalkulacija.SifraKalkulacije,
                    Datum = Convert.ToDateTime(txtDatum.Text.Trim()),
                    Kolicina = Convert.ToDouble(txtKolicina.Text.Trim()),
                    OktupnaCena = Convert.ToDouble(txtOtkupnaCena.Text.Trim()),
                    ProdajnaCena = Convert.ToDouble(txtProdajna.Text.Trim()),
                    StopaRabata = Convert.ToDouble(txtStopaRabata.Text.Trim()),
                    StopaRUC = Convert.ToDouble(txtStopaRUC.Text.Trim()),
                    ZavisniTrosak = Convert.ToDouble(txtZavisniTrosak.Text.Trim())
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
