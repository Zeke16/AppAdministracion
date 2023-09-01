using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace AppAdministracion.Models
{
    public class Departamentos
    {
        [Key]
        public int id_departamento { get; set; }
        [Required]
        [StringLength(50)]
        [DisplayName("Nombre del departamento")]
        public string nombre { get; set; }
        [Required]
        [StringLength(250)]
        [DisplayName("Descripcion del departamento")]
        public string descripcion { get; set; }
    }
}
