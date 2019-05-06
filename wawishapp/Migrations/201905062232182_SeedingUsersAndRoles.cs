namespace wawishapp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class SeedingUsersAndRoles : DbMigration
    {
        public override void Up()
        {
            Sql(@"
                INSERT INTO[dbo].[AspNetUsers] ([Id], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName]) VALUES(N'f04a39e6-a0c2-4344-ad29-b0f05f6ca5ce', N'billy.arredondo@pucp.pe', 0, N'AAz9Az0wldUYq2smf7QzbYF7vLCd46CPYik6Lf0vLGcE8IEpD4QzkFYv6QfNVV53kA==', N'079188e7-b994-4851-bfa6-fd0aab8dbf54', NULL, 0, 0, NULL, 1, 0, N'billy.arredondo')
                INSERT INTO[dbo].[AspNetUsers] ([Id], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName]) VALUES(N'f1757223-6d88-4ec1-8d4a-60bb0961fa33', N'ypomag14@gmail.com', 0, N'ALi0KPcasPzCv7BEmlIxxD6sEV9O2GScd6/AIgDNYjQKQMBnkjeGhUC6AcZx9mANew==', N'ae4f2367-cdb4-4b62-862a-d9c19286d10e', NULL, 0, 0, NULL, 1, 0, N'yerina.poma')
                ");
        }

    public override void Down()
        {
        }
    }
}
