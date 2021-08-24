using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace gestion_des_formations_final.Models
{
    public class Utilisateur : Microsoft.AspNetCore.Identity.IdentityUser
    {
        public Utilisateur() : base()
        {
            
        }
        public int UtilisateurId { get; set; }
        public string Nom { get; set; }

    }
}
