using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace gestion_des_formations_final.Models
{
    public class Salle
    {
        public int SalleId { get; set; }
        [Required(ErrorMessage = "Renseignez la désignation de la salle ")]
        public string Designation { get; set; }
        
        public string Lieu { get; set; }
        [Display(Name = "Date Ajout")]
        public DateTime DateAjout { get; set; }

        [Display(Name = "Date Modif")]
        public DateTime DateModif { get; set; }
    }
}
