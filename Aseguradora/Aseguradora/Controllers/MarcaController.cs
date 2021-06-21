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
    public class MarcaController : Controller
    {
        // GET: Marca
        private IMarcaDao marcadao = new MarcaService();
        public ActionResult Index()
        {
            OperationResponse response = marcadao.GetAll();
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
        public async Task<ActionResult> Add(MarcaModel oMarcaModel)
        {
            if (!ModelState.IsValid)
            {
                return View(oMarcaModel);
            }
            else
            {
                OperationResponse response = await marcadao.Save(oMarcaModel);
            }

            return RedirectToAction("Index");
        }


        public ActionResult Add()
        {

            return View();
        }

        public ActionResult Edit(int Id)
        {

            OperationResponse response = marcadao.GetById(Id);
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
        public async Task<ActionResult> Edit(MarcaModel oMarca)
        {
            if (!ModelState.IsValid)
            {
                return View(oMarca);
            }
            int IdMarca = oMarca.IdMarca;
            OperationResponse response = await marcadao.Update(IdMarca, oMarca);
            if (response.Code == 1)
            {
                return RedirectToAction("Index");
            }
            else
            {
                return RedirectToAction("Index");
            }
        }

        [HttpPost]
        public async Task<ActionResult> Delete(int IdMarca)
        {
            OperationResponse response = await marcadao.Delete(IdMarca);
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