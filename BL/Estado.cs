using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL
{
    public class Estado
    {


        public static ML.ResultadosQuerys EstadoGetById(int? idPais)
        {
            ML.ResultadosQuerys result = new ML.ResultadosQuerys();

            try
            {

                using (DL_EF.EJRamirezProgramacionNCapasEntities context = new DL_EF.EJRamirezProgramacionNCapasEntities())
                {

                    var query = context.GetByIdEstado(idPais).ToList();



                    if (query != null)
                    {

                        result.Objects = new List<Object>();


                        foreach (var row in query)
                        {
                            ML.Estado estado = new ML.Estado();

                            estado.IdEstado = row.IdEstado;
                            estado.Nombre = row.Nombre;

                            result.Objects.Add(estado);

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
