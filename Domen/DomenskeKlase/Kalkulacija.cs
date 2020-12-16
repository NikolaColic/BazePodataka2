using Domen.DomenskiObjekat;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domen.DomenskeKlase
{
    public class Kalkulacija : IOpstiDomenskiObjekat
    {
        public int SifraKalkulacije { get; set; }
        public double Kolicina { get; set; }
        public double OktupnaCena { get; set; }
        public double ProdajnaCena { get; set; }
        public DateTime Datum { get; set; }
        public double StopaRabata { get; set; }
        public double StopaRUC { get; set; }
        public double ZavisniTrosak { get; set; }

        public override bool Equals(object obj)
        {
            return base.Equals(obj);
        }

        public List<IOpstiDomenskiObjekat> GetReaderResult(SqlDataReader reader)
        {
            List<IOpstiDomenskiObjekat> lista = new List<IOpstiDomenskiObjekat>();

            while (reader.Read())
            {
                Kalkulacija kalkulacija = new Kalkulacija();
                kalkulacija.SifraKalkulacije = Convert.ToInt32(reader[0]);
                kalkulacija.Kolicina = Convert.ToDouble(reader[1]);
                kalkulacija.OktupnaCena = Convert.ToDouble(reader[2]);
                kalkulacija.ProdajnaCena = Convert.ToDouble(reader[3]);
                kalkulacija.Datum = Convert.ToDateTime(reader[4]);
                kalkulacija.StopaRabata = Convert.ToDouble(reader[5]);
                kalkulacija.StopaRUC = Convert.ToDouble(reader[6]);
                kalkulacija.ZavisniTrosak = Convert.ToDouble(reader[7]);
                lista.Add(kalkulacija);
            }
            reader.Close();

            return lista;
        }

        public string Insert()
        {
            return $"{SifraKalkulacije},{Kolicina},{OktupnaCena},{ProdajnaCena},'{Datum}', {StopaRabata},{StopaRUC},{ZavisniTrosak}";
        }

        public string Join()
        {
            return "";
        }

        public string Table()
        {
            return "Kalkulacija";
        }

        public string Table2()
        {
            return "Kalkulacija ka";
        }

        public override string ToString()
        {
            return SifraKalkulacije.ToString();
        }

        public string Update()
        {
            return $"kolicina = {Kolicina},otkupnaCena = {OktupnaCena},prodajnaCena = {ProdajnaCena}, datum ='{Datum}', stopaRabata = {StopaRabata},stopaRUC = {StopaRUC},zavisniTrosak ={ZavisniTrosak}";
        }

        public string Where()
        {
            return $"where sifraKalkulacije = {SifraKalkulacije}";
        }
    }
}
