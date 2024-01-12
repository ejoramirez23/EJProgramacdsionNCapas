using Microsoft.Ajax.Utilities;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Services.Description;


namespace PL_MVC.Controllers
{
    public class UsuarioController : Controller
    {



        [HttpGet]
        // GET: Usuario
        public ActionResult GetAll()
        {
            ML.Usuario usuario = new ML.Usuario();
            usuario.Rol = new ML.Rol();

            ML.ResultadosQuerys resutRoles = new ML.ResultadosQuerys();
            resutRoles = BL.Rol.GetAllEF();

            usuario.Rol.Roles = resutRoles.Objects;


            usuario.Nombre = (usuario.Nombre == null) ? "" : usuario.Nombre;
            usuario.ApellidoPaterno = (usuario.ApellidoPaterno == null) ? "" : usuario.ApellidoPaterno;
            usuario.ApellidoMaterno = (usuario.ApellidoMaterno == null) ? "" : usuario.ApellidoMaterno;
            usuario.Rol.IdRol = (usuario.Rol.IdRol == null) ? 0 : usuario.Rol.IdRol;

            ML.ResultadosQuerys result = BL.Usuario.GetAllEF(usuario);

            usuario.Usuarios = new List<object>();

            if (result.Correct)
            {
                usuario.Usuarios = result.Objects;


            }


            return View(usuario);
        }


        [HttpPost]

        public ActionResult GetAll(ML.Usuario usuario)
        {

            usuario.Nombre = (usuario.Nombre == null) ? "" : usuario.Nombre;
            usuario.ApellidoPaterno = (usuario.ApellidoPaterno == null) ? "" : usuario.ApellidoPaterno;
            usuario.ApellidoMaterno = (usuario.ApellidoMaterno == null) ? "" : usuario.ApellidoMaterno;
            usuario.Rol.IdRol = (usuario.Rol.IdRol == null) ? 0 : usuario.Rol.IdRol;

            ML.ResultadosQuerys resutRoles = new ML.ResultadosQuerys();
            resutRoles = BL.Rol.GetAllEF();

            usuario.Rol.Roles = resutRoles.Objects;

            ML.ResultadosQuerys result = BL.Usuario.GetAllEF(usuario);

            usuario.Usuarios = new List<object>();

            if (result.Correct)
            {
                usuario.Usuarios = result.Objects;
            }

            return View(usuario);
        }


      


        [HttpGet]

        public ActionResult Form(int? idUsuario)
        {

            ML.Usuario usuario = new ML.Usuario();

            ML.ResultadosQuerys resutRoles = new ML.ResultadosQuerys();
            resutRoles = BL.Rol.GetAllEF();

            ML.ResultadosQuerys resultPaises = new ML.ResultadosQuerys();
            resultPaises = BL.Pais.GetAllPais();

            usuario.Direccion = new ML.Direccion();
            usuario.Direccion.Colonia = new ML.Colonia();
            usuario.Direccion.Colonia.Municipio = new ML.Municipio();
            usuario.Direccion.Colonia.Municipio.Estado = new ML.Estado();
            usuario.Direccion.Colonia.Municipio.Estado.Pais = new ML.Pais();
            usuario.Direccion.Colonia.Municipio.Estado.Pais.Paises = resultPaises.Objects;

            usuario.Rol = new ML.Rol();
            usuario.Rol.Roles = resutRoles.Objects;



            if (idUsuario == null)
            {

                @ViewBag.Accion = "Agregar";

            }
            else
            {
                @ViewBag.Accion = "Actualizar";

                //usuario.IdUsuario = IdUsuario.Value;

                ML.ResultadosQuerys result = BL.Usuario.GetByIdEF(idUsuario);

                if (result.Correct)
                {

                    usuario.Direccion = new ML.Direccion();
                    usuario.Direccion.Colonia = new ML.Colonia();
                    usuario.Direccion.Colonia.Municipio = new ML.Municipio();
                    usuario.Direccion.Colonia.Municipio.Estado = new ML.Estado();
                    usuario.Direccion.Colonia.Municipio.Estado.Pais = new ML.Pais();

                    usuario = (ML.Usuario)result.Object;

                    ML.ResultadosQuerys resultEstados = BL.Estado.EstadoGetById(usuario.Direccion.Colonia.Municipio.Estado.Pais.IdPais);
                    ML.ResultadosQuerys resultMunicipios = BL.Municipio.MunicipioGetById(usuario.Direccion.Colonia.Municipio.Estado.IdEstado);
                    ML.ResultadosQuerys resultColonias = BL.Colonia.ColoniaGetById(usuario.Direccion.Colonia.Municipio.IdMunicipio);

                    usuario.Direccion.Colonia.Municipio.Estado.Pais.Paises = resultPaises.Objects;
                    usuario.Direccion.Colonia.Municipio.Estado.Estados = resultEstados.Objects;
                    usuario.Direccion.Colonia.Municipio.Municipios = resultMunicipios.Objects;
                    usuario.Direccion.Colonia.Colonias = resultColonias.Objects;

                    usuario.Rol.Roles = resutRoles.Objects;
                }

            }

            return View(usuario);

        }





