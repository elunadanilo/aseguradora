using Aseguradora.Dao;
using Aseguradora.Models;
using Aseguradora.Utils;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using System.Web;

namespace Aseguradora.Services
{
    public class MarcaService : IMarcaDao
    {
        private DbAseguradoraEntities bd = new DbAseguradoraEntities();

        public async Task<OperationResponse> Delete(int id)
        {
            try
            {
                using (bd)
                {
                    var data = bd.TblMarca.FirstOrDefault(p => p.IdMarca == id);
                    if (data != null)
                    {
                        bd.TblMarca.Remove(data);
                        bd.SaveChanges();
                        await Task.Delay(1000);
                        return new OperationResponse(1);
                    }
                    else
                    {
                        await Task.Delay(1000);
                        return new OperationResponse(0);
                    }
                }
            }
            catch (Exception exc)
            {
                Debug.WriteLine(exc);
                return new OperationResponse(0);
            }
        }

        public OperationResponse GetAll()
        {
            try
            {
                List<MarcaModel> listaMarca = null;
                using (bd)
                {
                    listaMarca = (from marca in bd.TblMarca
                                  select new MarcaModel
                                  {
                                      IdMarca = marca.IdMarca,
                                      Nombre = marca.Nombre
                                  }).ToList();
                }
                return new OperationResponse(1, listaMarca);
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
                MarcaModel oMarcaModel = new MarcaModel();
                using (bd)
                {
                    TblMarca oMarca = bd.TblMarca.Where(p => p.IdMarca.Equals(id)).First();
                    oMarcaModel.IdMarca = oMarca.IdMarca;
                    oMarcaModel.Nombre = oMarca.Nombre;
                }
                return new OperationResponse(1, oMarcaModel);
            }
            catch (Exception exc)
            {

                Debug.WriteLine(exc);
                return new OperationResponse(0);
            }
        }

        public async Task<OperationResponse> Save(MarcaModel t)
        {
            try
            {
                using (var bd = new DbAseguradoraEntities())
                {
                    TblMarca oMarca = new TblMarca();
                    oMarca.Nombre = t.Nombre;
                    bd.TblMarca.Add(oMarca);
                    bd.SaveChanges();
                }

                await Task.Delay(1000);
                return new OperationResponse(1);
            }
            catch (Exception exc)
            {

                Debug.WriteLine(exc);
                return new OperationResponse(0);
            }
        }

        public async Task<OperationResponse> Update(int id, MarcaModel t)
        {
            try
            {
                using (bd)
                {
                    TblMarca oM = bd.TblMarca.Where(p => p.IdMarca.Equals(id)).First();
                    oM.Nombre = t.Nombre;
                    bd.SaveChanges();
                }
                await Task.Delay(1000);
                return new OperationResponse(1);
            }
            catch (Exception exc)
            {

                Debug.WriteLine(exc);
                return new OperationResponse(0);
            }
        }
    }
}