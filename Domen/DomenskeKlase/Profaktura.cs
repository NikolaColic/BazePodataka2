using Domen.DomenskiObjekat;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domen.DomenskeKlase
{
    public class Profaktura : IOpstiDomenskiObjekat
    {
        public int BrojFakture { get; set; }
        public double Depozit { get; set; }
        public double StopaPoreza { get; set; }
        public string Opis { get; set; }
        public DateTime Datum { get; set; }
        public Trebovanje Trebovanje { get; set; }
        public Komitent Komitent { get; set; }

        public List<IOpstiDomenskiObjekat> GetReaderResult(SqlDataReader reader)
        {
            List<IOpstiDomenskiObjekat> lista = new List<IOpstiDomenskiObjekat>();

            while (reader.Read())
            {
                Profaktura pr = new Profaktura();
                pr.BrojFakture = Convert.ToInt32(reader[0]);
                pr.Depozit = Convert.ToDouble(reader["depozit"]);
                pr.StopaPoreza = Convert.ToDouble(reader["stopa"]);
                pr.Opis = reader[2].ToString();
                pr.Datum = Convert.ToDateTime(reader[3]);
                Trebovanje t = new Trebovanje();
                t.TrebovanjeId = Convert.ToInt32(reader["trebovanjeId"]);
                pr.Trebovanje = t;
                Komitent k = new Komitent();
                k.KomitentId = Convert.ToInt32(reader["komitentId"]);
                k.NazivKomitenta = reader["nazivKomitenta"].ToString();
                pr.Komitent = k;
                lista.Add(pr);
            }

            reader.Close();
            return lista;
        }

        public string Insert()
        {
            return $"'{Depozit},{StopaPoreza}','{Opis}','{Datum}',{Trebovanje.TrebovanjeId},{Komitent.KomitentId}";
        }

        public string Join()
        {
            return "join Trebovanje t on (t.trebovanjeId = p.trebovanjeId) join Komitent2 ko on (ko.komitentId = p.komitentId)";

        }

        public string Table()
        {
            return "Profaktura2";
        }

        public string Table2()
        {
            return "Profaktura2 p";
        }

        public string Update()
        {
            return $"procenti = '{Depozit},{StopaPoreza}',opis = '{Opis}',datum = '{Datum}',trebovanjeId = {Trebovanje.TrebovanjeId},komitentId = {Komitent.KomitentId}";

        }

        public string Where()
        {
            return $"brojFakture = {BrojFakture}";
        }
    }
}
