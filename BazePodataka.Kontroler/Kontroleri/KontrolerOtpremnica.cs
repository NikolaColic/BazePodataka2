using BazePodataka.BrokerBaze;
using Domen.DomenskeKlase;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BazePodataka.Kontroler.Kontroleri
{
    public class KontrolerOtpremnica
    {
        private static KontrolerOtpremnica instance;
        private DbBroker _broker = new DbBroker();
        private KontrolerOtpremnica()
        {

        }
        public static KontrolerOtpremnica Instance
        {
            get
            {
                if (instance is null) instance = new KontrolerOtpremnica();
                return instance;
            }
        }
        public bool Insert(Otpremnica otpremnica)
        {
            try
            {
                var rezultat = _broker.Insert(otpremnica);
                return rezultat;
            }
            catch (Exception)
            {
                return false;
            }
        }
        public bool Update(Otpremnica otpremnica)
        {
            try
            {
                var rezultat = _broker.Update(otpremnica);
                return rezultat;
            }
            catch (Exception)
            {
                return false;
            }
        }
        public bool Delete(Otpremnica otpremnica)
        {
            try
            {
                var rezultat = _broker.Delete(otpremnica);
                return rezultat;
            }
            catch (Exception)
            {
                return false;
            }
        }
        public List<Otpremnica> Select(Otpremnica otpremnica)
        {
            try
            {
                var rezultat = _broker.Select(otpremnica).OfType<Otpremnica>().ToList();
                return rezultat;
            }
            catch (Exception)
            {
                return null;
            }
        }
    }
}
