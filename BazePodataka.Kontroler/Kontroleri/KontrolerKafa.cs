using BazePodataka.BrokerBaze;
using Domen.DomenskeKlase;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BazePodataka.Kontroler.Kontroleri
{
    public class KontrolerKafa
    {
        private static KontrolerKafa instance;
        private DbBroker _broker = new DbBroker();
        private KontrolerKafa()
        {

        }
        public static KontrolerKafa Instance
        {
            get
            {
                if (instance is null) instance = new KontrolerKafa();
                return instance;
            }
        }
        public bool Insert(Kafa kafa)
        {
            try
            {
                var rezultat = _broker.Insert(kafa);
                return rezultat;
            }
            catch (Exception)
            {
                return false;
            }
        }
        public bool Update(Kafa kafa)
        {
            try
            {
                var rezultat = _broker.Update(kafa);
                return rezultat;
            }
            catch (Exception)
            {
                return false;
            }
        }
        public bool Delete(Kafa kafa)
        {
            try
            {
                var rezultat = _broker.Delete(kafa);
                return rezultat;
            }
            catch (Exception)
            {
                return false;
            }
        }
        public List<Kafa> Select(Kafa kafa)
        {
            try
            {
                var rezultat = _broker.Select(kafa).OfType<Kafa>().ToList();
                return rezultat;
            }
            catch (Exception)
            {
                return null;
            }
        }
    }
}
