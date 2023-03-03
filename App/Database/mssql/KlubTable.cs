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
       7.1 Novy klub
       7.2 Aktualizace klubu
       7.3 Seznam vsech klubu
       7.4 Detail klubu
     */

    public class KlubTable
    {
        public static string TABLE_NAME = "klub";
        public static string SQL_SELECT = "SELECT * FROM volejbal.klub";
        public static string SQL_SELECT_ID = "SELECT * FROM volejbal.klub WHERE id_klub=@id_klub";
        public static string SQL_INSERT = "insert into volejbal.klub (nazev, id_trener, id_hala) values (@nazev, @id_trener,@id_hala)";
        public static string SQL_UPDATE = "UPDATE volejbal.klub SET nazev=@nazev, id_trener=@id_trener, id_hala=@id_hala where id_klub=@id_klub";




        private static void PrepareCommand(SqlCommand command, Klub klub)
        {
            command.Parameters.AddWithValue("@id_klub", klub.id_klub);
            command.Parameters.AddWithValue("@nazev", klub.nazev);
            command.Parameters.AddWithValue("@id_trener", klub.id_trener == null ? DBNull.Value : (object)klub.id_trener);
            command.Parameters.AddWithValue("@id_hala", klub.id_hala);
 
        }


        /// <summary>
        /// 7.1 Novy klub
        /// </summary>
        public static int Insert(Klub klub, Database pDb)
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
            PrepareCommand(command, klub);
            int ret = db.ExecuteNonQuery(command);

            if (pDb == null)
            {
                db.Close();
            }

            return ret;
        }

        /// <summary>
        /// 7.2 Aktualizace klubu
        /// </summary>
        public static int Update(Klub klub, Database pDb = null)
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
            PrepareCommand(command, klub);
            int ret = db.ExecuteNonQuery(command);

            if (pDb == null)
            {
                db.Close();
            }

            return ret;
        }

        /// <summary>
        /// 7.3 Seznam vsech klubu
        /// </summary>
        public static Collection<Klub> Select(Database pDb = null)
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

            Collection<Klub> kluby = Read(reader);
            reader.Close();

            if (pDb == null)
            {
                db.Close();
            }

            return kluby;
        }

        /// <summary>
        /// 7.4 Detail klubu
        /// </summary>
        public static Klub DetailKlubu(int id_klubu, Database pDb = null)
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

            command.Parameters.AddWithValue("@id_klub", id_klubu);
            SqlDataReader reader = db.Select(command);

            Collection<Klub> kluby = Read(reader);
            Klub klub = null;
            if (kluby.Count == 1)
            {
                klub = kluby[0];
            }
            reader.Close();

            if (pDb == null)
            {
                db.Close();
            }

            return klub;
        }



        private static Collection<Klub> Read(SqlDataReader reader)
        {
            Collection<Klub> kluby = new Collection<Klub>();

            while (reader.Read())
            {
                Klub klub = new Klub();
                int i = -1;
                klub.id_klub = reader.GetInt32(++i);
                klub.nazev = reader.GetString(++i);
                if (!reader.IsDBNull(++i))
                {
                    klub.id_trener = reader.GetInt32(i);
                }
                klub.id_hala = reader.GetInt32(++i);
                kluby.Add(klub);
            }
            return kluby;
        }
    }
}