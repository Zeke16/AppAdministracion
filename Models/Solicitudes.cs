using Microsoft.AspNetCore.Identity;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace AppAdministracion.Models
{
    public class Solicitudes
    {
        [Key]
        public int id_solicitud { get; set; }
        [Required]
        [StringLength(250)]
        [DisplayName("Descripcion de la solicitud")]
        public string descripcion { get; set; }
        [DisplayName("Estado de la solicitud")]
        public int estado { get; set; }
        [DisplayName("Usuario que solicito")]
        public string id_user { get; set; }
        public virtual IEnumerable<IdentityUser> Usuarios { get; set; }
    }
}
