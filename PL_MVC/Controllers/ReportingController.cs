using Microsoft.Reporting.WebForms;
using PL_MVC.Reports;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.UI.WebControls;

namespace PL_MVC.Controllers
{
    public class ReportingController : Controller
    {
        // GET: Reporting
        DataSetAseguradora dataSetAseguradora = new DataSetAseguradora();
        public ActionResult ShowReport()
                {

            ML.ResultadosQuerys result = new ML.ResultadosQuerys();

            ReportViewer reportViewer = new ReportViewer();
            reportViewer.ProcessingMode = ProcessingMode.Local;
            reportViewer.SizeToReportContent = true;
            reportViewer.Width = Unit.Percentage(1300);
            reportViewer.Height = Unit.Percentage(1300);
            var connectionString = ConfigurationManager.ConnectionStrings["EJRamirezProgramacionNCapasConnectionString"].ConnectionString;
            SqlConnection context = new SqlConnection(connectionString);

            string query = "SELECT EP.Nombre,COUNT(EM.Nombre) FROM Empresa AS EP LEFT JOIN Empleado AS EM ON EM.IdEmpresa = EP.IdEmpresa GROUP BY EM.Nombre, EP.Nombre";



            SqlCommand cmd = new SqlCommand(query, context);

           

            SqlDataAdapter dataAdapter = new SqlDataAdapter(query, context);
            dataAdapter.Fill(dataSetAseguradora, dataSetAseguradora.GraficaEmpresa.ToString());

            //SqlDataAdapter dataAdapter1 = new SqlDataAdapter("SELECT * FROM Empleado", context);
            //dataAdapter.Fill(dataSetAseguradora, dataSetAseguradora.Empleado.ToString());


            reportViewer.LocalReport.ReportPath = Request.MapPath(Request.ApplicationPath) + @"Reports\Report1.rdlc";
            reportViewer.LocalReport.DataSources.Add(new ReportDataSource("DataSetAseguradora", dataSetAseguradora.Tables[0]));
            //reportViewer.LocalReport.DataSources.Add(new ReportDataSource("DataSetAseguradora", dataSetAseguradora.Tables[1]));
            //dataAdapter.Fill(dataSetAseguradora, dataSetAseguradora.Empleado.ToString());


            ViewBag.ReportViewer = reportViewer;



    


            return View();
        }
    }
}