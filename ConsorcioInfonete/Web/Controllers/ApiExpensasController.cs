<<<<<<< HEAD
﻿using System;
=======
﻿using Repositories.Context;
using Services;
using System;
>>>>>>> 2b1959087e64063461057dbe6e5b0429679f2087
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
<<<<<<< HEAD
using Repositories.Context;
using Services;
=======
>>>>>>> 2b1959087e64063461057dbe6e5b0429679f2087

namespace Web.Controllers
{
    public class ApiExpensasController : ApiController
    {
<<<<<<< HEAD

        E consorcioService;
=======
        ApiExpensasService expensasService;
>>>>>>> 2b1959087e64063461057dbe6e5b0429679f2087


        public ApiExpensasController()
        {
            PW3_TP_20202CEntities contexto = new PW3_TP_20202CEntities();
<<<<<<< HEAD
            consorcioService = new ConsorcioService(contexto);
        }
=======
            expensasService = new ApiExpensasService(contexto);
        }

>>>>>>> 2b1959087e64063461057dbe6e5b0429679f2087
        // GET: api/ApiExpensas
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET: api/ApiExpensas/5
        public string Get(int id)
        {
<<<<<<< HEAD
           
=======
            return "value";
>>>>>>> 2b1959087e64063461057dbe6e5b0429679f2087
        }

        // POST: api/ApiExpensas
        public void Post([FromBody]string value)
        {
<<<<<<< HEAD

=======
>>>>>>> 2b1959087e64063461057dbe6e5b0429679f2087
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
