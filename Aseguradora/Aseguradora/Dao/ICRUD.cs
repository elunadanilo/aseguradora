using Aseguradora.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aseguradora.Dao
{
    interface ICRUD<T>
    {
        OperationResponse GetAll();
        OperationResponse GetById(int id);
        Task<OperationResponse> Save(T t);
        Task<OperationResponse> Delete(int id);
        Task<OperationResponse> Update(int id, T t);
    }
}
