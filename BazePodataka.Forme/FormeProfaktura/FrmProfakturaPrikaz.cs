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
        List<Profaktura> profakture = new List<Profaktura>();
        public FrmProfakturaPrikaz()
        {
            InitializeComponent();
            PripremiFormu();
        }
        private void PripremiFormu()
        {
            profakture = KontrolerProfaktura.Instance.Select(new Profaktura());
            if (profakture is null) MessageBox.Show("Sistem ne moze da ucita listu");
            dgvPrikaz.DataSource = profakture;
        }

        private void btnDodaj_Click(object sender, EventArgs e)
        {
            FrmProfakturaDodaj form = new FrmProfakturaDodaj(Operacija.Add, null);
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
            bool znak = KontrolerProfaktura.Instance.Delete(p);
        }
        private Profaktura SelectProfaktura()
        {
            Profaktura profaktura = null;
            try
            {
                profaktura = (Profaktura)dgvPrikaz.SelectedRows[0].DataBoundItem;
                return profaktura;
            }
            catch (Exception ef)
            {
                MessageBox.Show("Niste selektovali");
                return null;
            }
        }
    }
}
