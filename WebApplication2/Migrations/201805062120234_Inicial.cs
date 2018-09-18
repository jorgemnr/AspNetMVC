namespace ReservarSalaoFestas.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Inicial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Agenda",
                c => new
                    {
                        DataReservaId = c.DateTime(nullable: false),
                        Evento = c.String(),
                        QtdePessoas = c.Int(nullable: false),
                        ClienteId = c.Int(nullable: false),
                        DataAtualizacao = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.DataReservaId)
                .ForeignKey("dbo.Clientes", t => t.ClienteId, cascadeDelete: true)
                .Index(t => t.ClienteId);
            
            CreateTable(
                "dbo.Clientes",
                c => new
                    {
                        ClienteId = c.Int(nullable: false, identity: true),
                        Nome = c.String(nullable: false, maxLength: 256),
                        Celular = c.String(maxLength: 15),
                        Apto = c.String(nullable: false, maxLength: 2),
                        DataAtualizacao = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.ClienteId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Agenda", "ClienteId", "dbo.Clientes");
            DropIndex("dbo.Agenda", new[] { "ClienteId" });
            DropTable("dbo.Clientes");
            DropTable("dbo.Agenda");
        }
    }
}
