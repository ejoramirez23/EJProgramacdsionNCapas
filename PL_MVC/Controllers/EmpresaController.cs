using System;
using System.Collections.Generic;
using System.Configuration;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Net.Http;
using System.Security.Policy;
using System.Web;
using System.Web.Mvc;

namespace PL_MVC.Controllers
{
    public class EmpresaController : Controller
    {

        //Metodo Get Empresa con Servicio WCF 

        //[HttpGet]
        //public ActionResult GetAll()
        //{
        //    ML.Empresa empresa = new ML.Empresa();


        //    //ML.ResultadosQuerys result = BL.Empresa.EmpresaGetAllEF();

        //    EmpresaService.EmpresaClient empresaService = new EmpresaService.EmpresaClient();


        //    ML.ResultadosQuerys result = empresaService.GetAll();


        //    empresa.Empresas = new List<object>();

        //    if (result.Correct)
        //    {
        //        empresa.Empresas = result.Objects;


        //    }


        //    return View(empresa);
        //}



        //Metodo Get Empresa con Servicio WCF 

        [HttpGet]
        public ActionResult GetAll()
        {
            ML.ResultadosQuerys result = new ML.ResultadosQuerys();

            ML.Empresa empresa = new ML.Empresa();

            using (var client = new HttpClient())
            {
                string urlAPIEmpresa = ConfigurationManager.AppSettings["urlAPIEmpresa"];

                client.BaseAddress = new Uri(urlAPIEmpresa);

                var responseTask = client.GetAsync("getall");
                responseTask.Wait();

                var resultApiStatus = responseTask.Result;

                result.Objects = new List<object>();

                if (resultApiStatus.IsSuccessStatusCode)
                {
                    var resultObjects = resultApiStatus.Content.ReadAsAsync<ML.ResultadosQuerys>();
                    resultObjects.Wait();

                    foreach (var resultItem in resultObjects.Result.Objects)
                    {
                        empresa = Newtonsoft.Json.JsonConvert.DeserializeObject<ML.Empresa>(resultItem.ToString());
                        result.Objects.Add(empresa);
                    }

                    empresa.Empresas = result.Objects;
                }


            }


            return View(empresa);
        }





        //[HttpGet]

        //public ActionResult Form(int? idEmpresa)
        //{

        //    ML.Empresa empresa = new ML.Empresa();



        //    if (idEmpresa == null)
        //    {

        //        @ViewBag.Accion = "Agregar";

        //    }
        //    else
        //    {
        //        @ViewBag.Accion = "Actualizar";


        //        ML.ResultadosQuerys result = BL.Empresa.EmpresaGetByIdEF(idEmpresa);

        //        if (result.Correct)
        //        {

        //            empresa = (ML.Empresa)result.Object;

        //        }

        //    }

        //    return View(empresa);

        //}


        [HttpGet]

        public ActionResult Form(int? idEmpresa)
        {

            ML.Empresa empresa = new ML.Empresa();



            if (idEmpresa == null)
            {

                @ViewBag.Accion = "Agregar";

            }
            else
            {
                @ViewBag.Accion = "Actualizar";


                ML.ResultadosQuerys result = new ML.ResultadosQuerys();

                try
                {

                    using (var client = new HttpClient())
                    {
                        //RecuperarBaseAddress de AppSettings 
                        string urlAPIEmpresa = ConfigurationManager.AppSettings["urlAPIEmpresa"];

                        client.BaseAddress = new Uri(urlAPIEmpresa);

                        var responseTask = client.GetAsync("getbyid/"+ idEmpresa);
                        responseTask.Wait();

                        var resultServicio = responseTask.Result;

                        if (resultServicio.IsSuccessStatusCode)
                        {
                            var readTask = resultServicio.Content.ReadAsAsync<ML.ResultadosQuerys>();
                            readTask.Wait();


                            ML.Empresa resultItemList = new ML.Empresa();
                            resultItemList = Newtonsoft.Json.JsonConvert.DeserializeObject<ML.Empresa>(readTask.Result.Object.ToString());
                            result.Object = resultItemList;

                            result.Correct = true;


                            empresa = (ML.Empresa)result.Object;
                        }
                    }

                }
                catch (Exception ex)
                {
                    result.Correct = false;
                    result.Message = ex.Message;
                }




            }

            return View(empresa);

        }



        //[HttpPost]

        //public ActionResult Form(ML.Empresa empresa)
        //{

        //    empresa.IdEmpresa = (empresa.IdEmpresa == null) ? 0:empresa.IdEmpresa;


        //    ML.ResultadosQuerys result = new ML.ResultadosQuerys();

        //    if (empresa.IdEmpresa == 0)
        //    {

        //        result = BL.Empresa.EmpresaAddEF(empresa);

        //        if (result.Correct)
        //        {

        //            ViewBag.Message = result.Message;
        //            return RedirectToAction("GetAll");
        //        }
        //        else
        //        {
        //            return RedirectToAction("Form");
        //        }

        //    }
        //    else
        //    {
        //        result = BL.Empresa.EmpresaUpdateEF(empresa);

        //        if (result.Correct)
        //        {

        //            ViewBag.Message = result.Message;
        //            return RedirectToAction("GetAll");
        //        }
        //        else
        //        {
        //            return RedirectToAction("Form");
        //        }

        //    }



        //}



        [HttpPost]

        public ActionResult Form(ML.Empresa empresa)
        {

            empresa.IdEmpresa = (empresa.IdEmpresa == null) ? 0 : empresa.IdEmpresa;


            ML.ResultadosQuerys result = new ML.ResultadosQuerys();

            if (empresa.IdEmpresa == 0)
            {

                using (var client = new HttpClient())
                {

                    string urlAPIEmpresa = ConfigurationManager.AppSettings["urlAPIEmpresa"];

                    client.BaseAddress = new Uri(urlAPIEmpresa);


                    var postTask = client.PostAsJsonAsync<ML.Empresa>("Add/", empresa);
                    postTask.Wait();

                    var resultApiEmpresa = postTask.Result;
                    if (resultApiEmpresa.IsSuccessStatusCode)
                    {
                        return RedirectToAction("GetAll");
                    }
                }

                return RedirectToAction("GetAll");

            }
            else
            {


                using (var client = new HttpClient())
                {

                    string urlAPIEmpresa = ConfigurationManager.AppSettings["urlAPIEmpresa"];

                    client.BaseAddress = new Uri(urlAPIEmpresa);


                    var postTask = client.PostAsJsonAsync<ML.Empresa>("update/"+ empresa.IdEmpresa, empresa);
                    postTask.Wait();

                    var resultApiEmpresa = postTask.Result;
                    if (resultApiEmpresa.IsSuccessStatusCode)
                    {
                        return RedirectToAction("GetAll");
                    }
                }

                return RedirectToAction("GetAll");





            }

        }



        [HttpPost]

        public JsonResult DeleteEmpresa(int IdEmpresa)
        {

            ML.ResultadosQuerys resultListProduct = new ML.ResultadosQuerys();
            
            using (var client = new HttpClient())
            {

                string urlAPIEmpresa = ConfigurationManager.AppSettings["urlAPIEmpresa"];

                client.BaseAddress = new Uri(urlAPIEmpresa);

            

                //HTTP POST



                var postTask = client.GetAsync("delete/" + IdEmpresa);
                postTask.Wait();

                var result = postTask.Result;
                if (result.IsSuccessStatusCode)
                {
                   
                }
            }


          



            return Json("listo");

        }


    }
}