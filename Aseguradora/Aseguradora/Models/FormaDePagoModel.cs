using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Aseguradora.Models
{
    public class FormaDePagoModel
    {
        [Display(Name = "Id Forma De Pago")]
        public int IdFormaDePago { get; set; }

        [Display(Name = "Descripcion")]
        [Required]
        [StringLength(50, ErrorMessage = "La longitud maxima es de 50")]
        public string Descripcion { get; set; }
    }
}