namespace OnlineBanking.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AlterKundeKontoModel : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Konto",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Iban = c.String(nullable: false),
                        Kontostand = c.Decimal(nullable: false, precision: 18, scale: 2),
                        KontoTypId = c.Int(nullable: false),
                        KundeId = c.Int(nullable: false),
                        EroeffnungsDatum = c.DateTime(nullable: false, storeType: "date"),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.KontoTyp", t => t.KontoTypId, cascadeDelete: true)
                .ForeignKey("dbo.Kunde", t => t.KundeId, cascadeDelete: true)
                .Index(t => t.KontoTypId)
                .Index(t => t.KundeId);
            
            CreateTable(
                "dbo.KontoTyp",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Bezeichnung = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Kunde",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Nachname = c.String(nullable: false),
                        Vorname = c.String(nullable: false),
                        Geburtsdatum = c.DateTime(nullable: false, storeType: "date"),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Konto", "KundeId", "dbo.Kunde");
            DropForeignKey("dbo.Konto", "KontoTypId", "dbo.KontoTyp");
            DropIndex("dbo.Konto", new[] { "KundeId" });
            DropIndex("dbo.Konto", new[] { "KontoTypId" });
            DropTable("dbo.Kunde");
            DropTable("dbo.KontoTyp");
            DropTable("dbo.Konto");
        }
    }
}
