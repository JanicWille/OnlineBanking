﻿using System.Collections.Generic;
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
                new Kunde{Vorname= "Carson",Nachname= "Alexander",Geburtsdatum= DateTime.Parse("2005-09-01")},
                new Kunde{Vorname="Meredith",Nachname="Alonso",Geburtsdatum=DateTime.Parse("2002-09-01")},
                new Kunde{Vorname="Arturo",Nachname="Anand",Geburtsdatum=DateTime.Parse("2003-09-01")},
                new Kunde{Vorname="Gytis",Nachname="Barzdukas",Geburtsdatum=DateTime.Parse("2002-09-01")},
                new Kunde{Vorname="Yan",Nachname="Li",Geburtsdatum=DateTime.Parse("2002-09-01")},
                new Kunde{Vorname="Peggy",Nachname="Justice",Geburtsdatum=DateTime.Parse("2001-09-01")},
                new Kunde{Vorname="Laura",Nachname="Norman",Geburtsdatum=DateTime.Parse("2003-09-01")},
                new Kunde{Vorname="Nino",Nachname="Olivetto",Geburtsdatum=DateTime.Parse("2005-09-01")},
                new Kunde{Vorname="Nino2",Nachname="Olivetto",Geburtsdatum=DateTime.Parse("2005-09-01")}
            };

            kunden.ForEach(s => context.Kunde.Add(s));
            var kontoTyp = new KontoTyp
            {
                Bezeichnung = "Girokonto",
                Id = 1
            };
            context.KontoTyp.Add(kontoTyp);

            var konten = new List<Konto>
            {
                new Konto{Id=1,Kontostand= 0, Iban = "DE258465135486813516845", KontoTypId = 1},
                new Konto{Id=2,Kontostand= 0, Iban = "DE252384315486813516845", KontoTypId = 1},
                new Konto{Id=3,Kontostand= 0, Iban = "DE258468463123813516845", KontoTypId = 1},
                new Konto{Id=4,Kontostand= 0, Iban = "DE258465135138713516845", KontoTypId = 1},
                new Konto{Id=5,Kontostand= 0, Iban = "DE258465135456813516845", KontoTypId = 1},
                new Konto{Id=6,Kontostand= 0, Iban = "DE258465135486813518645", KontoTypId = 1}
            };
            konten.ForEach(s => context.Konto.Add(s));
            context.SaveChanges();
        }
    }
}