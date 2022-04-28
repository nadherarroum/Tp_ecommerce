namespace TP_Ecommerce.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Categorie",
                c => new
                    {
                        IDCat = c.Int(nullable: false, identity: true),
                        NameCat = c.String(),
                    })
                .PrimaryKey(t => t.IDCat);
            
            CreateTable(
                "dbo.Marque",
                c => new
                    {
                        IDMrq = c.Int(nullable: false, identity: true),
                        NameMrq = c.String(),
                    })
                .PrimaryKey(t => t.IDMrq);
            
            CreateTable(
                "dbo.Produit",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        CategorieID = c.Int(nullable: false),
                        MarqueID = c.Int(nullable: false),
                        ProductName = c.String(),
                        Price = c.Double(nullable: false),
                        qte = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Categorie", t => t.CategorieID, cascadeDelete: true)
                .ForeignKey("dbo.Marque", t => t.MarqueID, cascadeDelete: true)
                .Index(t => t.CategorieID)
                .Index(t => t.MarqueID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Produit", "MarqueID", "dbo.Marque");
            DropForeignKey("dbo.Produit", "CategorieID", "dbo.Categorie");
            DropIndex("dbo.Produit", new[] { "MarqueID" });
            DropIndex("dbo.Produit", new[] { "CategorieID" });
            DropTable("dbo.Produit");
            DropTable("dbo.Marque");
            DropTable("dbo.Categorie");
        }
    }
}
