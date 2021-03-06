﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace OnlineBanking.Models
{
    public class Konto : ModelBase
    {
        [Required]
        public string Iban { get; set; }

        public decimal Kontostand { get; set; }

        [Required]
        public int KontoTypId { get; set; }

        public KontoTyp KontoTyp { get; set; }

        public int KundeId { get; set; }

        public Kunde Kunde { get; set; }

        [Column(TypeName = "Date")]
        [Required]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd.MM.yyyy}")]
        public DateTime EroeffnungsDatum { get; set; }
    }
}