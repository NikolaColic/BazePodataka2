using Domen.DomenskiObjekat;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domen.DomenskeKlase
{
    public class Komitent : IOpstiDomenskiObjekat
    {
        public int KomitentId { get; set; }
        public string Email { get; set; }
        public string NazivKomitenta { get; set; }
        public string OpisKomitenta { get; set; }
        public string Pib { get; set; }
        public string MaticniBroj { get; set; }
        public string BrojTelefona { get; set; }

        public override bool Equals(object obj)
        {
            return base.Equals(obj);
        }

        public List<IOpstiDomenskiObjekat> GetReaderResult(SqlDataReader reader)
        {
            List<IOpstiDomenskiObjekat> lista = new List<IOpstiDomenskiObjekat>();

            while (reader.Read())
            {
                Komitent k = new Komitent();
                k.KomitentId = Convert.ToInt32(reader[0]);
                k.Email = reader[1].ToString();
                k.NazivKomitenta = reader[2].ToString();
                k.OpisKomitenta = reader[3].ToString();
                k.Pib = reader[4].ToString();
                k.MaticniBroj = reader[5].ToString();
                k.BrojTelefona = reader[6].ToString();
                lista.Add(k);
            }

            reader.Close();
            return lista;
        }

        public string Insert()
        {
            return $"'{Email}','{NazivKomitenta}', '{OpisKomitenta}', '{Pib}', '{MaticniBroj}', '{BrojTelefona}'";
        }

        public string Join()
        {
            return "";
        }

        public string Table()
        {
            return "Komitent2";
        }

        public string Table2()
        {
            return "Komitent2 k2";

        }

        public override string ToString()
        {
            return NazivKomitenta;
        }

        public string Update()
        {
            return $"email = '{Email}',nazivKomitenta = '{NazivKomitenta}', opisKomitenta = '{OpisKomitenta}', pib = '{Pib}', maticniBroj = '{MaticniBroj}', brojTelefona = '{BrojTelefona}'";

        }

        public string Where()
        {
            return $"where komitentId = {KomitentId}";
        }
    }
}
