using System.Data.Entity;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System;

namespace ReservarSalaoFestas.Models
{
    // É possível adicionar dados do perfil do usuário adicionando mais propriedades na sua classe ApplicationUser, visite https://go.microsoft.com/fwlink/?LinkID=317594 para obter mais informações.
    public class ApplicationUser : IdentityUser
    {
        [StringLength(100)]
        public string NomeMorador { get; set; }
        [StringLength(2)]
        public string Apto { get; set; }

        public async Task<ClaimsIdentity> GenerateUserIdentityAsync(UserManager<ApplicationUser> manager)
        {
            // Observe que o authenticationType deve corresponder àquele definido em CookieAuthenticationOptions.AuthenticationType
            var userIdentity = await manager.CreateIdentityAsync(this, DefaultAuthenticationTypes.ApplicationCookie);
            // Adicionar declarações de usuário personalizado aqui
            return userIdentity;
        }

        public static implicit operator ApplicationUser(string v)
        {
            throw new NotImplementedException();
        }
    }

    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext()
            : base("name=SlFestasDb", throwIfV1Schema: false)
        {
        }

        public static ApplicationDbContext Create()
        {
            return new ApplicationDbContext();
        }

        //public DbSet<Clientes> Clientes { get; set; }
        public DbSet<Agenda> Agenda { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            //Deixar o IdentityDbContext criar os mapeamentos padrão
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<IdentityUser>()
                   .ToTable("Usuarios")
                   .Property(p => p.Id)
                   .HasColumnName("UsuarioId");

            modelBuilder.Entity<ApplicationUser>()
                .ToTable("Usuarios")
                .Property(p => p.Id)
                .HasColumnName("UsuarioId");

            modelBuilder.Entity<IdentityUserRole>()
                .ToTable("UsuarioPapel");

            modelBuilder.Entity<IdentityUserLogin>()
                .ToTable("Logins");

            modelBuilder.Entity<IdentityUserClaim>()
                .ToTable("Claims");

            modelBuilder.Entity<IdentityRole>()
                         .ToTable("Papeis");

            //Criar UniqueKey por data de Reserva
            modelBuilder.Entity<Agenda>()
                .HasIndex(c => c.DataReserva)
                .IsUnique();
        }
    }
}

/*

Hospedar no https://www.gearhost.com
    
Resetar as Migrations:
----------------------
1 - Excluir pasta migrations do projeto
2 - Ecluir a tabela __MigrationHistory do seu banco
3 - Abrir o Package Manager Console
3 - Rodar o comando: Enable-Migrations (Opcional: -EnableAutomaticMigrations -Force)
4 - Rodar o comando: Add-Migration Inicial
5 - Rodar o comando: Update-Database

Resetar BD - From Package Manager Console run:
----------------------
sqllocaldb.exe stop
sqllocaldb.exe delete
sqllocaldb start

*/
