using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.WebSockets;
using Antlr.Runtime;
using OnlineBanking.Models;

namespace OnlineBanking.ViewModels
{
    public class KundeKontoViewModel
    {
        [Required]
        public string Nachname { get; set; }

        [Required]
        public string Vorname { get; set; }

        [Required]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd.MM.yyyy}")]
        public DateTime Geburtsdatum { get; set; }
        public virtual ICollection<KundeKonto> Konten { get; set; }

        [Required]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd.MM.yyyy}")]
        public DateTime EroeffnungsDatum { get; set; }

        public virtual SelectList KontoTypList { get; set; }

        public KundeKontoViewModel()
        {
            Konten = new List<KundeKonto>();
        }
    }
}