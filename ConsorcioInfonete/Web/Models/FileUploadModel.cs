using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Web.Models
{
    public class FileUploadModel
    {
        public HttpPostedFileBase file { get; set; }
        public GastoVM gasto { get; set; }




    }
}