namespace Vidly.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class populateMembershipTypes : DbMigration
    {
        public override void Up()
        {
            Sql(" INSERT INTO MembershipTypes ([Id], [SignUpFee], [DurationInMonths], [DiscountRate], [Name]) VALUES(1, 0, 0, 0, N'Pay As You Go')");
            Sql("INSERT INTO MembershipTypes ([Id], [SignUpFee], [DurationInMonths], [DiscountRate], [Name]) VALUES(2, 30, 1, 10, N'Monthly')");
            Sql("INSERT INTO MembershipTypes ([Id], [SignUpFee], [DurationInMonths], [DiscountRate], [Name]) VALUES(3, 90, 3, 15, N'Quaterly')");
            Sql("INSERT INTO MembershipTypes ([Id], [SignUpFee], [DurationInMonths], [DiscountRate], [Name]) VALUES(4, 300, 12, 20, N'Yearly')");
        }

    public override void Down()
        {
        }
    }
}
