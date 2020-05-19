using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace OnlineBanking.Models
{
    public abstract class ModelBase
    {
        [Required]
        public int Id { get; set; }
    }
}