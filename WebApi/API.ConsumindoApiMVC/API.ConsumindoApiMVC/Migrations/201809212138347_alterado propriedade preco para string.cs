namespace API.ConsumindoApiMVC.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class alteradopropriedadeprecoparastring : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Produtos", "Preco", c => c.String());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Produtos", "Preco", c => c.Decimal(nullable: false, precision: 18, scale: 2));
        }
    }
}
