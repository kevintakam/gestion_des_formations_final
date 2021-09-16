using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace gestion_des_formations_final.Models
{
    public class Entreprise
    {
        public int EntrepriseId { get; set; }
        [Required(ErrorMessage = "Entrer la désignation de l'entreprise")]

        public string Designation { get; set; }
        [Display(Name = "Secteur(s) d'activité(s)")]
        public string SecteurActivité { get; set; }
        [Display(Name = "Personne responsable")]
        [Required(ErrorMessage = "Entrer la personne responsable")]

        public string PersonneResponsable { get; set; }

        public string Metier { get; set; }
        [Display(Name = "Site Web")]
        public string Siteweb { get; set; }
        [Required(ErrorMessage = "Entrer un contact de l'entreprise")]
        public int Telephone { get; set; }
        [EmailAddress(ErrorMessage = "Email non valide")]
        public string Email { get; set; }
        [Display(Name = "Boite Postale")]
        public string Boitepostale { get; set; }
        [Display(Name = "Date Ajout")]
        public DateTime DateAjout { get; set; }
        [Display(Name = "Date Modif")]
        public DateTime DateModif { get; set; }
    }
}
