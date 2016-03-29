using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MGRAnalysisHelper.Models
{
    public class Waga
    {
        [Key()]
        public int Id { get; set; }
        public int Wartosc { get; set; }
        public int AnalizaId { get; set; }
        public virtual Analiza Analiza { get; set; }
        public int KryteriumId { get; set; }
        public virtual Kryterium Kryterium { get; set; }
    }
}