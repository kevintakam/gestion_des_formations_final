using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace gestion_des_formations_final.Models
{
    public class Entreprise
    {
        public int EntrepriseId { get; set; }
        public string Designation { get; set; }
        public string Raisonsociale { get; set; }
        public string Boitepostale { get; set; }
        public string Fax { get; set; }
    }
}
