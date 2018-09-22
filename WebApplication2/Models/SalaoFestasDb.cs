using System.Data.Entity;

namespace ReservarSalaoFestas.Models
{
    public class SlFestasDb : DbContext
    {
        // You can add custom code to this file. Changes will not be overwritten.
        // 
        // If you want Entity Framework to drop and regenerate your database
        // automatically whenever you change your model schema, please use data migrations.
        // For more information refer to the documentation:
        // http://msdn.microsoft.com/en-us/data/jj591621.aspx

        //Hospedar no https://www.gearhost.com

        public SlFestasDb() : base("name=SlFestasDb")
        {
        }

        public System.Data.Entity.DbSet<ReservarSalaoFestas.Models.Clientes> Clientes { get; set; }
        public System.Data.Entity.DbSet<ReservarSalaoFestas.Models.Agenda> Agenda { get; set; }


        //Criar UniqueKey por data de Reserva
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Agenda>()
                .HasIndex(c => c.DataReserva)
                .IsUnique();
        }
    }
}


/*
Resetar as Migrations:
----------------------
1 - Excluir pasta migrations do projeto
2 - Ecluir a tabela __MigrationHistory do seu banco
3 - Abrir o Package Manager Console
3 - Rodar o comando: Enable-Migrations (Opcional: -EnableAutomaticMigrations -Force)
4 - Rodar o comando: Add-Migration Inicial
5 - Rodar o comando: Update-Database
*/
