namespace VMGest1.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class cf : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Anagraficas", "CodiceFiscale", c => c.String());
            AddColumn("dbo.Anagraficas", "DataNascita", c => c.DateTime(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Anagraficas", "DataNascita");
            DropColumn("dbo.Anagraficas", "CodiceFiscale");
        }
    }
}
