using Aseguradora.Dao;
using Aseguradora.Models;
using Aseguradora.Services;
using Aseguradora.Utils;
using iTextSharp.text;
using iTextSharp.text.pdf;
using OfficeOpenXml;
using OfficeOpenXml.Style;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
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
                Session["lista"] = response.Data;
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

        [HttpGet]
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

        public FileResult generarPdf() {
            Document doc = new Document();
            byte[] buffer;

            using (MemoryStream ms = new MemoryStream())
            {
                PdfWriter.GetInstance(doc, ms);
                doc.Open();

                Paragraph title = new Paragraph("Lista Marca");
                title.Alignment = Element.ALIGN_CENTER;
                doc.Add(title);

                Paragraph espacio = new Paragraph(" ");
                doc.Add(espacio);

                //Columnas (Tabla)
                PdfPTable table = new PdfPTable(3);
                //anchos a las columnas
                float[] values = new float[3] { 30, 40, 80 };
                //asignado esos anchos a la tabla
                table.SetWidths(values);


                //Creando celdas(Poniendo contenido)-color-alineado
                //el contenido al centro
                PdfPCell celda1 = new PdfPCell(new Phrase("Id Aseguradora"));
                celda1.BackgroundColor = new BaseColor(130, 130, 130);
                celda1.HorizontalAlignment = PdfPCell.ALIGN_CENTER;
                table.AddCell(celda1);

                PdfPCell celda2 = new PdfPCell(new Phrase("Nombre"));
                celda2.BackgroundColor = new BaseColor(130, 130, 130);
                celda2.HorizontalAlignment = PdfPCell.ALIGN_CENTER;
                table.AddCell(celda2);

                PdfPCell celda3 = new PdfPCell(new Phrase("Teléfono"));
                celda3.BackgroundColor = new BaseColor(130, 130, 130);
                celda3.HorizontalAlignment = PdfPCell.ALIGN_CENTER;
                table.AddCell(celda3);

                List<AseguradoraModel> lista = (List<AseguradoraModel>)Session["lista"];
                int nregistros = lista.Count;
                for (int i = 0; i < nregistros; i++)
                {
                    table.AddCell(lista[i].IdAseguradora.ToString());
                    table.AddCell(lista[i].Nombre);
                    table.AddCell(lista[i].Telefono);
                }

                doc.Add(table);
                doc.Close();

                buffer = ms.ToArray();
            }


            return File(buffer, "application/pdf");
        }

        public FileResult generarExcel()
        {
            byte[] buffer;

            using (MemoryStream ms = new MemoryStream())
            {
                ExcelPackage.LicenseContext = LicenseContext.NonCommercial;
                //Todo el documento excel
                ExcelPackage ep = new ExcelPackage();
                //Crear un hoja
                ep.Workbook.Worksheets.Add("Reporte");

                ExcelWorksheet ew = ep.Workbook.Worksheets[0];

                //Ponemos nombre de las columnas
                ew.Cells[1, 1].Value = "Id Aseguradora";
                ew.Cells[1, 2].Value = "Nombre";
                ew.Cells[1, 3].Value = "Telefono";
                ew.Column(1).Width = 20;
                ew.Column(2).Width = 40;
                ew.Column(3).Width = 180;
                using (var range = ew.Cells[1, 1, 1, 3])
                {
                    range.Style.Fill.PatternType = ExcelFillStyle.Solid;
                    range.Style.Font.Color.SetColor(Color.White);
                    range.Style.Fill.BackgroundColor.SetColor(Color.DarkRed);
                }
                List<AseguradoraModel> lista = (List<AseguradoraModel>)Session["lista"];
                int nregistros = lista.Count;
                //Pendiente
                for (int i = 0; i < nregistros; i++)
                {
                    ew.Cells[i + 2, 1].Value = lista[i].IdAseguradora;
                    ew.Cells[i + 2, 2].Value = lista[i].Nombre;
                    ew.Cells[i + 2, 3].Value = lista[i].Telefono;

                }
                //Pendiente
                ep.SaveAs(ms);
                buffer = ms.ToArray();

            }

            return File(buffer, "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet");

        }
    }
}