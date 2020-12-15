using Domen.DomenskiObjekat;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domen.DomenskeKlase
{
    public class StavkaTrebovanja : IOpstiDomenskiObjekat
    {
        public Trebovanje Trebovanje { get; set; }
        public int RbrStavke { get; set; }
        public double Cena { get; set; }
        public int Kolicina { get; set; }
        public Kafa Kafa { get; set; }

        public List<IOpstiDomenskiObjekat> GetReaderResult(SqlDataReader reader)
        {
            throw new NotImplementedException();
        }

        public string Insert()
        {
            return $"{Trebovanje.TrebovanjeId},{Cena},{Kolicina},{Kafa.KafaId}";
        }

        public string Join()
        {
            return "join Kafa k on (kk.kafaId = st.kafaId) join Trebovanje t on (t.trebovanjeId = st.trebovanjeId)";

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
            return $"rbrStavke ={RbrStavke}";
        }
    }
}
