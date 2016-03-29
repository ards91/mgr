using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MGRAnalysisHelper.Models
{
    public class Ocena_Portal
    {
        [Key()]
        public int Id { get; set; }
        public int Wartosc { get; set; }
        public int PortalId { get; set; }
        public int AnalizaId { get; set; }
        public virtual Portal portal { get; set; }
        public virtual Analiza porownania { get; set; }

    }
}