using gestion_des_formations_final.Data;
using gestion_des_formations_final.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace gestion_des_formations_final.Controllers
{
    public class FormationController : Controller
    {
        private readonly ApplicationDbContext _context;

        public FormationController(ApplicationDbContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            ViewData["Title"] = "Gestion des formations";
            ViewData["second_title"] = "Nos Formations";

            List<Formation> Formations = _context.Formation.ToList();
            return View(Formations);
        }
        [HttpGet]
        public IActionResult AjouterFormation()
        {
            ViewData["Title"] = "Gestion des formations";
            ViewData["second_title"] = "Formations >  Nouvelle Formation";
            Formation formation = new Formation();
            return View(formation);

        }
        [HttpPost]
        public IActionResult AjouterFormation(Formation formation)
        {
            ViewData["Title"] = "Gestion des formations";
            ViewData["second_title"] = "Formations >  Nouvelle Formation";
            _context.Attach(formation);
            _context.Entry(formation).State = EntityState.Added;
            _context.SaveChanges();
            return RedirectToAction("index");
        }

        public IActionResult Details(int Id)
        {
            ViewData["Title"] = "Gestion des formations";
            ViewData["second_title"] = "Formations >  consulter Formation";
            Formation formation = _context.Formation.Where(p => p.FormationId == Id).FirstOrDefault();

            return View(formation);
        }
        [HttpGet]
        public IActionResult ModifierFormation(int Id)
        {
            ViewData["Title"] = "Gestion des formations";
            ViewData["second_title"] = "Formations >  modifier Formation";
            Formation formation = _context.Formation.Where(p => p.FormationId == Id).FirstOrDefault();

            return View(formation);
        }
        [HttpPost]
        public IActionResult ModifierFormation(Formation formation)
        {
            ViewData["Title"] = "Gestion des formations";
            ViewData["second_title"] = "Formations >  modifier Formation";
            _context.Attach(formation);
            _context.Entry(formation).State = EntityState.Modified;
            _context.SaveChanges();
            return RedirectToAction("index");
        }
       
        public async Task<IActionResult> DeleteAsync(int? id)
        {
            ViewData["Title"] = "Gestion des formations";
            ViewData["second_title"] = "Formations >  modifier Formation";
            var formation = await _context.Formation.FindAsync(id);
            _context.Formation.Remove(formation);
            await _context.SaveChangesAsync();
            return RedirectToAction("index");
           
        }
   


    }
}
