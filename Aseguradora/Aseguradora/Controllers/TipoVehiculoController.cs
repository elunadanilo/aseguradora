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
    public class TipoVehiculoController : Controller
    {
        // GET: TipoVehiculo
        private ITipoVehiculoDao tipovehiculodao = new TipoVehiculoService();
        public ActionResult Index()
        {
            OperationResponse response = tipovehiculodao.GetAll();

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
        public async Task<ActionResult> Add(TipoVehiculoModel oTipoVehiculoModel)
        {

            if (!ModelState.IsValid)
            {
                return View(oTipoVehiculoModel);
            }
            else
            {
                OperationResponse response = await tipovehiculodao.Save(oTipoVehiculoModel);
            }

            return RedirectToAction("Index");
        }

        public ActionResult Edit(int Id)
        {

            OperationResponse response = tipovehiculodao.GetById(Id);

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
        public async Task<ActionResult> Edit(TipoVehiculoModel oTipoVehiculo)
        {
            if (!ModelState.IsValid)
            {
                return View(oTipoVehiculo);
            }

            int IdTipoVehiculo = oTipoVehiculo.IdTipoVehiculo;
            OperationResponse response = await tipovehiculodao.Update(IdTipoVehiculo, oTipoVehiculo);

            if (response.Code == 1)
            {
                return RedirectToAction("Index");
            }
            else
            {
                return RedirectToAction("Index");
            }
        }

        public async Task<ActionResult> Delete(int IdTipoVehiculo)
        {
            OperationResponse response = await tipovehiculodao.Delete(IdTipoVehiculo);
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