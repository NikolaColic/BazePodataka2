using BazePodataka.BrokerBaze;
using Domen.DomenskeKlase;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BazePodataka.Kontroler.Kontroleri
{
    public class KontrolerProfaktura
    {
        private static KontrolerProfaktura instance;
        private DbBroker _broker = new DbBroker();
        private KontrolerProfaktura()
        {

        }
        public static KontrolerProfaktura Instance
        {
            get
            {
                if (instance is null) instance = new KontrolerProfaktura();
                return instance;
            }
        }
        public bool Insert(Profaktura profaktura)
        {
            try
            {
                var rezultat = _broker.Insert(profaktura);
                return rezultat;
            }
            catch (Exception)
            {
                return false;
            }
        }
        public bool Update(Profaktura profaktura)
        {
            try
            {
                var rezultat = _broker.Update(profaktura);
                return rezultat;
            }
            catch (Exception)
            {
                return false;
            }
        }
        public bool Delete(Profaktura profaktura)
        {
            try
            {
                var rezultat = _broker.Insert(profaktura);
                return rezultat;
            }
            catch (Exception)
            {
                return false;
            }
        }
        public List<Profaktura> Select(Profaktura profaktura)
        {
            try
            {
                var rezultat = _broker.Select(profaktura).OfType<Profaktura>().ToList();
                return rezultat;
            }
            catch (Exception)
            {
                return null;
            }
        }
    }
}
