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

namespace BazePodataka.Forme.FormeKalkulacija
{
    public partial class FrmKalkulacijaDodaj : Form
    {
        Kalkulacija kalkulacija;
        public FrmKalkulacijaDodaj(Operacija operacija, Kalkulacija kalkulacija)
        {
            InitializeComponent();
            if (operacija == Operacija.Update)
            {
                this.kalkulacija = kalkulacija;
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
            bool znal = KontrolerKalkulacija.Instance.Update(new Kalkulacija());

        }

        private void btnDodaj_Click(object sender, EventArgs e)
        {
            bool znal = KontrolerKalkulacija.Instance.Insert(new Kalkulacija());
        }
    }
}
