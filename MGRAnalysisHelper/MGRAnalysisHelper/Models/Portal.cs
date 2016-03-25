using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MGRAnalysisHelper.Models
{
    public class Portal
    {
        public int ID { get; set; }
        public string Nazwa { get; set; }
        public string Opis { get; set; }
        public virtual ICollection<Analiza> Porownania { get; set; }
        public virtual ICollection<Ocena_Portal> OcenaPodsumowanie { get; set; }
        public virtual ICollection<Ocena_Kryterium> OcenaKryterium { get; set; }
        
    }
}