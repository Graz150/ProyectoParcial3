namespace ProyectoParcial3.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<ProyectoParcial3.Models.ApplicationDbContext>
    {
        public Configuration()
        { 
            AutomaticMigrationsEnabled = true;
            AutomaticMigrationDataLossAllowed = true;
        }

        protected override void Seed(ProyectoParcial3.Models.ApplicationDbContext context)
        {
            context.Roles.AddOrUpdate(x => x.Id,
                 new Microsoft.AspNet.Identity.EntityFramework.IdentityRole { Id = "1", Name = "Administrador" },
                 new Microsoft.AspNet.Identity.EntityFramework.IdentityRole { Id = "2", Name = "Docente" },
                 new Microsoft.AspNet.Identity.EntityFramework.IdentityRole { Id = "3", Name = "Alumno" }
                 );



            context.Ciudad.AddOrUpdate(

              new Models.Ciudad { ID = 1, Nombre = "Bogota" },
              new Models.Ciudad { ID = 2, Nombre = "Bucaramanga" }






                );
        }
    }
}
 