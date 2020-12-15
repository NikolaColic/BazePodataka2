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

namespace BazePodataka.Forme.FormeTrebovanje
{
    public partial class FrmTrebovanjePrikaz : Form
    {
        List<Trebovanje> trebovanja = new List<Trebovanje>();
        public FrmTrebovanjePrikaz()
        {
            InitializeComponent();
            PripremiFormu();
        }
        private void PripremiFormu()
        {
            trebovanja = KontrolerTrebovanje.Instance.Select(new Trebovanje());
            if (trebovanja is null) MessageBox.Show("Sistem ne moze da ucita listu");
            dgvPrikaz.DataSource = trebovanja;
        }

        private void btnDodaj_Click(object sender, EventArgs e)
        {
            FrmTrebovanjeDodaj form = new FrmTrebovanjeDodaj(Operacija.Add, null);
            form.ShowDialog();
        }

        private void btnIzmeni_Click(object sender, EventArgs e)
        {
            Trebovanje t = SelectTrebovanje();
            if (t is null) return;
            FrmTrebovanjeDodaj form = new FrmTrebovanjeDodaj(Operacija.Update, t);
            form.ShowDialog();
        }

        private void btnObrisi_Click(object sender, EventArgs e)
        {
            Trebovanje t = SelectTrebovanje();
            if (t is null) return;
            bool znak = KontrolerTrebovanje.Instance.Delete(t);
        }
        private Trebovanje SelectTrebovanje()
        {
            Trebovanje trebovanje = null;
            try
            {
                trebovanje = (Trebovanje)dgvPrikaz.SelectedRows[0].DataBoundItem;
                return trebovanje;
            }
            catch (Exception ef)
            {
                MessageBox.Show("Niste selektovali");
                return null;
            }
        }
    }
}
