namespace RVAS_Stripovi.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddedAgeCustomerAndLengthToFields : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Customers", "Age", c => c.Int(nullable: false));
            AlterColumn("dbo.Customers", "Name", c => c.String(nullable: false, maxLength: 50));
            AlterColumn("dbo.Customers", "Surname", c => c.String(nullable: false, maxLength: 50));
            AlterColumn("dbo.Customers", "Adress", c => c.String(nullable: false, maxLength: 100));
            AlterColumn("dbo.Customers", "PhoneNumber", c => c.String(nullable: false, maxLength: 25));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Customers", "PhoneNumber", c => c.String(nullable: false));
            AlterColumn("dbo.Customers", "Adress", c => c.String(nullable: false));
            AlterColumn("dbo.Customers", "Surname", c => c.String(nullable: false));
            AlterColumn("dbo.Customers", "Name", c => c.String(nullable: false));
            DropColumn("dbo.Customers", "Age");
        }
    }
}
