using Domen.DomenskeKlase;
using Domen.DomenskiObjekat;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BazePodataka.BrokerBaze
{
    public class DbBroker
    {
        private SqlTransaction transaction;
        private SqlConnection connection;

        public DbBroker()
        {
            connection = new SqlConnection(@"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=Baze2;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");

        }
        public bool Insert(IOpstiDomenskiObjekat objekat)
        {
            try
            {
                connection.Open();
                transaction = connection.BeginTransaction();
                SqlCommand command = new SqlCommand();
                command.Connection = connection;
                command.Transaction = transaction;
                command.CommandText = $"insert into {objekat.Table()} values ({objekat.Insert()})";
                if(command.ExecuteNonQuery() == 0) throw new Exception();
                transaction.Commit();
                return true;
            }
            catch(Exception e)
            {
                transaction.Rollback();
                Console.WriteLine(e.Message);
                return false;
            }
            finally
            {
                connection.Close();
            }
        }
        public bool Update(IOpstiDomenskiObjekat objekat)
        {
            try
            {
                connection.Open();
                transaction = connection.BeginTransaction();
                SqlCommand command = new SqlCommand();
                command.Connection = connection;
                command.Transaction = transaction;
                command.CommandText = $"update {objekat.Table()} set {objekat.Update()}  {objekat.Where()}";
                if (command.ExecuteNonQuery() == 0) throw new Exception();
                transaction.Commit();
                return true;
            }
            catch (Exception e)
            {
                transaction.Rollback();
                Console.WriteLine(e.Message);
                return false;
            }
            finally
            {
                connection.Close();
            }
        }
        public List<IOpstiDomenskiObjekat> Select(IOpstiDomenskiObjekat objekat)
        {
            try
            {
                connection.Open();
                SqlCommand command = new SqlCommand();
                command.Transaction = transaction;
                command.Connection = connection;
                if (objekat is Profaktura)
                {
                    command.CommandText = $"select *, procenti.Depozit as depozit, procenti.BrojTelefona as stopa  from Profaktura2 p join Trebovanje t on (t.trebovanjeId = p.trebovanjeId) join Komitent2 ko on (ko.komitentId = p.komitentId)";
                }
                else
                {
                     command.CommandText = $"select * from {objekat.Table2()} {objekat.Join()}";
                }
                SqlDataReader reader = command.ExecuteReader();
                return objekat.GetReaderResult(reader);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return null;
            }
            finally
            {
                connection.Close();
            }
        }
        public bool Delete(IOpstiDomenskiObjekat objekat)
        {
            try
            {
                connection.Open();
                transaction = connection.BeginTransaction();
                SqlCommand command = new SqlCommand();
                command.Connection = connection;
                command.Transaction = transaction;
                command.CommandText = $"delete from {objekat.Table()} {objekat.Where()}";
                if (command.ExecuteNonQuery() == 0) throw new Exception();
                transaction.Commit();
                return true;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                transaction.Rollback();
                return false;
            }
            finally
            {
                connection.Close();
            }
        }

        public bool InsertSlozen(Trebovanje trebovanje)
        {
            try
            {
                connection.Open();
                transaction = connection.BeginTransaction();
                SqlCommand command = new SqlCommand();
                command.Connection = connection;
                command.Transaction = transaction;
                command.CommandText = $"insert into {trebovanje.Table()} values ({trebovanje.Insert()})";
                if (command.ExecuteNonQuery() == 0) throw new Exception();
                foreach(var st in trebovanje.ListaStavki)
                {
                    st.Trebovanje.TrebovanjeId = trebovanje.TrebovanjeId;
                    command.CommandText = $"insert into {st.Table()} values ({st.Insert()})";
                    if (command.ExecuteNonQuery() == 0) throw new Exception();

                }
                transaction.Commit();
                return true;
            }
            catch (Exception e)
            {
                transaction.Rollback();
                Console.WriteLine(e.Message);
                return false;
            }
            finally
            {
                connection.Close();
            }
        }
        public bool UpdateSlozen(Trebovanje objekat, List<StavkaTrebovanja> stare)
        {
            try
            {
                connection.Open();
                transaction = connection.BeginTransaction();
                SqlCommand command = new SqlCommand();
                command.Connection = connection;
                command.Transaction = transaction;
                
                foreach(var stavka in objekat.ListaStavki)
                {
                    if(stare.SingleOrDefault((st)=> st.RbrStavke == stavka.RbrStavke) is null)
                    {
                        stavka.Trebovanje.TrebovanjeId = objekat.TrebovanjeId;
                        command.CommandText = $"insert into {stavka.Table()} values ({stavka.Insert()})";
                        if (command.ExecuteNonQuery() == 0) throw new Exception();

                    }
                }
                foreach(var staraStavka in stare)
                {
                    if(objekat.ListaStavki.SingleOrDefault((st)=> st.RbrStavke == staraStavka.RbrStavke) is null)
                    {
                        command.CommandText = $"delete from {staraStavka.Table()} {staraStavka.Where()}";
                        if (command.ExecuteNonQuery() == 0) throw new Exception();
                    }
                }
                command.CommandText = $"update {objekat.Table()} set {objekat.Update()}  {objekat.Where()}";
                if (command.ExecuteNonQuery() == 0) throw new Exception();
                transaction.Commit();
                return true;
            }
            catch (Exception e)
            {
                transaction.Rollback();
                Console.WriteLine(e.Message);
                return false;
            }
            finally
            {
                connection.Close();
            }
        }
        public bool DeleteSlozen(Trebovanje trebovanje)
        {
            try
            {
                connection.Open();
                transaction = connection.BeginTransaction();
                SqlCommand command = new SqlCommand();
                command.Connection = connection;
                command.Transaction = transaction;
                foreach (var st in trebovanje.ListaStavki)
                {
                    st.Trebovanje.TrebovanjeId = trebovanje.TrebovanjeId;
                    command.CommandText = $"delete from {st.Table()} {st.Where()}";
                    if (command.ExecuteNonQuery() == 0) throw new Exception();

                }
                command.CommandText = $"delete from {trebovanje.Table()} {trebovanje.Where()}";
                if (command.ExecuteNonQuery() == 0) throw new Exception();
                transaction.Commit();
                return true;
            }
            catch (Exception e)
            {
                transaction.Rollback();
                Console.WriteLine(e.Message);
                return false;
            }
            finally
            {
                connection.Close();
            }
        }
    }
}
