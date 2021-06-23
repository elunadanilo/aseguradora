using Aseguradora.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Aseguradora.Controllers
{
    public class PaginaController : Controller
    {
        // GET: Pagina
        public ActionResult Index()
        {
            List<PaginaModel> listaPagina = new List<PaginaModel>();
            using (var bd = new DbAseguradoraEntities())
            {
                listaPagina = (from pagina in bd.TblPagina
                               where pagina.BHabilitado == 1
                               select new PaginaModel
                               {
                                   IdPagina = pagina.IdPagina,
                                   Mensaje = pagina.Mensaje,
                                   Controlador = pagina.Controlador,
                                   Accion = pagina.Accion
                               }).ToList();
            }
                return View(listaPagina);
        }

        public ActionResult Filtrar(PaginaModel oPaginaModel)
        {
            string mensaje = oPaginaModel.Mensaje;
            List<PaginaModel> listaPagina = new List<PaginaModel>();
            using (var bd = new DbAseguradoraEntities())
            {
                if (mensaje == null)
                {
                    listaPagina = (from pagina in bd.TblPagina
                                   where pagina.BHabilitado == 1
                                   select new PaginaModel
                                   {
                                       IdPagina = pagina.IdPagina,
                                       Mensaje = pagina.Mensaje,
                                       Controlador = pagina.Controlador,
                                       Accion = pagina.Accion
                                   }).ToList();
                }
                else
                {
                    listaPagina = (from pagina in bd.TblPagina
                                   where pagina.BHabilitado == 1
                                   && pagina.Mensaje.Contains(mensaje)
                                   select new PaginaModel
                                   {
                                       IdPagina = pagina.IdPagina,
                                       Mensaje = pagina.Mensaje,
                                       Controlador = pagina.Controlador,
                                       Accion = pagina.Accion
                                   }).ToList();
                }
            }

            return PartialView("_TablaPagina",listaPagina);
        }

        public int Save(PaginaModel oPaginaModel, int Titulo)
        {
            int rpta = 0;
            using (var bd = new DbAseguradoraEntities())
            {
                if (Titulo.Equals(1))
                {
                    TblPagina oPagina = new TblPagina();
                    oPagina.Mensaje = oPaginaModel.Mensaje;
                    oPagina.Accion = oPaginaModel.Accion;
                    oPagina.Controlador = oPaginaModel.Controlador;
                    oPagina.BHabilitado = 1;
                    bd.TblPagina.Add(oPagina);
                    rpta = bd.SaveChanges();
                }
            }
            return rpta;
        }
    }
}