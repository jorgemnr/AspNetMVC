using System.Data.Entity;

namespace ReservarSalaoFestas.Models
{
    public class ReservarSalaoFestasContext : DbContext
    {
        // You can add custom code to this file. Changes will not be overwritten.
        // 
        // If you want Entity Framework to drop and regenerate your database
        // automatically whenever you change your model schema, please use data migrations.
        // For more information refer to the documentation:
        // http://msdn.microsoft.com/en-us/data/jj591621.aspx

        //Hospedar no https://www.gearhost.com

        public ReservarSalaoFestasContext() : base("name=ReservarSalaoFestasContext")
        {
        }

        public System.Data.Entity.DbSet<ReservarSalaoFestas.Models.Clientes> Clientes { get; set; }
        public System.Data.Entity.DbSet<ReservarSalaoFestas.Models.Agenda> Agenda { get; set; }

    }
}
