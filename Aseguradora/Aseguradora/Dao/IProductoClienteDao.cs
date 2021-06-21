using Aseguradora.Models;
using Aseguradora.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aseguradora.Dao
{
    interface IProductoClienteDao : ICRUD<ProductoClienteModel>
    {
        OperationResponse GetClientesListaProductos(int id);
    }
}
