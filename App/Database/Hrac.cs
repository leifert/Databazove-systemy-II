using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VolejbalovaLigaORM.ORM
{
    public class Hrac
    {
        public int id_hrac { get; set; }
        public int? id_klub { get; set; }
        public string jmeno { get; set; }
        public string prijmeni { get; set; }
        public DateTime datum_narozeni { get; set; }
        public string pozice { get; set; }
        public int vyska { get; set; }
        public string stav { get; set; }

        public string klub;
        public int? eso;
        public int? chybny_servis;
        public int? utok;
        public int? blok;
        public string cele_jmeno { get; set; }

    }
}
