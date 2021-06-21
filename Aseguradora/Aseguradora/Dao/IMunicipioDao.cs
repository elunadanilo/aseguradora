using Aseguradora.Models;
using Aseguradora.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aseguradora.Dao
{
    interface IMunicipioDao : ICRUD<MunicipioModel>
    {
        OperationResponse GetListMunicipio();
    }
}
