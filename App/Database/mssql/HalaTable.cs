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
     2.1 Nova hala
     2.2 Seznam hal
     2.3 Detail haly
     2.4 Aktualizace haly
     2.5 Seznam hal podle průměrné návštěvnosti
  */
    public class HalaTable
    {
        public static string TABLE_NAME = "hala";
        public static string SQL_SELECT = "SELECT * FROM volejbal.hala";
        public static string SQL_SELECT_ID = "SELECT * FROM volejbal.hala WHERE id_hala=@id_hala";
        public static string SQL_INSERT = "insert into volejbal.hala (nazev,adresa,kapacita,cena_listku) values (@nazev,@adresa,@kapacita,@cena_listku)";
        public static string SQL_UPDATE = "UPDATE volejbal.hala SET nazev=@nazev, adresa=@adresa, kapacita=@kapacita, cena_listku=@cena_listku where id_hala=@id_hala";
        public static string SQL_Prumerna_navstevnost = "select volejbal.hala.nazev,volejbal.hala.adresa,volejbal.hala.kapacita, avg(volejbal.zapas.pocet_divaku) as prumer from volejbal.zapas join volejbal.klub on volejbal.zapas.id_domaci = volejbal.klub.id_klub join volejbal.hala on volejbal.klub.id_hala = volejbal.hala.id_hala group by volejbal.hala.nazev, volejbal.hala.adresa, volejbal.hala.kapacita order by prumer DESC";

        private static void PrepareCommand(SqlCommand command, Hala hala)
        {
            command.Parameters.AddWithValue("@id_hala", hala.id_hala);
            command.Parameters.AddWithValue("@nazev", hala.nazev);
            command.Parameters.AddWithValue("@adresa", hala.adresa);
            command.Parameters.AddWithValue("@kapacita", hala.kapacita);
            command.Parameters.AddWithValue("@cena_listku", hala.cena_listku == null ? DBNull.Value : (object)hala.cena_listku);
        }

        /// <summary>
        /// 2.1 Nova hala
        /// </summary>
        public static int Insert(Hala hala, Database pDb)
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
            PrepareCommand(command, hala);
            int ret = db.ExecuteNonQuery(command);

            if (pDb == null)
            {
                db.Close();
            }

            return ret;
        }

        /// <summary>
        /// 2.2 Seznam hal
        /// </summary>

        public static Collection<Hala> Select(Database pDb = null)
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

            Collection<Hala> haly = Read(reader);
            reader.Close();

            if (pDb == null)
            {
                db.Close();
            }

            return haly;
        }

        /// <summary>
        /// 2.3 Detail haly
        /// </summary>
        public static Hala DetailHaly(int id_haly, Database pDb = null)
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

            command.Parameters.AddWithValue("@id_hala", id_haly);
            SqlDataReader reader = db.Select(command);

            Collection<Hala> haly = Read(reader);
            Hala hala = null;
            if (haly.Count == 1)
            {
                hala = haly[0];
            }
            reader.Close();

            if (pDb == null)
            {
                db.Close();
            }

            return hala;
        }



        /// <summary>
        ///2.4 Aktualizace haly
        /// </summary>
        public static int Update(Hala hala, Database pDb = null)
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
            PrepareCommand(command, hala);
            int ret = db.ExecuteNonQuery(command);

            if (pDb == null)
            {
                db.Close();
            }

            return ret;
        }

        /// <summary>
        /// 2.5 Seznam hal podle průměrné návštěvnosti
        /// </summary>
        public static Collection<Hala> Prumerna_Navstevnost(Database pDb = null)
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

            SqlCommand command = db.CreateCommand(SQL_Prumerna_navstevnost);
            SqlDataReader reader = db.Select(command);

            Collection<Hala> haly = Read2(reader);
            reader.Close();

            if (pDb == null)
            {
                db.Close();
            }

            return haly;
        }

        private static Collection<Hala> Read(SqlDataReader reader)
        {
            Collection<Hala> haly = new Collection<Hala>();

            while (reader.Read())
            {
                int i = -1;
                Hala hala = new Hala();

                hala.id_hala = reader.GetInt32(++i);
                hala.nazev = reader.GetString(++i);
                hala.adresa = reader.GetString(++i);
                hala.kapacita = reader.GetInt32(++i);
                if (!reader.IsDBNull(++i))
                {
                    hala.cena_listku = reader.GetInt32(i);
                }
                haly.Add(hala);
            }
            return haly;
        }

        private static Collection<Hala> Read2(SqlDataReader reader)
        {
            Collection<Hala> haly = new Collection<Hala>();

            while (reader.Read())
            {
                int i = -1;
                Hala hala = new Hala();

                hala.nazev = reader.GetString(++i);
                hala.adresa = reader.GetString(++i);
                hala.kapacita = reader.GetInt32(++i);
                hala.prumer = reader.GetInt32(++i);
                haly.Add(hala);
            }
            return haly;
        }
    }
}
