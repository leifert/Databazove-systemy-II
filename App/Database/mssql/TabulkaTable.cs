using System;
using System.Collections.Generic;
using System.Linq;
using System.Collections.ObjectModel;
using System.Data.SqlClient;

namespace VolejbalovaLigaORM.ORM.DAO.mssql
{
    /*
      3.1 Novy zaznam klubu
      3.2 Tabulka volejbalovych klubu
      3.3 Aktualizace klubu
      3.4 Odstraneni klubu

   */
    public class TabulkaTable
    {
        public static string TABLE_NAME = "tabulka";
        public static string SQL_SELECT = "select * from volejbal.tabulka";
        public static string SQL_INSERT = "insert into volejbal.tabulka(id_klub,zapasy_celkem,vyhry,prohry,vyhrane_sety,prohrane_sety,body) values(@id_klub,@zapasy_celkem,@vyhry,@prohry,@vyhrane_sety,@prohrane_sety,@body)";
        public static string SQL_UPDATE = "UPDATE volejbal.tabulka SET zapasy_celkem=@zapasy_celkem, vyhry=@vyhry, prohry=@prohry, vyhrane_sety=@vyhrane_sety,prohrane_sety=@prohrane_sety,body=@body where id_klub=@id_klub";
        public static string SQL_TABULKA = "select klub.nazev,zapasy_celkem, vyhry, prohry, vyhrane_sety, prohrane_sety, body from volejbal.tabulka join volejbal.klub on volejbal.tabulka.id_klub= volejbal.klub.id_klub order by body DESC";
        public static string SQL_DELETE_ID = "Delete from volejbal.tabulka where id_klub=@id_klub";
        private static void PrepareCommand(SqlCommand command, Tabulka tabulka)
        {
            command.Parameters.AddWithValue("@id_klub", tabulka.id_klub);
            command.Parameters.AddWithValue("@zapasy_celkem", tabulka.zapasy_celkem);
            command.Parameters.AddWithValue("@vyhry", tabulka.vyhry);
            command.Parameters.AddWithValue("@prohry", tabulka.prohry);
            command.Parameters.AddWithValue("@vyhrane_sety", tabulka.vyhrane_sety);
            command.Parameters.AddWithValue("@prohrane_sety", tabulka.prohrane_sety);
            command.Parameters.AddWithValue("@body", tabulka.body);
       
        }

        public static Collection<Tabulka> Select(Database pDb = null)
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

            Collection<Tabulka> kluby = Read(reader);
            reader.Close();

            if (pDb == null)
            {
                db.Close();
            }

            return kluby;
        }

        /// <summary>
        ///  3.1 Novy zaznam klubu
        /// </summary>
        public static int Insert(Tabulka tabulka, Database pDb)
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
            PrepareCommand(command, tabulka);
            int ret = db.ExecuteNonQuery(command);

            if (pDb == null)
            {
                db.Close();
            }

            return ret;
        }

        /// <summary>
        /// 3.2 Tabulka volejbalovych klubu
        /// </summary>

        public static Collection<Tabulka> Vysledna_tabulka(Database pDb = null)
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

            SqlCommand command = db.CreateCommand(SQL_TABULKA);
            SqlDataReader reader = db.Select(command);

            Collection<Tabulka> kluby = Read2(reader);
            reader.Close();

            if (pDb == null)
            {
                db.Close();
            }

            return kluby;
        }

        /// <summary>
        ///  3.3 Aktualizace klubu
        /// </summary>

        public static int Update(Tabulka tabulka, Database pDb = null)
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
            PrepareCommand(command, tabulka);
            int ret = db.ExecuteNonQuery(command);

            if (pDb == null)
            {
                db.Close();
            }

            return ret;
        }



        /// <summary>
        /// 3.4 Odstraneni klubu
        /// </summary>
        public static int Delete(int id_klub, Database pDb = null)
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
            SqlCommand command = db.CreateCommand(SQL_DELETE_ID);

            command.Parameters.AddWithValue("@id_klub", id_klub);
            int ret = db.ExecuteNonQuery(command);

            if (pDb == null)
            {
                db.Close();
            }

            return ret;
        }


        private static Collection<Tabulka> Read(SqlDataReader reader)
        {
            Collection<Tabulka> kluby = new Collection<Tabulka>();

            while (reader.Read())
            {
                int i = -1;
                Tabulka tab = new Tabulka();

                tab.id_klub = reader.GetInt32(++i);
                tab.zapasy_celkem = reader.GetInt32(++i);
                tab.vyhry = reader.GetInt32(++i);
                tab.prohry = reader.GetInt32(++i);
                tab.vyhrane_sety = reader.GetInt32(++i);
                tab.prohrane_sety = reader.GetInt32(++i);
                tab.body = reader.GetInt32(++i);

                kluby.Add(tab);
            }
            return kluby;
        }

        private static Collection<Tabulka> Read2(SqlDataReader reader)
        {
            Collection<Tabulka> kluby = new Collection<Tabulka>();

            while (reader.Read())
            {
                int i = -1;
                Tabulka tab = new Tabulka();

                tab.nazev = reader.GetString(++i);
                tab.zapasy_celkem = reader.GetInt32(++i);
                tab.vyhry = reader.GetInt32(++i);
                tab.prohry = reader.GetInt32(++i);
                tab.vyhrane_sety = reader.GetInt32(++i);
                tab.prohrane_sety = reader.GetInt32(++i);
                tab.body = reader.GetInt32(++i);

                kluby.Add(tab);
            }
            return kluby;
        }

    }
}
