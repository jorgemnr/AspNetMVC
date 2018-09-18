namespace ReservarSalaoFestas.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class dataatualizacao1 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Agenda", "DataAtualizacao", c => c.DateTime(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Agenda", "DataAtualizacao");
        }
    }
}
