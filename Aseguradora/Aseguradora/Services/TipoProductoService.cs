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
    public class TipoProductoService : ITipoProductoDao
    {
        private DbAseguradoraEntities bd = new DbAseguradoraEntities();

        public async Task<OperationResponse> Delete(int id)
        {
            try
            {
                using (bd)
                {
                    var data = bd.TblTipoProducto.FirstOrDefault(p => p.IdTipoProducto == id);
                    if (data != null)
                    {
                        bd.TblTipoProducto.Remove(data);
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
                List<TipoProductoModel> listaTipoProducto = null;
                using (bd)
                {
                    listaTipoProducto = (from tipoproducto in bd.TblTipoProducto
                                         join producto in bd.TblProducto on tipoproducto.IdProducto equals producto.IdProducto
                                         join aseguradora in bd.TblAseguradora on producto.IdAseguradora equals aseguradora.IdAseguradora
                                         select new TipoProductoModel
                                         {
                                             IdTipoProducto = tipoproducto.IdTipoProducto,
                                             IdProducto = tipoproducto.IdProducto,
                                             Descripcion = tipoproducto.Descripcion
                                         }

                        ).ToList();
                }
                return new OperationResponse(1, listaTipoProducto);
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
                TipoProductoModel oTipoProductoModel = new TipoProductoModel();
                using (bd)
                {
                    TblTipoProducto oTipoProducto = bd.TblTipoProducto.Where(p => p.IdTipoProducto.Equals(id)).First();
                    oTipoProductoModel.IdTipoProducto = oTipoProducto.IdTipoProducto;
                    oTipoProductoModel.IdProducto = oTipoProducto.IdProducto;
                    oTipoProductoModel.Descripcion = oTipoProducto.Descripcion;
                }
                return new OperationResponse(1, oTipoProductoModel);
            }
            catch (Exception exc)
            {

                Debug.WriteLine(exc);
                return new OperationResponse(0);
            }
        }

        public OperationResponse GetListTipoProducto()
        {
            try
            {
                List<SelectListItem> lista;
                using (var bd = new DbAseguradoraEntities())
                {
                    lista = (from item in bd.TblTipoProducto
                             select new SelectListItem
                             {
                                 Text = item.Descripcion,
                                 Value = item.IdProducto.ToString()
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

        public async Task<OperationResponse> Save(TipoProductoModel t)
        {
            try
            {
                using (bd)
                {
                    TblTipoProducto oTipoProducto = new TblTipoProducto();
                    oTipoProducto.IdProducto = t.IdProducto;
                    oTipoProducto.Descripcion = t.Descripcion;
                    bd.TblTipoProducto.Add(oTipoProducto);
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

        public async Task<OperationResponse> Update(int id, TipoProductoModel t)
        {
            try
            {

                using (bd)
                {
                    TblTipoProducto oTipoProducto = bd.TblTipoProducto.Where(p => p.IdTipoProducto.Equals(id)).First();
                    oTipoProducto.IdProducto = t.IdProducto;
                    oTipoProducto.Descripcion = t.Descripcion;
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