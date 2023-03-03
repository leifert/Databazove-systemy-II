using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VolejbalovaLigaORM.ORM.DAO.mssql
{

    /*
        6.1 Novy rozhodci
        6.2 Aktualizace rozhodciho
        6.3 Seznam vsech rozhodcich
        6.4 Smazani rozhodciho 
        6.5 Obnoveni rozhodciho 
     */

    public class RozhodciTable
    {
        public static string TABLE_NAME = "rozhodci";
        public static string SQL_SELECT = "SELECT * FROM volejbal.rozhodci";
        public static string SQL_SELECT_ID = "SELECT * FROM volejbal.rozhodci WHERE id_rozhodci=@id_rozhodci";
        public static string SQL_INSERT = "insert into volejbal.rozhodci (jmeno,prijmeni,pocet_zapasu,stav) values (@jmeno, @prijmeni,@pocet_zapasu,@stav)";
        public static string SQL_UPDATE = "UPDATE volejbal.rozhodci SET jmeno=@jmeno, prijmeni=@prijmeni, pocet_zapasu=@pocet_zapasu, stav=@stav where id_rozhodci=@id_rozhodci";
        public static string SQL_DELETE_ID = "UPDATE volejbal.rozhodci SET stav= 'Neaktivní' where id_rozhodci=@id_rozhodci";
        public static string SQL_OBNOVENI_ID = "UPDATE volejbal.rozhodci SET stav='Aktivní' where id_rozhodci=@id_rozhodci";


        private static void PrepareCommand(SqlCommand command, Rozhodci rozhodci)
        {
            command.Parameters.AddWithValue("@id_rozhodci", rozhodci.id_rozhodci);
            command.Parameters.AddWithValue("@jmeno", rozhodci.jmeno);
            command.Parameters.AddWithValue("@prijmeni", rozhodci.prijmeni);
            command.Parameters.AddWithValue("@pocet_zapasu", rozhodci.pocet_zapasu);
            command.Parameters.AddWithValue("@stav", rozhodci.stav);
        }


        /// <summary>
        /// 6.1 Novy rozhodci
        /// </summary>
        public static int Insert(Rozhodci rozhodci, Database pDb)
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
            PrepareCommand(command, rozhodci);
            int ret = db.ExecuteNonQuery(command);

            if (pDb == null)
            {
                db.Close();
            }

            return ret;
        }

        /// <summary>
        /// 6.2 Aktualizace rozhodciho
        /// </summary>
        public static int Update(Rozhodci rozhodci, Database pDb = null)
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
            PrepareCommand(command, rozhodci);
            int ret = db.ExecuteNonQuery(command);

            if (pDb == null)
            {
                db.Close();
            }

            return ret;
        }

        /// <summary>
        /// 6.3 Seznam vsech rozhodcich
        /// </summary>
        public static Collection<Rozhodci> Select(Database pDb = null)
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

            Collection<Rozhodci> rozhodcis = Read(reader);
            reader.Close();

            if (pDb == null)
            {
                db.Close();
            }

            return rozhodcis;
        }

        /// <summary>
        /// 6.4 Smazani rozhodciho 
        /// </summary>
        public static int Delete(int id_rozhodci, Database pDb = null)
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

            command.Parameters.AddWithValue("@id_rozhodci", id_rozhodci);
            int ret = db.ExecuteNonQuery(command);

            if (pDb == null)
            {
                db.Close();
            }

            return ret;
        }

        /// <summary>
        /// 6.5 Obnoveni rozhodciho 
        /// </summary>
        public static int ObnoveniRozhodciho(int id_rozhodci, Database pDb = null)
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
            SqlCommand command = db.CreateCommand(SQL_OBNOVENI_ID);

            command.Parameters.AddWithValue("@id_rozhodci", id_rozhodci);
            int ret = db.ExecuteNonQuery(command);

            if (pDb == null)
            {
                db.Close();
            }

            return ret;
        }
        public static Rozhodci SelectID(int id_rozhodci, Database pDb = null)
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
            SqlCommand command = db.CreateCommand(SQL_SELECT_ID);

            command.Parameters.AddWithValue("@id_rozhodci", id_rozhodci);
            SqlDataReader reader = db.Select(command);

            Collection<Rozhodci> Rozhodci = Read(reader);
            Rozhodci rozhod = null;
            if (Rozhodci.Count == 1)
            {
                rozhod = Rozhodci[0];
            }
            reader.Close();

            if (pDb == null)
            {
                db.Close();
            }

            return rozhod;
        }



        private static Collection<Rozhodci> Read(SqlDataReader reader)
        {
            Collection<Rozhodci> rozhodcis = new Collection<Rozhodci>();

            while (reader.Read())
            {
                Rozhodci rozhodci = new Rozhodci();
                int i = -1;
                rozhodci.id_rozhodci = reader.GetInt32(++i);
                rozhodci.jmeno = reader.GetString(++i);
                rozhodci.prijmeni = reader.GetString(++i);
                rozhodci.pocet_zapasu = reader.GetInt32(++i);
                rozhodci.stav = reader.GetString(++i);
                rozhodci.cele_jmeno = rozhodci.jmeno +" "+ rozhodci.prijmeni;
                rozhodcis.Add(rozhodci);
            }
            return rozhodcis;
        }
    }
}
