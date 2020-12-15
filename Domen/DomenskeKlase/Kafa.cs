using Domen.DomenskiObjekat;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domen.DomenskeKlase
{
    public class Kafa : IOpstiDomenskiObjekat
    {
        public int KafaId { get; set; }
        public string NazivKafe { get; set; }
        public string Opis { get; set; }
        public TipKafe TipKafe { get; set; }

        public string Table() => "Kafa";

        public string Table2() => "Kafa k";
        public string Insert() => $"{KafaId},'{NazivKafe}','{Opis}',{TipKafe.TipKafeId}";
        public string Update() => $"nazivKafe ='{NazivKafe}',opis = '{Opis}',tipKafeId ={TipKafe.TipKafeId}";
        public string Join() => "join TipKafe t on (k.tipKafeId = t.tipKafeId)";
        public string Where() => $"where kafaId = {KafaId}";
        public List<IOpstiDomenskiObjekat> GetReaderResult(SqlDataReader reader)
        {
            List<IOpstiDomenskiObjekat> lista = new List<IOpstiDomenskiObjekat>();

            while (reader.Read())
            {
                Kafa kafa = new Kafa();
                kafa.KafaId = Convert.ToInt32(reader[0]);
                kafa.NazivKafe = reader[1].ToString();
                kafa.Opis = reader[2].ToString();
                TipKafe tip = new TipKafe();
                tip.TipKafeId = Convert.ToInt32(reader[3]);
                tip.NazivTipa = reader[5].ToString();
                kafa.TipKafe = tip;
                lista.Add(kafa);
            }
            reader.Close();

            return lista;
        }

        public override string ToString()
        {
            return NazivKafe;
        }

        public override bool Equals(object obj)
        {
            return base.Equals(obj);
        }
    }
}
