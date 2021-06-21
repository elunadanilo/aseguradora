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
    public class AseguradoraController : Controller
    {
        private IAseguradoraDao aseguradoradao = new AseguradoraService();
        // GET: Aseguradora
        public ActionResult Index()
        {
            OperationResponse response = aseguradoradao.GetAll();
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
        public async Task<ActionResult> Add(AseguradoraModel oAseguradoraModel)
        {

            if (!ModelState.IsValid)
            {
                return View(oAseguradoraModel);
            }
            else
            {
                OperationResponse response = await aseguradoradao.Save(oAseguradoraModel);
            }

            return RedirectToAction("Index");
        }

        public ActionResult Edit(int Id)
        {

            OperationResponse response = aseguradoradao.GetById(Id);

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
        public async Task<ActionResult> Edit(AseguradoraModel oAseguradora)
        {

            if (!ModelState.IsValid)
            {
                return View(oAseguradora);
            }

            int IdAseguradora = oAseguradora.IdAseguradora;
            OperationResponse response = await aseguradoradao.Update(IdAseguradora, oAseguradora);

            if (response.Code == 1)
            {
                return RedirectToAction("Index");
            }
            else
            {
                return RedirectToAction("Index");
            }
        }

        public async Task<ActionResult> Delete(int IdAseguradora)
        {
            OperationResponse response = await aseguradoradao.Delete(IdAseguradora);
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