        [HttpPost]
        public ActionResult Form(ML.Usuario usuario, HttpPostedFileBase fuImagen)
        {

            if (ModelState.IsValid)
            {

                if (fuImagen != null)
                {
                    usuario.Imagen = convertFileToByteArray(fuImagen);
                }

                ML.ResultadosQuerys result = new ML.ResultadosQuerys();

                // SOLO CONVIERTE EL CURP EN MAYUSCULAS     
                usuario.CURP = usuario.CURP.ToUpper();

                if (usuario.IdUsuario == 0) //ejecutara Add
                {

                    result = BL.Usuario.AddEF(usuario);

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

                    result = BL.Usuario.UpdateEF(usuario);



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
                ML.ResultadosQuerys resutRoles = new ML.ResultadosQuerys();
                resutRoles = BL.Rol.GetAllEF();

                ML.ResultadosQuerys resultPaises = new ML.ResultadosQuerys();
                resultPaises = BL.Pais.GetAllPais();

                usuario.Direccion = new ML.Direccion();
                usuario.Direccion.Colonia = new ML.Colonia();
                usuario.Direccion.Colonia.Municipio = new ML.Municipio();
                usuario.Direccion.Colonia.Municipio.Estado = new ML.Estado();
                usuario.Direccion.Colonia.Municipio.Estado.Pais = new ML.Pais();
                usuario.Direccion.Colonia.Municipio.Estado.Pais.Paises = resultPaises.Objects;

                usuario.Rol = new ML.Rol();
                usuario.Rol.Roles = resutRoles.Objects;

                return View(usuario);
            }


        }





        [HttpGet]

        public ActionResult Delete(int? IdUsuario)
        {
            if (IdUsuario != null)
            {
                ViewBag.Accion = "Eliminar";
                ViewBag.Message = "Desea eliminar el usuario";
                ML.Usuario usuario = new ML.Usuario();

                usuario.IdUsuario = IdUsuario.Value;
                return View(usuario);
            }
            else
            {

                ViewBag.Message = "No se encontro el usuario";
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



        [HttpGet]

        public ActionResult CargaMasiva()
        {
            return View();
        }


        [HttpPost]

        public ActionResult CargaMasiva(HttpPostedFileBase cargaMasiva)
        {
            
            using(StreamReader file = new StreamReader(cargaMasiva.InputStream))
            {

                string row = file.ReadLine();

                while (!file.EndOfStream)
                {
                    row = file.ReadLine();

                    string[] rowFinal = row.Split('|');


                    ML.Empresa empresa = new ML.Empresa();

                    empresa.Nombre = rowFinal[0];   
                    empresa.Telefono = rowFinal[1];
                    empresa.Email = rowFinal[2];
                    empresa.DireccionWeb = rowFinal[3]; 

                    ML.ResultadosQuerys result = BL.Empresa.EmpresaAddEF(empresa);


                    ViewBag.Message = result.Message;

                }


           
            }
            

            return View("ModalEmpresa");

        }




        public byte[] convertFileToByteArray(HttpPostedFileBase fuImagen)
        {

            MemoryStream target = new MemoryStream();
            fuImagen.InputStream.CopyTo(target);
            byte[] data = target.ToArray();

            return data;
        }


        public JsonResult GetByIdEstado(int idPais)
        {
            ML.ResultadosQuerys result = BL.Estado.EstadoGetById(idPais);
            return Json(result.Objects);
        }

        public JsonResult GetByIdMunicipio(int idEstado)
        {
            ML.ResultadosQuerys result = BL.Municipio.MunicipioGetById(idEstado);
            return Json(result.Objects);
        }

        public JsonResult GetByIdColonia(int idMunicipio)
        {
            ML.ResultadosQuerys result = BL.Colonia.ColoniaGetById(idMunicipio);
            return Json(result.Objects);
        }


        [HttpPost]
        public JsonResult CambiarStatus(int idUsuario, bool status)
        {
            ML.ResultadosQuerys result = BL.Usuario.ChangeStatus(idUsuario, status);

            return Json(result);
        }







    }
}