﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace gestion_des_formations_final.Data
{
    public class Participant
    {
        public int ParticipantId { get; set; }
        public string Nom { get; set; }
        public string Prenom { get; set; }
        public string Email { get; set; }
        public int Telephone { get; set; }
        public string Adresse { get; set; }
        public string Statut { get; set; }
        public string ACertif { get; set; }

    }
}
