namespace ComputerReparationStore.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class init : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Customers",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        FirstName = c.String(),
                        LastName = c.String(),
                        Email = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.ListAllParts",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Brand = c.String(),
                        Name = c.String(),
                        Price = c.Decimal(nullable: false, precision: 18, scale: 2),
                        InStock = c.Boolean(),
                        Discriminator = c.String(nullable: false, maxLength: 128),
                        Part_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.ListAllParts", t => t.Part_Id)
                .Index(t => t.Part_Id);
            
            CreateTable(
                "dbo.ReparationOrders",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        StartDate = c.DateTime(nullable: false),
                        EndDate = c.DateTime(nullable: false),
                        Status = c.Int(nullable: false),
                        Customer_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Customers", t => t.Customer_Id)
                .Index(t => t.Customer_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.ReparationOrders", "Customer_Id", "dbo.Customers");
            DropForeignKey("dbo.ListAllParts", "Part_Id", "dbo.ListAllParts");
            DropIndex("dbo.ReparationOrders", new[] { "Customer_Id" });
            DropIndex("dbo.ListAllParts", new[] { "Part_Id" });
            DropTable("dbo.ReparationOrders");
            DropTable("dbo.ListAllParts");
            DropTable("dbo.Customers");
        }
    }
}
