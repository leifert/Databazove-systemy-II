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
        4.1 Nový hráč
        4.2 Smazání hráče – nastavení atributu stav na neaktivní,systém neumožní
        uživateli fyzicky provést operaci DELETE
        4.3 Obnovení hráče – nastavení atributu stav na aktivní
        4.4 Aktualizace hráče
        4.5 Seznam hráčů
        4.6 Detail hráče
        4.7 Seznam hráčů v klubu
        4.8 Seznam hráčů a statistiky v zápase
        4.9 Seznam hráčů a jejich celkové statistiky

     */

    public class HracTable
    {
        public static string TABLE_NAME = "hrac";
        public static string SQL_SELECT = "SELECT * FROM volejbal.hrac";
        public static string SQL_SELECT_ID = "SELECT * FROM volejbal.hrac WHERE id_hrac=@id_hrac";
        public static string SQL_INSERT = "insert into volejbal.hrac (id_klub,jmeno,prijmeni,datum_narozeni,pozice,vyska,stav) values (@id_klub,@jmeno,@prijmeni,@datum_narozeni,@pozice,@vyska,@stav)";
        public static string SQL_DELETE_ID = "UPDATE volejbal.hrac SET stav = 'Neaktivní' where id_hrac=@id_hrac";
        public static string SQL_OBNOVIT_ID = "UPDATE volejbal.hrac SET stav = 'Aktivní' where id_hrac=@id_hrac";
        public static string SQL_UPDATE = "UPDATE volejbal.hrac SET id_klub=@id_klub,jmeno=@jmeno,prijmeni=@prijmeni,datum_narozeni=@datum_narozeni,pozice=@pozice,vyska=@vyska,stav=@stav where id_hrac=@id_hrac";
        public static string SQL_SEZNAM_HRACU_V_KLUBU = "select * from volejbal.hrac where id_klub = @id_klub";
        public static string SQL_STATISTIKA_HRACU_V_ZAPASE = "Select k.nazev, h.jmeno, h.prijmeni, s.eso,s.chybny_servis, s.utok, s.blok from volejbal.hrac h join volejbal.statistika_zapasu s ON h.id_hrac = s.id_hrac join volejbal.klub k on h.id_klub = k.id_klub where s.id_zapas = @id_zapas order by k.nazev";
        public static string SQl_STAT_CELKEM = "Select k.nazev, h.jmeno, h.prijmeni, sum(s.eso)AS 'esa',sum(s.chybny_servis) AS 'chybne_servisy', sum(s.utok)AS'utoky', sum(s.blok)AS'bloky' from volejbal.hrac h join volejbal.statistika_zapasu s ON h.id_hrac = s.id_hrac join volejbal.klub k on h.id_klub = k.id_klub group by k.nazev, h.jmeno, h.prijmeni order by k.nazev";

        private static void PrepareCommand(SqlCommand command, Hrac hrac)
        {
            command.Parameters.AddWithValue("@id_hrac", hrac.id_hrac);
            command.Parameters.AddWithValue("@id_klub", hrac.id_klub == null ? DBNull.Value : (object)hrac.id_klub);
            command.Parameters.AddWithValue("@jmeno", hrac.jmeno);
            command.Parameters.AddWithValue("@prijmeni", hrac.prijmeni);
            command.Parameters.AddWithValue("@datum_narozeni", hrac.datum_narozeni);
            command.Parameters.AddWithValue("@pozice", hrac.pozice);
            command.Parameters.AddWithValue("@vyska", hrac.vyska);
            command.Parameters.AddWithValue("@stav", hrac.stav);


        }


        /// <summary>
        /// 4.1 Nový hráč
        /// </summary>
        public static int Insert(Hrac hrac, Database pDb)
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
            PrepareCommand(command, hrac);
            int ret = db.ExecuteNonQuery(command);

            if (pDb == null)
            {
                db.Close();
            }

            return ret;
        }

        /// <summary>
        /// 4.2 smazani hrace
        /// </summary>
        public static int delete(int id_hrace, Database pDb = null)
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

            command.Parameters.AddWithValue("@id_hrac", id_hrace);
            int ret = db.ExecuteNonQuery(command);

            if (pDb == null)
            {
                db.Close();
            }

            return ret;
        }

        /// <summary>
        /// 4.3 Obnoveni hrace
        /// </summary>
        public static int ObnoveniHrace(int id_hrace, Database pDb = null)
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
            SqlCommand command = db.CreateCommand(SQL_OBNOVIT_ID);

            command.Parameters.AddWithValue("@id_hrac", id_hrace);
            int ret = db.ExecuteNonQuery(command);

            if (pDb == null)
            {
                db.Close();
            }

            return ret;
        }

        /// <summary>
        /// 4.4 Aktualizace hráče
        /// </summary>
        public static int Update(Hrac hrac, Database pDb = null)
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
            PrepareCommand(command, hrac);
            int ret = db.ExecuteNonQuery(command);

            if (pDb == null)
            {
                db.Close();
            }

            return ret;
        }

        /// <summary>
        /// 4.5 Seznam hráčů
        /// </summary>
        public static Collection<Hrac> Select(Database pDb = null)
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

            Collection<Hrac> hraci = Read(reader);
            reader.Close();

            if (pDb == null)
            {
                db.Close();
            }

            return hraci;
        }


        /// <summary>
        /// 4.6 Detail hrace
        /// </summary>
        public static Hrac DetailHrace(int id_hrace, Database pDb = null)
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

            command.Parameters.AddWithValue("@id_hrac", id_hrace);
            SqlDataReader reader = db.Select(command);

            Collection<Hrac> hraci = Read(reader);
            Hrac hrac = null;
            if (hraci.Count == 1)
            {
                hrac = hraci[0];
            }
            reader.Close();

            if (pDb == null)
            {
                db.Close();
            }

            return hrac;
        }

        /// <summary>
        ///  4.7 Seznam hracu v klubu
        /// </summary>
        public static Collection<Hrac> Seznam_hracu_v_klubu(int id_klub, Database pDb = null)
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
            SqlCommand command = db.CreateCommand(SQL_SEZNAM_HRACU_V_KLUBU);

            command.Parameters.AddWithValue("@id_klub", id_klub);
            SqlDataReader reader = db.Select(command);

            Collection<Hrac> hraci = Read(reader);
            reader.Close();
            if (pDb == null)
            {
                db.Close();
            }
            return hraci;
        }

        /// <summary>
        ///  4.8 Seznam hracu a statistiky v zapase
        /// </summary>
        public static Collection<Hrac> Statistika_hracu_zapas(int id_zapasu, Database pDb = null)
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
            SqlCommand command = db.CreateCommand(SQL_STATISTIKA_HRACU_V_ZAPASE);

            command.Parameters.AddWithValue("@id_zapas", id_zapasu);
            SqlDataReader reader = db.Select(command);

            Collection<Hrac> hraci = Read2(reader);
            reader.Close();
            if (pDb == null)
            {
                db.Close();
            }
            return hraci;
        }

        /// <summary>
        ///  4.9 Seznam hracu a jejich celkove statistiky
        /// </summary>
        public static Collection<Hrac> Statistika_hracu_celkem(Database pDb = null)
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
            SqlCommand command = db.CreateCommand(SQl_STAT_CELKEM);

           
            SqlDataReader reader = db.Select(command);

            Collection<Hrac> hraci = Read2(reader);
            reader.Close();
            if (pDb == null)
            {
                db.Close();
            }
            return hraci;
        }

        private static Collection<Hrac> Read(SqlDataReader reader)
        {
            Collection<Hrac> hraci = new Collection<Hrac>();

            while (reader.Read())
            {
                Hrac hrac = new Hrac();
                int i = -1;
                hrac.id_hrac = reader.GetInt32(++i);
                if (!reader.IsDBNull(++i))
                {
                    hrac.id_klub = reader.GetInt32(i);
                }
                hrac.jmeno = reader.GetString(++i);
                hrac.prijmeni = reader.GetString(++i);
                hrac.datum_narozeni = reader.GetDateTime(++i);
                hrac.pozice = reader.GetString(++i);
                hrac.vyska = reader.GetInt32(++i);
                hrac.stav = reader.GetString(++i);
                hrac.cele_jmeno = hrac.jmeno + " "+ hrac.prijmeni;
                hraci.Add(hrac);
            }
            return hraci;
        }

        private static Collection<Hrac> Read2(SqlDataReader reader)
        {
            Collection<Hrac> hraci = new Collection<Hrac>();

            while (reader.Read())
            {
                Hrac hrac = new Hrac();
                int i = -1;
                hrac.klub = reader.GetString(++i);
                hrac.jmeno = reader.GetString(++i);
                hrac.prijmeni = reader.GetString(++i);
                if (!reader.IsDBNull(++i))
                {
                    hrac.eso = reader.GetInt32(i);
                }
                if (!reader.IsDBNull(++i))
                {
                    hrac.chybny_servis = reader.GetInt32(i);
                }
                if (!reader.IsDBNull(++i))
                {
                    hrac.utok = reader.GetInt32(i);
                }
                if (!reader.IsDBNull(++i))
                {
                    hrac.blok = reader.GetInt32(i);
                }
                hraci.Add(hrac);
            }
            return hraci;
        }
    }
}