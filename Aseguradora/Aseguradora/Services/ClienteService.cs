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
    public class ClienteService : IClienteDao
    {
        private DbAseguradoraEntities bd = new DbAseguradoraEntities();
        private ClienteModel oClienteVal;

        private bool buscarCliente(ClienteModel oCliente)
        {
            bool busquedaPrimerNombre = true;
            bool busquedaPrimerApellido = true;
            bool busquedaTelefono = true;

            if (!String.IsNullOrEmpty(oClienteVal.PrimerNombre))
            {
                busquedaPrimerNombre = oCliente.PrimerNombre.ToString().ToUpper().Contains(oClienteVal.PrimerNombre.ToString().ToUpper());
            }
            if (!String.IsNullOrEmpty(oClienteVal.PrimerApellido))
            {
                busquedaPrimerApellido = oCliente.PrimerApellido.ToString().ToUpper().Contains(oClienteVal.PrimerApellido.ToString().ToUpper());
            }
            if (!String.IsNullOrEmpty(oClienteVal.Telefono))
            {
                busquedaTelefono = oCliente.Telefono.ToString().ToUpper().Contains(oClienteVal.Telefono.ToString().ToUpper());
            }

            return (busquedaPrimerNombre && busquedaPrimerApellido && busquedaTelefono);
        }


        public async Task<OperationResponse> Delete(int id)
        {
            try
            {
                using (bd)
                {
                    var data = bd.TblCliente.FirstOrDefault(p => p.IdCliente == id);
                    if (data != null)
                    {
                        bd.TblCliente.Remove(data);
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
                List<ClienteModel> listaCliente = null;
                using (bd)
                {
                    listaCliente = (from cliente in bd.TblCliente
                                    join departamento in bd.TblDepartamento on cliente.Departamento equals departamento.Departamento
                                    join municipio in bd.TblMunicipio on new { cliente.Municipio, cliente.Departamento } equals new { municipio.Municipio, municipio.Departamento }
                                    select new ClienteModel
                                    {
                                        IdCliente = cliente.IdCliente,
                                        PrimerNombre = cliente.PrimerNombre,
                                        SegundoNombre = cliente.SegundoNombre,
                                        PrimerApellido = cliente.PrimerApellido,
                                        SegundoApellido = cliente.SegundoApellido,
                                        ApellidoCasada = cliente.ApellidoCasada,
                                        Departamento = departamento.Nombre,
                                        Municipio = municipio.Descripcion,
                                        Direccion = cliente.Direccion,
                                        Telefono = cliente.Telefono,
                                        TelefonoSecundario = cliente.TelefonoSecundario,
                                        TelefonoCelular = cliente.TelefonoCelular,
                                        NIT = cliente.NIT,
                                        DPI = cliente.DPI,
                                        CorreoElectronico = cliente.CorreoElectronico,
                                        FechaNacimiento = (DateTime)cliente.FechaNacimiento,
                                        ProfesionUOficio = cliente.ProfesionUOficio,
                                        Activo = cliente.Activo
                                    }).ToList();
                }

                return new OperationResponse(1, listaCliente);
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
                ClienteModel oClienteModel = new ClienteModel();
                using (bd)
                {
                    TblCliente oCliente = bd.TblCliente.Where(p => p.IdCliente.Equals(id)).First();
                    oClienteModel.IdCliente = oCliente.IdCliente;
                    oClienteModel.PrimerNombre = oCliente.PrimerNombre;
                    oClienteModel.SegundoNombre = oCliente.SegundoNombre;
                    oClienteModel.PrimerApellido = oCliente.PrimerApellido;
                    oClienteModel.SegundoApellido = oCliente.SegundoApellido;
                    oClienteModel.ApellidoCasada = oCliente.ApellidoCasada;
                    oClienteModel.Departamento = oCliente.Departamento;
                    oClienteModel.Municipio = oCliente.Municipio;
                    oClienteModel.Direccion = oCliente.Direccion;
                    oClienteModel.Telefono = oCliente.Telefono;
                    oClienteModel.TelefonoSecundario = oCliente.TelefonoSecundario;
                    oClienteModel.TelefonoCelular = oCliente.TelefonoCelular;
                    oClienteModel.NIT = oCliente.NIT;
                    oClienteModel.DPI = oCliente.DPI;
                    oClienteModel.CorreoElectronico = oCliente.CorreoElectronico;
                    oClienteModel.FechaNacimiento = (DateTime)oCliente.FechaNacimiento;
                    oClienteModel.ProfesionUOficio = oCliente.ProfesionUOficio;
                    oClienteModel.Activo = oCliente.Activo;

                }
                return new OperationResponse(1, oClienteModel);
            }
            catch (Exception exc)
            {

                Debug.WriteLine(exc);
                return new OperationResponse(0);
            }
        }

        public OperationResponse GetClientesPorFiltro(ClienteModel oCliente)
        {
            try
            {
                oClienteVal = oCliente;
                List<ClienteModel> ListaFiltradaCliente = null;
                List<ClienteModel> listaCliente = null;
                using (bd)
                {
                    listaCliente = (from cliente in bd.TblCliente
                                    join departamento in bd.TblDepartamento on cliente.Departamento equals departamento.Departamento
                                    join municipio in bd.TblMunicipio on new { cliente.Municipio, cliente.Departamento } equals new { municipio.Municipio, municipio.Departamento }
                                    select new ClienteModel
                                    {
                                        IdCliente = cliente.IdCliente,
                                        PrimerNombre = cliente.PrimerNombre,
                                        SegundoNombre = cliente.SegundoNombre,
                                        PrimerApellido = cliente.PrimerApellido,
                                        SegundoApellido = cliente.SegundoApellido,
                                        ApellidoCasada = cliente.ApellidoCasada,
                                        Departamento = departamento.Nombre,
                                        Municipio = municipio.Descripcion,
                                        Direccion = cliente.Direccion,
                                        Telefono = cliente.Telefono,
                                        TelefonoSecundario = cliente.TelefonoSecundario,
                                        TelefonoCelular = cliente.TelefonoCelular,
                                        NIT = cliente.NIT,
                                        DPI = cliente.DPI,
                                        CorreoElectronico = cliente.CorreoElectronico,
                                        FechaNacimiento = (DateTime)cliente.FechaNacimiento,
                                        ProfesionUOficio = cliente.ProfesionUOficio,
                                        Activo = cliente.Activo
                                    }).ToList();

                    if (oCliente.PrimerNombre == null && oCliente.PrimerApellido == null && oCliente.Telefono == null)
                    {
                        ListaFiltradaCliente = listaCliente;
                    }
                    else
                    {
                        Predicate<ClienteModel> pred = new Predicate<ClienteModel>(buscarCliente);
                        ListaFiltradaCliente = listaCliente.FindAll(pred);
                    }
                }

                return new OperationResponse(1, ListaFiltradaCliente);
            }
            catch (Exception exc)
            {

                Debug.WriteLine(exc);
                return new OperationResponse(0);
            }
        }

        public async Task<OperationResponse> Save(ClienteModel t)
        {
            try
            {
                using (bd)
                {
                    TblCliente oCliente = new TblCliente();
                    oCliente.PrimerNombre = t.PrimerNombre;
                    oCliente.SegundoNombre = t.SegundoNombre;
                    oCliente.PrimerApellido = t.PrimerApellido;
                    oCliente.SegundoApellido = t.SegundoApellido;
                    oCliente.ApellidoCasada = t.ApellidoCasada;
                    oCliente.Departamento = t.Departamento;
                    oCliente.Municipio = t.Municipio;
                    oCliente.Direccion = t.Direccion;
                    oCliente.Telefono = t.Telefono;
                    oCliente.TelefonoSecundario = t.TelefonoSecundario;
                    oCliente.TelefonoCelular = t.TelefonoCelular;
                    oCliente.NIT = t.NIT;
                    oCliente.DPI = t.DPI;
                    oCliente.CorreoElectronico = t.CorreoElectronico;
                    oCliente.FechaNacimiento = (DateTime)t.FechaNacimiento;
                    oCliente.ProfesionUOficio = t.ProfesionUOficio;
                    oCliente.Activo = t.Activo;

                    bd.TblCliente.Add(oCliente);
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

        public async Task<OperationResponse> Update(int id, ClienteModel t)
        {
            try
            {
                using (bd)
                {
                    TblCliente oCliente = bd.TblCliente.Where(p => p.IdCliente.Equals(id)).First();
                    oCliente.PrimerNombre = t.PrimerNombre;
                    oCliente.SegundoNombre = t.SegundoNombre;
                    oCliente.PrimerApellido = t.PrimerApellido;
                    oCliente.SegundoApellido = t.SegundoApellido;
                    oCliente.ApellidoCasada = t.ApellidoCasada;
                    oCliente.Departamento = t.Departamento;
                    oCliente.Municipio = t.Municipio;
                    oCliente.Direccion = t.Direccion;
                    oCliente.Telefono = t.Telefono;
                    oCliente.TelefonoSecundario = t.TelefonoSecundario;
                    oCliente.TelefonoCelular = t.TelefonoCelular;
                    oCliente.NIT = t.NIT;
                    oCliente.DPI = t.DPI;
                    oCliente.CorreoElectronico = t.CorreoElectronico;
                    oCliente.FechaNacimiento = (DateTime)t.FechaNacimiento;
                    oCliente.ProfesionUOficio = t.ProfesionUOficio;
                    oCliente.Activo = t.Activo;
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