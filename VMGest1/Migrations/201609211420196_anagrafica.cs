namespace VMGest1.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class anagrafica : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Anagraficas",
                c => new
                    {
                        Anagrafica_Id = c.Int(nullable: false, identity: true),
                        Nome = c.String(nullable: false),
                        Cognome = c.String(nullable: false),
                        Indirizzo = c.String(nullable: false),
                        CAP = c.String(nullable: false),
                        Città = c.String(nullable: false),
                        Telefono = c.String(),
                        Cellulare = c.String(),
                        Email = c.String(),
                    })
                .PrimaryKey(t => t.Anagrafica_Id);
            
            CreateTable(
                "dbo.Azionis",
                c => new
                    {
                        Azioni_Id = c.Int(nullable: false, identity: true),
                        Tipo = c.String(),
                        Anagrafica_Id = c.Int(nullable: false),
                        Data = c.DateTime(nullable: false),
                        Descrizione = c.String(),
                    })
                .PrimaryKey(t => t.Azioni_Id)
                .ForeignKey("dbo.Anagraficas", t => t.Anagrafica_Id, cascadeDelete: true)
                .Index(t => t.Anagrafica_Id);
            
            CreateTable(
                "dbo.AzioniDetts",
                c => new
                    {
                        AzioniDett_Id = c.Int(nullable: false, identity: true),
                        Area_Id = c.Int(nullable: false),
                        Descrizione = c.String(),
                        Azioni_Azioni_Id = c.Int(),
                    })
                .PrimaryKey(t => t.AzioniDett_Id)
                .ForeignKey("dbo.Arees", t => t.Area_Id, cascadeDelete: true)
                .ForeignKey("dbo.Azionis", t => t.Azioni_Azioni_Id)
                .Index(t => t.Area_Id)
                .Index(t => t.Azioni_Azioni_Id);
            
            CreateTable(
                "dbo.Arees",
                c => new
                    {
                        Area_Id = c.Int(nullable: false, identity: true),
                        Descrizione = c.String(),
                        Anamnesi = c.Boolean(nullable: false),
                        Valutazione = c.Boolean(nullable: false),
                        Trattamento = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Area_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.AzioniDetts", "Azioni_Azioni_Id", "dbo.Azionis");
            DropForeignKey("dbo.AzioniDetts", "Area_Id", "dbo.Arees");
            DropForeignKey("dbo.Azionis", "Anagrafica_Id", "dbo.Anagraficas");
            DropIndex("dbo.AzioniDetts", new[] { "Azioni_Azioni_Id" });
            DropIndex("dbo.AzioniDetts", new[] { "Area_Id" });
            DropIndex("dbo.Azionis", new[] { "Anagrafica_Id" });
            DropTable("dbo.Arees");
            DropTable("dbo.AzioniDetts");
            DropTable("dbo.Azionis");
            DropTable("dbo.Anagraficas");
        }
    }
}
