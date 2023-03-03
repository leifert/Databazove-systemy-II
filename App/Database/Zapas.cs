using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VolejbalovaLigaORM.ORM
{
    public class Zapas
    {
        public int id_zapas { get; set; }
        public int kolo { get; set; }
        public int id_domaci { get; set; }
        public int id_hoste { get; set; }
        public int domaci_sety { get; set; }
        public int hoste_sety { get; set; }
        public DateTime datum_zapasu { get; set; }
        public int id_rozhodci { get; set; }
        public int? pocet_divaku { get; set; }

        public string domaci { get; set; }
        public string hoste { get; set; }

    }
}
