namespace RVAS_Stripovi.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddedErrorMessagesToModelComicBook : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.ComicBooks", "Name", c => c.String(nullable: false, maxLength: 100));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.ComicBooks", "Name", c => c.String(nullable: false));
        }
    }
}
