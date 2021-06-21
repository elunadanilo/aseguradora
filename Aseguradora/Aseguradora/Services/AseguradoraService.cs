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
    public class AseguradoraService : IAseguradoraDao
    {
        private DbAseguradoraEntities bd = new DbAseguradoraEntities();
        public async Task<OperationResponse> Delete(int id)
        {
            try
            {
                using (bd)
                {
                    var data = bd.TblAseguradora.FirstOrDefault(p => p.IdAseguradora == id);
                    if (data != null)
                    {
                        bd.TblAseguradora.Remove(data);
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
                List<AseguradoraModel> listaAseguradora = null;
                using (bd)
                {
                    listaAseguradora = (from aseguradora in bd.TblAseguradora
                                        select new AseguradoraModel
                                        {
                                            IdAseguradora = aseguradora.IdAseguradora,
                                            Nombre = aseguradora.Nombre,
                                            Departamento = aseguradora.Departamento,
                                            Municipio = aseguradora.Municipio,
                                            Direccion = aseguradora.Direccion,
                                            NIT = aseguradora.NIT,
                                            Telefono = aseguradora.Telefono
                                        }).ToList();
                }
                return new OperationResponse(1, listaAseguradora);
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
                AseguradoraModel oAseguradoraModel = new AseguradoraModel();
                using (bd)
                {
                    TblAseguradora oAseguradora = bd.TblAseguradora.Where(p => p.IdAseguradora.Equals(id)).First();
                    oAseguradoraModel.IdAseguradora = oAseguradora.IdAseguradora;
                    oAseguradoraModel.Municipio = oAseguradora.Municipio;
                    oAseguradoraModel.Departamento = oAseguradora.Departamento;
                    oAseguradoraModel.Direccion = oAseguradora.Direccion;
                    oAseguradoraModel.NIT = oAseguradora.NIT;
                    oAseguradoraModel.Nombre = oAseguradora.Nombre;
                    oAseguradoraModel.Telefono = oAseguradora.Telefono;
                }
                return new OperationResponse(1, oAseguradoraModel);
            }
            catch (Exception exc)
            {

                Debug.WriteLine(exc);
                return new OperationResponse(0);
            }
        }

        public OperationResponse GetListAseguradora()
        {
            try
            {
                List<SelectListItem> lista;
                using (var bd = new DbAseguradoraEntities())
                {
                    lista = (from item in bd.TblAseguradora
                             select new SelectListItem
                             {
                                 Text = item.Nombre,
                                 Value = item.IdAseguradora.ToString()
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

        public async Task<OperationResponse> Save(AseguradoraModel t)
        {
            try
            {
                using (bd)
                {
                    TblAseguradora oTblAseguradora = new TblAseguradora();
                    oTblAseguradora.Municipio = t.Municipio;
                    oTblAseguradora.Departamento = t.Departamento;
                    oTblAseguradora.Direccion = t.Direccion;
                    oTblAseguradora.NIT = t.NIT;
                    oTblAseguradora.Nombre = t.Nombre;
                    oTblAseguradora.Telefono = t.Telefono;
                    bd.TblAseguradora.Add(oTblAseguradora);
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

        public async Task<OperationResponse> Update(int id, AseguradoraModel t)
        {
            try
            {
                using (bd)
                {
                    TblAseguradora oTblAseguradora = bd.TblAseguradora.Where(p => p.IdAseguradora.Equals(id)).First();
                    oTblAseguradora.Municipio = t.Municipio;
                    oTblAseguradora.Departamento = t.Departamento;
                    oTblAseguradora.Direccion = t.Direccion;
                    oTblAseguradora.NIT = t.NIT;
                    oTblAseguradora.Nombre = t.Nombre;
                    oTblAseguradora.Telefono = t.Telefono;
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