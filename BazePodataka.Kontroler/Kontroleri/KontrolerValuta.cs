using BazePodataka.BrokerBaze;
using Domen.DomenskeKlase;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BazePodataka.Kontroler.Kontroleri
{
    public class KontrolerValuta
    {
        private static KontrolerValuta instance;
        private DbBroker _broker = new DbBroker();
        private KontrolerValuta()
        {

        }
        public static KontrolerValuta Instance
        {
            get
            {
                if (instance is null) instance = new KontrolerValuta();
                return instance;
            }
        }
        public bool Insert(Valuta valuta)
        {
            try
            {
                var rezultat = _broker.Insert(valuta);
                return rezultat;
            }
            catch (Exception)
            {
                return false;
            }
        }
        public bool Update(Valuta valuta)
        {
            try
            {
                var rezultat = _broker.Update(valuta);
                return rezultat;
            }
            catch (Exception)
            {
                return false;
            }
        }
        public bool Delete(Valuta valuta)
        {
            try
            {
                var rezultat = _broker.Delete(valuta);
                return rezultat;
            }
            catch (Exception)
            {
                return false;
            }
        }
        public List<Valuta> Select(Valuta valuta)
        {
            try
            {
                var rezultat = _broker.Select(valuta).OfType<Valuta>().ToList();
                return rezultat;
            }
            catch (Exception)
            {
                return null;
            }
        }
    }
}
