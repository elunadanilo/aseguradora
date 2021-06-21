using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Aseguradora.Models
{
    public class ClienteModel
    {
        [Display(Name = "Id Cliente")]
        public int IdCliente { get; set; }

        [Display(Name = "Primer Nombre")]
        [Required]
        [StringLength(30, ErrorMessage = "La longitud maxima es de 30")]
        public string PrimerNombre { get; set; }

        [Display(Name = "Segundo Nombre")]
        [Required]
        [StringLength(30, ErrorMessage = "La longitud maxima es de 30")]
        public string SegundoNombre { get; set; }

        [Display(Name = "Primer Apellido")]
        [Required]
        [StringLength(30, ErrorMessage = "La longitud maxima es de 30")]
        public string PrimerApellido { get; set; }

        [Display(Name = "Segundo Apellido")]
        [StringLength(30, ErrorMessage = "La longitud maxima es de 30")]
        public string SegundoApellido { get; set; }

        [Display(Name = "Apellido Casada")]
        [StringLength(30, ErrorMessage = "La longitud maxima es de 30")]
        public string ApellidoCasada { get; set; }

        [Display(Name = "Departamento")]
        [Required]
        [StringLength(2, ErrorMessage = "La longitud maxima es de 2")]
        public string Departamento { get; set; }

        [Display(Name = "Municipio")]
        [Required]
        [StringLength(2, ErrorMessage = "La longitud maxima es de 2")]
        public string Municipio { get; set; }

        [Display(Name = "Direccion")]
        [Required]
        [StringLength(150, ErrorMessage = "La longitud maxima es de 150")]
        public string Direccion { get; set; }

        [Display(Name = "Telefono")]
        [Required]
        [StringLength(50, ErrorMessage = "La longitud maxima es de 50")]
        public string Telefono { get; set; }

        [Display(Name = "Telefono Secundario")]
        [StringLength(50, ErrorMessage = "La longitud maxima es de 50")]
        public string TelefonoSecundario { get; set; }

        [Display(Name = "Telefono Celular")]
        [StringLength(50, ErrorMessage = "La longitud maxima es de 50")]
        public string TelefonoCelular { get; set; }

        [Display(Name = "NIT")]
        [Required]
        [StringLength(50, ErrorMessage = "La longitud maxima es de 50")]
        public string NIT { get; set; }

        [Display(Name = "DPI")]
        [Required]
        [StringLength(50, ErrorMessage = "La longitud maxima es de 50")]
        public string DPI { get; set; }

        [Display(Name = "Correo Electronico")]
        [EmailAddress]
        [Required]
        [StringLength(100, ErrorMessage = "La longitud maxima es de 100")]
        public string CorreoElectronico { get; set; }

        [Display(Name = "Fecha Nacimiento")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime FechaNacimiento { get; set; }

        [Display(Name = "Profesion u Oficio")]
        [Required]
        [StringLength(150, ErrorMessage = "La longitud maxima es de 150")]
        public string ProfesionUOficio { get; set; }

        [Display(Name = "Activo")]
        public bool Activo { get; set; }
    }
}