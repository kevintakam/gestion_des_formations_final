using gestion_des_formations_final.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace gestion_des_formations_final.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {

        }
        public DbSet<Assister> Assister { get; set; }
        public DbSet<Certification> Certification { get; set; }
        public DbSet<Document> Document { get; set; }
        public DbSet<Entreprise> Entreprise { get; set; }
        public DbSet<Formateur> Formateur { get; set; }
        public DbSet<Formation> Formation { get; set; }
        public DbSet<Lieu> Lieux { get; set; }
        public DbSet<Organisme> Organisme { get; set; }
        public DbSet<Participant> Participant { get; set; }
        public DbSet<Prester> Prester { get; set; }
        public DbSet<Privilege> Privilege { get; set; }
        public DbSet<Role> Role { get; set; }
        public DbSet<Salle> Salle { get; set; }
        public DbSet<Session> Session { get; set; }
        public DbSet<TypeDocument> TypeDocument { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Prester>().HasKey(t => new { t.FormateurId, t.SessionId });
            modelBuilder.Entity<Assister>().HasKey(t => new { t.ParticipantId, t.SessionId });
        }
    }
}
