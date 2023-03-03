using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VolejbalovaLigaORM.ORM
{
    public class Historie_prestupu
    {
        public int id_prestup { get; set; }
        public int id_hrac { get; set; }
        public int stary_klub { get; set; }
        public int novy_klub { get; set; }
        public DateTime datum_prestupu { get; set; }
        public int? cena_prestupu { get; set; }


    }
}
