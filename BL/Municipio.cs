using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL
{
    public class Municipio
    {
        public static ML.ResultadosQuerys MunicipioGetById(int? idEstado)
        {
            ML.ResultadosQuerys result = new ML.ResultadosQuerys();

            try
            {

                using (DL_EF.EJRamirezProgramacionNCapasEntities context = new DL_EF.EJRamirezProgramacionNCapasEntities())
                {

                    var query = context.GetByIdMunicipio(idEstado).ToList();



                    if (query != null)
                    {

                        result.Objects = new List<Object>();


                        foreach (var row in query)
                        {
                            ML.Municipio municipio = new ML.Municipio();

                            municipio.IdMunicipio = row.IdMunicipio;
                            municipio.Nombre = row.Nombre;

                            result.Objects.Add(municipio);

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


    }
}
