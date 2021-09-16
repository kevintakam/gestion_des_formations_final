using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace gestion_des_formations_final.Models
{
    public class DocumentsVm
    {
        public int DocumentId { get; set; }
        public string Nom { get; set; }
        public IFormFile Contenu { get; set; }
        public int TypeDocumentId { get; set; }
        public string Intitule { get; set; }
        public int SessionId { get; set; }


    }
}
