using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Aseguradora.Models
{
    public class AseguradoraModel
    {
        [Display(Name = "Id Aseguradora")]
        public int IdAseguradora { get; set; }

        [Display(Name = "Nombre")]
        [Required]
        [StringLength(100, ErrorMessage = "La longitud maxima es de 100")]
        public string Nombre { get; set; }

        [Display(Name = "Departamento")]
        [Required]
        [StringLength(2, ErrorMessage = "La longitud maxima es de 2")]
        public string Departamento { get; set; }

        [Display(Name = "Municipio")]
        [Required]
        [StringLength(2, ErrorMessage = "La longitud maxima es de 2")]
        public string Municipio { get; set; }

        [Display(Name = "Dirección")]
        [Required]
        [StringLength(100, ErrorMessage = "La longitud maxima es de 100")]
        public string Direccion { get; set; }

        [Display(Name = "NIT")]
        [Required]
        [StringLength(10, ErrorMessage = "La longitud maxima es de 10")]
        public string NIT { get; set; }

        [Display(Name = "Teléfono")]
        [StringLength(10, ErrorMessage = "La longitud maxima es de 10")]
        public string Telefono { get; set; }
    }
}