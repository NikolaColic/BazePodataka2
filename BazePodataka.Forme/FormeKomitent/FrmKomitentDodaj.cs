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

namespace BazePodataka.Forme.FormeKomitent
{
    public partial class FrmKomitentDodaj : Form
    {
        Komitent komitent;
        public FrmKomitentDodaj(Operacija operacija, Komitent komitent)
        {
            InitializeComponent();
            if (operacija == Operacija.Update)
            {
                this.komitent = komitent;
                ButtonUpdate();
                PopuniVrednosti(komitent);
            }
            if (operacija == Operacija.Add)
            {
                ButtonAdd();
            }
        }

        private void PopuniVrednosti(Komitent komitent)
        {
            txtEmail.Text = komitent.Email;
            txtMaticni.Text = komitent.MaticniBroj;
            txtNaziv.Text = komitent.NazivKomitenta;
            txtOpis.Text = komitent.OpisKomitenta;
            txtPib.Text = komitent.Pib;
            txtBrojTelefona.Text = komitent.BrojTelefona;
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
            bool znal = KontrolerKomitent.Instance.Update(new Komitent());
        }

        private void btnDodaj_Click(object sender, EventArgs e)
        {
            bool znal = KontrolerKomitent.Instance.Insert(new Komitent());
        }
    }
}
