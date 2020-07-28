using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web.Mvc;
using OnlineBanking.DAL;
using OnlineBanking.Models;
using static System.String;
using PagedList;
using System.Data.Entity.Infrastructure;
using System.Threading.Tasks;
using OnlineBanking.ViewModels;

namespace OnlineBanking.Controllers
{
    public class KundenController : Controller
    {
        private BankingContext db = new BankingContext();

        // GET: Kunden
        public ViewResult Index(string sortOrder, string currentFilter, string searchString, int? page)
        {
            ViewBag.CurrentSort = sortOrder;
            ViewBag.NameSortParm = IsNullOrEmpty(sortOrder) ? "name_desc" : "";
            ViewBag.VornameSortParm = sortOrder == "Vorname" ? "vorname_desc" : "Vorname";
            ViewBag.DateSortParm = sortOrder == "Date" ? "date_desc" : "Date";

            if (searchString != null)
            {
                page = 1;
            }
            else
            {
                searchString = currentFilter;
            }

            ViewBag.CurrentFilter = searchString;

            var kunden = from k in db.Kunde
                select k;
            if (!IsNullOrEmpty(searchString))
            {
                kunden = kunden.Where(k => k.Nachname.Contains(searchString)
                                               || k.Vorname.Contains(searchString));
            }
            switch (sortOrder)
            {
                case "name_desc":
                    kunden = kunden.OrderByDescending(k => k.Nachname);
                    break;
                case "Date":
                    kunden = kunden.OrderBy(k => k.Geburtsdatum);
                    break;
                case "date_desc":
                    kunden = kunden.OrderByDescending(k => k.Geburtsdatum);
                    break;
                case "Vorname":
                    kunden = kunden.OrderBy(k => k.Vorname);
                    break;
                case "vorname_desc":
                    kunden = kunden.OrderByDescending(k => k.Vorname);
                    break;
                default:
                    kunden = kunden.OrderBy(k => k.Nachname);
                    break;
            }
            int pageSize = 3;
            int pageNumber = (page ?? 1);
            return View(kunden.ToPagedList(pageNumber, pageSize));
        }

        // GET: Kunden/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            Kunde kunde = db.Kunde
                .Include(x => x.Konten.Select(k => k.KontoTyp))
                .Select(x => x)
                .Single(x => x.Id == id);

            var test =
                from k in db.Kunde
                where k.Id == id
                select k;

            var asdf = test.ToList();

            // Kunde kunde = db.Kunde.Find(id);
            if (kunde == null)
            {
                return HttpNotFound();
            }
            return View(kunde);
        }

        // GET: Kunden/Create
        public ActionResult Create()
        {
            KundeKontoViewModel vm = new KundeKontoViewModel();
            return View(vm);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> AddKontoTask([Bind(Include = "Konten")] KundeKontoViewModel kundeKonto)
        {
            var kontoTypen = db.KontoTyp
                .Select(x => new SelectListItem()
                {
                    Text = x.Bezeichnung, Value = x.Id.ToString()
                }).ToList();

            kundeKonto.Konten.ForEach(x => x.KontoTypList = kontoTypen);
            
            kundeKonto.Konten.Add(new KontoViewModel()
            {
                EroeffnungsDatum = DateTime.Today,
                KontoTypList = kontoTypen,
                Kontostand = 0,
                Iban = Convert.ToString(new Random().Next(1000, 9999))
            });
            return PartialView("KundeKonto", kundeKonto);
        }

        // POST: Kunden/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(KundeKontoViewModel vm)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var kontenList = new List<Konto>();
                    foreach (var konto in vm.Konten)
                    {
                        kontenList.Add(new Konto
                        {
                            KontoTypId = konto.KontoTypId,
                            Iban = konto.Iban,
                            EroeffnungsDatum = konto.EroeffnungsDatum,
                            Kontostand = konto.Kontostand
                        });
                    }
                    var kunde = new Kunde
                    {
                        Geburtsdatum = vm.Geburtsdatum,
                        Nachname = vm.Nachname,
                        Vorname = vm.Vorname,
                        Konten = kontenList
                    };

                    db.Kunde.Add(kunde);
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }
            }
            catch (RetryLimitExceededException /* dex */)
            {
                //Log the error (uncomment dex variable name and add a line here to write a log.
                ModelState.AddModelError("", "Änderungen konnten nicht gespeichert werden. Versuchen sie es erneut. Falls das Problem bestehen bleibt, wenden Sie sich bitte an den Administrator.");
            }
            return View(vm);
        }

        // GET: Kunden/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Kunde kunde = db.Kunde.Find(id);
            if (kunde == null)
            {
                return HttpNotFound();
            }
            return View(kunde);
        }

        // POST: Kunden/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost, ActionName("edit")]
        [ValidateAntiForgeryToken]
        public ActionResult EditPost(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var kundeToUpdate = db.Kunde.Find(id);
            if (TryUpdateModel(kundeToUpdate, "",
                new string[] { "Nachname", "Vorname", "Geburtsdatum" }))
            {
                try
                {
                    db.SaveChanges();

                    return RedirectToAction("Index");
                }
                catch (RetryLimitExceededException /* dex */)
                {
                    //Log the error (uncomment dex variable name and add a line here to write a log.
                    ModelState.AddModelError("", "Änderungen konnten nicht gespeichert werden. Versuchen sie es erneut. Falls das Problem bestehen bleibt, wenden Sie sich bitte an den Administrator.");
                }
            }
            return View(kundeToUpdate);
        }

        // GET: Kunden/Delete/5
        public ActionResult Delete(int? id, bool? saveChangesError = false)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            if (saveChangesError.GetValueOrDefault())
            {
                ViewBag.ErrorMessage = "Löschen fehlgeschlagen. Versuchen sie es erneut. Falls das Problem bestehen bleibt, wenden Sie sich bitte an den Administrator.";
            }
            Kunde kunde = db.Kunde.Find(id);
            if (kunde == null)
            {
                return HttpNotFound();
            }
            return View(kunde);
        }

        // POST: Kunden/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id)
        {
            try
            {
                Kunde kunde = db.Kunde.Find(id);
                db.Kunde.Remove(kunde);
                db.SaveChanges();
            }
            catch (RetryLimitExceededException /* dex */)
            {
                //Log the error (uncomment dex variable name and add a line here to write a log.
                return RedirectToAction("Delete", new { id = id, saveChangesError = true });
            }
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
