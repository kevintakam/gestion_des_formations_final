using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace gestion_des_formations_final.Models
{
    public class Certification
    {
        public int CertificationId { get; set; }
        public string Designation { get; set; }
        public int OrganismeId { get; set; }
        public string Description { get; set; }
        [Display(Name = "Date Ajout")]
        public DateTime DateAjout { get; set; }
        [Display(Name = "Date Modif")]
        public DateTime DateModif { get; set; }
        public virtual Organisme Organisme { get; set; }
    }
}
