namespace VMGest1.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class endfeel : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Azionis", "Tmt", c => c.String());
            AddColumn("dbo.Azionis", "Endfeel", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Azionis", "Endfeel");
            DropColumn("dbo.Azionis", "Tmt");
        }
    }
}
