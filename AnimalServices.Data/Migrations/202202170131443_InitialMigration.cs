namespace AnimalServices.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialMigration : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Animal",
                c => new
                    {
                        AnimalId = c.Int(nullable: false, identity: true),
                        OwnerId = c.Guid(nullable: false),
                        Name = c.String(nullable: false),
                        Species = c.Int(nullable: false),
                        DateOfBirth = c.DateTime(nullable: false),
                        Weight = c.Int(nullable: false),
                        State = c.String(nullable: false),
                        IsFood = c.Boolean(nullable: false),
                        IsBred = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.AnimalId);
            
            CreateTable(
                "dbo.Clinic",
                c => new
                    {
                        ClinicId = c.Int(nullable: false, identity: true),
                        ClinicOwnerId = c.Guid(nullable: false),
                        Name = c.String(nullable: false),
                        Address = c.String(nullable: false),
                        ClinicType = c.Int(nullable: false),
                        HealthRecordId = c.Int(),
                    })
                .PrimaryKey(t => t.ClinicId)
                .ForeignKey("dbo.HealthRecord", t => t.HealthRecordId)
                .Index(t => t.HealthRecordId);
            
            CreateTable(
                "dbo.HealthRecord",
                c => new
                    {
                        HealthRecordId = c.Int(nullable: false, identity: true),
                        RecordType = c.Int(nullable: false),
                        DateGiven = c.DateTime(nullable: false),
                        FrequencyNeeded = c.String(nullable: false),
                        Comments = c.String(),
                        AnimalId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.HealthRecordId)
                .ForeignKey("dbo.Animal", t => t.AnimalId, cascadeDelete: true)
                .Index(t => t.AnimalId);
            
            CreateTable(
                "dbo.Registry",
                c => new
                    {
                        RegistryId = c.Int(nullable: false, identity: true),
                        AptDate = c.DateTime(nullable: false),
                        AptTime = c.DateTime(nullable: false),
                        ServiceId = c.Int(nullable: false),
                        AnimalId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.RegistryId)
                .ForeignKey("dbo.Animal", t => t.AnimalId, cascadeDelete: true)
                .ForeignKey("dbo.Service", t => t.ServiceId, cascadeDelete: true)
                .Index(t => t.ServiceId)
                .Index(t => t.AnimalId);
            
            CreateTable(
                "dbo.Service",
                c => new
                    {
                        ServiceId = c.Int(nullable: false, identity: true),
                        ServiceType = c.Int(nullable: false),
                        Price = c.Int(nullable: false),
                        Length = c.Int(nullable: false),
                        ClinicId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ServiceId)
                .ForeignKey("dbo.Clinic", t => t.ClinicId, cascadeDelete: true)
                .Index(t => t.ClinicId);
            
            CreateTable(
                "dbo.IdentityRole",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.IdentityUserRole",
                c => new
                    {
                        UserId = c.String(nullable: false, maxLength: 128),
                        RoleId = c.String(),
                        IdentityRole_Id = c.String(maxLength: 128),
                        ApplicationUser_Id = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.UserId)
                .ForeignKey("dbo.IdentityRole", t => t.IdentityRole_Id)
                .ForeignKey("dbo.ApplicationUser", t => t.ApplicationUser_Id)
                .Index(t => t.IdentityRole_Id)
                .Index(t => t.ApplicationUser_Id);
            
            CreateTable(
                "dbo.ApplicationUser",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Email = c.String(),
                        EmailConfirmed = c.Boolean(nullable: false),
                        PasswordHash = c.String(),
                        SecurityStamp = c.String(),
                        PhoneNumber = c.String(),
                        PhoneNumberConfirmed = c.Boolean(nullable: false),
                        TwoFactorEnabled = c.Boolean(nullable: false),
                        LockoutEndDateUtc = c.DateTime(),
                        LockoutEnabled = c.Boolean(nullable: false),
                        AccessFailedCount = c.Int(nullable: false),
                        UserName = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.IdentityUserClaim",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UserId = c.String(),
                        ClaimType = c.String(),
                        ClaimValue = c.String(),
                        ApplicationUser_Id = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.ApplicationUser", t => t.ApplicationUser_Id)
                .Index(t => t.ApplicationUser_Id);
            
            CreateTable(
                "dbo.IdentityUserLogin",
                c => new
                    {
                        UserId = c.String(nullable: false, maxLength: 128),
                        LoginProvider = c.String(),
                        ProviderKey = c.String(),
                        ApplicationUser_Id = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.UserId)
                .ForeignKey("dbo.ApplicationUser", t => t.ApplicationUser_Id)
                .Index(t => t.ApplicationUser_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.IdentityUserRole", "ApplicationUser_Id", "dbo.ApplicationUser");
            DropForeignKey("dbo.IdentityUserLogin", "ApplicationUser_Id", "dbo.ApplicationUser");
            DropForeignKey("dbo.IdentityUserClaim", "ApplicationUser_Id", "dbo.ApplicationUser");
            DropForeignKey("dbo.IdentityUserRole", "IdentityRole_Id", "dbo.IdentityRole");
            DropForeignKey("dbo.Registry", "ServiceId", "dbo.Service");
            DropForeignKey("dbo.Service", "ClinicId", "dbo.Clinic");
            DropForeignKey("dbo.Registry", "AnimalId", "dbo.Animal");
            DropForeignKey("dbo.Clinic", "HealthRecordId", "dbo.HealthRecord");
            DropForeignKey("dbo.HealthRecord", "AnimalId", "dbo.Animal");
            DropIndex("dbo.IdentityUserLogin", new[] { "ApplicationUser_Id" });
            DropIndex("dbo.IdentityUserClaim", new[] { "ApplicationUser_Id" });
            DropIndex("dbo.IdentityUserRole", new[] { "ApplicationUser_Id" });
            DropIndex("dbo.IdentityUserRole", new[] { "IdentityRole_Id" });
            DropIndex("dbo.Service", new[] { "ClinicId" });
            DropIndex("dbo.Registry", new[] { "AnimalId" });
            DropIndex("dbo.Registry", new[] { "ServiceId" });
            DropIndex("dbo.HealthRecord", new[] { "AnimalId" });
            DropIndex("dbo.Clinic", new[] { "HealthRecordId" });
            DropTable("dbo.IdentityUserLogin");
            DropTable("dbo.IdentityUserClaim");
            DropTable("dbo.ApplicationUser");
            DropTable("dbo.IdentityUserRole");
            DropTable("dbo.IdentityRole");
            DropTable("dbo.Service");
            DropTable("dbo.Registry");
            DropTable("dbo.HealthRecord");
            DropTable("dbo.Clinic");
            DropTable("dbo.Animal");
        }
    }
}
