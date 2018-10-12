using ReservarSalaoFestas.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Data;
using System.Globalization;
using System.Threading.Tasks;

namespace ReservarSalaoFestas
{
    public class SemearDados
    {
        public SemearDados()
        {
            using (ApplicationDbContext db = new ApplicationDbContext())
            {
                /***********************************************
                //1-Criar usuario Emmail: morador@email.com / senha: senha / Nome: Nome Morador / Apto: 53
                //2-Criar agendas
                **************************************************/
                string cli;
                DateTime Data;
                //
                try
                {
                    cli = (from d in db.Users
                           where d.UserName == "morador@email.com"
                           select d.Id).FirstOrDefault().ToString();
                }
                catch (System.Exception)
                {
                    cli = null;
                }

                if (cli != null)
                {
                    //Incluir Agenda
                    var Agendas = new List<Agenda>();
                    //
                    Data = DateTime.ParseExact("27/10/2018", "dd/MM/yyyy", CultureInfo.InvariantCulture);
                    var Agenda1 = db.Agenda.Where(x => x.DataReserva == Data).Count();
                    if (Agenda1 == 0)
                    {
                        Agendas.Add(new Agenda()
                        {
                            DataReserva = Data,
                            Evento = "Festa Aniversário",
                            QtdePessoas = 10,
                            UserId = cli
                        });
                    }
                    //
                    Data = DateTime.ParseExact("27/11/2018", "dd/MM/yyyy", CultureInfo.InvariantCulture);
                    var Agenda2 = db.Agenda.Where(x => x.DataReserva == Data).Count();
                    if (Agenda2 == 0)
                    {
                        Agendas.Add(new Agenda()
                        {
                            DataReserva = Data,
                            Evento = "Churrasco Família",
                            QtdePessoas = 20,
                            UserId = cli
                        });
                    }
                    //
                    Data = DateTime.ParseExact("27/12/2018", "dd/MM/yyyy", CultureInfo.InvariantCulture);
                    var Agenda3 = db.Agenda.Where(x => x.DataReserva == Data).Count();
                    if (Agenda3 == 0)
                    {
                        Agendas.Add(new Agenda()
                        {
                            DataReserva = Data,
                            Evento = "Comemoração Vitória",
                            QtdePessoas = 30,
                            UserId = cli
                        });
                    }
                    //
                    if (Agendas.Count() > 0)
                    {
                        db.Agenda.AddRange(Agendas);
                        db.SaveChanges();
                    }
                }
                /*************************************/
                //1-Criar usuario ciclano@email.com
                //2-Criar agendas
                /*************************************/
                ApplicationUser cliente = new ApplicationUser
                {
                    Email = "ciclano@email.com",
                    NomeMorador = "Ciclano da Silva",
                    Apto = "12",
                    UserName = "ciclano@email.com",
                };

                try
                {
                    cli = (from d in db.Users
                           where d.UserName == "ciclano@email.com"
                           select d.Id).FirstOrDefault().ToString();
                }
                catch (System.Exception)
                {
                    cli = null;
                }

                if (cli == null)
                {
                    db.Users.Add(cliente);
                    db.SaveChanges();
                    cli = cliente.Id;
                }

                //Incluir Agenda
                var AgendasCiclano = new List<Agenda>();
                //
                Data = DateTime.ParseExact("27/07/2018", "dd/MM/yyyy", CultureInfo.InvariantCulture);
                var AgendaCiclano1 = db.Agenda.Where(x => x.DataReserva == Data).Count();
                if (AgendaCiclano1 == 0)
                {
                    AgendasCiclano.Add(new Agenda()
                    {
                        DataReserva = Data,
                        Evento = "Assembleia Pintura Condomínio",
                        QtdePessoas = 30,
                        UserId = cli
                    });
                }
                //
                Data = DateTime.ParseExact("27/08/2018", "dd/MM/yyyy", CultureInfo.InvariantCulture);
                var AgendaCiclano2 = db.Agenda.Where(x => x.DataReserva == Data).Count();
                if (AgendaCiclano2 == 0)
                {
                    AgendasCiclano.Add(new Agenda()
                    {
                        DataReserva = Data,
                        Evento = "Churrasco Noivado Filha",
                        QtdePessoas = 35,
                        UserId = cli
                    });
                }

                if (AgendasCiclano.Count() > 0)
                {
                    db.Agenda.AddRange(AgendasCiclano);
                    db.SaveChanges();
                }
            }
        }
    }
}