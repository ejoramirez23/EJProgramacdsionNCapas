using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PL
{
    public class Empresa
    {


        public static void EmpresaAdd()
        {

            ML.Empresa empresa = new ML.Empresa();


            Console.WriteLine("Ingrese nombre de la empresa");
            empresa.Nombre = Console.ReadLine();

            Console.WriteLine("Ingrese telefono de la empresa");
            empresa.Telefono = Console.ReadLine();


            Console.WriteLine("Ingrese email de la empresa");
            empresa.Email = Console.ReadLine();

            Console.WriteLine("Ingrese direccion web");
            empresa.DireccionWeb = Console.ReadLine();


            ML.ResultadosQuerys result = BL.Empresa.EmpresaAddEF(empresa);  
            //ML.ResultadosQuerys result = BL.Empresa.EmpresaAddLINQ(empresa);

            if (result.Correct)
            {
                Console.WriteLine(result.Message);
            }
            else
            {
                Console.WriteLine(result.Message);
            }


        }



        public static void EmpresaUpdate()
        {

            ML.Empresa empresa = new ML.Empresa();

            Console.WriteLine("Ingrese Id de la empresa a actualizar");
            empresa.IdEmpresa = int.Parse(Console.ReadLine());

            Console.WriteLine("Ingrese nombre de la empresa");
            empresa.Nombre = Console.ReadLine();

            Console.WriteLine("Ingrese telefono de la empresa");
            empresa.Telefono = Console.ReadLine();


            Console.WriteLine("Ingrese email de la empresa");
            empresa.Email = Console.ReadLine();

            Console.WriteLine("Ingrese direccion web");
            empresa.DireccionWeb = Console.ReadLine();


            //ML.ResultadosQuerys result = BL.Empresa.EmpresaUpdateEF(empresa);
            ML.ResultadosQuerys result = BL.Empresa.EmpresaUpdateLINQ(empresa);


            if (result.Correct)
            {
                Console.WriteLine(result.Message);
            }
            else
            {
                Console.WriteLine(result.Message);
            }


        }




        public static void EmpresaDelete()
        {

            ML.Empresa empresa = new ML.Empresa();

            Console.WriteLine("Ingrese Id de la empresa a eliminar");
            empresa.IdEmpresa = int.Parse(Console.ReadLine());


            //ML.ResultadosQuerys result = BL.Empresa.EmpresaDeleteEF(empresa);
            ML.ResultadosQuerys result = BL.Empresa.EmpresaDeleteLINQ(empresa);

            if (result.Correct)
            {
                Console.WriteLine(result.Message);
            }
            else
            {
                Console.WriteLine(result.Message);
            }


        }





        public static void EmpresaGetAll()
        {

            ML.Empresa empresa = new ML.Empresa();

            //ML.ResultadosQuerys result = BL.Empresa.EmpresaGetAllEF();
            ML.ResultadosQuerys result = BL.Empresa.EmpresaGetAllLINQ();


            if (result.Correct)
            {

                foreach (ML.Empresa empresaGet in result.Objects)
                {
                    Console.WriteLine("");
                    Console.WriteLine("El Id de empresa es: "+ empresaGet.IdEmpresa);
                    Console.WriteLine("El Nombre de empresa es: " + empresaGet.Nombre);
                    Console.WriteLine("El Telefono de empresa es: " + empresaGet.Telefono);
                    Console.WriteLine("El Email de empresa es: " + empresaGet.Email);
                    Console.WriteLine("La Direccion Web de la empresa es: " + empresaGet.DireccionWeb);
                    Console.WriteLine("");
                }

            }
            else
            {
                Console.WriteLine(result.Message);
            }


        }



        public static void EmpresaGetById()
        {

            ML.Empresa empresa = new ML.Empresa();


            Console.WriteLine("Ingrese Id de la empresa a buscar");
            empresa.IdEmpresa = int.Parse(Console.ReadLine());



            //ML.ResultadosQuerys result = BL.Empresa.EmpresaGetByIdEF(empresa);
            ML.ResultadosQuerys result = BL.Empresa.EmpresaGetByIdLINQ(empresa);

            if (result.Correct)
            {

                ML.Empresa empresaGet = (ML.Empresa)result.Object;

             
                    Console.WriteLine("");
                    Console.WriteLine("El Id de empresa es: " + empresaGet.IdEmpresa);
                    Console.WriteLine("El Nombre de empresa es: " + empresaGet.Nombre);
                    Console.WriteLine("El Telefono de empresa es: " + empresaGet.Telefono);
                    Console.WriteLine("El Email de empresa es: " + empresaGet.Email);
                    Console.WriteLine("La Direccion Web de la empresa es: " + empresaGet.DireccionWeb);
                    Console.WriteLine("");
            

            }
            else
            {
                Console.WriteLine(result.Message);
            }


        }






    }
}
