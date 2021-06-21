using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Aseguradora.Models
{
    public class TipoVehiculoModel
    {
        [Display(Name = "Id Tipo Vehiculo")]
        public int IdTipoVehiculo { get; set; }

        [Display(Name = "Descripcion")]
        [Required]
        [StringLength(50, ErrorMessage = "la longitud maxima es de 50")]
        public string Descripcion { get; set; }
    }
}