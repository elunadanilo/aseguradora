using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Aseguradora.Models
{
    public class MarcaModel
    {
        [Display(Name = "Id Marca")]
        public int IdMarca { get; set; }

        [Display(Name = "Nombre")]
        [Required]
        [StringLength(50, ErrorMessage = "la longitud maxima es de 50")]
        public string Nombre { get; set; }
    }
}