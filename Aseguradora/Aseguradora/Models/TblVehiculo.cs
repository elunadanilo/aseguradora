//------------------------------------------------------------------------------
// <auto-generated>
//     Este código se generó a partir de una plantilla.
//
//     Los cambios manuales en este archivo pueden causar un comportamiento inesperado de la aplicación.
//     Los cambios manuales en este archivo se sobrescribirán si se regenera el código.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Aseguradora.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class TblVehiculo
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public TblVehiculo()
        {
            this.TblVehiculoCliente = new HashSet<TblVehiculoCliente>();
        }
    
        public int IdVehiculo { get; set; }
        public int IdMarca { get; set; }
        public int IdTipoVehiculo { get; set; }
        public string Nombre { get; set; }
        public byte NumeroDePuertas { get; set; }
        public byte NumeroDeLlantas { get; set; }
        public byte NumeroDeAsientos { get; set; }
        public decimal Motor { get; set; }
        public byte Cilindros { get; set; }
        public string Descripcion { get; set; }
    
        public virtual TblMarca TblMarca { get; set; }
        public virtual TblTipoVehiculo TblTipoVehiculo { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<TblVehiculoCliente> TblVehiculoCliente { get; set; }
    }
}