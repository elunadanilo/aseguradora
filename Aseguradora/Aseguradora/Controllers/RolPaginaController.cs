using Aseguradora.Models;
using System;
using System.Collections.Generic;
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
                return View();
        }
    }
}