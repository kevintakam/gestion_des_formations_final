﻿using System;
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
    public class EntreprisesController : Controller
    {
        private readonly ApplicationDbContext _context;

        public EntreprisesController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Entreprises
        public async Task<IActionResult> Index()
        {
            ViewData["Title"] = "Gestion des formations";
            ViewData["second_title"] = "Entreprises";
            return View(await _context.Entreprise.ToListAsync());
        }

        // GET: Entreprises/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            ViewData["Title"] = "Gestion des formations";
            ViewData["second_title"] = "Entreprises";
            if (id == null)
            {
                return NotFound();
            }

            var entreprise = await _context.Entreprise
                .FirstOrDefaultAsync(m => m.EntrepriseId == id);
            if (entreprise == null)
            {
                return NotFound();
            }

            return View(entreprise);
        }

        // GET: Entreprises/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Entreprises/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("EntrepriseId,Designation,SecteurActivité,PersonneResponsable,Metier,Siteweb,Telephone,Email,Boitepostale")] Entreprise entreprise)
        {
            ViewData["Title"] = "Gestion des formations";
            ViewData["second_title"] = "Entreprise";
            if (ModelState.IsValid)
            {
                if (EntrepriseExist(entreprise.Designation))
                {
                    ViewData["message"] = "cette entreprise existe déjà !";
                    return View(entreprise);
                }
                else
                {
                    entreprise.DateAjout = DateTime.Now;
                    entreprise.DateModif = DateTime.Now;
                    _context.Add(entreprise);
                    await _context.SaveChangesAsync();
                    return RedirectToAction(nameof(Index));
                }
            }
            return View(entreprise);
        }

        // GET: Entreprises/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            ViewData["Title"] = "Gestion des formations";
            ViewData["second_title"] = "Entreprises";
            if (id == null)
            {
                return NotFound();
            }

            var entreprise = await _context.Entreprise.FindAsync(id);
            if (entreprise == null)
            {
                return NotFound();
            }
            return View(entreprise);
        }

        // POST: Entreprises/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("EntrepriseId,Designation,SecteurActivité,PersonneResponsable,Metier,Siteweb,Telephone,Email,Boitepostale")] Entreprise entreprise)
        {
            ViewData["Title"] = "Gestion des formations";
            ViewData["second_title"] = "Entreprises";
            if (id != entreprise.EntrepriseId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    entreprise.DateModif = DateTime.Now;
                    _context.Update(entreprise);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!EntrepriseExists(entreprise.EntrepriseId))
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
            return View(entreprise);
        }

        // GET: Entreprises/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            ViewData["Title"] = "Gestion des formations";
            ViewData["second_title"] = "Entreprises";
            if (id == null)
            {
                return NotFound();
            }

            var entreprise = await _context.Entreprise
                .FirstOrDefaultAsync(m => m.EntrepriseId == id);
            if (entreprise == null)
            {
                return NotFound();
            }

            return View(entreprise);
        }

        // POST: Entreprises/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            ViewData["Title"] = "Gestion des formations";
            ViewData["second_title"] = "Entreprises";
            var entreprise = await _context.Entreprise.FindAsync(id);
            _context.Entreprise.Remove(entreprise);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool EntrepriseExists(int id)
        {
            return _context.Entreprise.Any(e => e.EntrepriseId == id);
        }
        private bool EntrepriseExist(string designation)
        {
            return _context.Organisme.Any(e => e.Designation == designation);
        }
    }
}
