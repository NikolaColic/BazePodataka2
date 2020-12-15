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
        List<Valuta> valute = new List<Valuta>();
        public FrmValutaPrikaz()
        {
            InitializeComponent();
            PripremiFormu();
        }
        private void PripremiFormu()
        {
            valute = KontrolerValuta.Instance.Select(new Valuta());
            if (valute is null) MessageBox.Show("Sistem ne moze da ucita listu");
            dgvPrikaz.DataSource = valute;
        }

        private void btnDodaj_Click(object sender, EventArgs e)
        {
            FrmValutaDodaj form = new FrmValutaDodaj(Operacija.Add, null);
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
            bool znak = KontrolerValuta.Instance.Delete(v);
        }

        private Valuta SelectValuta()
        {
            Valuta valuta = null;
            try
            {
                valuta = (Valuta)dgvPrikaz.SelectedRows[0].DataBoundItem;
                return valuta;
            }
            catch (Exception ef)
            {
                MessageBox.Show("Niste selektovali");
                return null;
            }
        }
    }
}
