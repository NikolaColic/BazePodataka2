using Domen.DomenskiObjekat;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domen.DomenskeKlase
{
    public class TipKafe : IOpstiDomenskiObjekat
    {
        public int TipKafeId { get; set; }
        public string NazivTipa { get; set; }

        public override bool Equals(object obj)
        {
            return base.Equals(obj);
        }

        public List<IOpstiDomenskiObjekat> GetReaderResult(SqlDataReader reader)
        {
            List<IOpstiDomenskiObjekat> lista = new List<IOpstiDomenskiObjekat>();

            while (reader.Read())
            {
                TipKafe tip = new TipKafe();
                tip.TipKafeId = Convert.ToInt32(reader[0]);
                tip.NazivTipa = reader[1].ToString();
                lista.Add(tip);
            }

            reader.Close();
            return lista;
        }

        public string Insert()
        {
            return $"{TipKafeId},'{NazivTipa}'";
        }

        public string Join()
        {
            return "";
        }

        public string Table()
        {
            return "TipKafe";
        }

        public string Table2()
        {
            return "TipKafe tk";
        }

        public override string ToString()
        {
            return NazivTipa;
        }

        public string Update()
        {
            return $"nazivTipa = '{NazivTipa}'";

        }

        public string Where()
        {
            return $"where tipKafeId = {TipKafeId}";
        }
    }
}
