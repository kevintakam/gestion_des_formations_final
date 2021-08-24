using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace gestion_des_formations_final.Models
{
    public class Certification
    {
        public int CertificationId { get; set; }
        public string Designation { get; set; }
        public int OrganismeId { get; set; }

        public virtual Organisme Organisme { get; set; }
    }
}
