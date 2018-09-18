namespace ReservarSalaoFestas.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class data : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Agenda", "DataAtualizacao");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Agenda", "DataAtualizacao", c => c.DateTime(nullable: false));
        }
    }
}
