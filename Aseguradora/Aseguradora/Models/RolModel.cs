using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Aseguradora.Models
{
    public class RolModel
    {
        [Display(Name = "Id Rol")]
        public int IdRol { get; set; }
        [Required]
        [Display(Name = "Nombre Rol")]

        public string Nombre { get; set; }
        [Required]
        [Display(Name = "Descripcion Rol")]
        public string Descripcion { get; set; }

        public int BHabilitado { get; set; }
    }
}