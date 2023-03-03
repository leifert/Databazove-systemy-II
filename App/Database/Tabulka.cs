using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VolejbalovaLigaORM.ORM
{
    public class Tabulka
    {
        public int id_klub { get; set; }
        public int zapasy_celkem { get; set; }
        public int vyhry { get; set; }
        public int prohry { get; set; }
        public int vyhrane_sety { get; set; }
        public int prohrane_sety { get; set; }
        public int body { get; set; }

        public string nazev { get; set; }


    }
}
