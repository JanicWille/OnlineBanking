using System.Collections.Generic;
using OnlineBanking.Models;
using System;
using System.Data.Entity;
using System.Data.Entity.Migrations;
using System.Linq;

namespace OnlineBanking.Migrations
{
    internal sealed class Configuration : DbMigrationsConfiguration<OnlineBanking.DAL.BankingContext>
    {
        public Configuration()
        {

            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(DAL.BankingContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method
            //  to avoid creating duplicate seed data.
            var kunden = new List<Kunde>
            {
                new Kunde{Id=1, Vorname= "Carson",Nachname= "Alexander",Geburtsdatum= DateTime.Parse("2005-09-01") ,EroeffnungsDatum= DateTime.Parse("2005-09-01")},
                new Kunde{Id=2, Vorname="Meredith",Nachname="Alonso",Geburtsdatum=DateTime.Parse("2002-09-01") ,EroeffnungsDatum= DateTime.Parse("2005-09-01")},
                new Kunde{Id=3, Vorname="Arturo",Nachname="Anand",Geburtsdatum=DateTime.Parse("2003-09-01"),EroeffnungsDatum= DateTime.Parse("2005-09-01")},
                new Kunde{Id=4, Vorname="Gytis",Nachname="Barzdukas",Geburtsdatum=DateTime.Parse("2002-09-01"),EroeffnungsDatum= DateTime.Parse("2005-09-01")},
                new Kunde{Id=5, Vorname="Yan",Nachname="Li",Geburtsdatum=DateTime.Parse("2002-09-01"),EroeffnungsDatum= DateTime.Parse("2005-09-01")},
                new Kunde{Id=6, Vorname="Peggy",Nachname="Justice",Geburtsdatum=DateTime.Parse("2001-09-01"),EroeffnungsDatum= DateTime.Parse("2005-09-01")},
                new Kunde{Id=7, Vorname="Laura",Nachname="Norman",Geburtsdatum=DateTime.Parse("2003-09-01"),EroeffnungsDatum= DateTime.Parse("2005-09-01")},
                new Kunde{Id=8, Vorname="Nino",Nachname="Olivetto",Geburtsdatum=DateTime.Parse("2005-09-01"),EroeffnungsDatum= DateTime.Parse("2005-09-01")},
            };

            kunden.ForEach(k => context.Kunde.Add(k));
            //var kontoTyp = new KontoTyp
            //{
            //    Bezeichnung = "Girokonto",
            //    Id = 1
            //};
            //context.KontoTyp.Add(kontoTyp);

            var konten = new List<Konto>
            {
                new Konto{Id=1, Kontostand= 0, Iban = "DE 0001", KontoTypId = 1},
                new Konto{Id=2, Kontostand= 0, Iban = "DE 0002", KontoTypId = 1},
                new Konto{Id=3, Kontostand= 0, Iban = "DE 0003", KontoTypId = 1},
                new Konto{Id=4, Kontostand= 0, Iban = "DE 0004", KontoTypId = 1},
                new Konto{Id=5, Kontostand= 0, Iban = "DE 0005", KontoTypId = 1},
                new Konto{Id=6, Kontostand= 0, Iban = "DE 0006", KontoTypId = 1},
                new Konto{Id=7, Kontostand= 0, Iban = "DE 0007", KontoTypId = 1},
                new Konto{Id=8, Kontostand= 0, Iban = "DE 0008", KontoTypId = 1}
            };
            konten.ForEach(k => context.Konto.Add(k));
            context.SaveChanges();
        }
    }
}
