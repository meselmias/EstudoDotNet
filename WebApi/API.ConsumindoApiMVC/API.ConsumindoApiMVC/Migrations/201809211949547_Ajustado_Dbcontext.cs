namespace API.ConsumindoApiMVC.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Ajustado_Dbcontext : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Marcas",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Nome = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Produtos",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Nome = c.String(),
                        Preco = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Marca_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Marcas", t => t.Marca_Id)
                .Index(t => t.Marca_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Produtos", "Marca_Id", "dbo.Marcas");
            DropIndex("dbo.Produtos", new[] { "Marca_Id" });
            DropTable("dbo.Produtos");
            DropTable("dbo.Marcas");
        }
    }
}
