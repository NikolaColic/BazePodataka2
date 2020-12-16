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
    public partial class FrmProfakturaPrikaz : Form
    {
        BindingList<Profaktura> profakture;
        public FrmProfakturaPrikaz()
        {
            InitializeComponent();
            PripremiFormu();
        }
        private void PripremiFormu()
        {
            List<Profaktura> lista = KontrolerProfaktura.Instance.Select(new Profaktura());
            profakture = new BindingList<Profaktura>(lista);
            if (lista is null) MessageBox.Show("Sistem ne moze da ucita listu");
            dgvPrikaz.DataSource = lista;
        }

        private void btnDodaj_Click(object sender, EventArgs e)
        {
            Profaktura p = new Profaktura() { BrojFakture = profakture.Max(m => m.BrojFakture) + 1 };
            FrmProfakturaDodaj form = new FrmProfakturaDodaj(Operacija.Add, p);
            form.ShowDialog();
        }

        private void btnIzmeni_Click(object sender, EventArgs e)
        {
            Profaktura p = SelectProfaktura();
            if (p is null) return;
            FrmProfakturaDodaj form = new FrmProfakturaDodaj(Operacija.Update, p);
            form.ShowDialog();
        }

        private void btnObrisi_Click(object sender, EventArgs e)
        {
            Profaktura p = SelectProfaktura();
            if (p is null) return;
            if (KontrolerProfaktura.Instance.Delete(p))
            {
                MessageBox.Show("Uspesno!");
                profakture.Remove(p);
                dgvPrikaz.DataSource = profakture;
            }
        }
        private Profaktura SelectProfaktura()
        {
            Profaktura profaktura = null;
            try
            {
                profaktura = (Profaktura)dgvPrikaz.SelectedRows[0].DataBoundItem;
                return profaktura;
            }
            catch (Exception )
            {
                MessageBox.Show("Niste selektovali");
                return null;
            }
        }
    }
}
