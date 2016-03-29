using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MGRAnalysisHelper.Models
{
    public class Kryterium
    {
        [Key()]
        public int Id { get; set; }
        public string Nazwa { get; set; }
        public string Opis { get; set; }
        public virtual ICollection<Analiza> Porownania { get; set; }
        public virtual ICollection<Ocena_Kryterium> Ocena { get; set; }
        public virtual ICollection<Waga> Wagi { get; set; }
    }
}