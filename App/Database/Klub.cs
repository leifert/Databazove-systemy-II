using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VolejbalovaLigaORM.ORM
{
    public class Klub
    {
        public int id_klub { get; set; }
        public string nazev { get; set; }
        public int? id_trener { get; set; }
        public int id_hala { get; set; }
      
    }
}
