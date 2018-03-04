namespace Vidly.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class PopulateGenreTable : DbMigration
    {
        public override void Up()
        {
            Sql("Insert INTO Genres ( Name) VALUES ( 'Boievic')");
            Sql("Insert INTO Genres ( Name) VALUES ( 'Horrow')");
            Sql("Insert INTO Genres ( Name) VALUES ( 'Comedy')");
            Sql("Insert INTO Genres ( Name) VALUES ( 'Family')");
            Sql("Insert INTO Genres (Name) VALUES ( 'Romance')");
        }
        
        public override void Down()
        {
        }
    }
}
