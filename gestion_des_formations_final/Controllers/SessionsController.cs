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
    public class SessionsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public SessionsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Sessions
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.Session.Include(s => s.Formation).Include(s => s.Salle);
            ViewData["Title"] = "Gestion des formations";
            ViewData["second_title"] = "Sessions";
            return View(await applicationDbContext.ToListAsync());
        }
        public async Task<IActionResult> SessionsEnCours()
        {
            var applicationDbContext = _context.Session.Include(s => s.Formation).Include(s => s.Salle);
            ViewData["Title"] = "Gestion des formations";
            ViewData["second_title"] = "Sessions";
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: Sessions/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            SessionsVm sessionvm = new SessionsVm();

            var session = await _context.Session.FindAsync(id);
            if (session == null)
            {
                return NotFound();
            }
            // info  a continuer pour la sessionvm
            sessionvm.SessionId = session.SessionId;
            sessionvm.FormationId = session.FormationId;
            sessionvm.DateDebut = session.DateDebut;
            sessionvm.DateFin = session.DateFin;
            sessionvm.SalleId = session.SalleId;
            sessionvm.Statut = session.Statut;
            sessionvm.DateAjout = session.DateAjout;
            sessionvm.DateModif = session.DateModif;
            #region recupérer les formateurs
            var formateur = _context.FormateurSessions.Include(i => i.Formateur).Where(s => s.SessionId == id).ToList();
            sessionvm.FormateurId = formateur[0].FormateurId;
            #endregion
            //les particîpants
            var parti = _context.ParticipantSessions.Include(i => i.Participant).Where(s => s.SessionId == id).ToList();
            
            foreach (var item in parti)
            {
                sessionvm.ParticipantSessions.Add(item);
            }
            foreach (var item in formateur)
            {
                sessionvm.FormateurSessions.Add(item);
            }
            ViewData["Title"] = "Gestion des formations";
            ViewData["second_title"] = "Sessions";
            ViewData["FormateurId"] = _context.FormateurSessions.Include(i => i.Formateur).Where(i => i.FormateurId == sessionvm.FormateurId).FirstOrDefault();
            ViewData["session"] = _context.Session.Include(i => i.Formation).Where(i => i.FormationId == sessionvm.FormationId).FirstOrDefault();
            ViewData["participants"]= _context.ParticipantSessions.Include(i => i.Participant).Where(s => s.SessionId == id).Count();
            ViewData["SalleId"] = _context.Session.Include(i => i.Salle).Where(i => i.SalleId == sessionvm.SalleId).FirstOrDefault();
            return View(sessionvm);
        }

        // GET: Sessions/Create
        public IActionResult Create()
        {
            ViewData["Title"] = "Gestion des formations";
            ViewData["second_title"] = "Sessions";
            ViewData["FormationId"] = new SelectList(_context.Formation, "FormationId", "Intitule");
            ViewData["SalleId"] = new SelectList(_context.Salle, "SalleId", "Designation");
            return View();
        }

        // POST: Sessions/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("SessionId,Intitule,DateDebut,DateFin,Statut,Evaluation,Examen,SalleId,FormationId")] Session session)
        {
            if (ModelState.IsValid)
            {
                _context.Add(session);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["Title"] = "Gestion des formations";
            ViewData["second_title"] = "Sessions";
            ViewData["FormationId"] = new SelectList(_context.Formation, "FormationId", "Intitule", session.FormationId);
            ViewData["SalleId"] = new SelectList(_context.Salle, "SalleId", "SalleId", session.SalleId);
            return View(session);
        }
        public IActionResult AjouterUneSession()
        {
            SessionsVm allsessions = new SessionsVm();


            allsessions.ParticipantSessions = new List<ParticipantSession>();

            for (int i = 0; i <= 9; i++) allsessions.ParticipantSessions.Add(new ParticipantSession());
            ViewData["Title"] = "Gestion des formations";
            ViewData["second_title"] = "Sessions";
            ViewData["FormationId"] = new SelectList(_context.Formation, "FormationId", "Intitule");
            ViewData["SalleId"] = new SelectList(_context.Salle, "SalleId", "Designation");
            ViewData["FormateurId"] = new SelectList(_context.FormateurP, "FormateurId", "Nom");
            return View(allsessions);
        }

        // POST: Sessions/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> AjouterUneSession(SessionsVm allsession)
        {

            try {
                #region ajout de la session
                Session session = new Session()
                {
                    DateDebut = allsession.DateDebut,
                    DateFin = allsession.DateFin,
                    FormationId = allsession.FormationId,
                    Statut = allsession.Statut,
                    SalleId = allsession.SalleId,
                    DateAjout = DateTime.Now,
                    DateModif = DateTime.Now

                };
                _context.Session.Add(session);
                _context.SaveChanges();
                #endregion

                #region ajout des participants
                #region ajout du formateur
                FormateurSession formateursession = new FormateurSession()
                {
                    FormateurId = allsession.FormateurId,
                    SessionId = session.SessionId
                };
                _context.FormateurSessions.Add(formateursession);
                _context.SaveChanges();
                #endregion
                /*
                Participant participant = new Participant()
                {
                    Nom = allsession.Nom,
                    Prenom = allsession.Prenom,
                    Email = allsession.Email,
                    Telephone = allsession.Telephone,
                    Adresse = allsession.Adresse,
                    Statut = allsession.StatutP
                };
                _context.Participant.Add(participant);

                */
                var participants = new List<Participant>();
                foreach (var item in allsession.ParticipantSessions)
                {
                    if (item.Participant.Nom != null)
                    {
                        participants.Add(item.Participant);
                    }


                }

                if (participants.Count != 0) {

                    _context.Participant.AddRange(participants);
                    _context.SaveChanges();

                    foreach (var item in allsession.ParticipantSessions)
                    {
                        if (item.Participant.Nom != null)
                        {
                            _context.ParticipantSessions.Add(new ParticipantSession
                            {
                                SessionId = session.SessionId,
                                ParticipantId = item.Participant.ParticipantId
                            });
                        }

                    }
                    _context.SaveChanges();

                }
                #endregion

                /////////////////////////
                await _context.SaveChangesAsync();
                if (session.Statut == "en cours")
                {
                    return RedirectToAction(nameof(SessionsEnCours));
                }
                else
                {
                    return RedirectToAction(nameof(Index));
                }

            
            }
            catch 
                {
                ViewData["Title"] = "Gestion des formations";
                ViewData["second_title"] = "Sessions";
                ViewData["FormationId"] = new SelectList(_context.Formation, "FormationId", "Intitule");
                ViewData["SalleId"] = new SelectList(_context.Salle, "SalleId", "Designation");
                ViewData["FormateurId"] = new SelectList(_context.FormateurP, "FormateurId", "Nom");
                return View(allsession);
            }
           

        }

        // GET: Sessions/Edit/5
        public async Task<IActionResult> ModifierUneSession(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            SessionsVm sessionvm = new SessionsVm();

            var session = await _context.Session.FindAsync(id);
            if (session == null)
            {
                return NotFound();
            }
            // info  a continuer pour la sessionvm
            sessionvm.SessionId = session.SessionId;
            sessionvm.FormationId = session.FormationId;
            sessionvm.DateDebut = session.DateDebut;
            sessionvm.DateFin = session.DateFin;
            sessionvm.SalleId = session.SalleId;
            sessionvm.Statut = session.Statut;
            sessionvm.DateAjout = session.DateAjout;
            sessionvm.DateModif = session.DateModif;
            #region recupérer les formateurs
            var formateur = _context.FormateurSessions.Include(i => i.Formateur).Where(s => s.SessionId == id).ToList();
            sessionvm.FormateurId = formateur[0].FormateurId;
            #endregion
            //les particîpants
            var parti = _context.ParticipantSessions.Include(i => i.Participant).Where(s => s.SessionId == id).ToList();
            var nbr = _context.ParticipantSessions.Include(i => i.Participant).Where(s => s.ParticipantId != 0).Count();
            foreach (var item in parti)
            {
                
                    if (item.Participant.Nom != null)
                    {
                        sessionvm.ParticipantSessions.Add(item);
                    }
                    else
                    {
                    for (int i = 0; i <= 9 - nbr; i++)
                    {
                        sessionvm.ParticipantSessions.Add(new ParticipantSession());
                    };
                    }

               
            }
            foreach (var item in formateur)
            {
                sessionvm.FormateurSessions.Add(item);
            }

            ViewData["Title"] = "Gestion des formations";
            ViewData["second_title"] = "Sessions";
            ViewData["FormateurId"] = new SelectList(_context.FormateurP, "FormateurId", "Nom", sessionvm.FormateurId);
            ViewData["FormationId"] = new SelectList(_context.Formation, "FormationId", "Intitule", sessionvm.FormationId);
            ViewData["SalleId"] = new SelectList(_context.Salle, "SalleId", "Designation", sessionvm.SalleId);
           
           // SessionsVm allsessions = new SessionsVm();
           // for (int i = 0; i <= 9 - nbr; i++) sessionvm.ParticipantSessions.Add(new ParticipantSession());
            return View(sessionvm);
        }

        // POST: Sessions/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> ModifierUneSession(int id,  SessionsVm sessionvm)
        {
            if (id != sessionvm.SessionId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    var session = await _context.Session.FindAsync(id);
                    // info  a continuer pour la session
                    session.FormationId = sessionvm.FormationId;
                    session.DateDebut = sessionvm.DateDebut;
                    session.DateFin = sessionvm.DateFin;
                    session.SalleId = sessionvm.SalleId;
                    session.Statut = sessionvm.Statut;
                    session.DateModif = DateTime.Now;
                    _context.Session.Update(session);
                    _context.SaveChanges();
                    var formateurs_session = await _context.FormateurSessions.Where(t => t.SessionId == id).ToListAsync();
                    _context.FormateurSessions.RemoveRange(formateurs_session);
                    var nouveau_formateurs_session = new FormateurSession()
                    {
                        SessionId = session.SessionId,
                        FormateurId = sessionvm.FormateurId
                    };
                    _context.FormateurSessions.Add(nouveau_formateurs_session);

                    var parti = await  _context.ParticipantSessions.Include(i => i.Participant).Where(w => w.SessionId == id).ToListAsync();
                    var participants = new List<Participant>();
                    foreach (var item in parti)
                    {
                        participants.Add(item.Participant);
                    }

                    _context.ParticipantSessions.RemoveRange(parti);
                    _context.Participant.RemoveRange(participants);
                    _context.SaveChanges();

                    if (participants.Count != 0)
                    {
                        var participantsNew = new List<Participant>();

                        foreach (var item in sessionvm.ParticipantSessions)
                        {
                            //item.ParticipantId = '\0';

                                participantsNew.Add(item.Participant);
                            
                        }
                        _context.Participant.AddRange(participantsNew);
                        _context.SaveChanges();

                        foreach (var item in sessionvm.ParticipantSessions)
                        {

                                _context.ParticipantSessions.Add(new ParticipantSession
                                {
                                    SessionId = session.SessionId,
                                    ParticipantId = item.Participant.ParticipantId
                                });
                            
                        }

                        _context.SaveChanges();

                    }
                    /////////////////////////
                    await _context.SaveChangesAsync();
                    if (session.Statut == "en cours")
                    {
                        return RedirectToAction(nameof(SessionsEnCours));
                    }
                    else
                    {
                        return RedirectToAction(nameof(Index));
                    }
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!SessionExists(sessionvm.SessionId))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }

            }
            ViewData["Title"] = "Gestion des formations";
            ViewData["second_title"] = "Sessions";
            ViewData["FormateurId"] = new SelectList(_context.FormateurP, "FormateurId", "Intitule", sessionvm.FormateurId);
            ViewData["FormationId"] = new SelectList(_context.Formation, "FormationId", "Intitule", sessionvm.FormationId);
            ViewData["SalleId"] = new SelectList(_context.Salle, "SalleId", "SalleId", sessionvm.SalleId);
            return View(sessionvm);
        }

        // GET: Sessions/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var session = await _context.Session
                .Include(s => s.Formation)
                .Include(s => s.Salle)
                .FirstOrDefaultAsync(m => m.SessionId == id);
            if (session == null)
            {
                return NotFound();
            }

            return View(session);
        }

        // POST: Sessions/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var session = await _context.Session.FindAsync(id);
            _context.Session.Remove(session);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool SessionExists(int id)
        {
            return _context.Session.Any(e => e.SessionId == id);
        }
    }
}
