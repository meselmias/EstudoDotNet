namespace API.ConsumindoApiMVC.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AlteradoTipopropriedadeNome : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Marcas", "Nome", c => c.String());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Marcas", "Nome", c => c.Int(nullable: false));
        }
    }
}
