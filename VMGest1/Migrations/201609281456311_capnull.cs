namespace VMGest1.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class capnull : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Anagraficas", "Indirizzo", c => c.String());
            AlterColumn("dbo.Anagraficas", "CAP", c => c.String());
            AlterColumn("dbo.Anagraficas", "Città", c => c.String());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Anagraficas", "Città", c => c.String(nullable: false));
            AlterColumn("dbo.Anagraficas", "CAP", c => c.String(nullable: false));
            AlterColumn("dbo.Anagraficas", "Indirizzo", c => c.String(nullable: false));
        }
    }
}
