using System;
using System.Collections.Generic;
using System.Data;
using System.Data.OleDb;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL
{
    public class Empresa
    {




        //***************************************** EF EMPRESA ******************************************

        public static ML.ResultadosQuerys EmpresaAddEF(ML.Empresa empresa)
        {

            ML.ResultadosQuerys result = new ML.ResultadosQuerys();


            try
            {


                using(DL_EF.EJRamirezProgramacionNCapasEntities context = new DL_EF.EJRamirezProgramacionNCapasEntities())
                {


                  

                        var query = context.EmpresaAdd(empresa.Nombre, empresa.Telefono, empresa.Email, empresa.DireccionWeb);


                        if (query > 0)
                        {
                            result.Correct = true;
                            result.Message = "Empresa agregada exitosamente !";

                        }
                        else
                        {
                            result.Correct = false;
                            result.Message = "Empresa no pudo ser agregada !";
                        }
                    }

                



            }
            catch (Exception ex)
            {
                result.Correct = false;
                result.Message = ex.Message;    
                throw;
            }

            return result;
        }




        public static ML.ResultadosQuerys EmpresaUpdateEF(ML.Empresa empresa)
        {

            ML.ResultadosQuerys result = new ML.ResultadosQuerys();


            try
            {


                using (DL_EF.EJRamirezProgramacionNCapasEntities context = new DL_EF.EJRamirezProgramacionNCapasEntities())
                {

                    var query = context.EmpresaUpdate(empresa.Nombre, empresa.Telefono, empresa.Email, empresa.DireccionWeb, empresa.IdEmpresa);


                    if (query > 0)
                    {
                        result.Correct = true;
                        result.Message = "Empresa actualizada exitosamente !";
                    }
                    else
                    {
                        result.Correct = false;
                        result.Message = "Empresa no pudo ser actualizada !";
                    }


                }



            }
            catch (Exception ex)
            {
                result.Correct = false;
                result.Message = ex.Message;
                throw;
            }

            return result;
        }




        public static ML.ResultadosQuerys EmpresaDeleteEF(int? idEmpresa)
        {

            ML.ResultadosQuerys result = new ML.ResultadosQuerys();


            try
            {


                using (DL_EF.EJRamirezProgramacionNCapasEntities context = new DL_EF.EJRamirezProgramacionNCapasEntities())
                {

                    var query = context.EmpresaDelete(idEmpresa);


                    if (query > 0)
                    {
                        result.Correct = true;
                        result.Message = "Empresa eliminada exitosamente !";
                    }
                    else
                    {
                        result.Correct = false;
                        result.Message = "Empresa no pudo ser eliminada !";
                    }


                }



            }
            catch (Exception ex)
            {
                result.Correct = false;
                result.Message = ex.Message;
                throw;
            }

            return result;
        }


        public static ML.ResultadosQuerys EmpresaGetAllEF()
        {

            ML.ResultadosQuerys result = new ML.ResultadosQuerys();


            try
            {

                using (DL_EF.EJRamirezProgramacionNCapasEntities context = new DL_EF.EJRamirezProgramacionNCapasEntities())
                {

                    var query = context.EmpresaGetAll();

                    if(query != null) 
                    {
                        result.Objects = new List<Object>();

                        foreach (var item in query)
                        {
                            ML.Empresa empresa = new ML.Empresa();

                            empresa.IdEmpresa = item.IdEmpresa; 
                            empresa.Nombre = item.Nombre;   
                            empresa.Telefono = item.Telefono;   
                            empresa.Email = item.Email;
                            empresa.DireccionWeb = item.DireccionWeb;


                            result.Objects.Add(empresa);

                        }

                        result.Correct = true;

                    }
                    else
                    {
                        result.Correct = true;
                        result.Message = "No se encontraron resultados";
                    }

                }


            }
            catch (Exception ex)
            {
                result.Correct = false;
                result.Message = ex.Message;
                throw;
            }

            return result;

        }




        public static ML.ResultadosQuerys EmpresaGetByIdEF(int? idEmpresa)
        {

            ML.ResultadosQuerys result = new ML.ResultadosQuerys();


            try
            {

                using (DL_EF.EJRamirezProgramacionNCapasEntities context = new DL_EF.EJRamirezProgramacionNCapasEntities())
                {

                    var query = context.EmpresaGetById(idEmpresa);

                    if (query != null)
                    {
                        result.Object = new object();

                        var item = query.FirstOrDefault();
                       
                        ML.Empresa empresaGet = new ML.Empresa();

                        empresaGet.IdEmpresa = item.IdEmpresa;
                        empresaGet.Nombre = item.Nombre;
                        empresaGet.Telefono = item.Telefono;
                        empresaGet.Email = item.Email;
                        empresaGet.DireccionWeb = item.DireccionWeb;


                            result.Object = empresaGet;

                     

                        result.Correct = true;

                    }
                    else
                    {
                        result.Correct = true;
                        result.Message = "No se encontraron resultados";
                    }

                }


            }
            catch (Exception ex)
            {
                result.Correct = false;
                result.Message = ex.Message;
                throw;
            }

            return result;

        }


        //***************************************** LINKQ EMPRESA ******************************************


        public static ML.ResultadosQuerys EmpresaAddLINQ(ML.Empresa empresa)
        {

            ML.ResultadosQuerys result = new ML.ResultadosQuerys();


            try
            {


                using (DL_EF.EJRamirezProgramacionNCapasEntities context = new DL_EF.EJRamirezProgramacionNCapasEntities())
                {

                    DL_EF.Empresa empresaLINQ = new DL_EF.Empresa();

                    empresaLINQ.Nombre = empresa.Nombre;
                    empresaLINQ.Telefono = empresa.Telefono;
                    empresaLINQ.Email = empresa.Email;
                    empresaLINQ.DireccionWeb = empresa.DireccionWeb;
                    
                   
                    context.Empresas.Add(empresaLINQ);

                    int RowsAfected = context.SaveChanges();

                    if (RowsAfected > 0)
                    {
                        result.Correct = true;
                        result.Message = "Empresa agregada exitosamente";
                    }
                    else
                    {
                        result.Correct = false;
                        result.Message = "Empresa no pudo ser agregada !";
                    }

                }




            }
            catch (Exception ex)
            {
                result.Correct = false;
                result.Message = ex.Message;
                throw;
            }

            return result;
        }





        public static ML.ResultadosQuerys EmpresaUpdateLINQ(ML.Empresa empresa)
        {

            ML.ResultadosQuerys result = new ML.ResultadosQuerys();


            try
            {


                using (DL_EF.EJRamirezProgramacionNCapasEntities context = new DL_EF.EJRamirezProgramacionNCapasEntities())
                {
                    var empresaLINQ = (from queryLINQ in context.Empresas
                                       where queryLINQ.IdEmpresa == empresa.IdEmpresa
                                       select queryLINQ).SingleOrDefault();


              


                    if (empresaLINQ != null)
                    {

                        empresaLINQ.Nombre = empresa.Nombre;
                        empresaLINQ.Telefono = empresa.Telefono;
                        empresaLINQ.Email = empresa.Email;
                        empresaLINQ.DireccionWeb = empresa.DireccionWeb;
                      
                        context.SaveChanges();

                        result.Correct = true;
                        result.Message = "Empresa actualizada exitosamente !";
                    }
                    else
                    {
                        result.Correct = false;
                        result.Message = "Empresa no pudo se actualizada !";
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





        public static ML.ResultadosQuerys EmpresaDeleteLINQ(ML.Empresa empresa)
        {

            ML.ResultadosQuerys result = new ML.ResultadosQuerys();


            try
            {


                using (DL_EF.EJRamirezProgramacionNCapasEntities context = new DL_EF.EJRamirezProgramacionNCapasEntities())
                {

                    var empresaLINQ = (from queryLINQ in context.Empresas
                                       where queryLINQ.IdEmpresa == empresa.IdEmpresa
                                       select queryLINQ).First();


                    context.Empresas.Remove(empresaLINQ);


                    int RowsAffected = context.SaveChanges();

                    if (RowsAffected > 0) 
                    {
                        result.Correct = true;
                        result.Message = "Empresa eliminada exitosamente !";
                    }
                    else
                    {
                        result.Correct = false;
                        result.Message = "Empresa no pudo ser eliminada !";
                    }

                }




            }
            catch (Exception ex)
            {
                result.Correct = false;
                result.Message = ex.Message;
                throw;
            }

            return result;
        }



        public static ML.ResultadosQuerys EmpresaGetAllLINQ()
        {

            ML.ResultadosQuerys result = new ML.ResultadosQuerys();


            try
            {


                using (DL_EF.EJRamirezProgramacionNCapasEntities context = new DL_EF.EJRamirezProgramacionNCapasEntities())
                {

                    var query = (from queryLINQ in context.Empresas
                                       select new{
                                        IdEmpresa = queryLINQ.IdEmpresa,
                                        Nombre = queryLINQ.Nombre,
                                        Telefono = queryLINQ.Telefono,  
                                        Email = queryLINQ.Email,
                                        DireccionWeb = queryLINQ.DireccionWeb
                                        });


                    if (query != null  || query.ToList().Count > 0)
                    {
                        result.Objects = new List<object>();

                        foreach (var item in query)
                        {
                            ML.Empresa empresa = new ML.Empresa();

                            empresa.IdEmpresa = item.IdEmpresa; 
                            empresa.Nombre = item.Nombre;
                            empresa.Telefono = item.Telefono;
                            empresa.Email = item.Email;
                            empresa.DireccionWeb = item.DireccionWeb;

                            result.Objects.Add(empresa);
                        }

                        result.Correct = true;

                    }
                    else
                    {
                        result.Correct = false;
                        result.Message = "No se encontraron registros";
                    }




                }




            }
            catch (Exception ex)
            {
                result.Correct = false;
                result.Message = ex.Message;
                throw;
            }

            return result;
        }





        public static ML.ResultadosQuerys EmpresaGetByIdLINQ(ML.Empresa empresa)
        {

            ML.ResultadosQuerys result = new ML.ResultadosQuerys();


            try
            {


                using (DL_EF.EJRamirezProgramacionNCapasEntities context = new DL_EF.EJRamirezProgramacionNCapasEntities())
                {

                    var query = (from queryLINQ in context.Empresas
                                 where queryLINQ.IdEmpresa == empresa.IdEmpresa
                                 select new
                                 {
                                     IdEmpresa = queryLINQ.IdEmpresa,
                                     Nombre = queryLINQ.Nombre,
                                     Telefono = queryLINQ.Telefono,
                                     Email = queryLINQ.Email,
                                     DireccionWeb = queryLINQ.DireccionWeb
                                 });


                    if (query != null || query.ToList().Count > 0)
                    {
                        result.Object = new object();

                        var item = query.ToList().First();

                     
                            ML.Empresa empresaGet = new ML.Empresa();

                            empresa.IdEmpresa = item.IdEmpresa;
                            empresa.Nombre = item.Nombre;
                            empresa.Telefono = item.Telefono;
                            empresa.Email = item.Email;
                            empresa.DireccionWeb = item.DireccionWeb;

                            result.Object = empresa;
                        
                        result.Correct = true;

                    }
                    else
                    {
                        result.Correct = false;
                        result.Message = "No se encontraron registros";
                    }




                }




            }
            catch (Exception ex)
            {
                result.Correct = false;
                result.Message = ex.Message;
                throw;
            }

            return result;
        }





        public static ML.Empresa  PrevizualizarExcel(ML.Empresa empresa, string rutaProyecto, string connectionStringExcel)
        {

            empresa.IsValidExcel = true;

            try
            {
                using (OleDbConnection context = new OleDbConnection(connectionStringExcel + rutaProyecto))
                {
                    string query = "SELECT * FROM [Hoja1$]";

                    using (OleDbCommand cmd = new OleDbCommand())
                    {
                        cmd.CommandText = query;
                        cmd.Connection = context;

                        OleDbDataAdapter dAdapter = new OleDbDataAdapter();
                        dAdapter.SelectCommand = cmd;

                        DataTable tablaEmpresa = new DataTable();

                        try
                        {
                            dAdapter.Fill(tablaEmpresa);
                        }
                        catch (Exception ex)
                        {

                        }

                        if (tablaEmpresa.Rows.Count > 0)
                        {
                            empresa.Empresas = new List<object>();

                            foreach (DataRow row in tablaEmpresa.Rows)
                            {
                                ML.Empresa empresaItem = new ML.Empresa();
                                empresaItem.Nombre = (row[0].ToString() == null || row[0].ToString() == "") ? "" : row[0].ToString();
                                empresaItem.Telefono = (row[1].ToString() == null || row[1].ToString() == "") ? "" : row[1].ToString();
                                empresaItem.Email = (row[2].ToString() == null || row[2].ToString() == "") ? "" : row[2].ToString();
                                empresaItem.DireccionWeb = (row[3].ToString() == null || row[3].ToString() == "") ? "" : row[3].ToString();

                                string errores = ValidarDatos(empresaItem);

                                if (errores == "")
                                {
                                    empresaItem.ErrorMessage = "";
                                }
                                else
                                {
                                    empresaItem.ErrorMessage = errores;
                                    empresa.IsValidExcel = false;
                                }

                                empresa.Empresas.Add(empresaItem);  


                            }


                        }


                    }
                }

            }
            catch (Exception ex)
            {

            }


                 

            return empresa;
        }



        public static string ValidarDatos(ML.Empresa empresa)
        {
            string errores = "";

            if(empresa.Nombre == "")
            {
                errores = "El nombre no puede ir null";
            }

            if (empresa.Telefono == "")
            {
                errores +=  "El Telefono no puede ir null";
            }

            if (empresa.Email == "")
            {
                errores = "El Email no puede ir null";
            }

            if (empresa.DireccionWeb == "")
            {
                errores = "La Direccion web no puede ir null";
            }

            return errores;
            
        }


    }
}
