using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;






namespace PL_MVC.Controllers
{
    public class CargaMasivaUsuarioController : Controller
    {
        // GET: CargaMasivaUsuario
        


        [HttpGet]

        public ActionResult CargaMasivaExcel()
        {
            return View();
        }


        [HttpPost]

        public ActionResult CargaMasivaExcel(HttpPostedFileBase cargaMasivaExcel)
        {







            DateTime dateAndTime = DateTime.Now;

            if (cargaMasivaExcel.ContentLength == 0)
            {
                ViewBag.Message = "No se guardo el archivo";
                return View("Modal");
            }
            else
            {
                if (cargaMasivaExcel.FileName.EndsWith("xls")  || cargaMasivaExcel.FileName.EndsWith("xlsx"))
                {

                    string saveName = dateAndTime.Day + "-" + dateAndTime.Month + "-" + dateAndTime.Year + " " + dateAndTime.TimeOfDay.Hours + " " + dateAndTime.TimeOfDay.Minutes + " " + dateAndTime.TimeOfDay.Seconds + " " + cargaMasivaExcel.FileName;

                    string path = Server.MapPath("~/UsuarioCargaMasiva/" + saveName);

                    if (System.IO.File.Exists(path))
                        System.IO.File.Delete(path);    
                    cargaMasivaExcel.SaveAs(path);


                }

                    ViewBag.Message = "Se guardo el archivo";
                return View("Modal");



            }

        }




    }
}