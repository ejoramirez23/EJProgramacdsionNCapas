using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PL_MVC.Controllers
{
    public class EmpleadoController : Controller
    {

        // GET: Empleado

        [HttpGet]
        public ActionResult GetAll()
        {
            ML.Empleado empleado = new ML.Empleado();
            empleado.Empresa = new ML.Empresa();

            ML.ResultadosQuerys resutEmpresas = new ML.ResultadosQuerys();
            resutEmpresas = BL.Empresa.EmpresaGetAllEF();

            empleado.Empresa.Empresas = resutEmpresas.Objects;


            empleado.Nombre = (empleado.Nombre == null) ? "" : empleado.Nombre;
            empleado.ApellidoPaterno = (empleado.ApellidoPaterno == null) ? "" : empleado.ApellidoPaterno;
            empleado.ApellidoMaterno = (empleado.ApellidoMaterno == null) ? "" : empleado.ApellidoMaterno;
            empleado.Empresa.IdEmpresa = (empleado.Empresa.IdEmpresa == null) ? 0 : empleado.Empresa.IdEmpresa;

            ML.ResultadosQuerys result = BL.Empleado.GetAllEF(empleado);

            empleado.Empleados = new List<object>();

            if (result.Correct)
            {
                empleado.Empleados = result.Objects;


            }


            return View(empleado);
        }



        [HttpPost]

        public ActionResult GetAll(ML.Empleado empleado)
        {

            empleado.Nombre = (empleado.Nombre == null) ? "" : empleado.Nombre;
            empleado.ApellidoPaterno = (empleado.ApellidoPaterno == null) ? "" : empleado.ApellidoPaterno;
            empleado.ApellidoMaterno = (empleado.ApellidoMaterno == null) ? "" : empleado.ApellidoMaterno;
            empleado.Empresa.IdEmpresa = (empleado.Empresa.IdEmpresa == null) ? 0 : empleado.Empresa.IdEmpresa;

            ML.ResultadosQuerys resutEmpresas = new ML.ResultadosQuerys();
            resutEmpresas = BL.Empresa.EmpresaGetAllEF();


           
            empleado.Empresa.Empresas = resutEmpresas.Objects;

            ML.ResultadosQuerys result = BL.Empleado.GetAllEF(empleado);

            empleado.Empleados = new List<object>();

            if (result.Correct)
            {
                empleado.Empleados = result.Objects;
            }

            return View(empleado);
        }








        [HttpGet]

        public ActionResult Form(string numeroEmpleado)
        {

            ML.Empleado empleado = new ML.Empleado();

            ML.ResultadosQuerys resutEmpresas = new ML.ResultadosQuerys();
            resutEmpresas = BL.Empresa.EmpresaGetAllEF();





            empleado.Empresa = new ML.Empresa();
            empleado.Empresa.Empresas = resutEmpresas.Objects;



            if (numeroEmpleado == null)
            {

                @ViewBag.Accion = "Agregar";

            }
            else
            {
                @ViewBag.Accion = "Actualizar";

                //usuario.IdUsuario = IdUsuario.Value;

                ML.ResultadosQuerys result = BL.Empleado.GetByIdEF(numeroEmpleado);

                if (result.Correct)
                {



                    empleado = (ML.Empleado)result.Object;




                    empleado.Empresa.Empresas = resutEmpresas.Objects;
                }

            }

            return View(empleado);

        }






        [HttpPost]
        public ActionResult Form(ML.Empleado empleado, HttpPostedFileBase fuFoto)
        {

            if (ModelState.IsValid)
            {

                if (fuFoto != null)
                {
                    empleado.Foto = convertFileToByteArray(fuFoto);
                }

                ML.ResultadosQuerys result = new ML.ResultadosQuerys();

               

                if (empleado.NumeroEmpleado == null) //ejecutara Add empleado
                {

                    empleado.NumeroEmpleado = "Empleado"+empleado.RFC;

                    result = BL.Empleado.AddEF(empleado);

                    if (result.Correct)
                    {

                        ViewBag.Message = result.Message;
                        return View("Modal");
                    }
                    else
                    {
                        return View("Modal");
                    }


                }
                else
                {

                    result = BL.Empleado.UpdateEF(empleado);



                    if (result.Correct)
                    {
                        ViewBag.Message = result.Message;
                        return View("Modal");
                    }
                    else
                    {
                        ViewBag.Message = result.Message;
                        return View("Modal");
                    }

                }

            }
            else
            {
                ML.ResultadosQuerys resutEmpresas = new ML.ResultadosQuerys();
                resutEmpresas = BL.Empresa.EmpresaGetAllEF();


              

                empleado.Empresa = new ML.Empresa();
                empleado.Empresa.Empresas = resutEmpresas.Objects;

                return View(empleado);
            }


        }



        [HttpGet]

        public ActionResult Delete(string NumeroEmpleado)
        {
            if (NumeroEmpleado != "")
            {
                ViewBag.Accion = "Eliminar";
                ViewBag.Message = "Desea eliminar el empleado";
                
                return View(NumeroEmpleado);
            }
            else
            {

                ViewBag.Message = "No se encontro el empleado";
                return View("Modal");
            }


        }



        [HttpPost]

        public ActionResult Delete(ML.Usuario usuario)
        {

            ML.ResultadosQuerys result = new ML.ResultadosQuerys();

            if (usuario.IdUsuario != 0)
            {
                result = BL.Usuario.DeleteEF(usuario.IdUsuario);

                if (result.Correct)
                {
                    ViewBag.Message = result.Message;
                    return View("Modal");
                }
                else
                {
                    ViewBag.Message = result.Message;
                    return View("Modal");
                }
            }
            else
            {
                ViewBag.Message = "no se encontro el usuario";
                return View("Modal");
            }


        }














        public byte[] convertFileToByteArray(HttpPostedFileBase fuFoto)
        {

            MemoryStream target = new MemoryStream();
            fuFoto.InputStream.CopyTo(target);
            byte[] data = target.ToArray();

            return data;
        }

















    }
}