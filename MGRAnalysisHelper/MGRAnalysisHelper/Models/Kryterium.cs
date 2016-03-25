using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MGRAnalysisHelper.Models
{
    public class Kryterium
    {
        public int Id { get; set; }
        public string Nazwa { get; set; }
        public string Opis { get; set; }
        public virtual ICollection<Analiza> Porownania { get; set; }
        public virtual ICollection<Ocena_Kryterium> Ocena
    }
}