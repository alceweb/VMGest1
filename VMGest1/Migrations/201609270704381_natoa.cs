namespace VMGest1.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class natoa : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Anagraficas", "LuogoNascita", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Anagraficas", "LuogoNascita");
        }
    }
}
