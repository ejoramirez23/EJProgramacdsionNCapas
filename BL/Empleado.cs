using System;
using System.Collections.Generic;

using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL
{
    public class Empleado
    {



        public static ML.ResultadosQuerys AddEF(ML.Empleado empleado)
        {

            ML.ResultadosQuerys result = new ML.ResultadosQuerys();

            try
            {

                using (DL_EF.EJRamirezProgramacionNCapasEntities context = new DL_EF.EJRamirezProgramacionNCapasEntities())
                {

                    var query = context.EmpleadoAddSP(empleado.NumeroEmpleado, empleado.RFC, empleado.Nombre, empleado.ApellidoPaterno, empleado.ApellidoMaterno, empleado.Email, empleado.Telefono, empleado.FechaNacimiento, empleado.NSS, empleado.FechaIngreso, empleado.Foto, empleado.Empresa.IdEmpresa);

                    if (query > 0)
                    {



                        result.Correct = true;
                        result.Message = "Empleado agregado exitosamente";
                    }
                    else
                    {
                        result.Correct = false;
                        result.Message = "Ocurrio un error: El Empleado no se pudo agregar";
                    }



                }
            }
            catch (Exception ex)
            {
                result.Correct = false;
                result.Ex = ex;
                result.Message = ex.Message;
            }

            return result;


        }





        public static ML.ResultadosQuerys UpdateEF(ML.Empleado empleado)
        {

            ML.ResultadosQuerys result = new ML.ResultadosQuerys();

            try
            {

                using (DL_EF.EJRamirezProgramacionNCapasEntities context = new DL_EF.EJRamirezProgramacionNCapasEntities())
                {


                    var query = context.EmpleadoUpdateSP(empleado.NumeroEmpleado, empleado.RFC, empleado.Nombre, empleado.ApellidoPaterno, empleado.ApellidoMaterno, empleado.Email, empleado.Telefono, empleado.FechaNacimiento, empleado.NSS, empleado.FechaIngreso, empleado.Foto, empleado.Empresa.IdEmpresa);

                    if (query > 0)
                    {
                        result.Correct = true;
                        result.Message = "Empleado actualizado exitosamente";
                    }
                    else
                    {
                        result.Correct = true;
                        result.Message = "Ocurrio un error: El Empleado no se pudo actualizar";
                    }



                }
            }
            catch (Exception ex)
            {
                result.Correct = false;
                result.Ex = ex;
                result.Message = ex.Message;
            }

            return result;


        }




        public static ML.ResultadosQuerys DeleteEF(string idEmpleado)
        {

            ML.ResultadosQuerys result = new ML.ResultadosQuerys();

            try
            {

                using (DL_EF.EJRamirezProgramacionNCapasEntities context = new DL_EF.EJRamirezProgramacionNCapasEntities())
                {


                    var query = context.EmpleadoDeleteSP(idEmpleado);

                    if (query > 0)
                    {
                        result.Correct = true;
                        result.Message = "Empleado eliminado exitosamente";
                    }
                    else
                    {
                        result.Correct = true;
                        result.Message = "Ocurrio un error: El Empleado no se pudo eliminar";
                    }



                }
            }
            catch (Exception ex)
            {
                result.Correct = false;
                result.Ex = ex;
                result.Message = ex.Message;
            }

            return result;


        }







        public static ML.ResultadosQuerys GetAllEF(ML.Empleado empleado)
        {

            ML.ResultadosQuerys result = new ML.ResultadosQuerys();

            try
            {

                using (DL_EF.EJRamirezProgramacionNCapasEntities context = new DL_EF.EJRamirezProgramacionNCapasEntities())
                {

                    var query = context.EmpleadoGetAll(empleado.Nombre, empleado.ApellidoPaterno, empleado.ApellidoMaterno, empleado.Empresa.IdEmpresa).ToList();


                    if (query != null)
                    {

                        result.Objects = new List<Object>();


                        foreach (var row in query)
                        {
                            empleado = new ML.Empleado();

                            empleado.NumeroEmpleado = row.NumeroEmpleado;
                            empleado.RFC = row.RFC;
                            empleado.Nombre = row.NombreEmpleado;
                            empleado.ApellidoPaterno = row.ApellidoPaterno;
                            empleado.ApellidoMaterno = row.ApellidoMaterno;
                            empleado.Email = row.EmailEmpleado;
                            empleado.Telefono = row.TelefonoEmpleado;
                            empleado.FechaNacimiento = row.FechaNacimiento.Value.ToString("dd/MM/yyyy");
                            empleado.NSS = row.NSS;
                            empleado.FechaIngreso = row.FechaIngreso.Value.ToString("dd/MM/yyyy");
                            empleado.Foto = row.Foto;


                            empleado.Empresa = new ML.Empresa();
                            empleado.Empresa.IdEmpresa = row.IdEmpresa;
                            empleado.Empresa.Nombre = row.NombreEmpresa;
                        
                          


                            result.Objects.Add(empleado);

                        }



                        result.Correct = true;
                    }



                }
            }
            catch (Exception ex)
            {
                result.Correct = false;
                result.Ex = ex;
                result.Message = ex.Message;
            }

            return result;


        }





        public static ML.ResultadosQuerys GetByIdEF(string idEmpleado)
        {

            ML.ResultadosQuerys result = new ML.ResultadosQuerys();

            try
            {

                using (DL_EF.EJRamirezProgramacionNCapasEntities context = new DL_EF.EJRamirezProgramacionNCapasEntities())
                {

                    var query = context.EmpleadoGetById(idEmpleado);


                    if (query != null)
                    {

                        var row = query.FirstOrDefault();

                        result.Object = new object();
                        ML.Empleado empleado = new ML.Empleado();

                        empleado.NumeroEmpleado = row.NumeroEmpleado;
                        empleado.RFC = row.RFC;
                        empleado.Nombre = row.NombreEmpleado;
                        empleado.ApellidoPaterno = row.ApellidoPaterno;
                        empleado.ApellidoMaterno = row.ApellidoMaterno;
                        empleado.Email = row.EmailEmpleado;
                        empleado.Telefono = row.TelefonoEmpleado;
                        empleado.FechaNacimiento = row.FechaNacimiento.Value.ToString("dd/MM/yyyy");
                        empleado.NSS = row.NSS;
                        empleado.FechaIngreso = row.FechaIngreso.Value.ToString("dd/MM/yyyy");
                        empleado.Foto = row.Foto;


                        empleado.Empresa = new ML.Empresa();
                        empleado.Empresa.IdEmpresa = row.IdEmpresa;
                        empleado.Empresa.Nombre = row.NombreEmpresa;



                        result.Object = empleado;


                        result.Correct = true;
                    }
                    else
                    {
                        result.Correct = false;
                        result.Message = "No se encontraron resultados";
                    }



                }
            }
            catch (Exception ex)
            {
                result.Correct = false;
                result.Ex = ex;
                result.Message = ex.Message;
            }

            return result;


        }











    }
}
