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
       9.1 Nova statistika
       9.2 Aktualizace statistiky
       9.3 Detail statistiky hracu v zapase
       9.4 Seznam vsech statistik pro konkretni zapas


     */

    public class Statistika_zapasuTable
    {
        public static string TABLE_NAME = "statistika_zapasu";
        public static string SQL_SELECT = "SELECT * FROM volejbal.statistika_zapasu";
        public static string SQL_SELECT_ID = "SELECT * FROM volejbal.statistika_zapasu where id_zapas=@id_zapas AND id_hrac=@id_hrac";
        public static string SQL_SELECT_ZAPASU = "SELECT * FROM volejbal.statistika_zapasu WHERE id_zapas=@id_zapas";
        public static string SQL_INSERT = "insert into volejbal.statistika_zapasu (id_zapas, id_hrac, eso, chybny_servis, utok, blok) values (@id_zapas, @id_hrac, @eso, @chybny_servis, @utok, @blok)";
        public static string SQL_UPDATE = "UPDATE volejbal.statistika_zapasu SET id_zapas=@id_zapas, id_hrac=@id_hrac, eso=@eso, chybny_servis=@chybny_servis, utok=@utok, blok=@blok where id_zapas=@id_zapas AND id_hrac=@id_hrac";



        private static void PrepareCommand(SqlCommand command, Statistika_zapasu stat )
        {
            command.Parameters.AddWithValue("@id_zapas", stat.id_zapas);
            command.Parameters.AddWithValue("@id_hrac", stat.id_hrac);
            command.Parameters.AddWithValue("@eso", stat.eso == null ? DBNull.Value : (object)stat.eso);
            command.Parameters.AddWithValue("@chybny_servis", stat.chybny_servis == null ? DBNull.Value : (object)stat.chybny_servis);
            command.Parameters.AddWithValue("@utok", stat.utok == null ? DBNull.Value : (object)stat.utok);
            command.Parameters.AddWithValue("@blok", stat.blok == null ? DBNull.Value : (object)stat.blok);
         


        }


        /// <summary>
        ///9.1 Nova statistika
        /// </summary>
        public static int Insert(Statistika_zapasu stat, Database pDb)
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
            PrepareCommand(command, stat);
            int ret = db.ExecuteNonQuery(command);

            if (pDb == null)
            {
                db.Close();
            }

            return ret;
        }

        /// <summary>
        /// 9.2 Aktualizace statistiky
        /// </summary>
        public static int Update(Statistika_zapasu stat, Database pDb = null)
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
            PrepareCommand(command, stat);
            int ret = db.ExecuteNonQuery(command);

            if (pDb == null)
            {
                db.Close();
            }

            return ret;
        }

        public static Collection<Statistika_zapasu> Select(Database pDb = null)
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

            Collection<Statistika_zapasu> staty = Read(reader);
            reader.Close();

            if (pDb == null)
            {
                db.Close();
            }

            return staty;
        }

        /// <summary>
        /// 9.3 Detail statistiky hracu v zapase
        /// </summary>
        public static Statistika_zapasu DetailStatistiky(int id_zapasu,int id_hrace, Database pDb = null)
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

            command.Parameters.AddWithValue("@id_zapas", id_zapasu);
            command.Parameters.AddWithValue("@id_hrac", id_hrace);
            SqlDataReader reader = db.Select(command);

            Collection<Statistika_zapasu> staty = Read(reader);
            Statistika_zapasu stat = null;
            if (staty.Count == 1)
            {
                stat = staty[0];
            }
            reader.Close();

            if (pDb == null)
            {
                db.Close();
            }

            return stat;
        }
       

        /// <summary>
        ///  9.4 Seznam vsech statistik pro konkretni zapas
        /// </summary>

        public static Collection<Statistika_zapasu> Statistika_zapasu(int id_zapasu, Database pDb = null)
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
            SqlCommand command = db.CreateCommand(SQL_SELECT_ZAPASU);

            command.Parameters.AddWithValue("@id_zapas", id_zapasu);
            SqlDataReader reader = db.Select(command);

            Collection<Statistika_zapasu> staty = Read(reader);
            reader.Close();
            if (pDb == null)
            {
                db.Close();
            }
            return staty;
        }




        private static Collection<Statistika_zapasu> Read(SqlDataReader reader)
        {
            Collection<Statistika_zapasu> staty = new Collection<Statistika_zapasu>();

            while (reader.Read())
            {
                Statistika_zapasu stat = new Statistika_zapasu();
                int i = -1;
                stat.id_zapas = reader.GetInt32(++i);
                stat.id_hrac = reader.GetInt32(++i);
                if (!reader.IsDBNull(++i))
                {
                    stat.eso = reader.GetInt32(i);
                }
                if (!reader.IsDBNull(++i))
                {
                    stat.chybny_servis = reader.GetInt32(i);
                }
                if (!reader.IsDBNull(++i))
                {
                    stat.utok = reader.GetInt32(i);
                }
                if (!reader.IsDBNull(++i))
                {
                    stat.blok = reader.GetInt32(i);
                }
                staty.Add(stat);
            }
            return staty;
        }
    }
}
