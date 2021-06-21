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
    public class MunicipioService : IMunicipioDao
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
                List<MunicipioModel> listaMunicipio = null;
                using (bd)
                {
                    listaMunicipio = (from municipio in bd.TblMunicipio
                                      select new MunicipioModel
                                      {
                                          Municipio = municipio.Municipio,
                                          Descripcion = municipio.Descripcion
                                      }).ToList();
                }
                return new OperationResponse(1, listaMunicipio);
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
                MunicipioModel oMunicipioModel = new MunicipioModel();
                using (bd)
                {
                    TblMunicipio oMunicipio = bd.TblMunicipio.Where(p => p.Municipio.Equals(id)).First();
                    oMunicipioModel.Municipio = oMunicipio.Municipio;
                    oMunicipioModel.Descripcion = oMunicipio.Descripcion;
                }
                return new OperationResponse(1, oMunicipioModel);
            }
            catch (Exception exc)
            {

                Debug.WriteLine(exc);
                return new OperationResponse(0);
            }
        }

        public OperationResponse GetListMunicipio()
        {
            try
            {
                List<SelectListItem> lista;
                using (var bd = new DbAseguradoraEntities())
                {
                    lista = (from item in bd.TblMunicipio
                             select new SelectListItem
                             {
                                 Text = item.Descripcion,
                                 Value = item.Municipio
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

        public Task<OperationResponse> Save(MunicipioModel t)
        {
            throw new NotImplementedException();
        }

        public Task<OperationResponse> Update(int id, MunicipioModel t)
        {
            throw new NotImplementedException();
        }
    }
}