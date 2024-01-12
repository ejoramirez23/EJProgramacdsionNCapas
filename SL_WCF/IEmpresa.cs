using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace SL_WCF
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IEmpresa" in both code and config file together.
    [ServiceContract]
    public interface IEmpresa
    {

        [OperationContract]
        ML.ResultadosQuerys Add(ML.Empresa empresa);

        [OperationContract]
        ML.ResultadosQuerys Update(ML.Empresa empresa);

        [OperationContract]
        ML.ResultadosQuerys Delete(int? idEmpresa);

        [OperationContract]
        [ServiceKnownType(typeof(ML.Empresa))]
        ML.ResultadosQuerys GetAll();

        [OperationContract]
        [ServiceKnownType(typeof(ML.Empresa))]
        ML.ResultadosQuerys GetById(int? idEmpresa);


        [OperationContract]
        void DoWork();
    }
}
