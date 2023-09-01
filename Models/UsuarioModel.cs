using Microsoft.AspNetCore.Identity;

namespace AppAdministracion.Models
{
    public class UsuarioModel : IdentityUser
    {
        public string FullName { get; set; }
    }
}
