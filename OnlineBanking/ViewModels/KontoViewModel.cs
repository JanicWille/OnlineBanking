using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using OnlineBanking.Models;

namespace OnlineBanking.ViewModels
{
    public class KontoViewModel
    {
        public string Iban { get; set; }

        public decimal Kontostand { get; set; }

        public int KontoTypId { get; set; }

        public KontoTyp KontoTyp { get; set; }

        public int KundeId { get; set; }

        public Kunde Kunde { get; set; }

        [Required]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd.MM.yyyy}")]
        public DateTime EroeffnungsDatum { get; set; }

        public virtual SelectList KontoTypList { get; set; }
    }
}