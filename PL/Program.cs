using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PL
{
    internal class Program
    {
        static void Main(string[] args)
        {



            int opcion = 0;
            do
            {

                Console.WriteLine("------ MENU ASEGURADORA ----");

                Console.WriteLine("1 - MENU USUARIOS");
                Console.WriteLine("2 - MENU EMPRESA");

                Console.WriteLine("");
                Console.WriteLine("0 - Salir");
                opcion = int.Parse(Console.ReadLine());



                switch (opcion)
                {
                   case 1:
                        int opcionU = 0;

                        do
                        {
                            Console.WriteLine("----- MENU USUARIOS ----");
                            Console.WriteLine("1- Agregar usuario");
                            Console.WriteLine("2- Actualizar usuario");
                            Console.WriteLine("3- Eliminar usuario");
                            Console.WriteLine("4 Buscar todos los usuarios");
                            Console.WriteLine("5 Buscar por id de usuario");
                            Console.WriteLine("6 Salir del menu usuarios");

                            Console.WriteLine("");
                            Console.WriteLine("Ingrese una opcion: ");
                            opcionU = int.Parse(Console.ReadLine());


                            if (opcionU == 1)
                            {
                                PL.Usuario.Add();
                            }
                            else if (opcionU == 2)
                            {
                                PL.Usuario.Update();
                            }
                            else if (opcionU == 3)
                            {
                                PL.Usuario.Delete();
                            }
                            else if (opcionU == 4)
                            {
                                PL.Usuario.GetAll();
                            }
                            else if (opcionU == 5)
                            {
                                PL.Usuario.GetById();
                            }
                            else if (opcionU == 6)
                            {
                                Console.WriteLine("PRESIONE CUALQUIER TECLA PARA SALIR");
                            }
                            else
                            {
                                Console.WriteLine("Ingrese solo una opcion del menu: ");
                            }

                            Console.WriteLine("");
                            Console.ReadKey();

                        } while (opcionU != 6);


                    break;



                    case 2:

                        int opcionE = 0;
                        do
                        {
                            Console.WriteLine("----- MENU EMPRESA ----");
                            Console.WriteLine("1- Agregar empresa");
                            Console.WriteLine("2- Actualizar empresa");
                            Console.WriteLine("3- Eliminar empresa");
                            Console.WriteLine("4 Buscar todos las empresas");
                            Console.WriteLine("5 Buscar por id de empresa");
                            Console.WriteLine("6 Salir menu empresa");

                            Console.WriteLine("");
                            Console.WriteLine("Ingrese una opcion: ");
                            opcionE = int.Parse(Console.ReadLine());


                            if (opcionE == 1)
                            {
                                PL.Empresa.EmpresaAdd();
                            }
                            else if (opcionE == 2)
                            {
                                PL.Empresa.EmpresaUpdate();
                            }
                            else if (opcionE == 3)
                            {
                                PL.Empresa.EmpresaDelete();
                            }
                            else if (opcionE == 4)
                            {
                                PL.Empresa.EmpresaGetAll();
                            }
                            else if (opcionE == 5)
                            {
                                PL.Empresa.EmpresaGetById();
                            }
                            else if (opcionE == 6)
                            {
                                Console.WriteLine("PRESIONE CUALQUIER TECLA PARA SALIR");
                            }
                            else
                            {
                                Console.WriteLine("Ingrese solo una opcion del menu: ");
                            }

                            Console.WriteLine("");
                            Console.ReadKey();

                        } while (opcionE != 6);


                        break;
                }

            } while (opcion != 0);







        } 
    }
}
