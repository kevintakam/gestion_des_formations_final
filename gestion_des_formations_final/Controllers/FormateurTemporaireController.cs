using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using gestion_des_formations_final.Models;
using gestion_des_formations_final.Data;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Microsoft.AspNetCore.Http;
using gestion_des_formations_final.ViewModels;
using Microsoft.Extensions.Hosting.Internal;
using System.IO;
using Microsoft.AspNetCore.Hosting;

namespace gestion_des_formations_final.Controllers
{
    public class FormateurTemporaireController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly IWebHostEnvironment _env;
        public FormateurTemporaireController(ApplicationDbContext context, IWebHostEnvironment env)
        {
            _context = context;
            _env = env;
        }
        public IActionResult Index()
        {
            List<FormateurTemporaire> Formateur = _context.FormateurT.ToList();
            ViewData["Title"] = "Gestion des formations";
            ViewData["second_title"] = "Nos Formateurs";
            return View(Formateur);
        }
        public IActionResult Details(int Id)
        {
            ViewData["Title"] = "Gestion des formations";
            ViewData["second_title"] = "Formateurs >  Details Formateur";
            FormateurTemporaire Formateur = _context.FormateurT.Where(p => p.FormateurTemporaireId == Id).FirstOrDefault();
            return View(Formateur);
        }
        [HttpGet]
        public IActionResult Edit(int Id)
        {
            ViewData["Title"] = "Gestion des formations";
            ViewData["second_title"] = "Formateurs >  Modifier un Formateur";
            FormateurTemporaire formateur = _context.FormateurT.Where(p => p.FormateurTemporaireId == Id).FirstOrDefault();

            return View(formateur);
        }
        [HttpPost]
        public IActionResult Edit(FormateurTemporaire formateur)
        {

            formateur.DateModif = DateTime.Now;

            _context.Attach(formateur);
            _context.Entry(formateur).State = EntityState.Modified;
     
                FormateurTemporaire f = _context.FormateurT.FirstOrDefault(e => e.FormateurTemporaireId == formateur.FormateurTemporaireId);
                Formateur form = new Formateur()
                {

                    Nom = f.Nom,
                    Prenom = f.Prenom,
                    Email = f.Email,
                    Adresse = f.Adresse,
                    NbreAnneeExperience = f.NbreAnneeExperience,
                    Telephone = f.Telephone,
                    Type = f.Type,
                    NiveauAcademique = f.NiveauAcademique,
                    Certifications = f.Certifications,
                    Specialités = f.Specialités,
                    Statut = f.Statut

                };
                _context.FormateurP.Update(form);
            
            _context.SaveChanges();
            return RedirectToAction("Index");

        }
        [HttpGet]
        public async Task<IActionResult> DeleteAsync(int? id)
        {
            ViewData["Title"] = "Gestion des formations";
            ViewData["second_title"] = "Formateurs >  modifier Formateur";
            var formateur = await _context.FormateurT.FindAsync(id);
            _context.FormateurT.Remove(formateur);
            await _context.SaveChangesAsync();
            return RedirectToAction("index");

        }
        [HttpGet]
        public ActionResult Create()
        {
            FormateurTemporaire formateur = new FormateurTemporaire();
            ViewData["Title"] = "Gestion des formations";
            ViewData["second_title"] = "Formateurs >  Nouveau Formateur ";

            return View(formateur);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(FormateurVm formateurVm)
        {
            try
            {
                if (FormateurExist(formateurVm.Nom, formateurVm.Prenom))
                {
                    ViewData["message"] = "ce formateur a  déjà  été enregistré !";
                    return View();
                }
                else
                {
                    if (formateurVm.Prenom == null)
                    {
                        formateurVm.Prenom = "";
                    }
                    FormateurTemporaire formateurT = new FormateurTemporaire()
                    {

                        Nom = formateurVm.Nom,
                        Prenom = formateurVm.Prenom,
                        Email = formateurVm.Email,
                        Adresse = formateurVm.Adresse,
                        NbreAnneeExperience = formateurVm.NbreAnneeExperience,
                        Telephone = formateurVm.Telephone,
                        Statut = formateurVm.Statut,
                        Type = formateurVm.Type,
                        NiveauAcademique = formateurVm.NiveauAcademique,
                        Certifications = formateurVm.Certifications,
                        Specialités = formateurVm.Specialités,
                        DateAjout = DateTime.Now,
                        DateModif = DateTime.Now

                    };
                    if (formateurVm.Cv != null)
                    {
                        formateurT.Cv = FileUpload(formateurVm.Cv, formateurT.Nom, formateurT.Prenom);
                        _context.FormateurT.Add(formateurT);
                        _context.SaveChanges();
                    }
                    return RedirectToAction("Index");
                }
            }
            catch (Exception)
            {
                return View();
            }
        }

        public string FileUpload(IFormFile file, string nom, string prenom)
        {

            string ext = Path.GetExtension(file.FileName);
            if (ext.ToLower() == ".pdf" || ext.ToLower() != ".doc" || ext.ToLower() != ".docx")
            {
                var newName = "CV_" + new DateTimeOffset(DateTime.UtcNow).ToUnixTimeMilliseconds().ToString() + "_" + nom.ToUpper() + prenom.ToUpper() + ext;
                var filePath = Path.Combine(_env.WebRootPath, "CVFormateur", newName.ToString());

                using (var filestream = new FileStream(filePath, FileMode.Create))
                {
                    file.CopyTo(filestream);
                }
                return newName.ToString();
            }

            return "";
        }
        private bool FormateurExist(string nom, string prenom)
        {
            return _context.FormateurT.Any(e => e.Nom == nom && e.Prenom == prenom);
        }
    }

}
