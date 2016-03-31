using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MGRAnalysisHelper.Models
{
    public class Ocena_Kryterium
    {
        [Key()]
        public int Id { get; set; }
        [Range(1.0,10.0,ErrorMessage ="Wartość oceny powinna mieścić się w przedziale od 1 do 10")]
        public int Wartosc { get; set; }
        public string Opis { get; set; }
        public int KryteriumID { get; set; }
        public int PortalId { get; set; }
        public int AnalizaId { get; set; }
        public virtual Kryterium kryterium { get; set; }
        public virtual Portal portal { get; set; }
        public virtual Analiza porownania { get; set; }
    }
}