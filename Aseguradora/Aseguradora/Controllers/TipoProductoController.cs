using Aseguradora.Dao;
using Aseguradora.Models;
using Aseguradora.Services;
using Aseguradora.Utils;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace Aseguradora.Controllers
{
    public class TipoProductoController : Controller
    {
        private ITipoProductoDao tipoproductodao = new TipoProductoService();
        private IProductoDao productodao = new ProductoService();
        private IAseguradoraDao aseguradoradao = new AseguradoraService();
        // GET: TipoProducto
        public ActionResult Index()
        {
            OperationResponse response = tipoproductodao.GetAll();

            if (response.Code == 1)
            {
                return View(response.Data);
            }
            else
            {
                return View();
            }
        }

        public ActionResult Add()
        {
            listarAseguradora();
            return View();
        }

        [HttpPost]
        public async Task<ActionResult> Add(TipoProductoModel oTipoProductoModel)
        {
            if (!ModelState.IsValid)
            {
                listarAseguradora();
                return View(oTipoProductoModel);
            }
            else
            {
                OperationResponse response = await tipoproductodao.Save(oTipoProductoModel);
            }

            return RedirectToAction("Index");
        }


        public ActionResult Edit(int Id)
        {

            OperationResponse response = tipoproductodao.GetById(Id);

            if (response.Code == 1)
            {
                return View(response.Data);
            }
            else
            {
                return View();
            }
        }

        public async Task<ActionResult> Edit(TipoProductoModel oTipoProducto)
        {
            if (!ModelState.IsValid)
            {
                //listarProducto(id);
                return View(oTipoProducto);
            }

            int IdTipoProducto = oTipoProducto.IdTipoProducto;
            OperationResponse response = await tipoproductodao.Update(IdTipoProducto, oTipoProducto);

            if (response.Code == 1)
            {
                return RedirectToAction("Index");
            }
            else
            {
                return RedirectToAction("Index");
            }
        }

        public async Task<ActionResult> Delete(int IdTipoProducto)
        {
            OperationResponse response = await tipoproductodao.Delete(IdTipoProducto);
            if (response.Code == 1)
            {
                return RedirectToAction("Index");
            }
            else
            {
                return RedirectToAction("Index");
            }
        }

        //public ActionResult ListarProducto(int IdAseguradora)
        //{
        //    OperationResponse response = productodao.GetListProducto(IdAseguradora);


        //        return Json(response.Data);

        //}
        public ActionResult ListarProducto(int IdAseguradora)
        {
            OperationResponse response = productodao.GetListProducto(IdAseguradora);
            return Json(response.Data, JsonRequestBehavior.AllowGet);
        }

        public void listarAseguradora()
        {
            OperationResponse response = aseguradoradao.GetListAseguradora();
            ViewBag.listaAseguradora = response.Data;
        }
    }
}