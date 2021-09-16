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
    public class CertificationsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public CertificationsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Certifications
        public async Task<IActionResult> Index()
        {
            ViewData["Title"] = "Gestion des formations";
            ViewData["second_title"] = "Certifications";
            var applicationDbContext = _context.Certification.Include(c => c.Organisme);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: Certifications/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var certification = await _context.Certification
                .Include(c => c.Organisme)
                .FirstOrDefaultAsync(m => m.CertificationId == id);
            if (certification == null)
            {
                return NotFound();
            }

            return View(certification);
        }

        // GET: Certifications/Create
        public IActionResult Create()
        {
            ViewData["Title"] = "Gestion des formations";
            ViewData["second_title"] = "Certifications";
            ViewData["OrganismeId"] = new SelectList(_context.Organisme, "OrganismeId", "Designation");
            return View();
        }

        // POST: Certifications/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("CertificationId,Designation,OrganismeId,Description")] Certification certification)
        {
            if (ModelState.IsValid)
            {
                if (CertificationExist(certification.Designation, certification.OrganismeId))
                {
                    ViewData["message"] = "cette salle existe déjà !";
                    return View(certification);
                }
                else
                {
                    certification.DateAjout = DateTime.Now;
                    certification.DateModif = DateTime.Now;
                    _context.Add(certification);
                    await _context.SaveChangesAsync();
                    return RedirectToAction(nameof(Index));
                }
            }
            ViewData["OrganismeId"] = new SelectList(_context.Organisme, "OrganismeId", "Designation", certification.OrganismeId);
            return View(certification);
        }

        // GET: Certifications/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            ViewData["Title"] = "Gestion des formations";
            ViewData["second_title"] = "Certifications";
            if (id == null)
            {
                return NotFound();
            }

            var certification = await _context.Certification.FindAsync(id);
            if (certification == null)
            {
                return NotFound();
            }
            ViewData["OrganismeId"] = new SelectList(_context.Organisme, "OrganismeId", "Designation", certification.OrganismeId);
            return View(certification);
        }

        // POST: Certifications/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("CertificationId,Designation,OrganismeId,Description")] Certification certification)
        {
            ViewData["Title"] = "Gestion des formations";
            ViewData["second_title"] = "Certifications";
            if (id != certification.CertificationId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    certification.DateModif = DateTime.Now;
                    _context.Update(certification);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CertificationExists(certification.CertificationId))
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
            ViewData["OrganismeId"] = new SelectList(_context.Organisme, "OrganismeId", "Designation", certification.OrganismeId);
            return View(certification);
        }

        // GET: Certifications/Delete/5
        /*  public async Task<IActionResult> Delete(int? id)
          {
              ViewData["Title"] = "Gestion des formations";
              ViewData["second_title"] = "Certification";
              if (id == null)
              {
                  return NotFound();
              }

              var certification = await _context.Certification
                  .Include(c => c.Organisme)
                  .FirstOrDefaultAsync(m => m.CertificationId == id);
              if (certification == null)
              {
                  return NotFound();
              }

              return View(certification);
          }*/

        // POST: Certifications/Delete/5
        /* [HttpPost, ActionName("Delete")]
         [ValidateAntiForgeryToken]
         public async Task<IActionResult> DeleteConfirmed(int id)
         {
             ViewData["Title"] = "Gestion des formations";
             ViewData["second_title"] = "Certification";
             var certification = await _context.Certification.FindAsync(id);
             _context.Certification.Remove(certification);
             await _context.SaveChangesAsync();
             return RedirectToAction(nameof(Index));
         }*/
        public async Task<IActionResult> DeleteAsync(int? id)
        {
            ViewData["Title"] = "Gestion des formations";
            ViewData["second_title"] = "Certification";
            var certification = await _context.Certification.FindAsync(id);
            _context.Certification.Remove(certification);
            await _context.SaveChangesAsync();
            return RedirectToAction("index");

        }

        private bool CertificationExists(int id)
        {
            return _context.Certification.Any(e => e.CertificationId == id);
        }
        private bool CertificationExist(string designation, int organisme)
        {
            return _context.Certification.Any(e => e.Designation == designation && e.OrganismeId == organisme);
        }
    }
}
