namespace Vidly.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class PopulateMembershipTypes : DbMigration
    {
        public override void Up()
        {
            Sql("Update INTO MembershipTypes (Id, SingUpFee, DurationInMonth, DiscountRate,Name) VALUES (1, 0,0,0,Pay as you Go)");
            Sql("Update INTO MembershipTypes (Id, SingUpFee, DurationInMonth, DiscountRate,Name) VALUES (2, 30,1,10,Monthly)");
            Sql("Update INTO MembershipTypes (Id, SingUpFee, DurationInMonth, DiscountRate,Name) VALUES (3, 90,3,15,Monthly)");
            Sql("Update INTO MembershipTypes (Id, SingUpFee, DurationInMonth, DiscountRate,Name) VALUES (4, 300,12,20,Monthly)");
        }
        
        public override void Down()
        {
        }
    }
}
