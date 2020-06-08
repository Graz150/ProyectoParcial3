using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;

namespace ProyectoParcial3.Models
{
    // Para agregar datos de perfil del usuario, agregue más propiedades a su clase ApplicationUser. Visite https://go.microsoft.com/fwlink/?LinkID=317594 para obtener más información.
    public class ApplicationUser : IdentityUser
    {
        [Required]
        [StringLength(40, ErrorMessage = "Los nombres no pueden tener más de 40 caracteres")]
        [Display(Name = "Nombres")]
        public string Nombres { get; set; }
        [Required]
        [StringLength(40, ErrorMessage = "Los nombres no puede tener más de 40 caracteres")]
        [Display(Name = "Apellidos")]
        public string Apellidos { get; set; }

        [Required]
        [StringLength(40, ErrorMessage = "La identificacion no puede tener más de 40 caracteres")]
        [Display(Name = "Identificacion")]
        public string Identificacion { get; set; }

        [ForeignKey("Ciudad")]
        [Display(Name = "Ciudad")]
        public int CiudadId { get; set; }
        public Ciudad Ciudad { get; set; }
        public async Task<ClaimsIdentity> GenerateUserIdentityAsync(UserManager<ApplicationUser> manager)
        {
            // Tenga en cuenta que el valor de authenticationType debe coincidir con el definido en CookieAuthenticationOptions.AuthenticationType
            var userIdentity = await manager.CreateIdentityAsync(this, DefaultAuthenticationTypes.ApplicationCookie);
            // Agregar aquí notificaciones personalizadas de usuario
            return userIdentity;
        }
    }

    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext()
            : base("DefaultConnection", throwIfV1Schema: false)
        {
        }

        public static ApplicationDbContext Create()
        {
            return new ApplicationDbContext();
        }
         

        public System.Data.Entity.DbSet<ProyectoParcial3.Models.Afirmacion> Afirmacions { get; set; }

        public System.Data.Entity.DbSet<ProyectoParcial3.Models.Competencia> Competencias { get; set; }
        
    

        public System.Data.Entity.DbSet<ProyectoParcial3.Models.Programa> Programas { get; set; }

        public System.Data.Entity.DbSet<ProyectoParcial3.Models.Examen> Examen { get; set; }

        public System.Data.Entity.DbSet<ProyectoParcial3.Models.Opcion> Opcions { get; set; }

        public System.Data.Entity.DbSet<ProyectoParcial3.Models.Pregunta> Preguntas { get; set; }

        public System.Data.Entity.DbSet<ProyectoParcial3.Models.PreguntaEstudiante> PreguntaEstudiantes { get; set; }

        public System.Data.Entity.DbSet<ProyectoParcial3.Models.PreguntaExamen> PreguntaExamen { get; set; }

        public System.Data.Entity.DbSet<ProyectoParcial3.Models.Ciudad> Ciudad { get; set; }

        public System.Data.Entity.DbSet<ProyectoParcial3.Models.Resultado> Resultadoes { get; set; }

        



    }
}