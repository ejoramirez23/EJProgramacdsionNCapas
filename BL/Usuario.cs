using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


using System.Data;
using System.Data.SqlClient;


namespace BL
{
    public class Usuario
    {
        public static ML.ResultadosQuerys AddSP(ML.Usuario usuario)
        {

            ML.ResultadosQuerys result = new ML.ResultadosQuerys();

            try
            {
               
                using (SqlConnection conn = new SqlConnection(DL.Conexion.GetConnectionString()))
                {


                    string query = "UsuarioAddSP";

                    conn.Open();

                    using (SqlCommand command = new SqlCommand(query, conn))
                    {
                        command.Parameters.AddWithValue("@UserName", usuario.UserName);
                        command.Parameters.AddWithValue("@Nombre", usuario.Nombre);
                        command.Parameters.AddWithValue("@ApellidoPaterno", usuario.ApellidoPaterno);
                        command.Parameters.AddWithValue("@ApellidoMaterno", usuario.ApellidoMaterno);
                        command.Parameters.AddWithValue("@Email", usuario.Email);
                        command.Parameters.AddWithValue("@Pasword", usuario.Pasword);
                        command.Parameters.AddWithValue("@Sexo", usuario.Sexo);
                        command.Parameters.AddWithValue("@Telefono", usuario.Telefono);
                        command.Parameters.AddWithValue("@Celular", usuario.Celular);
                        command.Parameters.AddWithValue("@FechaNacimiento", usuario.FechaNacimiento);
                        command.Parameters.AddWithValue("@CURP", usuario.CURP);


                        command.Parameters.AddWithValue("@IdRol", usuario.Rol.IdRol);

                        command.CommandType = CommandType.StoredProcedure; 

                        int RowsAffected = command.ExecuteNonQuery();

                        if (RowsAffected > 0)
                        {
                            result.Correct = true;
                        }
                        else
                        {
                            result.Correct = false;
                            result.Message = "El usuario no pudo ser agregado";
                        }



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






        public static ML.ResultadosQuerys UpdateSP(ML.Usuario usuario)
        {

            ML.ResultadosQuerys result = new ML.ResultadosQuerys();

            try
            {

                using (SqlConnection conn = new SqlConnection(DL.Conexion.GetConnectionString()))
                {


                    string query = "UsuarioUpdateSP";

                    conn.Open();

                    using (SqlCommand command = new SqlCommand(query, conn))
                    {
                        command.Parameters.AddWithValue("@IdUsuario", usuario.IdUsuario);
                        command.Parameters.AddWithValue("@UserName", usuario.UserName);
                        command.Parameters.AddWithValue("@Nombre", usuario.Nombre);
                        command.Parameters.AddWithValue("@ApellidoPaterno", usuario.ApellidoPaterno);
                        command.Parameters.AddWithValue("@ApellidoMaterno", usuario.ApellidoMaterno);
                        command.Parameters.AddWithValue("@Email", usuario.Email);
                        command.Parameters.AddWithValue("@Pasword", usuario.Pasword);
                        command.Parameters.AddWithValue("@Sexo", usuario.Sexo);
                        command.Parameters.AddWithValue("@Telefono", usuario.Telefono);
                        command.Parameters.AddWithValue("@Celular", usuario.Celular);
                        command.Parameters.AddWithValue("@FechaNacimiento", usuario.FechaNacimiento);
                        command.Parameters.AddWithValue("@CURP", usuario.CURP);


                        command.Parameters.AddWithValue("@IdRol", usuario.Rol.IdRol);

                        command.CommandType = CommandType.StoredProcedure;

                        int RowsAffected = command.ExecuteNonQuery();

                        if (RowsAffected > 0)
                        {
                            result.Correct = true;
                        }
                        else
                        {
                            result.Correct = false;
                            result.Message = "El usuario no pudo ser actualizado";
                        }



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





        public static ML.ResultadosQuerys DeleteSP(ML.Usuario usuario)
        {

            ML.ResultadosQuerys result = new ML.ResultadosQuerys();

            try
            {

                using (SqlConnection conn = new SqlConnection(DL.Conexion.GetConnectionString()))
                {


                    string query = "UsuarioDeleteSP";

                    conn.Open();

                    using (SqlCommand command = new SqlCommand(query, conn))
                    {
                        command.Parameters.AddWithValue("@IdUsuario", usuario.IdUsuario);
                       
                        command.CommandType = CommandType.StoredProcedure;

                        int RowsAffected = command.ExecuteNonQuery();

                        if (RowsAffected > 0)
                        {
                            result.Correct = true;
                        }
                        else
                        {
                            result.Correct = false;
                            result.Message = "El usuario no pudo ser eliminado";
                        }



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



        public static ML.ResultadosQuerys GetAllSP()
        {

            ML.ResultadosQuerys result = new ML.ResultadosQuerys();

            try
            {

                using (SqlConnection conn = new SqlConnection(DL.Conexion.GetConnectionString()))
                {


                    string query = "UsuarioGetAll";

                    conn.Open();

                    using (SqlCommand command = new SqlCommand(query, conn))
                    {

                        command.CommandType = CommandType.StoredProcedure;

                        DataTable usuarioTable = new DataTable();

                        SqlDataAdapter dataAdapter = new SqlDataAdapter(command);

                        dataAdapter.Fill(usuarioTable); 
                           
                        if (usuarioTable.Rows.Count > 0) {
                        

                            result.Objects = new List<Object>();

                            foreach(DataRow row in usuarioTable.Rows)
                            {
                                ML.Usuario usuarioRow = new ML.Usuario();

                                usuarioRow.IdUsuario = Convert.ToInt32(row[0]);
                                usuarioRow.UserName = Convert.ToString(row[1]); 
                                usuarioRow.Nombre = row[2].ToString();  
                                usuarioRow.ApellidoPaterno = row[3].ToString();
                                usuarioRow.ApellidoMaterno = row[4].ToString(); 
                                usuarioRow.Email = row[5].ToString();
                                usuarioRow.Pasword = row[6].ToString(); 
                                usuarioRow.Sexo = row[7].ToString();
                                usuarioRow.Telefono = row[8].ToString();    
                                usuarioRow.Celular = row[9].ToString();
                                usuarioRow.FechaNacimiento = row[10].ToString();
                                usuarioRow.CURP = row[11].ToString();

                                usuarioRow.Rol = new ML.Rol();
                                usuarioRow.Rol.IdRol = Convert.ToInt32(row[12]);


                                result.Objects.Add(usuarioRow);
                            }

                            result.Correct = true;
                             
                        
                        }
                        



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




        public static ML.ResultadosQuerys GetByIdSP(ML.Usuario usuario)
        {

            ML.ResultadosQuerys result = new ML.ResultadosQuerys();

            try
            {

                using (SqlConnection conn = new SqlConnection(DL.Conexion.GetConnectionString()))
                {


                    string query = "UsuarioGetById";

                    conn.Open();

                    using (SqlCommand command = new SqlCommand(query, conn))
                    {
                        command.Parameters.AddWithValue("@IdUsuario", usuario.IdUsuario);
                        command.CommandType = CommandType.StoredProcedure;

                        DataTable usuarioTable = new DataTable();

                        SqlDataAdapter dataAdapter = new SqlDataAdapter(command);

                        dataAdapter.Fill(usuarioTable);

                        if (usuarioTable.Rows.Count > 0)
                        {


                            result.Object = new object();

                            DataRow row = usuarioTable.Rows[0];

                            
                                ML.Usuario usuarioRow = new ML.Usuario();

                                usuarioRow.IdUsuario = Convert.ToInt32(row[0]);
                                usuarioRow.UserName = Convert.ToString(row[1]);
                                usuarioRow.Nombre = row[2].ToString();
                                usuarioRow.ApellidoPaterno = row[3].ToString();
                                usuarioRow.ApellidoMaterno = row[4].ToString();
                                usuarioRow.Email = row[5].ToString();
                                usuarioRow.Pasword = row[6].ToString();
                                usuarioRow.Sexo = row[7].ToString();
                                usuarioRow.Telefono = row[8].ToString();
                                usuarioRow.Celular = row[9].ToString();
                                usuarioRow.FechaNacimiento = row[10].ToString();
                                usuarioRow.CURP = row[11].ToString();

                                usuarioRow.Rol = new ML.Rol();
                                usuarioRow.Rol.IdRol = Convert.ToInt32(row[12]);


                            result.Object = usuarioRow;
                            

                            result.Correct = true;


                        }




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







        //public static ML.ResultadosQuerys Add(ML.Usuario usuario)
        //{

        //    ML.ResultadosQuerys result = new ML.ResultadosQuerys();

        //    try
        //    {
        //        //using (SqlConnection conn = new SqlConnection(DL.Conexion.GetConnectionString()))
        //        using (SqlConnection conn = new SqlConnection())
        //        {
        //            conn.ConnectionString = DL.Conexion.GetConnectionString();

        //            conn.Open();

        //            string query = "INSERT INTO [Usuarios] ([Nombre],[Telefono],[Edad],[Correo],[Direccion],[Passwrd]) VALUES (@Nombre, @Telefono, @Edad, @Correo, @Direccion, @Passwrd)";

        //            using (SqlCommand command = new SqlCommand(query, conn))
        //            {

        //                command.Parameters.AddWithValue("@Nombre", usuario.Nombre);
        //                command.Parameters.AddWithValue("@Telefono", usuario.Telefono);
        //                command.Parameters.AddWithValue("@Edad", usuario.Edad);
        //                command.Parameters.AddWithValue("@Correo", usuario.Correo);
        //                command.Parameters.AddWithValue("@Direccion", usuario.Direccion);
        //                command.Parameters.AddWithValue("@Passwrd", usuario.Passwrd);

        //                int RowsAffected = command.ExecuteNonQuery();

        //                if (RowsAffected > 0) {
        //                    result.Correct = true;
        //                }
        //                else
        //                {
        //                    result.Correct = false;
        //                    result.ErrorMessage = "El usuario no pudo ser agregado";
        //                }



        //            }


        //        }
        //    } catch (Exception ex) {
        //        result.Correct = false;
        //        result.Ex = ex;
        //        result.ErrorMessage = ex.Message;
        //    }

        //    return result;


        //}


        //public static ML.ResultadosQuerys Update(ML.Usuario usuario)
        //{

        //    ML.ResultadosQuerys result = new ML.ResultadosQuerys();

        //    try
        //    {

        //        using (SqlConnection conn = new SqlConnection())
        //        {
        //            conn.ConnectionString = DL.Conexion.GetConnectionString();

        //            conn.Open();

        //            string query = "UPDATE [Usuarios] SET [Nombre] = @Nombre, [Telefono] = @Telefono, [Edad] = @Edad, [Correo] = @Correo, [Direccion] = @Direccion, [Passwrd] = @Passwrd WHERE [IdUsuario] = @IdUsuario";

        //            using (SqlCommand command = new SqlCommand(query, conn))
        //            {
        //                command.Parameters.AddWithValue("@IdUsuario", usuario.IdUsuario);
        //                command.Parameters.AddWithValue("@Nombre", usuario.Nombre);
        //                command.Parameters.AddWithValue("@Telefono", usuario.Telefono);
        //                command.Parameters.AddWithValue("@Edad", usuario.Edad);
        //                command.Parameters.AddWithValue("@Correo", usuario.Correo);
        //                command.Parameters.AddWithValue("@Direccion", usuario.Direccion);
        //                command.Parameters.AddWithValue("@Passwrd", usuario.Passwrd);

        //                int RowsAffected = command.ExecuteNonQuery();

        //                if (RowsAffected > 0)
        //                {
        //                    result.Correct = true;
        //                }
        //                else
        //                {
        //                    result.Correct = false;
        //                    result.ErrorMessage = "El usuario no pudo ser actualizado";
        //                }



        //            }


        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        result.Correct = false;
        //        result.Ex = ex;
        //        result.ErrorMessage = ex.Message;
        //    }

        //    return result;

        //}

        //public static ML.ResultadosQuerys UpdateSP(ML.Usuario usuario)
        //{

        //    ML.ResultadosQuerys result = new ML.ResultadosQuerys();

        //    try
        //    {

        //        using (SqlConnection conn = new SqlConnection())
        //        {
        //            conn.ConnectionString = DL.Conexion.GetConnectionString();

        //            conn.Open();

        //            string query = "UsuariosUpdateSP";

        //            using (SqlCommand command = new SqlCommand(query, conn))
        //            {
        //                command.Parameters.AddWithValue("@IdUsuario", usuario.IdUsuario);
        //                command.Parameters.AddWithValue("@Nombre", usuario.Nombre);
        //                command.Parameters.AddWithValue("@Telefono", usuario.Telefono);
        //                command.Parameters.AddWithValue("@Edad", usuario.Edad);
        //                command.Parameters.AddWithValue("@Correo", usuario.Correo);
        //                command.Parameters.AddWithValue("@Direccion", usuario.Direccion);
        //                command.Parameters.AddWithValue("@Passwrd", usuario.Passwrd);
        //                command.CommandType = CommandType.StoredProcedure;

        //                int RowsAffected = command.ExecuteNonQuery();

        //                if (RowsAffected > 0)
        //                {
        //                    result.Correct = true;
        //                }
        //                else
        //                {
        //                    result.Correct = false;
        //                    result.ErrorMessage = "El usuario no pudo ser actualizado";
        //                }



        //            }


        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        result.Correct = false;
        //        result.Ex = ex;
        //        result.ErrorMessage = ex.Message;
        //    }

        //    return result;

        //}

        //public static ML.ResultadosQuerys Delete(ML.Usuario usuario)
        //{

        //    ML.ResultadosQuerys result = new ML.ResultadosQuerys();

        //    try
        //    {

        //        using (SqlConnection conn = new SqlConnection())
        //        {
        //            conn.ConnectionString = DL.Conexion.GetConnectionString();

        //            conn.Open();

        //            string query = "DELETE FROM [Usuarios] WHERE [IdUsuario] = @IdUsuario";

        //            using (SqlCommand command = new SqlCommand(query, conn))
        //            {
        //                command.Parameters.AddWithValue("@IdUsuario", usuario.IdUsuario);


        //                int RowsAffected = command.ExecuteNonQuery();

        //                if (RowsAffected > 0)
        //                {
        //                    result.Correct = true;
        //                }
        //                else
        //                {
        //                    result.Correct = false;
        //                    result.ErrorMessage = "El usuario no pudo ser Eliminado";
        //                }



        //            }


        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        result.Correct = false;
        //        result.Ex = ex;
        //        result.ErrorMessage = ex.Message;
        //    }

        //    return result;

        //}







        //public static ML.ResultadosQuerys DeleteSP(ML.Usuario usuario)
        //{

        //    ML.ResultadosQuerys result = new ML.ResultadosQuerys();

        //    try
        //    {

        //        using (SqlConnection conn = new SqlConnection())
        //        {
        //            conn.ConnectionString = DL.Conexion.GetConnectionString();

        //           

        //            string query = "UsuariosDeleteSP";

        //            using (SqlCommand command = new SqlCommand(query, conn))
        //            {
        //                command.Parameters.AddWithValue("@IdUsuario", usuario.IdUsuario);
        //                command.CommandType = CommandType.StoredProcedure;


        //                int RowsAffected = command.ExecuteNonQuery();

        //                if (RowsAffected > 0)
        //                {
        //                    result.Correct = true;
        //                }
        //                else
        //                {
        //                    result.Correct = false;
        //                    result.ErrorMessage = "El usuario no pudo ser Eliminado";
        //                }



        //            }


        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        result.Correct = false;
        //        result.Ex = ex;
        //        result.ErrorMessage = ex.Message;
        //    }

        //    return result;

        //}

        //public static ML.ResultadosQuerys GetById(ML.Usuario usuario)
        //{
        //    ML.ResultadosQuerys result = new ML.ResultadosQuerys();

        //    try
        //    {
        //        using (SqlConnection context = new SqlConnection(DL.Conexion.GetConnectionString()))
        //        {

        //            string query = "UsuariosGetById";

        //            using (SqlCommand cmd = new SqlCommand(query, context))
        //            {
        //                cmd.Parameters.AddWithValue("@IdUsuario", usuario.IdUsuario);
        //                cmd.CommandType = CommandType.StoredProcedure;

        //                DataTable usuariosTable = new DataTable();

        //                SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(cmd);    

        //                sqlDataAdapter.Fill(usuariosTable);

        //                if (usuariosTable.Rows.Count > 0)
        //                {

        //                    DataRow row = usuariosTable.Rows[0];

        //                        usuario.Nombre = row[0].ToString();
        //                        usuario.Telefono = row[1].ToString();
        //                        usuario.Edad = Convert.ToByte(row[2]);
        //                        usuario.Correo = row[3].ToString();
        //                        usuario.Direccion = row[4].ToString();

        //                    object usuarioObject = usuario;


        //                    result.Object = usuarioObject;

        //                    result.Correct = true;


        //                }
        //            }

        //        }

        //    }
        //    catch (Exception ex)
        //    {
        //        result.Correct = false;
        //        result.Ex = ex;
        //        result.ErrorMessage = ex.Message;
        //    }

        //    return result;
        //}



        //public static ML.ResultadosQuerys GetAll()
        //{
        //    ML.ResultadosQuerys result = new ML.ResultadosQuerys();

        //    try
        //    {
        //        using (SqlConnection context = new SqlConnection(DL.Conexion.GetConnectionString()))
        //        {

        //            string query = "UsuariosGetAll";

        //            using (SqlCommand cmd = new SqlCommand(query, context))
        //            {

        //                cmd.CommandType = CommandType.StoredProcedure;

        //                DataTable usuariosTable = new DataTable();

        //                SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(cmd);

        //                sqlDataAdapter.Fill(usuariosTable);

        //                if (usuariosTable.Rows.Count > 0)
        //                {

        //                    result.Objects = new List<object>();


        //                    foreach (DataRow row in usuariosTable.Rows)
        //                    {
        //                        ML.Usuario usuario = new ML.Usuario();

        //                        usuario.Nombre = row[0].ToString();
        //                        usuario.Telefono = row[1].ToString();
        //                        usuario.Edad = Convert.ToByte(row[2]);
        //                        usuario.Correo = row[3].ToString();
        //                        usuario.Direccion = row[4].ToString();

        //                        usuario.RolName.RolName = row[5].ToString();    


        //                        result.Objects.Add(usuario);

        //                    }




        //                    result.Correct = true;


        //                }
        //            }

        //        }

        //    }
        //    catch (Exception ex)
        //    {
        //        result.Correct = false;
        //        result.Ex = ex;
        //        result.ErrorMessage = ex.Message;
        //    }

        //    return result;
        //}





        // EF


        public static ML.ResultadosQuerys AddEF(ML.Usuario usuario)
        {

            ML.ResultadosQuerys result = new ML.ResultadosQuerys();

            try
            {

                using (DL_EF.EJRamirezProgramacionNCapasEntities context = new DL_EF.EJRamirezProgramacionNCapasEntities())
                {

                    var query = context.UsuarioAddSP(usuario.UserName, usuario.Nombre, usuario.ApellidoPaterno, usuario.ApellidoMaterno, usuario.Email, usuario.Pasword, usuario.Sexo, usuario.Telefono, usuario.Celular, usuario.FechaNacimiento, usuario.CURP, usuario.Rol.IdRol, usuario.Direccion.Colonia.IdColonia, usuario.Direccion.Calle, usuario.Direccion.NumeroExterior, usuario.Direccion.NumeroInterior, usuario.Imagen);

                    if (query > 0)
                    {
                       

                       
                        result.Correct = true;
                        result.Message = "Usuario agregado exitosamente";
                    }
                    else
                    {
                        result.Correct = false;
                        result.Message = "Ocurrio un error: El usuario no se pudo agregado";
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





        public static ML.ResultadosQuerys UpdateEF(ML.Usuario usuario)
        {

            ML.ResultadosQuerys result = new ML.ResultadosQuerys();

            try
            {

                using (DL_EF.EJRamirezProgramacionNCapasEntities context = new DL_EF.EJRamirezProgramacionNCapasEntities())
                {


                    var query = context.UsuarioUpdateSP(usuario.IdUsuario, usuario.UserName, usuario.Nombre, usuario.ApellidoPaterno, usuario.ApellidoMaterno, usuario.Email, usuario.Pasword, usuario.Sexo, usuario.Telefono, usuario.Celular, usuario.FechaNacimiento, usuario.CURP, usuario.Rol.IdRol, usuario.Direccion.Colonia.IdColonia, usuario.Direccion.Calle, usuario.Direccion.NumeroExterior, usuario.Direccion.NumeroInterior, usuario.Imagen, usuario.Direccion.IdDireccion);

                        if (query > 0)
                        {
                            result.Correct = true;
                            result.Message = "Usuario actualizado exitosamente";
                        }
                        else
                        {
                            result.Correct = true;
                            result.Message = "Ocurrio un error: El usuario no se pudo actualizar";
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




        public static ML.ResultadosQuerys DeleteEF(int? idUsuario)
        {

            ML.ResultadosQuerys result = new ML.ResultadosQuerys();

            try
            {

                using (DL_EF.EJRamirezProgramacionNCapasEntities context = new DL_EF.EJRamirezProgramacionNCapasEntities())
                {


                    var query = context.UsuarioDeleteSP(idUsuario);

                    if (query > 0)
                    {
                        result.Correct = true;
                        result.Message = "Usuario eliminado exitosamente";
                    }
                    else
                    {
                        result.Correct = true;
                        result.Message = "Ocurrio un error: El usuario no se pudo eliminar";
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







        public static ML.ResultadosQuerys GetAllEF(ML.Usuario usuario)
        {

            ML.ResultadosQuerys result = new ML.ResultadosQuerys();

            try
            {

                using (DL_EF.EJRamirezProgramacionNCapasEntities context = new DL_EF.EJRamirezProgramacionNCapasEntities())
                {

                    var query = context.UsuarioGetAll2(usuario.Nombre, usuario.ApellidoPaterno, usuario.ApellidoMaterno, usuario.Rol.IdRol).ToList();

                    
                    if (query != null)
                    {

                        result.Objects = new List<Object>();


                        foreach (var row in query)
                        {
                            usuario = new ML.Usuario();

                            usuario.IdUsuario = row.IdUsuario;  
                            usuario.UserName = row.UserName;    
                            usuario.Nombre = row.UsuarioNombre;
                            usuario.ApellidoPaterno = row.ApellidoPaterno;  
                            usuario.ApellidoMaterno = row.ApellidoMaterno;  
                            usuario.Email = row.Email;  
                            usuario.Pasword = row.Pasword;  
                            usuario.Sexo = row.Sexo;    
                            usuario.Telefono = row.Telefono;    
                            usuario.Celular = row.Celular;  
                            
                            usuario.CURP = row.CURP;    
                            usuario.FechaNacimiento = row.FechaNacimiento.Value.ToString("dd/MM/yyyy");
                            usuario.Rol = new ML.Rol();
                            usuario.Rol.IdRol = row.IdRol;
                            usuario.Rol.RolName = row.RolName;
                            usuario.Estatus = row.Estatus.Value;

                            usuario.Imagen = row.Imagen;    
                           

                            result.Objects.Add(usuario);        

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





        public static ML.ResultadosQuerys GetByIdEF(int? idUsuario)
        {

            ML.ResultadosQuerys result = new ML.ResultadosQuerys();

            try
            {

                using (DL_EF.EJRamirezProgramacionNCapasEntities context = new DL_EF.EJRamirezProgramacionNCapasEntities())
                {

                    var query = context.UsuarioGetById(idUsuario);


                    if (query != null)
                    {

                        var item = query.FirstOrDefault();

                        result.Object = new object();

                        ML.Usuario usuario = new ML.Usuario();

                        usuario.IdUsuario = item.IdUsuario;
                        usuario.UserName = item.UserName;
                        usuario.Nombre = item.UsuarioNombre;
                        usuario.ApellidoPaterno = item.ApellidoPaterno;
                        usuario.ApellidoMaterno = item.ApellidoMaterno;
                        usuario.Email = item.Email;
                        usuario.Pasword = item.Pasword;
                        usuario.Sexo = item.Sexo;
                        usuario.Telefono = item.Telefono;
                        usuario.Celular = item.Celular;
                        usuario.FechaNacimiento = item.FechaNacimiento.Value.ToString("dd/MM/yyyy");
                        usuario.CURP = item.CURP;

                        usuario.Rol = new ML.Rol();
                        usuario.Rol.IdRol = item.IdRol.Value;
                        usuario.Rol.RolName = item.RolName;

                        usuario.Direccion = new ML.Direccion();
                        usuario.Direccion.IdDireccion = item.IdDireccion;
                        usuario.Direccion.Calle = item.Calle;
                        usuario.Direccion.NumeroExterior = item.NumeroExterior;
                        usuario.Direccion.NumeroInterior = item.NumeroInterior;
                        usuario.Direccion.Colonia = new ML.Colonia();
                        usuario.Direccion.Colonia.IdColonia = item.IdColonia;
                        usuario.Direccion.Colonia.Nombre = item.ColoniaNombre;
                        usuario.Direccion.Colonia.CodigoPostal = item.CodigoPostal;
                        usuario.Direccion.Colonia.Municipio = new ML.Municipio();
                        usuario.Direccion.Colonia.Municipio.IdMunicipio = item.IdMunicipio;
                        usuario.Direccion.Colonia.Municipio.Nombre = item.MunicipioNombre;
                        usuario.Direccion.Colonia.Municipio.Estado = new ML.Estado();
                        usuario.Direccion.Colonia.Municipio.Estado.IdEstado = item.IdEstado;
                        usuario.Direccion.Colonia.Municipio.Estado.Nombre = item.EstadoNombre;
                        usuario.Direccion.Colonia.Municipio.Estado.Pais = new ML.Pais();
                        usuario.Direccion.Colonia.Municipio.Estado.Pais.IdPais = item.IdPais;
                        usuario.Direccion.Colonia.Municipio.Estado.Pais.Nombre = item.PaisNombre;


                        usuario.Imagen = item.Imagen;


                        result.Object = usuario;


                        result.Correct = true;
                    }
                    else
                    {
                        result.Correct = false;
                        result.Message = "No se encontraron resultados";
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




        public static ML.ResultadosQuerys ChangeStatus(int idUsuario, bool status)
        {
            ML.ResultadosQuerys result = new ML.ResultadosQuerys();

            try
            {

                using (DL_EF.EJRamirezProgramacionNCapasEntities context = new DL_EF.EJRamirezProgramacionNCapasEntities())
                {

                    var query = context.UpdateEstatus(idUsuario, status);


                    if (query >= 1)
                    {

                        result.Correct = true;
                    }
                    else
                    {
                        result.Correct = false;
                        result.Message = "No se pudo actualizar el estatus";
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




            // LINQ


            //public static ML.ResultadosQuerys AddLINQ(ML.Usuario usuario)
            //{
            //    ML.ResultadosQuerys result = new ML.ResultadosQuerys();


            //    try
            //    {

            //        using(DL_EF.EJRamirezProgramacionNCapasEntities context = new DL_EF.EJRamirezProgramacionNCapasEntities())
            //        {

            //            DL_EF.Usuario usuarioLINQ = new DL_EF.Usuario();

            //            usuarioLINQ.UserName = usuario.UserName; 
            //            usuarioLINQ.Nombre = usuario.Nombre;
            //            usuarioLINQ.ApellidoPaterno = usuario.ApellidoPaterno;
            //            usuarioLINQ.ApellidoMaterno = usuario.ApellidoMaterno;
            //            usuarioLINQ.Email = usuario.Email; 
            //            usuarioLINQ.Pasword = usuario.Pasword;  
            //            usuarioLINQ.Sexo = usuario.Sexo;    
            //            usuarioLINQ.Telefono = usuario.Telefono;
            //            usuarioLINQ.Celular = usuario.Celular;
            //            usuarioLINQ.FechaNacimiento = usuario.FechaNacimiento;
            //            usuarioLINQ.CURP = usuario.CURP;
            //            usuarioLINQ.IdRol = usuario.Rol.IdRol;

            //            context.Usuarios.Add(usuarioLINQ);

            //           int RowsAfected  = context.SaveChanges();

            //            if (RowsAfected > 0)
            //            {
            //                result.Correct = true;
            //                result.Message = "Usuario agregado exitosamente";
            //            }

            //        }




            //    }
            //    catch (Exception ex)
            //    {
            //        result.Correct = false; 
            //        result.Ex = ex;
            //        result.Message = ex.Message;    
            //    }

            //    return result;


            //}




            //public static ML.ResultadosQuerys UpdateLINQ(ML.Usuario usuario)
            //{
            //    ML.ResultadosQuerys result = new ML.ResultadosQuerys();


            //    try
            //    {

            //        using (DL_EF.EJRamirezProgramacionNCapasEntities context = new DL_EF.EJRamirezProgramacionNCapasEntities())
            //        {


            //            var usuarioLINQ = (from queryLINQ in context.Usuarios
            //                         where queryLINQ.IdUsuario == usuario.IdUsuario
            //                         select queryLINQ).SingleOrDefault();


            //            if (usuarioLINQ != null)
            //            {

            //                usuarioLINQ.UserName = usuario.UserName;
            //                usuarioLINQ.Nombre = usuario.Nombre;
            //                usuarioLINQ.ApellidoPaterno = usuario.ApellidoPaterno;
            //                usuarioLINQ.ApellidoMaterno = usuario.ApellidoMaterno;
            //                usuarioLINQ.Email = usuario.Email;
            //                usuarioLINQ.Pasword = usuario.Pasword;
            //                usuarioLINQ.Sexo = usuario.Sexo;
            //                usuarioLINQ.Telefono = usuario.Telefono;
            //                usuarioLINQ.Celular = usuario.Celular;
            //                usuarioLINQ.FechaNacimiento = usuario.FechaNacimiento;
            //                usuarioLINQ.CURP = usuario.CURP;
            //                usuarioLINQ.IdRol = usuario.Rol.IdRol;

            //                context.SaveChanges();

            //                result.Correct = true;
            //                result.Message = "Usuario actualizado exitosamente";
            //            }


            //        }




            //    }
            //    catch (Exception ex)
            //    {
            //        result.Correct = false;
            //        result.Ex = ex;
            //        result.Message = ex.Message;
            //    }

            //    return result;


            //}



            //public static ML.ResultadosQuerys DeleteLINQ(ML.Usuario usuario)
            //{
            //    ML.ResultadosQuerys result = new ML.ResultadosQuerys();


            //    try
            //    {

            //        using (DL_EF.EJRamirezProgramacionNCapasEntities context = new DL_EF.EJRamirezProgramacionNCapasEntities())
            //        {


            //            var usuarioLINQ = (from queryLINQ in context.Usuarios
            //                               where queryLINQ.IdUsuario == usuario.IdUsuario
            //                               select queryLINQ).First();


            //            context.Usuarios.Remove(usuarioLINQ);


            //            int RowsAffected = context.SaveChanges();

            //            if (RowsAffected > 0)
            //            {
            //                result.Correct = true;
            //                result.Message = "Usuario eliminado exitosamente";
            //            }


            //        }




            //    }
            //    catch (Exception ex)
            //    {
            //        result.Correct = false;
            //        result.Ex = ex;
            //        result.Message = ex.Message;
            //    }

            //    return result;


            //}




            //public static ML.ResultadosQuerys GetAllLINQ()
            //{

            //    ML.ResultadosQuerys result = new ML.ResultadosQuerys();

            //    try
            //    {
            //        using(DL_EF.EJRamirezProgramacionNCapasEntities context = new DL_EF.EJRamirezProgramacionNCapasEntities())
            //        {

            //            var usuarioLINQ = (from queryLINQ in context.Usuarios
            //                               join RolLINQ in context.Rols on queryLINQ.IdRol equals RolLINQ.IdRol
            //                               select new 
            //                               {
            //                                   IdUsuario = queryLINQ.IdUsuario, 
            //                                   UserName = queryLINQ.UserName,   
            //                                   Nombre = queryLINQ.Nombre,
            //                                   ApellidoPaterno = queryLINQ.ApellidoPaterno,
            //                                   ApellidoMaterno = queryLINQ.ApellidoMaterno,
            //                                   Email = queryLINQ.Email,
            //                                   Pasword = queryLINQ.Pasword, 
            //                                   Sexo = queryLINQ.Sexo,
            //                                   Telefono = queryLINQ.Telefono,   
            //                                   Celular = queryLINQ.Celular,
            //                                   FechaNacimiento = queryLINQ.FechaNacimiento,
            //                                   CURP = queryLINQ.CURP,
            //                                   IdRol = queryLINQ.IdRol, 
            //                                   RolName = queryLINQ.Rol.RolName
            //                               });

            //            result.Objects = new List<Object>();

            //            if (usuarioLINQ != null  || usuarioLINQ.ToList().Count > 0)
            //            {

            //                foreach (var item in usuarioLINQ)
            //                {
            //                    ML.Usuario usuario = new ML.Usuario();

            //                    usuario.IdUsuario = item.IdUsuario;
            //                    usuario.UserName = item.UserName;
            //                    usuario.Nombre = item.Nombre; 
            //                    usuario.ApellidoPaterno = item.ApellidoPaterno; 
            //                    usuario.ApellidoMaterno = item.ApellidoMaterno; 
            //                    usuario.Email = item.Email;
            //                    usuario.Pasword = item.Pasword;
            //                    usuario.Sexo = item.Sexo;
            //                    usuario.Telefono = item.Telefono;
            //                    usuario.Celular = item.Celular; 
            //                    usuario.FechaNacimiento = item.FechaNacimiento;
            //                    usuario.CURP = item.CURP; 

            //                    usuario.Rol = new ML.Rol();
            //                    usuario.Rol.IdRol = item.IdRol.Value;
            //                    usuario.Rol.RolName = item.RolName; 

            //                    result.Objects.Add(usuario);    
            //                }

            //                result.Correct = true;
            //            }
            //            else
            //            {
            //                result.Correct = false;
            //                result.Message = "No se encontraron registros";
            //            }



            //        }



            //    }
            //    catch ( Exception ex)
            //    {
            //        result.Correct = false;
            //        result.Ex = ex;
            //        result.Message = ex.Message;
            //        throw;
            //    }


            //    return result;


            //}







            //public static ML.ResultadosQuerys GetByIdLINQ(ML.Usuario usuario)
            //{

            //    ML.ResultadosQuerys result = new ML.ResultadosQuerys();

            //    try
            //    {

            //        using(DL_EF.EJRamirezProgramacionNCapasEntities context = new DL_EF.EJRamirezProgramacionNCapasEntities())
            //        {

            //            var query = (from UsuarioLINQ in context.Usuarios
            //                               join RolLINQ in context.Rols on UsuarioLINQ.IdRol equals RolLINQ.IdRol
            //                               where UsuarioLINQ.IdUsuario == usuario.IdUsuario
            //                               select new
            //                               {
            //                                   IdUsuario = UsuarioLINQ.IdUsuario,
            //                                   UserName = UsuarioLINQ.UserName,
            //                                   Nombre = UsuarioLINQ.Nombre,
            //                                   ApellidoPaterno = UsuarioLINQ.ApellidoPaterno,
            //                                   ApellidoMaterno = UsuarioLINQ.ApellidoMaterno,
            //                                   Email = UsuarioLINQ.Email,
            //                                   Pasword = UsuarioLINQ.Pasword,
            //                                   Sexo = UsuarioLINQ.Sexo,
            //                                   Telefono = UsuarioLINQ.Telefono,
            //                                   Celular = UsuarioLINQ.Celular,
            //                                   FechaNacimiento = UsuarioLINQ.FechaNacimiento,
            //                                   CURP = UsuarioLINQ.CURP,
            //                                   IdRol = UsuarioLINQ.IdRol,
            //                                   RolName = UsuarioLINQ.Rol.RolName
            //                               });

            //            result.Object = new object();


            //            if(query != null || query.ToList().Count() > 0 )
            //            {

            //                var item = query.FirstOrDefault();  

            //                ML.Usuario usuarioGet = new ML.Usuario();  


            //                usuarioGet.IdUsuario = item.IdUsuario;
            //                usuarioGet.UserName = item.UserName;    
            //                usuarioGet.Nombre = item.Nombre;    
            //                usuarioGet.ApellidoPaterno = item.ApellidoPaterno;  
            //                usuarioGet.ApellidoMaterno = item.ApellidoMaterno;
            //                usuarioGet.CURP = item.CURP;
            //                usuarioGet.Celular = item.Celular;
            //                usuarioGet.Telefono = item.Telefono;
            //                usuarioGet.Sexo = item.Sexo;
            //                usuarioGet.FechaNacimiento = item.FechaNacimiento;  
            //                usuarioGet.Email = item.Email;
            //                usuarioGet.Pasword = item.Pasword;

            //                usuarioGet.Rol = new ML.Rol();
            //                usuarioGet.Rol.IdRol = item.IdRol.Value;
            //                usuarioGet.Rol.RolName = item.RolName;

            //                result.Object = usuarioGet;

            //                result.Correct = true;

            //            }
            //            else
            //            {
            //                result.Correct = false;
            //                result.Message = "No se encontraron resultados";
            //            }

            //        }


            //    }
            //    catch (Exception ex)
            //    {
            //        result.Correct = false;
            //        result.Ex = ex;
            //        result.Message = ex.Message;
            //        throw;
            //    }
            //    return result;
            //}




        }
}
