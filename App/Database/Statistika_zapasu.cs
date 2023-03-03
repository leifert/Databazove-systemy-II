using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VolejbalovaLigaORM.ORM
{
    public class Statistika_zapasu
    {
        public int id_zapas { get; set; }
        public int id_hrac { get; set; }
        public int? eso { get; set; }
        public int? chybny_servis { get; set; }
        public int? utok { get; set; }
        public int? blok { get; set; }
    }
}
