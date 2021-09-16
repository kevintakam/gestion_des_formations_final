using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using gestion_des_formations_final.Data;
using gestion_des_formations_final.Models;
using System.IO;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Hosting.Internal;

namespace gestion_des_formations_final.Controllers
{
    public class DocumentsController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly IWebHostEnvironment _env;
        public DocumentsController(ApplicationDbContext context, IWebHostEnvironment env)
        {
            _context = context;
            _env = env;
        }

        // GET: Documents
        public async Task<IActionResult> Index()
        {
            ViewData["Title"] = "Gestion des formations";
            ViewData["second_title"] = "Documents";
            var applicationDbContext = _context.Document.Include(d => d.Session).ThenInclude(e => e.Formation).Include(d => d.TypeDocument);
            return View(await applicationDbContext.ToListAsync());
        }

        //GET: Importer un document
        public async Task<ActionResult> ImporterDocumentAsync(int? id)
        {
            ViewData["Title"] = "Gestion des formations";
            ViewData["second_title"] = "Documents > Nouveau Document";
            DocumentsVm documentsvm = new DocumentsVm();
            var e = _context.Session.Include(f => f.Formation).Where(s => s.Statut == "planifié");
            var typedocument = await _context.TypeDocument.FindAsync(id);
            documentsvm.TypeDocumentId = typedocument.TypeDocumentId;
            ViewData["sessions"] = new SelectList(e, "SessionId", "Formation.Intitule");
            ViewData["TypeDocumentId"] = new SelectList(_context.TypeDocument, "TypeDocumentId", "Intitule",typedocument.TypeDocumentId);
           
            return View(documentsvm);
        }

        //GET: Importer un document
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult ImporterDocument(DocumentsVm documentsvm)
        {
            ViewData["Title"] = "Gestion des formations";
            ViewData["second_title"] = "Documents";
            try
            {
                if (documentsvm.Nom == null)
                {
                    documentsvm.Nom = "";
                }

                Document Document = new Document()
                {
                    Nom = documentsvm.Nom,
                    SessionId = documentsvm.SessionId,
                    TypeDocumentId = documentsvm.TypeDocumentId,
                    DateAjout = DateTime.Now,
                    DateModif = DateTime.Now
                };
                if (documentsvm.Contenu != null)
                {
                    Document.Contenu = FileUpload(documentsvm.Contenu, Document.Nom);
                    _context.Document.Add(Document);
                    _context.SaveChanges();
                }
                return RedirectToAction(nameof(Index));

            }

            catch (Exception)
            {
                return View();
            }
        }
        public string FileUpload(IFormFile file, string nom)
        {

            string ext = Path.GetExtension(file.FileName);
            if (ext.ToLower() == ".pdf" || ext.ToLower() != ".doc" || ext.ToLower() != ".docx")
            {
                var newName = "Doc_" + new DateTimeOffset(DateTime.UtcNow).ToUnixTimeMilliseconds().ToString() + "_" + nom.ToUpper() + ext;
                var filePath = Path.Combine(_env.WebRootPath, "DOCUMENTS", newName.ToString());

                using (var filestream = new FileStream(filePath, FileMode.Create))
                {
                    file.CopyTo(filestream);
                }
                return newName.ToString();
            }

            return "";
        }

        // GET: Documents/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
          //  var document = _context.Document.Include(d => d.Session).ThenInclude(e => e.Formation).Include(d => d.TypeDocument).FirstOrDefaultAsync();
            var document = await _context.Document
                .Include(d => d.Session)
                .ThenInclude(f => f.Formation)
                .Include(d => d.TypeDocument)
                .FirstOrDefaultAsync(m => m.DocumentId == id);
            if (document == null)
            {
                return NotFound();
            }

            return View(document);
        }

        // GET: Documents/Create
        public IActionResult Create()
        {
            ViewData["SessionId"] = new SelectList(_context.Session, "SessionId", "SessionId");
            ViewData["TypeDocumentId"] = new SelectList(_context.TypeDocument, "TypeDocumentId", "TypeDocumentId");
            return View();
        }

        // POST: Documents/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("DocumentId,Nom,Contenu,TypeDocumentId,SessionId")] Document document)
        {
            if (ModelState.IsValid)
            {
                _context.Add(document);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["SessionId"] = new SelectList(_context.Session, "SessionId", "SessionId", document.SessionId);
            ViewData["TypeDocumentId"] = new SelectList(_context.TypeDocument, "TypeDocumentId", "TypeDocumentId", document.TypeDocumentId);
            return View(document);
        }

        // GET: Documents/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var document = await _context.Document.FindAsync(id);
            if (document == null)
            {
                return NotFound();
            }
            ViewData["Title"] = "Gestion des formations";
            ViewData["second_title"] = "Documents > Modifier Document";

            var e = _context.Session.Include(f => f.Formation).Where(s => s.Statut == "planifié");

            ViewData["sessions"] = new SelectList(e, "SessionId", "Formation.Intitule");
            ViewData["TypeDocumentId"] = new SelectList(_context.TypeDocument, "TypeDocumentId", "Intitule");
            DocumentsVm dvm = new DocumentsVm()
            {
                DocumentId = document.DocumentId,
                TypeDocumentId = document.TypeDocumentId,
                Nom = document.Nom,
                SessionId = document.SessionId
            };
            return View(dvm);
        }

        // POST: Documents/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, DocumentsVm dvm)
        {
            if (id != dvm.DocumentId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {

                    var oldContent = await _context.Document.FirstOrDefaultAsync(d => d.DocumentId == id);
                    Document doc = oldContent;
                    doc.DateModif = DateTime.Now;
                    doc.Nom = dvm.Nom;
                    doc.SessionId = dvm.SessionId;
                    doc.TypeDocumentId = dvm.TypeDocumentId;

                    if (dvm.Contenu != null)
                    {
                        doc.Contenu = FileUpload(dvm.Contenu, dvm.Nom);
                    }

                    _context.Update(doc);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!DocumentExists(dvm.DocumentId))
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
            ViewData["SessionId"] = new SelectList(_context.Session, "SessionId", "SessionId", dvm.SessionId);
            ViewData["TypeDocumentId"] = new SelectList(_context.TypeDocument, "TypeDocumentId", "TypeDocumentId", dvm.TypeDocumentId);
            return View(dvm);
        }

        // GET: Documents/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var document = await _context.Document
                .Include(d => d.Session)
                .Include(d => d.TypeDocument)
                .FirstOrDefaultAsync(m => m.DocumentId == id);
            if (document == null)
            {
                return NotFound();
            }

            return View(document);
        }

        // POST: Documents/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var document = await _context.Document.FindAsync(id);
            _context.Document.Remove(document);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool DocumentExists(int id)
        {
            return _context.Document.Any(e => e.DocumentId == id);
        }
    }
}
