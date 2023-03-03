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
        5.1 Novy prestup
        5.2 Aktualizace prestupu
        5.3 Vypis vsech prestupu hrace
     */

    public class Historie_prestupuTable
    {
        public static string TABLE_NAME = "historie_prestupu";
        public static string SQL_SELECT = "SELECT * FROM volejbal.historie_prestupu";
        public static string SQL_SELECT_ID = "SELECT * FROM volejbal.historie_prestupu WHERE id_prestup=@id_prestup";
        public static string SQL_INSERT = "insert into volejbal.historie_prestupu (id_hrac,stary_klub,novy_klub,datum_prestupu, cena_prestupu) values (@id_hrac,@stary_klub,@novy_klub,@datum_prestupu, @cena_prestupu)";
        public static string SQL_UPDATE = "UPDATE volejbal.historie_prestupu SET id_hrac=@id_hrac,stary_klub=@id_hrac,novy_klub=@novy_klub,datum_prestupu=@datum_prestupu, cena_prestupu=@cena_prestupu where id_prestup=@id_prestup";
        public static string SQL_PRESTUPY_HRACE = "select * from volejbal.historie_prestupu where id_hrac = @id_hrac";
        public static string SQL_PRESTUP = "spNovyPrestup";

        private static void PrepareCommand(SqlCommand command, Historie_prestupu prestup)
        {
            command.Parameters.AddWithValue("@id_prestup", prestup.id_prestup);
            command.Parameters.AddWithValue("@id_hrac", prestup.id_hrac);
            command.Parameters.AddWithValue("@stary_klub", prestup.stary_klub);
            command.Parameters.AddWithValue("@novy_klub", prestup.novy_klub);
            command.Parameters.AddWithValue("@datum_prestupu", prestup.datum_prestupu);
            command.Parameters.AddWithValue("@cena_prestupu", prestup.cena_prestupu == null ? DBNull.Value : (object)prestup.cena_prestupu);
        }

        /// <summary>
        /// 5.1 Novy prestup
        /// </summary>
        public static int Prestup(int id_hrace, int novy_klub, int cena, Database pDb = null)
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
            SqlCommand command = db.CreateCommand(SQL_PRESTUP, CommandType.StoredProcedure);

            command.Parameters.AddWithValue("@p_id_hrac", id_hrace);
            command.Parameters.AddWithValue("@p_novy_klub", novy_klub);
            command.Parameters.AddWithValue("@p_cena_prestupu", cena);
            int ret = db.ExecuteNonQuery(command);

            if (pDb == null)
            {
                db.Close();
            }

            return ret;
        }




        /// <summary>
        /// 5.2 Aktualizace prestupu
        /// </summary>
        public static int Update(Historie_prestupu prestup, Database pDb = null)
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
            PrepareCommand(command, prestup);
            int ret = db.ExecuteNonQuery(command);

            if (pDb == null)
            {
                db.Close();
            }

            return ret;
        }

        /// <summary>
        /// 5.3 Vypis vsech prestupu hrace
        /// </summary>
        public static Collection<Historie_prestupu> Seznam_prestupu_hrace(int id_hrace, Database pDb = null)
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
            SqlCommand command = db.CreateCommand(SQL_PRESTUPY_HRACE);

            command.Parameters.AddWithValue("@id_hrac", id_hrace);
            SqlDataReader reader = db.Select(command);

            Collection<Historie_prestupu> prestupy = Read(reader);
            reader.Close();
            if (pDb == null)
            {
                db.Close();
            }
            return prestupy;
        }
        

        private static Collection<Historie_prestupu> Read(SqlDataReader reader)
        {
            Collection<Historie_prestupu> prestupy = new Collection<Historie_prestupu>();

            while (reader.Read())
            {
                Historie_prestupu prestup = new Historie_prestupu();
                int i = -1;
                prestup.id_prestup = reader.GetInt32(++i);
                prestup.id_hrac = reader.GetInt32(++i);
                prestup.stary_klub = reader.GetInt32(++i);
                prestup.novy_klub = reader.GetInt32(++i);
                prestup.datum_prestupu = reader.GetDateTime(++i);
                if (!reader.IsDBNull(++i))
                {
                    prestup.cena_prestupu = reader.GetInt32(i);
                }
                prestupy.Add(prestup);

            }
            return prestupy;
        }
    }
}
