using Aseguradora.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Aseguradora.Controllers
{
    public class RolController : Controller
    {
        // GET: Rol
        public ActionResult Index()
        {
            List<RolModel> listaRol = new List<RolModel>();
            using (var bd = new DbAseguradoraEntities()) {
                listaRol = (from rol in bd.TblRol
                            where rol.BHabilitado == 1
                            select new RolModel
                            {
                                IdRol=rol.IdRol,
                                Nombre=rol.Nombre,
                                Descripcion=rol.Descripcion
                            }).ToList();
            }
                return View(listaRol);
        }

        public ActionResult Filtro(string Nombre)
        {
            List<RolModel> listaRol = new List<RolModel>();
            using (var bd = new DbAseguradoraEntities())
            {
                if (Nombre == null)
                {
                    listaRol = (from rol in bd.TblRol
                                where rol.BHabilitado == 1
                                select new RolModel
                                {
                                    IdRol = rol.IdRol,
                                    Nombre = rol.Nombre,
                                    Descripcion = rol.Descripcion
                                }).ToList();
                }
                else
                {
                    listaRol = (from rol in bd.TblRol
                                where rol.BHabilitado == 1
                                && rol.Nombre.Contains(Nombre)
                                select new RolModel
                                {
                                    IdRol = rol.IdRol,
                                    Nombre = rol.Nombre,
                                    Descripcion = rol.Descripcion
                                }).ToList();

                }
            }
            return PartialView("_TablaRol",listaRol);
        }

        public int Save(RolModel oRolModel, int Titulo)
        {
            int rpta = 0;
            using (var bd = new DbAseguradoraEntities())
            {
                if (Titulo.Equals(1))
                {
                    TblRol oRol = new TblRol();
                    oRol.Nombre = oRolModel.Nombre;
                    oRol.Descripcion = oRolModel.Descripcion;
                    oRol.BHabilitado = 1;
                    bd.TblRol.Add(oRol);
                    rpta=bd.SaveChanges();
                }
            }
                return rpta;
        }
    }
}