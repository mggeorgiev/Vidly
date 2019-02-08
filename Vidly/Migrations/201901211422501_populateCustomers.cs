namespace Vidly.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class populateCustomers : DbMigration
    {
        public override void Up()
        {
            Sql("INSERT INTO Customers ( Name, IsSubscribedToNewsletter, MembershipTypeId, DateOfBirth) VALUES ( N'John Smith', 0, 1, N'1980-01-01 00:00:00')");
            Sql("INSERT INTO Customers ( Name, IsSubscribedToNewsletter, MembershipTypeId, DateOfBirth) VALUES ( N'Merry Williams', 1, 2, NULL)");
            Sql("INSERT INTO Customers ( Name, IsSubscribedToNewsletter, MembershipTypeId, DateOfBirth) VALUES ( N'Martin Georgiev', 1, 1, N'1978-11-23 00:00:00')");
        }
        
        public override void Down()
        {
        }
    }
}
