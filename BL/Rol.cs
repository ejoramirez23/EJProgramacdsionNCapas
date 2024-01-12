using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL
{
    public class Rol
    {

        public static ML.ResultadosQuerys GetAllEF()
        {
            ML.ResultadosQuerys result = new ML.ResultadosQuerys();

            try
            {

                using (DL_EF.EJRamirezProgramacionNCapasEntities context = new DL_EF.EJRamirezProgramacionNCapasEntities())
                {

                    var query = context.RolGetAll().ToList();



                    if (query != null)
                    {

                        result.Objects = new List<Object>();


                        foreach (var row in query)
                        {
                            ML.Rol rol = new ML.Rol();

                            rol.IdRol = row.IdRol;
                            rol.RolName = row.RolName;

                            result.Objects.Add(rol);

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
