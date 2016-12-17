namespace Mysolution_Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Initial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.countries",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        IdCountry = c.Int(nullable: false),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.exports",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Year = c.Int(nullable: false),
                        Export_blnUSD = c.Decimal(precision: 18, scale: 2),
                        country_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.countries", t => t.country_Id)
                .Index(t => t.country_Id);
            
            CreateTable(
                "dbo.gdps",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Year = c.Int(nullable: false),
                        GDP_blnUSD = c.Decimal(precision: 18, scale: 2),
                        country_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.countries", t => t.country_Id)
                .Index(t => t.country_Id);
            
            CreateTable(
                "dbo.gdpgrowths",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Year = c.Int(nullable: false),
                        GDPGrowth_percent = c.Decimal(precision: 18, scale: 2),
                        country_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.countries", t => t.country_Id)
                .Index(t => t.country_Id);
            
            CreateTable(
                "dbo.import1",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Year = c.Int(nullable: false),
                        Import_blnUSD = c.Decimal(precision: 18, scale: 2),
                        country_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.countries", t => t.country_Id)
                .Index(t => t.country_Id);
            
            CreateTable(
                "dbo.inflations",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Year = c.Int(nullable: false),
                        Inflation_percent = c.Decimal(precision: 18, scale: 2),
                        country_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.countries", t => t.country_Id)
                .Index(t => t.country_Id);
            
            CreateTable(
                "dbo.national_debt",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Year = c.Int(nullable: false),
                        Debt_GDP_percent = c.Decimal(precision: 18, scale: 2),
                        country_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.countries", t => t.country_Id)
                .Index(t => t.country_Id);
            
            CreateTable(
                "dbo.populations",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Year = c.Int(nullable: false),
                        Population_mln = c.Decimal(precision: 18, scale: 2),
                        country_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.countries", t => t.country_Id)
                .Index(t => t.country_Id);
            
            CreateTable(
                "dbo.unemployments",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Year = c.Int(nullable: false),
                        Unemployment_percent = c.Decimal(precision: 18, scale: 2),
                        country_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.countries", t => t.country_Id)
                .Index(t => t.country_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.unemployments", "country_Id", "dbo.countries");
            DropForeignKey("dbo.populations", "country_Id", "dbo.countries");
            DropForeignKey("dbo.national_debt", "country_Id", "dbo.countries");
            DropForeignKey("dbo.inflations", "country_Id", "dbo.countries");
            DropForeignKey("dbo.import1", "country_Id", "dbo.countries");
            DropForeignKey("dbo.gdpgrowths", "country_Id", "dbo.countries");
            DropForeignKey("dbo.gdps", "country_Id", "dbo.countries");
            DropForeignKey("dbo.exports", "country_Id", "dbo.countries");
            DropIndex("dbo.unemployments", new[] { "country_Id" });
            DropIndex("dbo.populations", new[] { "country_Id" });
            DropIndex("dbo.national_debt", new[] { "country_Id" });
            DropIndex("dbo.inflations", new[] { "country_Id" });
            DropIndex("dbo.import1", new[] { "country_Id" });
            DropIndex("dbo.gdpgrowths", new[] { "country_Id" });
            DropIndex("dbo.gdps", new[] { "country_Id" });
            DropIndex("dbo.exports", new[] { "country_Id" });
            DropTable("dbo.unemployments");
            DropTable("dbo.populations");
            DropTable("dbo.national_debt");
            DropTable("dbo.inflations");
            DropTable("dbo.import1");
            DropTable("dbo.gdpgrowths");
            DropTable("dbo.gdps");
            DropTable("dbo.exports");
            DropTable("dbo.countries");
        }
    }
}
