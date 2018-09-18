namespace ReservarSalaoFestas.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class agenda : DbMigration
    {
        public override void Up()
        {
            DropPrimaryKey("dbo.Agenda");
            AddColumn("dbo.Agenda", "AgendaId", c => c.Int(nullable: false, identity: true));
            AddColumn("dbo.Agenda", "DataReserva", c => c.DateTime(nullable: false));
            AddPrimaryKey("dbo.Agenda", "AgendaId");
            DropColumn("dbo.Agenda", "DataReservaId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Agenda", "DataReservaId", c => c.DateTime(nullable: false));
            DropPrimaryKey("dbo.Agenda");
            DropColumn("dbo.Agenda", "DataReserva");
            DropColumn("dbo.Agenda", "AgendaId");
            AddPrimaryKey("dbo.Agenda", "DataReservaId");
        }
    }
}
