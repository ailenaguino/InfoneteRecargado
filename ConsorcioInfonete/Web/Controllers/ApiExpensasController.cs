using System;
﻿using Repositories.Context;
using Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Repositories.Context;
using Common;
using Services;

namespace Web.Controllers
{
    public class ApiExpensasController : ApiController
    {


        ConsorcioService consorcioService;
        ApiExpensasService expensasService;


        public ApiExpensasController()
        {
            PW3_TP_20202CEntities contexto = new PW3_TP_20202CEntities();
            consorcioService = new ConsorcioService(contexto);
            expensasService = new ApiExpensasService(contexto);
        
        }

        // GET: api/ApiExpensas
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }
       
        // GET: api/ApiExpensas/5
        public List<Expensa> Get(int id)
        {
            List<Expensa> expensas= expensasService.ObtenerExpensas(id);
            return expensas;
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
