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
        // cette fonction permet de récupérer la liste des formations et de les afficher sur la vue Index du dossier vue de formation
        public IActionResult Index()
        {
            ViewData["Title"] = "Gestion des formations";
            ViewData["second_title"] = "Formations";
            ViewData["first_title"] = "Formation";
            ViewData["title_modal"] = " détaillée";

            List<Formation> Formations = _context.Formation.ToList();
            return View(Formations);
        }
        //cette fonction permet d'aller vers le formulaire d'ajout d'une nouvelle formation 
        [HttpGet]
        public IActionResult AjouterFormation()
        {
            ViewData["Title"] = "Gestion des formations";
            ViewData["second_title"] = "Formations >  Nouvelle Formation";
            Formation formation = new Formation();
            return View(formation);

        }
        //cette formation permet de récupérer les données et les envoyer vers l'entité de formation
        [HttpPost]
        public async Task<IActionResult> AjouterFormation(Formation formation)
        {
            ViewData["Title"] = "Gestion des formations";
            ViewData["second_title"] = "Formations ";
            if (ModelState.IsValid)
            {
                if (FormationExist(formation.Intitule))
                {
                    ViewData["message"] = "La formation " + formation.Intitule + " a déjà été enregistrée !";
                    return View(formation);
                }
                else
                {
                    formation.DateAjout = DateTime.Now;
                    formation.DateModif = DateTime.Now;
                    _context.Add(formation);
                    await _context.SaveChangesAsync();
                    ViewData["message"] = "votre formation a été crée avec succèss";
                    return RedirectToAction(nameof(Index));
                }
            }
            return View(formation);
        }

      /*  public IActionResult Details(int Id)
        {
            ViewData["Title"] = "Gestion des formations";
            ViewData["second_title"] = "Formations >  consulter Formation";
            Formation formation = _context.Formation.Where(p => p.FormationId == Id).FirstOrDefault();

            return PartialView("Details", formation);
        }*/
        // GET: Sessions/Details/5
        //cette fonction permet d'afficher les détails d'une formation précise 
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var formation = await _context.Formation.FirstOrDefaultAsync(m => m.FormationId == id);
            if (formation == null)
            {
                return NotFound();
            }

            return View(formation);
        }
        //cette fonction nous dirige vers le formulaire de modification avec les données de la formation à modifier
        [HttpGet]
        public IActionResult ModifierFormation(int Id)
        {
            ViewData["Title"] = "Gestion des formations";
            ViewData["second_title"] = "Formations";
            Formation formation = _context.Formation.Where(p => p.FormationId == Id).FirstOrDefault();

            return View(formation);
        }
        //cette fonction permet de modifier les données de la formation 
        [HttpPost]
        public IActionResult ModifierFormation(Formation formation)
        {
            ViewData["Title"] = "Gestion des formations";
            ViewData["second_title"] = "Formations";
            formation.DateModif = DateTime.Now;
            _context.Attach(formation);
            _context.Entry(formation).State = EntityState.Modified;
            _context.SaveChanges();
            return RedirectToAction("index");
        }
       //cette fonction permet de supprimer une formation de la base de donnée
        public async Task<IActionResult> DeleteAsync(int? id)
        {
            ViewData["Title"] = "Gestion des formations";
            ViewData["second_title"] = "Formations";
            var formation = await _context.Formation.FindAsync(id);
            _context.Formation.Remove(formation);
            await _context.SaveChangesAsync();
            return RedirectToAction("index");
           
        }
        private bool FormationExist(string intitule)
        {
            return _context.Formation.Any(e => e.Intitule == intitule);
        }

    }
}
