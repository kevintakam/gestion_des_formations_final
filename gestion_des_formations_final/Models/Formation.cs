using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace gestion_des_formations_final.Models
{
    public class Formation
    {
        public int FormationId { get; set; }
        [Display(Name ="Intitule de la formation")]
        [Required(ErrorMessage = "Renseigner l'intitule de la formation")]
        public string Intitule { get; set; }
        [Display(Name = "Prix ")]
        [Required(ErrorMessage = "Renseigner le prix de la formation")]
        public float Prix { get; set; }
        [Required(ErrorMessage = "Renseigner la duree de la formation")]
        public int Duree { get; set; }

        [Display(Name = "Objectif de la formation")]
        public string Description { get; set; }
        [Display(Name = "Formation certifiee ")]
        public bool FormationCertifiee { get; set; }
        public DateTime DateAjout { get; set; }
        public DateTime DateModif { get; set; }
    }
}
