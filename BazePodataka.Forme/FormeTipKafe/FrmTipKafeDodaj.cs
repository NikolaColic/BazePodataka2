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

namespace BazePodataka.Forme.FormeTipKafe
{
    public partial class FrmTipKafeDodaj : Form
    {
        TipKafe tip;
        public FrmTipKafeDodaj(Operacija operacija, TipKafe tip)
        {
            InitializeComponent();
            if (operacija == Operacija.Update)
            {
                this.tip = tip;
                ButtonUpdate();
                PopuniVrednosti(tip);
            }
            if (operacija == Operacija.Add)
            {
                ButtonAdd();
            }
        }

        private void PopuniVrednosti(TipKafe tip)
        {
            txtNaziv.Text = tip.NazivTipa;
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
            bool znak = KontrolerTipKafe.Instance.Update(new TipKafe());
        }

        private void btnDodaj_Click(object sender, EventArgs e)
        {
            bool znak = KontrolerTipKafe.Instance.Insert(new TipKafe());
        }
    }
}
