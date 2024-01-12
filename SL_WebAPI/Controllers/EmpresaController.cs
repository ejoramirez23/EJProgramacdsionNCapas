using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace SL_WebAPI.Controllers
{

    [Route("api/empresa/")]
    public class EmpresaController : ApiController
    {
        // GET: api/Empresa
        [HttpGet]
        [Route("GetAll")]
        public IHttpActionResult GetAll()
        {


            ML.ResultadosQuerys result = BL.Empresa.EmpresaGetAllEF();

            if (result.Correct)
            {
                return Ok(result);
            }
            else
            {
                return NotFound();
            }


            //return new string[] { "value1", "value2" };
        }

        // GET: api/Empresa/5
        public string Get(int id)
        {
            return "value";
        }




        // POST: api/Empresa

        [HttpPost]
        [Route("Add")]
        public IHttpActionResult Add([FromBody] ML.Empresa empresa)
        {
            ML.ResultadosQuerys result = BL.Empresa.EmpresaAddEF(empresa);

            if (result.Correct)
            {
                return Ok(result);
            }
            else
            {
                return BadRequest(result.Message);
            }

        }



        [HttpGet]
        [Route("GetbyId/{IdEmpresa}")]

        public IHttpActionResult GetbyId(int IdEmpresa)
        {
            var result = BL.Empresa.EmpresaGetByIdEF(IdEmpresa);

            if (result.Correct)
            {
                return Ok(result);
            }
            else
            {
                return NotFound();
            }
        }




        // PUT: api/Empresa/5
        [HttpPost]
        [Route("Update/{IdEmpresa}")]
        public IHttpActionResult Update(int IdEmpresa, [FromBody] ML.Empresa empresa)
        {

            ML.ResultadosQuerys result = BL.Empresa.EmpresaUpdateEF(empresa);

            if (result.Correct)
            {
                return Ok(result);
            }
            else
            {
                return NotFound();
            }

        }






        // DELETE: api/Empresa/5
        [HttpGet]
        [Route("Delete/{IdEmpresa}")]
        public IHttpActionResult Delete(int IdEmpresa)
        {

            var result = BL.Empresa.EmpresaDeleteEF(IdEmpresa);

            if (result.Correct)
            {
                return Ok(result);
            }
            else
            {
                return NotFound();
            }
        }
    }
}

