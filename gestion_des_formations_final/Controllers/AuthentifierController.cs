using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using gestion_des_formations_final.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace gestion_des_formations_final.Controllers
{
    public class AuthentifierController : Controller
    {
        private UserManager<Utilisateur> UserMgr { get; }
        private SignInManager<Utilisateur> SignInMgr { get; }
        public AuthentifierController(UserManager<Utilisateur> userManager, SignInManager<Utilisateur> signInManager)
        {
            UserMgr = userManager;
            SignInMgr = signInManager;
        }
        public IActionResult Index()
        {
            return View();
        }
            [HttpPost]
        public async Task<IActionResult> Log(Utilisateur user)
        {
            try
            {
                ViewData["message"] = "cet utilisateur est prêt à être enregistrer";

            }
            catch (Exception Ex)
            {
                ViewBag.message = Ex.Message;
            }
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Register()
        {
            try
            {
                    Utilisateur user = new Utilisateur();
                    IdentityResult result = await UserMgr.CreateAsync(user);
                    ViewBag.message = "utilisateur crée avec succès";
            }
            catch(Exception Ex)
            {
                ViewBag.message = Ex.Message;
            }
            return View();
        }

    }
}
