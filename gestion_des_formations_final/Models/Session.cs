using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace gestion_des_formations_final.Models
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
        public int SalleId { get; set; }
        public int FormationId { get; set; }
        public virtual Salle Salle { get; set; }
        public virtual Formation Formation { get; set; }
        public virtual ICollection<Prester> Prester { get; set; }
        public virtual ICollection<Assister> Assister { get; set; }
    }
}
