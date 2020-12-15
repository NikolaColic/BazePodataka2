using Domen.DomenskiObjekat;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domen.DomenskeKlase
{
    public class Otpremnica : IOpstiDomenskiObjekat
    {
        public int SifraOtpremnice { get; set; }
        public double PreostaloUplata { get; set; }
        public DateTime DatumIzdavanja { get; set; }
        public double UplaceniAvansi { get; set; }
        public string Napomena { get; set; }
        public DateTime DatumPrometa { get; set; }
        public string NazivValute { get; set; }
        public Valuta Valuta { get; set; }

        public List<IOpstiDomenskiObjekat> GetReaderResult(SqlDataReader reader)
        {
            List<IOpstiDomenskiObjekat> lista = new List<IOpstiDomenskiObjekat>();

            while (reader.Read())
            {
                Otpremnica o = new Otpremnica();
                o.SifraOtpremnice = Convert.ToInt32(reader[0]);
                o.PreostaloUplata = Convert.ToDouble(reader[1]);
                o.DatumIzdavanja = Convert.ToDateTime(reader[2]);
                o.UplaceniAvansi = Convert.ToDouble(reader[3]);
                o.Napomena = reader[4].ToString();
                o.DatumPrometa = Convert.ToDateTime(reader[5]);
                Valuta v = new Valuta();
                v.ValutaId = Convert.ToInt32(reader[6]);
                v.NazivValute = reader["nazivValute"].ToString();
                o.NazivValute = reader["nazivValute"].ToString();
                o.Valuta = v;
                lista.Add(o);
            }

            reader.Close();
            return lista;
        }

        public string Insert()
        {
            return $"{PreostaloUplata},'{DatumIzdavanja}',{UplaceniAvansi},'{Napomena}','{DatumPrometa}',{Valuta.ValutaId},'{NazivValute}'";
        }

        public string Join()
        {
            return $"join Valuta v on (v.valutaId = o.valutaId)";
        }

        public string Table()
        {
            return "Otpremnica";
        }

        public string Table2()
        {
            return "Otpremnica o";

        }

        public string Update()
        {
            return $"preostaloUplata ={PreostaloUplata},datumIzdavanja = '{DatumIzdavanja}',uplaceniAvansi = {UplaceniAvansi},napomena = '{Napomena}',datumPrometa ='{DatumPrometa}',valutaId = {Valuta.ValutaId}";

        }

        public string Where()
        {
            return $"sifraOtpremnice = {SifraOtpremnice}";
        }
    }
}
