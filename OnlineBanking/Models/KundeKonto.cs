using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace OnlineBanking.Models
{
    public class KundeKonto : ModelBase
    {
        public int KontoId { get; set; }
        public int KundeId { get; set; }
        public Kunde Kunde { get; set; }
        public Konto Konto { get; set; }

        public  static List<KundeKonto> Konten { get; set; }
        public KundeKonto()
        {
            Konten = new List<KundeKonto>();
        }
    }
}