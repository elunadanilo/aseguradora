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
    public class FormaDePagoService : IFormaDePagoDao
    {
        private DbAseguradoraEntities bd = new DbAseguradoraEntities();

        public async Task<OperationResponse> Delete(int id)
        {
            try
            {
                using (bd)
                {
                    var data = bd.TblFormaDePago.FirstOrDefault(p => p.IdFormaDePago == id);
                    if (data != null)
                    {
                        bd.TblFormaDePago.Remove(data);
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
                List<FormaDePagoModel> listaFormaDepago = null;
                using (bd)
                {
                    listaFormaDepago = (from formadepago in bd.TblFormaDePago
                                        select new FormaDePagoModel
                                        {
                                            IdFormaDePago = formadepago.IdFormaDePago,
                                            Descripcion = formadepago.Descripcion
                                        }).ToList();
                }

                //Aqui va la operacion que querés hacer con la DB
                return new OperationResponse(1, listaFormaDepago);
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
                FormaDePagoModel oFormaDePagoModel = new FormaDePagoModel();
                using (bd)
                {
                    TblFormaDePago oFormaDePago = bd.TblFormaDePago.Where(p => p.IdFormaDePago.Equals(id)).First();
                    oFormaDePagoModel.IdFormaDePago = oFormaDePago.IdFormaDePago;
                    oFormaDePagoModel.Descripcion = oFormaDePago.Descripcion;
                }
                return new OperationResponse(1, oFormaDePagoModel);
            }
            catch (Exception exc)
            {

                Debug.WriteLine(exc);
                return new OperationResponse(0);
            }
        }

        public async Task<OperationResponse> Save(FormaDePagoModel t)
        {
            try
            {
                //Aqui va la operacion que querés hacer con la DB
                using (bd)
                {
                    TblFormaDePago oFormaDePago = new TblFormaDePago();
                    oFormaDePago.Descripcion = t.Descripcion;
                    bd.TblFormaDePago.Add(oFormaDePago);
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

        public async Task<OperationResponse> Update(int id, FormaDePagoModel t)
        {
            try
            {
                //Aqui va la operacion que querés hacer con la DB
                using (bd)
                {
                    TblFormaDePago oForma = bd.TblFormaDePago.Where(p => p.IdFormaDePago.Equals(id)).First();
                    oForma.Descripcion = t.Descripcion;
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