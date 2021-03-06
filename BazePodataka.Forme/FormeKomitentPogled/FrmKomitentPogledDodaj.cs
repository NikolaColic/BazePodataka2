﻿using BazePodataka.Kontroler.Kontroleri;
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

namespace BazePodataka.Forme.FormeKomitent
{
    public partial class FrmKomitentPogledDodaj : Form
    {
        KomitentPogled komitent;
        public FrmKomitentPogledDodaj(Operacija operacija, KomitentPogled komitent)
        {
            InitializeComponent();
            this.komitent = komitent;
            if (operacija == Operacija.Update)
            {
                ButtonUpdate();
                PopuniVrednosti(komitent);
            }
            if (operacija == Operacija.Add)
            {
                ButtonAdd();
            }
        }

        private void PopuniVrednosti(KomitentPogled komitent)
        {
            txtEmail.Text = komitent.Email;
            txtMaticni.Text = komitent.MaticniBroj;
            txtNaziv.Text = komitent.NazivKomitenta;
            txtOpis.Text = komitent.OpisKomitenta;
            txtPib.Text = komitent.Pib;
            txtBrojTelefona.Text = komitent.BrojTelefona;
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
            KomitentPogled k = KreirajKomitenta();
            if (k is null) return;
            if (KontrolerKomitentPogled.Instance.Update(k)) MessageBox.Show("Uspesno");
            else MessageBox.Show("Neuspesno");
        }

        private void btnDodaj_Click(object sender, EventArgs e)
        {
            KomitentPogled k = KreirajKomitenta();
            if (k is null) return;
            if (KontrolerKomitentPogled.Instance.Insert(k)) MessageBox.Show("Uspesno");
            else MessageBox.Show("Neuspesno");
        }

        private KomitentPogled KreirajKomitenta()
        {
            try
            {
                KomitentPogled k = new KomitentPogled()
                {
                    KomitentId = komitent.KomitentId,
                    BrojTelefona = txtBrojTelefona.Text,
                    Email = txtEmail.Text,
                    MaticniBroj = txtMaticni.Text,
                    NazivKomitenta = txtNaziv.Text,
                    OpisKomitenta = txtOpis.Text,
                    Pib = txtPib.Text
                };
                return k;
            }
            catch (Exception)
            {
                MessageBox.Show("Pogresan unos");
                return null;
            }
        }
    }
}
