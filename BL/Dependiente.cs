using System;
using System.Collections.Generic;

using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL
{
    public class Dependiente
    {



        public static ML.ResultadosQuerys GetByNumeroEmpleado(string numeroEmpleado)
        {

            ML.ResultadosQuerys result = new ML.ResultadosQuerys();

            try
            {

                using (DL_EF.EJRamirezProgramacionNCapasEntities context = new DL_EF.EJRamirezProgramacionNCapasEntities())
                {

                    var query = context.DependientesGetByNumeroEmpleado(numeroEmpleado).ToList();


                    if (query != null)
                    {



                        result.Objects = new List<object>();


                        foreach (var row in query)
                        {
                            ML.Dependiente dependiente = new ML.Dependiente();

                            dependiente.IdDependiente = Convert.ToInt32(row.IdDependiente);
                            dependiente.Nombre = row.DependienteNombre;
                            dependiente.ApellidoPaterno = row.ApellidoPaterno;
                            dependiente.ApellidoMaterno = row.ApellidoMaterno;
                            dependiente.FechaNacimiento = row.FechaNacimiento.Value.ToString("dd/MM/yyyy");
                            dependiente.EstadoCivil = row.EstadoCivil;
                            dependiente.Genero = row.Genero;
                            dependiente.Telefono = row.Telefono;
                            dependiente.RFC = row.RFC;
                            dependiente.NumeroEmpleado = row.NumeroEmpleado;

                            dependiente.DependienteTipo = new ML.DependienteTipo();
                            dependiente.DependienteTipo.IdDependienteTipo = Convert.ToInt32(row.IdDependiente);
                            dependiente.DependienteTipo.Nombre = row.NombreDependienteTipo;

                            result.Objects.Add(dependiente);
                        }



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
