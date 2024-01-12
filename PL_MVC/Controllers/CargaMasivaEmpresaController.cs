using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PL_MVC.Controllers
{
    public class CargaMasivaEmpresaController : Controller
    {
        // GET: CargaMasivaEmpresa


        [HttpGet]

        public ActionResult CargaMasiva()
        {
            ML.Empresa empresa = new ML.Empresa();
            return View(empresa);
        }



        [HttpPost]

        public ActionResult CargaMasiva(HttpPostedFileBase excel)
        {

            if (Session["DireccionExcel"] == null)
            {

                if (excel != null)
                {


                    string extensionArchivo = Path.GetExtension(excel.FileName).ToLower();
                    string extensionValida = ConfigurationManager.AppSettings["TipoExcel"];


                    if (extensionArchivo == extensionValida)
                    {
                        string rutaProyecto = Server.MapPath("~/EmpresaCargaMasiva/");

                        string filePath = rutaProyecto + Path.GetFileNameWithoutExtension(excel.FileName) + "-" + DateTime.Now.ToString("yyyyMMddHHmmss") + extensionValida;

                        if (!System.IO.File.Exists(filePath))
                        {

                            excel.SaveAs(filePath);

                        }
                        string connectionStringExcel = ConfigurationManager.AppSettings["ConnectionString"];

                        ViewBag.Message = "Se guardo correctamente el Excel";

                        ML.Empresa empresa = new ML.Empresa();

                        empresa = BL.Empresa.PrevizualizarExcel(empresa, filePath, connectionStringExcel);

                        if (empresa.IsValidExcel == true)
                        {
                            Session["DireccionExcel"] = filePath;
                            Session["ListEmpresas"] = empresa.Empresas;
                        }
                        else
                        {

                        }


                        return View(empresa);


                    }
                    else
                    {
                        ViewBag.Message = "Porfavor seleccione un archivo valido de tipo Excel";
                        return View("Modal");
                    }


                }
                else
                {
                    ViewBag.Message = "Porfavor seleccione un archivo";
                    return View("Modal");
                }


            }
            else
            {


                string filePath = Session["DireccionExcel"].ToString();


                ML.Empresa empresa = new ML.Empresa();
                empresa.Empresas = (List<Object>)Session["ListEmpresas"];

                ML.ResultadosQuerys result = BL.Empresa.EmpresaAddEF(empresa);


                if (result.Correct)
                {
                    ViewBag.Message = "Se insertaron los registros del excel correctamente";
                    return View("Modal");
                    Session["DireccionExcel"] = null;
                    Session["ListEmpresas"] = null;
                }
                else
                {
                    ViewBag.Message = "Porfavor seleccione un archivo";
                    return View("Modal");
                }
            }

        }






    }
}