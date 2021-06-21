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
    public class TipoVehiculoService : ITipoVehiculoDao
    {
        private DbAseguradoraEntities bd = new DbAseguradoraEntities();
        public async Task<OperationResponse> Delete(int id)
        {
            try
            {
                using (bd)
                {
                    var data = bd.TblTipoVehiculo.FirstOrDefault(p => p.IdTipoVehiculo == id);
                    if (data != null)
                    {
                        bd.TblTipoVehiculo.Remove(data);
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
                List<TipoVehiculoModel> listaTipoVehiculo = null;
                using (bd)
                {
                    listaTipoVehiculo = (from tipovehiculo in bd.TblTipoVehiculo
                                         select new TipoVehiculoModel
                                         {
                                             IdTipoVehiculo = tipovehiculo.IdTipoVehiculo,
                                             Descripcion = tipovehiculo.Descripcion
                                         }).ToList();
                }

                //Aqui va la operacion que querés hacer con la DB
                return new OperationResponse(1, listaTipoVehiculo);
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
                TipoVehiculoModel oTipoVehiculoModel = new TipoVehiculoModel();
                using (bd)
                {
                    TblTipoVehiculo oTipoVehiculo = bd.TblTipoVehiculo.Where(p => p.IdTipoVehiculo.Equals(id)).First();
                    oTipoVehiculoModel.IdTipoVehiculo = oTipoVehiculo.IdTipoVehiculo;
                    oTipoVehiculoModel.Descripcion = oTipoVehiculo.Descripcion;
                }
                return new OperationResponse(1, oTipoVehiculoModel);
            }
            catch (Exception exc)
            {

                Debug.WriteLine(exc);
                return new OperationResponse(0);
            }
        }

        public async Task<OperationResponse> Save(TipoVehiculoModel t)
        {
            try
            {
                //Aqui va la operacion que querés hacer con la DB
                using (bd)
                {
                    TblTipoVehiculo oTipoVehiculo = new TblTipoVehiculo();
                    oTipoVehiculo.Descripcion = t.Descripcion;
                    bd.TblTipoVehiculo.Add(oTipoVehiculo);
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

        public async Task<OperationResponse> Update(int id, TipoVehiculoModel t)
        {
            try
            {
                //Aqui va la operacion que querés hacer con la DB
                using (bd)
                {
                    TblTipoVehiculo oTipoVehiculo = bd.TblTipoVehiculo.Where(p => p.IdTipoVehiculo.Equals(id)).First();
                    oTipoVehiculo.Descripcion = t.Descripcion;
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