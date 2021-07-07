namespace RVAS_Stripovi.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddedNullableToDueDate : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Rentals", "DueDate", c => c.DateTime());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Rentals", "DueDate", c => c.DateTime(nullable: false));
        }
    }
}
