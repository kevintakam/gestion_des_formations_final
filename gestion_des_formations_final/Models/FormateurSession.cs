using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace gestion_des_formations_final.Models
{
    public class FormateurSession
    {
        public int SessionId { get; set; }
        public int FormateurId { get; set; }

        public virtual Formateur Formateur { get; set; }
        public virtual Session Session { get; set; }
    }
}
