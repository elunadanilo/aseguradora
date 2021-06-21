using Aseguradora.Dao;
using Aseguradora.Models;
using Aseguradora.Services;
using Aseguradora.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace Aseguradora.Controllers
{
    public class ProductoController : Controller
    {
        private IProductoDao productodao = new ProductoService();
        // GET: Producto
        public ActionResult Index()
        {
            OperationResponse response = productodao.GetAll();
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

            return View();
        }

        [HttpPost]
        public async Task<ActionResult> Add(ProductoModel oProductoModel)
        {

            if (!ModelState.IsValid)
            {
                return View(oProductoModel);
            }
            else
            {
                OperationResponse response = await productodao.Save(oProductoModel);

            }

            return RedirectToAction("Index");
        }

        public ActionResult Edit(int Id)
        {
            OperationResponse response = productodao.GetById(Id);
            if (response.Code == 1)
            {
                return View(response.Data);
            }
            else
            {
                return View();
            }
        }

        [HttpPost]
        public async Task<ActionResult> Edit(ProductoModel oProducto)
        {
            if (!ModelState.IsValid)
            {
                return View(oProducto);
            }
            int IdProducto = oProducto.IdProducto;
            OperationResponse response = await productodao.Update(IdProducto, oProducto);

            if (response.Code == 1)
            {
                return RedirectToAction("Index");
            }
            else
            {
                return RedirectToAction("Index");
            }
        }

        public async Task<ActionResult> Delete(int IdProducto)
        {
            OperationResponse response = await productodao.Delete(IdProducto);
            if (response.Code == 1)
            {
                return RedirectToAction("Index");
            }
            else
            {
                return RedirectToAction("Index");
            }
        }

    }
}