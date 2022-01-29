using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace gestion_des_formations_final.Models
{
    public class Session
    {
        public int SessionId { get; set; }  
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd-MM-yyyy}", ApplyFormatInEditMode = true)]
        [Required(ErrorMessage = "Veuillez sélectionner la date de debut de la formation")]
        public DateTime DateDebut { get; set; }
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd-MM-yyyy}", ApplyFormatInEditMode = true)]
        [Required(ErrorMessage = "Veuillez sélectionner la date de fin de la formation")]
        public DateTime DateFin { get; set; }
        public string Statut { get; set; }
        public int Evaluation { get; set; }
        public string Examen { get; set; }
        [Display(Name = "Salle de la session")]
        public int SalleId { get; set; }
        [Display(Name = "Formation")]
        public int FormationId { get; set; }
        public virtual Salle Salle { get; set; }
        public virtual Formation Formation { get; set; }
        public DateTime DateAjout { get; set; }
        public DateTime DateModif { get; set; }
        public virtual ICollection<FormateurSession> Aprester { get; set; }
        public virtual ICollection<ParticipantSession> Assister { get; set; }
    }
}
