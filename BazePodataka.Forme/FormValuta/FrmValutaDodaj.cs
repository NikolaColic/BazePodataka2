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

namespace BazePodataka.Forme.FormValuta
{
    public partial class FrmValutaDodaj : Form
    {
        Valuta valuta;
        public FrmValutaDodaj(Operacija operacija, Valuta valuta)
        {
            InitializeComponent();
            if (operacija == Operacija.Update)
            {
                this.valuta = valuta;
                ButtonUpdate();
                PopuniVrednosti(valuta);
            }
            if (operacija == Operacija.Add)
            {
                ButtonAdd();
            }
        }

        private void PopuniVrednosti(Valuta valuta)
        {
            txtNaziv.Text = valuta.NazivValute;
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
            bool znak = KontrolerValuta.Instance.Update(new Valuta());
        }

        private void btnDodaj_Click(object sender, EventArgs e)
        {
            bool znak = KontrolerValuta.Instance.Insert(new Valuta());
        }
    }
}
