namespace Unflixx.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class SeedUsers : DbMigration
    {
        public override void Up()
        {
            Sql(@"INSERT INTO [dbo].[AspNetUsers] ([Id], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName]) VALUES (N'4e91e439-1a1c-40fd-a361-90dc1e9b5859', N'admin@unflixx.com', 0, N'AANIh3Bn/f/ukxQWCY75ZuXIoGKqnAAr/jdcQal1G3a6jRnA9tw5mqOK35T9s04rzg==', N'1611e2fd-073f-4e39-9ded-3d097386166b', NULL, 0, 0, NULL, 1, 0, N'admin@unflixx.com')
                    INSERT INTO [dbo].[AspNetUsers] ([Id], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName]) VALUES (N'a42b6fdc-0865-43f1-8d75-bd681c360e8b', N'guest@unflixx.com', 0, N'ADyzSSYIgyAKbpoXa2S+uIfrc2T32lsXfTo9rN9oCaDhd90iArg995MXtXtcWNW0fg==', N'17d48c1e-a68c-406d-9166-1517031f0001', NULL, 0, 0, NULL, 1, 0, N'guest@unflixx.com')
                    INSERT INTO [dbo].[AspNetRoles] ([Id], [Name]) VALUES (N'234fe348-e217-4d28-8120-c3a6d3c4be3b', N'CanManageMovies')
                    INSERT INTO [dbo].[AspNetUserRoles] ([UserId], [RoleId]) VALUES (N'4e91e439-1a1c-40fd-a361-90dc1e9b5859', N'234fe348-e217-4d28-8120-c3a6d3c4be3b')
                ");
        }
        
        public override void Down()
        {
        }
    }
}
