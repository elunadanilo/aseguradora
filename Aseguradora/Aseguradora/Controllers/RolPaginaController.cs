using Aseguradora.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Aseguradora.Controllers
{
    public class RolPaginaController : Controller
    {
        // GET: RolPagina
        public ActionResult Index()
        {
            ListarComboRol();
            List<RolPaginaModel> listaRol = new List<RolPaginaModel>();
            using (var bd = new DbAseguradoraEntities())
            {
                listaRol = (from rolpagina in bd.TblRolPagina
                            join rol in bd.TblRol
                            on rolpagina.IdRol equals rol.IdRol
                            join pagina in bd.TblPagina
                            on rolpagina.IdPagina equals pagina.IdPagina
                            select new RolPaginaModel
                            {
                                IdRolPagina=rolpagina.IdRolPagina,
                                nombreRol=rol.Nombre,
                                nombreMensaje=pagina.Mensaje
                            }).ToList();

            }
                return View(listaRol);
        }

        public void ListarComboRol()
        {
            try
            {
                List<SelectListItem> lista;
                using (var bd = new DbAseguradoraEntities())
                {
                    lista = (from item in bd.TblRol
                             where item.BHabilitado==1
                             select new SelectListItem
                             {
                                 Text = item.Nombre,
                                 Value = item.IdRol.ToString()
                             }).ToList();
                    lista.Insert(0, new SelectListItem { Text = "-Todos-", Value = "" });
                    ViewBag.lista = lista;
                }          
            }
            catch (Exception exc)
            {
                Debug.WriteLine(exc);
                
            }
        }

        public ActionResult Filtrar(int IdRol)
        {
           
            List<RolPaginaModel> listaRol = new List<RolPaginaModel>();
            using (var bd = new DbAseguradoraEntities())
            {
                if (IdRol == 0)
                {
                    listaRol = (from rolpagina in bd.TblRolPagina
                                join rol in bd.TblRol
                                on rolpagina.IdRol equals rol.IdRol
                                join pagina in bd.TblPagina
                                on rolpagina.IdPagina equals pagina.IdPagina
                                where rolpagina.BHabilitado==1
                                select new RolPaginaModel
                                {
                                    IdRolPagina = rolpagina.IdRolPagina,
                                    nombreRol = rol.Nombre,
                                    nombreMensaje = pagina.Mensaje
                                }).ToList();
                }
                else
                {
                    listaRol = (from rolpagina in bd.TblRolPagina
                                join rol in bd.TblRol
                                on rolpagina.IdRol equals rol.IdRol
                                join pagina in bd.TblPagina
                                on rolpagina.IdPagina equals pagina.IdPagina
                                where rolpagina.BHabilitado == 1
                                && rolpagina.IdRol == IdRol
                                select new RolPaginaModel
                                {
                                    IdRolPagina = rolpagina.IdRolPagina,
                                    nombreRol = rol.Nombre,
                                    nombreMensaje = pagina.Mensaje
                                }).ToList();
                }
               

            }
            return PartialView("_TablaRolPagina",listaRol);
        }
    }
}