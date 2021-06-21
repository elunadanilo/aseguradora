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
    public class FormaDePagoController : Controller
    {
        private IFormaDePagoDao formadepagodao = new FormaDePagoService();
        // GET: FormaDePago
        public ActionResult Index()
        {
            OperationResponse response = formadepagodao.GetAll();

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
        public async Task<ActionResult> Add(FormaDePagoModel oFormaDePagoModel)
        {

            if (!ModelState.IsValid)
            {
                return View(oFormaDePagoModel);
            }
            else
            {
                OperationResponse response = await formadepagodao.Save(oFormaDePagoModel);
            }

            return RedirectToAction("Index");
        }

        public ActionResult Add()
        {

            return View();
        }

        //Se recuperan los datos para mostrar en el formulario de edicion
        public ActionResult Edit(int Id)
        {
            OperationResponse response = formadepagodao.GetById(Id);

            if (response.Code == 1)
            {
                return View(response.Data);
            }
            else
            {
                return View();
            }
        }

        //Se realiza el update con los datos obtenidos del formulario de edicion
        [HttpPost]
        public async Task<ActionResult> Edit(FormaDePagoModel oFormaDePago)
        {
            if (!ModelState.IsValid)
            {
                return View(oFormaDePago);
            }

            int IdFormaDePago = oFormaDePago.IdFormaDePago;
            OperationResponse response = await formadepagodao.Update(IdFormaDePago, oFormaDePago);

            if (response.Code == 1)
            {
                return RedirectToAction("Index");
            }
            else
            {
                return RedirectToAction("Index");
            }
        }

        public async Task<ActionResult> Delete(int IdFormaDePago)
        {
            OperationResponse response = await formadepagodao.Delete(IdFormaDePago);
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