using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace gestion_des_formations_final.Models
{
    public class SessionsVm
    {
        public SessionsVm()
        {
            ParticipantSessions = new List<ParticipantSession>();
            FormateurSessions = new List<FormateurSession>();
        }
        public int SessionId { get; set; }
        public DateTime DateDebut { get; set; }
        public DateTime DateFin { get; set; }
        public string Statut { get; set; }
        public int FormationId { get; set; }
        public int SalleId { get; set; }
        public int FormateurId { get; set; }

        public DateTime DateAjout { get; set; }
        public DateTime DateModif { get; set; }
        public virtual IList<FormateurSession> FormateurSessions { get; set; }
        public virtual IList<ParticipantSession> ParticipantSessions { get; set; }

    }
}
