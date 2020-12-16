using BazePodataka.BrokerBaze;
using Domen.DomenskeKlase;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BazePodataka.Kontroler.Kontroleri
{
    public class KontrolerKomitentPogled
    {
        private static KontrolerKomitentPogled instance;
        private DbBroker _broker = new DbBroker();
        private KontrolerKomitentPogled()
        {

        }
        public static KontrolerKomitentPogled Instance
        {
            get
            {
                if (instance is null) instance = new KontrolerKomitentPogled();
                return instance;
            }
        }
        public bool Insert(KomitentPogled komitent)
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
        public bool Update(KomitentPogled komitent)
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
        public bool Delete(KomitentPogled komitent)
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
        public List<KomitentPogled> Select(KomitentPogled komitent)
        {
            try
            {
                var rezultat = _broker.Select(komitent).OfType<KomitentPogled>().ToList();
                return rezultat;
            }
            catch (Exception)
            {
                return null;
            }
        }
    }
}
