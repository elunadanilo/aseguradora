using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Aseguradora.Models
{
    public class MunicipioModel
    {
        [Display(Name = "Departamento")]
        public string Departamento { get; set; }

        [Display(Name = "Municipio")]
        [Required]
        [StringLength(2, ErrorMessage = "La longitud maxima es de 2")]
        public string Municipio { get; set; }

        [Display(Name = "Descripcion")]
        [Required]
        [StringLength(50, ErrorMessage = "La longitud maxima es de 50")]
        public string Descripcion { get; set; }
    }
}