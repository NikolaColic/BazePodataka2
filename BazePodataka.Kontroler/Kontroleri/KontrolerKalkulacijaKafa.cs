using BazePodataka.BrokerBaze;
using Domen.DomenskeKlase;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BazePodataka.Kontroler.Kontroleri
{
    public class KontrolerKalkulacijaKafa
    {
        private static KontrolerKalkulacijaKafa instance;
        private DbBroker _broker = new DbBroker();
        private KontrolerKalkulacijaKafa()
        {

        }
        public static KontrolerKalkulacijaKafa Instance
        {
            get
            {
                if (instance is null) instance = new KontrolerKalkulacijaKafa();
                return instance;
            }
        }
        public bool Insert(KalkulacijaKafa kafa)
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
        public bool Update(KalkulacijaKafa kafa)
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
        public bool Delete(KalkulacijaKafa kafa)
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
        public List<KalkulacijaKafa> Select(KalkulacijaKafa kafa)
        {
            try
            {
                var rezultat = _broker.Select(kafa).OfType<KalkulacijaKafa>().ToList();
                return rezultat;
            }
            catch (Exception)
            {
                return null;
            }
        }
    }
}
