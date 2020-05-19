using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;
using System.Web.Mvc.Routing.Constraints;

namespace OnlineBanking.Models
{
    public class Kunde : ModelBase
    {
        [Required]
        public string Nachname { get; set; }

        [Required]
        public string Vorname { get; set; }

        [Column(TypeName = "Date")]
        [Required]
        public DateTime Geburtsdatum { get; set; }
        public virtual ICollection<KundeKonto> Konten { get; set; }
    }
}