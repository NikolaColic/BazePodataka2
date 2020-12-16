using BazePodataka.BrokerBaze;
using Domen.DomenskeKlase;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BazePodataka.Kontroler.Kontroleri
{
    public class KontrolerKomitent
    {
        private static KontrolerKomitent instance;
        private DbBroker _broker = new DbBroker();
        private KontrolerKomitent()
        {

        }
        public static KontrolerKomitent Instance
        {
            get
            {
                if (instance is null) instance = new KontrolerKomitent();
                return instance;
            }
        }
        public bool Insert(Komitent komitent)
        {
            try
            {
                var rezultat = _broker.Insert(komitent);
                return rezultat;
            }
            catch (Exception)
            {
                return false;
            }
        }
        public bool Update(Komitent komitent)
        {
            try
            {
                var rezultat = _broker.Update(komitent);
                return rezultat;
            }
            catch (Exception)
            {
                return false;
            }
        }
        public bool Delete(Komitent komitent)
        {
            try
            {
                var rezultat = _broker.Delete(komitent);
                return rezultat;
            }
            catch (Exception)
            {
                return false;
            }
        }
        public List<Komitent> Select(Komitent komitent)
        {
            try
            {
                var rezultat = _broker.Select(komitent).OfType<Komitent>().ToList();
                return rezultat;
            }
            catch (Exception)
            {
                return null;
            }
        }
    }
}
