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
    public class TypeDocumentsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public TypeDocumentsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: TypeDocuments
        public async Task<IActionResult> Index()
        {
            ViewData["Title"] = "Gestion des formations";
            ViewData["second_title"] = "Documents";
            ViewData["first_title"] = "Type document";
            ViewData["title_modal"] = "détaillé";
            return View(await _context.TypeDocument.ToListAsync());
        }
        public async Task<IActionResult> ChoixModeleDocument()
        {
            ViewData["Title"] = "Gestion des formations";
            ViewData["second_title"] = "Documents";
            return View(await _context.TypeDocument.ToListAsync());
        }

        // GET: TypeDocuments/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            ViewData["Title"] = "Gestion des formations";
            ViewData["second_title"] = "Documents";
            if (id == null)
            {
                return NotFound();
            }

            var typeDocument = await _context.TypeDocument
                .FirstOrDefaultAsync(m => m.TypeDocumentId == id);
            if (typeDocument == null)
            {
                return NotFound();
            }

            return View(typeDocument);
        }

        // GET: TypeDocuments/Create
        public IActionResult AjouterUnTypeDocument()
        {
            ViewData["Title"] = "Gestion des formations";
            ViewData["second_title"] = "Documents";
            return View();
        }

        // POST: TypeDocuments/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> AjouterUnTypeDocument([Bind("TypeDocumentId,Intitule")] TypeDocument typeDocument)
        {
            ViewData["Title"] = "Gestion des formations";
            ViewData["second_title"] = "Documents";
            if (ModelState.IsValid)
            {
                if (TypedocumentExist(typeDocument.Intitule))
                {
                    ViewData["message"] = "Le type de document " + typeDocument.Intitule + " a déjà été enregistrée !";
                    return View(typeDocument);
                }
                else
                {
                    typeDocument.DateAjout = DateTime.Now;
                    typeDocument.DateModif = DateTime.Now;
                    _context.Add(typeDocument);
                    await _context.SaveChangesAsync();
                    return RedirectToAction(nameof(Index));
                }
            }
            return View(typeDocument);
        }

        // GET: TypeDocuments/Edit/5
        public async Task<IActionResult> ModifierUnTypeDocument(int? id)
        {
            ViewData["Title"] = "Gestion des formations";
            ViewData["second_title"] = "Documents";
            if (id == null)
            {
                return NotFound();
            }

            var typeDocument = await _context.TypeDocument.FindAsync(id);
            if (typeDocument == null)
            {
                return NotFound();
            }
            return View(typeDocument);
        }

        // POST: TypeDocuments/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> ModifierUnTypeDocument(int id, [Bind("TypeDocumentId,Intitule,Description")] TypeDocument typeDocument)
        {
            ViewData["Title"] = "Gestion des formations";
            ViewData["second_title"] = "Documents";
            if (id != typeDocument.TypeDocumentId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    typeDocument.DateModif = DateTime.Now;
                    _context.Update(typeDocument);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TypeDocumentExists(typeDocument.TypeDocumentId))
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
            return View(typeDocument);
        }

        // GET: TypeDocuments/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            ViewData["Title"] = "Gestion des formations";
            ViewData["second_title"] = "Documents";
            if (id == null)
            {
                return NotFound();
            }

            var typeDocument = await _context.TypeDocument
                .FirstOrDefaultAsync(m => m.TypeDocumentId == id);
            if (typeDocument == null)
            {
                return NotFound();
            }

            return View(typeDocument);
        }

        // POST: TypeDocuments/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            ViewData["Title"] = "Gestion des formations";
            ViewData["second_title"] = "Documents";
            var typeDocument = await _context.TypeDocument.FindAsync(id);
            _context.TypeDocument.Remove(typeDocument);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TypeDocumentExists(int id)
        {
            return _context.TypeDocument.Any(e => e.TypeDocumentId == id);
        }
        private bool TypedocumentExist(string Intitule)
        {
            return _context.TypeDocument.Any(e => e.Intitule == Intitule);
        }
    }
}
