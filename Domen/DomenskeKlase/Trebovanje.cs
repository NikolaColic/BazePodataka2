using Domen.DomenskiObjekat;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domen.DomenskeKlase
{
    public class Trebovanje : IOpstiDomenskiObjekat
    {
        public int TrebovanjeId { get; set; }
        public DateTime Datum { get; set; }
        public Komitent Komitent { get; set; }
        public double Ukupno { get; set; }

        public List<StavkaTrebovanja> ListaStavki { get; set; }

        public override bool Equals(object obj)
        {
            return base.Equals(obj);
        }

        public List<IOpstiDomenskiObjekat> GetReaderResult(SqlDataReader reader)
        {
            List<IOpstiDomenskiObjekat> lista = new List<IOpstiDomenskiObjekat>();

            while (reader.Read())
            {
                Trebovanje t = new Trebovanje();
                t.TrebovanjeId = Convert.ToInt32(reader[0]);
                t.Datum = Convert.ToDateTime(reader[1]);
                t.Ukupno = Convert.ToDouble(reader["Ukupno"]);
                Komitent k = new Komitent();
                k.KomitentId = Convert.ToInt32(reader["komitentId"]);
                k.NazivKomitenta = reader["nazivKomitenta"].ToString();
                t.Komitent = k;
                lista.Add(t);
            }

            reader.Close();
            return lista;
        }


        public string Insert()
        {
            return $"'{Datum}',{Komitent.KomitentId},{Ukupno}";
        }

        public string Join()
        {
            return "join Komitent2 k on (k.komitentId = t.komitentId)";
        }

        public string Table()
        {
            return "Trebovanje";
        }

        public string Table2()
        {
            return "Trebovanje t";
        }

        public override string ToString()
        {
            return TrebovanjeId + "";
        }

        public string Update()
        {
            return $"datum = '{Datum}',komitentId = {Komitent.KomitentId},Ukupno = {Ukupno}";

        }

        public string Where()
        {
            return $"where trebovanjeId = {TrebovanjeId}";
        }
    }
}
