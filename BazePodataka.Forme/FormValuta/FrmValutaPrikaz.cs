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
    public partial class FrmValutaPrikaz : Form
    {
        BindingList<Valuta> valute;
        public FrmValutaPrikaz()
        {
            InitializeComponent();
            PripremiFormu();
        }
        private void PripremiFormu()
        {
            List<Valuta> lista = KontrolerValuta.Instance.Select(new Valuta());
            valute = new BindingList<Valuta>(lista);
            if (lista is null) MessageBox.Show("Sistem ne moze da ucita listu");
            dgvPrikaz.DataSource = lista;
        }

        private void btnDodaj_Click(object sender, EventArgs e)
        {
            Valuta v = new Valuta() { ValutaId = valute.Max(m => m.ValutaId) + 1 };
            FrmValutaDodaj form = new FrmValutaDodaj(Operacija.Add, v);
            form.ShowDialog();
        }

        private void btnIzmeni_Click(object sender, EventArgs e)
        {
            Valuta v = SelectValuta();
            if (v is null) return;
            FrmValutaDodaj form = new FrmValutaDodaj(Operacija.Update, v);
            form.ShowDialog();
        }

        private void btnObrisi_Click(object sender, EventArgs e)
        {
            Valuta v = SelectValuta();
            if (v is null) return;
            if (KontrolerValuta.Instance.Delete(v))
            {
                MessageBox.Show("Uspesno!");
                valute.Remove(v);
                dgvPrikaz.DataSource = valute;
                return;
            }
            MessageBox.Show("Neuspesno!");
        }

        private Valuta SelectValuta()
        {
            Valuta valuta = null;
            try
            {
                valuta = (Valuta)dgvPrikaz.SelectedRows[0].DataBoundItem;
                return valuta;
            }
            catch (Exception )
            {
                MessageBox.Show("Niste selektovali");
                return null;
            }
        }
    }
}
