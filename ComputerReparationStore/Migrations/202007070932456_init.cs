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
                "dbo.PartListItems",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Brand = c.String(),
                        Name = c.String(),
                        Price = c.Decimal(nullable: false, precision: 18, scale: 2),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Parts",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        InStock = c.Boolean(nullable: false),
                        PartListItem_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.PartListItems", t => t.PartListItem_Id)
                .Index(t => t.PartListItem_Id);
            
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
            DropForeignKey("dbo.Parts", "PartListItem_Id", "dbo.PartListItems");
            DropIndex("dbo.ReparationOrders", new[] { "Customer_Id" });
            DropIndex("dbo.Parts", new[] { "PartListItem_Id" });
            DropTable("dbo.ReparationOrders");
            DropTable("dbo.Parts");
            DropTable("dbo.PartListItems");
            DropTable("dbo.Customers");
        }
    }
}
