
namespace BazePodataka.Forme.FormeTrebovanje
{
    partial class FrmTrebovanjeDodaj
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.cmbKafa = new System.Windows.Forms.ComboBox();
            this.cmbKomitent = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.txtCena = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.txtKolicina = new System.Windows.Forms.TextBox();
            this.btnIzmeni = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.txtUkupno = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.btnDodaj = new System.Windows.Forms.Button();
            this.txtDatum = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.btnDodajStavku = new System.Windows.Forms.Button();
            this.btnObrisiStavku = new System.Windows.Forms.Button();
            this.dgvStavke = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.dgvStavke)).BeginInit();
            this.SuspendLayout();
            // 
            // cmbKafa
            // 
            this.cmbKafa.FormattingEnabled = true;
            this.cmbKafa.Location = new System.Drawing.Point(532, 165);
            this.cmbKafa.Name = "cmbKafa";
            this.cmbKafa.Size = new System.Drawing.Size(152, 24);
            this.cmbKafa.TabIndex = 67;
            // 
            // cmbKomitent
            // 
            this.cmbKomitent.FormattingEnabled = true;
            this.cmbKomitent.Location = new System.Drawing.Point(141, 107);
            this.cmbKomitent.Name = "cmbKomitent";
            this.cmbKomitent.Size = new System.Drawing.Size(152, 24);
            this.cmbKomitent.TabIndex = 66;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(17, 114);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(63, 17);
            this.label4.TabIndex = 65;
            this.label4.Text = "Komitent";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(405, 168);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(37, 17);
            this.label5.TabIndex = 64;
            this.label5.Text = "Kafa";
            // 
            // txtCena
            // 
            this.txtCena.Location = new System.Drawing.Point(143, 208);
            this.txtCena.Name = "txtCena";
            this.txtCena.Size = new System.Drawing.Size(152, 22);
            this.txtCena.TabIndex = 63;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(18, 211);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(41, 17);
            this.label6.TabIndex = 62;
            this.label6.Text = "Cena";
            // 
            // txtKolicina
            // 
            this.txtKolicina.Location = new System.Drawing.Point(142, 168);
            this.txtKolicina.Name = "txtKolicina";
            this.txtKolicina.Size = new System.Drawing.Size(152, 22);
            this.txtKolicina.TabIndex = 61;
            // 
            // btnIzmeni
            // 
            this.btnIzmeni.Location = new System.Drawing.Point(595, 405);
            this.btnIzmeni.Name = "btnIzmeni";
            this.btnIzmeni.Size = new System.Drawing.Size(89, 33);
            this.btnIzmeni.TabIndex = 60;
            this.btnIzmeni.Text = "Izmeni";
            this.btnIzmeni.UseVisualStyleBackColor = true;
            this.btnIzmeni.Visible = false;
            this.btnIzmeni.Click += new System.EventHandler(this.btnIzmeni_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(18, 168);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(57, 17);
            this.label3.TabIndex = 59;
            this.label3.Text = "Kolicina";
            // 
            // txtUkupno
            // 
            this.txtUkupno.Location = new System.Drawing.Point(141, 65);
            this.txtUkupno.Name = "txtUkupno";
            this.txtUkupno.Size = new System.Drawing.Size(152, 22);
            this.txtUkupno.TabIndex = 58;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(17, 68);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(57, 17);
            this.label2.TabIndex = 57;
            this.label2.Text = "Ukupno";
            // 
            // btnDodaj
            // 
            this.btnDodaj.Location = new System.Drawing.Point(595, 405);
            this.btnDodaj.Name = "btnDodaj";
            this.btnDodaj.Size = new System.Drawing.Size(89, 33);
            this.btnDodaj.TabIndex = 56;
            this.btnDodaj.Text = "Dodaj";
            this.btnDodaj.UseVisualStyleBackColor = true;
            this.btnDodaj.Click += new System.EventHandler(this.btnDodaj_Click);
            // 
            // txtDatum
            // 
            this.txtDatum.Location = new System.Drawing.Point(141, 12);
            this.txtDatum.Name = "txtDatum";
            this.txtDatum.Size = new System.Drawing.Size(152, 22);
            this.txtDatum.TabIndex = 55;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(17, 17);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(49, 17);
            this.label1.TabIndex = 54;
            this.label1.Text = "Datum";
            // 
            // btnDodajStavku
            // 
            this.btnDodajStavku.Location = new System.Drawing.Point(595, 203);
            this.btnDodajStavku.Name = "btnDodajStavku";
            this.btnDodajStavku.Size = new System.Drawing.Size(89, 33);
            this.btnDodajStavku.TabIndex = 68;
            this.btnDodajStavku.Text = "Dodaj";
            this.btnDodajStavku.UseVisualStyleBackColor = true;
            this.btnDodajStavku.Click += new System.EventHandler(this.btnDodajStavku_Click);
            // 
            // btnObrisiStavku
            // 
            this.btnObrisiStavku.Location = new System.Drawing.Point(486, 203);
            this.btnObrisiStavku.Name = "btnObrisiStavku";
            this.btnObrisiStavku.Size = new System.Drawing.Size(89, 33);
            this.btnObrisiStavku.TabIndex = 69;
            this.btnObrisiStavku.Text = "Obrisi";
            this.btnObrisiStavku.UseVisualStyleBackColor = true;
            this.btnObrisiStavku.Click += new System.EventHandler(this.btnObrisiStavku_Click);
            // 
            // dgvStavke
            // 
            this.dgvStavke.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvStavke.Location = new System.Drawing.Point(21, 249);
            this.dgvStavke.Name = "dgvStavke";
            this.dgvStavke.RowHeadersWidth = 51;
            this.dgvStavke.RowTemplate.Height = 24;
            this.dgvStavke.Size = new System.Drawing.Size(663, 150);
            this.dgvStavke.TabIndex = 70;
            // 
            // FrmTrebovanjeDodaj
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(694, 444);
            this.Controls.Add(this.dgvStavke);
            this.Controls.Add(this.btnObrisiStavku);
            this.Controls.Add(this.btnDodajStavku);
            this.Controls.Add(this.cmbKafa);
            this.Controls.Add(this.cmbKomitent);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.txtCena);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.txtKolicina);
            this.Controls.Add(this.btnIzmeni);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txtUkupno);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.btnDodaj);
            this.Controls.Add(this.txtDatum);
            this.Controls.Add(this.label1);
            this.Name = "FrmTrebovanjeDodaj";
            this.Text = "FrmTrebovanjeDodaj";
            ((System.ComponentModel.ISupportInitialize)(this.dgvStavke)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox cmbKafa;
        private System.Windows.Forms.ComboBox cmbKomitent;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtCena;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txtKolicina;
        private System.Windows.Forms.Button btnIzmeni;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtUkupno;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnDodaj;
        private System.Windows.Forms.TextBox txtDatum;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnDodajStavku;
        private System.Windows.Forms.Button btnObrisiStavku;
        private System.Windows.Forms.DataGridView dgvStavke;
    }
}