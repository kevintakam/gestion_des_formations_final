using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using gestion_des_formations_final.Models;
using gestion_des_formations_final.Data;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
namespace gestion_des_formations_final.Controllers
{
    public class FormateurController : Controller
    {
        private readonly ApplicationDbContext _context;
        public FormateurController (ApplicationDbContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            List<Formateur> Formateur = _context.Formateur.ToList();
            ViewData["Title"] = "Gestion des formations";
            ViewData["second_title"] = "Nos Formateurs";
            return View(Formateur);
        }
        public IActionResult Details(int Id)
        {
            ViewData["Title"] = "Gestion des formations";
            ViewData["second_title"] = "Formateurs >  Details Formateur";
            Formateur Formateur = _context.Formateur.Where(p => p.FormateurId == Id).FirstOrDefault();
            return View(Formateur);
        }
        [HttpGet]
        public IActionResult Edit(int Id)
        {
            ViewData["Title"] = "Gestion des formations";
            ViewData["second_title"] = "Formateurs >  Modifier un Formateur";
            Formateur Formateur = _context.Formateur.Where(p => p.FormateurId == Id).FirstOrDefault();
            return View(Formateur);
        }
        [HttpPost]
        public IActionResult Edit(Formateur formateur)
        {
            ViewData["Title"] = "Gestion des formations";
            ViewData["second_title"] = "Formateurs >  Modifier un Formateur";
            _context.Attach(formateur);
            _context.Entry(formateur).State = EntityState.Modified;
            _context.SaveChanges();
            return RedirectToAction("Index");
        }
        [HttpGet]
        public async Task<IActionResult> DeleteAsync(int? id)
        {
            ViewData["Title"] = "Gestion des formations";
            ViewData["second_title"] = "Formations >  modifier Formation";
            var formateur = await _context.Formateur.FindAsync(id);
            _context.Formateur.Remove(formateur);
            await _context.SaveChangesAsync();
            return RedirectToAction("index");

        }
        [HttpGet]
        public ActionResult Create()
        {
            Formateur formateur = new Formateur();
            ViewData["Title"] = "Gestion des formations";
            ViewData["second_title"] = "Formateurs >  Nouveau Formateur ";
            return View(formateur);
        }

        [HttpPost]
       // [ValidateAntiForgeryToken]
        public ActionResult Create(Formateur formateur)
        {
            ViewData["Title"] = "Gestion des formations";
            ViewData["second_title"] = "Formateurs >  Nouveau Formateur ";
            _context.Attach(formateur);
            _context.Entry(formateur).State = EntityState.Added;
            _context.SaveChanges();
            return RedirectToAction("Index");
        }
       
    }
}
