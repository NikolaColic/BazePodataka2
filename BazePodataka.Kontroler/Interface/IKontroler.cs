using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BazePodataka.Kontroler.Interface
{
    public interface IKontroler<T>
    {
        List<T> Vrati(T obj);
        bool Add(T obj);
        bool Update(T obj);
        bool Delete(T obj);
        bool AddTransaction(T obj);
    }
}
