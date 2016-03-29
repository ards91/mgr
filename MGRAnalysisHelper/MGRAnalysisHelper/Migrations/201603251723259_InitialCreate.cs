namespace MGRAnalysisHelper.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Analiza",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Nazwa = c.String(),
                        DataAnalizy = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Kryterium",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Nazwa = c.String(),
                        Opis = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Ocena_Kryterium",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Wartosc = c.Int(nullable: false),
                        Opis = c.String(),
                        KryteriumID = c.Int(nullable: false),
                        PortalId = c.Int(nullable: false),
                        AnalizaId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Kryterium", t => t.KryteriumID, cascadeDelete: true)
                .ForeignKey("dbo.Analiza", t => t.AnalizaId, cascadeDelete: true)
                .ForeignKey("dbo.Portal", t => t.PortalId, cascadeDelete: true)
                .Index(t => t.KryteriumID)
                .Index(t => t.PortalId)
                .Index(t => t.AnalizaId);
            
            CreateTable(
                "dbo.Portal",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Nazwa = c.String(),
                        Opis = c.String(),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.Ocena_Portal",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Wartosc = c.Int(nullable: false),
                        PortalId = c.Int(nullable: false),
                        AnalizaId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Analiza", t => t.AnalizaId, cascadeDelete: true)
                .ForeignKey("dbo.Portal", t => t.PortalId, cascadeDelete: true)
                .Index(t => t.PortalId)
                .Index(t => t.AnalizaId);
            
            CreateTable(
                "dbo.PortalAnaliza",
                c => new
                    {
                        Portal_ID = c.Int(nullable: false),
                        Analiza_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Portal_ID, t.Analiza_Id })
                .ForeignKey("dbo.Portal", t => t.Portal_ID, cascadeDelete: true)
                .ForeignKey("dbo.Analiza", t => t.Analiza_Id, cascadeDelete: true)
                .Index(t => t.Portal_ID)
                .Index(t => t.Analiza_Id);
            
            CreateTable(
                "dbo.KryteriumAnaliza",
                c => new
                    {
                        Kryterium_Id = c.Int(nullable: false),
                        Analiza_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Kryterium_Id, t.Analiza_Id })
                .ForeignKey("dbo.Kryterium", t => t.Kryterium_Id, cascadeDelete: true)
                .ForeignKey("dbo.Analiza", t => t.Analiza_Id, cascadeDelete: true)
                .Index(t => t.Kryterium_Id)
                .Index(t => t.Analiza_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.KryteriumAnaliza", "Analiza_Id", "dbo.Analiza");
            DropForeignKey("dbo.KryteriumAnaliza", "Kryterium_Id", "dbo.Kryterium");
            DropForeignKey("dbo.PortalAnaliza", "Analiza_Id", "dbo.Analiza");
            DropForeignKey("dbo.PortalAnaliza", "Portal_ID", "dbo.Portal");
            DropForeignKey("dbo.Ocena_Portal", "PortalId", "dbo.Portal");
            DropForeignKey("dbo.Ocena_Portal", "AnalizaId", "dbo.Analiza");
            DropForeignKey("dbo.Ocena_Kryterium", "PortalId", "dbo.Portal");
            DropForeignKey("dbo.Ocena_Kryterium", "AnalizaId", "dbo.Analiza");
            DropForeignKey("dbo.Ocena_Kryterium", "KryteriumID", "dbo.Kryterium");
            DropIndex("dbo.KryteriumAnaliza", new[] { "Analiza_Id" });
            DropIndex("dbo.KryteriumAnaliza", new[] { "Kryterium_Id" });
            DropIndex("dbo.PortalAnaliza", new[] { "Analiza_Id" });
            DropIndex("dbo.PortalAnaliza", new[] { "Portal_ID" });
            DropIndex("dbo.Ocena_Portal", new[] { "AnalizaId" });
            DropIndex("dbo.Ocena_Portal", new[] { "PortalId" });
            DropIndex("dbo.Ocena_Kryterium", new[] { "AnalizaId" });
            DropIndex("dbo.Ocena_Kryterium", new[] { "PortalId" });
            DropIndex("dbo.Ocena_Kryterium", new[] { "KryteriumID" });
            DropTable("dbo.KryteriumAnaliza");
            DropTable("dbo.PortalAnaliza");
            DropTable("dbo.Ocena_Portal");
            DropTable("dbo.Portal");
            DropTable("dbo.Ocena_Kryterium");
            DropTable("dbo.Kryterium");
            DropTable("dbo.Analiza");
        }
    }
}
