using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace gestion_des_formations_final.Models
{
    public class Formateur
    {
          
        [Key]
        public int FormateurId { get; set; }
        public string Nom { get; set; }
        public string Prenom { get; set; }
        public string Email { get; set; }
        public string Adresse { get; set; }
        public int NumeroCni { get; set; }
        public string Cv { get; set; }
        public int NbreAnneeExperience { get; set; }
        public int Telephone { get; set; }
        public string Type { get; set; }
        public string NiveauAcademique { get; set; }
        public string Certifications { get; set; }
        public string Specialités { get; set; }
        public string Statut { get; set; }
        [Display(Name = "Date Ajout")]
        public DateTime DateAjout { get; set; }
        [Display(Name = "Date Modif")]
        public DateTime DateModif { get; set; }
        public virtual ICollection<FormateurSession> Prester { get; set; }


    }
}
