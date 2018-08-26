using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Entities;
using Newtonsoft.Json;

namespace FunClub.Controllers
{
    public class CargaMasivaController : Controller
    {
        // GET: CargaMasiva
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public string CargarEntradas(HttpPostedFileBase file)
        {

            byte[] fileData = null;

            using (var binaryReader = new System.IO.BinaryReader(file.InputStream))
            {
                fileData = binaryReader.ReadBytes(file.ContentLength);
            }

            var rs = BLL.CargasMasivasBLL.CargaMasivaEntrada(file.FileName, fileData);

            return JsonConvert.SerializeObject(rs, Formatting.None,
                        new JsonSerializerSettings()
                        {
                            ReferenceLoopHandling = ReferenceLoopHandling.Ignore
                        });

        }

        [HttpGet]
        public FileResult DescargarEntradasEjemplo()
        {
            string Ruta = @"C:\Users\garigos\Documents\GitHub\Arigos.FunClub\FunClub\CargasMasivas\ArchivoEjemploEntradas.xlsx";
            
            var retorno = File(System.IO.File.ReadAllBytes(Ruta), "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet", "ArchivoEjemploEntradas.xlsx");

            return retorno;
        }


    }
}