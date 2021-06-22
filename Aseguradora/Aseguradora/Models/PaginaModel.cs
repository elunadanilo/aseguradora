using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Aseguradora.Models
{
    public class PaginaModel
    {
        [Display(Name = "Id Pagina")]
        public int IdPagina { get; set; }
        [Required]
        [Display(Name = "Titulo del link")]
        public string Mensaje { get; set; }
        [Required]
        [Display(Name = "Nombre de la accion")]
        public string Accion { get; set; }
        [Required]
        [Display(Name = "Nombre del Controlador")]
        public string Controlador { get; set; }
        public int BHabilitado { get; set; }

        //Propiedad adicional

        public string mensajeFiltro { get; set; }
    }
}