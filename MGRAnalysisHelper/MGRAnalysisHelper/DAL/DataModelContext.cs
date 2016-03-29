using System;
using MGRAnalysisHelper.Models;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;

namespace MGRAnalysisHelper.DAL
{
    public class DataModelContext : DbContext
    {
        public DataModelContext() : base("DataModelContext")
        {

        }
        public DbSet<Analiza> Analizy { get; set; }
        public DbSet<Portal> Portale { get; set; }
        public DbSet<Kryterium> Kryteria { get; set; }
        public DbSet<Ocena_Kryterium> OcenyKryterium { get; set; }
        public DbSet<Ocena_Portal> OcenyPortal { get; set; }
        public DbSet<Waga> Wagi { get; set; }


        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
        }
    }
}