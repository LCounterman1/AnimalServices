namespace AnimalServices.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class TestMigration : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Clinic", "AnimalId", "dbo.Animal");
            DropForeignKey("dbo.HealthRecord", "AnimalId", "dbo.Animal");
            DropForeignKey("dbo.Registry", "AnimalID", "dbo.Animal");
            DropForeignKey("dbo.Service", "AnimalID", "dbo.Animal");
            DropPrimaryKey("dbo.Animal");
            CreateTable(
                "dbo.Clinic",
                c => new
                    {
                        ClinicId = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false),
                        Address = c.String(nullable: false),
                        ClinicType = c.Int(nullable: false),
                        AnimalId = c.Int(nullable: false),
                        HealthRecordId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ClinicId)
                .ForeignKey("dbo.Animal", t => t.AnimalId, cascadeDelete: true)
                .ForeignKey("dbo.HealthRecord", t => t.HealthRecordId, cascadeDelete: true)
                .Index(t => t.AnimalId)
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
                        AnimalID = c.Int(nullable: false),
                        ClinicID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.RegistryId)
                .ForeignKey("dbo.Animal", t => t.AnimalID, cascadeDelete: true)
                .ForeignKey("dbo.Clinic", t => t.ClinicID, cascadeDelete: true)
                .Index(t => t.AnimalID)
                .Index(t => t.ClinicID);
            
            CreateTable(
                "dbo.Service",
                c => new
                    {
                        ServiceId = c.Int(nullable: false, identity: true),
                        ServiceType = c.Int(nullable: false),
                        Price = c.Int(nullable: false),
                        Length = c.Int(nullable: false),
                        ClinicID = c.Int(nullable: false),
                        AnimalID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ServiceId)
                .ForeignKey("dbo.Animal", t => t.AnimalID, cascadeDelete: true)
                .ForeignKey("dbo.Clinic", t => t.ClinicID, cascadeDelete: true)
                .Index(t => t.ClinicID)
                .Index(t => t.AnimalID);
            
            AddColumn("dbo.Animal", "AnimalId", c => c.Int(nullable: false, identity: true));
            AddPrimaryKey("dbo.Animal", "AnimalId");
            DropColumn("dbo.Animal", "ID");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Animal", "ID", c => c.Int(nullable: false, identity: true));
            DropForeignKey("dbo.Service", "ClinicID", "dbo.Clinic");
            DropForeignKey("dbo.Service", "AnimalID", "dbo.Animal");
            DropForeignKey("dbo.Registry", "ClinicID", "dbo.Clinic");
            DropForeignKey("dbo.Registry", "AnimalID", "dbo.Animal");
            DropForeignKey("dbo.Clinic", "HealthRecordId", "dbo.HealthRecord");
            DropForeignKey("dbo.HealthRecord", "AnimalId", "dbo.Animal");
            DropForeignKey("dbo.Clinic", "AnimalId", "dbo.Animal");
            DropIndex("dbo.Service", new[] { "AnimalID" });
            DropIndex("dbo.Service", new[] { "ClinicID" });
            DropIndex("dbo.Registry", new[] { "ClinicID" });
            DropIndex("dbo.Registry", new[] { "AnimalID" });
            DropIndex("dbo.HealthRecord", new[] { "AnimalId" });
            DropIndex("dbo.Clinic", new[] { "HealthRecordId" });
            DropIndex("dbo.Clinic", new[] { "AnimalId" });
            DropPrimaryKey("dbo.Animal");
            DropColumn("dbo.Animal", "AnimalId");
            DropTable("dbo.Service");
            DropTable("dbo.Registry");
            DropTable("dbo.HealthRecord");
            DropTable("dbo.Clinic");
            AddPrimaryKey("dbo.Animal", "ID");
            AddForeignKey("dbo.Service", "AnimalID", "dbo.Animal", "AnimalId", cascadeDelete: true);
            AddForeignKey("dbo.Registry", "AnimalID", "dbo.Animal", "AnimalId", cascadeDelete: true);
            AddForeignKey("dbo.HealthRecord", "AnimalId", "dbo.Animal", "AnimalId", cascadeDelete: true);
            AddForeignKey("dbo.Clinic", "AnimalId", "dbo.Animal", "AnimalId", cascadeDelete: true);
        }
    }
}
