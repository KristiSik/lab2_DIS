namespace MVCProject.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class I : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Transports", "TransportCompanyId", "dbo.TransportCompanies");
            DropIndex("dbo.Transports", new[] { "TransportCompanyId" });
            AlterColumn("dbo.Transports", "TransportCompanyId", c => c.Int());
            CreateIndex("dbo.Transports", "TransportCompanyId");
            AddForeignKey("dbo.Transports", "TransportCompanyId", "dbo.TransportCompanies", "ID");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Transports", "TransportCompanyId", "dbo.TransportCompanies");
            DropIndex("dbo.Transports", new[] { "TransportCompanyId" });
            AlterColumn("dbo.Transports", "TransportCompanyId", c => c.Int(nullable: false));
            CreateIndex("dbo.Transports", "TransportCompanyId");
            AddForeignKey("dbo.Transports", "TransportCompanyId", "dbo.TransportCompanies", "ID", cascadeDelete: true);
        }
    }
}
