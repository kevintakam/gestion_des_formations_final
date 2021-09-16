using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace gestion_des_formations_final.Models
{
    public class ParticipantSession
    {
        public int ParticipantId { get; set; }
        public int SessionId { get; set; }
        public virtual Participant Participant { get; set; }
        public virtual Session Session { get; set; }
    }
}
