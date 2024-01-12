using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PL
{
    public class Usuario
    {

        public static void Add()
        {
            ML.Usuario usuario = new ML.Usuario();

            Console.WriteLine("");

            Console.WriteLine("--- AGREGAR USUARIO ---");

            Console.WriteLine("Ingrese nombre de usuario: ");
            usuario.UserName = Console.ReadLine();

            Console.WriteLine("Ingrese su nombre: ");
            usuario.Nombre = Console.ReadLine();

            Console.WriteLine("Ingrese apellido paterno: ");
            usuario.ApellidoPaterno = Console.ReadLine();

            Console.WriteLine("Ingrese apellido materno: ");
            usuario.ApellidoMaterno = Console.ReadLine();

            Console.WriteLine("Ingrese Email: ");
            usuario.Email = Console.ReadLine();

            Console.WriteLine("Ingrese Password: ");
            usuario.Pasword = Console.ReadLine();

            Console.WriteLine("Ingrese su Sexo: ");
            usuario.Sexo = Console.ReadLine();

            Console.WriteLine("Ingrese Telefono: ");
            usuario.Telefono = Console.ReadLine();

            Console.WriteLine("Ingrese Celular: ");
            usuario.Celular = Console.ReadLine();

            Console.WriteLine("Ingrese fecha de nacimiento: ");
            usuario.FechaNacimiento = Console.ReadLine();

            Console.WriteLine("Ingrese CURP: ");
            usuario.CURP = Console.ReadLine().ToUpper();

            usuario.Rol = new ML.Rol();  

            Console.WriteLine("Ingrese rol");
            Console.WriteLine("");
            Console.WriteLine("1 - Administrador");
            Console.WriteLine("2 - Usuario");
            Console.WriteLine("");
            usuario.Rol.IdRol = int.Parse(Console.ReadLine());   


            //ML.ResultadosQuerys result = BL.Usuario.AddSP(usuario); //SP
            ML.ResultadosQuerys result = BL.Usuario.AddEF(usuario); //EF
            //ML.ResultadosQuerys result = BL.Usuario.AddLINQ(usuario); //LINQ


            if (result.Correct)
            {
                Console.WriteLine("Usuario agregado correctamente");
            }
            else
            {
                Console.WriteLine("Ocurrió un error: " + result.Message);
            }

            

        }





        public static void Update()
        {
            ML.Usuario usuario = new ML.Usuario();

            Console.WriteLine("");

            Console.WriteLine("--- ACTUALIZAR USUARIO ---");

            Console.WriteLine("Ingrese Id de usuario a actualizar: ");
            usuario.IdUsuario = int.Parse(Console.ReadLine());

            Console.WriteLine("Ingrese nombre de usuario: ");
            usuario.UserName = Console.ReadLine();

            Console.WriteLine("Ingrese su nombre: ");
            usuario.Nombre = Console.ReadLine();

            Console.WriteLine("Ingrese apellido paterno: ");
            usuario.ApellidoPaterno = Console.ReadLine();

            Console.WriteLine("Ingrese apellido materno: ");
            usuario.ApellidoMaterno = Console.ReadLine();

            Console.WriteLine("Ingrese Email: ");
            usuario.Email = Console.ReadLine();

            Console.WriteLine("Ingrese Password: ");
            usuario.Pasword = Console.ReadLine();

            Console.WriteLine("Ingrese su Sexo: ");
            usuario.Sexo = Console.ReadLine();

            Console.WriteLine("Ingrese Telefono: ");
            usuario.Telefono = Console.ReadLine();

            Console.WriteLine("Ingrese Celular: ");
            usuario.Celular = Console.ReadLine();

            Console.WriteLine("Ingrese fecha de nacimiento: ");
            usuario.FechaNacimiento = Console.ReadLine();

            Console.WriteLine("Ingrese CURP: ");
            usuario.CURP = Console.ReadLine().ToUpper();

            usuario.Rol = new ML.Rol();

            Console.WriteLine("Ingrese rol");
            Console.WriteLine("");
            Console.WriteLine("1 - Administrador");
            Console.WriteLine("2 - Usuario");
            Console.WriteLine("");
            usuario.Rol.IdRol = int.Parse(Console.ReadLine());


            //ML.ResultadosQuerys result = BL.Usuario.UpdateSP(usuario);
            ML.ResultadosQuerys result = BL.Usuario.UpdateEF(usuario);
            //ML.ResultadosQuerys result = BL.Usuario.UpdateLINQ(usuario);


            if (result.Correct)
            {
                Console.WriteLine("Usuario actualizado correctamente");
            }
            else
            {
                Console.WriteLine("Ocurrió un error: " + result.Message);
            }



        }


        public static void Delete()
        {
            ML.Usuario usuario = new ML.Usuario();

            Console.WriteLine("");

            Console.WriteLine("--- ELIMINAR USUARIO ---");

            Console.WriteLine("Ingrese Id de usuario a eliminar: ");
            usuario.IdUsuario = int.Parse(Console.ReadLine());


            //ML.ResultadosQuerys result = BL.Usuario.DeleteSP(usuario);
            ML.ResultadosQuerys result = BL.Usuario.DeleteEF(1);
            //ML.ResultadosQuerys result = BL.Usuario.DeleteLINQ(usuario);


            if (result.Correct)
            {
                Console.WriteLine("Usuario eliminado correctamente");
            }
            else
            {
                Console.WriteLine("Ocurrió un error: " + result.Message);
            }



        }





        public static void GetAll()
        {
            

            Console.WriteLine("");

            Console.WriteLine("--- INFORMACION DE USUARIOS ---");

            ML.Usuario usuario = new ML.Usuario();
            //ML.ResultadosQuerys result = BL.Usuario.GetAllSP();
            ML.ResultadosQuerys result = BL.Usuario.GetAllEF(usuario);
            //ML.ResultadosQuerys result = BL.Usuario.GetAllLINQ();

            if (result.Correct)
            {

                foreach (ML.Usuario usuarioRow in result.Objects)
                {
                    Console.WriteLine("");
                    Console.WriteLine("El id de usuario es : " + usuarioRow.IdUsuario);
                    Console.WriteLine("El UserName es : " + usuarioRow.UserName);
                    Console.WriteLine("El Nombre es : " + usuarioRow.Nombre);
                    Console.WriteLine("El Apellido paterno es : " + usuarioRow.ApellidoPaterno);
                    Console.WriteLine("El Apellido materno es : " + usuarioRow.ApellidoMaterno);
                    Console.WriteLine("El Email es : " + usuarioRow.Email);
                    Console.WriteLine("El Password es : " + usuarioRow.Pasword);
                    Console.WriteLine("El Sexo es : " + usuarioRow.Sexo);
                    Console.WriteLine("El Telefono es : " + usuarioRow.Telefono);
                    Console.WriteLine("El Celular es : " + usuarioRow.Celular);
                    Console.WriteLine("El CURP es : " + usuarioRow.CURP);
                    Console.WriteLine("La Fecha de nacimiento es : " + usuarioRow.FechaNacimiento);
                    Console.WriteLine("El Id Rol es : " + usuarioRow.Rol.IdRol);
                    Console.WriteLine("El nombre del Rol es : " + usuarioRow.Rol.RolName);
                    Console.WriteLine("");
                }



            }
            else
            {
                Console.WriteLine("Ocurrió un error: " + result.Message);
            }
        }





        public static void GetById()
        {

            ML.Usuario usuario = new ML.Usuario();  

            Console.WriteLine("");
            Console.WriteLine("Ingrese Id de usuario a buscar: ");
            usuario.IdUsuario = int.Parse(Console.ReadLine());

            //ML.ResultadosQuerys result = BL.Usuario.GetByIdSP(usuario);
            ML.ResultadosQuerys result = BL.Usuario.GetByIdEF(1);
            //ML.ResultadosQuerys result = BL.Usuario.GetByIdLINQ(usuario);

            Console.WriteLine("--- INFORMACION DE USUARIO ---");



            if (result.Correct)
            {

                ML.Usuario usuarioRow = (ML.Usuario)result.Object;

             
                    Console.WriteLine("");
                    Console.WriteLine("El id de usuario es : " + usuarioRow.IdUsuario);
                    Console.WriteLine("El UserName es : " + usuarioRow.UserName);
                    Console.WriteLine("El Nombre es : " + usuarioRow.Nombre);
                    Console.WriteLine("El Apellido paterno es : " + usuarioRow.ApellidoPaterno);
                    Console.WriteLine("El Apellido materno es : " + usuarioRow.ApellidoMaterno);
                    Console.WriteLine("El Email es : " + usuarioRow.Email);
                    Console.WriteLine("El Password es : " + usuarioRow.Pasword);
                    Console.WriteLine("El Sexo es : " + usuarioRow.Sexo);
                    Console.WriteLine("El Telefono es : " + usuarioRow.Telefono);
                    Console.WriteLine("El Celular es : " + usuarioRow.Celular);
                    Console.WriteLine("El CURP es : " + usuarioRow.CURP);
                    Console.WriteLine("La Fecha de nacimiento es : " + usuarioRow.FechaNacimiento);
                    Console.WriteLine("El Id Rol es : " + usuarioRow.Rol.IdRol);
                    Console.WriteLine("");
                



            }
            else
            {
                Console.WriteLine("Ocurrió un error: " + result.Message);
            }
        }



        //public static void Update() {

        //    ML.Usuario usuario = new ML.Usuario   

        //    Console.WriteLine("");

        //    Console.WriteLine("--- ACTUALIZAR USUARIO ---");

        //    Console.WriteLine("Ingrese Id de usuario: ");
        //    usuario.IdUsuario = byte.Parse(Console.ReadLine());

        //    Console.WriteLine("Ingrese Nombre: ");
        //    usuario.Nombre = Console.ReadLine();

        //    Console.WriteLine("Ingrese Telefono: ");
        //    usuario.Telefono = Console.ReadLine();

        //    Console.WriteLine("Ingrese Edad: ");
        //    usuario.Edad = byte.Parse(Console.ReadLine());

        //    Console.WriteLine("Ingrese Correo: ");
        //    usuario.Correo = Console.ReadLine();

        //    Console.WriteLine("Ingrese Direccion: ");
        //    usuario.Direccion = Console.ReadLine();

        //    Console.WriteLine("Ingrese Contraseña: ");
        //    usuario.Passwrd = Console.ReadLine();

        //    //ML.ResultadosQuerys result = BL.Usuario.Update(usuario);
        //    ML.ResultadosQuerys result = BL.Usuario.UpdateSP(usuario);

        //    if (result.Correct)
        //    {
        //        Console.WriteLine("Usuario actualizado correctamente");
        //    }
        //    else
        //    {
        //        Console.WriteLine("Ocurrió un error: " + result.ErrorMessage);
        //    }



        //}



        //public static void Delete() {
        //    ML.Usuario usuario = new ML.Usuario();

        //    Console.WriteLine("");

        //    Console.WriteLine("--- ELIMINAR USUARIO ---");

        //    Console.WriteLine("Ingrese Id de usuario a eliminar: ");
        //    usuario.IdUsuario = byte.Parse(Console.ReadLine());

        //    //ML.ResultadosQuerys result = BL.Usuario.Delete(usuario);
        //    ML.ResultadosQuerys result = BL.Usuario.DeleteSP(usuario);


        //    if (result.Correct)
        //    {
        //        Console.WriteLine("Usuario Eliminado correctamente");
        //    }
        //    else
        //    {
        //        Console.WriteLine("Ocurrió un error: " + result.ErrorMessage);
        //    }

        //}


        //public static void GetById()
        //{
        //    ML.Usuario usuario = new ML.Usuario();

        //    Console.WriteLine("");

        //    Console.WriteLine("--- INFORMACION DE USUARIO POR ID  ---");

        //    Console.WriteLine("Ingrese Id de usuario para obtener su informacion: ");
        //    usuario.IdUsuario = byte.Parse(Console.ReadLine());

        //    ML.ResultadosQuerys result = BL.Usuario.GetById(usuario);

        //    if (result.Correct){

        //        //foreach (ML.Usuario usuarioResult in result.Objects)
        //        //{
        //        //    Console.WriteLine("El usuario es :"+ usuarioResult.Nombre);
        //        //    Console.WriteLine("El Telefono es :" + usuarioResult.Telefono);
        //        //    Console.WriteLine("El Edad es :" + usuarioResult.Edad);
        //        //    Console.WriteLine("El Correo es :" + usuarioResult.Correo);
        //        //    Console.WriteLine("El Direccion es :" + usuarioResult.Direccion);
        //        //}

        //        ML.Usuario usuarioResult = (ML.Usuario)result.Object;

        //        Console.WriteLine("El usuario es :" + usuarioResult.Nombre);
        //        Console.WriteLine("El Telefono es :" + usuarioResult.Telefono);
        //        Console.WriteLine("El Edad es :" + usuarioResult.Edad);
        //        Console.WriteLine("El Correo es :" + usuarioResult.Correo);
        //        Console.WriteLine("El Direccion es :" + usuarioResult.Direccion);

        //    }
        //}


        //public static void GetAll()
        //{
        //    ML.Usuario usuario = new ML.Usuario();

        //    Console.WriteLine("");

        //    Console.WriteLine("--- INFORMACION DE USUARIOS ---");


        //    ML.ResultadosQuerys result = BL.Usuario.GetAll();

        //    if (result.Correct)
        //    {

        //        foreach (ML.Usuario usuarioResult in result.Objects)
        //        {
        //            Console.WriteLine("");
        //            Console.WriteLine("El usuario es :" + usuarioResult.Nombre);
        //            Console.WriteLine("El Telefono es :" + usuarioResult.Telefono);
        //            Console.WriteLine("El Edad es :" + usuarioResult.Edad);
        //            Console.WriteLine("El Correo es :" + usuarioResult.Correo);
        //            Console.WriteLine("El Direccion es :" + usuarioResult.Direccion);
        //            Console.WriteLine("");
        //        }


        //    }
        //}




    }
}
