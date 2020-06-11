namespace OnlineBanking.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Kunde_EroeffnungsDatum : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Kunde", "EroeffnungsDatum", c => c.DateTime(nullable: false, storeType: "date"));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Kunde", "EroeffnungsDatum");
        }
    }
}
