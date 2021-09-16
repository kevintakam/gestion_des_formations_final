using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using gestion_des_formations_final.Models;

namespace gestion_des_formations_final.ViewModels
{
    public class FormateurVm
    {
        public FormateurVm()
        {
            Aprester = new List<FormateurSession>();
        }
        [Key]
        public int FormateurTemporaireId { get; set; }
        [Required(ErrorMessage = "Renseignez le nom du formateur")]
        public string Nom { get; set; }
        public IFormFile Cv { get; set; }
        public string Prenom { get; set; }
        [Required(ErrorMessage = "Renseignez le mail du formateur")]
        [RegularExpression(@"^[a-zA-Z0-9]+@[a-zA-Z0-9]+\.[a-zA-Z0-9]+$", ErrorMessage = "Email invalide")]
        public string Email { get; set; }
        [Required(ErrorMessage = "Renseignez l'adresse du formateur")]
        public string Adresse { get; set; }
        public int NumeroCni { get; set; }
        [Required(ErrorMessage = "Renseignez le plus haut diplome du formateur")]
        public string Statut { get; set; }
        public int NbreAnneeExperience { get; set; }
        [Required(ErrorMessage = "Renseignez le numéro de téléphone du formateur")]
        public int Telephone { get; set; }
        [Required(ErrorMessage = "Renseignez le type de formateur")]
        public string Type { get; set; }
        public string NiveauAcademique { get; set; }
        public string Certifications { get; set; }
        public string Specialités { get; set; }
        public DateTime DateAjout { get; set; }
        public DateTime DateModif { get; set; }
        public virtual ICollection<FormateurSession> Aprester { get; set; }

    }
}
