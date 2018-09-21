namespace API.ConsumindoApiMVC.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Adicionadopropriedadeemprodutos : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Produtos", "Marca_Id", "dbo.Marcas");
            DropIndex("dbo.Produtos", new[] { "Marca_Id" });
            RenameColumn(table: "dbo.Produtos", name: "Marca_Id", newName: "MarcaId");
            AlterColumn("dbo.Produtos", "MarcaId", c => c.Int(nullable: false));
            CreateIndex("dbo.Produtos", "MarcaId");
            AddForeignKey("dbo.Produtos", "MarcaId", "dbo.Marcas", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Produtos", "MarcaId", "dbo.Marcas");
            DropIndex("dbo.Produtos", new[] { "MarcaId" });
            AlterColumn("dbo.Produtos", "MarcaId", c => c.Int());
            RenameColumn(table: "dbo.Produtos", name: "MarcaId", newName: "Marca_Id");
            CreateIndex("dbo.Produtos", "Marca_Id");
            AddForeignKey("dbo.Produtos", "Marca_Id", "dbo.Marcas", "Id");
        }
    }
}
