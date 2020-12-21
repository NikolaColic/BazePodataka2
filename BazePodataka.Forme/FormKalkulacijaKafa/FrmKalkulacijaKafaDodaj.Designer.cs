
namespace BazePodataka.Forme.FormKalkulacijaKafa
{
    partial class FrmKalkulacijaKafaDodaj
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
            this.label2 = new System.Windows.Forms.Label();
            this.btnDodaj = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.cmbKalkulacija = new System.Windows.Forms.ComboBox();
            this.txtDatumOd = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // cmbKafa
            // 
            this.cmbKafa.FormattingEnabled = true;
            this.cmbKafa.Location = new System.Drawing.Point(110, 12);
            this.cmbKafa.Name = "cmbKafa";
            this.cmbKafa.Size = new System.Drawing.Size(152, 24);
            this.cmbKafa.TabIndex = 14;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(18, 70);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(79, 17);
            this.label2.TabIndex = 11;
            this.label2.Text = "Kalkulacija:";
            // 
            // btnDodaj
            // 
            this.btnDodaj.Location = new System.Drawing.Point(173, 137);
            this.btnDodaj.Name = "btnDodaj";
            this.btnDodaj.Size = new System.Drawing.Size(89, 33);
            this.btnDodaj.TabIndex = 10;
            this.btnDodaj.Text = "Dodaj";
            this.btnDodaj.UseVisualStyleBackColor = true;
            this.btnDodaj.Click += new System.EventHandler(this.btnDodaj_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(18, 17);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(41, 17);
            this.label1.TabIndex = 8;
            this.label1.Text = "Kafa:";
            // 
            // cmbKalkulacija
            // 
            this.cmbKalkulacija.FormattingEnabled = true;
            this.cmbKalkulacija.Location = new System.Drawing.Point(110, 63);
            this.cmbKalkulacija.Name = "cmbKalkulacija";
            this.cmbKalkulacija.Size = new System.Drawing.Size(152, 24);
            this.cmbKalkulacija.TabIndex = 16;
            // 
            // txtDatumOd
            // 
            this.txtDatumOd.Location = new System.Drawing.Point(110, 103);
            this.txtDatumOd.Name = "txtDatumOd";
            this.txtDatumOd.Size = new System.Drawing.Size(152, 22);
            this.txtDatumOd.TabIndex = 17;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(18, 108);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(73, 17);
            this.label3.TabIndex = 18;
            this.label3.Text = "Datum od:";
            // 
            // FrmKalkulacijaKafaDodaj
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(330, 228);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txtDatumOd);
            this.Controls.Add(this.cmbKalkulacija);
            this.Controls.Add(this.cmbKafa);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.btnDodaj);
            this.Controls.Add(this.label1);
            this.Name = "FrmKalkulacijaKafaDodaj";
            this.Text = "FrmKalkulacijaKafaDodaj";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.ComboBox cmbKafa;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnDodaj;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cmbKalkulacija;
        private System.Windows.Forms.TextBox txtDatumOd;
        private System.Windows.Forms.Label label3;
    }
}