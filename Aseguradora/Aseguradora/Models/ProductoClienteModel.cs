using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Aseguradora.Models
{
    public class ProductoClienteModel
    {
        public int IdProductoCliente { get; set; }
        public string NombreAseguradora { get; set; }
        public string NombreProducto { get; set; }
        public int IdTipoProducto { get; set; }
        public string NombreTipoProducto { get; set; }
        public int IdCliente { get; set; }
        public string NombreCliente { get; set; }
        public int IdFormaDePago { get; set; }
        public string NombreFormaDePago { get; set; }
        public string DocumentoPoliza { get; set; }
        public DateTime FechaInicial { get; set; }
        public Nullable<System.DateTime> FechaFinal { get; set; }
        public decimal ValorGeneral { get; set; }
        public decimal ValorPoliza { get; set; }
        public decimal ValorActual { get; set; }
        public decimal PrimaAnual { get; set; }
        public decimal PrimaNeta { get; set; }
    }
}