using BazePodataka.BrokerBaze;
using Domen.DomenskeKlase;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BazePodataka.Kontroler.Kontroleri
{
    public class KontrolerTipKafe
    {
        private static KontrolerTipKafe instance;
        private DbBroker _broker = new DbBroker();
        private KontrolerTipKafe()
        {

        }
        public static KontrolerTipKafe Instance
        {
            get
            {
                if (instance is null) instance = new KontrolerTipKafe();
                return instance;
            }
        }
        public bool Insert(TipKafe tipKafe)
        {
            try
            {
                var rezultat = _broker.Insert(tipKafe);
                return rezultat;
            }
            catch (Exception)
            {
                return false;
            }
        }
        public bool Update(TipKafe tipKafe)
        {
            try
            {
                var rezultat = _broker.Update(tipKafe);
                return rezultat;
            }
            catch (Exception)
            {
                return false;
            }
        }
        public bool Delete(TipKafe tipKafe)
        {
            try
            {
                var rezultat = _broker.Delete(tipKafe);
                return rezultat;
            }
            catch (Exception)
            {
                return false;
            }
        }
        public List<TipKafe> Select(TipKafe tipKafe)
        {
            try
            {
                var rezultat = _broker.Select(tipKafe).OfType<TipKafe>().ToList();
                return rezultat;
            }
            catch (Exception)
            {
                return null;
            }
        }
    }
}
