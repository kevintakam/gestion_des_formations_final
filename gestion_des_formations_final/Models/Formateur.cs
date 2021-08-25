using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace gestion_des_formations_final.Models
{
    public class Formateur
    {
        [Key]
        public int FormateurId { get; set; }
        [Required(ErrorMessage ="Renseignez le nom du formateur")]
        public string Nom { get; set; }
        [Required(ErrorMessage = "Renseignez le prenom du formateur")]
        public string Prenom { get; set; }
        [Required(ErrorMessage = "Renseignez le mail du formateur")]
        public string Email { get; set; }
        [Required(ErrorMessage = "Renseignez l'adresse du formateur")]
        public string Adresse { get; set; }
        [Required(ErrorMessage = "Renseignez la date et l'heure de naissance du formateur")]
        [Display(Name = "Date et Heure de Naissance")]
        public DateTime DateAnniv { get; set; }
        [Required(ErrorMessage = "Renseignez le numéro de téléphone du formateur")]
        public int Telephone { get; set; }
        [Required(ErrorMessage = "Renseignez le type de formateur")]
        public string Type { get; set; }
        public virtual ICollection<Prester> APrester
        { get; set; }
    }
}
