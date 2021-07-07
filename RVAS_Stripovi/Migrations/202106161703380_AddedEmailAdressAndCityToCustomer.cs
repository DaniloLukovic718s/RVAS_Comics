namespace RVAS_Stripovi.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddedEmailAdressAndCityToCustomer : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Customers", "City", c => c.String(nullable: false, maxLength: 50));
            AddColumn("dbo.Customers", "EmailAdress", c => c.String(nullable: false, maxLength: 50));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Customers", "EmailAdress");
            DropColumn("dbo.Customers", "City");
        }
    }
}
