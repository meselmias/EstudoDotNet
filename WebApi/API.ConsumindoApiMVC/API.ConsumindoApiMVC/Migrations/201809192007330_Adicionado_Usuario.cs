namespace API.ConsumindoApiMVC.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Adicionado_Usuario : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Usuario",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Nome = c.String(maxLength: 50),
                        Email = c.String(maxLength: 50),
                        Login = c.String(maxLength: 10),
                        Senha = c.String(maxLength: 8),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Usuario");
        }
    }
}
