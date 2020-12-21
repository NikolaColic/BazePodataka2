using Domen.DomenskiObjekat;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domen.DomenskeKlase
{
    public class KalkulacijaKafa : IOpstiDomenskiObjekat
    {
        public Kafa Kafa { get; set; }
        public Kalkulacija Kalkulacija { get; set; }
        public string NazivKafe { get; set; }
        public DateTime DatumOd { get; set; }
        public DateTime DatumDo { get; set; }

        public List<IOpstiDomenskiObjekat> GetReaderResult(SqlDataReader reader)
        {

            List<IOpstiDomenskiObjekat> lista = new List<IOpstiDomenskiObjekat>();

            while (reader.Read())
            {
                KalkulacijaKafa kk = new KalkulacijaKafa();
                Kafa k = new Kafa();
                k.KafaId = Convert.ToInt32(reader[0]);
                kk.NazivKafe = reader["nazivKafe"].ToString();
                k.NazivKafe = kk.NazivKafe;
                kk.Kafa = k;
                kk.DatumOd = Convert.ToDateTime(reader["datumOd"]);
                try
                {
                    kk.DatumDo = Convert.ToDateTime(reader["datumDo"]);
                }
                catch (Exception)
                {
                    kk.DatumDo = new DateTime(1000,1,1);
                }
                Kalkulacija ka = new Kalkulacija();
                ka.SifraKalkulacije = Convert.ToInt32(reader[1]);
                ka.ProdajnaCena = Convert.ToDouble(reader["prodajnaCena"]);
                kk.Kalkulacija = ka;
                lista.Add(kk);
            }
            
            reader.Close();
            return lista;
        }

        public string Insert()
        {
            return $"{Kafa.KafaId},{Kalkulacija.SifraKalkulacije},'{NazivKafe}','{DatumOd}',NULL";
        }

        public string Join()
        {
            return "join Kafa k on (kk.kafaId = k.kafaId) join Kalkulacija ka on (ka.sifraKalkulacije = kk.sifraKalkulacije)";
        }

        public string Table()
        {
            return "KalkulacijaKafa";
        }

        public string Table2()
        {
            return "KalkulacijaKafa kk";
        }

        public string Update()
        {
            return $"datumOd = '{DatumOd}',datumDo ='{DatumDo}'";

        }

        public string Where()
        {
            return $"where kafaId = {Kafa.KafaId} and sifraKalkulacije = {Kalkulacija.SifraKalkulacije} and datumOd = '{DatumOd}'";
        }
    }
}
