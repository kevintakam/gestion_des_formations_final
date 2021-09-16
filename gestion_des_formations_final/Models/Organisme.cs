using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace gestion_des_formations_final.Models
{
    public class Organisme
    {
        public int OrganismeId { get; set; }
        [Display(Name = "Designation")]
        [Required(ErrorMessage = "Renseigner la désignation de l'organisation")]
        public string Designation { get; set; }
        [Display(Name = "Sigle")]

        public string Sigle { get; set; }
        [Display(Name = "Site Web")]
        public string SiteWeb { get; set; }
        public string Adresse { get; set; }
        public string Description { get; set; }
        [Display(Name = "Date Ajout")]
        public DateTime DateAjout { get; set; }
        [Display(Name = "Date Modif")]
        public DateTime DateModif { get; set; }

    }
}
