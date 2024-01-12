using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;



namespace DL
{
    public class Conexion
    {
        public static string GetConnectionString() {
           
            string connectionString = System.Configuration.ConfigurationManager.ConnectionStrings["EJRamirezProgramacionNCapas"].ToString();

            return connectionString;    

        }   
    }
}
