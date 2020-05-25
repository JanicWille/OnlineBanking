using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using ContosoUniversity.Models;
using OnlineBanking.DAL;
using OnlineBanking.Models;

namespace ContosoUniversity.DAL
{
    public class BankingInitializer : System.Data.Entity.DropCreateDatabaseIfModelChanges<BankingContext>
    {
        protected override void Seed(BankingContext context)
        {
            var students = new List<Kunde>
            {
            new Kunde{Vorname= "Carson",Nachname= "Alexander",Geburtsdatum= DateTime.Parse("2005-09-01")},
            new Kunde{Vorname="Meredith",Nachname="Alonso",Geburtsdatum=DateTime.Parse("2002-09-01")},
            new Kunde{Vorname="Arturo",Nachname="Anand",Geburtsdatum=DateTime.Parse("2003-09-01")},
            new Kunde{Vorname="Gytis",Nachname="Barzdukas",Geburtsdatum=DateTime.Parse("2002-09-01")},
            new Kunde{Vorname="Yan",Nachname="Li",Geburtsdatum=DateTime.Parse("2002-09-01")},
            new Kunde{Vorname="Peggy",Nachname="Justice",Geburtsdatum=DateTime.Parse("2001-09-01")},
            new Kunde{Vorname="Laura",Nachname="Norman",Geburtsdatum=DateTime.Parse("2003-09-01")},
            new Kunde{Vorname="Nino",Nachname="Olivetto",Geburtsdatum=DateTime.Parse("2005-09-01")}
            };

            students.ForEach(s => context.Kunde.Add(s));
            context.SaveChanges();
            var courses = new List<Konto>
            {
            new Konto{Id= 1050,KontoTypId= 0001,KontoTyp= "Girokonto", Iban = "DE258465135486813516845"},
            new Konto{Id=4022,KontoTypId=0002,KontoTyp="Girokonto",},
            new Konto{Id=4041,KontoTypId=0003,KontoTyp="Girokonto",},
            new Konto{Id=1045,KontoTypId=0004,KontoTyp="Girokonto",},
            new Konto{Id=3141,KontoTypId=0005,KontoTyp="Girokonto",},
            new Konto{Id=2021,KontoTypId=0006,KontoTyp="Girokonto",},
            new Konto{Id=2042,KontoTypId=0007,KontoTyp="Girokonto",}
            };
            courses.ForEach(s => context.Konto.Add(s));
            context.SaveChanges();
        }
    }
}