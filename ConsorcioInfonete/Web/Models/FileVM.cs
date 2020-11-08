using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;

namespace Web.Models
{
    public class FileVM: HttpPostedFileBase
    {
        public string fileName { get; set; }
        
        public FileVM()
        {

        }
        public FileVM(string s)
        {
            fileName = s;
        }
        public void GuardarArchivo(HttpPostedFileBase file,HttpServerUtilityBase server)
        {
            var fileName = Path.GetFileName(file.FileName);
            var path = Path.Combine(server.MapPath("~/Gastos/"), fileName);
            file.SaveAs(path);            
        }
    }
}