using BazePodataka.BrokerBaze;
using Domen.DomenskeKlase;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BazePodataka.Kontroler.Kontroleri
{
    public class KontrolerTrebovanje
    {
        private static KontrolerTrebovanje instance;
        private DbBroker _broker = new DbBroker();
        private KontrolerTrebovanje()
        {

        }
        public static KontrolerTrebovanje Instance
        {
            get
            {
                if (instance is null) instance = new KontrolerTrebovanje();
                return instance;
            }
        }
        public bool Insert(Trebovanje trebovanje)
        {
            try
            {
                var rezultat = _broker.Insert(trebovanje);
                return rezultat;
            }
            catch (Exception)
            {
                return false;
            }
        }
        public bool Update(Trebovanje trebovanje)
        {
            try
            {
                var rezultat = _broker.Update(trebovanje);
                return rezultat;
            }
            catch (Exception)
            {
                return false;
            }
        }
        public bool Delete(Trebovanje trebovanje)
        {
            try
            {
                var rezultat = _broker.Insert(trebovanje);
                return rezultat;
            }
            catch (Exception)
            {
                return false;
            }
        }
        public List<Trebovanje> Select(Trebovanje trebovanje)
        {
            try
            {
                var rezultat = _broker.Select(trebovanje).OfType<Trebovanje>().ToList();
                return rezultat;
            }
            catch (Exception)
            {
                return null;
            }
        }
    }
}
