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
    public class ClienteController : Controller
    {
        private IClienteDao clientedao = new ClienteService();
        private IMunicipioDao municipiodao = new MunicipioService();
        private IDepartamentoDao departamentodao = new DepartamentoService();
        // GET: Cliente
        //public ActionResult Index()
        //{
        //    OperationResponse response = clientedao.GetAll();

        //    if (response.Code == 1)
        //    {
        //        return View(response.Data);
        //    }
        //    else
        //    {
        //        return View();
        //    }
        //}

        public ActionResult Index(ClienteModel oCliente)
        {
            OperationResponse response = clientedao.GetClientesPorFiltro(oCliente);

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
            ListarCombos();

            return View();
        }

        [HttpPost]
        public async Task<ActionResult> Add(ClienteModel oClienteModel)
        {

            if (!ModelState.IsValid)
            {
                ListarCombos();
                return View(oClienteModel);
            }
            else
            {
                OperationResponse response = await clientedao.Save(oClienteModel);
            }

            return RedirectToAction("Index");
        }


        public ActionResult Edit(int Id)
        {
            OperationResponse response = clientedao.GetById(Id);

            if (response.Code == 1)
            {
                ListarCombos();
                return View(response.Data);
            }
            else
            {
                return View();
            }
        }

        [HttpPost]
        public async Task<ActionResult> Edit(ClienteModel oCliente)
        {
            if (!ModelState.IsValid)
            {
                ListarCombos();
                return View(oCliente);
            }

            int IdCliente = oCliente.IdCliente;
            OperationResponse response = await clientedao.Update(IdCliente, oCliente);

            if (response.Code == 1)
            {
                return RedirectToAction("Index");
            }
            else
            {
                return RedirectToAction("Index");
            }
        }

        public async Task<ActionResult> Delete(int id)
        {
            OperationResponse response = await clientedao.Delete(id);
            if (response.Code == 1)
            {
                return RedirectToAction("Index");
            }
            else
            {
                return RedirectToAction("Index");
            }
        }

        public void listarDepartamento()
        {
            OperationResponse response = departamentodao.GetListDepartamento();
            ViewBag.listaDepartamento = response.Data;
        }

        public void listarMunicipio()
        {
            OperationResponse response = municipiodao.GetListMunicipio();
            ViewBag.listaMunicipio = response.Data;
        }

        public void ListarCombos()
        {
            listarDepartamento();
            listarMunicipio();
        }
    }
}