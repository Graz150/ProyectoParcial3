using PagedList;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using System.Web.Security;

namespace ProyectoParcial3.Models.ViewModels
{
    public class UserViewModel
    {
        public string UserId { get; set; }
        public IEnumerable<ApplicationUser> ListaUsuarios { get; set; }
        public IPagedList<ApplicationUser> ListaUsuariosP { get; set; }
        public IPagedList<ApplicationUser> ListaRoles { get; set; }
        public ApplicationUser Usuario { get; set; }
        public string Message { get; set; }

        public Dictionary<string, string> RolesByUsuario { get; set; } = new Dictionary<string, string>();


        /// <summary>
        /// Trae todos los usuarios que correspondan a un role
        /// </summary>
        public UserViewModel(ApplicationDbContext db, string role)
        {
            this.ListaUsuarios = getUsersByRoleId(role, db);
        }
        /// <summary>
        /// Para crear y listar todos los usuarios
        /// </summary>
        public UserViewModel(ApplicationDbContext db)
        {
            //Para crear y listar todos los usuarios
            Message = null;
            ListaUsuarios = db.Users.ToList();
        }
        /// <summary>
        /// Constructor vacío por siakas XD
        /// </summary>

        public UserViewModel()
        {

        }


        /// <summary>
        /// Trae todos los usuarios que correspondan a un Role Especificado
        /// </summary>
        private IEnumerable<ApplicationUser> getUsersByRoleId(string role, ApplicationDbContext db)
        {
            var usuarios = db.Users.Where(user => user.Roles.All(urm => urm.RoleId == role));
            return usuarios;
        }
        /// <summary>
        /// Trae todos los usuarios que correspondan a un Role con un ordenamiento determinado
        /// </summary>
        public UserViewModel(ApplicationDbContext db, string role, string sortOrder, string searchString, int? page)
        {
            this.ListaUsuariosP = getUsersByRoleId(role, db, sortOrder, searchString, page);
        }
        /// <summary>
        ///Trae los usuarios de un rol especifico, ordenado por una columna o por id los cuales pertenecen a una pagina especifica
        /// del paginado o se filtran por lo que se haya buscando en el cuadro de busqueda
        /// </summary>
        private IPagedList<ApplicationUser> getUsersByRoleId(string role, ApplicationDbContext db, string sortOrder, string searchString, int? page)
        {
            var usuarios = db.Users.Where(user => user.Roles.All(urm => urm.RoleId == role));

            if (!string.IsNullOrEmpty(searchString))
            {
                usuarios = usuarios.Where(s => s.Nombres.Contains(searchString) || s.Apellidos.Contains(searchString));
            }

            switch (sortOrder)
            {
                case "Nombre":
                    usuarios = usuarios.OrderBy(s => s.Nombres);
                    break;
                case "Nombres_desc":
                    usuarios = usuarios.OrderByDescending(s => s.Nombres);
                    break;
                case "Apellido":
                    usuarios = usuarios.OrderBy(s => s.Apellidos);
                    break;
                case "Apellidos_desc":
                    usuarios = usuarios.OrderByDescending(s => s.Apellidos);
                    break;
                case "Email":
                    usuarios = usuarios.OrderBy(s => s.Email);
                    break;
                case "Email_desc":
                    usuarios = usuarios.OrderByDescending(s => s.Email);
                    break;
                case "Username":
                    usuarios = usuarios.OrderBy(s => s.UserName);
                    break;
                case "Username_desc":
                    usuarios = usuarios.OrderByDescending(s => s.UserName);
                    break;
                default:
                    usuarios = usuarios.OrderBy(s => s.Id);
                    break;
            }

            int pageSize = 8;
            int pageNumber = (page ?? 1);
            return usuarios.ToPagedList(pageNumber, pageSize);
        }
    }
}