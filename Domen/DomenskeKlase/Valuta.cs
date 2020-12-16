using Domen.DomenskiObjekat;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domen.DomenskeKlase
{
    public class Valuta : IOpstiDomenskiObjekat
    {
        public int ValutaId { get; set; }
        public string NazivValute { get; set; }

        public override bool Equals(object obj)
        {
            return base.Equals(obj);
        }

        public List<IOpstiDomenskiObjekat> GetReaderResult(SqlDataReader reader)
        {
            List<IOpstiDomenskiObjekat> lista = new List<IOpstiDomenskiObjekat>();

            while (reader.Read())
            {
                Valuta v = new Valuta();
                v.ValutaId = Convert.ToInt32(reader[0]);
                v.NazivValute = reader[1].ToString();
                lista.Add(v);
            }

            reader.Close();
            return lista;
        }


        public string Insert()
        {
            return $"{ValutaId},'{NazivValute}'";
        }

        public string Join()
        {
            return "";
        }

        public string Table()
        {
            return "Valuta";
        }

        public string Table2()
        {
            return "Valuta v";

        }

        public override string ToString()
        {
            return NazivValute;
        }

        public string Update()
        {
            return $"nazivValute = '{NazivValute}'";
        }

        public string Where()
        {
            return $"where valutaId = {ValutaId}";
        }
    }
}
