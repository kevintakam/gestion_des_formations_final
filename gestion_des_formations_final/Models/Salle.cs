using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace gestion_des_formations_final.Models
{
    public class Salle
    {
        public int SalleId { get; set; }
        public string Designation { get; set; }
        public int LieuId { get; set; }

        public virtual Lieu Lieu { get; set; }
    }
}
