namespace Vidly.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdataDAtaToCustomers : DbMigration
    {
        public override void Up()
        {
            Sql("TRUNCATE Table Customers");
        }
        
        public override void Down()
        {
        }
    }
}
