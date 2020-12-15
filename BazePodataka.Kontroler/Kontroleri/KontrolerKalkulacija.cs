using BazePodataka.BrokerBaze;
using Domen.DomenskeKlase;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BazePodataka.Kontroler.Kontroleri
{
    public class KontrolerKalkulacija
    {
        private static KontrolerKalkulacija instance;
        private DbBroker _broker = new DbBroker();
        private KontrolerKalkulacija()
        {

        }
        public static KontrolerKalkulacija Instance
        {
            get
            {
                if (instance is null) instance = new KontrolerKalkulacija();
                return instance;
            }
        }
        public bool Insert(Kalkulacija kalkulacija)
        {
            try
            {
                var rezultat = _broker.Insert(kalkulacija);
                return rezultat;
            }
            catch (Exception)
            {
                return false;
            }
        }
        public bool Update(Kalkulacija kalkulacija)
        {
            try
            {
                var rezultat = _broker.Update(kalkulacija);
                return rezultat;
            }
            catch (Exception)
            {
                return false;
            }
        }
        public bool Delete(Kalkulacija kalkulacija)
        {
            try
            {
                var rezultat = _broker.Insert(kalkulacija);
                return rezultat;
            }
            catch (Exception)
            {
                return false;
            }
        }
        public List<Kalkulacija> Select(Kalkulacija kalkulacija)
        {
            try
            {
                var rezultat = _broker.Select(kalkulacija).OfType<Kalkulacija>().ToList();
                return rezultat;
            }
            catch (Exception)
            {
                return null;
            }
        }
    }
}
