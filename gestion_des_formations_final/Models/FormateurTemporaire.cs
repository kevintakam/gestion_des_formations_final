using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Http;

namespace gestion_des_formations_final.Models
{
    public class FormateurTemporaire
    {
        [Key]
        public int FormateurTemporaireId { get; set; }

        [Required(ErrorMessage = "Renseignez le nom du formateur")]
        [Display(Name = "Nom")]
        public string Nom { get; set; }

        [Display(Name = "Prenom")]
        public string Prenom { get; set; }

        [Required(ErrorMessage = "Renseignez le mail du formateur")]
        [RegularExpression(@"^[a-zA-Z0-9]+@[a-zA-Z0-9]+\.[a-zA-Z0-9]+$", ErrorMessage = "Email invalide")]
        public string Email { get; set; }

        public string Adresse { get; set; }

        public string Cv { get; set; }
        [Required(ErrorMessage = "Renseignez le numero de CNI du formateur")]
        [Display(Name = "CNI")]
        public int NumeroCni { get; set; }
        public string Statut { get; set; }
        [Required(ErrorMessage = "Renseignez le nombre d'années d'expériences du formateur")]
        [Display(Name = "Année(s) d'expérience(s)")]
        public int NbreAnneeExperience { get; set; }
        [Required(ErrorMessage = "Renseignez le numéro de téléphone du formateur")]
        public int Telephone { get; set; }
        [Required(ErrorMessage = "Renseignez le type de formateur")]
        public string Type { get; set; }
        [Display(Name = "Niveau Académique")]
        public string NiveauAcademique { get; set; }
        public string Certifications { get; set; }
        [Required(ErrorMessage = "Renseignez la ou les Spécialités du formateur")]
        public string Specialités { get; set; }
        [Display(Name = "Date Ajout")]
        public DateTime DateAjout { get; set; }
        [Display(Name = "Date Modif")]
        public DateTime DateModif { get; set; }


    }
}
