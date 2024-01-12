using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL
{
    public class Pais
    {

        public static ML.ResultadosQuerys GetAllPais()
        {
            ML.ResultadosQuerys result = new ML.ResultadosQuerys();

            try
            {

                using (DL_EF.EJRamirezProgramacionNCapasEntities context = new DL_EF.EJRamirezProgramacionNCapasEntities())
                {

                    var query = context.PaisGetAll().ToList();



                    if (query != null)
                    {

                        result.Objects = new List<Object>();


                        foreach (var row in query)
                        {
                            ML.Pais pais = new ML.Pais();

                            pais.IdPais = row.IdPais;
                            pais.Nombre = row.Nombre;

                            result.Objects.Add(pais);

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
