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
                var rezultat = _broker.InsertSlozen(trebovanje);
                return rezultat;
            }
            catch (Exception)
            {
                return false;
            }
        }
        public bool Update(Trebovanje trebovanje, List<StavkaTrebovanja> stare)
        {
            try
            {
                var rezultat = _broker.UpdateSlozen(trebovanje,stare);
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
                var rezultat = _broker.DeleteSlozen(trebovanje);
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

                var stavke = _broker.Select(new StavkaTrebovanja()).OfType<StavkaTrebovanja>().ToList();
                foreach(var jedno in rezultat)
                {
                    jedno.ListaStavki = stavke.Where((s) => s.Trebovanje.TrebovanjeId == jedno.TrebovanjeId).ToList();
                }
                return rezultat;
            }
            catch (Exception)
            {
                return null;
            }
        }
        public List<StavkaTrebovanja> SelectStavke(StavkaTrebovanja trebovanje)
        {
            try
            {

                var stavke = _broker.Select(trebovanje).OfType<StavkaTrebovanja>().ToList();
                return stavke;
            }
            catch (Exception)
            {
                return null;
            }
        }
    }
}
