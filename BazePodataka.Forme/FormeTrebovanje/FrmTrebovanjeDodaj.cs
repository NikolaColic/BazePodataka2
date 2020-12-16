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
    public partial class FrmTrebovanjeDodaj : Form
    {
        Trebovanje trebovanje;
        BindingList<StavkaTrebovanja> stavke = new BindingList<StavkaTrebovanja>();
        List<StavkaTrebovanja> sveStavke = new List<StavkaTrebovanja>();
        List<KalkulacijaKafa> kalkulacije;
        int max = 0;
        public FrmTrebovanjeDodaj(Operacija operacija, Trebovanje trebovanje)
        {
            InitializeComponent();
            PripremiFormu();
            this.trebovanje = trebovanje;
            KreirajListu(trebovanje.ListaStavki);
            if (operacija == Operacija.Update)
            {

                ButtonUpdate();
                PopuniVrednosti(trebovanje);
            }
            if (operacija == Operacija.Add)
            {
                ButtonAdd();
            }
            txtUkupno.Enabled = false;
        }

        private void KreirajListu(List<StavkaTrebovanja> stavkeLista)
        {
            foreach(var stavka in stavkeLista)
            {
                stavke.Add(stavka);
            }
        }
        private void PripremiFormu()
        {
            List<Kafa> kafe = KontrolerKafa.Instance.Select(new Kafa());
            List<Komitent> komitenti = KontrolerKomitent.Instance.Select(new Komitent());
            sveStavke = KontrolerTrebovanje.Instance.SelectStavke(new StavkaTrebovanja());
            max = sveStavke.Max((m) => m.RbrStavke) + 1;

            kalkulacije = KontrolerKafa.Instance.SelectKalkulacija(new KalkulacijaKafa());
            cmbKomitent.DataSource = komitenti;
            cmbKafa.DataSource = kafe;
        }
        private void PopuniVrednosti(Trebovanje trebovanje)
        {
            txtDatum.Text = trebovanje.Datum.ToString();
            txtKolicina.Text = "";
            txtCena.Text = "";
            txtUkupno.Text = trebovanje.Ukupno.ToString();
            cmbKomitent.SelectedItem = trebovanje.Komitent;
            cmbKomitent.Enabled = false;
            dgvStavke.DataSource = trebovanje.ListaStavki;
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
            Trebovanje t = Kreiraj();
            if (t is null) return;
            List<StavkaTrebovanja> stare = trebovanje.ListaStavki;
            t.ListaStavki = stavke.ToList();
            if (KontrolerTrebovanje.Instance.Update(t, stare)) MessageBox.Show("Uspesno!");
            else MessageBox.Show("Neuspesno!");
        }

        private void btnDodaj_Click(object sender, EventArgs e)
        {
            Trebovanje t = Kreiraj();
            if (t is null) return;
            t.ListaStavki = stavke.ToList();
            if (KontrolerTrebovanje.Instance.Insert(t)) MessageBox.Show("Uspesno!");
            else MessageBox.Show("Neuspesno!");
        }

        private void btnDodajStavku_Click(object sender, EventArgs e)
        {
            StavkaTrebovanja st = KreirajStavku();
            if (st is null) return;
            stavke.Add(st);
            dgvStavke.DataSource = stavke;
        }
        private StavkaTrebovanja KreirajStavku()
        {
            try
            {
                Kafa k = (Kafa)cmbKafa.SelectedItem;
                StavkaTrebovanja st = new StavkaTrebovanja()
                {
                    Kolicina = Convert.ToInt32(txtKolicina.Text),
                    Kafa = k,
                    RbrStavke = max,
                    Cena = IzracunajCenu(k),
                    Trebovanje = new Trebovanje()
                };
                max += 1;
                return st;
            }
            catch (Exception)
            {
                MessageBox.Show("Pogresan unos!");
                return null;
            }
        }
        private Trebovanje Kreiraj()
        {
            try
            {
                Trebovanje t = new Trebovanje()
                {
                    TrebovanjeId = trebovanje.TrebovanjeId,
                    Datum = Convert.ToDateTime(txtDatum.Text),
                    Komitent = (Komitent)cmbKomitent.SelectedItem,
                    Ukupno = 0,
                };
                return t;
            }
            catch (Exception)
            {
                MessageBox.Show("Pogresan unos!");
                return null;
            }
        }
        private double IzracunajCenu(Kafa k)
        {
            double cena = kalkulacije.SingleOrDefault(kal => kal.Kafa.KafaId == k.KafaId && kal.DatumDo > DateTime.Now)
                .Kalkulacija.ProdajnaCena;
            return cena;
                
        }

        private void btnObrisiStavku_Click(object sender, EventArgs e)
        {
            StavkaTrebovanja st = SelectStavka();
            if (st is null) return;
            stavke.Remove(st);
            dgvStavke.DataSource = stavke;
        }
        private StavkaTrebovanja SelectStavka()
        {
            StavkaTrebovanja stavka = null;
            try
            {
                stavka = (StavkaTrebovanja)dgvStavke.SelectedRows[0].DataBoundItem;
                return stavka;
            }
            catch (Exception)
            {
                MessageBox.Show("Niste selektovali");
                return null;
            }
        }
    }
}
