using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace gestion_des_formations_final.Data
{
    public class Document
    {
        public int DocumentId { get; set; }
        public string Nom { get; set; }
        public string Contenu { get; set; }
    }
}
