using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Mvc;
using Newtonsoft.Json;
using Repositories.Models;

namespace Web.Controllers
{
    public class ExpensasController : Controller
    {
        // GET: Expensas
        public ActionResult Lista(int id)
        {
            var url = $"https://{HttpContext.Request.Url.Authority}/api/apiexpensas/{id}";
            var request = (HttpWebRequest)WebRequest.Create(url);
            request.Method = "GET";
            request.ContentType = "application/json";
            request.Accept = "application/json";
            List<Expensa> result;
            using (WebResponse response = request.GetResponse())
            {
                using (Stream strReader = response.GetResponseStream())
                {
                    if (strReader == null)
                    {
                        return View(new List<Expensa>());
                    }
                    using (StreamReader objReader = new StreamReader(strReader))
                    {
                        string responseBody = objReader.ReadToEnd();
                         result = JsonConvert.DeserializeObject<List<Expensa>>(responseBody);
                       
                    }
                }
            }

            Expensa ultimo = null;

            if (!(result == null || result.Count == 0))
            {
                ultimo = result.Find(expensa => expensa.Año == DateTime.Now.Year && expensa.Mes == DateTime.Now.Month);
            }

            ViewBag.Ultimo = ultimo;
            return View(result);
        }
    }
}