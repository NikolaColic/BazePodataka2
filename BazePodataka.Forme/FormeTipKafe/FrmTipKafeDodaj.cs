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
            this.tip = tip;
            if (operacija == Operacija.Update)
            {
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
            TipKafe tip = Kreiraj();
            if (tip is null) return;
            if (KontrolerTipKafe.Instance.Update(tip)) MessageBox.Show("Uspesno!");
            else MessageBox.Show("Neuspesno");
        }

        private void btnDodaj_Click(object sender, EventArgs e)
        {
            TipKafe tip = Kreiraj();
            if (tip is null) return;
            if (KontrolerTipKafe.Instance.Insert(tip)) MessageBox.Show("Uspesno!");
            else MessageBox.Show("Neuspesno");
        }

        private TipKafe Kreiraj()
        {
            try
            {
                TipKafe t = new TipKafe()
                {
                    TipKafeId = tip.TipKafeId,
                    NazivTipa = txtNaziv.Text
                };
                return t;
            }
            catch (Exception)
            {
                MessageBox.Show("Pogresan unos!");
                return null;
            }
        }
    }
}
