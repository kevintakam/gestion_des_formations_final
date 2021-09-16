using gestion_des_formations_final.Data;
using gestion_des_formations_final.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace gestion_des_formations_final.Controllers
{
    public class HomeController : Controller
    {
        private readonly ApplicationDbContext _context;

        public HomeController(ApplicationDbContext context)
        {
            _context = context;
        }


        public IActionResult Index()
        {
            ViewData["Title"] = "Gestion des formations";
            ViewData["second_title"] = "Tableau de bord";
            ViewData["sessions_encours"] = _context.Session.Where(t => t.Statut == "en cours").Count();
            ViewData["sessions_planifie"] = _context.Session.Where(t => t.Statut == "planifié").Count();
            ViewData["formateursT"] = _context.FormateurT.Where(t => t.Statut == "en cours d'approbation").Count();
            ViewData["formations"] = _context.Formation.Where(t => t.FormationCertifiee == true).Count();
            return View(ViewData);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
