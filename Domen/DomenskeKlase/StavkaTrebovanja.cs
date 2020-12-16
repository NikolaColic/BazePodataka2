using Domen.DomenskiObjekat;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domen.DomenskeKlase
{
    public class StavkaTrebovanja : IOpstiDomenskiObjekat
    {
        [Browsable(false)]
        public Trebovanje Trebovanje { get; set; }
        public int RbrStavke { get; set; }
        public double Cena { get; set; }
        public int Kolicina { get; set; }
        public Kafa Kafa { get; set; }

        public List<IOpstiDomenskiObjekat> GetReaderResult(SqlDataReader reader)
        {

            List<IOpstiDomenskiObjekat> lista = new List<IOpstiDomenskiObjekat>();

            while (reader.Read())
            {
                StavkaTrebovanja st = new StavkaTrebovanja();
                Trebovanje t = new Trebovanje();
                t.TrebovanjeId = Convert.ToInt32(reader[0]);
                st.RbrStavke = Convert.ToInt32(reader[1]);
                st.Cena = Convert.ToDouble(reader[2]);
                st.Kolicina = Convert.ToInt32(reader[3]);
                st.Trebovanje = t;
                Kafa k = new Kafa();
                k.KafaId = Convert.ToInt32(reader["kafaId"]);
                k.NazivKafe = reader["nazivKafe"].ToString();
                st.Kafa = k;
                lista.Add(st);
            }
            reader.Close();

            return lista;
        }

        public string Insert()
        {
            return $"{Trebovanje.TrebovanjeId},{RbrStavke},{Cena},{Kolicina},{Kafa.KafaId}";
        }

        public string Join()
        {
            return "join Kafa k on (k.kafaId = st.kafaId) join Trebovanje t on (t.trebovanjeId = st.trebovanjeId)";

        }

        public string Table()
        {
            return "StavkeTrebovanja";
        }

        public string Table2()
        {
            return "StavkeTrebovanja st";

        }

        public string Update()
        {
            return $"cena = {Cena},kolicina = {Kolicina},kafaId = {Kafa.KafaId}";

        }

        public string Where()
        {
            return $"where rbrStavke ={RbrStavke}";
        }
    }
}
