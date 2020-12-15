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
                transaction.Rollback();
                return false;
            }
            finally
            {
                connection.Close();
            }
        }
    }
}
