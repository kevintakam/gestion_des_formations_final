using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace gestion_des_formations_final.Data
{
    public class Formation
    {
        public int FormationId { get; set; }
        public string Intitule { get; set; }
        public int Prix { get; set; }
        public int Duree { get; set; }
    }
}
