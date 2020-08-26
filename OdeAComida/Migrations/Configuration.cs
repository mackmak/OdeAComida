namespace OdeAComida.Migrations
{
    using OdeAComida.Models;
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;
    using System.Web.Security;
    using WebMatrix.WebData;

    internal sealed class Configuration : DbMigrationsConfiguration<OdeAComida.Models.OdeAComidaDb>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(OdeAComida.Models.OdeAComidaDb context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data. E.g.
            //
            //    context.People.AddOrUpdate(
            //      p => p.FullName,
            //      new Person { FullName = "Andrew Peters" },
            //      new Person { FullName = "Brice Lambson" },
            //      new Person { FullName = "Rowan Miller" }
            //    );
            //
            context.Restaurantes.AddOrUpdate(r => r.Nome,
               new Restaurante { Nome = "Sabatino's", Cidade = "Baltimore", Pais = "USA" },
               new Restaurante { Nome = "Great Lake", Cidade = "Chicago", Pais = "USA" },
               new Restaurante
               {
                   Nome = "Smaka",
                   Cidade = "Gothenburg",
                   Pais = "Sweden",
                   Analises =
                       new List<AnaliseRestaurante> { 
                       new AnaliseRestaurante { Nota = 9, Corpo="Great food!", NomeAnalista="Scott" }
                   }
               });

          

            SeedMembership();

        }

        //definindo funções de usuário (admin, vendas, etc.)
        private void SeedMembership()
        {
            InicializarConexao.Inicializar();

            var funcoes = (SimpleRoleProvider)Roles.Provider;
            var adesao = (SimpleMembershipProvider)Membership.Provider;

            if (!funcoes.RoleExists("Admin")){
                funcoes.CreateRole("Admin");
            }

            if(adesao.GetUser("someguy", false) == null)
            {
                adesao.CreateUserAndAccount("someguy", "tantofaz");
            }
            if (!funcoes.GetRolesForUser("someguy").Contains("Admin"))
            {
                funcoes.AddUsersToRoles(new[] { "someguy" }, new[] {"admin"});
            }
        }
    }
}
