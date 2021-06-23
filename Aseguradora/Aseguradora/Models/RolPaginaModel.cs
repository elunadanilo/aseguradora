using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Aseguradora.Models
{
    public class RolPaginaModel
    {
        [Display(Name = "Id Rol Pagina")]
        public int IdRolPagina { get; set; }
        [Required]
        public int IdRol { get; set; }
        [Required]
        public int IdPagina { get; set; }
        public int BHabilitado { get; set; }
        //Propiedades adicionales
        [Display(Name = "Nombre Rol")]
        public string nombreRol { get; set; }
        [Display(Name = "Nombre Mensaje")]
        public string nombreMensaje { get; set; }
    }
}