using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL
{
    public class Colonia
    {
        public static ML.ResultadosQuerys ColoniaGetById(int? idMunicipio)
        {
            ML.ResultadosQuerys result = new ML.ResultadosQuerys();

            try
            {

                using (DL_EF.EJRamirezProgramacionNCapasEntities context = new DL_EF.EJRamirezProgramacionNCapasEntities())
                {

                    var query = context.GetByIdColonia(idMunicipio).ToList();



                    if (query != null)
                    {

                        result.Objects = new List<Object>();


                        foreach (var row in query)
                        {
                            ML.Colonia colonia = new ML.Colonia();

                            colonia.IdColonia = row.IdColonia;
                            colonia.Nombre = row.Nombre;

                            result.Objects.Add(colonia);

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
