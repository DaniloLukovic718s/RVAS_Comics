namespace RVAS_Stripovi.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class PopulateGenres : DbMigration
    {
        public override void Up()
        {
            Sql("INSERT INTO Genres(Name) VALUES ('Action')");
            Sql("INSERT INTO Genres(Name) VALUES ('Romance')");
            Sql("INSERT INTO Genres(Name) VALUES ('Slice of Life')");
            Sql("INSERT INTO Genres(Name) VALUES ('Psychological')");
            Sql("INSERT INTO Genres(Name) VALUES ('Sport')");
            Sql("INSERT INTO Genres(Name) VALUES ('Manga')");
            Sql("INSERT INTO Genres(Name) VALUES ('Horror')");
            Sql("INSERT INTO Genres(Name) VALUES ('Comedy')");
        }
        
        public override void Down()
        {
            Sql("TRUNCATE TABLE dbo.Genres");
        }
    }
}
