using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
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
    }
}