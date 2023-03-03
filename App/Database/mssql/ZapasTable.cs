using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VolejbalovaLigaORM.ORM.DAO.mssql
{

    /*
        8.1 Novy zapas
        8.2 Aktualizace zapasu
        8.3 Seznam vsech zapasu
        8.4 Seznam zapasu urciteho kola
        8.5 Detail zapasu
        8.6 Seznam kol
        8.7 Odehrani zapasu – transakce
        8.8 Zmena rozhodciho v zapase

     */

    public class ZapasTable
    {
        public static string TABLE_NAME = "zapas";
        public static string SQL_SELECT = "SELECT * FROM volejbal.zapas";
        public static string SQL_SELECT_ID = "SELECT * FROM volejbal.zapas WHERE id_zapas=@id_zapas";
        public static string SQL_INSERT = "insert into volejbal.zapas (kolo,id_domaci,id_hoste,domaci_sety,hoste_sety,datum_zapasu,id_rozhodci,pocet_divaku) values (@kolo,@id_domaci,@id_hoste,@domaci_sety,@hoste_sety,@datum_zapasu,@id_rozhodci,@pocet_divaku)";
        public static string SQL_UPDATE = "UPDATE volejbal.zapas SET kolo=@kolo,id_domaci=@id_domaci,id_hoste=@id_hoste,domaci_sety=@domaci_sety,hoste_sety=@hoste_sety,datum_zapasu=@datum_zapasu,id_rozhodci=@id_rozhodci,pocet_divaku=@pocet_divaku where id_zapas=@id_zapas";
        public static string SQL_SEZNAM_ZAPASU_KOLA = "select * from volejbal.zapas where kolo=@kolo";
        public static string SQL_SEZNAM_KOL = "select DISTINCT kolo from volejbal.zapas";
        public static string SQL_ODEHRAT_ZAPAS = "spOdehraniZapasu";
        public static string SQL_ZMENA_ROZHODCIHO = "UPDATE volejbal.zapas SET id_rozhodci=@id_rozhodci WHERE id_zapas=@id_zapas";
        public static string SQL_TABULKA_KOLA = "select kl.nazev, domaci_sety, hoste_sety,kl2.nazev from volejbal.zapas join volejbal.klub kl on volejbal.zapas.id_domaci = kl.id_klub join volejbal.klub kl2 on volejbal.zapas.id_hoste = kl2.id_klub where kolo=@kolo";


        private static void PrepareCommand(SqlCommand command, Zapas zapas)
        {
            command.Parameters.AddWithValue("@id_zapas", zapas.id_zapas);
            command.Parameters.AddWithValue("@kolo", zapas.kolo);
            command.Parameters.AddWithValue("@id_domaci", zapas.id_domaci);
            command.Parameters.AddWithValue("@id_hoste", zapas.id_hoste);
            command.Parameters.AddWithValue("@domaci_sety", zapas.domaci_sety);
            command.Parameters.AddWithValue("@hoste_sety", zapas.hoste_sety);
            command.Parameters.AddWithValue("@datum_zapasu", zapas.datum_zapasu);
            command.Parameters.AddWithValue("@id_rozhodci", zapas.id_rozhodci);
            command.Parameters.AddWithValue("@pocet_divaku", zapas.pocet_divaku == null ? DBNull.Value : (object)zapas.pocet_divaku);
          

        }


        /// <summary>
        /// 8.1 Novy zapas
        /// </summary>
        public static int Insert(Zapas zapas, Database pDb = null)
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
            PrepareCommand(command, zapas);
            int ret = db.ExecuteNonQuery(command);

            if (pDb == null)
            {
                db.Close();
            }

            return ret;
        }

        /// <summary>
        /// 8.2 Aktualizace zapasu
        /// </summary>
        public static int Update(Zapas zapas, Database pDb = null)
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
            PrepareCommand(command, zapas);
            int ret = db.ExecuteNonQuery(command);

            if (pDb == null)
            {
                db.Close();
            }

            return ret;
        }

        /// <summary>
        /// 8.3 Seznam zapasu
        /// </summary>
        public static Collection<Zapas> Select(Database pDb = null)
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

            Collection<Zapas> zapasy = Read(reader);
            reader.Close();

            if (pDb == null)
            {
                db.Close();
            }

            return zapasy;
        }


        /// <summary>
        ///   8.4 Seznam zápasů určitého kola
        /// </summary>
        public static Collection<Zapas> Seznam_zapasu_kola(int kolo, Database pDb = null)
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
            SqlCommand command = db.CreateCommand(SQL_SEZNAM_ZAPASU_KOLA);

            command.Parameters.AddWithValue("@kolo", kolo);
            SqlDataReader reader = db.Select(command);

            Collection<Zapas> zapasy = Read(reader);
            reader.Close();
            if (pDb == null)
            {
                db.Close();
            }
            return zapasy;
        }


        /// <summary>
        /// 8.5 Detail zapasu
        /// </summary>
        public static Zapas DetailZapasu(int id_zapasu, Database pDb = null)
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
            SqlDataReader reader = db.Select(command);

            Collection<Zapas> zapasy = Read(reader);
            Zapas zapas = null;
            if (zapasy.Count == 1)
            {
                zapas = zapasy[0];
            }
            reader.Close();

            if (pDb == null)
            {
                db.Close();
            }

            return zapas;
        }

        /// <summary>
        /// 8.6 Seznam kol
        /// </summary>
        public static Collection<Zapas> Seznam_kol(Database pDb = null)
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

            SqlCommand command = db.CreateCommand(SQL_SEZNAM_KOL);
            SqlDataReader reader = db.Select(command);

            Collection<Zapas> zapasy = Read2(reader);
            reader.Close();

            if (pDb == null)
            {
                db.Close();
            }

            return zapasy;
        }

        /// <summary>
        /// 8.7 Odehrani zapasu
        /// </summary>
        public static int Odehrat(int id_zapasu, int id_domaci, int id_hoste,int kolo,int domaci_sety,int hoste_sety, int id_rozhodci, int divaci, Database pDb = null)
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
            SqlCommand command = db.CreateCommand(SQL_ODEHRAT_ZAPAS, CommandType.StoredProcedure);

            command.Parameters.AddWithValue("@p_id_zapasu", id_zapasu);
            command.Parameters.AddWithValue("@p_id_domaci", id_domaci);
            command.Parameters.AddWithValue("@p_id_hoste", id_hoste);
            command.Parameters.AddWithValue("@p_kolo", kolo);
            command.Parameters.AddWithValue("@p_domaci_sety", domaci_sety);
            command.Parameters.AddWithValue("@p_hoste_sety", hoste_sety);
            command.Parameters.AddWithValue("@p_id_rozhodci", id_rozhodci);
            command.Parameters.AddWithValue("@p_pocet_divaku", divaci);

            int ret = db.ExecuteNonQuery(command);

            if (pDb == null)
            {
                db.Close();
            }

            return ret;
        }
        /// <summary>
        /// 8.8 Zmena rozhodciho v zapase
        /// </summary>
        public static int ZmenaRozhodciho(int id_zapasu, int id_rozhodci,  Database pDb = null)
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
            SqlCommand command = db.CreateCommand(SQL_ZMENA_ROZHODCIHO);

            command.Parameters.AddWithValue("@id_zapas", id_zapasu);
            command.Parameters.AddWithValue("@id_rozhodci", id_rozhodci);

            int ret = db.ExecuteNonQuery(command);

            if (pDb == null)
            {
                db.Close();
            }

            return ret;
        }

        public static Collection<Zapas> Zapasy_kola(int kolo, Database pDb = null)
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
            SqlCommand command = db.CreateCommand(SQL_TABULKA_KOLA);

            command.Parameters.AddWithValue("@kolo", kolo);
            SqlDataReader reader = db.Select(command);

            Collection<Zapas> zapasy = Read3(reader);
            reader.Close();
            if (pDb == null)
            {
                db.Close();
            }
            return zapasy;
        }

        private static Collection<Zapas> Read(SqlDataReader reader)
        {
            Collection<Zapas> zapasy = new Collection<Zapas>();

            while (reader.Read())
            {
                Zapas zapas = new Zapas();
                int i = -1;
                zapas.id_zapas = reader.GetInt32(++i);
                zapas.kolo = reader.GetInt32(++i);
                zapas.id_domaci = reader.GetInt32(++i);
                zapas.id_hoste = reader.GetInt32(++i);
                zapas.domaci_sety = reader.GetInt32(++i);
                zapas.hoste_sety = reader.GetInt32(++i);
                zapas.datum_zapasu = reader.GetDateTime(++i);
                zapas.id_rozhodci = reader.GetInt32(++i);
                if (!reader.IsDBNull(++i))
                {
                    zapas.pocet_divaku = reader.GetInt32(i);
                }
                zapasy.Add(zapas);
            }
            return zapasy;
        }
        private static Collection<Zapas> Read2(SqlDataReader reader)
        {
            Collection<Zapas> zapasy = new Collection<Zapas>();

            while (reader.Read())
            {
                Zapas zapas = new Zapas();
                int i = -1;
              
                zapas.kolo = reader.GetInt32(++i);
                zapasy.Add(zapas);
            }
            return zapasy;
        }
        private static Collection<Zapas> Read3(SqlDataReader reader)
        {
            Collection<Zapas> zapasy = new Collection<Zapas>();

            while (reader.Read())
            {
                Zapas zapas = new Zapas();
                int i = -1;
                zapas.domaci = reader.GetString(++i);
                zapas.domaci_sety = reader.GetInt32(++i);
                zapas.hoste_sety = reader.GetInt32(++i);
                zapas.hoste = reader.GetString(++i);
                zapasy.Add(zapas);
            }
            return zapasy;
        }
    }
}