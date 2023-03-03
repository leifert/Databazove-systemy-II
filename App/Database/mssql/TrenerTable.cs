using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data.SqlClient;


namespace VolejbalovaLigaORM.ORM.DAO.mssql
{

    /*
     1.1 Novy trener
     1.2 Seznam treneru
     1.3 Aktualizace trenera
     */

    public class TrenerTable
    {
        public static string TABLE_NAME = "trener";
        public static string SQL_SELECT = "SELECT * FROM volejbal.trener";
        public static string SQL_SELECT_ID = "SELECT * FROM volejbal.trener WHERE id_trener=@id_trener";
        public static string SQL_INSERT = "insert into volejbal.trener (jmeno,prijmeni) values (@jmeno, @prijmeni)";
        public static string SQL_UPDATE = "UPDATE volejbal.trener SET jmeno=@jmeno, prijmeni=@prijmeni where id_trener=@id_trener";


        private static void PrepareCommand(SqlCommand command, Trener trener)
        {
            command.Parameters.AddWithValue("@id_trener", trener.id_trener);
            command.Parameters.AddWithValue("@jmeno", trener.jmeno);
            command.Parameters.AddWithValue("@prijmeni", trener.prijmeni);
        }


        /// <summary>
        /// 1.1 Novy trener
        /// </summary>
        public static int Insert(Trener trener, Database pDb)
        {
            Database db;
            if (pDb == null)
            {
                db = new Database();
                db.Connect();
            }
            else
            {
                db = pDb;
            }

            SqlCommand command = db.CreateCommand(SQL_INSERT);
            PrepareCommand(command, trener);
            int ret = db.ExecuteNonQuery(command);

            if (pDb == null)
            {
                db.Close();
            }

            return ret;
        }

        /// <summary>
        /// 1.2 Seznam treneru
        /// </summary>
        public static Collection<Trener> Select(Database pDb = null)
        {
            Database db;
            if (pDb == null)
            {
                db = new Database();
                db.Connect();
            }
            else
            {
                db = (Database)pDb;
            }

            SqlCommand command = db.CreateCommand(SQL_SELECT);
            SqlDataReader reader = db.Select(command);

            Collection<Trener> treners = Read(reader);
            reader.Close();

            if (pDb == null)
            {
                db.Close();
            }

            return treners;
        }

        /// <summary>
        /// 1.3 Aktualizace trenera
        /// </summary>
        public static int Update(Trener trener, Database pDb = null)
        {
            Database db;
            if (pDb == null)
            {
                db = new Database();
                db.Connect();
            }
            else
            {
                db = (Database)pDb;
            }

            SqlCommand command = db.CreateCommand(SQL_UPDATE);
            PrepareCommand(command, trener);
            int ret = db.ExecuteNonQuery(command);

            if (pDb == null)
            {
                db.Close();
            }

            return ret;
        }

        private static Collection<Trener> Read(SqlDataReader reader)
        {
            Collection<Trener> treners = new Collection<Trener>();

            while (reader.Read())
            {
                Trener trener = new Trener();
                int i = -1;
                trener.id_trener = reader.GetInt32(++i);
                trener.jmeno = reader.GetString(++i);
                trener.prijmeni = reader.GetString(++i);
                treners.Add(trener);
            }
            return treners;
        }
    }
}
