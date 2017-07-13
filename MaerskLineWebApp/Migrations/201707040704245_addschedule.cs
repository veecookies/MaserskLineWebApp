namespace MaerskLineWebApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addschedule : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Containers",
                c => new
                    {
                        ContainerID = c.Int(nullable: false, identity: true),
                        Container_Description = c.String(nullable: false),
                        Container_Weight = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ContainerID);
            
            CreateTable(
                "dbo.ShippingSchedules",
                c => new
                    {
                        ShippingScheduleID = c.Int(nullable: false, identity: true),
                        ShipID = c.Int(nullable: false),
                        ContainerID = c.Int(nullable: false),
                        Charges = c.Double(nullable: false),
                        Departure_Date = c.DateTime(nullable: false),
                        Arrival_Date = c.DateTime(nullable: false),
                        Departure_ShipyardID = c.Int(nullable: false),
                        Arrival_ShipyardID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ShippingScheduleID)
                .ForeignKey("dbo.Containers", t => t.ContainerID, cascadeDelete: false)
                .ForeignKey("dbo.Ships", t => t.ShipID, cascadeDelete: false)
                .ForeignKey("dbo.Shipyards", t => t.Departure_ShipyardID, cascadeDelete: false)
                .ForeignKey("dbo.Shipyards", t => t.Arrival_ShipyardID, cascadeDelete: false)
                .Index(t => t.ShipID)
                .Index(t => t.ContainerID)
                .Index(t => t.Departure_ShipyardID)
                .Index(t => t.Arrival_ShipyardID);
            
            CreateTable(
                "dbo.Ships",
                c => new
                    {
                        ShipID = c.Int(nullable: false, identity: true),
                        Ship_Name = c.String(nullable: false),
                        Ship_Description = c.String(),
                        Max_Containers = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ShipID);
            
            CreateTable(
                "dbo.Shipyards",
                c => new
                    {
                        ShipyardID = c.Int(nullable: false, identity: true),
                        Shipyard_Name = c.String(),
                        Shipyard_Location = c.String(),
                    })
                .PrimaryKey(t => t.ShipyardID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.ShippingSchedules", "Arrival_ShipyardID", "dbo.Shipyards");
            DropForeignKey("dbo.ShippingSchedules", "Departure_ShipyardID", "dbo.Shipyards");
            DropForeignKey("dbo.ShippingSchedules", "ShipID", "dbo.Ships");
            DropForeignKey("dbo.ShippingSchedules", "ContainerID", "dbo.Containers");
            DropIndex("dbo.ShippingSchedules", new[] { "Arrival_ShipyardID" });
            DropIndex("dbo.ShippingSchedules", new[] { "Departure_ShipyardID" });
            DropIndex("dbo.ShippingSchedules", new[] { "ContainerID" });
            DropIndex("dbo.ShippingSchedules", new[] { "ShipID" });
            DropTable("dbo.Shipyards");
            DropTable("dbo.Ships");
            DropTable("dbo.ShippingSchedules");
            DropTable("dbo.Containers");
        }
    }
}
