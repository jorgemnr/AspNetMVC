namespace ReservarSalaoFestas.Migrations
{
    using ReservarSalaoFestas.Models;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Data.Entity.Validation;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<ReservarSalaoFestas.Models.ApplicationDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(ReservarSalaoFestas.Models.ApplicationDbContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data.

            //Incluir usuario / cliente
            var cliente = new ApplicationUser
            {
                Email = "email@email.com",
                NomeMorador = "Nome Morador",
                Apto = "53",
                UserName = "email@email.com"
            };

            //var cli = context.Users.FirstOrDefaultAsync(x => x.UserName == "email@email.com").ToString();
            var cli = (from d in context.Users
                       where d.UserName == "email@email.com"
                       select d.Id).FirstOrDefault().ToString();
            if (cli == null)
            {
                var usu = context.Users.Add(cliente);
                cli = usu.Id.FirstOrDefault().ToString();
            }


            //Incluir Agenda
            var Agendas = new List<Agenda>();
            //
            var Agenda1 = context.Agenda.FirstOrDefaultAsync(x => x.DataReserva == System.DateTime.Parse("27/10/2018")).ToString();
            if (Agenda1 == null)
            {
                Agendas.Add(new Agenda()
                {
                    DataReserva = System.DateTime.Parse("27/10/2018"),
                    Evento = "Festa Aniversário",
                    QtdePessoas = 10,
                    UserId = cli
                });
            }
            //
            var Agenda2 = context.Agenda.FirstOrDefaultAsync(x => x.DataReserva == System.DateTime.Parse("27/11/2018")).ToString();
            if (Agenda2 == null)
            {
                Agendas.Add(new Agenda()
                {
                    DataReserva = System.DateTime.Parse("27/11/2018"),
                    Evento = "Churrasco Família",
                    QtdePessoas = 20,
                    UserId = cli
                });
            }
            //
            var Agenda3 = context.Agenda.FirstOrDefaultAsync(x => x.DataReserva == System.DateTime.Parse("27/12/2018")).ToString();
            if (Agenda3 == null)
            {
                Agendas.Add(new Agenda()
                {
                    DataReserva = System.DateTime.Parse("27/12/2018"),
                    Evento = "Comemoração Vitória",
                    QtdePessoas = 30,
                    UserId = cli
                });
            }
            //
            context.Agenda.AddRange(Agendas);
        }
    }
}
