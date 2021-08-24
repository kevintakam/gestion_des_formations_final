using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace gestion_des_formations_final.Models
{
    public class Privilege
    {
        public int PrivilegeId { get; set; }
        public string Designation { get; set; }
        public int RoleId { get; set; }
        public virtual Role Role { get; set; }
    }
}
