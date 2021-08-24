using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace gestion_des_formations_final.Controllers
{
    public class FormateurController : Controller
    {
        public IActionResult Index()
        {
            ViewData["Title"] = "Gestion des formations";
            ViewData["second_title"] = "Nos Formateurs";
            return View(ViewData);

        }
        public IActionResult Mesformateurs()
        {
            ViewData["Title"] = "Gestion des formations";
            ViewData["second_title"] = "Nos Formateurs";
            return View(ViewData);
        }
    }
}
