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

namespace BazePodataka.Forme.FormeKafa
{
    public partial class FrmKafaPrikaz : Form
    {
        BindingList<Kafa> listaKafi;
        public FrmKafaPrikaz()
        {
            InitializeComponent();
            PripremiFormu();
        }

        private void PripremiFormu()
        {
            List<Kafa> lista = KontrolerKafa.Instance.Select(new Kafa());
            listaKafi = new BindingList<Kafa>(lista);
            if (lista is null) MessageBox.Show("Sistem ne moze da ucita listu");
            dgvPrikazKafa.DataSource = lista;
            
        }

        private void btnDodaj_Click(object sender, EventArgs e)
        {
            int max = listaKafi.Max((s) => s.KafaId);
            FrmKafaDodaj form = new FrmKafaDodaj(Operacija.Add, new Kafa() { KafaId =max+1});
            form.ShowDialog();

        }

        private void btnIzmeni_Click(object sender, EventArgs e)
        {
            Kafa k = SelectKafa();
            if (k is null) return;
            FrmKafaDodaj form = new FrmKafaDodaj(Operacija.Update, k);
            form.ShowDialog();
        }

        private void btnObrisi_Click(object sender, EventArgs e)
        {
            Kafa k = SelectKafa();
            if (k is null) return;
            bool znak = KontrolerKafa.Instance.Delete(k);
            if (znak)
            {
                MessageBox.Show("Uspesno ste obrisali!");
                listaKafi.Remove(k);
                dgvPrikazKafa.DataSource = listaKafi;
                return;
            }
            MessageBox.Show("Ne moze da se obrise!");
        }
        private Kafa SelectKafa()
        {
            Kafa kafa = null;
            try
            {
                kafa = (Kafa)dgvPrikazKafa.SelectedRows[0].DataBoundItem;
                return kafa;
            }
            catch (Exception ef)
            {
                MessageBox.Show("Niste selektovali ");
                Console.WriteLine(ef.Message);
                return null ;
            }
        }
    }
}
