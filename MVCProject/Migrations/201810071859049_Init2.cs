namespace MVCProject.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Init2 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Transports", "Transportation_ID", "dbo.Transportations");
            DropForeignKey("dbo.Transports", "TransportCompany_ID", "dbo.TransportCompanies");
            DropIndex("dbo.Transports", new[] { "Transportation_ID" });
            DropIndex("dbo.Transports", new[] { "TransportCompany_ID" });
            RenameColumn(table: "dbo.Transports", name: "Transportation_ID", newName: "TransportationId");
            RenameColumn(table: "dbo.Transports", name: "TransportCompany_ID", newName: "TransportCompanyId");
            AlterColumn("dbo.Transports", "TransportationId", c => c.Int(nullable: false));
            AlterColumn("dbo.Transports", "TransportCompanyId", c => c.Int(nullable: false));
            CreateIndex("dbo.Transports", "TransportationId");
            CreateIndex("dbo.Transports", "TransportCompanyId");
            AddForeignKey("dbo.Transports", "TransportationId", "dbo.Transportations", "ID", cascadeDelete: true);
            AddForeignKey("dbo.Transports", "TransportCompanyId", "dbo.TransportCompanies", "ID", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Transports", "TransportCompanyId", "dbo.TransportCompanies");
            DropForeignKey("dbo.Transports", "TransportationId", "dbo.Transportations");
            DropIndex("dbo.Transports", new[] { "TransportCompanyId" });
            DropIndex("dbo.Transports", new[] { "TransportationId" });
            AlterColumn("dbo.Transports", "TransportCompanyId", c => c.Int());
            AlterColumn("dbo.Transports", "TransportationId", c => c.Int());
            RenameColumn(table: "dbo.Transports", name: "TransportCompanyId", newName: "TransportCompany_ID");
            RenameColumn(table: "dbo.Transports", name: "TransportationId", newName: "Transportation_ID");
            CreateIndex("dbo.Transports", "TransportCompany_ID");
            CreateIndex("dbo.Transports", "Transportation_ID");
            AddForeignKey("dbo.Transports", "TransportCompany_ID", "dbo.TransportCompanies", "ID");
            AddForeignKey("dbo.Transports", "Transportation_ID", "dbo.Transportations", "ID");
        }
    }
}
