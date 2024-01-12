using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace SL_WCF
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Empresa" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select Empresa.svc or Empresa.svc.cs at the Solution Explorer and start debugging.
    public class Empresa : IEmpresa
    {

        public ML.ResultadosQuerys Add(ML.Empresa empresa)
        {
            ML.ResultadosQuerys result = BL.Empresa.EmpresaAddEF(empresa);

            return result;
        }

        public ML.ResultadosQuerys Update(ML.Empresa empresa)
        {
            ML.ResultadosQuerys result = BL.Empresa.EmpresaUpdateEF(empresa);

            return result;
        }


        public ML.ResultadosQuerys Delete(int? idEmpresa)
        {
            ML.ResultadosQuerys result = BL.Empresa.EmpresaDeleteEF(idEmpresa);

            return result;
        }

        public ML.ResultadosQuerys GetAll()
        {
            ML.ResultadosQuerys result = BL.Empresa.EmpresaGetAllEF();

            return result;
        }


        public ML.ResultadosQuerys GetById(int? idEmpresa)
        {
            ML.ResultadosQuerys result = BL.Empresa.EmpresaGetByIdEF(idEmpresa);

            return result;
        }



        public void DoWork()
        {
        }
    }
}
