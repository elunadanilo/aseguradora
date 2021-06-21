using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Aseguradora.Models
{
    public class ProductoModel
    {
        [Display(Name = "Id Producto")]
        public int IdProducto { get; set; }

        [Display(Name = "Id Aseguradora")]
        public int IdAseguradora { get; set; }

        [Display(Name = "Descripción")]
        [Required]
        [StringLength(50, ErrorMessage = "La longitud maxima es de 50")]
        public string Descripcion { get; set; }
    }
}