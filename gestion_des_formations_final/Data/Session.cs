using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace gestion_des_formations_final.Data
{
    public class Session
    {
        public int SessionId { get; set; }
        public string Intitule { get; set; }
        public DateTime DateDebut { get; set; }
        public DateTime DateFin { get; set; }
        public string Statut { get; set; }
        public int Evaluation { get; set; }
        public string Examen { get; set; }
    }
}
