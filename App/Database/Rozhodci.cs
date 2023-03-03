using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VolejbalovaLigaORM.ORM
{
    public class Rozhodci
    {
        public int id_rozhodci { get; set; }
        public string jmeno { get; set; }
        public string prijmeni { get; set; }
        public int pocet_zapasu { get; set; }
        public string stav { get; set; }
        public string cele_jmeno { get; set; }
    }
}
