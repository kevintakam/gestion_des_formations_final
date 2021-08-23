using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace gestion_des_formations_final.Models
{
    public class Role
    {
        public int RoleId { get; set; }
        public string Designation { get; set; }
        public int UtilisateurId { get; set; }

        public virtual Utilisateur Utilisateur { get; set; }
    }
}
