using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using OnlineBanking.DAL;
using OnlineBanking.ViewModels;

namespace OnlineBanking.Controllers
{
    public class HomeController : Controller
    {
        private BankingContext db = new BankingContext();

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            IQueryable<Eroeffnungsdatum> data = from kunde in db.Konto
                group kunde by kunde.EroeffnungsDatum into dateGroup
                select new Eroeffnungsdatum()
                {
                    KontoEroeffnung = dateGroup.Key,
                    KundenCount = dateGroup.Count()
                };
            return View(data.ToList());
        }

        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}