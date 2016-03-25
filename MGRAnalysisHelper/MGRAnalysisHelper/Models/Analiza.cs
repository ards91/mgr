using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MGRAnalysisHelper.Models
{
    public class Analiza
    {
        public int ID { get; set; }
        public string Nazwa { get; set; }
        public DateTime DataAnalizy { get; set; }
        public virtual ICollection<Portal> Portale { get; set; }
        public virtual ICollection<Kryterium> Kryteria { get; set; }
        public virtual ICollection<Ocena_Portal> OcenaPodsumowanie { get; set; }
        public virtual ICollection<Ocena_Kryterium> OcenaKryterium { get; set; }

    }
}