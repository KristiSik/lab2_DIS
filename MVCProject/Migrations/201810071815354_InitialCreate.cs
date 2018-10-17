namespace MVCProject.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Transportations",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        CityFrom = c.String(),
                        CityTo = c.String(),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.Transports",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Number = c.String(),
                        DriverName = c.String(),
                        Transportation_ID = c.Int(),
                        TransportCompany_ID = c.Int(),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Transportations", t => t.Transportation_ID)
                .ForeignKey("dbo.TransportCompanies", t => t.TransportCompany_ID)
                .Index(t => t.Transportation_ID)
                .Index(t => t.TransportCompany_ID);
            
            CreateTable(
                "dbo.TransportCompanies",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.ID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Transports", "TransportCompany_ID", "dbo.TransportCompanies");
            DropForeignKey("dbo.Transports", "Transportation_ID", "dbo.Transportations");
            DropIndex("dbo.Transports", new[] { "TransportCompany_ID" });
            DropIndex("dbo.Transports", new[] { "Transportation_ID" });
            DropTable("dbo.TransportCompanies");
            DropTable("dbo.Transports");
            DropTable("dbo.Transportations");
        }
    }
}
