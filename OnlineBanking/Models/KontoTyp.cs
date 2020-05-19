using System.ComponentModel.DataAnnotations;

namespace OnlineBanking.Models
{
    public class KontoTyp : ModelBase
    {
        [Required]
        public string Bezeichnung { get; set; }
    }
}