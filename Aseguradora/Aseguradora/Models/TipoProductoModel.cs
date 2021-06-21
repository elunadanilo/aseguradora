using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Aseguradora.Models
{
    public class TipoProductoModel
    {
        [Display(Name = "Id Tipo Producto")]
        public int IdTipoProducto { get; set; }

        [Display(Name = "Id Aseguradora")]
        public int IdAseguradora { get; set; }

        [Display(Name = "Id Producto")]
        [Required]
        public int IdProducto { get; set; }

        [Display(Name = "Descripción")]
        [Required]
        public string Descripcion { get; set; }
    }
}