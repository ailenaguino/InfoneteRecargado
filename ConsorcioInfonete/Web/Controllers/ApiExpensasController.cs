using System;
﻿using Repositories.Context;
using Services;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Web.Http;
using Repositories.Models;

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
       
        public List<Expensa> Get(int id)
        {
            List<Expensa> expensas= expensasService.ObtenerExpensas(id);
            return expensas;
        }

    }
}
