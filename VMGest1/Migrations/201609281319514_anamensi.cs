namespace VMGest1.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class anamensi : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Azionis", "Diagnostica", c => c.String());
            AddColumn("dbo.Azionis", "Traumi", c => c.String());
            AddColumn("dbo.Azionis", "Chirurgia", c => c.String());
            AddColumn("dbo.Azionis", "Viscerale", c => c.String());
            AddColumn("dbo.Azionis", "Dentale", c => c.String());
            AddColumn("dbo.Azionis", "Visiva", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Azionis", "Visiva");
            DropColumn("dbo.Azionis", "Dentale");
            DropColumn("dbo.Azionis", "Viscerale");
            DropColumn("dbo.Azionis", "Chirurgia");
            DropColumn("dbo.Azionis", "Traumi");
            DropColumn("dbo.Azionis", "Diagnostica");
        }
    }
}
