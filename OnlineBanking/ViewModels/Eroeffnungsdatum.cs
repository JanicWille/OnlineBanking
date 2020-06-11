using System;
using System.ComponentModel.DataAnnotations;

namespace OnlineBanking.ViewModels
{
    public class Eroeffnungsdatum
    {
        [DataType(DataType.Date)]
        public DateTime? KontoEroeffnung { get; set; }

        public int KundenCount { get; set; }
    }
}