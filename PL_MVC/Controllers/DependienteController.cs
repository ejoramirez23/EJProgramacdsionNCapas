using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PL_MVC.Controllers
{
    public class DependienteController : Controller
    {
        // GET: Dependiente


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





        public ActionResult EmpleadoDependiente(string numeroEmpleado, string nombre, string apellidoPaterno, string apellidoMaterno)
        {

            ML.Empleado empleado = new ML.Empleado();

            if (Session["NumeroEmpleado"] == null)
            {
                ML.ResultadosQuerys result = BL.Dependiente.GetByNumeroEmpleado(numeroEmpleado);

                if (result.Correct)
                {

                    empleado.Dependiente = new ML.Dependiente();

                    empleado.Dependiente.Dependientes = result.Objects;

                    empleado.Nombre = nombre;
                    empleado.ApellidoPaterno = apellidoPaterno;
                    empleado.ApellidoMaterno = apellidoMaterno;

                    Session["NumeroEmpleado"] = numeroEmpleado;
                    Session["NombreEmpleado"] = nombre;
                    Session["APaternoEmpleado"] = apellidoPaterno;
                    Session["AMaternoEmpleado"] = apellidoMaterno;

                }
                else
                {
                    ViewBag.Message = result.Message;
                }
            }

            return View(empleado);
        }


















    }
}