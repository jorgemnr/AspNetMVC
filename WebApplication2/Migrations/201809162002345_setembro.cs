namespace ReservarSalaoFestas.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class setembro : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Clientes", "Senha", c => c.String(nullable: false, maxLength: 100));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Clientes", "Senha");
        }
    }
}
