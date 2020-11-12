using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Repositories.Context;
using Services;

namespace Web.Controllers
{
    public class ApiExpensasController : ApiController
    {

        E consorcioService;


        public ApiExpensasController()
        {
            PW3_TP_20202CEntities contexto = new PW3_TP_20202CEntities();
            consorcioService = new ConsorcioService(contexto);
        }
        // GET: api/ApiExpensas
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET: api/ApiExpensas/5
        public string Get(int id)
        {
           
        }

        // POST: api/ApiExpensas
        public void Post([FromBody]string value)
        {

        }

        // PUT: api/ApiExpensas/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/ApiExpensas/5
        public void Delete(int id)
        {
        }
    }
}
