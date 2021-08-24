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
            return View();
        }
    }
}
