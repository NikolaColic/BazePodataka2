using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domen.DomenskiObjekat
{
    public interface IOpstiDomenskiObjekat
    {
        string Table();
        string Table2();
        string Insert();
        string Update();
        string Join();
        string Where();


        List<IOpstiDomenskiObjekat> GetReaderResult(SqlDataReader reader);
    }
}
