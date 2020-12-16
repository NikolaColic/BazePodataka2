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
        BindingList<Trebovanje> trebovanja = new BindingList<Trebovanje>();
        public FrmTrebovanjePrikaz()
        {
            InitializeComponent();
            PripremiFormu();
        }
        private void PripremiFormu()
        {
            List<Trebovanje> lista = KontrolerTrebovanje.Instance.Select(new Trebovanje());
            trebovanja = new BindingList<Trebovanje>(lista);
            if (lista is null) MessageBox.Show("Sistem ne moze da ucita listu");
            dgvPrikaz.DataSource = lista;
        }

        private void btnDodaj_Click(object sender, EventArgs e)
        {
            Trebovanje t = new Trebovanje();
            t.ListaStavki = new List<StavkaTrebovanja>();
            t.TrebovanjeId = trebovanja.Max(m => m.TrebovanjeId) + 1;
            FrmTrebovanjeDodaj form = new FrmTrebovanjeDodaj(Operacija.Add, t);
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
            if (KontrolerTrebovanje.Instance.Delete(t))
            {
                MessageBox.Show("Uspesno!");
                trebovanja.Remove(t);
                dgvPrikaz.DataSource = trebovanja;
            }
            else
            {
                MessageBox.Show("Neuspesno!");
            }
        }
        private Trebovanje SelectTrebovanje()
        {
            Trebovanje trebovanje = null;
            try
            {
                trebovanje = (Trebovanje)dgvPrikaz.SelectedRows[0].DataBoundItem;
                return trebovanje;
            }
            catch (Exception)
            {
                MessageBox.Show("Niste selektovali");
                return null;
            }
        }
    }
}
