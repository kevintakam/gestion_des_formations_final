using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace gestion_des_formations_final.Controllers
{
    public class FormationController : Controller
    {
        public IActionResult Index()
        {
            ViewData["Title"] = "Gestion des formations";
            ViewData["second_title"] = "Nos Formations";
            return View(ViewData);
        }
        public IActionResult Mesformations()
        {
            ViewData["Title"] = "Gestion des formations";
            ViewData["second_title"] = "Nos Formations";
            return View(ViewData);
        }
    }
}
