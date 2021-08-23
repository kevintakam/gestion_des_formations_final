using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace gestion_des_formations_final.Models
{
    public class Document
    {
        public int DocumentId { get; set; }
        public string Nom { get; set; }
        public string Contenu { get; set; }
        public int TypeDocumentId { get; set; }
        public int SessionId { get; set; }
        public virtual TypeDocument TypeDocument { get; set; }
        public virtual Session Session { get; set; }

    }
}
