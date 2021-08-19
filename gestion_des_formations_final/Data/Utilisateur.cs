using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace gestion_des_formations_final.Data
{
    public class Utilisateur
    {
        public int UtilisateurId { get; set; }
        public string Nom { get; set; } 
        public string Password { get; set; }
        public string ConfirmPassword { get; set; }
    }
}
