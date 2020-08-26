namespace OdeAComida.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.AnaliseRestaurantes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Nota = c.Int(nullable: false),
                        Corpo = c.String(nullable: false, maxLength: 1024),
                        NomeAnalista = c.String(maxLength: 80),
                        RestauranteId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Restaurantes", t => t.RestauranteId, cascadeDelete: true)
                .Index(t => t.RestauranteId);
            
            CreateTable(
                "dbo.PerfilUsuario",
                c => new
                    {
                        UserId = c.Int(nullable: false, identity: true),
                        NomeUsuario = c.String(maxLength: 80),
                        RestauranteFavorito = c.String(maxLength: 80),
                    })
                .PrimaryKey(t => t.UserId);
            
            CreateTable(
                "dbo.Restaurantes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Nome = c.String(),
                        Cidade = c.String(),
                        Pais = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.AnaliseRestaurantes", "RestauranteId", "dbo.Restaurantes");
            DropIndex("dbo.AnaliseRestaurantes", new[] { "RestauranteId" });
            DropTable("dbo.Restaurantes");
            DropTable("dbo.PerfilUsuario");
            DropTable("dbo.AnaliseRestaurantes");
        }
    }
}
