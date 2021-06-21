using Aseguradora.Dao;
using Aseguradora.Models;
using Aseguradora.Utils;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace Aseguradora.Services
{
    public class DepartamentoService : IDepartamentoDao
    {
        private DbAseguradoraEntities bd = new DbAseguradoraEntities();
        public Task<OperationResponse> Delete(int id)
        {
            throw new NotImplementedException();
        }

        public OperationResponse GetAll()
        {
            try
            {
                List<DepartamentoModel> listaDepartamento = null;
                using (bd)
                {
                    listaDepartamento = (from departamento in bd.TblDepartamento
                                         select new DepartamentoModel
                                         {
                                             Departamento = departamento.Departamento,
                                             Nombre = departamento.Nombre
                                         }).ToList();
                }
                return new OperationResponse(1, listaDepartamento);
            }
            catch (Exception exc)
            {

                Debug.WriteLine(exc);
                return new OperationResponse(0);
            }
        }

        public OperationResponse GetById(int id)
        {
            try
            {
                DepartamentoModel oDepartamentoModel = new DepartamentoModel();
                using (bd)
                {
                    TblDepartamento oDepartamento = bd.TblDepartamento.Where(p => p.Departamento.Equals(id)).First();
                    oDepartamentoModel.Departamento = oDepartamento.Departamento;
                    oDepartamentoModel.Nombre = oDepartamento.Nombre;
                }
                return new OperationResponse(1, oDepartamentoModel);
            }
            catch (Exception exc)
            {

                Debug.WriteLine(exc);
                return new OperationResponse(0);
            }
        }

        public OperationResponse GetListDepartamento()
        {
            try
            {
                List<SelectListItem> lista;
                using (bd)
                {
                    lista = (from item in bd.TblDepartamento
                             select new SelectListItem
                             {
                                 Text = item.Nombre,
                                 Value = item.Departamento
                             }).ToList();
                    lista.Insert(0, new SelectListItem { Text = "-Todos-", Value = "" });

                }

                return new OperationResponse(1, lista);
            }
            catch (Exception exc)
            {
                Debug.WriteLine(exc);
                return new OperationResponse(0);
            }
        }

        public Task<OperationResponse> Save(DepartamentoModel t)
        {
            throw new NotImplementedException();
        }

        public Task<OperationResponse> Update(int id, DepartamentoModel t)
        {
            throw new NotImplementedException();
        }
    }
}