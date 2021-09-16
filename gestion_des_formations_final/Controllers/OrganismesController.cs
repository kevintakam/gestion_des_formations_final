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
    public class OrganismesController : Controller
    {
        private readonly ApplicationDbContext _context;

        public OrganismesController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Organismes
        public async Task<IActionResult> Index()
        {
            ViewData["Title"] = "Gestion des formations";
            ViewData["second_title"] = "Organismes";
            return View(await _context.Organisme.ToListAsync());
        }

        // GET: Organismes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var organisme = await _context.Organisme
                .FirstOrDefaultAsync(m => m.OrganismeId == id);
            if (organisme == null)
            {
                return NotFound();
            }

            return View(organisme);
        }

        // GET: Organismes/Create
        public IActionResult Create()
        {
            ViewData["Title"] = "Gestion des formations";
            ViewData["second_title"] = "Organismes";
            return View();
        }

        // POST: Organismes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Organisme organisme)
        {
            ViewData["Title"] = "Gestion des formations";
            ViewData["second_title"] = "Organisme";
            if (ModelState.IsValid)
            {
                if (OrganismeExist(organisme.Designation))
                {
                    ViewData["message"] = "cet organisme existe déjà !";
                    return View(organisme);
                }
                else
                {
                    organisme.DateAjout = DateTime.Now;
                    organisme.DateModif = DateTime.Now;
                    _context.Add(organisme);
                    await _context.SaveChangesAsync();
                    return RedirectToAction(nameof(Index));
                }
            }
            return View(organisme);
        }

        // GET: Organismes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var organisme = await _context.Organisme.FindAsync(id);
            if (organisme == null)
            {
                return NotFound();
            }
            return View(organisme);
        }

        // POST: Organismes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id,  Organisme organisme)
        {
            ViewData["Title"] = "Gestion des formations";
            ViewData["second_title"] = "Organismes";
            if (id != organisme.OrganismeId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    organisme.DateModif = DateTime.Now;
                    _context.Update(organisme);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!OrganismeExists(organisme.OrganismeId))
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
            return View(organisme);
        }

        // GET: Organismes/Delete/5
        /* public async Task<IActionResult> Delete(int? id)
         {
             ViewData["Title"] = "Gestion des formations";
             ViewData["second_title"] = "Organisme";
             if (id == null)
             {
                 return NotFound();
             }

             var organisme = await _context.Organisme
                 .FirstOrDefaultAsync(m => m.OrganismeId == id);
             if (organisme == null)
             {
                 return NotFound();
             }

             return View(organisme);
         }*/

        // POST: Organismes/Delete/5
        /*  [HttpPost, ActionName("Delete")]
         [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
         {
             var organisme = await _context.Organisme.FindAsync(id);
             _context.Organisme.Remove(organisme);
             await _context.SaveChangesAsync();
             return RedirectToAction(nameof(Index));
         }*/
        //cette fonction permet de supprimer une formation de la base de donnée
        public async Task<IActionResult> DeleteAsync(int? id)
        {
            ViewData["Title"] = "Gestion des formations";
            ViewData["second_title"] = "Organismes";
            var organisme = await _context.Organisme.FindAsync(id);
            _context.Organisme.Remove(organisme);
            await _context.SaveChangesAsync();
            return RedirectToAction("index");

        }
        private bool OrganismeExists(int id)
        {
            return _context.Organisme.Any(e => e.OrganismeId == id);
        }
        private bool OrganismeExist(string designation)
        {
            return _context.Organisme.Any(e => e.Designation == designation);
        }
    }
}
