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
    public class ProductoService : IProductoDao
    {
        private DbAseguradoraEntities bd = new DbAseguradoraEntities();

        public async Task<OperationResponse> Delete(int id)
        {
            try
            {
                using (bd)
                {
                    var data = bd.TblProducto.FirstOrDefault(p => p.IdProducto == id);
                    if (data != null)
                    {
                        bd.TblProducto.Remove(data);
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
                List<ProductoModel> listaProducto = null;
                using (bd)
                {
                    listaProducto = (from aseguradora in bd.TblAseguradora
                                     join producto in bd.TblProducto on aseguradora.IdAseguradora equals producto.IdAseguradora
                                     select new ProductoModel
                                     {
                                         IdProducto = producto.IdProducto,
                                         IdAseguradora=producto.IdAseguradora,
                                         Descripcion = producto.Descripcion
                                     }).ToList();
                }
                return new OperationResponse(1, listaProducto);
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
                ProductoModel oProductoModel = new ProductoModel();
                using (bd)
                {
                    TblProducto oProducto = bd.TblProducto.Where(p => p.IdProducto.Equals(id)).First();
                    oProductoModel.IdProducto = oProducto.IdProducto;
                    oProductoModel.IdAseguradora = oProducto.IdAseguradora;
                    oProductoModel.Descripcion = oProducto.Descripcion;
                }
                return new OperationResponse(1, oProductoModel);
            }
            catch (Exception exc)
            {
                Debug.WriteLine(exc);
                return new OperationResponse(0);
            }
        }

        public async Task<OperationResponse> Save(ProductoModel t)
        {
            try
            {
                using (bd)
                {
                    TblProducto oProducto = new TblProducto();
                    oProducto.IdAseguradora = t.IdAseguradora;
                    oProducto.Descripcion = t.Descripcion;
                    bd.TblProducto.Add(oProducto);
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

        public async Task<OperationResponse> Update(int id, ProductoModel t)
        {
            try
            {
                using (bd)
                {
                    TblProducto producto = bd.TblProducto.Where(p => p.IdProducto.Equals(id)).First();
                    producto.IdAseguradora = t.IdAseguradora;
                    producto.Descripcion = t.Descripcion;
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


        public OperationResponse GetListProducto(int IdAseguradora)
        {
            try
            {
                List<SelectListItem> lista;
                using (var bd = new DbAseguradoraEntities())
                {
                    lista = (from item in bd.TblProducto
                             where item.IdAseguradora == IdAseguradora
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
    }
}