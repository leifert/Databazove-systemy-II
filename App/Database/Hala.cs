using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VolejbalovaLigaORM.ORM
{
    public class Hala
    {
        public int id_hala { get; set; }
        public string nazev { get; set; }
        public string adresa { get; set; }
        public int kapacita { get; set; }
        public int? cena_listku { get; set; }
        public int prumer;
    }
}
