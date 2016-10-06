namespace VMGest1.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class azdett : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.AzDetts",
                c => new
                    {
                        AzioniDett_Id = c.Int(nullable: false, identity: true),
                        Area_Id = c.Int(nullable: false),
                        Descrizione = c.String(),
                        Azioni_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.AzioniDett_Id)
                .ForeignKey("dbo.Arees", t => t.Area_Id, cascadeDelete: true)
                .ForeignKey("dbo.Azionis", t => t.Azioni_Id, cascadeDelete: true)
                .Index(t => t.Area_Id)
                .Index(t => t.Azioni_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.AzDetts", "Azioni_Id", "dbo.Azionis");
            DropForeignKey("dbo.AzDetts", "Area_Id", "dbo.Arees");
            DropIndex("dbo.AzDetts", new[] { "Azioni_Id" });
            DropIndex("dbo.AzDetts", new[] { "Area_Id" });
            DropTable("dbo.AzDetts");
        }
    }
}
