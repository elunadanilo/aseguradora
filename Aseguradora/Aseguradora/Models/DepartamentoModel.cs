using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Aseguradora.Models
{
    public class DepartamentoModel
    {
        [Display(Name = "Departamento")]
        public string Departamento { get; set; }

        [Display(Name = "Nombre Departamento")]
        [Required]
        [StringLength(30, ErrorMessage = "La longitud maxima es de 30")]
        public string Nombre { get; set; }
    }
}