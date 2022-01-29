using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using gestion_des_formations_final.Data;
using gestion_des_formations_final.Models;

namespace gestion_des_formations_final.Controllers
{
    public class SallesController : Controller
    {
        private readonly ApplicationDbContext _context;

        public SallesController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Salles
        public async Task<IActionResult> Index()
        {
            ViewData["Title"] = "Gestion des formations";
            ViewData["second_title"] = "Salles";
            ViewData["first_title"] = "Salle";
            ViewData["title_modal"] = "détaillée";
            return View(await _context.Salle.ToListAsync());
        }

        // GET: Salles/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var salle = await _context.Salle
                .FirstOrDefaultAsync(m => m.SalleId == id);
            if (salle == null)
            {
                return NotFound();
            }

            return View(salle);
        }

        // GET: Salles/Create
        public IActionResult AjouterUneSalle()
        {
            ViewData["Title"] = "Gestion des formations";
            ViewData["second_title"] = "Salles";

            return View();
        }

        // POST: Salles/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> AjouterUneSalle( Salle salle)
        {
            if (ModelState.IsValid)
            {
                if (SalleExist(salle.Designation,salle.Lieu))
                {
                    ViewData["message"] = "La salle "+salle.Designation+"-"+salle.Lieu+" a déjà été enregistrée !";
                    return View(salle);
                }
                else
                {
                    salle.DateAjout = DateTime.Now;
                    salle.DateModif = DateTime.Now;
                    _context.Add(salle);
                    await _context.SaveChangesAsync();
                    TempData["success"] = "La salle "+salle.Designation+"-"+salle.Lieu+" a été enregistré avec succès !";
                    return RedirectToAction(nameof(Index));
                }

            }
            return View(salle);
        }

        // GET: Salles/Edit/5
        public async Task<IActionResult> ModifierUneSalle(int? id)
        {
            ViewData["Title"] = "Gestion des formations";
            ViewData["second_title"] = "Salles";
            if (id == null)
            {
                return NotFound();
            }

            var salle = await _context.Salle.FindAsync(id);
            if (salle == null)
            {
                return NotFound();
            }
            return View(salle);
        }

        // POST: Salles/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> ModifierUneSalle(int id,  Salle salle)
        {
            ViewData["Title"] = "Gestion des formations";
            ViewData["second_title"] = "Salles";
            if (id != salle.SalleId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    salle.DateModif = DateTime.Now;
                    _context.Update(salle);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!SalleExists(salle.SalleId))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(salle);
        }

        // GET: Salles/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            ViewData["Title"] = "Gestion des formations";
            ViewData["second_title"] = "Salles";
            if (id == null)
            {
                return NotFound();
            }

            var salle = await _context.Salle
                .FirstOrDefaultAsync(m => m.SalleId == id);
            if (salle == null)
            {
                return NotFound();
            }

            return View(salle);
        }

        // POST: Salles/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            ViewData["Title"] = "Gestion des formations";
            ViewData["second_title"] = "Salles";
            var salle = await _context.Salle.FindAsync(id);
            _context.Salle.Remove(salle);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool SalleExists(int id)
        {
            return _context.Salle.Any(e => e.SalleId == id);
        }
        private bool SalleExist(string designation, string lieu)
        {
            return _context.Salle.Any(e => e.Designation == designation && e.Lieu == lieu);
        }
    }
}
